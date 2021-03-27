using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace Festival.ManagementTab.ExecuteManagement
{
    public partial class ExecuteMain : FormBase
    {
        private FesExecuteBusiness executeBusiness;

        public ExecuteMain()
        {
            InitializeComponent();
            InitLayoutMain();
        }

        private void InitLayoutMain()
        {
            dataGridViewFilter.Location = new System.Drawing.Point(5, 10);
            this.dataGridViewFilter.Size = new System.Drawing.Size(this.Size.Width - 25, this.Size.Height - 55);
        }

        private void InitDataGridView()
        {
            executeBusiness = new FesExecuteBusiness();

            dataGridViewFilter.ColumnDeletedDataPropertyName = colロック削除.DataPropertyName;
            dataGridViewFilter.ColumnDeletedName = colロック削除.Name;
            dataGridViewFilter.DataGridViewSource = dtgExecute;
            dataGridViewFilter.CellClickedEvent += CellClick;

            dataGridViewFilter.InitData();
        }

        private void CellClick(DataGridViewCell cell)
        {
            if (cell == null || !cell.OwningColumn.Name.Equals(colロック削除.Name) || cell.OwningRow.Index == -1)
                return;

            string userId = cell.OwningRow.Cells[colID.Name].Value.ToString();
            string message = colID.HeaderText + ": " + userId;
            DialogResult rst = MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA004), message), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;
            try
            {
                executeBusiness.DeleteById(userId);
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

        private void ExecuteMain_Load(object sender, EventArgs e)
        {
            InitDataGridView();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dataGridViewFilter.DataTableSource = executeBusiness.GetExecuteAll();
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

        private void btnLoadExecute_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.C))
            {
                dataGridViewFilter.Copy();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
