using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Festival.DiscVideoTab.FesSongWithDisc
{
    public partial class FesSongWithDiscImport : FormBase
    {
        private FesSongWithDiscImportBusiness fesSongWithDiscImportBusiness;

        private int totalRecords = 0;
        private DataTable dtImportData;
        string localFile = string.Empty;
        int verSion;

        public FesSongWithDiscImport(DisVersion _verSion)
        {
            InitializeComponent();
            verSion = (int)_verSion;          
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                btnImport_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CreateImportTable()
        {
            if (dtImportData == null)
            {
                dtImportData = new DataTable();
                dtImportData.Columns.Add("デジドコNo", typeof(int));
                dtImportData.Columns.Add("Fes_DISCID", typeof(int));
                dtImportData.Columns.Add("Fes_NET利用フラグ", typeof(int));
                dtImportData.Columns.Add("取消日", typeof(int));
            }
            // Clear data
            dtImportData.Clear();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = Constants.FesSongWithDiscImportFilter;
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
            IsActive = false;
            this.Close();
        }

        private void LoadInit()
        {
            txtInputFilePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + Properties.Settings.Default.FES_SONG_WITH_DISC_FILE_NAME_IMPORT_DISCID割付リスト取込;
        }

        private void ImportProcess()
        {
            if (fesSongWithDiscImportBusiness == null)
                fesSongWithDiscImportBusiness = new FesSongWithDiscImportBusiness();
         
            bgwProcess = CreateThread();
            bgwProcess.RunWorkerCompleted += import_RunWorkerCompleted;
            bgwProcess.DoWork += import_DoWork;
            bgwProcess.RunWorkerAsync();
            this.ShowWating();
        }

        private void import_DoWork(object sender, DoWorkEventArgs e)
        {
            ImportExecute();
        }

        private void import_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (bgwProcess != null)
            {
                bgwProcess.RunWorkerCompleted -= import_RunWorkerCompleted;
                bgwProcess.DoWork -= import_DoWork;
                bgwProcess.Dispose();
            }
            bgwProcess = null;
            GC.Collect();
            this.ClosedWaiting();
            if (IsActive)
                this.Close();
        }

        private bool Valid()
        {
            localFile = txtInputFilePath.Text;
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
                this.ClosedWaiting();
                Invoke(new Action(() =>
                {
                    MessageBox.Show(GetResources.GetResourceMesssage(Constants.MESSAGE_ERROR_FILE_NOT_FOUND), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInputFilePath.Focus();
                }));
                return false;
            }

            if (!ValidTsv(txtInputFilePath.Text))
                return false;

            return true;
        }

        private bool ValidTsv(string filePath)
        {
            FileInfo file = new FileInfo(filePath);

            if (file.Length == 0 ||
                (file.Length > 0 && !File.ReadAllLines(txtInputFilePath.Text).Where(dat => !String.IsNullOrWhiteSpace(dat.Trim())).Any())
            )
            {
                this.ClosedWaiting();

                Invoke(new Action(() =>
                {
                    MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE053), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInputFilePath.Focus();
                }));

                return false;
            }

            // Create table
            CreateImportTable();

            var allData = File.ReadAllLines(filePath);
            totalRecords = allData.Count();

            for (int rowIndex = 0; rowIndex < totalRecords; rowIndex++)
            {
                var dataRow = allData[rowIndex].Split('\t');
                int columns = dataRow.Count();

                // 項目数チェック(3項目)
                if (columns != 4)
                {
                    this.ClosedWaiting();

                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format("4カラム以外の行があったため取り込めませんでした。{0} 行目 デジドコNo:{1}", rowIndex, dataRow[0]), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInputFilePath.Focus();
                    }));

                    return false;
                }

                // デジドコNo
                if (string.IsNullOrWhiteSpace(dataRow[0]))
                {
                    this.ClosedWaiting();

                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format("デジドコNoが設定されていないため取り込めませんでした。{0} 行目 ：{1}", rowIndex, dataRow[0]), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInputFilePath.Focus();
                    }));

                    return false;
                }

                if (!string.IsNullOrWhiteSpace(dataRow[0]) && (!Utils.IsNumeric(dataRow[0]) || dataRow[0].Length > 8 && Utils.IsNumeric(dataRow[0])))
                {
                    this.ClosedWaiting();

                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format("デジドコNoのフォーマットが不正な行があったため取り込めませんでした。{0} 行目：{1}", rowIndex, dataRow[0]), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInputFilePath.Focus();
                    }));

                    return false;
                }

                // Valid Fes_DISCID
                if (!string.IsNullOrWhiteSpace(dataRow[1]) && (!Utils.IsNumeric(dataRow[1]) || dataRow[1].Length > 8 && Utils.IsNumeric(dataRow[1])))
                {
                    this.ClosedWaiting();

                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format("Fes_DISCIDのフォーマットが不正な行があったため取り込めませんでした。{0} 行目：{1}", rowIndex, dataRow[1]), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInputFilePath.Focus();
                    }));

                    return false;
                }

                // Valid Fes_NET利用フラグ
                if (!string.IsNullOrWhiteSpace(dataRow[2]) && (!Utils.IsNumeric(dataRow[2]) || dataRow[2].Length > 8 && Utils.IsNumeric(dataRow[2])))
                {
                    this.ClosedWaiting();

                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format("Fes_NET利用フラグのフォーマットが不正な行があったため取り込めませんでした。{0} 行目：{1}", rowIndex, dataRow[2]), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInputFilePath.Focus();
                    }));

                    return false;
                }

                // Valid 取消日
                if (!string.IsNullOrWhiteSpace(dataRow[3]) && (!Utils.IsNumeric(dataRow[3]) || dataRow[3].Length > 8 && Utils.IsNumeric(dataRow[3])))
                {
                    this.ClosedWaiting();

                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format("取消日のフォーマットが不正な行があったため取り込めませんでした。{0} 行目：{1}", rowIndex, dataRow[3]), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInputFilePath.Focus();
                    }));

                    return false;
                }

                // Get data
                dtImportData.Rows.Add(dataRow[0], dataRow[1], dataRow[2], dataRow[3]);
            }

            return true;
        }

        private void ImportExecute()
        {
            try
            {
                if (!Valid())
                {
                    return;
                }

                // Truncate work table
                fesSongWithDiscImportBusiness.TruncateWorkTableTmp();

                // truncate table
                fesSongWithDiscImportBusiness.TruncateFesDiscAllocationTable();

                // Copy file to server              
                string serverFile = Properties.Settings.Default.FES_SONG_WITH_DISC_SERVER_FILE_PATH_IMPORT_DISCID割付リスト取込配置ファイル;
                File.Copy(localFile, serverFile, true);

                fesSongWithDiscImportBusiness.BulkImportFesDisc(serverFile);

                // Delete File
                File.Delete(serverFile);

                // Check duplicate song selection
                CheckDuplicateSongSelection();

                // '更新対象選曲番号チェック
                CheckSongSelectionUpdated();

                string message = string.Empty;

                fesSongWithDiscImportBusiness.ExecuteImportCheck(verSion, ref message);
                this.ClosedWaiting();

                if (!string.IsNullOrEmpty(message))
                {
                    IsActive = false;
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(message, GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
                else
                    IsActive = true;
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

        private void CheckSongSelectionUpdated()
        {
            try
            {
                DataTable dtSongUpdate = fesSongWithDiscImportBusiness.CheckSongSelectedUpdate();
                if (dtSongUpdate.Rows.Count == 0)
                {
                    return;
                }

                //logfile
                string logPath = Properties.Settings.Default.FES_SONG_WITH_DISC_IMPORT_LOG_DISCID割付リスト取込チェックファイルパス;
                StringBuilder logInfo = new StringBuilder();
                logInfo.Append(string.Format("下記のデジドコNoは、デジドコNoが存在しません（{0})", DateTime.Now));
                foreach (DataRow row in dtSongUpdate.Rows)
                {
                    logInfo.Append(row[0].ToString());
                }

                LogWriter.Write(logPath, logInfo.ToString());

                Utils.OpenFileByNotepad(logPath);
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
            }
        }

        private void CheckDuplicateSongSelection()
        {
            try
            {
                DataTable dtDuplicateSong = fesSongWithDiscImportBusiness.CheckDuplicateSongSelected();
                if (dtDuplicateSong.Rows.Count == 0)
                {
                    return;
                }

                //logfile
                string logPath = Properties.Settings.Default.FES_SONG_WITH_DISC_IMPORT_LOG_DISCID割付リスト取込チェックファイルパス;
                StringBuilder logInfo = new StringBuilder();
                logInfo.Append(string.Format("下記のデジドコNoが重複しています。（{0})", DateTime.Now));
                foreach (DataRow row in dtDuplicateSong.Rows)
                {
                    logInfo.Append(row[0].ToString());
                }

                LogWriter.Write(logPath, logInfo.ToString());

                Utils.OpenFileByNotepad(logPath);
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
            }
        }

        private void FesRecommendSongImport_Load(object sender, EventArgs e)
        {
            LoadInit();
        }
    }
}
