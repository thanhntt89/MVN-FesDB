using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace Festival.DBTab.TieupConfirm
{
    public partial class TieupConfirmMain : FormBase
    {
        private TieupConfirmBusiness tieupConfirmBusiness;

        public TieupConfirmMain()
        {
            InitializeComponent();
        }

        public void InitData()
        {
            tieupConfirmBusiness = new TieupConfirmBusiness();
            // set struct datagridview
            dataGridViewFilter.DataGridViewSource = advTieup;
            dataGridViewFilter.ColUpdatedIndex = colUpdateDate.Index;
            dataGridViewFilter.ColumnUpdateTimeDataPropertyName = colUpdateDate.DataPropertyName;

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
                dataGridViewFilter.DataTableSource = tieupConfirmBusiness.GetDataTieupTable();

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

        private void TieupConfirmMain_Load(object sender, EventArgs e)
        {
            InitData();
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtUpdate = new DataTable();
                dtUpdate = dataGridViewFilter.GetUpdateData();
                tieupConfirmBusiness.SaveTieupContentTmp(dtUpdate);
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };
                this.LogException(error);
            }
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

        private void TieupConfirmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridViewFilter.SaveConfig();
        }
    }
}
