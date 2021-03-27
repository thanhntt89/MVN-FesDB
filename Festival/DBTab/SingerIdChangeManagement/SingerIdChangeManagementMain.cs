using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace Festival.DBTab.SingerIdChangeManagement
{
    public partial class SingerIdChangeManagementMain : FormBase
    {
        private SingerIdChangeManagementBusiness singerIdChangeManagementBusiness;
        private DataGridViewCell currentCell;

        public SingerIdChangeManagementMain()
        {
            InitializeComponent();
            btnAddNew.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void SingerIdChangeManagementMain_Load(object sender, EventArgs e)
        {
            InitData();
            LoadData();
        }

        public void InitData()
        {
            singerIdChangeManagementBusiness = new SingerIdChangeManagementBusiness();
            dataGridViewFilter.DataGridViewSource = advancedDataGridView;
            dataGridViewFilter.ColumnKeyDataPropertyName = col履歴No.DataPropertyName;
            dataGridViewFilter.ColumnUpdateTimeDataPropertyName = colDateTimeUpdate.DataPropertyName;

            dataGridViewFilter.ColumnKeyName = col履歴No.Name;
            dataGridViewFilter.AllowUserEdit = false;
            dataGridViewFilter.CellClickedEvent += Delete;
            // set struct datagridview           
            dataGridViewFilter.InitData();
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
                dataGridViewFilter.DataTableSource = singerIdChangeManagementBusiness.GetSingerIdChangeAllTable();

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
            if (!btnUpdate.Enabled)
                return;
            SingerIdChangeRegister singerRegister = new SingerIdChangeRegister(dataGridViewFilter.CurrentKeyValue);
            singerRegister.ShowDialog();
            if (singerRegister.IsActive)
                LoadData();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (!btnAddNew.Enabled) return;

            SingerIdChangeRegister singerRegister = new SingerIdChangeRegister();
            singerRegister.ShowDialog();
            if (singerRegister.IsActive)
                LoadData();
        }

        private void Delete(DataGridViewCell cell)
        {
            if (cell == null || cell.ColumnIndex != colDelete.Index || cell.RowIndex == -1)
                return;

            currentCell = cell;

            string data = cell.OwningRow.Cells[col変更前_歌手ID.Name].Value.ToString();
            string message = col変更前_歌手ID.HeaderText + ": " + data;
            string deletedId = cell.OwningRow.Cells[col履歴No.Name].Value.ToString();

            DialogResult rst = MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA004), message), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;

            try
            {
                singerIdChangeManagementBusiness.DeleteSingerId(deletedId);
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
            if (keyData == Keys.F2 || keyData == Keys.Space)
            {
                btnUpdate_Click(null, null);
            }
            else if (keyData == (Keys.Control | Keys.N))
            {
                btnAddNew_Click(null, null);
            }
            else if (keyData == (Keys.Control | Keys.C))
            {
                dataGridViewFilter.Copy();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
