using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

namespace Festival.DBTab.FesContent
{
    public partial class FesContentImportList : FormBase
    {
        private FesContentBusiness contentBusiness;
        private DataTable tableExcellImport = new DataTable();

        // List song number in excel file
        private List<string> SongNumberList = new List<string>();

        private int SuccessCount = 0;
        private int FailsColumnCount = 0;
        private int totalRecords = 0;

        public FesContentImportList()
        {
            InitializeComponent();
            contentBusiness = new FesContentBusiness();
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ProcessImportExecute();
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

            string extention = Path.GetExtension(txtInputFilePath.Text);
            if (extention.Contains(Constants.EXTENTION_TXT))
            {
                if (!ValidFileTxt(txtInputFilePath.Text))
                {
                    return false;
                }
            }
            if (extention.Contains(Constants.EXTENTION_EXCEL))
            {
                if (!ValidFileExcel(txtInputFilePath.Text))
                    return false;
            }

            return true;
        }

        private void ProcessImportExecute()
        {
            if (!Valid())
                return;

            var rst = MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGI001), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (rst != DialogResult.Yes)
            {
                return;
            }

            bgwProcess = CreateThread();

            bgwProcess.DoWork += ImportExecute_DoWork;
            bgwProcess.RunWorkerCompleted += ImportExecute_RunWorkerCompleted;
            bgwProcess.RunWorkerAsync();
            this.ShowWating();
        }

        private void ImportExecute_DoWork(object sender, DoWorkEventArgs e)
        {
            ImportExecute();
        }

        private void ImportExecute_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (bgwProcess != null)
            {
                bgwProcess.DoWork -= ImportExecute_DoWork;
                bgwProcess.RunWorkerCompleted -= ImportExecute_RunWorkerCompleted;
                bgwProcess.Dispose();
            }
            bgwProcess = null;
            GC.Collect();
            this.ClosedWaiting();
            if (IsActive)
                // After closing this form call unfilter
                this.Close();
        }

        private void ImportExecute()
        {
            try
            {
                // ワークテーブルの内容を削除する ID_FES_CONTENTS
                contentBusiness.TruncateFesConentTable();

                // Txt file checked
                if (rdSongInFileText.Checked)
                {
                    ImportTextFile();
                }
                // Excel checked
                else if (rdSongInFileExcel.Checked)
                {
                    ImportExcelFile();
                }

                IsActive = true;

                this.ClosedWaiting();

                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format("{0} 件取り込みました。", totalRecords), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void ImportExcelFile()
        {
            try
            {
                // 選曲番号保存用ワークテーブルクリア strTable_SongNumber
                contentBusiness.TruncateSelectionSongNumber();

                // Insert data from excel files
                contentBusiness.InsertSongNumberList(SongNumberList);

                //Fesコンテンツワークテーブル更新 
                contentBusiness.InsertWorkTable();

                // カラオケ選曲番号取得	
                DataTable songNumberTable = contentBusiness.SelectKaraokeSongNumber(SongNumberList);

                // データー取得した後に、「ファイルの内容を検証」へ
                if (ValidSongNumber(songNumberTable))
                {
                    this.ClosedWaiting();
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA001), SuccessCount, FailsColumnCount), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidSongNumber(DataTable songNumberTable)
        {
            try
            {
                int rowIndex = 0;
                FailsColumnCount = 0;
                foreach (DataRow row in songNumberTable.Rows)
                {
                    rowIndex++;
                    SuccessCount++;

                    string data = DataTableUtil.GetDataInColumn(row, "Fesアレンジコード", songNumberTable);
                    // エラーメッセージ:  "3文字以内で指定してください。"
                    if (data != null)
                    {
                        FailsColumnCount++;
                        this.ClosedWaiting();
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE027), rowIndex, data), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));

                        return false;
                    }
                    // エラーメッセージ:  "数字で指定してください。"
                    if (!Utils.IsNumeric(data))
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE019), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    //邦題優先フラグ
                    string dataColum邦題優先フラグ = DataTableUtil.GetDataInColumn(row, "邦題優先フラグ", songNumberTable);
                    if (dataColum邦題優先フラグ != null && ((!dataColum邦題優先フラグ.Equals("0") || !dataColum邦題優先フラグ.Equals("1"))))
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE018), rowIndex, dataColum邦題優先フラグ), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }
                    string data楽曲名邦題 = DataTableUtil.GetDataInColumn(row, "楽曲名邦題", songNumberTable);
                    if (dataColum邦題優先フラグ != null && !dataColum邦題優先フラグ.Equals("1") && data楽曲名邦題 == null)
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE020), rowIndex), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    // 曲名補正
                    data = DataTableUtil.GetDataInColumn(row, "曲名補正", songNumberTable);

                    if (data != null && data.Length > 384)
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE003), "曲名補正"), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }
                    // かなNULLフラグ
                    data = DataTableUtil.GetDataInColumn(row, "かなNULLフラグ", songNumberTable);
                    if (data != null && ((!data.Equals("0") || !data.Equals("1"))))
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE018), rowIndex, data), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    // 曲名カナ補正
                    data = DataTableUtil.GetDataInColumn(row, "曲名カナ補正", songNumberTable);
                    if (data != null && data.Length > 256)
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE005), rowIndex, data), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    // 曲名ソート補正
                    data = DataTableUtil.GetDataInColumn(row, "曲名ソート補正", songNumberTable);
                    if (data != null && data.Length > 256)
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE005), rowIndex, data), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }
                    // Check katakana waitting

                    // 歌手ID補正
                    data = DataTableUtil.GetDataInColumn(row, "歌手ID補正", songNumberTable);
                    if (data != null && !Utils.IsNumeric(data))
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE019), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));

                        return false;
                    }

                    // Compare with excel file
                    if (!DataTableUtil.CheckDataInColumn(data, "歌手ID補正", tableExcellImport))
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE021), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    // Fes_アップ予定日
                    data = DataTableUtil.GetDataInColumn(row, "Fes_アップ予定日", songNumberTable);
                    if (data != null && data.Length != 8)
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE002), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }
                    if (!Utils.IsDataTime(data))
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE022), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    // Fes_ライツ用サービス発表日
                    data = DataTableUtil.GetDataInColumn(row, "Fes_ライツ用サービス発表日", songNumberTable);
                    if (data != null && data.Length != 8)
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE002), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }
                    if (!Utils.IsDataTime(data))
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE022), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    // Fes_検索表示可否フラグ
                    data = DataTableUtil.GetDataInColumn(row, "Fes_検索表示可否フラグ", songNumberTable);
                    if (data != null && ((!data.Equals("0") || !data.Equals("1"))))
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE018), rowIndex, data), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    // Fes_取消フラグ
                    data = DataTableUtil.GetDataInColumn(row, "Fes_取消フラグ", songNumberTable);
                    if (data != null && !Utils.IsNumeric(data))
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE019), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    // Compare with excel file
                    if (!DataTableUtil.CheckDataInColumn(data, "Fes_取消フラグ", tableExcellImport))
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE021), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    // Fes_停止日
                    data = DataTableUtil.GetDataInColumn(row, "Fes_停止日", songNumberTable);
                    if (data != null && data.Length != 8)
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE002), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }
                    if (!Utils.IsDataTime(data))
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE022), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    // Fes_削除情報
                    data = DataTableUtil.GetDataInColumn(row, "Fes_削除情報", songNumberTable);
                    if (data != null && data.Length > 255)
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE002), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));

                        return false;
                    }

                    // Fes_録画可否フラグ
                    data = DataTableUtil.GetDataInColumn(row, "Fes_録画可否フラグ", songNumberTable);
                    if (data != null && ((!data.Equals("0") || !data.Equals("1"))))
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE018), rowIndex, data), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    // Fes_有料コンテンツフラグ"
                    data = DataTableUtil.GetDataInColumn(row, "Fes_有料コンテンツフラグ", songNumberTable);
                    if (data != null && ((!data.Equals("0") || !data.Equals("1"))))
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE018), rowIndex, data), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    // Fes_チャプターフラグ
                    data = DataTableUtil.GetDataInColumn(row, "Fes_チャプターフラグ", songNumberTable);
                    if (data != null && ((!data.Equals("0") || !data.Equals("1"))))
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE018), rowIndex, data), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    // INTRO_TYPE補正
                    data = DataTableUtil.GetDataInColumn(row, "INTRO_TYPE補正", songNumberTable);
                    if (data != null && ((!data.Equals("0") || !data.Equals("1"))))
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE018), rowIndex, data), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    //Fes_映像ジャンル 
                    data = DataTableUtil.GetDataInColumn(row, "Fes_映像ジャンル", songNumberTable);

                    // Compare with excel file
                    if (!DataTableUtil.CheckDataInColumn(data, "Fes_映像ジャンル", tableExcellImport))
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE021), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    // 著作権備考
                    data = DataTableUtil.GetDataInColumn(row, "著作権備考", songNumberTable);
                    if (data != null && data.Length > 255)
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE002), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    // 新譜本扱月
                    data = DataTableUtil.GetDataInColumn(row, "新譜本扱月", songNumberTable);
                    if (data != null && data.Length != 6)
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE002), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    // 備考
                    data = DataTableUtil.GetDataInColumn(row, "備考", songNumberTable);
                    if (data != null && data.Length > 255)
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE002), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    // 曲名ソート英数補正
                    data = DataTableUtil.GetDataInColumn(row, "曲名ソート英数補正", songNumberTable);
                    if (data != null && data.Length > 180)
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE002), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }
                    if (!Char.IsUpper(data, 0))
                    {
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE023), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    // 演奏時間補正
                    data = DataTableUtil.GetDataInColumn(row, "演奏時間補正", songNumberTable);
                    if (data != null && Utils.IsNumeric(data))
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE019), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }
                    if (data != null && data.Length > 8)
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE002), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }


                    //支援レベル 
                    data = DataTableUtil.GetDataInColumn(row, "支援レベル", songNumberTable);

                    // Compare with excel file
                    if (!DataTableUtil.CheckDataInColumn(data, "支援レベル", tableExcellImport))
                    {
                        this.ClosedWaiting();
                        FailsColumnCount++;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE021), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }
                }

                return true;

            }
            catch
            {
                return false;
            }
        }

        private void ImportTextFile()
        {
            try
            {
                contentBusiness.ImportFile(txtInputFilePath.Text, Properties.Settings.Default.FES_CONTENT_SERVER_PATH_録音可能リスト取込配置ファイル);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidFileTxt(string filePath)
        {
            FileInfo file = new FileInfo(filePath);

            if (file.Length == 0 ||
                (file.Length > 0 && !File.ReadAllLines(txtInputFilePath.Text).Where(dat => !String.IsNullOrWhiteSpace(dat.Trim())).Any())
            )
            {
                this.ClosedWaiting();

                Invoke(new Action(() =>
                {
                    MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE026), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInputFilePath.Focus();
                }));

                return false;
            }

            var KaraokeNo = File.ReadAllLines(filePath);
            totalRecords = KaraokeNo.Count();

            for (int rowIndex = 0; rowIndex < totalRecords; rowIndex++)
            {
                var dataRow = KaraokeNo[rowIndex].Split('\t');
                int columns = dataRow.Count();
                // File has more one column
                if (columns > 1)
                {
                    this.ClosedWaiting();
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(GetResources.GetResourceMesssage(Constants.MESSAGE_ERROR_FILE_NOT_FOUND), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInputFilePath.Focus();
                    }));

                    return false;
                }

                if (!Utils.IsNumeric(dataRow[0]) || dataRow[0].Length > 8)
                {
                    this.ClosedWaiting();
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE027), rowIndex, dataRow[0]), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInputFilePath.Focus();
                    }));

                    return false;
                }
            }
            return true;
        }

        private bool ValidFileExcel(string filePath)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            tableExcellImport.Columns.Clear();

            try
            {
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                if (colCount > 30)
                {
                    this.ClosedWaiting();
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE028), colCount), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInputFilePath.Focus();
                    }));

                    return false;
                }

                int songNumberColumnIndex = -1;

                // Column カラオケNo exist in first row
                for (int columnIndex = 1; columnIndex <= colCount; columnIndex++)
                {
                    Excel.Range range = (xlWorksheet.Cells[1, columnIndex] as Excel.Range);
                    if (range.Value.ToString().Equals("カラオケNo"))
                    {
                        songNumberColumnIndex = columnIndex;
                        break;
                    }
                }
                // If not exist column カラオケNo in first row notify message
                if (songNumberColumnIndex == -1)
                {
                    this.ClosedWaiting();
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE027), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInputFilePath.Focus();
                    }));

                    return false;
                }

                // Create data table import
                for (int columnIndex = 1; columnIndex <= colCount; columnIndex++)
                {
                    Excel.Range range = (xlWorksheet.Cells[1, columnIndex] as Excel.Range);
                    tableExcellImport.Columns.Add(range.Value.ToString());
                }

                // Get songnumber in song number column
                for (int rowIndex = 2; rowIndex <= rowCount; rowIndex++)
                {
                    Excel.Range rangeSongColumn = (xlWorksheet.Cells[rowIndex, songNumberColumnIndex] as Excel.Range);

                    SongNumberList.Add(rangeSongColumn.Value.ToString());

                    // Add new Rows
                    tableExcellImport.Rows.Add();

                    // Fill data to column
                    for (int columnIndex = 1; columnIndex <= colCount; columnIndex++)
                    {
                        Excel.Range range = (xlWorksheet.Cells[rowIndex, columnIndex] as Excel.Range);
                        object data = range.Value;

                        tableExcellImport.Rows[rowIndex - 2][columnIndex - 1] = data == null ? string.Empty : data.ToString();
                    }
                }

                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception ex)
            {     //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                return false;
            }

            return true;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (rdSongInFileText.Checked)
            {
                openFile.Filter = Constants.FesContentSoundRecordingFilter;
            }
            else if (rdSongInFileExcel.Checked)
            {
                openFile.Filter = Constants.FesContentUpdateItemFilter;
            }
            var rst = openFile.ShowDialog();
            if (rst != DialogResult.OK)
                return;
            txtInputFilePath.Text = openFile.FileName;
        }

        private void ImportList_Load(object sender, EventArgs e)
        {
            LoadInit();
        }

        private void LoadInit()
        {
            rdReplaceNull.Checked = true;
            rdSongInFileText.Checked = true;
            rdSongInFileText_CheckedChanged(null, null);
            if(!string.IsNullOrWhiteSpace(Properties.Settings.Default.FES_CONTENT_IMPORT_FILE_TXT_録音可能曲リスト取込))
            txtInputFilePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + Properties.Settings.Default.FES_CONTENT_IMPORT_FILE_TXT_録音可能曲リスト取込;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                btnImport_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void rdSongInFileText_CheckedChanged(object sender, EventArgs e)
        {
            txtInputFilePath.Text = Properties.Settings.Default.FES_CONTENT_IMPORT_FILE_TXT_録音可能曲リスト取込;
        }

        private void rdSongInFileExcel_CheckedChanged(object sender, EventArgs e)
        {
            txtInputFilePath.Text = Properties.Settings.Default.FES_CONTENT_IMPORT_FILE_XSL_更新項目リスト取込;
        }
    }
}
