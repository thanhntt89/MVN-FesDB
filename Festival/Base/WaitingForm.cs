using System;
using System.Drawing;
using System.Windows.Forms;

namespace Festival.Base
{
    public partial class WaitingForm : FormBase
    {
        public WaitingForm()
        {
            InitializeComponent();
            this.AllowTransparency = true;
            this.TransparencyKey = this.BackColor;
        }

        private void WaitingForm_Load(object sender, EventArgs e)
        {
            circularProgressBar.Size = new Size(136, 136);
            this.Size = circularProgressBar.Size;
            circularProgressBar.Dock = DockStyle.Fill;
        }
    }
}
