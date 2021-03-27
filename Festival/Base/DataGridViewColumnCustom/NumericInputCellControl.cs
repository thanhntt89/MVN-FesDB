using System;
using System.Windows.Forms;
using System.Linq;

namespace Festival.Base
{
    public class NumericInputCellControl : DataGridViewTextBoxEditingControl, IDataGridViewEditingControl //DataGridViewTextBoxEditingControl
    {
        private bool Cancelling = false;

        //public override string Text
        //{
        //    get
        //    {
        //        return base.Text;
        //    }

        //    set
        //    {
        //        base.Text = value;
        //    }
        //}

        public Int64 MaxValueInput { get; set; }

        public override bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                case Keys.Escape:
                case Keys.Delete:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        // Check key press number only
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) ||
                this.Text.Length > base.MaxLength)
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Cancelling = true;
                e.Handled = true;
                e.SuppressKeyPress = true;
                var dgv = this.EditingControlDataGridView;
                dgv.CancelEdit();
                dgv.EndEdit();
            }
            base.OnKeyDown(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            var dgv = this.EditingControlDataGridView;
            var cell = dgv.CurrentCell as DataGridViewNumericCell;

            if (!Cancelling && cell != null)
            {
                if (string.IsNullOrWhiteSpace(this.Text))
                {
                    cell.Value = DBNull.Value;
                    return;
                }
                if (!string.IsNullOrWhiteSpace(this.Text) &&
                    this.Text.ToString().All(char.IsNumber))
                {
                    // If user input number lager than maxvalue input
                    // Set value is empty
                    if (MaxValueInput != 0 && !NumericUtil.IsValidNumber(this.Text, MaxValueInput))
                        this.Text = string.Empty;
                    cell.Value = this.Text;
                }
                else
                {
                    dgv.CancelEdit();
                    dgv.EndEdit();
                }
            }

            base.OnLeave(e);
            Cancelling = false;
        }
    }
}
