using DevComponents.DotNetBar.Controls;
using Festival.Base;
using Festival.Common;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Festival.DiscVideoTab.FesSongWithDisc
{
    public partial class FesSongWithDiscSearch : FormBase
    {
        private FesSongWithDiscBusiness fesSongWithDiscBusiness;

        // List parameter
        public List<string> SlqParameters { get; set; }

        public FesSongWithDiscSearch(LayOutEntity layOutEntity)
        {
            InitializeComponent();

            CurrentLayOut = layOutEntity;
            if (fesSongWithDiscBusiness == null)
                fesSongWithDiscBusiness = new FesSongWithDiscBusiness();

            txtDigiDocoNoFrom.Focus();

            LoadControlIndex();
            LoadInitRegisteredConditionCombox();
            LoadUsAgeFlagCombox();
            this.ActiveControl = txtDigiDocoNoFrom;
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadUsAgeFlagCombox()
        {
            try
            {
                DataTable dataSource = new DataTable();
                dataSource = fesSongWithDiscBusiness.GetUseAgeFlagDataForCombox();
                cboUsAgeFlag.DataSource = dataSource;
                cboUsAgeFlag.ValueMember = dataSource.Columns[0].ColumnName;
                cboUsAgeFlag.DisplayMember = dataSource.Columns[1].ColumnName;
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
            }
        }

        private void LoadInitRegisteredConditionCombox()
        {
            try
            {
                DataTable dataSource = new DataTable();
                if (CurrentLayOut.Version == DisVersion.VERSION_NUMBER_V1)
                {
                    lblFes_DISCID.Text = "Fes_DISCID_V1";
                    lblFes_NET利用フラグ.Text = "Fes_NET利用フラグ_V1";
                    dataSource = fesSongWithDiscBusiness.GetRegisteredConditionData(Properties.Settings.Default.FES_SONG_WITH_DISC_検索条件_V1);
                }
                else if (CurrentLayOut.Version == DisVersion.VERSION_NUMBER_V2)
                {
                    lblFes_DISCID.Text = "Fes_DISCID_V2";
                    lblFes_NET利用フラグ.Text = "Fes_NET利用フラグ_V2";
                    dataSource = fesSongWithDiscBusiness.GetRegisteredConditionData(Properties.Settings.Default.FES_SONG_WITH_DISC_検索条件_V2);
                }

                cboRegisteredCondition.DataSource = dataSource;
                cboRegisteredCondition.ValueMember = dataSource.Columns[0].ColumnName;
                cboRegisteredCondition.DisplayMember = dataSource.Columns[1].ColumnName;
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
            }
        }

        private void Clear()
        {
            foreach (Control ctrl in grpSearchingCondition.Controls)
            {
                TextBoxX txt = ctrl as TextBoxX;
                if (txt != null)
                {
                    txt.Text = string.Empty;
                }

                MaskedTextBoxAdv dtInput = ctrl as MaskedTextBoxAdv;
                if (dtInput != null)
                {
                    dtInput.Text = string.Empty;
                }

                ComboBoxEx cbo = ctrl as ComboBoxEx;
                if (cbo != null)
                {
                    cbo.SelectedIndex = 0;
                }
            }
            radPartialMatch.Checked = true;
        }

        private void Search()
        {
            if (!Valid())
                return;

            SearchingProcess();
        }

        private void SearchingProcess()
        {
            GetParamterAll();

            if (SlqParameters.Count == 0)
            {
                var rst = MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGI011), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (rst != DialogResult.Yes)
                {
                    return;
                }
            }

            bgwProcess = CreateThread();
            bgwProcess.RunWorkerCompleted += Search_RunWorkerCompleted;
            bgwProcess.DoWork += Search_DoWork;
            bgwProcess.RunWorkerAsync();
            this.ShowWating();
        }

        private void Search_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                // Truncate work table
                fesSongWithDiscBusiness.TruncateWorkTableTmp();

                // Search
                fesSongWithDiscBusiness.ExecuteSearch(SlqParameters, CurrentLayOut.Version);

                // Truncate table fest content               
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

        private void Search_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (IsActive)
                this.Hide();

            if (bgwProcess != null)
            {
                bgwProcess.RunWorkerCompleted -= Search_RunWorkerCompleted;
                bgwProcess.DoWork -= Search_DoWork;
                bgwProcess.Dispose();
            }
            bgwProcess = null;
            GC.Collect();
            this.ClosedWaiting();
        }

        private bool Valid()
        {
            if (!CheckCompareNumberInput(lblデジドコNo.Text, Constants.MSGE006, txtDigiDocoNoFrom, txtDigiDocoNoTo))
            {
                return false;
            }
            if (!CheckCompareNumberInput(lblカラオケNo.Text, Constants.MSGE006, txtKaraokeNoFrom, txtKaraokeNoTo))
            {
                return false;
            }
            if (!CheckCompareNumberInput(lblFes_DISCID.Text, Constants.MSGE006, txtFes_DISCIDFrom, txtFes_DISCIDTo))
            {
                return false;
            }
            if (!CheckDateTimeInput(lbl取消日.Text, Constants.MSGE016, null, dtCancelDateFrom, dtCancelDateTo))
            {
                return false;
            }
            if (!CheckDateTimeInput(lblFes_アップ予定日.Text, Constants.MSGE016, null, dtScheduleUpdateDateFrom, dtScheduleUpdateDateTo))
            {
                return false;
            }
            if (!CheckDateTimeInput(lblFes_サービス発表日.Text, Constants.MSGE016, null, dtServiceDateFrom, dtServiceDateTo))
            {
                return false;
            }
            if (!CheckDateTimeInput(lblOrch_制作完了日.Text, Constants.MSGE016, null, dtProductionDateFrom, dtProductionDateTo))
            {
                return false;
            }
            return true;
        }

        private void GetParamterAll()
        {
            if (SlqParameters == null)
                SlqParameters = new List<string>();
            SlqParameters.Clear();

            Invoke(new Action(() =>
            {
                //1.デジドコNo
                GetParameterTextBoxNumber("[Wii(デジドコ)選曲番号]", txtDigiDocoNoFrom, txtDigiDocoNoTo);
                //2.カラオケNo
                GetParameterTextBoxNumber("[カラオケ選曲番号]", txtKaraokeNoFrom, txtKaraokeNoTo);
                //3.曲名(MARY)
                GetParameterTextBox("[楽曲名]", txtSongName);
                //4.曲名カナ
                GetParameterTextBox("[楽曲名検索用カナ]", txtSongNamKana);
                //5.曲名カナ補正
                GetParameterTextBox("[曲名よみがな補正]", txtSongNameTitleKanaCorrection);
                //6.歌手名
                GetParameterTextBox("[歌手名]", txtSingerName);
                //7.歌手名カナ
                GetParameterTextBox("[歌手名検索用カナ]", txtSingerNameKana);

                //8.Fes_DISCID
                //9. Fes_NET利用フラグ
                if (CurrentLayOut.Version == DisVersion.VERSION_NUMBER_V1)
                {
                    GetParameterTextBoxNumber("[FesDISCID]", txtFes_DISCIDFrom, txtFes_DISCIDTo);

                    GetParameterFromCombox("[NET利用フラグ]", cboUsAgeFlag, false);
                }
                else if (CurrentLayOut.Version == DisVersion.VERSION_NUMBER_V2)
                {
                    GetParameterTextBoxNumber("[FesDISCID(Ver2)]", txtFes_DISCIDFrom, txtFes_DISCIDTo);
                    GetParameterFromCombox("[NET利用フラグ(Ver2)]", cboUsAgeFlag, false);
                }
                //10. 取消日
                GetParameterComboxWithDateTime("[取消日(Ver2)]", null, dtCancelDateFrom, dtCancelDateTo, "yyyyMMdd");
                //11. Fes_アップ予定日
                GetParameterComboxWithDateTime("[アップ予定日]", null, dtScheduleUpdateDateFrom, dtScheduleUpdateDateTo, "yyyyMMdd");
                //12. Fes_サービス発表日
                GetParameterComboxWithDateTime("[サービス発表日]", null, dtServiceDateFrom, dtServiceDateTo, "yyyyMMdd");
                //13. Orch_制作完了日
                GetParameterComboxWithDateTime("[Wii_U_制作完了日]", null, dtProductionDateFrom, dtProductionDateTo, "yyyyMMdd");
                //14. 登録済み条件
                GetParameterFromCombox(null, cboRegisteredCondition);
            }));
        }

        /// <summary>
        /// Input only numeric
        /// </summary>
        /// <param name="e"></param>
        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            base.OnKeyPress(e);
        }

        private void OnLeave(object sender, EventArgs e)
        {
            TextBoxX text = (TextBoxX)sender;
            if (text == null)
                return;
            if (!text.Text.All(char.IsNumber))
            {
                text.Text = null;
            }
            base.OnLeave(e);
        }

        public bool CheckDateTimeInput(string lableName, string messageCode, ComboBoxEx combox, MaskedTextBoxAdv dtFrom, MaskedTextBoxAdv dtTo)
        {
            return GetParameterUtils.CheckDateTimeInput(lableName, messageCode, combox, dtFrom, dtTo);
        }

        public bool CheckCompareNumberInput(string labaleName, string messageCode, TextBoxX textBox1, TextBoxX textBox2)
        {
            return GetParameterUtils.CheckCompareNumberInput(labaleName, messageCode, textBox1, textBox2);
        }

        private void GetParameterFromCombox(string columnName, ComboBoxEx cboCheck, bool IsGetValue = true)
        {
            GetParameterUtils.GetParameterFromCombox(SlqParameters, columnName, cboCheck, IsGetValue);
        }

        private void GetParameterComboxWithDateTime(string columnCondition, ComboBoxEx combCheck, MaskedTextBoxAdv dtFrom, MaskedTextBoxAdv dtTo, string format = "")
        {
            GetParameterUtils.GetParameterComboxWithDateTime(SlqParameters, columnCondition, combCheck, dtFrom, dtTo, format);
        }

        private void GetParameterTextBox(string columnName, TextBoxX textBox)
        {
            GetParameterUtils.GetParameterTextBox(SlqParameters, columnName, textBox, radMatchingAll, radFrontMatch, radPartialMatch, radExclude);
        }

        private void GetParameterTextBoxNumber(string columnName, TextBoxX textNumberFrom, TextBoxX textNumberTo)
        {
            GetParameterUtils.GetParameterTextBoxNumber(SlqParameters, columnName, textNumberFrom, textNumberTo);
        }

        private void LoadControlIndex()
        {
            btnDigiDokoNoInput.TabIndex = (int)TabIndex.btnDigiDokoNoInput;
            btnKaraokeNoInput.TabIndex = (int)TabIndex.btnKaraokeNoInput;
            btnVideoCodeInput.TabIndex = (int)TabIndex.btnVideoCodeInput;
            txtDigiDocoNoFrom.TabIndex = (int)TabIndex.txtDigiDocoNoFrom;
            txtDigiDocoNoTo.TabIndex = (int)TabIndex.txtDigiDocoNoTo;
            txtKaraokeNoFrom.TabIndex = (int)TabIndex.txtKaraokeNoFrom;
            txtKaraokeNoTo.TabIndex = (int)TabIndex.txtKaraokeNoTo;
            txtSongName.TabIndex = (int)TabIndex.txtSongName;
            txtSongNamKana.TabIndex = (int)TabIndex.txtSongNamKana;
            txtSongNameTitleKanaCorrection.TabIndex = (int)TabIndex.txtSongNameTitleKanaCorrection;
            txtSingerName.TabIndex = (int)TabIndex.txtSingerName;
            txtSingerNameKana.TabIndex = (int)TabIndex.txtSingerNameKana;
            txtFes_DISCIDFrom.TabIndex = (int)TabIndex.txtFes_DISCIDFrom;
            txtFes_DISCIDTo.TabIndex = (int)TabIndex.txtFes_DISCIDTo;
            dtCancelDateFrom.TabIndex = (int)TabIndex.dtCancelDateFrom;
            dtCancelDateTo.TabIndex = (int)TabIndex.dtCancelDateTo;
            cboUsAgeFlag.TabIndex = (int)TabIndex.cboUsAgeFlag;
            dtScheduleUpdateDateFrom.TabIndex = (int)TabIndex.dtScheduleUpdateDateFrom;
            dtScheduleUpdateDateTo.TabIndex = (int)TabIndex.dtScheduleUpdateDateTo;
            cboRegisteredCondition.TabIndex = (int)TabIndex.cboRegisteredCondition;
            dtServiceDateFrom.TabIndex = (int)TabIndex.dtServiceDateFrom;
            dtServiceDateTo.TabIndex = (int)TabIndex.dtServiceDateTo;
            dtProductionDateFrom.TabIndex = (int)TabIndex.dtProductionDateFrom;
            dtProductionDateTo.TabIndex = (int)TabIndex.dtProductionDateTo;
            radMatchingAll.TabIndex = (int)TabIndex.radMatchingAll;
            radFrontMatch.TabIndex = (int)TabIndex.radFrontMatch;
            radPartialMatch.TabIndex = (int)TabIndex.radPartialMatch;
            radExclude.TabIndex = (int)TabIndex.radExclude;
            btnClear.TabIndex = (int)TabIndex.btnClear;
            btnSearch.TabIndex = (int)TabIndex.btnSearch;
            btnClose.TabIndex = (int)TabIndex.btnClose;
            grpSearchingCondition.TabIndex = (int)TabIndex.groupBox2;
        }

        private enum TabIndex
        {
            btnDigiDokoNoInput,
            btnKaraokeNoInput,
            btnVideoCodeInput,
            groupBox2,
            txtDigiDocoNoFrom,
            txtDigiDocoNoTo,
            txtKaraokeNoFrom,
            txtKaraokeNoTo,
            txtSongName,
            txtSongNamKana,
            txtSongNameTitleKanaCorrection,
            txtSingerName,
            txtSingerNameKana,
            txtFes_DISCIDFrom,
            txtFes_DISCIDTo,
            cboUsAgeFlag,
            dtCancelDateFrom,
            dtCancelDateTo,
            dtScheduleUpdateDateFrom,
            dtScheduleUpdateDateTo,
            dtServiceDateFrom,
            dtServiceDateTo,
            dtProductionDateFrom,
            dtProductionDateTo,
            cboRegisteredCondition,
            radMatchingAll,
            radFrontMatch,
            radPartialMatch,
            radExclude,
            btnClear,
            btnSearch,
            btnClose
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.C))
            {
                btnClear_Click(null, null);
            }
            if (keyData == (Keys.Control | Keys.D))
            {
                SetDateValue();
            }
            if (keyData == (Keys.Shift | Keys.F12))
            {
                btnKaraokeNoInput_Click(null, null);
            }
            if (keyData == (Keys.Shift | Keys.F11))
            {
                btnVideoCodeInput_Click(null, null);
            }
            else if (keyData == Keys.F12)
            {
                btnDigiDokoNoInput_Click(null, null);
            }
            else if (keyData == Keys.F5)
            {
                btnSearch_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SetDateValue()
        {
            foreach (Control ctrl in grpSearchingCondition.Controls)
            {
                MaskedTextBoxAdv input = ctrl as MaskedTextBoxAdv;
                if (input != null)
                {
                    if (ctrl.ContainsFocus)
                    {
                        input.Text = DateTime.Now.ToString(Constants.DATE_TIME_FORMAT_SQL111);
                        break;
                    }
                }
            }
        }

        private void OpenInputSongNumber(EnumInputTypeName functioName)
        {
            IsActive = false;
            this.Hide();
            FesSongWithDiscInputSongNumber fesVideoAssigmentInputSongNumber = new FesSongWithDiscInputSongNumber(functioName, CurrentLayOut.Version);
            fesVideoAssigmentInputSongNumber.ShowDialog();
            if (fesVideoAssigmentInputSongNumber.IsActive)
            {
                IsActive = true;
                // Reset active
                fesVideoAssigmentInputSongNumber.IsActive = false;
            }
        }

        private void btnDigiDokoNoInput_Click(object sender, EventArgs e)
        {
            if (btnDigiDokoNoInput.Enabled)
                OpenInputSongNumber(EnumInputTypeName.選曲番号入力);
        }

        private void btnKaraokeNoInput_Click(object sender, EventArgs e)
        {
            if (btnKaraokeNoInput.Enabled)
                OpenInputSongNumber(EnumInputTypeName.選曲番号入力カラオケ);
        }

        private void btnVideoCodeInput_Click(object sender, EventArgs e)
        {
            if (btnVideoCodeInput.Enabled)
                OpenInputSongNumber(EnumInputTypeName.Fes_DISCID);
        }

    }
}
