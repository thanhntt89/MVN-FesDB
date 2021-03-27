using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
using DevComponents.DotNetBar.Controls;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Festival.Base
{
    public partial class TextBoxInputNumeric : TextBoxX
    {
        public TextBoxInputNumeric()
        {
            InitializeComponent();
            
        }

        public TextBoxInputNumeric(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            base.OnKeyPress(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            if (!this.Text.All(char.IsNumber))
            {
                this.Text = null;
            }
            base.OnLeave(e);
        }
    }
}
