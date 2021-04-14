using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
using System.Linq;

namespace Festival.ManagementTab.AuthGroup
{
    public partial class AuthGroupMain : FormBase
    {
        private FesAuthGroupBusiness authGroupBusiness;

        public AuthGroupMain()
        {
            InitializeComponent();
        }

        private void InitLayoutMain()
        {
            dataGridViewFilter.Location = new System.Drawing.Point(3, btnSave.Location.Y + btnSave.Height + 2 * this.dataGridViewFilter.Margin.Left);
            btnSave.Location = new System.Drawing.Point(this.Size.Width - btnSave.Width - 18, btnSave.Height / 2);

            this.dataGridViewFilter.Size = new System.Drawing.Size(this.Size.Width - 20, this.Size.Height - 3 * btnSave.Height - 20);           
        }

        private void InitDataGridView()
        {
            authGroupBusiness = new FesAuthGroupBusiness();
            dataGridViewFilter.ColumnDeletedDataPropertyName = colDelete.DataPropertyName;
            dataGridViewFilter.AllowUserEdit = true;
            dataGridViewFilter.DataGridViewSource = advAuthGroup;
            dataGridViewFilter.ColumnUpdateTimeDataPropertyName = colUpdateDate.DataPropertyName;
            dataGridViewFilter.ColumnUpdateTimeName = colUpdateDate.Name;
            dataGridViewFilter.CellClickedEvent += CellClick;
            //dataGridViewFilter.CellEndEditEvent += CellEndEditEvent;
            dataGridViewFilter.InitData();
        }

        private void CellEndEditEvent(DataGridViewCell cell)
        {
            if (cell == null || !cell.OwningColumn.Name.Equals(col権限グループ.Name) || cell.OwningRow.Index == cell.DataGridView.Rows.Count - 1)
                return;
            string currentId = cell.Value.ToString();
            string oldId = cell.OwningRow.Cells[colOld権限グループ.Name].Value.ToString();

            // If update
            if (!currentId.Equals(oldId))
            {
                if (!CheckExistId(currentId))
                {
                    cell.Value = oldId;
                    cell.OwningRow.Cells[colUpdateDate.Name].Value = DBNull.Value;
                }
            }
        }


        public void LoadData()
        {
            try
            {
                dataGridViewFilter.DataTableSource = authGroupBusiness.GetGroupAuthorityAll();
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

        private void AuthGroupMain_Load(object sender, EventArgs e)
        {
            InitLayoutMain();
            InitDataGridView();
            LoadData();
        }

        private void btn_save(object sender, EventArgs e)
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
            string groupId = string.Empty;
            string oldGroupId = string.Empty;

            // Valid info
            foreach (DataRow row in dtUpdate.Rows)
            {
                if (!CheckIsNull(col権限グループ.DataPropertyName, row[col権限グループ.DataPropertyName]))
                    return false;

                groupId = row[col権限グループ.DataPropertyName].ToString();

                oldGroupId = row[colOld権限グループ.DataPropertyName] == null ? string.Empty : row[colOld権限グループ.DataPropertyName].ToString();

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

        private bool CheckExistId(string groupId)
        {
            try
            {
                var dtCheck = authGroupBusiness.GetDataById(groupId);
                if (dtCheck.Rows.Count > 0)
                {
                    MessageBox.Show(string.Format("権限グループ:{0} は存在しています。", groupId), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                DataTable dtSave = GetUpdateData();

                int updateCount = 0;

                authGroupBusiness.Save(dtSave, ref updateCount);

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
            var dt = GetUpdateData();

            foreach (DataRow row in dt.Rows)
            {
                string id = row[col権限グループ.DataPropertyName].ToString();

                DataRow rowUpdate = dataGridViewFilter.DataTableSource.AsEnumerable().Where(r => r.Field<object>(col権限グループ.DataPropertyName).ToString().Equals(id)).FirstOrDefault();
                if (rowUpdate == null)
                    continue;
                rowUpdate[colUpdateDate.DataPropertyName] = DBNull.Value;
                rowUpdate[colOld権限グループ.DataPropertyName] = row[col権限グループ.DataPropertyName];
            }
        }

        private DataTable GetUpdateData()
        {
            return dataGridViewFilter.GetUpdateData();
        }

        private void CellClick(DataGridViewCell cell)
        {
            if (cell == null || !cell.OwningColumn.Name.Equals(colDelete.Name) || cell.OwningRow.Index == cell.DataGridView.Rows.Count - 1)
                return;

            if (cell.OwningRow.Cells[colOld権限グループ.Name].Value == DBNull.Value)
            {
                cell.DataGridView.Rows.Remove(cell.OwningRow);
                return;
            }
            string userId = cell.OwningRow.Cells[colOld権限グループ.Name].Value.ToString();
            string message = col権限グループ.HeaderText + ": " + userId;
            DialogResult rst = MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA004), message), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;
            try
            {
                authGroupBusiness.DeleteById(userId);
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
                btn_save(null, null);
            }
            else if (keyData == (Keys.Control | Keys.C))
            {
                dataGridViewFilter.Copy();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
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

        private void AuthGroupMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridViewFilter.SaveConfig();
            CloseAndSave(e);
        }
    }
}
