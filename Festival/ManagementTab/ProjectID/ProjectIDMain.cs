using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Festival.ManagementTab.ProjectID
{
    public partial class ProjectIDMain : FormBase
    {
        private FesProjectBusiness projectIDBusiness;    

        public ProjectIDMain()
        {
            InitializeComponent();
            InitLayoutMain();
        }

        private void InitLayoutMain()
        {
            dataGridViewFilter.Location = new System.Drawing.Point(3, btn_save.Location.Y + btn_save.Height + 2 * this.dataGridViewFilter.Margin.Left);
            btn_save.Location = new System.Drawing.Point(this.Size.Width - btn_save.Width - 18, btn_save.Height / 2);

            this.dataGridViewFilter.Size = new System.Drawing.Size(this.Size.Width - 20, this.Size.Height - 3 * btn_save.Height - 20);
        }

        public void InitData()
        {
            projectIDBusiness = new FesProjectBusiness();

            dataGridViewFilter.ColumnDeletedDataPropertyName = colDelete.DataPropertyName;
            dataGridViewFilter.AllowUserEdit = true;
            dataGridViewFilter.DataGridViewSource = advProjects;
            dataGridViewFilter.ColumnUpdateTimeDataPropertyName = colUpdateDate.DataPropertyName;
            dataGridViewFilter.ColumnUpdateTimeName = colUpdateDate.Name;
            dataGridViewFilter.CellClickedEvent += CellClick;
            //dataGridViewFilter.CellEndEditEvent += CellEndEditEvent;
            dataGridViewFilter.InitData();
        }
             

        private void CellClick(DataGridViewCell cell)
        {
            if (cell == null || !cell.OwningColumn.Name.Equals(colDelete.Name) || cell.OwningRow.Index == cell.DataGridView.Rows.Count - 1)
                return;

            string userId = cell.OwningRow.Cells[colプロジェクトID.Name].Value.ToString();
            string message = colプロジェクトID.HeaderText + ": " + userId;
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
                projectIDBusiness.DeleteById(userId);
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

        public void LoadData()
        {
            try
            {
                dataGridViewFilter.DataTableSource = projectIDBusiness.GetProjectAll();
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


        public void ProjectIDMain_Load(object sender, EventArgs e)
        {
            InitData();
            LoadData();
        }

        private void btnSave(object sender, EventArgs e)
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

            // Valid info
            foreach (DataRow row in dtUpdate.Rows)
            {
                if (!CheckIsNull(colプロジェクトID.DataPropertyName, row[colプロジェクトID.DataPropertyName]))
                    return false;
                if (!CheckIsNull(col機能名.DataPropertyName, row[col機能名.DataPropertyName]))
                    return false;

                projectId = row[colプロジェクトID.DataPropertyName].ToString();

                oldProjectId = row[colOldプロジェクトID.DataPropertyName] == null ? string.Empty : row[colOldプロジェクトID.DataPropertyName].ToString();

                // If add new
                if (string.IsNullOrWhiteSpace(oldProjectId) || !projectId.Equals(oldProjectId))
                {
                    if (!CheckExistId(projectId))
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

        private bool CheckExistId(string projectId)
        {
            try
            {
                var dtCheck = projectIDBusiness.GetDataById(projectId);
                if (dtCheck.Rows.Count > 0)
                {
                    MessageBox.Show(string.Format("プロジェクトID:{0} は存在しています。", projectId), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                projectIDBusiness.Save(dtSave, ref updateCount);

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

        private DataTable GetUpdateData()
        {
            return dataGridViewFilter.GetUpdateData();
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

        private void ResetStatus()
        {
            var dt = GetUpdateData();

            foreach (DataRow row in dt.Rows)
            {
                string id = row[colプロジェクトID.DataPropertyName].ToString();

                DataRow rowUpdate = dataGridViewFilter.DataTableSource.AsEnumerable().Where(r => r.Field<object>(colプロジェクトID.DataPropertyName).ToString().Equals(id)).FirstOrDefault();
                if (rowUpdate == null)
                    continue;
                rowUpdate[colUpdateDate.DataPropertyName] = DBNull.Value;
                rowUpdate[colOldプロジェクトID.DataPropertyName] = row[colプロジェクトID.DataPropertyName];
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                btnSave(null, null);
            }
            else if (keyData == (Keys.Control | Keys.C))
            {
                dataGridViewFilter.Copy();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ProjectIDMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridViewFilter.SaveConfig();
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
