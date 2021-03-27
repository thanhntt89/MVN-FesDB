using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;

namespace Festival.DiscVideoTab.FesSongAddDelete
{
    public partial class FesSongImport : FormBase
    {
        private FesSongAddDeleteBusiness fesSongAddDeleteBusiness;
        private DataTable dtImport = new DataTable();
        private int totalRecords = 0;

        public FesSongImport()
        {
            InitializeComponent();
        }

        private void FesSongImport_Load(object sender, EventArgs e)
        {
            LoadInit();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileFilter();
        }

        private void OpenFileFilter()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = Constants.FILE_FILTER_TSV_EXTENSION;
            var rst = openFile.ShowDialog();
            if (rst != DialogResult.OK)
                return;
            txtInputFilePath.Text = openFile.FileName;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportProcess();
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadInit()
        {
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.FES_SONG_MANAGEMENT_DISC搭載曲データサイズ取込))
                txtInputFilePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + Properties.Settings.Default.FES_SONG_MANAGEMENT_DISC搭載曲データサイズ取込;
        }

        private bool Valid()
        {
            if (string.IsNullOrWhiteSpace(txtInputFilePath.Text))
            {
                this.ClosedWaiting();
                Invoke(new Action(() =>
                {
                    MessageBox.Show(GetResources.GetResourceMesssage(Constants.MESSAGE_ERROR_FILE_NOT_FOUND), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInputFilePath.Focus();
                }));
                return false;
            }

            FileInfo file = new FileInfo(txtInputFilePath.Text);

            if (!file.Exists)
            {
                Invoke(new Action(() =>
                {
                    this.ClosedWaiting();
                    MessageBox.Show(GetResources.GetResourceMesssage(Constants.MESSAGE_ERROR_FILE_NOT_FOUND), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInputFilePath.Focus();
                }));
                return false;
            }

            if (file.Length == 0 ||
                (file.Length > 0 && !File.ReadAllLines(txtInputFilePath.Text).Where(dat => !String.IsNullOrWhiteSpace(dat.Trim())).Any())
            )
            {
                Invoke(new Action(() =>
                {
                    this.ClosedWaiting();
                    MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE026), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInputFilePath.Focus();
                }));

                return false;
            }

            if (dtImport.Columns.Count == 0)
            {
                dtImport.Columns.Add("デジドコNo", typeof(string));
                dtImport.Columns.Add("データサイズ", typeof(string));
            }
            dtImport.Rows.Clear();

            var dataImport = File.ReadAllLines(txtInputFilePath.Text);
            totalRecords = dataImport.Count();
            for (int index = 0; index < totalRecords; index++)
            {
                var row = dataImport[index].Split('\t');
                int columns = row.Count();
                if (columns != 2)
                {
                    Invoke(new Action(() =>
                    {
                        this.ClosedWaiting();
                        MessageBox.Show(string.Format("2カラム以外の行があったため取り込めませんでした。\n{0} 行目 カラオケNo：", index), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                    return false;
                }

                // Check length
                if (row[1].Length > 9 || !Utils.IsNumeric(row[1]))
                {
                    Invoke(new Action(() =>
                    {
                        this.ClosedWaiting();
                        MessageBox.Show(string.Format("{0}行目 Fes_データサイズのフォーマットが違います。", index), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                    return false;
                }

                // Add to import table
                dtImport.Rows.Add(row[0], row[1]);
            }

            return true;
        }

        private void ImportProcess()
        {
            if (fesSongAddDeleteBusiness == null)
                fesSongAddDeleteBusiness = new FesSongAddDeleteBusiness();


            if (bgwProcess == null)
                bgwProcess = CreateThread();
            bgwProcess.RunWorkerCompleted += BgwProcess_RunWorkerCompleted;
            bgwProcess.DoWork += BgwProcess_DoWork;
            bgwProcess.RunWorkerAsync();
            this.ShowWating();
        }

        private void BgwProcess_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            ExecuteImport();
        }

        private void BgwProcess_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.ClosedWaiting();
            if (bgwProcess != null)
            {
                bgwProcess.Dispose();
                bgwProcess = null;
            }
            GC.Collect();
            if (IsActive)
                btnClosed_Click(null, null);
        }

        private void ExecuteImport()
        {
            try
            {
                if (!Valid())
                    return;
                int failsCount = 0;
                int sucessCount = 0;
                string errorMessage = string.Empty;
                string alertMessage = string.Empty;

                fesSongAddDeleteBusiness.ImportSong(dtImport, ref sucessCount, ref failsCount, ref errorMessage);
                IsActive = true;              
                Invoke(new Action(() =>
                {
                    this.ClosedWaiting();
                    MessageBox.Show(string.Format("{0} 件取り込みました。\n{1}件失敗しました。\n{2}", sucessCount, failsCount, errorMessage), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.I)
            {
                btnImport_Click(null, null);
            }
            else if (keyData == Keys.C)
            {
                btnClosed_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
