using DevComponents.DotNetBar.Controls;
using DevComponents.Editors.DateTimeAdv;
using FestivalCommon;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Festival.Common
{
    public class GetParameterUtils
    {
        public static void GetParameterCheckBox(List<string> slqParameters, string columnCondition, string unCheckedValue, CheckBoxX checkBox)
        {
            string param = string.Empty;
            if (string.IsNullOrWhiteSpace(columnCondition) || checkBox == null)
                return;
            if (!checkBox.Checked)
            {
                param = string.Format("and {0} = '{1}'", columnCondition, unCheckedValue);
            }

            if (!string.IsNullOrEmpty(param))
                slqParameters.Add(param);
        }

        public static void ActiveDatetimeInput(ComboBoxEx combox, MaskedTextBoxAdv dtFrom, MaskedTextBoxAdv dtTo)
        {
            dtFrom.Enabled = false;
            dtTo.Enabled = false;
            dtFrom.Text = string.Empty;
            dtTo.Text = string.Empty;
            if (combox.SelectedIndex < 1)
            {
                dtFrom.Enabled = true;
                dtTo.Enabled = true;
            }
        }

        public static void ActiveInputText(ComboBoxEx combox, TextBoxX txtBox1, TextBoxX txtBox2)
        {
            txtBox1.Enabled = true;
            txtBox2.Enabled = true;
            txtBox1.Text = string.Empty;
            txtBox2.Text = string.Empty;
            if (combox.SelectedIndex > 0)
            {
                txtBox1.Enabled = false;
                txtBox2.Enabled = false;
            }
        }

        public static bool CheckCompareNumberInput(string lableName, string messageCode, TextBoxX textBox1, TextBoxX textBox2)
        {
            int value1 = -1;
            int value2 = -1;
            int.TryParse(textBox1.Text, out value1);
            int.TryParse(textBox2.Text, out value2);

            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && value1 > value2)
            {
                MessageBox.Show(string.Format(GetResources.GetResourceMesssage(messageCode), lableName), Constants.ERROR_TITLE_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return false;
            }
            return true;
        }

        public static void GetParameterComboxWithDateTime(List<string> slqParameters, string columnCondition, ComboBoxEx combCheck, MaskedTextBoxAdv dtFrom, MaskedTextBoxAdv dtTo, string format = "")
        {
            DateTimeInput toValue = new DateTimeInput();
            DateTimeInput fromValue = new DateTimeInput();

            DateTime inputTo;
            DateTime inputFrom;

            DateTime.TryParse(dtFrom.Text, out inputFrom);
            DateTime.TryParse(dtTo.Text, out inputTo);

            fromValue.Value = inputFrom;
            toValue.Value = inputTo;

            GetParameterUtils.GetParameterComboxWithDateTime(slqParameters, columnCondition, combCheck, fromValue, toValue, format);
        }

        public static bool CheckDateTimeInput(string lableName, string messageCode, ComboBoxEx combox, MaskedTextBoxAdv dtFrom, MaskedTextBoxAdv dtTo)
        {
            if (combox == null || (combox != null && combox.SelectedIndex < 1))
            {
                DateTime toValue = DateTime.MinValue;
                DateTime fromValue = DateTime.MinValue;

                if (dtFrom != null)
                    DateTime.TryParse(dtFrom.Text, out fromValue);
                if (dtTo != null)
                    DateTime.TryParse(dtTo.Text, out toValue);

                if (dtFrom != null && !string.IsNullOrEmpty(dtFrom.Text.Replace("/", "").Trim()) && fromValue == DateTime.MinValue)
                {
                    MessageBox.Show(string.Format("{0} の形式が正しくない", lableName), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtFrom.Focus();
                    return false;
                }

                if (dtTo != null && !string.IsNullOrEmpty(dtTo.Text.Replace("/", "").Trim()) && toValue == DateTime.MinValue)
                {
                    MessageBox.Show(string.Format("{0} の形式が正しくない", lableName), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtTo.Focus();
                    return false;
                }

                if (fromValue != DateTime.MinValue && toValue != DateTime.MinValue && toValue < fromValue)
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssage(messageCode), lableName), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtFrom.Focus();
                    return false;
                }
            }

            return true;
        }

        public static void GetParameterFromCombox(List<string> slqParameters, string columnName, ComboBoxEx cboCheck, bool IsGetValue = true)
        {
            string param = string.Empty;
            // Blank not searching condition
            if (cboCheck.SelectedIndex < 1)
                return;

            // Column null
            if (string.IsNullOrWhiteSpace(columnName) || columnName == null)
            {
                param = string.Format("and {0}", cboCheck.Text);
                if (IsGetValue)
                {
                    param = string.Format("and {0}", cboCheck.SelectedValue);
                }
            }
            else
            {
                if (cboCheck.Text.ToLower().Equals(Constants.CONDITION_VALUE_NULL.ToLower())
                         || cboCheck.Text.ToLower().Equals(Constants.CONDITION_VALUE_NOT_NULL.ToLower()))
                {
                    param = string.Format("and {0} is {1}", columnName, cboCheck.Text.ToLower());
                    if (IsGetValue)
                    {
                        param = string.Format("and {0} is {1}", columnName, cboCheck.SelectedValue);
                    }
                }
                else
                {
                    param = string.Format("and {0} = '{1}'", columnName, cboCheck.Text.ToLower());
                    if (IsGetValue)
                    {
                        param = string.Format("and {0} = '{1}'", columnName, cboCheck.SelectedValue);
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(param))
                slqParameters.Add(param);
        }

        private static void GetParameterComboxWithDateTime(List<string> slqParameters, string columnCondition, ComboBoxEx combCheck, DateTimeInput dtFrom, DateTimeInput dtTo, string format = "")
        {
            string param = string.Empty;

            // If combox not blank
            if (combCheck != null && combCheck.SelectedIndex > 0)
            {
                param = string.Format("and {0} is {1}", columnCondition, combCheck.Text.ToLower());
                if (!string.IsNullOrEmpty(param))
                    slqParameters.Add(param);

                return;
            }

            // Check datatime value input
            if (!string.IsNullOrEmpty(dtFrom.Text) && !string.IsNullOrEmpty(dtTo.Text))
            {
                param = string.Format("and {0} between '{1}' and '{2}'", columnCondition, dtFrom.Value, dtTo.Value);
                if (!string.IsNullOrEmpty(format))
                {
                    param = string.Format("and {0} between '{1}' and '{2}'", columnCondition, dtFrom.Value.ToString(format), dtTo.Value.ToString(format));
                }
            }
            else if (!string.IsNullOrEmpty(dtFrom.Text))
            {
                param = string.Format("and {0} = '{1}'", columnCondition, dtFrom.Value);
                if (!string.IsNullOrEmpty(format))
                {
                    param = string.Format("and {0} = '{1}'", columnCondition, dtFrom.Value.ToString(format));
                }
            }
            else if (!string.IsNullOrEmpty(dtTo.Text))
            {
                param = string.Format("and {0} <= '{1}'", columnCondition, dtTo.Value);

                if (!string.IsNullOrEmpty(format))
                {
                    param = string.Format("and {0} <= '{1}'", columnCondition, dtTo.Value.ToString(format));
                }
            }

            if (!string.IsNullOrEmpty(param))
                slqParameters.Add(param);
        }

        public static void GetParameterTextBox(List<string> slqParameters, string columnName, TextBoxX textBox, RadioButton radMatchingAll, RadioButton radFrontMatch, RadioButton radPartialMatch, RadioButton radExclude)
        {
            string data = string.Empty;
            if (textBox != null)
                data = textBox.Text.Replace("'", "''");
            string param = string.Empty;
            if (radMatchingAll.Checked && !string.IsNullOrWhiteSpace(data))
            {
                param = string.Format("and {0} = '{1}'", columnName, data);
            }
            else if (radFrontMatch.Checked && !string.IsNullOrWhiteSpace(data))
            {
                param = string.Format("and {0} like '{1}%'", columnName, data);
            }
            else if (radPartialMatch.Checked && !string.IsNullOrWhiteSpace(data))
            {
                param = string.Format("and {0} like '%{1}%'", columnName, data);
            }
            else if (radExclude.Checked && !string.IsNullOrWhiteSpace(data))
            {
                param = string.Format("and {0} not like '%{1}%'", columnName, data);
            }
            if (!string.IsNullOrWhiteSpace(param))
                slqParameters.Add(param);
        }

        public static void GetParameterTextBoxNumber(List<string> slqParameters, string columnName, TextBoxX textNumberFrom, TextBoxX textNumberTo)
        {
            string param = string.Empty;

            if (!string.IsNullOrWhiteSpace(textNumberFrom.Text) && !string.IsNullOrWhiteSpace(textNumberTo.Text))
            {
                param = string.Format("and {0} between {1} and {2}", columnName, textNumberFrom.Text, textNumberTo.Text);
            }
            else if (!string.IsNullOrWhiteSpace(textNumberFrom.Text))
            {
                param = string.Format(" and  {0} =  {1}", columnName, textNumberFrom.Text);
            }
            else if (!string.IsNullOrWhiteSpace(textNumberTo.Text))
            {
                param = string.Format(" and  {0} <=  {1}", columnName, textNumberTo.Text);
            }
            if (!string.IsNullOrWhiteSpace(param))
                slqParameters.Add(param);
        }

        public static void GetParameterTextBoxText(List<string> slqParameters, string columnName, TextBoxX textNumberFrom, TextBoxX textNumberTo)
        {
            string param = string.Empty;

            if (!string.IsNullOrWhiteSpace(textNumberFrom.Text) && !string.IsNullOrWhiteSpace(textNumberTo.Text))
            {
                param = string.Format("and {0} between '{1}' and '{2}'", columnName, textNumberFrom.Text, textNumberTo.Text);
            }
            else if (!string.IsNullOrWhiteSpace(textNumberFrom.Text))
            {
                param = string.Format(" and  {0} = '{1}'", columnName, textNumberFrom.Text);
            }
            else if (!string.IsNullOrWhiteSpace(textNumberTo.Text))
            {
                param = string.Format(" and  {0} <=  '{1}'", columnName, textNumberTo.Text);
            }
            if (!string.IsNullOrWhiteSpace(param))
                slqParameters.Add(param);
        }

        internal static void GetParameterComboxWithTextBox(List<string> slqParameters, string columnName, ComboBoxEx combCheck, TextBoxX txtFrom, TextBoxX txtTo)
        {
            string param = string.Empty;
            // If combox not blank
            if (combCheck != null && combCheck.SelectedIndex > 0)
            {
                param = string.Format("and {0} is {1}", columnName, combCheck.Text.ToLower());
                if (!string.IsNullOrEmpty(param))
                    slqParameters.Add(param);

                return;
            }

            if (!string.IsNullOrWhiteSpace(txtFrom.Text) && !string.IsNullOrWhiteSpace(txtTo.Text))
            {
                param = string.Format("and {0} between {1} and {2}", columnName, txtFrom.Text, txtTo.Text);
            }
            else if (!string.IsNullOrWhiteSpace(txtFrom.Text))
            {
                param = string.Format(" and  {0} =  {1}", columnName, txtFrom.Text);
            }
            else if (!string.IsNullOrWhiteSpace(txtTo.Text))
            {
                param = string.Format(" and  {0} <=  {1}", columnName, txtTo.Text);
            }
            if (!string.IsNullOrWhiteSpace(param))
                slqParameters.Add(param);
        }
    }
}
