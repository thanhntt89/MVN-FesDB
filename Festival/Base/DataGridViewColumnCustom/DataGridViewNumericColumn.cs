using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Festival.Base
{
    public class DataGridViewNumericColumn : DataGridViewColumn
    {
        private Int64 MaxValue = 0;
        private int MinInputLengthValue = 0;

        public DataGridViewNumericColumn() : base(new DataGridViewNumericCell())
        {
            this.ValueType = typeof(DataGridViewNumericCell);
            this.MaxValue = Int64.MaxValue;
        }

        [Category("Behavior")]
        [Description("Max input characters")]
        public int MaxInputLength
        {
            get
            {
                return ((DataGridViewNumericCell)base.CellTemplate).MaxInputLength;
            }
            set
            {
                ((DataGridViewNumericCell)base.CellTemplate).MaxInputLength = value;
            }
        }
        [Category("Behavior")]
        [Description("Max input characters")]
        public int MinInputLength
        {
            get { return MinInputLengthValue; }
            set { MinInputLengthValue = value; }
        }

        [Category("Behavior")]
        [Description("Max value input")]
        public Int64 MaxValueInput
        {
            get
            {
                return MaxValue;
            }
            set
            {
                MaxValue = value;
            }
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is correct.
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewNumericCell)))
                {
                    throw new InvalidCastException("Must be a numeric input");
                }

                base.CellTemplate = value;
            }
        }

        public override object Clone()
        {
            DataGridViewNumericColumn clo = (DataGridViewNumericColumn)base.Clone();
            if (clo != null)
            {
                clo.MaxValueInput = MaxValueInput;
                clo.MinInputLength = MinInputLength;
            }

            return clo;
        }
    }
}
