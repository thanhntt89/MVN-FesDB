using DevComponents.DotNetBar.Controls;
using Festival.Base;
using FestivalCommon;
using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;

namespace Festival.Common
{
    public partial class ComboxColumnInput : FormBase
    {
        private DataGridViewCell currentCell;
        private bool isUpdateColumn = false;
        private bool isColumnFilter = false;

        public ComboxColumnInput(DataGridViewCell comboxCollection, bool isUpdateColumn, bool isColumnFilter)
        {
            InitializeComponent();
            this.currentCell = comboxCollection;
            this.isUpdateColumn = isUpdateColumn;
            this.isColumnFilter = isColumnFilter;

            if (!isUpdateColumn)
            {
                this.Text = "セル編集";
            }
        }

        private void InitDataGrid()
        {
            if (currentCell == null)
                return;
            var cbo = (DataGridViewComboBoxExColumn)currentCell.OwningColumn;
            lblColumName.Text = currentCell.DataGridView.Columns[currentCell.ColumnIndex].HeaderText;

            DataTable dtSource = cbo.DataSource as DataTable;
            if (dtSource == null)
                return;

            if (currentCell.OwningColumn.DataPropertyName.Equals("歌手ID補正"))
            {
                advFilter.Focus();
                dtgComboxInput.Visible = false;
                advFilter.Visible = true;

                BindingSource bdSource = new BindingSource();

                bdSource.DataSource = dtSource;
                advFilter.DataSource = bdSource;

                bdSource.Filter = string.Empty;

                DataGridViewUtils.FastAutoSizeColumns(advFilter);

                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Size = new System.Drawing.Size(870, 530);

                for (int i = 0; i < advFilter.Rows.Count; i++)
                {
                    if (advFilter.Rows[i].Cells[0].Value.Equals(currentCell.Value))
                    {
                        advFilter.Rows[i].Cells[0].Selected = true;
                        break;
                    }
                }
                dtgComboxInput.Focus();
            }
            else
            {
                this.Size = new System.Drawing.Size(464, 278);

                if (dtSource.Rows.Count == 0)
                    return;
                int rowIndex = 0;
                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    dtgComboxInput.Rows.Add(dtSource.Rows[i][0], dtSource.Rows[i][1]);
                    if (dtSource.Rows[i][0].ToString().Equals(currentCell.Value.ToString()))
                    {
                        rowIndex = i;
                    }
                }
                dtgComboxInput.ClearSelection();
                if (rowIndex != -1)
                {
                    dtgComboxInput.Rows[rowIndex].Selected = true;
                    int targetRow = dtgComboxInput.SelectedRows[0].Index;
                    int halfWay = (dtgComboxInput.DisplayedRowCount(false) / 2);
                    targetRow = Math.Max(targetRow - halfWay, 0);
                    dtgComboxInput.FirstDisplayedScrollingRowIndex = targetRow;
                }
            }
        }

        private void InsertByKeyNumber(Keys keyData)
        {
            if (dtgComboxInput.Rows.Count > 10)
            {
                return;
            }

            int value = -1;
            switch (keyData)
            {
                case Keys.NumPad0:
                case Keys.D0:
                    value = 0;
                    break;
                case Keys.NumPad1:
                case Keys.D1:
                    value = 1;
                    break;
                case Keys.NumPad2:
                case Keys.D2:
                    value = 2;
                    break;
                case Keys.NumPad3:
                case Keys.D3:
                    value = 3;
                    break;
                case Keys.NumPad4:
                case Keys.D4:
                    value = 4;
                    break;
                case Keys.NumPad5:
                case Keys.D5:
                    value = 5;
                    break;
                case Keys.NumPad6:
                case Keys.D6:
                    value = 6;
                    break;
                case Keys.NumPad7:
                case Keys.D7:
                    value = 7;
                    break;
                case Keys.NumPad8:
                case Keys.D8:
                    value = 8;
                    break;
                case Keys.NumPad9:
                case Keys.D9:
                    value = 9;
                    break;
                default:
                    break;
            }

            foreach (DataGridViewRow row in dtgComboxInput.Rows)
            {
                if (row.Cells[colIndex.Index].Value == DBNull.Value) continue;
                if (row.Cells[colIndex.Index].Value.ToString().Equals(value.ToString()))
                {
                    dtgComboxInput.CurrentCell = row.Cells[colValue.Index];                   
                    break;
                }
            }       
        }

        private void ComboxColumnInput_Load(object sender, EventArgs e)
        {
            InitDataGrid();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            UpdateAll();
        }

        private void UpdateAll()
        {
            if (this.isUpdateColumn && this.isColumnFilter)
            {
                DialogResult rst = MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGI002), GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (rst != DialogResult.Yes)
                {
                    return;
                }
            }

            if (dtgComboxInput.Visible)
            {
                if (dtgComboxInput.CurrentRow == null)
                    return;
                DataUpdate = dtgComboxInput.Rows[dtgComboxInput.CurrentRow.Index].Cells[colIndex.Index].Value.ToString();
            }
            else if (advFilter.Visible)
            {
                if (advFilter.CurrentRow == null)
                    return;
                DataUpdate = advFilter.Rows[advFilter.CurrentRow.Index].Cells[colIndex.Index].Value.ToString();
            }

            IsActive = true;
            btnClose_Click(null, null);
        }

        private void btnBlank_Click(object sender, EventArgs e)
        {
            DataUpdate = string.Empty;
            IsActive = true;
            btnClose_Click(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnApply_Click(null, null);
            }
            else
            {
                InsertByKeyNumber(keyData);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
