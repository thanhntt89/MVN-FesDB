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
using System.Windows.Forms;

namespace Festival.DBTab.RecommendSong
{
    public partial class FesRecommendSongImport : FormBase
    {
        private RecommendSongImportBusiness importRecommendSongBusiness;

        private int totalRecords = 0;
        private DataTable dtImportData;

        public FesRecommendSongImport()
        {
            InitializeComponent();
        }

        private void CreateImportTable()
        {
            if (dtImportData == null)
            {
                dtImportData = new DataTable();
                dtImportData.Columns.Add("項目数チェック", typeof(string));
                dtImportData.Columns.Add("プログラムIDチェック", typeof(int));
                dtImportData.Columns.Add("選曲番号チェック", typeof(int));
            }
            // Clear data
            dtImportData.Clear();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = Constants.FesRecommendSongImportFilter;
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
            txtInputFilePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + Properties.Settings.Default.FES_RECOMMEND_SONG_IMPORT_FILE_おすすめ曲リスト取込;
        }

        private void ImportProcess()
        {
            if (importRecommendSongBusiness == null)
                importRecommendSongBusiness = new RecommendSongImportBusiness();

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

            // Get all Fesおすすめプログラム
            DataTable dtFesRecommendSong = new DataTable();
            try
            {
                // Get all Fesおすすめプログラム
                dtFesRecommendSong = importRecommendSongBusiness.GetFeRecommendProgram();
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
                return false;
            }
            var KaraokeNo = File.ReadAllLines(filePath);
            totalRecords = KaraokeNo.Count();

            for (int rowIndex = 0; rowIndex < totalRecords; rowIndex++)
            {
                var dataRow = KaraokeNo[rowIndex].Split('\t');
                int columns = dataRow.Count();

                // 項目数チェック(3項目)
                if (columns != 3)
                {
                    this.ClosedWaiting();
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE045), rowIndex, columns), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInputFilePath.Focus();
                    }));

                    return false;
                }

                // プログラムIDチェック
                if (!string.IsNullOrWhiteSpace(dataRow[0]))
                {
                    // Valid  プログラムIDチェック in database
                    var exist = dtFesRecommendSong.AsEnumerable().Where(r => r.Field<object>(0) != null && r.Field<object>(0).ToString().Equals(dataRow[0])).FirstOrDefault();
                    if (exist == null)
                    {
                        this.ClosedWaiting();
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE046), rowIndex, dataRow[0]), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtInputFilePath.Focus();
                        }));

                        return false;
                    }
                }

                // Valid 選曲番号チェック
                if (string.IsNullOrWhiteSpace(dataRow[1]))
                {
                    this.ClosedWaiting();
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE048), rowIndex, dataRow[1]), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));

                    return false;
                }

                if (!Utils.IsNumeric(dataRow[1]))
                {
                    this.ClosedWaiting();
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE049), rowIndex, dataRow[1]), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));

                    return false;
                }

                if (dataRow[1].Length > 8)
                {
                    this.ClosedWaiting();
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE050), rowIndex, dataRow[1]), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));

                    return false;
                }

                // Valid 表示順。
                if (string.IsNullOrWhiteSpace(dataRow[2]))
                {
                    this.ClosedWaiting();
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE051), rowIndex, dataRow[2]), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));

                    return false;
                }
                if (!Utils.IsNumeric(dataRow[2]))
                {
                    this.ClosedWaiting();
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE052), rowIndex, dataRow[2]), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));

                    return false;
                }
                if (dataRow[2].Length > 8)
                {
                    this.ClosedWaiting();
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE050), rowIndex, dataRow[2]), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));

                    return false;
                }

                // Get data
                dtImportData.Rows.Add(dataRow[0], dataRow[1], dataRow[2]);
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

                DataTable dtRecommendSongSource = new DataTable();
                DataTable dtRecommendSongDes = new DataTable();

                string contentId = string.Empty;
                string displayOrder = string.Empty;
                string programId = string.Empty;
                string errorMessage = string.Empty;
                int countFail = 0;
                int index = 0;

                foreach (DataRow row in dtImportData.Rows)
                {
                    index++;

                    displayOrder = row[2].ToString();
                    contentId = row[1] == null ? string.Empty : row[1].ToString();
                    programId = row[0] == null ? string.Empty : row[0].ToString();
                    

                    //Get RecommendSongSource By ColumnIndex = 1 Column([Wii(デジドコ)選曲番号]) // 選曲番号チェック
                    dtRecommendSongSource = importRecommendSongBusiness.GetFesRecommendSongSource(contentId);

                    if (dtRecommendSongSource.Rows.Count == 0)
                    {
                        countFail++;
                        errorMessage += index + " 行目　対応するデジドココンテンツIDが見つかりません。";
                        continue;
                    }

                    // プログラムIDチェック
                    dtRecommendSongDes = importRecommendSongBusiness.GetFesRecommendSongDes(programId, dtRecommendSongSource.Rows[0]["デジドココンテンツID"].ToString(), displayOrder);

                    bool newFlg = false;

                    // Add new
                    if (dtRecommendSongDes.Rows.Count == 0)
                    {
                        newFlg = true;
                        dtRecommendSongDes.Rows.Add();
                    }

                    dtRecommendSongDes.Rows[0]["Wii(デジドコ)選曲番号"] = dtRecommendSongSource.Rows[0]["Wii(デジドコ)選曲番号"];
                    dtRecommendSongDes.Rows[0]["カラオケ選曲番号"] = dtRecommendSongSource.Rows[0]["カラオケ選曲番号"];
                    dtRecommendSongDes.Rows[0]["楽曲名"] = dtRecommendSongSource.Rows[0]["楽曲名"];
                    dtRecommendSongDes.Rows[0]["歌手名"] = dtRecommendSongSource.Rows[0]["歌手名"];
                    dtRecommendSongDes.Rows[0]["FesDISCID"] = dtRecommendSongSource.Rows[0]["FesDISCID"];
                    dtRecommendSongDes.Rows[0]["有料コンテンツフラグ"] = dtRecommendSongSource.Rows[0]["有料コンテンツフラグ"];
                    dtRecommendSongDes.Rows[0]["有償情報フラグ"] = dtRecommendSongSource.Rows[0]["有償情報フラグ"];
                    dtRecommendSongDes.Rows[0]["サービス発表日"] = dtRecommendSongSource.Rows[0]["サービス発表日"];
                    dtRecommendSongDes.Rows[0]["取消フラグ"] = dtRecommendSongSource.Rows[0]["取消フラグ"];
                    dtRecommendSongDes.Rows[0]["FesDISCID"] = dtRecommendSongSource.Rows[0]["FesDISCID"];
                    dtRecommendSongDes.Rows[0]["選択"] = 0;
                    dtRecommendSongDes.Rows[0]["削除"] = 0;
                    dtRecommendSongDes.Rows[0]["更新日時"] = DateTime.Now;

                    if (newFlg)
                    {
                        dtRecommendSongDes.Rows[0]["デジドココンテンツID"] = dtRecommendSongSource.Rows[0]["デジドココンテンツID"];
                        dtRecommendSongDes.Rows[0]["表示順"] = row[2].ToString();

                        if (row[0] != null && !string.IsNullOrEmpty(row[0].ToString()))
                        {
                            dtRecommendSongDes.Rows[0]["プログラムID"] = row[0].ToString();
                        }

                        importRecommendSongBusiness.InsertFesRecommendSongWorkTable(dtRecommendSongDes);
                    }
                    else
                    {
                        importRecommendSongBusiness.UpdateFesRecommendSongWorkTable(dtRecommendSongDes);
                    }
                }

                IsActive = true;

                this.ClosedWaiting();

                Invoke(new Action(() =>
                {
                    string message = string.Format("{0} 件取り込みました。\n{1} 件失敗しました。\n{2}", dtImportData.Rows.Count - countFail, countFail, errorMessage);
                    MessageBox.Show(message, GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FesRecommendSongImport_Load(object sender, EventArgs e)
        {
            LoadInit();
        }
    }
}
