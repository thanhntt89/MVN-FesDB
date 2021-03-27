using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;

namespace Festival.ManagementTab.FunctionID
{
    public partial class FunctionIDMain : FormBase
    {
        private FesFunctionBusiness functionIDBusiness;
   
        public FunctionIDMain()
        {
            InitializeComponent();
            InitLayoutMain();
        }

        private void InitLayoutMain()
        {
            dataGridViewFilter.Location = new System.Drawing.Point(3, btnSave.Location.Y + btnSave.Height + 2 * this.dataGridViewFilter.Margin.Left);
            btnSave.Location = new System.Drawing.Point(this.Size.Width - btnSave.Width - 18, btnSave.Height / 2);

            this.dataGridViewFilter.Size = new System.Drawing.Size(this.Size.Width - 20, this.Size.Height - 3 * btnSave.Height - 20);
        }

        private void InitDataGridView()
        {
            functionIDBusiness = new FesFunctionBusiness();

            dataGridViewFilter.ColumnDeletedDataPropertyName = colDelete.DataPropertyName;
            dataGridViewFilter.AllowUserEdit = true;
            dataGridViewFilter.DataGridViewSource = dtgFuntions;
            dataGridViewFilter.ColumnUpdateTimeDataPropertyName = colUpdateDate.DataPropertyName;
            dataGridViewFilter.ColumnUpdateTimeName = colUpdateDate.Name;
            dataGridViewFilter.CellClickedEvent += CellClick;
           // dataGridViewFilter.CellEndEditEvent += CellEndEditEvent;
            LoadCombox();
            dataGridViewFilter.InitData();
        }

        private void CellEndEditEvent(DataGridViewCell cell)
        {
            if ((cell == null || cell.OwningRow.Index == cell.DataGridView.Rows.Count - 1) && (!cell.OwningColumn.Name.Equals(colプロジェクトID.Name) || !cell.OwningColumn.Name.Equals(col機能ID.Name)))
                return;

            string functionId = cell.OwningRow.Cells[col機能ID.Name].Value.ToString();          
            string projectId = cell.OwningRow.Cells[colプロジェクトID.Name].Value.ToString();

            string oldProjectId = cell.OwningRow.Cells[colOldプロジェクトID.Name].Value == null ? string.Empty : cell.OwningRow.Cells[colOldプロジェクトID.Name].Value.ToString();
            string oldFunctionId = cell.OwningRow.Cells[colOld機能ID.Name].Value == null ? string.Empty : cell.OwningRow.Cells[colOld機能ID.Name].Value.ToString();          

            string value = string.Empty;
            if (cell.OwningColumn.Name.Equals(col機能ID.Name))
                value = oldFunctionId;          
            else if (cell.OwningColumn.Name.Equals(colプロジェクトID.Name))
                value = oldProjectId;

            if (!projectId.Equals(oldProjectId) ||  !functionId.Equals(oldFunctionId))
            {
                if (!CheckExist(projectId, functionId))
                {
                    cell.Value = value;
                    cell.OwningRow.Cells[colUpdateDate.Name].Value = DBNull.Value;
                }
            }
        }

        private void CellClick(DataGridViewCell cell)
        {
            if (cell == null || !cell.OwningColumn.Name.Equals(colDelete.Name) || cell.OwningRow.Index == cell.DataGridView.Rows.Count - 1)
                return;

            string projectId = cell.OwningRow.Cells[colプロジェクトID.Name].Value.ToString();
            string functionId = cell.OwningRow.Cells[col機能ID.Name].Value.ToString();

            string message = colプロジェクトID.HeaderText + ": " + projectId + " " + col機能ID.HeaderText + ": " + functionId;
            if (cell.OwningRow.Cells[colOldプロジェクトID.Name].Value == DBNull.Value)
            {
                cell.DataGridView.Rows.Remove(cell.OwningRow);
                return;
            }
            DialogResult rst = MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA004), message), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;
            try
            {
                functionIDBusiness.DeleteById(projectId, functionId);
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

        private void LoadCombox()
        {
            try
            {
                DataTable dtProject = functionIDBusiness.GetProjectAll();
                colプロジェクトID.DataSource = dtProject;
                colプロジェクトID.ValueMember = dtProject.Columns[0].ColumnName;
                colプロジェクトID.DisplayMember = dtProject.Columns[1].ColumnName;
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

        public void LoadData()
        {
            try
            {
                dataGridViewFilter.DataTableSource = functionIDBusiness.GetFunctionAll();
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

        private void functionID_Load(object sender, EventArgs e)
        {
            InitDataGridView();            
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private bool Valid()
        {
            var dtUpdate = GetUpdateData();

            if ((dtUpdate == null || dtUpdate.Rows.Count == 0))
            {
                MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGI009), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string projectId = string.Empty;
            string oldProjectId = string.Empty;

            string functionId = string.Empty;
            string oldFunctionId = string.Empty;

            // Valid info
            foreach (DataRow row in dtUpdate.Rows)
            {
                if (!CheckIsNull(colプロジェクトID.DataPropertyName, row[colプロジェクトID.DataPropertyName]))
                    return false;
                if (!CheckIsNull(col機能ID.DataPropertyName, row[col機能ID.DataPropertyName]))
                    return false;

                projectId = row[colプロジェクトID.DataPropertyName].ToString();
                oldProjectId = row[colOldプロジェクトID.DataPropertyName] == null ? string.Empty : row[colOldプロジェクトID.DataPropertyName].ToString();

                functionId = row[col機能ID.DataPropertyName].ToString();
                oldFunctionId = row[colOld機能ID.DataPropertyName] == null ? string.Empty : row[colOld機能ID.DataPropertyName].ToString();

                if (string.IsNullOrWhiteSpace(oldProjectId) || !projectId.Equals(oldProjectId) || !functionId.Equals(oldFunctionId))
                {
                    if (!CheckExist(projectId, functionId))
                        return false;
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

        private bool CheckIsNull(string columnName, object dataCheck)
        {
            if (dataCheck == DBNull.Value || string.IsNullOrWhiteSpace(dataCheck.ToString().Trim()))
            {
                MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA002), columnName), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool CheckExist(string projectId, string functionId)
        {
            try
            {
                var dtCheck = functionIDBusiness.GetDataById(projectId, functionId);
                if (dtCheck.Rows.Count > 0)
                {
                    MessageBox.Show(string.Format("プロジェクトID:{0} , 機能ID:{1} は存在しています。", projectId, functionId), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void Save()
        {
            try
            {
                if (!Valid())
                    return;

                DataTable dtSave = GetUpdateData();

                int updateCount = 0;

                functionIDBusiness.Save(dtSave, ref updateCount);

                if (dtSave.Rows.Count == updateCount)
                {
                    ResetStatus();
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

        private void ResetStatus()
        {
            DataTable dt = GetUpdateData();

            foreach (DataRow row in dt.Rows)
            {
                string projectId = row[colプロジェクトID.DataPropertyName].ToString();
                string functionId = row[col機能ID.DataPropertyName].ToString();

                DataRow rowUpdate = dataGridViewFilter.DataTableSource.AsEnumerable().Where(r => r.Field<object>(colプロジェクトID.DataPropertyName).ToString().Equals(projectId) && r.Field<object>(col機能ID.DataPropertyName).ToString().Equals(functionId)).FirstOrDefault();
                if (rowUpdate == null)
                    continue;
                rowUpdate[colUpdateDate.DataPropertyName] = DBNull.Value;
                rowUpdate[colOldプロジェクトID.DataPropertyName] = projectId;
                rowUpdate[colOld機能ID.DataPropertyName] = functionId;
            }
        }

        private DataTable GetUpdateData()
        {
            return dataGridViewFilter.GetUpdateData();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                btnSave_Click(null, null);
            }
            else if (keyData == (Keys.Control | Keys.C))
            {
                dataGridViewFilter.Copy();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FunctionIDMain_FormClosing(object sender, FormClosingEventArgs e)
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
