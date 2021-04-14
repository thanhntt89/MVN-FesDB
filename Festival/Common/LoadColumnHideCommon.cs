using Festival.Base;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace Festival.Common
{
    public partial class LoadColumnHideCommon : FormBase
    {
        private DataGridViewColumnCollection columns = null;
        public FestivalEvents.ColumnsVisibleHandler SetColumnVisibleEvent;
        private List<string> GetHideColumns;

        public LoadColumnHideCommon(DataGridViewColumnCollection columnInput, List<string> HideColumns)
        {
            InitializeComponent();
            columns = columnInput;
            GetHideColumns = HideColumns;
        }

        private void LoadColumns()
        {
            panelMain.Controls.Clear();
            int x = 9;
            int y = 6;
            int count = 0;

            if (columns == null)
                return;

            var query = columns.Cast<DataGridViewColumn>().OrderBy(r => r.DisplayIndex);

            foreach (DataGridViewColumn col in query)
            {
                //var hideColumn = GetHideColumns.Where(r => r.Equals(col.DataPropertyName));

                //if (hideColumn.Count() > 0)
                //    continue;

                CheckBox chkColumn = new CheckBox();
                if (count > 0)
                    y += chkColumn.Size.Height;

                chkColumn.Checked = col.Visible;
                chkColumn.CheckedChanged += ChkColumn_CheckedChanged;
                chkColumn.Name = col.Name;
                chkColumn.Text = col.HeaderText;
                chkColumn.Location = new System.Drawing.Point(x, y);
                chkColumn.Size = new System.Drawing.Size(200, 17);
                panelMain.Controls.Add(chkColumn);
                count++;
            }
        }

        private void ChkColumn_CheckedChanged(object sender, System.EventArgs e)
        {
            CheckBox currentCheck = sender as CheckBox;
            if (currentCheck != null)
            {
                if (SetColumnVisibleEvent != null)
                    SetColumnVisibleEvent(currentCheck.Name, currentCheck.Checked);
            }
        }

        private void LoadColumnHideCommon_Load(object sender, System.EventArgs e)
        {
            LoadColumns();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == (Keys.Alt | Keys.C))
            {
                btnClose_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
