using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace Festival.DiscVideoTab.FesIndiVidualVideoDisc
{
    public partial class FesVideoDiscDisplay : FormBase
    {
        private FesVideoDiscBusiness fesIndividualVideoDiscBusiness;

        public FesVideoDiscDisplay()
        {
            InitializeComponent();
            InitLayoutMain();
        }
        private void InitLayoutMain()
        {
            dataGridViewFilter.Location = new System.Drawing.Point(5, 10);
            this.dataGridViewFilter.Size = new System.Drawing.Size(this.Size.Width - 25, this.Size.Height - 55);
        }

        private void FesVideoDiscDisplay_Load(object sender, System.EventArgs e)
        {
            InitData();
            LoadData();
        }

        public void InitData()
        {
            fesIndividualVideoDiscBusiness = new FesVideoDiscBusiness();
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
            dataGridViewFilter.RemoveEventDataGridView();
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
                dataGridViewFilter.DataTableSource = fesIndividualVideoDiscBusiness.GetFesIndividualVideoDisc();

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
            dataGridViewFilter.InitDataGridViewEvent();
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
