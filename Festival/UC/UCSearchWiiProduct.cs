using Festival.Base;
using System;
using FestivalObjects;
using System.Windows.Forms;

namespace Festival.UC
{
    public partial class UCSearchWiiProduct : UserControlBaseAdvance
    {
        public UCSearchWiiProduct()
        {
            InitializeComponent();
        }

        private void btnEnkaFlagSetting_Click(object sender, EventArgs e)
        {

        }

        public override void ExportToFile(FileExportEntity FileInfo)
        {          
            MessageBox.Show("UCSearchWiiProduct:" + FileInfo.FileName);
        }
    }
}
