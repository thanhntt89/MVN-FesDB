using DevComponents.DotNetBar.Controls;
using Festival.Base;
using FestivalCommon;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Globalization;
using FestivalUtilities;

namespace Festival.Common
{
    public partial class CommonInput : FormBase
    {
        private CultureInfo lang = null;

        private DataGridViewCell currentCell;

        private Int64 MaxValueInput = 0;
        private int MinLength = 0;
        private bool isInputText = false;

        private bool isUpdateColumn = false;
        private bool IsFilterActive = false;

        private string currentColumnName = string.Empty;
        private ColumnEntity column = new ColumnEntity();

        public ColumnsCollection HiraganaColumns { get; set; }

        public ColumnsCollection KatakanaColumns { get; set; }
        public ColumnsCollection HankakuEiSuColumns { get; set; }

        public CommonInput(DataGridViewCell cell, bool IsUpdateColumn, bool isColumnFilter)
        {
            InitializeComponent();
            currentCell = cell;
            this.isUpdateColumn = IsUpdateColumn;
            this.IsFilterActive = isColumnFilter;
            currentColumnName = cell.OwningColumn.DataPropertyName;
            if (!IsUpdateColumn)
            {
                this.Text = "セル編集";
            }
        }

        private void BulkBatchInPut_Load(object sender, System.EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            if (currentCell == null)
                return;
            lblShortCutKey.Visible = false;
            dtInput.Visible = false;
            txtInputText.Visible = false;
            cboStatus.Visible = false;
            btnClear.Visible = false;
            btnBlank.Visible = false;
            btnInput.Enabled = false;
            btnBlank.Enabled = false;
            btnClear.Enabled = false;

            lblColumName.Text = currentCell.OwningColumn.HeaderText;

            if (currentCell.GetType().Equals(typeof(DataGridViewTextBoxCell)))
            {
                TextBoxDisplay();
            }
            else if (currentCell.GetType().Equals(typeof(DataGridViewDateTimeInputCell)) ||
                currentCell.GetType().Equals(typeof(DataGridViewMaskedTextBoxAdvCell)))
            {
                DateTimeInputDisplay();
            }
            else if (currentCell.GetType().Equals(typeof(DataGridViewNumericCell)))
            {
                NumericDisplay();
            }
            else if (currentCell.GetType().Equals(typeof(DataGridViewCheckBoxXCell)) ||
                currentCell.GetType().Equals(typeof(DataGridViewCheckBoxCell)))
            {
                CheckBoxDisplay();
            }
        }

        private void CheckBoxDisplay()
        {
            cboStatus.Visible = true;
            cboStatus.Size = txtInputText.Size;
            cboStatus.Location = txtInputText.Location;
            btnInput.Enabled = true;
            btnInput.Location = btnClear.Location;
            btnInput.Visible = true;
        }

        private void NumericDisplay()
        {
            isInputText = true;
            txtInputText.MaxLength = ((DataGridViewNumericColumn)currentCell.OwningColumn).MaxInputLength;
            MinLength = ((DataGridViewNumericColumn)currentCell.OwningColumn).MinInputLength;
            // Get max value input
            MaxValueInput = ((DataGridViewNumericColumn)currentCell.OwningColumn).MaxValueInput;

            // Copy disable if input numeric
            if (MaxValueInput > 0)
            {
                txtInputText.KeyDown += TxtInputText_KeyDown;
                txtInputText.Enter += TxtInputText_Enter;
            }
            txtInputText.Text = currentCell.Value.ToString();

            // Active Event key numberic
            txtInputText.KeyPress += TxtInputText_KeyPress;

            txtInputText.Visible = true;
            btnClear.Visible = true;
            btnBlank.Visible = true;
            btnInput.Visible = true;

            btnInput.Enabled = true;
            btnBlank.Enabled = true;
            btnClear.Enabled = true;
            txtInputText.Focus();
        }

        private void TextBoxDisplay()
        {
            isInputText = true;
            txtInputText.MaxLength = ((DataGridViewTextBoxColumn)currentCell.OwningColumn).MaxInputLength;

            txtInputText.Text = currentCell.Value.ToString();

            txtInputText.Visible = true;
            btnClear.Visible = true;
            btnBlank.Visible = true;
            btnInput.Visible = true;

            btnInput.Enabled = true;
            btnBlank.Enabled = true;
            btnClear.Enabled = true;
            txtInputText.Focus();

            // Set activeImode textbox
            ActiveImode(currentColumnName);
          var columnEng = HankakuEiSuColumns.GetColumn(currentColumnName);
            if (columnEng != null)
            {
                if (columnEng.IsUpperCase)
                {
                    txtInputText.CharacterCasing = CharacterCasing.Upper;
                }
            }
        }

        private void DateTimeInputDisplay()
        {
            if (currentCell.Value != DBNull.Value && currentCell.Value != null)
                dtInput.Text = Convert.ToDateTime(currentCell.Value).ToString("yyyy/MM/dd");

            dtInput.Visible = true;
            lblShortCutKey.Visible = true;
            btnClear.Visible = true;
            btnBlank.Visible = true;
            btnInput.Visible = true;

            btnInput.Enabled = true;
            btnBlank.Enabled = true;
            btnClear.Enabled = true;

            dtInput.Size = txtInputText.Size;
            dtInput.Location = txtInputText.Location;
            dtInput.Focus();
            dtInput.Select();
        }

        private void ActiveImode(string columName)
        {
            if (HiraganaColumns != null && HiraganaColumns.Count > 0)
            {
                if (HiraganaColumns.Exist(columName))
                {
                    lang = new CultureInfo("ja-JP");
                    InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(lang);
                    txtInputText.ImeMode = ImeMode.Hiragana;
                    column = HiraganaColumns.GetColumn(columName);
                }
            }

            if (KatakanaColumns != null && lang == null && KatakanaColumns.Count > 0)
            {
                lang = new CultureInfo("ja-JP");
                if (KatakanaColumns.Exist(columName))
                {
                    InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(lang);
                    txtInputText.ImeMode = ImeMode.Katakana;
                    column = KatakanaColumns.GetColumn(columName);
                }
            }
        }

        private void AddCurrentDateTime()
        {
            if (dtInput.Visible)
                dtInput.Text = DateTime.Now.ToString(Constants.DATE_TIME_FORMAT_SQL111);
        }

        private void TxtInputText_Enter(object sender, EventArgs e)
        {
            Clipboard.Clear();
        }

        private void TxtInputText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnInput.Focus();
            }

            if (e.Control == true)
            {
                switch (e.KeyCode)
                {
                    case Keys.C:
                    case Keys.P:
                    case Keys.X:
                        e.Handled = true;
                        txtInputText.SelectionLength = 0;
                        break;
                }
            }
        }

        private void TxtInputText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }

        private void btnBlank_Click(object sender, System.EventArgs e)
        {
            UpdateBank();
        }

        private void UpdateBank()
        {
            if (currentCell == null)
                return;
            IsActive = true;
            Status = null;
            DataUpdate = null;
            btnClose_Click(null, null);
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Input data
        /// </summary>
        private void Input()
        {
            if (currentCell == null)
                return;
            IsActive = false;

            if (txtInputText.Visible)
            {
                if (!ValidText())
                    return;
                DataUpdate = txtInputText.Text;
            }
            else if (dtInput.Visible)
            {
                if (!GetParameterUtils.CheckDateTimeInput(lblColumName.Text, "", null, dtInput, null))
                    return;

                DateTime dateTime = DateTime.MinValue;
                DateTime.TryParse(dtInput.Text, out dateTime);
                if (dateTime != DateTime.MinValue)
                    DataUpdate = dateTime;
            }
            else if (cboStatus.Visible)
            {
                DataUpdate = cboStatus.SelectedIndex == 0 ? true : false;
            }

            if (this.isUpdateColumn && this.IsFilterActive)
            {
                DialogResult rst = MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGI002), GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (rst != DialogResult.Yes)
                {
                    return;
                }
            }

            IsActive = true;
            btnClose_Click(null, null);
        }

        private bool ValidText()
        {
            if (!isInputText || currentCell == null)
                return false;

            if (HankakuEiSuColumns != null && HankakuEiSuColumns.Count > 0)
            {
               var existcolumn = HankakuEiSuColumns.GetColumn(currentColumnName);

                if (existcolumn != null && existcolumn.IsDataRequired)
                {
                    // EN and Numeric upercase
                    if (existcolumn.IsHankakuEiSu)
                    {
                        if (!existcolumn.IsUpperCase)
                        {
                            if (!Utils.IsHankakuEiSu(txtInputText.Text))
                            {
                                MessageBox.Show(string.Format("半角英数字または英文字で指定してください", txtInputText.Text), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtInputText.SelectAll();
                                txtInputText.Focus();
                                return false;
                            }
                        }
                        else
                        {
                            if (!Utils.IsCharacterEN(txtInputText.Text))
                            {
                                MessageBox.Show(string.Format("半角英数字大文字で指定してください", txtInputText.Text), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtInputText.SelectAll();
                                txtInputText.Focus();
                                return false;
                            }
                        }
                    }
                }
            }

            if (HiraganaColumns != null && HiraganaColumns.Count > 0 && column != null && column.IsDataRequired)
            {
                if (HiraganaColumns.Exist(currentColumnName))
                {
                    if (column.IsOnlyHiragana && !column.IsNumeric)
                    {
                        if (!Utils.IsHiragana(txtInputText.Text))
                        {
                            MessageBox.Show("ひらがなで入力してください", GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        if (Utils.IsNumericEN(txtInputText.Text))
                        {
                            if (!column.IsNumeric)
                            {
                                MessageBox.Show("ひらがなで入力してください", GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                        // Only katakana
                        else if (!Utils.IsHiragana(txtInputText.Text))
                        {
                            MessageBox.Show("ひらがなで入力してください", GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
            }

            if (KatakanaColumns != null && KatakanaColumns.Count > 0 && column != null && column.IsDataRequired)
            {
                if (KatakanaColumns.Exist(currentColumnName))
                {
                    // Only katakana 
                    if (column.IsOnlyKatakana && !column.IsNumeric)
                    {
                        if (!Utils.IsKatakana(txtInputText.Text))
                        {
                            MessageBox.Show("カタカナで指定してください", GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    // Katakana or numeric
                    else
                    {
                        if (Utils.IsNumericEN(txtInputText.Text))
                        {
                            if (!column.IsNumeric)
                            {
                                MessageBox.Show("カタカナまたは数値で指定してください", GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                        // Only katakana
                        else if (!Utils.IsKatakana(txtInputText.Text))
                        {
                            MessageBox.Show("カタカナまたは数値で指定してください", GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
            }

            if (MinLength != 0 && txtInputText.TextLength < MinLength)
            {
                MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE024), MinLength), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInputText.Focus();
                return false;
            }

            if (currentCell.OwningColumn.GetType().Equals(typeof(DataGridViewNumericColumn)))
            {
                if (!Utils.IsNumericEN(txtInputText.Text))
                {
                    MessageBox.Show("数字で指定してください", GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void btnInput_Click(object sender, System.EventArgs e)
        {
            Input();
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            if (txtInputText.Visible)
                txtInputText.Text = string.Empty;
            else if (dtInput.Visible)
            {
                dtInput.ResetText();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.I))
            {
                btnInput_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.N))
            {
                btnBlank_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.C))
            {
                btnClear_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D))
            {
                AddCurrentDateTime();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CommonInPut_FormClosing(object sender, FormClosingEventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
        }
    }
}
