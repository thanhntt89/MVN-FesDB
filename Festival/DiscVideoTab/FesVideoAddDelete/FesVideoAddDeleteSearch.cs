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

namespace Festival.DiscVideoTab.FesVideoAddDelete
{
    public partial class FesVideoAddDeleteSearch : FormBase
    {
        private FesVideoAddDeleteBusiness videoDiscManagementBusiness;

        // List parameter
        public List<string> SlqParameters { get; set; }

        public FesVideoAddDeleteSearch(LayOutEntity layOutEntity)
        {
            InitializeComponent();

            CurrentLayOut = layOutEntity;
            if (videoDiscManagementBusiness == null)
                videoDiscManagementBusiness = new FesVideoAddDeleteBusiness();

            LoadInitCombox();
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
                if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.FES_VIDEOS_MANAGERMENT_検索条件))
                {
                    DataTable dataSource = videoDiscManagementBusiness.GetRegisteredConditionData(Properties.Settings.Default.FES_VIDEOS_MANAGERMENT_検索条件);

                    cboRegisteredCondition.DataSource = dataSource;
                    cboRegisteredCondition.ValueMember = dataSource.Columns[0].ColumnName;
                    cboRegisteredCondition.DisplayMember = dataSource.Columns[1].ColumnName;
                }

                DataTable dtAdditionalDeleteCategory = videoDiscManagementBusiness.GetAddtinalDeleteCategory();
                cbo追加削除区分.DataSource = dtAdditionalDeleteCategory;
                cbo追加削除区分.ValueMember = dtAdditionalDeleteCategory.Columns[0].ColumnName;
                cbo追加削除区分.DisplayMember = dtAdditionalDeleteCategory.Columns[1].ColumnName;
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
                    cbo.SelectedIndex = -1;
                }
            }
            chkIncludeInitData.Checked = false;
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
                videoDiscManagementBusiness.TruncateVideoDiscManagementWorkTmp();

                // Search
                videoDiscManagementBusiness.ExecuteSearch(SlqParameters);

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
            if (!CheckCompareNumberInput(lblFes_DISCID.Text, Constants.MSGE006, txtFes_DISCIDFrom, txtFes_DISCIDTo))
            {
                return false;
            }
            if (!CheckDateTimeInput(lbl登録日.Text, Constants.MSGE016, null, dtRegisterDateFrom, dtRegisterDateTo))
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
                //1.背景ファイル名
                GetParameterTextBox("[背景ファイル名]", txtFileName);
                //2.登録済み条件
                GetParameterFromCombox("[追加削除区分]", cbo追加削除区分);
                //3.Fes_DISCID
                GetParameterTextBoxNumber("[FesDISCID]", txtFes_DISCIDFrom, txtFes_DISCIDTo);
                //4.登録日
                GetParameterComboxWithDateTime("[登録日]", null, dtRegisterDateFrom, dtRegisterDateTo, "yyyyMMdd");
                //5. 初動データを含む
                GetParameterCheckBox("[未出力フラグ]", "0", chkIncludeInitData);
                //6.初動データを含む
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

        public bool CheckCompareNumberInput(string lableName, string messageCode, TextBoxX textBox1, TextBoxX textBox2)
        {
            return GetParameterUtils.CheckCompareNumberInput(lableName, messageCode, textBox1, textBox2);
        }

        private void GetParameterFromCombox(string columnName, ComboBoxEx cboCheck, bool IsGetValue = true)
        {
            GetParameterUtils.GetParameterFromCombox(SlqParameters, columnName, cboCheck, IsGetValue);
        }

        private void GetParameterCheckBox(string columnCondition, string checkedValue, CheckBoxX checkBox)
        {
            GetParameterUtils.GetParameterCheckBox(SlqParameters, columnCondition, checkedValue, checkBox);
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
                btnInputFile_Click(null, null);
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

        private void OpenInputSongNumber()
        {
            IsActive = false;
            this.Hide();
            FesVideoInputSongNumber fesVideoInputSongNumber = new FesVideoInputSongNumber(EnumInputTypeName.背景ファイル名入力, EnumInputNumberType.VideoNumber);
            fesVideoInputSongNumber.ShowDialog();
            if (fesVideoInputSongNumber.IsActive)
            {
                IsActive = true;
                // Reset active
                fesVideoInputSongNumber.IsActive = false;
            }
        }

        private void IndividualVideoDiscManagementSearch_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtFileName;
            txtFileName.Focus();
        }

        private void btnInputFile_Click(object sender, EventArgs e)
        {
            if (!btnInputFile.Enabled)
                return;
            OpenInputSongNumber();
        }
    }
}
