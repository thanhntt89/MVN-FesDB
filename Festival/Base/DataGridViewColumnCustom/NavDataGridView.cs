using System.Windows.Forms;
using System;
using Zuby.ADGV;

namespace Festival.Base
{
    public partial class NavDataGridView : UserControl
    {
        public AdvancedDataGridView DataGridViewSource { get; set; }
        public delegate void ClearFilterAndSortHandle();
        private int totalRows = 0;
        private int currentRowIndex = 0;
        private int currentColumnIndex = 0;
        // Save current position
        private int scrollPosition = 0;
        int totalColumns = 0;
        int visibleColumnCount = 0;
        int maxiMum = 0;
        int totalwidth = 0;

        public NavDataGridView()
        {
            InitializeComponent();
            LoadToolTips();
        }

        public void EnableClearFilterAndSortButton()
        {
            Invoke(new Action(() =>
            {
                if (DataGridViewSource != null)
                {
                    btnUnFilterAndSort.Enabled = false;

                    if (!string.IsNullOrEmpty(DataGridViewSource.FilterString) || !string.IsNullOrEmpty(DataGridViewSource.SortString))
                        btnUnFilterAndSort.Enabled = true;

                }
            }));
        }

        private void DataGridViewSource_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            InitHScroll();
        }

        public void InitHScroll()
        {
            if (DataGridViewSource == null || DataGridViewSource.Columns.Count == 0)
                return;
            Invoke(new Action(() =>
            {
                totalwidth = DataGridViewSource.RowHeadersWidth;
                totalColumns = 0;
                visibleColumnCount = 0;
                maxiMum = 0;
                foreach (DataGridViewColumn col in DataGridViewSource.Columns)
                {
                    if (!col.Visible)
                    {
                        visibleColumnCount++;
                        continue;
                    }

                    totalwidth += col.Width;
                    totalColumns++;
                }

                maxiMum = totalColumns > 0 ? totalwidth + DataGridViewSource.Columns[totalColumns - 1].Width / 2 : totalwidth;
                hScrollBar.Maximum = maxiMum;
                hScrollBar.Minimum = 0;
                hScrollBar.LargeChange = DataGridViewSource.Width;
                hScrollBar.SmallChange = DataGridViewSource.Columns[0].Width;
                hScrollBar.Value = scrollPosition > hScrollBar.Maximum ? hScrollBar.Maximum : scrollPosition;
                DataGridViewSource.HorizontalScrollingOffset = hScrollBar.Value;
            }));
        }

        private void DataGridViewSource_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (currentColumnIndex != e.ColumnIndex)
            {
                if (e.ColumnIndex == totalColumns - 1)
                {
                    hScrollBar.Value = hScrollBar.Maximum;
                }
                else if (e.ColumnIndex == 0)
                {
                    hScrollBar.Value = hScrollBar.Minimum;
                }

                scrollPosition = hScrollBar.Value;
            }

            currentColumnIndex = e.ColumnIndex;

            if (currentRowIndex == e.RowIndex)
                return;

            currentRowIndex = e.RowIndex;
            NextRow();
        }

        private void InitCombox()
        {
            if (DataGridViewSource == null)
                return;
            JumpToRow(currentRowIndex);
        }

        private void InitDataGridViewEvent()
        {
            if (DataGridViewSource == null)
                return;
            DataGridViewSource.ColumnWidthChanged += DataGridViewSource_ColumnWidthChanged;
            DataGridViewSource.SizeChanged += DataGridViewSource_SizeChanged;
            DataGridViewSource.DataBindingComplete += DataGridViewSource_DataBindingComplete;
            DataGridViewSource.CellEnter += DataGridViewSource_CellEnter;
            DataGridViewSource.FilterStringChanged += DataGridViewSource_FilterStringChanged;
            DataGridViewSource.SortStringChanged += DataGridViewSource_SortStringChanged;
            DataGridViewSource.Scroll += DataGridViewSource_Scroll;
        }

        private void DataGridViewSource_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll && DataGridViewSource.HorizontalScrollingOffset > 0 && hScrollBar.Value != DataGridViewSource.HorizontalScrollingOffset)
            {
                hScrollBar.Value = DataGridViewSource.HorizontalScrollingOffset;
            }
        }

        private void DataGridViewSource_SortStringChanged(object sender, AdvancedDataGridView.SortEventArgs e)
        {
            EnableClearFilterAndSortButton();
        }

        private void DataGridViewSource_FilterStringChanged(object sender, AdvancedDataGridView.FilterEventArgs e)
        {
            EnableClearFilterAndSortButton();
        }

        private void DataGridViewSource_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            InitCombox();
            if (hScrollBar.Value != DataGridViewSource.HorizontalScrollingOffset)
            {
                LoadScrollOfset();
            }
        }

        private void DataGridViewSource_SizeChanged(object sender, EventArgs e)
        {
            InitHScroll();
        }

        private void NavDataGridView_Load(object sender, System.EventArgs e)
        {
            InitHScroll();
            InitDataGridViewEvent();
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            scrollPosition = e.NewValue;
            if (DataGridViewSource == null)
                return;
            LoadScrollOfset();
        }

        private void LoadScrollOfset()
        {
            if (scrollPosition < hScrollBar.Minimum)
                scrollPosition = hScrollBar.Minimum;
            else if (scrollPosition > hScrollBar.Maximum)
                scrollPosition = hScrollBar.Maximum;

            hScrollBar.Value = scrollPosition;

            if (scrollPosition == 0)
            {
                DataGridViewSource.HorizontalScrollingOffset = scrollPosition;
            }
            else if (scrollPosition > 0)
            {
                DataGridViewSource.HorizontalScrollingOffset = totalColumns > 0 ? scrollPosition + DataGridViewSource.Columns[totalColumns - 1].Width / 2 : scrollPosition;
            }
        }

        public void NextRow()
        {
            if (DataGridViewSource == null || DataGridViewSource.CurrentCell == null || DataGridViewSource.CurrentCell.RowIndex > totalRows - 1 || DataGridViewSource.CurrentCell.RowIndex == -1)
                return;

            JumpToRow(currentRowIndex);
        }

        private void JumpToRow(int rowIndex)
        {
            Invoke(new Action(() =>
            {
                totalRows = DataGridViewSource.RowCount;
                if (DataGridViewSource.AllowUserToAddRows)
                    totalRows--;
                if (totalRows == 0)
                    rowIndex = 0;

                NavButton();

                if (totalRows == 0 || rowIndex == -1)
                {
                    txtNumber.Text = "0/0";
                    return;
                }

                rowIndex = rowIndex > totalRows - 1 ? totalRows - 1 : rowIndex;
                txtNumber.Text = (rowIndex + 1) + "/" + totalRows;
                try
                {
                    if (DataGridViewSource.CurrentCell != null)
                        DataGridViewSource.CurrentCell = DataGridViewSource[DataGridViewSource.CurrentCell.ColumnIndex, rowIndex];
                }
                catch
                {

                }               
            }));
        }

        private void NavButton()
        {
            Invoke(new Action(() =>
            {
                btnFirstRow.Enabled = true;
                btnPreRow.Enabled = true;
                btnNextRow.Enabled = true;
                btnLastRow.Enabled = true;

                if (currentRowIndex == 0)
                {
                    btnFirstRow.Enabled = false;
                    btnPreRow.Enabled = false;
                }
                else if (currentRowIndex == totalRows - 1)
                {
                    btnNextRow.Enabled = false;
                    btnLastRow.Enabled = false;
                }
            }));
        }

        private void btnNextRow_Click(object sender, System.EventArgs e)
        {
            if (currentRowIndex < 0 || currentRowIndex >= totalRows - 1)
                return;
            currentRowIndex++;
            NextRow();
        }

        private void btnLastRow_Click(object sender, System.EventArgs e)
        {
            currentRowIndex = totalRows - 1;
            NextRow();
        }

        private void btnPreRow_Click(object sender, System.EventArgs e)
        {
            if (currentRowIndex < 0 || currentRowIndex > totalRows - 1)
                return;
            currentRowIndex--;
            NextRow();
        }

        private void btnFirstRow_Click(object sender, System.EventArgs e)
        {
            currentRowIndex = 0;
            NextRow();
        }

        private void btnUnFilterAndSort_Click(object sender, EventArgs e)
        {
            DataGridViewSource.CleanFilterAndSort();
            btnUnFilterAndSort.Enabled = false;
        }

        private void LoadToolTips()
        {
            ToolTip ToolTip = new ToolTip();
            ToolTip.SetToolTip(this.btnFirstRow, "First row");
            ToolTip.SetToolTip(this.btnPreRow, "Previewus row");
            ToolTip.SetToolTip(this.btnNextRow, "Next row");
            ToolTip.SetToolTip(this.btnLastRow, "Last row");
            ToolTip.SetToolTip(this.btnUnFilterAndSort, "Clear filter and sort");
        }

        private void JumpToRow()
        {
            if (int.TryParse(txtNumber.Text, out currentRowIndex))
            {
                if (currentRowIndex > totalRows)
                {
                    txtNumber.Text = totalRows.ToString();
                    txtNumber.Focus();
                    return;
                }

                currentRowIndex--;
                JumpToRow(currentRowIndex);
            }
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNumber_Click(object sender, EventArgs e)
        {
            txtNumber.Text = string.Empty;
        }

        private void txtNumber_Leave(object sender, EventArgs e)
        {
            JumpToRow(currentRowIndex);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                JumpToRow();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
