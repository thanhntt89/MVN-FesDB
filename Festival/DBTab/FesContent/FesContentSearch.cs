using System.Windows.Forms;
using Festival.Base;
using FestivalCommon;
using System;
using System.Data;
using FestivalBusiness;
using System.Reflection;
using DevComponents.DotNetBar.Controls;
using System.Linq;
using System.Collections.Generic;
using DevComponents.Editors.DateTimeAdv;
using FestivalUtilities;
using Festival.Common;

namespace Festival.DBTab.FesContent
{
    public partial class FesContentSearch : FormBase
    {
        private LayoutCollection DisableButtonScreens = new LayoutCollection();
        private CommonBusiness commonBusiness;
        private FesContentBusiness festivalContentBusiness = null;

        // List parameter
        public List<string> SlqParameters { get; set; }

        public FesContentSearch(LayOutEntity layOutEntity)
        {
            InitializeComponent();
            this.CurrentLayOut = layOutEntity;
            // Language changed
            this.InputLanguageChanged += new InputLanguageChangedEventHandler(languageChange);

            festivalContentBusiness = new FesContentBusiness();

            LoadTitle();
            RemoveWaterMask();
        }

        private void LoadTitle()
        {
            if (this.CurrentLayOut.LayoutName == LayOut.FesContentMainAdvance)
            {
                this.Text = "Festivalコンテンツ_検索条件";
            }
        }

        private void InitCombox()
        {
            LoadComboxFesUpDate();
            LoadComboxFinishedDate();
            LoadComboxFesServicePublicDate();
            LoadComboxFesCancelFlag();
            LoadComboxFesPaidContentFlag();
            LoadComboxFesChapterFlag();
            LoadComboxSupportLevel();
            LoadComboxOrchServicePublic();
            LoadComboxOrchCancelFlag();
            LoadComboxRegisteredConditions();
        }

        private void LoadComboxFesUpDate()
        {
            try
            {
                DataTable dataSource = commonBusiness.GetDataComboxFesUpDate();

                cboFesUpDate.DataSource = dataSource;
                cboFesUpDate.ValueMember = dataSource.Columns[0].ColumnName;
                cboFesUpDate.DisplayMember = dataSource.Columns[1].ColumnName;
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

        private void LoadComboxFinishedDate()
        {
            try
            {
                DataTable dataSource = commonBusiness.GetDataComboxOrchFinishedDate();

                cboCreateDone.DataSource = dataSource;
                cboCreateDone.ValueMember = dataSource.Columns[0].ColumnName;
                cboCreateDone.DisplayMember = dataSource.Columns[1].ColumnName;
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

        private void LoadComboxFesServicePublicDate()
        {
            try
            {
                DataTable dataSource = commonBusiness.GetDataComboxFesServicePublicDate();

                cboFesServicePublicDate.DataSource = dataSource;
                cboFesServicePublicDate.ValueMember = dataSource.Columns[0].ColumnName;
                cboFesServicePublicDate.DisplayMember = dataSource.Columns[1].ColumnName;
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

        private void LoadComboxFesCancelFlag()
        {
            try
            {
                DataTable dataSource = commonBusiness.GetComboxFesCancelFlag();

                cboFesCancelFlag.DataSource = dataSource;
                cboFesCancelFlag.ValueMember = dataSource.Columns[0].ColumnName;
                cboFesCancelFlag.DisplayMember = dataSource.Columns[0].ColumnName;
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

        private void LoadComboxFesPaidContentFlag()
        {
            try
            {
                DataTable dataSource = commonBusiness.GetComboxFesPaidContentFlag();

                cboFesPaidContentFlag.DataSource = dataSource;
                cboFesPaidContentFlag.ValueMember = dataSource.Columns[0].ColumnName;
                cboFesPaidContentFlag.DisplayMember = dataSource.Columns[1].ColumnName;
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

        private void LoadComboxFesChapterFlag()
        {
            try
            {
                DataTable dataSource = commonBusiness.GetComboxFesChapterFlag();

                cboFesChapterFlag.DataSource = dataSource;
                cboFesChapterFlag.ValueMember = dataSource.Columns[0].ColumnName;
                cboFesChapterFlag.DisplayMember = dataSource.Columns[1].ColumnName;
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

        private void LoadComboxSupportLevel()
        {
            try
            {
                DataTable dataSource = commonBusiness.GetComboxSupportLevel();

                cboSupportLevel.DataSource = dataSource;
                cboSupportLevel.ValueMember = dataSource.Columns[0].ColumnName;
                cboSupportLevel.DisplayMember = dataSource.Columns[1].ColumnName;
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

        private void LoadComboxOrchServicePublic()
        {
            try
            {
                DataTable dataSource = commonBusiness.GetComboxOrchServicePublic();

                cboOrchServicePublic.DataSource = dataSource;
                cboOrchServicePublic.ValueMember = dataSource.Columns[0].ColumnName;
                cboOrchServicePublic.DisplayMember = dataSource.Columns[1].ColumnName;
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

        private void LoadComboxOrchCancelFlag()
        {
            try
            {
                DataTable dataSource = commonBusiness.GetComboxOrchCancelFlag();

                cboOrchCancelFlag.DataSource = dataSource;
                cboOrchCancelFlag.ValueMember = dataSource.Columns[0].ColumnName;
                cboOrchCancelFlag.DisplayMember = dataSource.Columns[1].ColumnName;
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

        private void LoadComboxRegisteredConditions()
        {
            try
            {
                DataTable dataSource = commonBusiness.GetComboxRegisteredConditions(Properties.Settings.Default.FES_CONENT_COMBOX_DATA_登録済み条件_検索条件);

                cboRegisteredConditions.DataSource = dataSource;
                cboRegisteredConditions.ValueMember = dataSource.Columns[0].ColumnName;
                cboRegisteredConditions.DisplayMember = dataSource.Columns[1].ColumnName;
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
            bgwProcess.RunWorkerCompleted += BgwProcess_RunWorkerCompleted;
            bgwProcess.DoWork += BgwProcess_DoWork;
            bgwProcess.RunWorkerAsync();
            this.ShowWating();
        }

        private void BgwProcess_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                // Execute query
                festivalContentBusiness.ExecuteSearch(SlqParameters);
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

        private void BgwProcess_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (IsActive)
                this.Hide();

            if (bgwProcess != null)
            {
                bgwProcess.RunWorkerCompleted -= BgwProcess_RunWorkerCompleted;
                bgwProcess.DoWork -= BgwProcess_DoWork;
                bgwProcess.Dispose();
            }
            bgwProcess = null;
            GC.Collect();
            this.ClosedWaiting();
        }

        private void GetParamterAll()
        {
            if (SlqParameters == null)
                SlqParameters = new List<string>();
            SlqParameters.Clear();

            Invoke(new Action(() =>
            {
                //1.デジドコNo
                GetParameterTextBoxNumber("[Wii(デジドコ)選曲番号]", txtSongNumberFrom, txtSongNumberTo);
                //2.カラオケNo
                GetParameterTextBoxNumber("[カラオケ選曲番号]", txtKaraokeSongNumberFrom, txtKaraokeSongNumberTo);
                //3.曲名(MARY)
                GetParameterTextBox("[楽曲名]", txtMelodyName);
                //4.曲名補止
                GetParameterTextBox("[曲名補正]", txtMelodyNameStop);
                //5.曲名カナ
                GetParameterTextBox("[楽曲名検索用カナ]", txtMelodyNameKana);
                //6.曲名カナ補止
                GetParameterTextBox("[曲名よみがな補正]", txtMelodyNameStopKana);
                //7.歌手名
                GetParameterTextBox("[歌手名]", txtSingerName);
                //8.歌手名カナ
                GetParameterTextBox("[歌手名検索用カナ]", txtSingerNameKana);
                //9.Fes_アップ予定日
                GetParameterComboxWithDateTime("[アップ予定日]", cboFesUpDate, dtFesUpDateFrom, dtFesUpDateTo, "yyyyMMdd");
                //10.Orch_制作完了日
                GetParameterComboxWithDateTime("[Wii_U_制作完了日]", cboCreateDone, dtCreateDoneFrom, dtCreateDoneTo, "yyyyMMdd");
                //11.Fes_サービス発表日
                GetParameterComboxWithDateTime("[サービス発表日]", cboFesServicePublicDate, dtFesServicePublicDateFrom, dtFesServicePublicDateTo, "yyyyMMdd");
                //12.Fes_取消フラグ
                GetParameterFromCombox("[取消フラグ]", cboFesCancelFlag);
                //13.Fes_停止日
                GetParameterComboxWithDateTime("[停止日]", null, dtFesStopDateFrom, dtFesStopDateTo, "yyyyMMdd");
                //14.Fes_有料コンテンツフラグ
                GetParameterFromCombox("[有料コンテンツフラグ]", cboFesPaidContentFlag);
                //15.Fes_チャプターフラグ
                GetParameterFromCombox("[チャプターフラグ]", cboFesChapterFlag, false);
                // 16.新譜本扱月
                GetParameterComboxWithDateTime("[新譜本扱月]", null, dtNewSongHandlingMonthFrom, dtNewSongHandlingMonthTo, "yyyyMM");
                //17.支援レベル
                GetParameterFromCombox("[支援レベル]", cboSupportLevel);
                //18.Fesアレンジコード（補止）
                GetParameterTextBox("[Fesアレンジコード]", txtFesArrangeCodeStop);
                //19.発表日
                GetParameterComboxWithDateTime("[発売日]", null, dtPublicDateFrom, dtPublicDateTo, "yyyyMMdd");
                //20.歌唱可能日
                GetParameterComboxWithDateTime("[歌唱可能日]", null, dtSingAvaibleDateFrom, dtSingAvaibleDateTo, "yyyyMMdd");
                // 21.カラオケ完パケ期限日
                GetParameterComboxWithDateTime("[カラオケ完パケ期限日]", null, dtKaraokeCompletePackageDeadlineFrom, dtKaraokeCompletePackageDeadlineTo, "yyyyMMdd");
                //22.Orch_サービス発表日
                GetParameterComboxWithDateTime("[Wii_U_サービス発表日]", cboOrchServicePublic, dtOrchServicePublicDateFrom, dtOrchServicePublicDateTo, "yyyyMMdd");
                //23.Orch_取消フラグ
                GetParameterFromCombox("[Wii_U_取消フラグ]", cboOrchCancelFlag);
                // 24.Orch_停止日
                GetParameterComboxWithDateTime("[Wii_U_停止日]", null, dtOrchStopDateFrom, dtOrchStopDateTo, "yyyyMMdd");
                //25.備考
                GetParameterTextBox("[備考]", txtRemarks);
                //26.著作権備考
                GetParameterTextBox("[著作権備考]", txtCopyrightRemarks);
                //27.登録日時 
                GetParameterComboxWithDateTime("[登録日時]", null, dtRegisteredDateFrom, dtRegisteredDateTo, "yyyyMMdd");
                //28.配信マーク
                GetParameterTextBox("[配信マーク]", txtDeliveryMark);
                //29.登録済み条件
                GetParameterFromCombox(null, cboRegisteredConditions);
            }));
        }

        private void GetParameterComboxWithDateTime(string columnCondition, ComboBoxEx combCheck, MaskedTextBoxAdv dtFrom, MaskedTextBoxAdv dtTo, string format = "")
        {
            GetParameterUtils.GetParameterComboxWithDateTime(SlqParameters, columnCondition, combCheck, dtFrom, dtTo, format);
        }

        private void GetParameterFromCombox(string columnName, ComboBoxEx cboCheck, bool IsGetValue = true)
        {
            GetParameterUtils.GetParameterFromCombox(SlqParameters, columnName, cboCheck, IsGetValue);
        }

        private void GetParameterTextBox(string columnName, TextBoxX textBox)
        {
            GetParameterUtils.GetParameterTextBox(SlqParameters, columnName, textBox, radMatchingAll, radFrontMatch, radPartialMatch, radExclude);
        }

        private void GetParameterTextBoxNumber(string columnName, TextBoxX textNumberFrom, TextBoxX textNumberTo)
        {
            GetParameterUtils.GetParameterTextBoxNumber(SlqParameters, columnName, textNumberFrom, textNumberTo);
        }

        private bool Valid()
        {
            if (!CheckCompareNumberInput(lblデジドコNo.Text, Constants.MSGE006, txtSongNumberFrom, txtSongNumberTo))
            {
                return false;
            }
            if (!CheckCompareNumberInput(lblカラオケNo.Text, Constants.MSGE006, txtKaraokeSongNumberFrom, txtKaraokeSongNumberTo))
            {
                return false;
            }

            if (!CheckDateTimeInput(lblFes_アップ予定日.Text, Constants.MSGE016, cboFesUpDate, dtFesUpDateFrom, dtFesUpDateTo))
            {
                return false;
            }
            if (!CheckDateTimeInput(lblOrch_制作完了日.Text, Constants.MSGE016, cboCreateDone, dtCreateDoneFrom, dtCreateDoneTo))
            {
                return false;
            }
            if (!CheckDateTimeInput(lblFes_サービス発表日.Text, Constants.MSGE016, cboFesServicePublicDate, dtFesServicePublicDateFrom, dtFesServicePublicDateTo))
            {
                return false;
            }
            if (!CheckDateTimeInput(lblFes_停止日.Text, Constants.MSGE016, null, dtFesStopDateFrom, dtFesStopDateTo))
            {
                return false;
            }

            if (!CheckDateTimeInput(lbl新譜本扱月.Text, Constants.MSGE016, null, dtNewSongHandlingMonthFrom, dtNewSongHandlingMonthTo))
            {
                return false;
            }
            if (!CheckDateTimeInput(lbl発表日.Text, Constants.MSGE016, null, dtPublicDateFrom, dtPublicDateTo))
            {
                return false;
            }
            if (!CheckDateTimeInput(lbl歌唱可能日.Text, Constants.MSGE016, null, dtSingAvaibleDateFrom, dtSingAvaibleDateTo))
            {
                return false;
            }
            if (!CheckDateTimeInput(lblカラオケ完パケ期限日.Text, Constants.MSGE016, null, dtKaraokeCompletePackageDeadlineFrom, dtKaraokeCompletePackageDeadlineTo))
            {
                return false;
            }
            if (!CheckDateTimeInput(lblOrch_サービス発表日.Text, Constants.MSGE016, cboOrchServicePublic, dtOrchServicePublicDateFrom, dtOrchServicePublicDateTo))
            {
                return false;
            }
            if (!CheckDateTimeInput(lblOrch_停止日.Text, Constants.MSGE016, null, dtOrchStopDateFrom, dtOrchStopDateTo))
            {
                return false;
            }
            if (!CheckDateTimeInput(lbl登録日時.Text, Constants.MSGE016, null, dtRegisteredDateFrom, dtRegisteredDateTo))
            {
                return false;
            }
            return true;
        }

        private void languageChange(object sender, InputLanguageChangedEventArgs e)
        {
            TextBoxX textBox = sender as TextBoxX;
            if (textBox == null)
                return;

            // If the input language is Japanese.
            // set the initial IMEMode to Katakana.
            if (e.InputLanguage.Culture.TwoLetterISOLanguageName.Equals("ja"))
            {
                textBox.ImeMode = ImeMode.Katakana;
            }
        }

        private void btnInputSongSelectedNumber_Click(object sender, EventArgs e)
        {
            if (!btnInputSongSelectedNumber.Enabled)
                return;
            IsActive = false;
            this.Hide();

            InputSongNumber inputSongNumber = new InputSongNumber(Constants.TitleInputSongSelectedNumberText, this.CurrentLayOut);
            inputSongNumber.ShowDialog();

            if (inputSongNumber.IsActive)
            {
                IsActive = true;
                // Reset active
                inputSongNumber.IsActive = false;
            }
        }

        private void bntInputSongSelectedNumerKaraoke_Click(object sender, EventArgs e)
        {
            if (!bntInputSongSelectedNumerKaraoke.Enabled)
                return;
            IsActive = false;
            this.Hide();
            InputSongNumber inputSongNumber = new InputSongNumber(Constants.TitleInputSongSelectedNumberKaraokeText, this.CurrentLayOut);
            inputSongNumber.ShowDialog();
            if (inputSongNumber.IsActive)
            {
                IsActive = true;
            }
        }


        private void btnFileVerification_Click(object sender, EventArgs e)
        {
            if (!btnFileVerification.Enabled)
                return;

            IsActive = false;

            this.Hide();
            InputFileSearchingCondition fileVerification = new InputFileSearchingCondition(Constants.TitleInputFileMatchingScreenText, this.CurrentLayOut);
            fileVerification.ShowDialog();
            // Search main
            if (fileVerification.IsActive)
            {
                IsActive = true;
                // Reset active
                fileVerification.IsActive = false;
            }
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            Search();
        }

        private void btnOpenFile_Click(object sender, System.EventArgs e)
        {
            if (!btnOpenFile.Enabled)
                return;
            IsActive = false;
            this.Hide();
            InputFileSearchingCondition fileVerification = new InputFileSearchingCondition(Constants.TitleInputFileMatchingKaraokeScreenText, this.CurrentLayOut);
            fileVerification.ShowDialog();

            // Search main
            if (fileVerification.IsActive)
            {
                IsActive = true;
                // Reset active
                fileVerification.IsActive = false;
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F3)
            {
                btnFileVerification_Click(null, null);
            }
            else if (keyData == Keys.F4)
            {
                btnOpenFile_Click(null, null);
            }
            else if (keyData == (Keys.F5))
            {
                btnSearch_Click(null, null);
            }
            else if (keyData == Keys.F12)
            {
                btnInputSongSelectedNumber_Click(null, null);
            }
            else if (keyData == (Keys.Shift | Keys.F12))
            {
                bntInputSongSelectedNumerKaraoke_Click(null, null);
            }
            else if (keyData == (Keys.Alt | Keys.C))
            {
                btnClear_Click(null, null);
            }
            else if (keyData == (Keys.Control | Keys.D))
            {
                SetDateValue();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SetDateValue()
        {
            foreach (Control ctrl in pannelMain.Controls)
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

        private void MenuIPTVSearchingCondition_Load(object sender, System.EventArgs e)
        {
            LoadInitLayout();
            LoadData();
        }

        private void LoadInitLayout()
        {
            System.Drawing.Size screenSize = Screen.PrimaryScreen.Bounds.Size;
            if (pannelMain.Width > screenSize.Width)
            {
                this.Width = screenSize.Width;
                this.AutoScroll = true;
            }
            if (pannelMain.Height > screenSize.Height)
            {
                this.Height = screenSize.Height;
                this.AutoScroll = true;
            }

            lblShortCutDateTime.Location = new System.Drawing.Point(pannelMain.Location.X, pannelMain.Location.Y + pannelMain.Height + 5);
            panelButton.Location = new System.Drawing.Point(pannelMain.Width - panelButton.Width + 15, pannelMain.Height + panelButton.Height + 15);
        }

        private void LoadData()
        {
            if (commonBusiness != null)
                return;
            commonBusiness = new CommonBusiness();
            txtSongNumberFrom.Select();
            LoadTabIndex();
            InitCombox();
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            ClearData();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.IsActive = false;
            this.Close();
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

        private void ActiveDatetimeInput(ComboBoxEx combox, MaskedTextBoxAdv dtFrom, MaskedTextBoxAdv dtTo)
        {
            GetParameterUtils.ActiveDatetimeInput(combox, dtFrom, dtTo);
        }

        private bool CheckDateTimeInput(string lableName, string messageCode, ComboBoxEx combox, MaskedTextBoxAdv dtFrom, MaskedTextBoxAdv dtTo)
        {
            return GetParameterUtils.CheckDateTimeInput(lableName, messageCode, combox, dtFrom, dtTo);
        }


        public bool CheckCompareNumberInput(string lableName, string messageCode, TextBoxX textBox1, TextBoxX textBox2)
        {
            return GetParameterUtils.CheckCompareNumberInput(lableName, messageCode, textBox1, textBox2);
        }

        private void ClearData()
        {
            foreach (Control ctrl in pannelMain.Controls)
            {
                TextBoxX txtBox = ctrl as TextBoxX;
                if (txtBox != null)
                    txtBox.Text = string.Empty;

                MaskedTextBoxAdv dtInput = ctrl as MaskedTextBoxAdv;
                if (dtInput != null)
                {
                    dtInput.Text = string.Empty;
                }

                ComboBoxEx cboX = ctrl as ComboBoxEx;
                if (cboX != null)
                {
                    cboX.SelectedIndex = -1;
                }
            }
            radPartialMatch.Checked = true;
            btnInputSongSelectedNumber.Select();
        }

        private void LoadTabIndex()
        {
            btnFileVerification.TabIndex = (int)ControlTabIndex.btnFileVerification;
            btnInputSongSelectedNumber.TabIndex = (int)ControlTabIndex.btnSongNumber;
            btnOpenFile.TabIndex = (int)ControlTabIndex.btnOpenFile;
            bntInputSongSelectedNumerKaraoke.TabIndex = (int)ControlTabIndex.bntInputSongNumer;
            txtSongNumberFrom.TabIndex = (int)ControlTabIndex.txtSongNumberFrom;
            txtSongNumberTo.TabIndex = (int)ControlTabIndex.txtSongNumberTo;
            txtKaraokeSongNumberFrom.TabIndex = (int)ControlTabIndex.txtKaraokeSongNumberFrom;
            txtKaraokeSongNumberTo.TabIndex = (int)ControlTabIndex.txtKaraokeSongNumberTo;
            txtMelodyName.TabIndex = (int)ControlTabIndex.txtMelodyName;
            txtMelodyNameStop.TabIndex = (int)ControlTabIndex.txtMelodyNameStop;
            txtMelodyNameKana.TabIndex = (int)ControlTabIndex.txtMelodyNameKana;
            txtMelodyNameStopKana.TabIndex = (int)ControlTabIndex.txtMelodyNameStopKana;
            txtSingerName.TabIndex = (int)ControlTabIndex.txtSingerName;
            txtSingerNameKana.TabIndex = (int)ControlTabIndex.txtSingerNameKana;
            cboFesUpDate.TabIndex = (int)ControlTabIndex.cboFesUpDate;
            dtFesUpDateFrom.TabIndex = (int)ControlTabIndex.dtFesUpDateFrom;
            dtFesUpDateTo.TabIndex = (int)ControlTabIndex.dtFesUpDateTo;
            cboCreateDone.TabIndex = (int)ControlTabIndex.cboCreateDone;
            dtCreateDoneFrom.TabIndex = (int)ControlTabIndex.dtCreateDoneFrom;
            dtCreateDoneTo.TabIndex = (int)ControlTabIndex.dtCreateDoneTo;
            dtFesServicePublicDateFrom.TabIndex = (int)ControlTabIndex.dtFesServicePublicDateFrom;
            cboFesServicePublicDate.TabIndex = (int)ControlTabIndex.cboFesServicePublicDate;
            dtFesServicePublicDateTo.TabIndex = (int)ControlTabIndex.dtFesServicePublicDateTo;
            cboFesCancelFlag.TabIndex = (int)ControlTabIndex.cboFesCancelFlag;
            dtFesStopDateFrom.TabIndex = (int)ControlTabIndex.dtFesStopDateFrom;
            dtFesStopDateTo.TabIndex = (int)ControlTabIndex.dtFesStopDateTo;
            cboFesPaidContentFlag.TabIndex = (int)ControlTabIndex.cboFesPaidContentFlag;
            cboFesChapterFlag.TabIndex = (int)ControlTabIndex.cboFesChapterFlag;
            dtNewSongHandlingMonthFrom.TabIndex = (int)ControlTabIndex.dtNewSongHandlingMonthFrom;
            dtNewSongHandlingMonthTo.TabIndex = (int)ControlTabIndex.dtNewSongHandlingMonthTo;
            cboSupportLevel.TabIndex = (int)ControlTabIndex.cboSupportLevel;
            txtFesArrangeCodeStop.TabIndex = (int)ControlTabIndex.txtFesArrangeCodeStop;
            dtPublicDateFrom.TabIndex = (int)ControlTabIndex.dtPublicDateFrom;
            dtPublicDateTo.TabIndex = (int)ControlTabIndex.dtPublicDateTo;
            dtSingAvaibleDateFrom.TabIndex = (int)ControlTabIndex.dtSingAvaibleDateFrom;
            dtSingAvaibleDateTo.TabIndex = (int)ControlTabIndex.dtSingAvaibleDateTo;
            dtKaraokeCompletePackageDeadlineFrom.TabIndex = (int)ControlTabIndex.dtKaraokeCompletePackageDeadlineFrom;
            dtKaraokeCompletePackageDeadlineTo.TabIndex = (int)ControlTabIndex.dtKaraokeCompletePackageDeadlineTo;
            cboOrchServicePublic.TabIndex = (int)ControlTabIndex.cboOrchServicePublic;
            dtOrchServicePublicDateFrom.TabIndex = (int)ControlTabIndex.dtOrchServicePublicDateFrom;
            dtOrchServicePublicDateTo.TabIndex = (int)ControlTabIndex.dtOrchServicePublicDateTo;
            cboOrchCancelFlag.TabIndex = (int)ControlTabIndex.cboOrchCancelFlag;
            dtOrchStopDateFrom.TabIndex = (int)ControlTabIndex.dtOrchStopDateFrom;
            dtOrchStopDateTo.TabIndex = (int)ControlTabIndex.dtOrchStopDateTo;
            txtRemarks.TabIndex = (int)ControlTabIndex.txtRemarks;
            txtCopyrightRemarks.TabIndex = (int)ControlTabIndex.txtCopyrightRemarks;
            dtRegisteredDateFrom.TabIndex = (int)ControlTabIndex.dtRegisteredDateFrom;
            dtRegisteredDateTo.TabIndex = (int)ControlTabIndex.dtRegisteredDateTo;
            txtDeliveryMark.TabIndex = (int)ControlTabIndex.txtDeliveryMark;
            cboRegisteredConditions.TabIndex = (int)ControlTabIndex.cboRegisteredConditions;
            groupBox1.TabIndex = (int)ControlTabIndex.groupBox1;
            radMatchingAll.TabIndex = (int)ControlTabIndex.radMatchingAll;
            radFrontMatch.TabIndex = (int)ControlTabIndex.radFrontMatch;
            radPartialMatch.TabIndex = (int)ControlTabIndex.radPartialMatch;
            radExclude.TabIndex = (int)ControlTabIndex.radExclude;
            btnClear.TabIndex = (int)ControlTabIndex.btnClear;
            btnSearch.TabIndex = (int)ControlTabIndex.btnSearch;
            btnClose.TabIndex = (int)ControlTabIndex.btnClose;
            pannelMain.TabIndex = (int)ControlTabIndex.grpSearchingCondition;
        }

        private enum ControlTabIndex
        {
            txtSongNumberFrom,
            txtSongNumberTo,
            txtKaraokeSongNumberFrom,
            txtKaraokeSongNumberTo,
            txtMelodyName,
            txtMelodyNameStop,
            txtMelodyNameKana,
            txtMelodyNameStopKana,
            txtSingerName,
            txtSingerNameKana,
            cboFesUpDate,
            dtFesUpDateFrom,
            dtFesUpDateTo,
            cboCreateDone,
            dtCreateDoneFrom,
            dtCreateDoneTo,
            cboFesServicePublicDate,
            dtFesServicePublicDateFrom,
            dtFesServicePublicDateTo,
            cboFesCancelFlag,
            dtFesStopDateFrom,
            dtFesStopDateTo,
            cboFesPaidContentFlag,
            cboFesChapterFlag,
            dtNewSongHandlingMonthFrom,
            dtNewSongHandlingMonthTo,
            cboSupportLevel,
            txtFesArrangeCodeStop,
            dtPublicDateFrom,
            dtPublicDateTo,
            dtSingAvaibleDateFrom,
            dtSingAvaibleDateTo,
            dtKaraokeCompletePackageDeadlineFrom,
            dtKaraokeCompletePackageDeadlineTo,
            cboOrchServicePublic,
            dtOrchServicePublicDateFrom,
            dtOrchServicePublicDateTo,
            cboOrchCancelFlag,
            dtOrchStopDateFrom,
            dtOrchStopDateTo,
            txtRemarks,
            txtCopyrightRemarks,
            dtRegisteredDateFrom,
            dtRegisteredDateTo,
            txtDeliveryMark,
            cboRegisteredConditions,
            groupBox1,
            radMatchingAll,
            radFrontMatch,
            radPartialMatch,
            radExclude,
            grpSearchingCondition,
            btnClear,
            btnSearch,
            btnClose,
            btnFileVerification,
            btnOpenFile,
            btnSongNumber,
            bntInputSongNumer
        }

        private void cboFesUpDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveDatetimeInput(cboFesUpDate, dtFesUpDateFrom, dtFesUpDateTo);
        }

        private void cboCreateDone_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveDatetimeInput(cboCreateDone, dtCreateDoneFrom, dtCreateDoneTo);
        }

        private void cboFesServicePublicDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveDatetimeInput(cboFesServicePublicDate, dtFesServicePublicDateFrom, dtFesServicePublicDateTo);
        }

        private void cboOrchServicePublic_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveDatetimeInput(cboOrchServicePublic, dtOrchServicePublicDateFrom, dtOrchServicePublicDateTo);
        }

        private void RemoveWaterMask()
        {
            foreach (Control ctrl in pannelMain.Controls)
            {
                TextBoxX txt = ctrl as TextBoxX;
                if (txt != null)
                {
                    txt.WatermarkText = string.Empty;
                    continue;
                }

                ComboBoxEx cbo = ctrl as ComboBoxEx;
                if (cbo != null)
                {
                    cbo.WatermarkText = string.Empty;
                    continue;
                }

                DateTimeInput dtinput = ctrl as DateTimeInput;
                if (dtinput != null)
                {
                    dtinput.WatermarkText = string.Empty;
                    continue;
                }
            }
        }

    }
}
