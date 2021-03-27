using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
namespace Festival.Base
{
    class DataGridViewNumericCell : DataGridViewTextBoxCell
    {
        public DataGridViewNumericCell() : base()
        {
            this.ValueType = typeof(string);
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            NumericInputCellControl ctl = DataGridView.EditingControl as NumericInputCellControl;
            ctl.MaxValueInput = MaxValueInput;

            if (this.Value == null)
            {
                ctl.Text = string.Empty;
            }
            else
            {
                ctl.Text = this.Value.ToString();
            }
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            DataGridViewNumericColumn owningCol = OwningColumn as DataGridViewNumericColumn;
            if (owningCol != null)
            {
                MaxValueInput = owningCol.MaxValueInput;
            }

            return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }

        /// <summary>
        /// Save config user: Maxvalue input in cell 
        /// </summary>
        public Int64 MaxValueInput
        {
            get; set;
        }

        public override Type EditType
        {
            get
            {               
                return typeof(NumericInputCellControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                return base.ValueType;
            }
            set
            {
                base.ValueType = value;
            }
        }

        protected override bool SetValue(int rowIndex, object value)
        {
            if (value != null)
            {
                if (!value.Equals("") &&
                    value.ToString().All(char.IsNumber) &&
                    MaxValueInput != 0 && !NumericUtil.IsValidNumber(value.ToString(), MaxValueInput)
                    || value.Equals(""))
                {
                    value = DBNull.Value;
                }
                else if (!value.ToString().All(char.IsNumber))
                {
                    return false;
                }
            }

            return base.SetValue(rowIndex, value);
        }

        public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, TypeConverter formattedValueTypeConverter, TypeConverter valueTypeConverter)
        {
            if (formattedValue != null)
            {
                if (!string.IsNullOrWhiteSpace(formattedValue.ToString()) && formattedValue.ToString().All(char.IsNumber))
                {
                    if (MaxValueInput != 0 && !NumericUtil.IsValidNumber(formattedValue.ToString(), MaxValueInput))
                    {
                        formattedValue = DBNull.Value;
                    }
                }
            }
            return formattedValue;
        }
    }

    public class NumericUtil
    {
        public static bool IsValidNumber(string data, Int64 MaxValue)
        {
            Int64 ot = Int64.MaxValue;
            if (data == null)
                return true;
            Int64.TryParse(data, out ot);
            if (ot > MaxValue)
                return false;
            return true;
        }
    }
}
