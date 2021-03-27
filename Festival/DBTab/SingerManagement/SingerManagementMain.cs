using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace Festival.DBTab.SingerManagement
{
    public partial class SingerManagementMain : FormBase
    {
        private SingerManagementBusiness singerManagementBusiness;
        private DataGridViewCell currentCell;

        public SingerManagementMain()
        {
            InitializeComponent();
        }

        private void SingerIdChangeManagementMain_Load(object sender, EventArgs e)
        {
            InitData();
            LoadData();
        }

        public void InitData()
        {
            singerManagementBusiness = new SingerManagementBusiness();
            dataGridViewFilter.DataGridViewSource = advancedDataGridView;
            dataGridViewFilter.ColumnKeyDataPropertyName = colFes独自歌手ID.DataPropertyName;
            dataGridViewFilter.ColumnKeyName = colFes独自歌手ID.Name;
            dataGridViewFilter.ColumnUpdateTimeDataPropertyName = colDateTimeUpdate.DataPropertyName;
            dataGridViewFilter.ColumnUpdateTimeName = colDateTimeUpdate.Name;
            dataGridViewFilter.ColumnDeletedDataPropertyName = colDelete.DataPropertyName;

            dataGridViewFilter.AllowUserEdit = true;
            dataGridViewFilter.CellClickedEvent += Delete;
            // dataGridViewFilter.RowLeaveEvent += CellEndEditEvent;
            //dataGridViewFilter.CellDoubleClickedEvent += EditData;
            // set struct datagridview           
            dataGridViewFilter.InitData();
        }


        private void CellEndEditEvent(DataGridViewCell cell)
        {
            if (cell == null || !cell.OwningColumn.Name.Equals(colFes独自歌手ID.Name) || cell.OwningRow.Index == cell.DataGridView.Rows.Count - 1)
                return;
            string currentId = cell.Value.ToString();
            string oldId = cell.OwningRow.Cells[colOldFes独自歌手ID.Name].Value.ToString();

            // If update
            if (!currentId.Equals(oldId))
            {
                if (!CheckExistId(currentId))
                {
                    cell.Value = oldId;
                    cell.OwningRow.Cells[colDateTimeUpdate.Name].Value = DBNull.Value;
                }
            }
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
            try
            {
                // Get data from work table
                dataGridViewFilter.DataTableSource = singerManagementBusiness.GetSingerTable();

                Invoke(new Action(() =>
                {
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
        private void EditData(DataGridViewCell cell)
        {
            UpdateRow();
        }

        private void UpdateRow()
        {
            if (!btnUpdate.Enabled)
                return;

            SingerRegister singerRegister = new SingerRegister(dataGridViewFilter.CurrentKeyValue);
            singerRegister.ShowDialog();
            if (singerRegister.IsActive)
                LoadData();
        }

        private void UpdateRow(object dataRow)
        {
            DataTable tbData = dataRow as DataTable;
            if (tbData == null || tbData.Rows.Count == 0)
                return;
            dataGridViewFilter.UpdateCell(dataGridViewFilter.GetCellInCurrentRowByColumnName(colFes独自歌手ID.Name), tbData.Rows[0][colFes独自歌手ID.DataPropertyName]);
            dataGridViewFilter.UpdateCell(dataGridViewFilter.GetCellInCurrentRowByColumnName(col歌手名.Name), tbData.Rows[0][col歌手名.DataPropertyName]);
            dataGridViewFilter.UpdateCell(dataGridViewFilter.GetCellInCurrentRowByColumnName(col歌手名検索用カナ.Name), tbData.Rows[0][col歌手名検索用カナ.DataPropertyName]);
            dataGridViewFilter.UpdateCell(dataGridViewFilter.GetCellInCurrentRowByColumnName(col歌手名ソート用カナ.Name), tbData.Rows[0][col歌手名ソート用カナ.DataPropertyName]);
            dataGridViewFilter.UpdateCell(dataGridViewFilter.GetCellInCurrentRowByColumnName(col歌手名ソート用英数.Name), tbData.Rows[0][col歌手名ソート用英数.DataPropertyName]);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            SingerRegister singerRegister = new SingerRegister();
            singerRegister.AddNewRowEvent += AddNewRow;
            singerRegister.ShowDialog();
            if (singerRegister.IsActive)
                LoadData();
        }

        public void AddNewRow(object dataRow)
        {
            try
            {
                DataTable tbData = dataRow as DataTable;
                if (tbData == null || tbData.Rows.Count == 0)
                    return;

                RowAddNewObject rowAdd = new RowAddNewObject();

                DataRow row = tbData.Rows[0];

                rowAdd.KeyId = row[colFes独自歌手ID.DataPropertyName].ToString();

                rowAdd.Columns.Add(new ColumnObject { ColumnIndex = colFes独自歌手ID.Index, ColumnName = colFes独自歌手ID.Name, ColumnDataPropertyName = colFes独自歌手ID.DataPropertyName, Data = row[colFes独自歌手ID.DataPropertyName].ToString() });

                rowAdd.Columns.Add(new ColumnObject { ColumnIndex = col歌手名.Index, ColumnName = col歌手名.Name, ColumnDataPropertyName = col歌手名.DataPropertyName, Data = row[col歌手名.DataPropertyName].ToString() });

                rowAdd.Columns.Add(new ColumnObject { ColumnIndex = col歌手名検索用カナ.Index, ColumnName = col歌手名検索用カナ.Name, ColumnDataPropertyName = col歌手名検索用カナ.DataPropertyName, Data = row[col歌手名検索用カナ.DataPropertyName].ToString() });

                rowAdd.Columns.Add(new ColumnObject { ColumnIndex = col歌手名ソート用カナ.Index, ColumnName = col歌手名ソート用カナ.Name, ColumnDataPropertyName = col歌手名ソート用カナ.DataPropertyName, Data = row[col歌手名ソート用カナ.DataPropertyName].ToString() });
                rowAdd.Columns.Add(new ColumnObject { ColumnIndex = col歌手名ソート用英数.Index, ColumnName = col歌手名ソート用英数.Name, ColumnDataPropertyName = col歌手名ソート用英数.DataPropertyName, Data = row[col歌手名ソート用英数.DataPropertyName].ToString() });

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

            if (cell.OwningRow.Cells[colOldFes独自歌手ID.Name].Value == DBNull.Value)
            {
                cell.DataGridView.Rows.Remove(cell.OwningRow);
                return;
            }

            currentCell = cell;
            string data = cell.OwningRow.Cells[colFes独自歌手ID.Name].Value.ToString();
            string message = colFes独自歌手ID.HeaderText + ": " + data;
            DialogResult rst = MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA004), message), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;
            try
            {
                string deletedId = cell.OwningRow.Cells[colFes独自歌手ID.Name].Value.ToString();
                singerManagementBusiness.DeleteSingerId(deletedId);
                dataGridViewFilter.RemoveRow(deletedId);
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
            //if (keyData == Keys.F2 || keyData == Keys.Space)
            //{
            //    btnUpdate_Click(null, null);
            //}
            //else if (keyData == (Keys.Control | Keys.N))
            //{
            //    btnAddNew_Click(null, null);
            //}
            //else 
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
            Save();
        }

        private bool Valid()
        {
            var dtUpdate = dataGridViewFilter.GetUpdateData();

            if ((dtUpdate == null || dtUpdate.Rows.Count == 0))
            {
                MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGI009), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string groupId = string.Empty;
            string oldGroupId = string.Empty;

            // Valid info
            foreach (DataRow row in dtUpdate.Rows)
            {
                if (!CheckIsNull(colFes独自歌手ID.DataPropertyName, row[colFes独自歌手ID.DataPropertyName]))
                    return false;

                groupId = row[colFes独自歌手ID.DataPropertyName].ToString();

                oldGroupId = row[colOldFes独自歌手ID.DataPropertyName] == null ? string.Empty : row[colOldFes独自歌手ID.DataPropertyName].ToString();

                // If add new
                if (string.IsNullOrWhiteSpace(oldGroupId) || !groupId.Equals(oldGroupId))
                {
                    if (!CheckExistId(groupId))
                    {
                        return false;
                    }
                }
            }

            string messageContents = string.Empty;

            //Get count edit
            if (dtUpdate != null && dtUpdate.Rows.Count > 0)
            {
                messageContents = dtUpdate.Rows.Count + " 件更新します。\n";
            }

            messageContents += "よろしいでしょうか。";

            DialogResult rst = MessageBox.Show(messageContents, GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rst != DialogResult.Yes)
                return false;

            return true;
        }

        private bool CheckExistId(string singerId)
        {
            try
            {
                var dtCheck = singerManagementBusiness.GetDataById(singerId);
                if (dtCheck.Rows.Count > 0)
                {
                    MessageBox.Show(string.Format("{0}:{1} は存在しています。", colFes独自歌手ID.HeaderText, singerId), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void Save()
        {
            try
            {
                if (!Valid())
                    return;

                DataTable dtSave = dataGridViewFilter.GetUpdateData();

                int updateCount = 0;

                singerManagementBusiness.Save(dtSave, ref updateCount);

                if (dtSave.Rows.Count == updateCount)
                {
                    LoadData();
                    MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGI007), GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void SingerManagementMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseAndSave(e);
        }

        public void CloseAndSave(FormClosingEventArgs e)
        {
            DataTable dtUpdate = dataGridViewFilter.GetUpdateData();

            if ((dtUpdate == null || dtUpdate.Rows.Count == 0))
            {
                return;
            }

            string messageContents = string.Format(GetResources.GetResourceMesssage(Constants.MSGI004), "\n");

            DialogResult rst = MessageBox.Show(messageContents, GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Cancel close
            if (rst != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }

            dtUpdate = null;
            GC.Collect();
        }
    }
}
