using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;

namespace Festival.ManagementTab.User
{
    public partial class UserMain : FormBase
    {
        private FesUserBusiness fesUserBusiness;       

        public UserMain()
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

        public void InitData()
        {
            fesUserBusiness = new FesUserBusiness();

            dataGridViewFilter.ColumnDeletedDataPropertyName = colDelete.DataPropertyName;
            dataGridViewFilter.AllowUserEdit = true;
            dataGridViewFilter.DataGridViewSource = dtgUser;
            dataGridViewFilter.ColumnUpdateTimeDataPropertyName = colUpdateDate.DataPropertyName;
            dataGridViewFilter.ColumnUpdateTimeName = colUpdateDate.Name;
            dataGridViewFilter.CellClickedEvent += CellClick;
            //dataGridViewFilter.CellEndEditEvent += CellEndEditEvent;
            LoadDataFunctionColumn();
            dataGridViewFilter.InitData();
        }

        private void CellEndEditEvent(DataGridViewCell cell)
        {
            if (cell == null || !cell.OwningColumn.Name.Equals(col利用者ID.Name) || cell.OwningRow.Index == cell.DataGridView.Rows.Count - 1)
                return;
            string currentId = cell.Value.ToString();
            string oldId = cell.OwningRow.Cells[colOld利用者ID.Name].Value.ToString();

            // If update
            if (!currentId.Equals(oldId))
            {
                if (!CheckExist(col利用者ID.HeaderText, currentId))
                {
                    cell.Value = oldId;
                    cell.OwningRow.Cells[colUpdateDate.Name].Value = DBNull.Value;
                }
            }
        }

        private void CellClick(DataGridViewCell cell)
        {
            if (cell == null || !cell.OwningColumn.Name.Equals(colDelete.Name) || cell.OwningRow.Index == cell.DataGridView.Rows.Count - 1)
                return;

            string userId = cell.OwningRow.Cells[col利用者ID.Name].Value.ToString();
            string message = col利用者ID.HeaderText + ": " + userId;
            if (cell.OwningRow.Cells[colOld利用者ID.Name].Value == DBNull.Value)
            {
                cell.DataGridView.Rows.Remove(cell.OwningRow);
                return;
            }
            DialogResult rst = MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA004), message), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;
            try
            {
                fesUserBusiness.DeleteById(userId);
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

        private void UserMain_Load(object sender, EventArgs e)
        {
            InitData();
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
            string userId = string.Empty;
            string oldUserId = string.Empty;

            // Valid info
            foreach (DataRow row in dtUpdate.Rows)
            {
                if (!CheckIsNull(col利用者ID.DataPropertyName, row[col利用者ID.DataPropertyName]))
                    return false;
                if (!CheckIsNull(col権限グループ.DataPropertyName, row[col権限グループ.DataPropertyName]))
                    return false;

                userId = row[col利用者ID.DataPropertyName].ToString();
                oldUserId = row[colOld利用者ID.DataPropertyName] == null ? string.Empty : row[colOld利用者ID.DataPropertyName].ToString();

                if (string.IsNullOrWhiteSpace(oldUserId) || !userId.Equals(oldUserId))
                {
                    if (!CheckExist(col利用者ID.HeaderText, userId))
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

        private bool CheckExist(string fieldName, string id)
        {
            try
            {
                var dtCheck = fesUserBusiness.GetDataById(id);
                if (dtCheck.Rows.Count > 0)
                {
                    MessageBox.Show(string.Format("{0}:{1} は存在しています。", fieldName, id), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                fesUserBusiness.Save(dtSave, ref updateCount);

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
                string id = row[col利用者ID.DataPropertyName].ToString();

                DataRow rowUpdate = dataGridViewFilter.DataTableSource.AsEnumerable().Where(r => r.Field<object>(col利用者ID.DataPropertyName).ToString().Equals(id)).FirstOrDefault();
                if (rowUpdate == null)
                    continue;
                rowUpdate[colUpdateDate.DataPropertyName] = DBNull.Value;
                rowUpdate[colOld利用者ID.DataPropertyName] = row[col利用者ID.DataPropertyName];
            }
        }
           
        private void LoadData()
        {
            try
            {
                dataGridViewFilter.DataTableSource = fesUserBusiness.GetUsersAll();
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

        private void LoadDataFunctionColumn()
        {
            try
            {
                DataTable dt権限グループ = fesUserBusiness.GetAuthorityAll();
                col権限グループ.DataSource = dt権限グループ;
                col権限グループ.ValueMember = dt権限グループ.Columns[0].ColumnName;
                col権限グループ.DisplayMember = dt権限グループ.Columns[0].ColumnName;
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

        private bool CheckIsNull(string columnName, object dataCheck)
        {
            if (dataCheck == DBNull.Value || string.IsNullOrWhiteSpace(dataCheck.ToString().Trim()))
            {
                MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA002), columnName), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private DataTable GetUpdateData()
        {
            return dataGridViewFilter.GetUpdateData();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == (Keys.Control | Keys.S))
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

        private void UserMain_FormClosing(object sender, FormClosingEventArgs e)
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
