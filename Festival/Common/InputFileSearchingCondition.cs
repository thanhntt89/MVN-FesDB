using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Festival.Common
{
    public partial class InputFileSearchingCondition : FormBase
    {
        private CommonBusiness commonBusiness;
        private FesContentBusiness contentsBusiness;

        public InputFileSearchingCondition(string title, LayOutEntity layOutEntity)
        {
            InitializeComponent();
            this.CurrentLayOut = layOutEntity;
            contentsBusiness = new FesContentBusiness();
            commonBusiness = new CommonBusiness();
            this.Text = title;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                this.Close();
            }));
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = Constants.OpenFileFilter;
            var rst = file.ShowDialog();
            if (rst != DialogResult.OK)
                return;
            txtInputFile.Text = file.FileName;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchingProcess();
        }

        private bool Valid()
        {
            if (string.IsNullOrEmpty(txtInputFile.Text))
            {
                MessageBox.Show(GetResources.GetResourceMesssage(Constants.MESSAGE_ERROR_FILE_NOT_FOUND), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!File.Exists(txtInputFile.Text))
            {
                MessageBox.Show(GetResources.GetResourceMesssage(Constants.MESSAGE_ERROR_FILE_NOT_FOUND), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!Constants.OpenFileFilter.Contains(Path.GetExtension(txtInputFile.Text)))
            {
                MessageBox.Show(GetResources.GetResourceMesssage(Constants.MESSAGE_ERROR_FILE_NOT_FOUND), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void SearchingProcess()
        {
            if (!Valid())
                return;

            bgwProcess = CreateThread();
            bgwProcess.RunWorkerCompleted += BgwProcess_RunWorkerCompleted;
            bgwProcess.DoWork += BgwProcess_DoWork;
            bgwProcess.RunWorkerAsync();

            this.ShowWating();
        }

        private void BgwProcess_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Search();
        }

        private void BgwProcess_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (IsActive)
                btnClose_Click(null, null);

            if (bgwProcess != null)
            {
                bgwProcess.RunWorkerCompleted += BgwProcess_RunWorkerCompleted;
                bgwProcess.DoWork += BgwProcess_DoWork;
                bgwProcess.Dispose();
            }
            bgwProcess = null;
            GC.Collect();
            this.ClosedWaiting();
        }

        private void Search()
        {
            try
            {
                // Truncate song name table
                commonBusiness.TruncateTableWorkFesSongNumber();

                // Insert song number from file
                if (!IsInsertSongNumber())
                    return;

                //Insert to work table
                // Db tmp
                if (this.Text.Equals(Constants.TitleInputFileMatchingKaraokeScreenText))
                {
                    commonBusiness.InsertWorkTableMatchingKaraoke();
                }
                //Db wii
                else if (this.Text.Equals(Constants.TitleInputFileMatchingScreenText))
                {
                    commonBusiness.InsertWorkTableTmpBySongNumber();
                }

                IsActive = true;
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

        /// <summary>
        /// Get song number list
        /// </summary>
        /// <returns></returns>
        private List<string> GetSongNumberList()
        {
            // List song number from file data input
            List<string> songNumberList = new List<string>();
            try
            {
                string extention = Path.GetExtension(txtInputFile.Text);

                if (extention.Equals(Constants.EXTENTION_EXCEL))
                {
                    // First index =1 column song number
                    songNumberList = ExcelUtils.GetSongNumberInput(txtInputFile.Text, 1);
                }
                else if (extention.Equals(Constants.EXTENTION_CSV) || extention.Equals(Constants.EXTENTION_TXT) || extention.Equals(Constants.EXTENTION_TSV))
                {
                    songNumberList = FileUtils.GetSongNumberInput(txtInputFile.Text);
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

            return songNumberList;
        }

        private bool IsInsertSongNumber()
        {
            // List song number from file data input
            List<string> songNumberList = GetSongNumberList();

            if (songNumberList.Count == 0)
                return false;

            try
            {
                // Insert song name table
                commonBusiness.InsertSongNumber(songNumberList);

                // Truncate work table
                commonBusiness.TruncateTableTmp(Constants.WORK_TABLE_NAME_FESTCONTENT);

                return true;
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
                return false;
            }
        }

        private void FileVerification_Load(object sender, EventArgs e)
        {
            LoadInit();
        }

        private void LoadInit()
        {
            if (this.CurrentLayOut.LayoutName == LayOut.FesContentMainAdvance)
                txtInputFile.Text = Properties.Settings.Default.FES_CONTENT_INPUT_入力パス;
        }
    }
}
