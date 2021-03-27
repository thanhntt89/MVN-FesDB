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
using System.ComponentModel;

namespace Festival.DBTab.ExportTsv
{
    public partial class FesTsvImportRanking : FormBase
    {
        private ImportRankingBusiness importRankingBusiness;

        private DateTime dtImportAnnualFrom = DateTime.MaxValue;
        private DateTime dtImportAnnualTo = DateTime.MaxValue;
        private bool isYearChecked = false;
        // Insert total ranking
        private DataTable dataTotalRanking = null;
        private DataTable dataYearRanking = null;
        private string fileImportAnnual = string.Empty;
        private string fileImportYear = string.Empty;

        public FesTsvImportRanking()
        {
            InitializeComponent();
            importRankingBusiness = new ImportRankingBusiness();

            // init table total ranking
            dataTotalRanking = new DataTable();
            dataTotalRanking.Columns.Add("デジドコ選曲番号");
            dataTotalRanking.Columns.Add("演奏回数");

            // Init table year ranking
            dataYearRanking = new DataTable();
            dataYearRanking.Columns.Add("RANKING_YEAR");
            dataYearRanking.Columns.Add("RANKING_MONTH");
            dataYearRanking.Columns.Add("RANKING_CODE");
            dataYearRanking.Columns.Add("SONG_GROUPID");
            dataYearRanking.Columns.Add("RANKING_POSITION");

        }


        private void btnOpenFileInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = Constants.FILE_FILTER_TXT_EXTENTION;
            var rst = openFile.ShowDialog();
            if (rst == DialogResult.OK)
            {
                txtAnnualFileInputPath.Text = openFile.FileName;
                fileImportAnnual = openFile.FileName;
            }
        }

        private void btnOpenFileInputYear_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = Constants.FILE_FILTER_TXT_EXTENTION;
            var rst = openFile.ShowDialog();
            if (rst == DialogResult.OK)
            {
                txtFileInputPathYear.Text = openFile.FileName;
                fileImportYear = openFile.FileName;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImportFile_Click(object sender, EventArgs e)
        {
            ProgressImport();
        }

        /// <summary>
        /// Load config data
        /// </summary>
        private void LoadData()
        {
            txtAnnualFileInputPath.Text = Properties.Settings.Default.IMPORT_RANKING_総合ランキング + DateTime.Now.ToString("yyyyMM") + Constants.EXTENTION_TXT;
            txtFileInputPathYear.Text = Properties.Settings.Default.IMPORT_RANKING_年間ランキング;
            dtFrom.Value = DateTime.Today.AddDays(-6 - (int)DateTime.Today.DayOfWeek);
            dtTo.Value = dtFrom.Value.AddDays(6);
        }

        private void FesTsvImportRanking_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void chkYearRankingInputFile_CheckedChanged(object sender, EventArgs e)
        {
            btnOpenFileInputYear.Enabled = chkYearRankingInputFile.Checked;
            txtFileInputPathYear.Enabled = chkYearRankingInputFile.Checked;
            isYearChecked = chkYearRankingInputFile.Checked;
        }


        private void ProgressImport()
        {
            if (!Valid())
                return;
            IsActive = false;
            bgwProcess = CreateThread();
            bgwProcess.DoWork += Import_DoWork;
            bgwProcess.RunWorkerCompleted += Import_RunWorkerCompleted;
            bgwProcess.RunWorkerAsync(txtAnnualFileInputPath.Text);

            dtImportAnnualFrom = dtFrom.Value;
            dtImportAnnualTo = dtTo.Value;
            this.ShowWating();
        }

        private void Import_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (bgwProcess != null)
            {
                bgwProcess.DoWork -= Import_DoWork;
                bgwProcess.RunWorkerCompleted -= Import_RunWorkerCompleted;
                bgwProcess = null;
            }

            GC.Collect();
            this.ClosedWaiting();
            if (IsActive)
                btnClose_Click(null, null);
        }

        private void Import_DoWork(object sender, DoWorkEventArgs e)
        {
            ImportData();
        }

        /// <summary>
        /// Valid data input
        /// </summary>
        /// <returns>TRUE is passed | FALSE not passed</returns>
        private bool Valid()
        {
            // Check file annual file input path
            if (!File.Exists(fileImportAnnual))
            {
                MessageBox.Show(GetResources.GetResourceMesssageTsv(Constants.MSGE001), GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnOpenFileInput.Focus();
                return false;
            }

            // check date time
            if (dtFrom.Value > dtTo.Value)
            {
                MessageBox.Show(GetResources.GetResourceMesssageTsv(Constants.MSGE029), GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtFrom.Focus();
                return false;
            }

            // 空のファイルは取り込まない
            try
            {
                FileInfo fileInfo = new FileInfo(fileImportAnnual);

                if (fileInfo.Length == 0 ||
                    (fileInfo.Length > 0
                    && !File.ReadAllLines(fileImportAnnual).Where(dat => !String.IsNullOrWhiteSpace(dat.Trim())).Any())
                )
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssageTsv(Constants.MSGE026), "ランキング"), GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                var dataTotal = File.ReadAllLines(fileImportAnnual);
                var totalRowsCount = dataTotal.Count();
                // Reset data
                dataTotalRanking.Rows.Clear();

                //取り込むファイルのカラム数がおかしいならメッセージ出す
                for (int index = 0; index < totalRowsCount; index++)
                {
                    // Check number of columns in file
                    // Lager than 3 error
                    var dataRows = dataTotal[index].Split('\t');

                    int comLumns = dataRows.Count();

                    // 項目数 = 3　かつ　NULLデーターがある場合、E030のエラーメッセージが表示されます。
                    if (comLumns == 3)
                    {
                        if (string.IsNullOrEmpty(dataRows[0]) || string.IsNullOrEmpty(dataRows[1]))
                        {
                            MessageBox.Show(string.Format(GetResources.GetResourceMesssageTsv(Constants.MSGE030), index + 1, dataRows[0]), "ランキング取込", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                    }
                    //  項目数 < 3 E031のエラーメッセージが表示されます。
                    else if (comLumns < 3)
                    {

                        MessageBox.Show(string.Format(GetResources.GetResourceMesssageTsv(Constants.MSGE031), index + 1, comLumns >= 1 ? dataRows[0] : string.Empty), "ランキング取込", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    //  項目数>  3 の場合、E032のエラーメッセージが表示されます。
                    else if (comLumns > 3)
                    {
                        MessageBox.Show(string.Format(GetResources.GetResourceMesssageTsv(Constants.MSGE032), index + 1, dataRows[0]), "ランキング取込", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    //[デジドコ選曲番号] [演奏回数]
                    dataTotalRanking.Rows.Add(dataRows[1], dataRows[2]);
                }
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

                LogException(error);
                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssageTsv(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Valid year
        /// </summary>
        /// <returns></returns>
        private bool ValidYearChecked()
        {
            if (!isYearChecked)
                return false;

            if (!File.Exists(fileImportYear))
            {
                this.ClosedWaiting();
                Invoke(new Action(() =>
                {
                    MessageBox.Show(GetResources.GetResourceMesssageTsv(Constants.MSGE001), GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnOpenFileInputYear.Focus();
                }));

                return false;
            }

            // Check file ranking year Empty
            // Check file annual empty
            // Check file no data
            try
            {
                FileInfo fileInfo = new FileInfo(fileImportYear);

                if (fileInfo.Length == 0 ||
                    (fileInfo.Length > 0
                    && !File.ReadAllLines(fileImportYear).Where(data => !String.IsNullOrWhiteSpace(data.Trim())).Any())
                )
                {
                    this.ClosedWaiting();
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format(GetResources.GetResourceMesssageTsv(Constants.MSGE026), "年間ランキング"), GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));

                    return false;
                }

                var dataYear = File.ReadAllLines(fileImportYear);
                var totalRowsCount = dataYear.Count();

                // Reset data
                dataYearRanking.Rows.Clear();

                for (int index = 0; index < totalRowsCount; index++)
                {
                    // Check number of columns in file
                    // Lager than 5 error
                    var dataRows = dataYear[index].Split('\t');

                    int comLumns = dataRows.Count();

                    // 項目数 = 5　かつ　NULLデーターがある場合、E033 のエラーメッセージが表示されます。
                    if (comLumns == 5)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            if (string.IsNullOrEmpty(dataRows[k]))
                            {
                                this.ClosedWaiting();
                                Invoke(new Action(() =>
                                {
                                    MessageBox.Show(string.Format(GetResources.GetResourceMesssageTsv(Constants.MSGE033), index + 1, dataRows[3]),
                                        "ランキング取込", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }));
                                return false;
                            }
                        }

                    }
                    // 項目数 < 5 E034のエラーメッセージが表示されます。
                    else if (comLumns < 5)
                    {
                        this.ClosedWaiting();
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(string.Format(GetResources.GetResourceMesssageTsv(Constants.MSGE034), index + 1, comLumns >= 4 ? dataRows[3] : string.Empty),
                                "ランキング取込", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));

                        return false;
                    }
                    // 項目数 >  5 の場合、E035のエラーメッセージが表示されます。
                    else if (comLumns > 5)
                    {
                        this.ClosedWaiting();
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(string.Format(GetResources.GetResourceMesssageTsv(Constants.MSGE035), index + 1, dataRows[3]),
                                "ランキング取込", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));

                        return false;
                    }
                    if (index >= 1)
                    {
                        dataYearRanking.Rows.Add(dataRows[0], dataRows[1], dataRows[2], dataRows[3], dataRows[4]);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ClosedWaiting();
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                LogException(error);
                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssageTsv(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Import database
        /// </summary>
        /// <param name="filePathAnnual">file path in local</param>
        /// <param name="filePathYear">file path in local</param>
        private void ImportData()
        {
            ImportRankingDay();
            ImportRankingYear();
        }

        private void ImportRankingDay()
        {
            try
            {
                // Delete total ranking
                importRankingBusiness.TruncateTablTotalRanking();
                // Import bulk
                importRankingBusiness.BulkInsert(dataTotalRanking, Constants.TABLE_TOTAL_RANKING);
                // Create tabale ranking
                importRankingBusiness.CreateTotalRankingTable();
                // Update ranking aggregationperiod
                importRankingBusiness.UpdateRankingAggregationPeriod(dtImportAnnualFrom.ToString("yyyy/MM/dd"), dtImportAnnualTo.ToString("yyyy/MM/dd"));

                if (!chkYearRankingInputFile.Checked)
                {
                    this.ClosedWaiting();
                }
                IsActive = true;
                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssageTsv(Constants.MSGI004), dataTotalRanking.Rows.Count, 0), GetResources.GetResourceMesssageTsv(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
            }
            catch (Exception ex)
            {
                this.ClosedWaiting();
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                LogException(error);
                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssageTsv(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));

                return;
            }

        }

        private void ImportRankingYear()
        {
            try
            {
                if (!ValidYearChecked())
                {
                    return;
                }

                IsActive = false;

                importRankingBusiness.TruncateKaraokeYearRanking();
                importRankingBusiness.BulkInsert(dataYearRanking, Constants.TABLE_KARAOKE_YEAR_RANKING);
                IsActive = true;

                this.ClosedWaiting();

                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssageTsv(Constants.MSGI005), dataYearRanking.Rows.Count, 0), GetResources.GetResourceMesssageTsv(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
            }
            catch (Exception ex)
            {
                this.ClosedWaiting();
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                LogException(error);
                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssageTsv(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.I)
            {
                btnImportFile_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
