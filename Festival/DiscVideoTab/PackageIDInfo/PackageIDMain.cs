using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;

namespace Festival.DiscVideoTab.PackageIDInfo
{
    public partial class PackageIDMain : FormBase
    {
        private FesPackageBusiness packageBusiness = new FesPackageBusiness();

        public PackageIDMain()
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
            dataGridViewFilter.ColumnDeletedDataPropertyName = colDelete.DataPropertyName;
            dataGridViewFilter.AllowUserEdit = true;
            dataGridViewFilter.DataGridViewSource = dtgPackage;
            dataGridViewFilter.ColumnUpdateTimeDataPropertyName = colUpdateDate.DataPropertyName;
            dataGridViewFilter.ColumnUpdateTimeName = colUpdateDate.Name;
            dataGridViewFilter.CellClickedEvent += CellClick;
           // dataGridViewFilter.CellEndEditEvent += CellEndEditEvent;

            dataGridViewFilter.InitData();
        }

        private void CellEndEditEvent(DataGridViewCell cell)
        {
            if (cell == null || !cell.OwningColumn.Name.Equals(colFesDISCID.Name) || cell.OwningRow.Index == cell.DataGridView.Rows.Count - 1)
                return;
            string currentId = cell.Value.ToString();
            string oldId = cell.OwningRow.Cells[colOldFesDISCID.Name].Value.ToString();

            // If update
            if (!currentId.Equals(oldId))
            {
                if (!CheckExistId(currentId, colFesDISCID.HeaderText))
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

            if (cell.OwningRow.Cells[colOldFesDISCID.Name].Value == DBNull.Value)
            {
                cell.DataGridView.Rows.Remove(cell.OwningRow);
                return;
            }

            string userId = cell.OwningRow.Cells[colOldFesDISCID.Name].Value.ToString();
            string message = colFesDISCID.HeaderText + ": " + userId;
            DialogResult rst = MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA004), message), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;
            try
            {
                packageBusiness.DeleteById(userId);
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

        private void PackageIDMain_Load(object sender, EventArgs e)
        {
            InitDataGridView();
            LoadData();
        }
                

        public void LoadData()
        {
            try
            {
                dataGridViewFilter.DataTableSource = packageBusiness.GetPackegeAll();
                Invoke(new Action(() =>
                {
                    dataGridViewFilter.LoadData();
                }));
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
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            try
            {
                if (!Valid())
                    return;

                DataTable dtSave = GetUpdateData();

                int updateCount = 0;

                packageBusiness.Save(dtSave, ref updateCount);

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
                if (!CheckIsNull(colパッケージID.DataPropertyName, row[colパッケージID.DataPropertyName]))
                    return false;
                if (!CheckIsNull(colFesDISCID.DataPropertyName, row[colFesDISCID.DataPropertyName]))
                    return false;

                userId = row[colFesDISCID.DataPropertyName] == null ? string.Empty : row[colFesDISCID.DataPropertyName].ToString();

                oldUserId = row[colOldFesDISCID.DataPropertyName] == null ? string.Empty : row[colOldFesDISCID.DataPropertyName].ToString();

                // If add new
                if (string.IsNullOrWhiteSpace(oldUserId) || !userId.Equals(oldUserId))
                {
                    if (!CheckExistId(userId, colFesDISCID.HeaderText))
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

        private bool CheckExistId(string checkId, string columHeader)
        {
            try
            {
                var dtCheck = packageBusiness.GetDataById(checkId);
                if (dtCheck.Rows.Count > 0)
                {
                    MessageBox.Show(string.Format("{0}:{1} は存在しています。", columHeader, checkId), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void ResetStatus()
        {
            DataTable dt = GetUpdateData();

            foreach (DataRow row in dt.Rows)
            {
                string fesDISCID = row[colFesDISCID.DataPropertyName].ToString();

                DataRow rowUpdate = dataGridViewFilter.DataTableSource.AsEnumerable().Where(r => r.Field<object>(colFesDISCID.DataPropertyName).ToString().Equals(fesDISCID)).FirstOrDefault();
                rowUpdate[colUpdateDate.DataPropertyName] = DBNull.Value;
                rowUpdate[colOldFesDISCID.DataPropertyName] = fesDISCID;
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

        private void PackageIDMain_FormClosing(object sender, FormClosingEventArgs e)
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
