using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Festival.ManagementTab.Authority
{
    public partial class AuthorityMain : FormBase
    {
        private FesAuthorityBusiness authorityBusiness;
        private DataTable dt機能ID = new DataTable();

        public AuthorityMain()
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
            authorityBusiness = new FesAuthorityBusiness();

            LoadDataFunctionColumn();

            dataGridViewFilter.ColumnDeletedDataPropertyName = colDelete.DataPropertyName;
            dataGridViewFilter.AllowUserEdit = true;
            dataGridViewFilter.DataGridViewSource = advAuthority;
            dataGridViewFilter.ColumnUpdateTimeDataPropertyName = colUpdateDate.DataPropertyName;
            dataGridViewFilter.ColumnUpdateTimeName = colUpdateDate.Name;
            dataGridViewFilter.CellClickedEvent += CellClick;
            //dataGridViewFilter.CellEndEditEvent += CellEndEditEvent;
            dataGridViewFilter.InitData();
        }

        private void CellEndEditEvent(DataGridViewCell cell)
        {
            if ((cell == null || cell.OwningRow.Index == cell.DataGridView.Rows.Count - 1) && (!cell.OwningColumn.Name.Equals(col権限グループ.Name) || !cell.OwningColumn.Name.Equals(colプロジェクトID.Name) || !cell.OwningColumn.Name.Equals(col機能ID.Name)))
                return;


            string userId = cell.OwningRow.Cells[col権限グループ.Name].Value.ToString();
            string functionId = cell.OwningRow.Cells[colプロジェクトID.Name].Value.ToString();
            string roleId = cell.OwningRow.Cells[col機能ID.Name].Value.ToString();

            string oldUserId = cell.OwningRow.Cells[colOld権限グループ.Name].Value == null ? string.Empty : cell.OwningRow.Cells[colOld権限グループ.Name].Value.ToString();
            string oldFunctionId = cell.OwningRow.Cells[colOldプロジェクトID.Name].Value == null ? string.Empty : cell.OwningRow.Cells[colOldプロジェクトID.Name].Value.ToString();
            string oldRoleId = cell.OwningRow.Cells[colOld機能ID.Name].Value == null ? string.Empty : cell.OwningRow.Cells[colOld機能ID.Name].Value.ToString();

            string value = string.Empty;
            if (cell.OwningColumn.Name.Equals(col権限グループ.Name))
                value = oldUserId;
            else if (cell.OwningColumn.Name.Equals(colプロジェクトID.Name))
                value = oldFunctionId;
            else if (cell.OwningColumn.Name.Equals(col機能ID.Name))
                value = oldRoleId;


            if (!userId.Equals(oldUserId) || !functionId.Equals(oldFunctionId) || !roleId.Equals(oldRoleId))
            {
                if (!CheckExist(userId, functionId, roleId))
                {
                    cell.Value = value;
                    cell.OwningRow.Cells[colUpdateDate.Name].Value = DBNull.Value;
                }
            }
        }

        private void CellClick(DataGridViewCell cell)
        {
            UpdateColumnProjectId(cell);
            Delete(cell);
        }

        private void Delete(DataGridViewCell cell)
        {
            if (cell == null || !cell.OwningColumn.Name.Equals(colDelete.Name) || cell.OwningRow.Index == cell.DataGridView.Rows.Count - 1)
                return;

            string userId = cell.OwningRow.Cells[col権限グループ.Name].Value.ToString();
            string functionId = cell.OwningRow.Cells[colプロジェクトID.Name].Value.ToString();
            string roleId = cell.OwningRow.Cells[col機能ID.Name].Value.ToString();
            string message = col権限グループ.HeaderText + ": " + userId + " " + colプロジェクトID.HeaderText + ": " + functionId + " " + col機能ID.HeaderText + ": " + roleId;

            if (cell.OwningRow.Cells[colOld権限グループ.Name].Value == DBNull.Value)
            {
                cell.DataGridView.Rows.Remove(cell.OwningRow);
                return;
            }
            DialogResult rst = MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA004), message), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;
            try
            {
                authorityBusiness.DeleteById(userId, functionId, roleId);
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

        private void UpdateColumnProjectId(DataGridViewCell cell)
        {
            if (dt機能ID == null || cell == null || !cell.OwningColumn.Name.Equals(col機能ID.Name) || cell.OwningRow.Index == cell.DataGridView.Rows.Count - 1)
                return;

            string functionId = cell.OwningRow.Cells[col機能ID.Name].Value == null ? string.Empty : cell.OwningRow.Cells[col機能ID.Name].Value.ToString();
            string projectId = string.Empty;
            var exist = dt機能ID.AsEnumerable().Where(r => r.Field<object>(col機能ID.DataPropertyName).ToString().Equals(functionId)).Select(r => r.Field<object>(colプロジェクトID.DataPropertyName)).FirstOrDefault();
            if (exist != null)
                projectId = exist.ToString();
            cell.OwningRow.Cells[colプロジェクトID.Name].Value = projectId;
        }

        private void LoadData()
        {
            try
            {
                dataGridViewFilter.DataTableSource = authorityBusiness.GetAuthorityAll();
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
                dt機能ID = authorityBusiness.GetFunctionList();
                col機能ID.DataSource = dt機能ID;
                col機能ID.ValueMember = dt機能ID.Columns[1].ColumnName;
                col機能ID.DisplayMember = dt機能ID.Columns[2].ColumnName;

                // Role type
                DataTable dtRoleType = authorityBusiness.GetRoleType();
                col更新タイプ.DataSource = dtRoleType;
                col更新タイプ.ValueMember = dtRoleType.Columns[0].ColumnName;
                col更新タイプ.DisplayMember = dtRoleType.Columns[1].ColumnName;

                DataTable dt権限グループ = authorityBusiness.GetAuthorityGroupAll();
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

        private void PrivilegeMain_Load(object sender, EventArgs e)
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

            // Check dulicate data
            var duplicates = dtUpdate.AsEnumerable().GroupBy(i => new { GroupId = i.Field<object>(col権限グループ.DataPropertyName), ProjectId = i.Field<object>(colプロジェクトID.DataPropertyName), FunctionID = i.Field<object>(col機能ID.DataPropertyName) }).Where(g => g.Count() > 1).Select(g => new { g.Key.GroupId, g.Key.ProjectId, g.Key.FunctionID }).ToList();
            if (duplicates.Count != 0)
            {
                foreach (var item in duplicates)
                {
                    MessageBox.Show(string.Format("データ重複 [{0},{1},{2}]", item.GroupId, item.ProjectId, item.FunctionID), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            string userId = string.Empty;
            string functionId = string.Empty;
            string roleId = string.Empty;

            string oldUserId = string.Empty;
            string oldFunctionId = string.Empty;
            string oldRoleId = string.Empty;

            // Valid info
            foreach (DataRow row in dtUpdate.Rows)
            {
                if (!CheckIsNull(col権限グループ.DataPropertyName, row[col権限グループ.DataPropertyName]))
                    return false;
                if (!CheckIsNull(colプロジェクトID.DataPropertyName, row[colプロジェクトID.DataPropertyName]))
                    return false;
                if (!CheckIsNull(col機能ID.DataPropertyName, row[col機能ID.DataPropertyName]))
                    return false;
                if (!CheckIsNull(col更新タイプ.DataPropertyName, row[col更新タイプ.DataPropertyName]))
                    return false;

                userId = row[col権限グループ.DataPropertyName].ToString();
                functionId = row[colプロジェクトID.DataPropertyName].ToString();
                roleId = row[col機能ID.DataPropertyName].ToString();

                oldUserId = row[colOld権限グループ.DataPropertyName] == null ? string.Empty : row[colOld権限グループ.DataPropertyName].ToString();
                oldFunctionId = row[colOldプロジェクトID.DataPropertyName] == null ? string.Empty : row[colOldプロジェクトID.DataPropertyName].ToString();
                oldRoleId = row[colOld機能ID.DataPropertyName] == null ? string.Empty : row[colOld機能ID.DataPropertyName].ToString();

                if (string.IsNullOrWhiteSpace(oldUserId) || !userId.Equals(oldUserId) || !functionId.Equals(oldFunctionId) || !roleId.Equals(oldRoleId))
                {
                    if (!CheckExist(userId, functionId, roleId))
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

        private bool CheckExist(string userId, string functionId, string roleId)
        {
            try
            {
                //権限グループ,プロジェクトID,機能ID,更新タイプ 
                var dtCheck = authorityBusiness.GetAuthority(userId, functionId, roleId);
                if (dtCheck.Rows.Count > 0)
                {
                    MessageBox.Show(string.Format("権限グループ:{0} プロジェクトID: {1} 機能ID:{2}  は存在しています。", userId, functionId, roleId), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                authorityBusiness.Save(dtSave, ref updateCount);

                if (dtSave.Rows.Count == updateCount)
                {
                    ResetStatus();
                    MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGI007), GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
        }

        private DataTable GetUpdateData()
        {
            return dataGridViewFilter.GetUpdateData();
        }

        private void ResetStatus()
        {
            DataTable dt = GetUpdateData();
            foreach (DataRow row in dt.Rows)
            {
                string groupId = row[col権限グループ.DataPropertyName].ToString();
                string projectId = row[colプロジェクトID.DataPropertyName].ToString();
                string roleId = row[col機能ID.DataPropertyName].ToString();

                DataRow rowUpdate = dataGridViewFilter.DataTableSource.AsEnumerable().Where(r => r.Field<object>(col権限グループ.DataPropertyName).ToString().Equals(groupId) && r.Field<object>(colプロジェクトID.DataPropertyName) != null && r.Field<object>(colプロジェクトID.DataPropertyName).ToString().Equals(projectId) && r.Field<object>(col機能ID.DataPropertyName).ToString().Equals(roleId)).FirstOrDefault();
                if (rowUpdate == null)
                    continue;
                rowUpdate[colUpdateDate.DataPropertyName] = DBNull.Value;
                rowUpdate[colOld権限グループ.DataPropertyName] = groupId;
                rowUpdate[colOldプロジェクトID.DataPropertyName] = projectId;
                rowUpdate[colOld機能ID.DataPropertyName] = roleId;
            }

            dt = null;
            GC.Collect();
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

        private void AuthorityMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridViewFilter.SaveConfig();
            CloseAndSave(e);
        }
    }
}
