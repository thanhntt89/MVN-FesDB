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

namespace Festival.DiscVideoTab.FesVideoAssigment
{
    public partial class FesVideoAssigmentSearch : FormBase
    {
        private FesVideoAssigmentBusiness videosAssigmentBusines;

        // List parameter
        public List<string> SlqParameters { get; set; }
        private IList<string> festaVideo = null;

        public FesVideoAssigmentSearch(LayOutEntity layOutEntity)
        {
            InitializeComponent();

            CurrentLayOut = layOutEntity;
            if (videosAssigmentBusines == null)
                videosAssigmentBusines = new FesVideoAssigmentBusiness();

            LoadControlIndex();
            LoadInitCombox();
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

        private void LoadInitCombox()
        {
            try
            {
                DataTable dataSource = videosAssigmentBusines.GetRegisteredConditionData(Properties.Settings.Default.FES_VIDEO_ASSIGMENT_SEARCH_検索条件);

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
            }

            cboRegisteredCondition.SelectedIndex = 0;
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
                var rst = MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGI011), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Information);

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
                videosAssigmentBusines.TruncateVideoAssigmentWorkTmp();

                // Insert festavideo              
                videosAssigmentBusines.InsertFestaVideoLock(festaVideo);

                // Search
                videosAssigmentBusines.ExecuteSearch(SlqParameters);

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
            if (!CheckCompareNumberInput(Constants.MSGE006, txtDigiDocoNoFrom, txtDigiDocoNoTo))
            {
                return false;
            }
            if (!CheckCompareNumberInput(Constants.MSGE006, txtKaraokeNoFrom, txtKaraokeNoTo))
            {
                return false;
            }
            if (!CheckDateTimeInput(lblFes_アップ予定日.Text, Constants.MSGE016, null, dtUpdateDateFrom, dtUpdateDateTo))
            {
                return false;
            }
            if (!CheckDateTimeInput(lblFes_サービス発表日.Text, Constants.MSGE016, null, dtServiceDateFrom, dtServiceDateTo))
            {
                return false;
            }

            //Get Festavideo
            festaVideo = Utils.GetDataFromFileToList(Properties.Settings.Default.FES_PEREMIUM_CONTENT_VIDEO_LOCKED_PATH, ',');

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
                //8.背景映像コード
                GetParameterTextBoxText("[背景映像コード]", txtVideoCodeFrom, txtVideoCodeTo);
                //9. Fes_アップ予定日
                GetParameterComboxWithDateTime("[アップ予定日]", null, dtUpdateDateFrom, dtUpdateDateTo, "yyyyMMdd");
                //10. Fes_サービス発表日
                GetParameterComboxWithDateTime("[サービス発表日]", null, dtServiceDateFrom, dtServiceDateTo, "yyyyMMdd");
                //11. 登録済み条件
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

        public bool CheckCompareNumberInput(string messageCode, TextBoxX textBox1, TextBoxX textBox2)
        {
            int value1 = -1;
            int value2 = -1;
            int.TryParse(textBox1.Text, out value1);
            int.TryParse(textBox2.Text, out value2);

            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && value1 > value2)
            {
                MessageBox.Show(GetResources.GetResourceMesssage(messageCode), Constants.ERROR_TITLE_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return false;
            }
            return true;
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

        private void GetParameterTextBoxText(string columnName, TextBoxX textNumberFrom, TextBoxX textNumberTo)
        {
            GetParameterUtils.GetParameterTextBoxText(SlqParameters, columnName, textNumberFrom, textNumberTo);
        }

        private void LoadControlIndex()
        {
            btnDigiDokoNoInput.TabIndex = (int)TabIndexs.btnDigiDokoNoInput;
            btnKaraokeNoInput.TabIndex = (int)TabIndexs.btnKaraokeNoInput;
            btnVideoCodeInput.TabIndex = (int)TabIndexs.btnVideoCodeInput;
            txtDigiDocoNoFrom.TabIndex = (int)TabIndexs.txtDigiDocoNoFrom;
            txtDigiDocoNoTo.TabIndex = (int)TabIndexs.txtDigiDocoNoTo;
            txtKaraokeNoFrom.TabIndex = (int)TabIndexs.txtKaraokeNoFrom;
            txtKaraokeNoTo.TabIndex = (int)TabIndexs.txtKaraokeNoTo;
            txtSongName.TabIndex = (int)TabIndexs.txtSongName;
            txtSongNamKana.TabIndex = (int)TabIndexs.txtSongNamKana;
            txtSongNameTitleKanaCorrection.TabIndex = (int)TabIndexs.txtSongNameTitleKanaCorrection;
            txtSingerName.TabIndex = (int)TabIndexs.txtSingerName;
            txtSingerNameKana.TabIndex = (int)TabIndexs.txtSingerNameKana;
            txtVideoCodeFrom.TabIndex = (int)TabIndexs.txtVideoCodeFrom;
            txtVideoCodeTo.TabIndex = (int)TabIndexs.txtVideoCodeTo;
            dtUpdateDateFrom.TabIndex = (int)TabIndexs.dtUpdateDateFrom;
            dtUpdateDateTo.TabIndex = (int)TabIndexs.dtUpdateDateTo;
            dtServiceDateFrom.TabIndex = (int)TabIndexs.dtServiceDateFrom;
            dtServiceDateTo.TabIndex = (int)TabIndexs.dtServiceDateTo;
            cboRegisteredCondition.TabIndex = (int)TabIndexs.cboRegisteredCondition;
            radMatchingAll.TabIndex = (int)TabIndexs.radMatchingAll;
            radFrontMatch.TabIndex = (int)TabIndexs.radFrontMatch;
            radPartialMatch.TabIndex = (int)TabIndexs.radPartialMatch;
            radExclude.TabIndex = (int)TabIndexs.radExclude;
            btnClear.TabIndex = (int)TabIndexs.btnClear;
            btnSearch.TabIndex = (int)TabIndexs.btnSearch;
            btnClose.TabIndex = (int)TabIndexs.btnClose;
            grpSearchingCondition.TabIndex = (int)TabIndexs.groupBox2;
        }

        private enum TabIndexs
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
            txtVideoCodeFrom,
            txtVideoCodeTo,
            dtUpdateDateFrom,
            dtUpdateDateTo,
            dtServiceDateFrom,
            dtServiceDateTo,
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
            if (keyData == Keys.F12)
            {
                btnDigiDokoNoInput_Click(null, null);
            }
            if (keyData == (Keys.Shift | Keys.F12))
            {
                btnKaraokeNoInput_Click(null, null);
            }
            if (keyData == (Keys.Shift | Keys.F11))
            {
                btnVideoCodeInput_Click(null, null);
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
            FesVideoAssigmentInputSongNumber fesVideoAssigmentInputSongNumber = new FesVideoAssigmentInputSongNumber(functioName);
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
            if (!btnDigiDokoNoInput.Enabled)
                return;
            OpenInputSongNumber(EnumInputTypeName.選曲番号入力);
        }

        private void btnKaraokeNoInput_Click(object sender, EventArgs e)
        {
            if (!btnKaraokeNoInput.Enabled)
                return;
            OpenInputSongNumber(EnumInputTypeName.選曲番号入力カラオケ);
        }

        private void btnVideoCodeInput_Click(object sender, EventArgs e)
        {
            if (!btnVideoCodeInput.Enabled)
                return;
            OpenInputSongNumber(EnumInputTypeName.背景映像コード入力);
        }
    }
}
