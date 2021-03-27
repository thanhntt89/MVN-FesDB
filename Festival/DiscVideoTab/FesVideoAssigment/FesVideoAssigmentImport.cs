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

namespace Festival.DiscVideoTab.FesVideoAssigment
{
    public partial class FesVideoAssigmentImport : FormBase
    {
        private FesVideoAssigmentImportBusiness fesVideoAssigmentImportBusiness;

        private int totalRecords = 0;
        private DataTable dtImportData;
        string localFile = string.Empty;

        public FesVideoAssigmentImport()
        {
            InitializeComponent();
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
                dtImportData.Columns.Add("カラオケNo", typeof(string));
                dtImportData.Columns.Add("背景動画コード", typeof(string));
            }
            // Clear data
            dtImportData.Clear();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = Constants.FesVideoAssigmentImportFilter;
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
            txtInputFilePath.Text = Properties.Settings.Default.FES_VIDEO_ASSIGMENT_DEFAULT_PATH_映像割付リスト取込パス + "\\" + Properties.Settings.Default.FES_VIDEO_ASSIGMENT_IMPORT_EXPORT_FILE_映像割付リスト取込;
        }

        private void ImportProcess()
        {
            if (fesVideoAssigmentImportBusiness == null)
                fesVideoAssigmentImportBusiness = new FesVideoAssigmentImportBusiness();
            // Message
          var rst =  MessageBox.Show("選曲番号キーは「カラオケNo」です\n処理を始めてよろしいですか？", GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rst != DialogResult.Yes)
                return;
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
                if (columns != 2)
                {
                    this.ClosedWaiting();

                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format("2カラム以外の行があったため取り込めませんでした。{0}  行目 カラオケNo：{1}", rowIndex, dataRow[0]), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInputFilePath.Focus();
                    }));

                    return false;
                }

                if (dataRow[1] == null || string.IsNullOrEmpty(dataRow[1].ToString()))
                {
                    MessageBox.Show(string.Format("{0} 行目 背景映像コードのフォーマットが違います。", rowIndex), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInputFilePath.Focus();
                    return false;

                }
                string karaokeNumber = dataRow[1].ToString();

                if (karaokeNumber.Length > 8 || !Utils.IsHankakuEiSu(karaokeNumber))
                {
                    MessageBox.Show(string.Format("{0} 行目 背景映像コードのフォーマットが違います。", rowIndex), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInputFilePath.Focus();
                    return false;
                }

                // Get data
                dtImportData.Rows.Add(dataRow[0], dataRow[1]);
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

                int countFail = 0;
                string message = string.Empty;
                int rowIndex = 0;
                DataTable dtFesVideoByKaraokeNumber = new DataTable();
                DataTable dtFesAssigmentDes = new DataTable();

                // truncate table tmp
                fesVideoAssigmentImportBusiness.TruncateFesVideoAssigmentWork();

                dtFesAssigmentDes = fesVideoAssigmentImportBusiness.GetFesVideoAssigmentColumns();

                foreach (DataRow row in dtImportData.Rows)
                {
                    rowIndex++;

                    if (row[0] == null || string.IsNullOrEmpty(row[0].ToString()))
                    {
                        message += string.Format("{0} 行目　カラオケNoが未設定です。", rowIndex);
                        countFail++;
                        continue;
                    }


                    if (!Utils.IsNumeric(row[0].ToString()))
                    {
                        message = string.Format("{0} 行目対応するデジドココンテンツIDが見つかりません。カラオケNo = {1}", rowIndex, row[0].ToString());
                        countFail++;
                        continue;
                    }

                    dtFesVideoByKaraokeNumber = fesVideoAssigmentImportBusiness.GetFesVideoAssigmentByKaraokeNumber(row[0].ToString());

                    if (dtFesVideoByKaraokeNumber.Rows.Count == 0)
                    {
                        message = string.Format("{0} 行目対応するデジドココンテンツIDが見つかりません。カラオケNo = {1}", rowIndex, row[0].ToString());
                        countFail++;
                        continue;
                    }

                    // Add new to FesVideoAssigmentWorkTable
                    dtFesAssigmentDes.Rows.Clear();
                    dtFesAssigmentDes.Rows.Add();

                    dtFesAssigmentDes.Rows[0]["デジドココンテンツID"] = dtFesVideoByKaraokeNumber.Rows[0]["デジドココンテンツID"];
                    dtFesAssigmentDes.Rows[0]["Wii(デジドコ)選曲番号"] = dtFesVideoByKaraokeNumber.Rows[0]["Wii(デジドコ)選曲番号"];
                    dtFesAssigmentDes.Rows[0]["カラオケ選曲番号"] = dtFesVideoByKaraokeNumber.Rows[0]["カラオケ選曲番号"];
                    dtFesAssigmentDes.Rows[0]["楽曲名"] = dtFesVideoByKaraokeNumber.Rows[0]["楽曲名"];
                    dtFesAssigmentDes.Rows[0]["歌手名"] = dtFesVideoByKaraokeNumber.Rows[0]["歌手名"];
                    dtFesAssigmentDes.Rows[0]["楽曲名検索用カナ"] = dtFesVideoByKaraokeNumber.Rows[0]["楽曲名検索用カナ"];
                    dtFesAssigmentDes.Rows[0]["曲名よみがな補正"] = dtFesVideoByKaraokeNumber.Rows[0]["曲名よみがな補正"];
                    dtFesAssigmentDes.Rows[0]["歌手名検索用カナ"] = dtFesVideoByKaraokeNumber.Rows[0]["歌手名検索用カナ"];
                    dtFesAssigmentDes.Rows[0]["背景映像コード"] = row[1].ToString();
                    dtFesAssigmentDes.Rows[0]["アップ予定日"] = dtFesVideoByKaraokeNumber.Rows[0]["アップ予定日"];
                    dtFesAssigmentDes.Rows[0]["サービス発表日"] = dtFesVideoByKaraokeNumber.Rows[0]["サービス発表日"];
                    dtFesAssigmentDes.Rows[0]["取消フラグ"] = dtFesVideoByKaraokeNumber.Rows[0]["取消フラグ"];
                    dtFesAssigmentDes.Rows[0]["JV映像区分(背景映像区分)"] = dtFesVideoByKaraokeNumber.Rows[0]["JV映像区分(背景映像区分)"];
                    dtFesAssigmentDes.Rows[0]["備考"] = dtFesVideoByKaraokeNumber.Rows[0]["備考"];
                    dtFesAssigmentDes.Rows[0]["選択"] = 0;
                    dtFesAssigmentDes.Rows[0]["削除"] = 0;
                    dtFesAssigmentDes.Rows[0]["更新日時"] = DateTime.Now;

                    fesVideoAssigmentImportBusiness.InsertFesVideoAssigment(dtFesAssigmentDes);
                }

                this.ClosedWaiting();
                string notify = string.Format("{0} 件取り込みました。\n{1} 件失敗しました。\n{2}", dtImportData.Rows.Count - countFail, countFail, message);

                IsActive = true;
                Invoke(new Action(() =>
                {
                    MessageBox.Show(notify, GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
