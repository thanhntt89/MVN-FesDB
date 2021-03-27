using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace Festival.DBTab.RecommendProgramManagement
{
    public partial class RecommendProgramMain : FormBase
    {
        private RecommendProgramBusiness recommendProgramBusiness;       

        public RecommendProgramMain()
        {
            InitializeComponent();
        }

        private void RecommendProgramMain_Load(object sender, EventArgs e)
        {
            InitLayoutMain();
            InitData();
            LoadData();
        }

        private void InitLayoutMain()
        {
            dataGridViewFilter.Location = new System.Drawing.Point(3, btnSave.Location.Y + 2 * this.dataGridViewFilter.Margin.Left);
            this.dataGridViewFilter.Size = new System.Drawing.Size(this.Size.Width - 20, this.Size.Height - 3 * btnSave.Height - 20);
        }

        public void InitData()
        {
            recommendProgramBusiness = new RecommendProgramBusiness();
            dataGridViewFilter.DataGridViewSource = dtgRecommendSong;
            dataGridViewFilter.ColumnKeyDataPropertyName = colプログラムID.DataPropertyName;
            dataGridViewFilter.ColumnKeyName = colプログラムID.Name;
            dataGridViewFilter.ColumnUpdateTimeDataPropertyName = colDateTimeUpdate.DataPropertyName;
            dataGridViewFilter.ColumnUpdateTimeName = colDateTimeUpdate.Name;
            dataGridViewFilter.ColumnDeletedDataPropertyName = colDelete.DataPropertyName;

            dataGridViewFilter.CellClickedEvent += Delete;
            dataGridViewFilter.RowLeaveEvent += RowLeaveEvent;
            dataGridViewFilter.CellEndEditEvent += CellEndEditEvent;

            dataGridViewFilter.AllowUserEdit = true;          
            // set struct datagridview           
            dataGridViewFilter.InitData();
        }

        private void UserAddedRowEvent(DataGridViewCell cell)
        {
            if (cell == null || cell.OwningRow.Index == cell.DataGridView.Rows.Count - 1 || cell.OwningColumn.Name.Equals(colDelete.Name))
                return;

            string currentId = cell.OwningRow.Cells[colプログラムID.Name].Value.ToString();
            string oldId = cell.OwningRow.Cells[colOldプログラムID.Name].Value.ToString();

            // If update
            if (!currentId.Equals(oldId))
            {
                if (!CheckExistId(currentId))
                {
                    cell.OwningRow.Cells[colプログラムID.Name].Value = oldId;
                    cell.OwningRow.Cells[colDateTimeUpdate.Name].Value = DBNull.Value;
                    cell.OwningRow.Cells[colプログラムID.Name].Selected = true;
                    cell.DataGridView.BeginEdit(true);
                    return;
                }
            }

            Save(cell);
        }

        private void RowLeaveEvent(DataGridViewCell cell)
        {           
            if (cell == null || cell.OwningRow.Index == cell.DataGridView.Rows.Count - 1 || cell.OwningColumn.Name.Equals(colDelete.Name))
                return;

            string currentId = cell.OwningRow.Cells[colプログラムID.Name].Value.ToString();
            string oldId = cell.OwningRow.Cells[colOldプログラムID.Name].Value.ToString();

            // If update
            if (!currentId.Equals(oldId))
            {
                if (!CheckExistId(currentId))
                {
                    cell.OwningRow.Cells[colプログラムID.Name].Value = oldId;
                    cell.OwningRow.Cells[colDateTimeUpdate.Name].Value = DBNull.Value;
                    cell.OwningRow.Cells[colプログラムID.Name].Selected = true;
                    return;
                }
            }

            Save(cell);
        }

        private void SetUpdateData(DataGridViewCell cell)
        {
            try
            {
                string currentId = cell.OwningRow.Cells[colプログラムID.Name].Value.ToString();

                cell.OwningRow.Cells[colOldプログラムID.Name].Value = currentId;
                cell.OwningRow.Cells[colDateTimeUpdate.Name].Value = DBNull.Value;
            }
            catch (Exception ex)
            {
                this.ClosedWaiting();
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = Constants.LOG_FILE_PATH_ERROR
                };

                LogException(error);
                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        private void CellEndEditEvent(DataGridViewCell cell)
        {
            if (cell == null || cell.OwningColumn.Name.Equals(colDelete.Name) || cell.OwningRow.Index == cell.DataGridView.Rows.Count - 1)
                return;

            string currentId = cell.OwningRow.Cells[colプログラムID.Name].Value.ToString();
            string oldId = cell.OwningRow.Cells[colOldプログラムID.Name].Value.ToString();

            // If update
            if (!currentId.Equals(oldId))
            {
                if (!CheckExistId(currentId))
                {
                    cell.OwningRow.Cells[colプログラムID.Name].Value = oldId;
                    cell.OwningRow.Cells[colDateTimeUpdate.Name].Value = DBNull.Value;
                    cell.OwningRow.Cells[colプログラムID.Name].Selected = true;
                    return;
                }
            }
        }

        private void EditData(DataGridViewCell cell)
        {
            UpdateRow();
        }

        public void LoadData()
        {
            DisplayThread();
        }

        private void DisplayThread()
        {
            if (bgwProcess == null)
                bgwProcess = CreateThread();

            bgwProcess.RunWorkerCompleted += DisPlayCompleted;
            bgwProcess.DoWork += DisplayDoWork;
            bgwProcess.RunWorkerAsync();
            this.ShowWating();
        }

        private void DisplayDoWork(object sender, DoWorkEventArgs e)
        {
            ExecuteLoadData();
        }

        private void ExecuteLoadData()
        {
            try
            {
                Invoke(new Action(() =>
                {
                    // Get data from work table
                    dataGridViewFilter.DataTableSource = recommendProgramBusiness.GetRecommendProgramTable();
                    dataGridViewFilter.LoadData();
                }));
            }
            catch (Exception ex)
            {
                this.ClosedWaiting();
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = Constants.LOG_FILE_PATH_ERROR
                };

                LogException(error);
                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        private void DisPlayCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.ClosedWaiting();

            if (bgwProcess != null)
            {
                bgwProcess.DoWork -= DisplayDoWork;
                bgwProcess.RunWorkerCompleted -= DisPlayCompleted;
                bgwProcess.Dispose();
            }

            bgwProcess = null;
            GC.Collect();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateRow();
        }

        private void UpdateRow()
        {
            if (!btnUpdate.Enabled)
                return;

            RecommendProgramRegister singerRegister = new RecommendProgramRegister(dataGridViewFilter.CurrentKeyValue);
            singerRegister.ShowDialog();
            if (singerRegister.IsActive)
                LoadData();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            RecommendProgramRegister singerRegister = new RecommendProgramRegister();
            singerRegister.AddNewRowEvent += AddNewRow;
            singerRegister.ShowDialog();
        }

        public void AddNewRow(object dataRow)
        {
            try
            {
                DataTable tbData = dataRow as DataTable;
                if (tbData == null || tbData.Rows.Count == 0)
                    return;

                RowAddNewObject rowAdd = new RowAddNewObject();

                rowAdd.KeyId = tbData.Rows[0][colプログラムID.DataPropertyName].ToString();
                var プログラム名 = tbData.Rows[0][colプログラム名.DataPropertyName].ToString();
                var 備考 = tbData.Rows[0][col備考.DataPropertyName].ToString();
                rowAdd.Columns.Add(new ColumnObject { ColumnIndex = colプログラムID.Index, ColumnName = colプログラムID.Name, ColumnDataPropertyName = colプログラムID.DataPropertyName, Data = rowAdd.KeyId });
                rowAdd.Columns.Add(new ColumnObject { ColumnIndex = colプログラム名.Index, ColumnName = colプログラム名.Name, ColumnDataPropertyName = colプログラム名.DataPropertyName, Data = プログラム名 });
                rowAdd.Columns.Add(new ColumnObject { ColumnIndex = col備考.Index, ColumnName = col備考.Name, ColumnDataPropertyName = col備考.DataPropertyName, Data = 備考 });

                dataGridViewFilter.AddNewRow(rowAdd);

                rowAdd = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                this.ClosedWaiting();

                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = Constants.LOG_FILE_PATH_ERROR
                };

                LogException(error);

                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        private void Delete(DataGridViewCell cell)
        {
            if (cell == null || !cell.OwningColumn.Name.Equals(colDelete.Name) || cell.OwningRow.Index == cell.DataGridView.Rows.Count - 1)
                return;

            if (cell.OwningRow.Cells[colOldプログラムID.Name].Value == DBNull.Value)
            {
                LoadData();
                return;
            }

            string data = cell.OwningRow.Cells[colプログラム名.Name].Value.ToString();
            string message = colプログラム名.HeaderText + ": " + data;
            DialogResult rst = MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA004), message), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;
            try
            {
                string deletedId = cell.OwningRow.Cells[colプログラムID.Name].Value.ToString();
                recommendProgramBusiness.DeleteRecommendProgramById(deletedId);
                LoadData();
            }
            catch (Exception ex)
            {
                this.ClosedWaiting();
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = Constants.LOG_FILE_PATH_ERROR
                };

                LogException(error);
                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                btnSave_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.C))
            {
                dataGridViewFilter.Copy();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //  Save();
        }

        private bool Valid()
        {
            var dtUpdate = dataGridViewFilter.GetUpdateData();

            if ((dtUpdate == null || dtUpdate.Rows.Count == 0))
            {              
                return false;
            }

            string groupId = string.Empty;
            string oldGroupId = string.Empty;

            // Valid info
            foreach (DataRow row in dtUpdate.Rows)
            {
                if (!CheckIsNull(colプログラムID.DataPropertyName, row[colプログラムID.DataPropertyName]))
                    return false;

                groupId = row[colプログラムID.DataPropertyName].ToString();

                oldGroupId = row[colOldプログラムID.DataPropertyName] == null ? string.Empty : row[colOldプログラムID.DataPropertyName].ToString();

                // If add new
                if (string.IsNullOrWhiteSpace(oldGroupId) || !groupId.Equals(oldGroupId))
                {
                    if (!CheckExistId(groupId))
                    {
                        return false;
                    }
                }
            }

            //string messageContents = string.Empty;

            ////Get count edit
            //if (dtUpdate != null && dtUpdate.Rows.Count > 0)
            //{
            //    messageContents = dtUpdate.Rows.Count + " 件更新します。\n";
            //}

            //messageContents += "よろしいでしょうか。";

            //DialogResult rst = MessageBox.Show(messageContents, GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (rst != DialogResult.Yes)
            //    return false;

            return true;
        }

        private bool CheckExistId(string groupId)
        {
            try
            {
                var dtCheck = recommendProgramBusiness.GetDataById(groupId);
                if (dtCheck.Rows.Count > 0)
                {
                    MessageBox.Show(string.Format("{0}:{1} は存在しています。", colプログラムID.HeaderText, groupId), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                this.ClosedWaiting();
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = Constants.LOG_FILE_PATH_ERROR
                };

                LogException(error);
                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
                return false;
            }
            return true;
        }

        private bool CheckIsNull(string columnName, object dataCheck)
        {
            if (dataCheck == DBNull.Value || string.IsNullOrWhiteSpace(dataCheck.ToString().Trim()))
            {
                MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA002), columnName), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void Save(DataGridViewCell cell)
        {
            try
            {
                if (!Valid())
                    return;

                DataTable dtSave = dataGridViewFilter.GetUpdateData();

                int updateCount = 0;

                recommendProgramBusiness.Save(dtSave, ref updateCount);

                if (dtSave.Rows.Count == updateCount && cell != null)
                {
                    SetUpdateData(cell);

                    //LoadData();
                    //MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGI007), GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = Constants.LOG_FILE_PATH_ERROR
                };

                LogException(error);

                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        private void RecommendProgramMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseAndSave(e);
        }

        public void CloseAndSave(FormClosingEventArgs e)
        {
            Save(null);
        }
    }
}
