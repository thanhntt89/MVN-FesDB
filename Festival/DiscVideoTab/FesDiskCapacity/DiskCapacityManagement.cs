using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace Festival.DiscVideoTab.FesDiskCapacity
{
    public partial class DiskCapacityManagement : FormBase
    {
        private FesDiskCapacityBusiness fesDiskCapacityBusiness;

        public DiskCapacityManagement()
        {
            InitializeComponent();
            InitLayoutMain();
        }

        private void InitLayoutMain()
        {
            dataGridViewFilter.Location = new System.Drawing.Point(5, 10);
            this.dataGridViewFilter.Size = new System.Drawing.Size(this.Size.Width - 25, this.Size.Height - 55);
        }

        public void InitDisckLayout()
        {
            // set struct datagridview
            dataGridViewFilter.DataGridViewSource = advDiskManagement;
            dataGridViewFilter.ColumnKeyDataPropertyName = colFesDISCID.DataPropertyName;
            dataGridViewFilter.ColumnKeyName = colFesDISCID.Name;
            dataGridViewFilter.ColumnUpdateTimeDataPropertyName = colDateTimeUpdate.DataPropertyName;
            dataGridViewFilter.ColumnUpdateTimeName = colDateTimeUpdate.Name;

            dataGridViewFilter.AllowUserEdit = false;
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
                int disSize = Properties.Settings.Default.FES_DISK_MANAGEMENT_DISCサイズ;
                int unitFile = Properties.Settings.Default.FES_DISK_MANAGEMENT_ファイルサイズの単位;

                // Get data from work table
                dataGridViewFilter.DataTableSource = fesDiskCapacityBusiness.GetDiskCapacityInfoAll(disSize, unitFile);

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

        private void DiskCapacityManagement_Load(object sender, EventArgs e)
        {
            fesDiskCapacityBusiness = new FesDiskCapacityBusiness();
            InitDisckLayout();
            LoadData();
        }

        private void DiskCapacityManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridViewFilter.SaveConfig();
            fesDiskCapacityBusiness = null;
            GC.Collect();
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
