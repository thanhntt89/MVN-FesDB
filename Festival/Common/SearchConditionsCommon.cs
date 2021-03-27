using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Festival.Base;
using System.Windows.Forms;
using FestivalObjects;
using System.Collections.Generic;
using System.Linq;
using Zuby.ADGV;
using System;

namespace Festival.Common
{
    public partial class SearchConditionsCommon : UserControlBaseAdvance
    {
        // Save data AND or Data OR to filter function
        private DataGridViewFilterEntity filterEntity;
        private const string DATAGRIDVIEWNAMEOR = "dtgCondition";
        private const string TabConditionText = "または";
        private AdvancedDataGridView currentDataGridViewEditing = null;
        // Tabcount start with default tab
        private int tabCount = 0;
        // List condition
        private IList<AdvancedDataGridView> dataOrConditon;

        public SearchConditionsCommon(DataGridViewColumnCollection columns, List<string> HideColumns)
        {
            InitializeComponent();

            dataOrConditon = new List<AdvancedDataGridView>();
            // Get all column display
            this.ColumnCollection = columns;
            this.HideColumns = HideColumns;
            // Init combox column datasource
            this.InitSearchConditionColumnCombox();
        }

        private void SearchConditionsCommon_Load(object sender, System.EventArgs e)
        {
            CreateConditionTab();
        }

        private void dtgSearchCondition_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // If first tab condition
            if (tabMain.Tabs.Count == 1)
                CreateConditionTab();
        }

        /// <summary>
        /// Create newa tab
        /// </summary>
        private void CreateConditionTab()
        {
            // Count tab
            tabCount++;

            // Create datagridview
            AdvancedDataGridView dtgCondition = CreateDataGridViewCondition(tabCount);

            dtgCondition.Dock = DockStyle.Fill;

            // Set first tab
            if (tabMain.Tabs.Count == tabCount)
            {
                superTabControlPanel0.Controls.Add(dtgCondition);
                return;
            }

            SuperTabItem tabCodition = new SuperTabItem();

            SuperTabControlPanel superTabControlConditionPanel = new SuperTabControlPanel();

            superTabControlConditionPanel.Name = "Panel_CONDITION" + tabCount;
            tabCodition.Text = TabConditionText;
            tabCodition.AttachedControl = superTabControlConditionPanel;
            superTabControlConditionPanel.Controls.Add(dtgCondition);
            superTabControlConditionPanel.Dock = DockStyle.Fill;
            superTabControlConditionPanel.TabItem = tabCodition;
            superTabControlConditionPanel.Location = new System.Drawing.Point(0, 0);

            // Create new tab or
            tabMain.Controls.Add(superTabControlConditionPanel);
            tabMain.Tabs.Add(tabCodition);
        }

        /// <summary>
        /// Create or datagridview condition
        /// </summary>
        /// <returns></returns>
        private AdvancedDataGridView CreateDataGridViewCondition(int dataGridViewIndex)
        {
            AdvancedDataGridView dtgCondition = new AdvancedDataGridView();
            if (this.ColumnCollection.Count == 0)
                return dtgCondition;

            dtgCondition.Name = DATAGRIDVIEWNAMEOR + dataGridViewIndex;
            dtgCondition.AllowUserToAddRows = false;
            dtgCondition.AllowUserToResizeRows = false;
            dtgCondition.AllowUserToResizeColumns = true;
            dtgCondition.AllowUserToDeleteRows = false;
            dtgCondition.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dtgCondition.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgCondition.AllowUserToResizeColumns = true;
            dtgCondition.BackgroundColor = System.Drawing.Color.White;

            var dtg = dataOrConditon.Count > 0 ? dataOrConditon[dataOrConditon.Count - 1].Columns.Cast<DataGridViewColumn>().OrderBy(r => r.DisplayIndex).ToList() :  this.ColumnCollection.Cast<DataGridViewColumn>().OrderBy(r => r.DisplayIndex).ToList();

            foreach (DataGridViewColumn col in dtg)
            {
                DataGridViewColumn colm = (DataGridViewColumn)col.Clone();
                colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                colm.ReadOnly = false;
                colm.Width = col.Width;
                colm.Frozen = false;
                colm.DisplayIndex = col.DisplayIndex;             

                if (colm.GetType().Equals(typeof(DataGridViewDateTimeInputColumn)))
                {
                    colm.MinimumWidth = 120;
                }

                if (!colm.GetType().Equals(typeof(DataGridViewComboBoxExColumn)) && !colm.GetType().Equals(typeof(DataGridViewCheckBoxXColumn)))
                {
                    DataGridViewComboBoxExColumn comboxColumn = new DataGridViewComboBoxExColumn();
                    comboxColumn.Name = colm.Name;
                    comboxColumn.HeaderText = colm.HeaderText;
                    comboxColumn.DataPropertyName = colm.DataPropertyName;
                    comboxColumn.DataSource = this.SearchConditionColumnComboxData;
                    comboxColumn.DropDownStyle = ComboBoxStyle.DropDownList;
                    colm = comboxColumn;
                }

                dtgCondition.Columns.Add(colm);
                dtgCondition.Columns[col.Name].Visible = col.Visible;
                // Disable filter column
                dtgCondition.DisableFilterAndSort(colm);
                colm = null;
            }

            // Event create new tab after finished input
            dtgCondition.CellEndEdit += CellEndEdit;
            // Checkbox clicked event
            dtgCondition.CellClick += CellClick;
            // Delete selected cell
            dtgCondition.KeyDown += KeyDown;

            // Set index 
            dtgCondition.TabIndex = dataGridViewIndex;

            GC.Collect();

            // Auto Resize columns
            dtgCondition.AutoResizeColumns();

            // Add first data
            DataGridViewRow filterRow = new DataGridViewRow();
            dtgCondition.Rows.Insert(0, filterRow);
            // Checkbook column first          
            // Set init for checkbox columns
            dtgCondition.Rows[0].Cells.Cast<DataGridViewCell>().Where(cell => cell.GetType().Equals(typeof(DataGridViewCheckBoxXCell))).ToList().ForEach(cell => cell.Value = false);

            // Add data gridview to list
            dataOrConditon.Add(dtgCondition);
            return dtgCondition;
        }

        /// <summary>
        /// User press delete button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            AdvancedDataGridView currentSource = (AdvancedDataGridView)sender;
            DeleteAllData(currentSource);
            e.Handled = true;
        }

        private void DeleteAllData(AdvancedDataGridView currentSource)
        {
            foreach (DataGridViewCell cell in currentSource.SelectedCells)
            {
                // If checkbox data rest to false
                if (cell.GetType().Equals(typeof(DataGridViewCheckBoxXCell)))
                    cell.Value = false;
                else
                    cell.Value = string.Empty;
            }
        }

        private void CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            currentDataGridViewEditing = (AdvancedDataGridView)sender;
            // If last tab create new tab condition
            if (currentDataGridViewEditing.TabIndex == tabMain.Tabs.Count)
                CreateConditionTab();

            // Auto width column fit data
            currentDataGridViewEditing.AutoResizeColumns();
        }

        /// <summary>
        /// Get data to fillter
        /// </summary>
        public DataGridViewFilterEntity GetDataFilter()
        {
            // Complete all editing cell
            if (currentDataGridViewEditing != null)
            {
                currentDataGridViewEditing.EndEdit(DataGridViewDataErrorContexts.Commit);
            }

            if (filterEntity == null)
                filterEntity = new DataGridViewFilterEntity();

            // Ignore last tab condition
            filterEntity.DataSearch = new DataGridViewRow[dataOrConditon.Count - 1];

            int index = 0;
            foreach (var dtgOrCondition in dataOrConditon)
            {
                // Over condition break
                if (index == dataOrConditon.Count - 1)
                    break;

                // Copy data row input by user
                filterEntity.DataSearch[index] = DataGridViewUtils.GetDataRows(dtgOrCondition)[0];
                index++;
            }

            return filterEntity;
        }

        /// <summary>
        /// Event for checkbox column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentDataGridViewEditing = (AdvancedDataGridView)sender;

            if (currentDataGridViewEditing.CurrentCell.GetType().Equals(typeof(DataGridViewCheckBoxXCell)))
            {
                CellEndEdit(sender, e);
            }
        }

        /// <summary>
        /// Visible column datagrid
        /// </summary>
        /// <param name="columName"></param>
        /// <param name="visible"></param>
        public void ColumnVisible(string columName, bool visible)
        {
            if (dataOrConditon == null)
                return;

            foreach (var dtgOrCondition in dataOrConditon)
            {
                dtgOrCondition.Columns[columName].Visible = visible;
            }
        }

        public void ChangeColumnDisplayIndex(DataGridViewColumnCollection columns)
        {
            if (columns == null)
                return;

            foreach (AdvancedDataGridView dtgOrCondition in dataOrConditon)
            {
                foreach (DataGridViewColumn col in dtgOrCondition.Columns)
                {
                    var columnExist = columns.Cast<DataGridViewColumn>().Where(r => r.Name.Equals(col.Name)).FirstOrDefault();
                    if (columnExist != null)
                    {
                        col.DisplayIndex = columnExist.DisplayIndex;
                        col.Visible = columnExist.Visible;
                    }
                }
            }
        }
    }
}
