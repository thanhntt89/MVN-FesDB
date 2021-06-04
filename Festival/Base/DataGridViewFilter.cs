using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FestivalObjects;
using DevComponents.DotNetBar.Controls;
using FestivalCommon;
using FestivalUtilities;
using System.Reflection;
using Zuby.ADGV;
using System.Collections.Generic;
using Festival.Base.DataGridViewColumnCustom;
using System.Globalization;

namespace Festival.Base
{
    public partial class DataGridViewFilter : UserControlBaseAdvance
    {
        public DataGridViewFilter()
        {
            InitializeComponent();
        }

        public BindingSource bindingSource_main = new BindingSource();

        private int LastSelectedColumnIndex = -1;
        private int LasSelectedRowIndex = -1;
        private int LastHorizontalScrollingOffset = 0;
        private int firstDisplayedScrollingColumnIndex = -1;
        private object dataEditing = null;
        // Cell seleted to copy or cut
        private DataGridViewSelectedCellCollection seletedCellCollection;
        private DataTable columnDataSource;
        private bool isFirstLoadData = true;
        public bool AllowUserEdit { get; set; }
        private int firstDisplayedScrollingRowIndex = 0;
        //Get Video locktype


        public void InitDataGridViewEvent()
        {
            dtgAdvMain.HorizontalScrollingOffset = LastHorizontalScrollingOffset;
            dtgAdvMain.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // Create event valuechange for datagridview first
            dtgAdvMain.CellValueChanged += dtgAdvMain_CellValueChanged;
            dtgAdvMain.CellEnter += dtgAdvMain_CellEnter;
            dtgAdvMain.EditingControlShowing += EditingControlShowing;
            dtgAdvMain.RowPostPaint += dtgAdvMain_RowPostPaint;

            dtgAdvMain.DataError += dtgAdvMain_DataError;
            dtgAdvMain.CellEndEdit += dtgAdvMain_CellEndEdit;
            dtgAdvMain.CellBeginEdit += dtgAdvMain_CellBeginEdit;
            dtgAdvMain.FilterStringChanged += dtgAdvMain_FilterStringChanged;
            dtgAdvMain.CellClick += dtgAdvMain_CellClick;
            dtgAdvMain.CellDoubleClick += dtgAdvMain_CellDoubleClick;
            dtgAdvMain.RowLeave += dtgAdvMain_RowLeave;

            if (dtgAdvMain.RowCount > 0 && dtgAdvMain.ColumnCount > 0 && LastSelectedColumnIndex > 0 && LasSelectedRowIndex >= 0 && LasSelectedRowIndex < dtgAdvMain.RowCount && dtgAdvMain.ColumnCount > LastSelectedColumnIndex)
            {
                dtgAdvMain.Rows[CurrentRowsIndex].Cells[LastSelectedColumnIndex].Selected = true;
                dtgAdvMain.CurrentCell = dtgAdvMain.Rows[LasSelectedRowIndex].Cells[LastSelectedColumnIndex];
            }

            if (dtgAdvMain.RowCount > 0 && firstDisplayedScrollingRowIndex > 0 && firstDisplayedScrollingRowIndex < dtgAdvMain.RowCount)
                dtgAdvMain.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;

            if (dtgAdvMain.ColumnCount > 0 && firstDisplayedScrollingColumnIndex > 0 && firstDisplayedScrollingColumnIndex < dtgAdvMain.ColumnCount)
                dtgAdvMain.FirstDisplayedScrollingColumnIndex = firstDisplayedScrollingColumnIndex;

            firstDisplayedScrollingRowIndex = 0;
            firstDisplayedScrollingColumnIndex = 0;
        }


        public void RemoveEventDataGridView()
        {
            LastHorizontalScrollingOffset = dtgAdvMain.HorizontalScrollingOffset;
            firstDisplayedScrollingRowIndex = dtgAdvMain.FirstDisplayedScrollingRowIndex;
            var LastColumnIndex = dtgAdvMain.FirstDisplayedScrollingColumnIndex;
            firstDisplayedScrollingColumnIndex = LastColumnIndex;

            LastSelectedColumnIndex = CurrentColumnIndex;
            LasSelectedRowIndex = CurrentRowsIndex;

            dtgAdvMain.CellValueChanged -= dtgAdvMain_CellValueChanged;
            dtgAdvMain.CellEnter -= dtgAdvMain_CellEnter;
            dtgAdvMain.EditingControlShowing -= EditingControlShowing;
            dtgAdvMain.RowPostPaint -= dtgAdvMain_RowPostPaint;
            dtgAdvMain.CellEndEdit -= dtgAdvMain_CellEndEdit;
            dtgAdvMain.CellBeginEdit -= dtgAdvMain_CellBeginEdit;
            dtgAdvMain.FilterStringChanged -= dtgAdvMain_FilterStringChanged;
            dtgAdvMain.CellClick -= dtgAdvMain_CellClick;
            dtgAdvMain.CellDoubleClick -= dtgAdvMain_CellDoubleClick;
            dtgAdvMain.RowLeave -= dtgAdvMain_RowLeave;
        }

        private void dtgAdvMain_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (RowLeaveEvent != null && dataEditing != null)
            {
                dtgAdvMain.EndEdit();
                bindingSource_main.EndEdit();
                RowLeaveEvent(dtgAdvMain.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                dataEditing = null;
            }
        }

        private void dtgAdvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellDoubleClickedEvent != null && e.RowIndex != -1)
                CellDoubleClickedEvent(dtgAdvMain.CurrentCell);
        }

        private void dtgAdvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 1 && e.ColumnIndex == -1 || e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            if (CellClickedEvent != null)
                CellClickedEvent(dtgAdvMain.CurrentCell);
        }

        private void dtgAdvMain_FilterStringChanged(object sender, AdvancedDataGridView.FilterEventArgs e)
        {
            this.IsFilterActive = !string.IsNullOrEmpty(e.FilterString);
        }

        private void dtgAdvMain_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            e.Cancel = !AllowUserEdit;
            dataEditing = dtgAdvMain.CurrentRow.Cells[e.ColumnIndex].Value;
        }

        private void dtgAdvMain_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgAdvMain.Rows.Count == 0 || string.IsNullOrWhiteSpace(ColumnUpdateTimeName) || dtgAdvMain.CurrentRow.Cells[e.ColumnIndex].Value == null || dataEditing == null || dtgAdvMain.CurrentRow.Cells[e.ColumnIndex].Value.Equals(dataEditing))
                return;
            dtgAdvMain.CurrentRow.Cells[ColumnUpdateTimeName].Value = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT);

            if (CellEndEditEvent != null)
                CellEndEditEvent(dtgAdvMain.CurrentCell);
        }

        private void dtgAdvMain_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dtgAdvMain_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DrawFirstColumIndex(sender, e);
        }

        private void DrawFirstColumIndex(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dtgAdvMain.AllowUserToAddRows && e.RowIndex > dtgAdvMain.Rows.Count - 2)
                return;
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,

                LineAlignment = StringAlignment.Center
            };
            //get the size of the string
            Size textSize = TextRenderer.MeasureText(rowIdx, this.Font);
            //if header width lower then string width then resize
            if (grid.RowHeadersWidth < textSize.Width + 40)
            {
                grid.RowHeadersWidth = textSize.Width + 40;
            }
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        /// <summary>
        /// One click column combox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ControlActive(e);
        }

        private void ControlActive(DataGridViewEditingControlShowingEventArgs e)
        {
            ComboxOneClickActive(e);
        }

        private void ComboxOneClickActive(DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBoxEx ctl = e.Control as ComboBoxEx;
            if (ctl == null)
                return;
            ctl.Enter -= new EventHandler(ComboxClick);
            ctl.Enter += new EventHandler(ComboxClick);
            ctl.SelectedIndexChanged -= Ctl_SelectedIndexChanged; ;
            ctl.Enter += Ctl_SelectedIndexChanged;

            columnDataSource = ctl.DataSource as DataTable;
        }

        private void Ctl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxEx cboSelected = sender as ComboBoxEx;
            if (cboSelected != null)
            {
                cboSelected.SelectedItem = cboSelected.SelectedValue;
            }
        }

        private void ComboxClick(object sender, EventArgs e)
        {
            (sender as ComboBoxEx).DroppedDown = true;
        }

        public override void ClearFilterAndSort()
        {
            if (dtgAdvMain == null)
                return;
            dtgAdvMain.CleanFilterAndSort();
        }

        public object GetDataByKeyIdAndField(string keyId, string fiedlName)
        {
            object obj = new object();
            DataTable dt = GetDataByKeyColumn(keyId);
            if (dt != null)
            {
                obj = dt.Rows[0][fiedlName];
            }
            return obj;
        }

        public DataTable GetDataByKeyColumn(string keyId)
        {
            return DataGridViewUtils.GetDataByColumnId(DataTableSource, ColumnKeyDataPropertyName, keyId);
        }

        public override DataTable GetUpdateData()
        {
            if (dtgAdvMain != null)
            {
                bindingSource_main.EndEdit();
                dtgAdvMain.EndEdit();
            }
            return DataGridViewUtils.GetDataUpdate(DataTableSource, ColumnUpdateTimeDataPropertyName);
        }

        public override DataTable GetUpdateAndDeletedData()
        {
            return DataGridViewUtils.GetDataUpdateAndDeleted(DataTableSource, ColumnUpdateTimeDataPropertyName, ColumnDeletedDataPropertyName, ColumnKeyDataPropertyName);
        }

        public DataTable GetDataSave()
        {
            return DataGridViewUtils.GetDataSave(DataTableSource, ColumnChoiseDataPropertyName, ColumnUpdateTimeDataPropertyName, ColumnDeletedDataPropertyName, ColumnKeyDataPropertyName);
        }

        public List<DataRow> GetAddedRowData()
        {
            return DataGridViewUtils.GetDataAddNew(DataTableSource, ColumnUpdateTimeDataPropertyName, ColumnKeyDataPropertyName);
        }

        public override DataTable GetExportData()
        {
            return DataGridViewUtils.GetDataExport(DataTableSource, ColumnUpdateTimeDataPropertyName, ColumnChoiseDataPropertyName);
        }

        public override DataTable GetDeletedData()
        {
            return DataGridViewUtils.GetDataDeleted(DataTableSource, ColumnDeletedDataPropertyName);
        }

        public override void ResetStatusUpdateColum()
        {
            if (DataTableSource == null || ColUpdatedIndex == -1)
                return;
            RemoveEventDataGridView();
            DataGridViewUtils.ResetUpdateColumn(DataTableSource, ColumnUpdateTimeDataPropertyName, ColumnDeletedDataPropertyName, ref CurrentColumnIndex, ref CurrentRowsIndex);
            InitDataGridViewEvent();
        }

        /// <summary>
        /// Event cell value change by use 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgAdvMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgAdvMain == null || dtgAdvMain.Rows.Count == 0 || ColUpdatedIndex == -1 || DataTableSource == null)
                return;

            // Display select column
            if (IsDisplayItemSeleted == true && e.ColumnIndex == ColChoiseIndex)
                DisplayItemSeleted(IsDisplayItemSeleted);

            if (this.IsFilterActive)
            {
                dtgAdvMain.TriggerFilterStringChanged();
            }
        }

        private void GetEditData(object sender, DataGridViewCellEventArgs e)
        {
            // Get current column index to frozen
            CurrentColumnIndex = e.ColumnIndex;
            CurrentRowsIndex = e.RowIndex;

            if (dtgAdvMain != null && dtgAdvMain.CurrentRow != null && !string.IsNullOrEmpty(ColumnKeyName))
                CurrentKeyValue = dtgAdvMain.CurrentRow.Cells[ColumnKeyName].Value == null ? string.Empty : dtgAdvMain.CurrentRow.Cells[ColumnKeyName].Value.ToString();

            if (CurrentColumnIndex == -1 || dtgAdvMain == null || dtgAdvMain.Rows.Count == 0)
                return;

            if (EditCellEvent != null)
                EditCellEvent(dtgAdvMain.CurrentCell);
        }

        /// <summary>
        /// Focus cell to edit when cell selected 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgAdvMain_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            GetEditData(sender, e);
        }

        /// <summary>
        /// Seleted all in datagridview
        /// </summary>
        /// <param name="isSelected"></param>
        public override void Choise(bool? isSelected)
        {
            ChoiseProcess(isSelected);
        }

        /// <summary>
        /// Count rows data
        /// </summary>
        public int Count
        {
            get
            {
                int count = 0;
                if (DataTableSource != null)
                    count = DataTableSource.Rows.Count;
                return count;
            }
        }

        private void UpdateColumnChoise(bool isSelected)
        {
            ColumnUpdateEntity columns = new ColumnUpdateEntity()
            {
                ColumnKeyDataPropertyName = ColumnKeyDataPropertyName,
                ColumnCurrentUpdateDataPropertyName = ColumnChoiseDataPropertyName,
                DataUpdate = isSelected
            };
            Invoke(new Action(() =>
            {
                dtgAdvMain.CleanFilterAndSort();
            }));

            if (!string.IsNullOrWhiteSpace(bindingSource_main.Filter) || !string.IsNullOrWhiteSpace(DataTableSource.DefaultView.RowFilter))
                DataGridViewUtils.UpdateColum(DataTableSource, columns, ref CurrentColumnIndex, ref CurrentRowsIndex);
            else
            {
                DataTableSource.AsEnumerable()//.Where(row => row.Field<bool>(ColumnChoiseDataPropertyName) == !(bool)isSelected)
                          .Select(b => b[ColumnChoiseDataPropertyName] = (bool)isSelected)
                          .ToList();
            }
        }

        /// <summary>
        /// Process to run waiting form 
        /// </summary>
        /// <param name="isSelected"></param>
        private void ChoiseProcess(bool? isSelected)
        {
            if (DataTableSource == null)
                return;

            RemoveEventDataGridView();

            bgwProcess = CreateThread();
            bgwProcess.RunWorkerCompleted += ChoiseProcess_RunWorkerCompleted;
            bgwProcess.DoWork += ChoiseProcess_DoWork;
            bgwProcess.RunWorkerAsync(isSelected);

            this.ShowWating();
        }

        private void ChoiseProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateColumnChoise((bool)e.Argument);
        }

        private void ChoiseProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            InitDataGridViewEvent();
            if (bgwProcess != null)
            {
                bgwProcess.RunWorkerCompleted -= ChoiseProcess_RunWorkerCompleted;
                bgwProcess.DoWork -= ChoiseProcess_DoWork;
            }

            this.ClosedWaiting();
            bgwProcess = null;
            GC.Collect();
        }

        /// <summary>
        /// Check datagrid view has data
        /// </summary>
        public bool HasData
        {
            get
            {
                return dtgAdvMain.DisplayedRowCount(true) == 0 ? false : true;
            }
        }

        public override bool IsDataUpdated
        {
            get
            {
                return DataGridViewUtils.HasUpdateData(DataTableSource, ColumnUpdateTimeDataPropertyName, ColumnDeletedDataPropertyName);
            }
        }

        /// <summary>
        /// Define columns and type
        /// </summary>
        public override void InitData()
        {
            if (dtgAdvMain == null || dtgAdvMain.Columns.Count > 0 || DataGridViewSource == null)
                return;

            Invoke(new Action(() =>
            {
                DataTableSource = new DataTable();

                foreach (DataGridViewColumn col in DataGridViewSource.Columns)
                {
                    var column = (DataGridViewColumn)col.Clone();

                    column.ReadOnly = col.ReadOnly;
                    column.DisplayIndex = col.DisplayIndex;

                    if (column.GetType().Equals(typeof(DataGridViewCheckBoxXColumn)))
                    {
                        var dataGridViewCellStyle1 = new DataGridViewCellStyle();
                        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle = dataGridViewCellStyle1;

                        DataTableSource.Columns.Add(col.DataPropertyName, typeof(bool));
                    }
                    else
                    // Format column datetime with fit input control
                    if (column.GetType().Equals(typeof(DataGridViewDateTimeInputColumn)))
                    {
                        column.MinimumWidth = 110;
                        DataTableSource.Columns.Add(col.DataPropertyName, typeof(DateTime));
                    }
                    else
                    // Format column datetime with fit input control
                    if (column.GetType().Equals(typeof(DataGridViewNumericColumn)))
                    {
                        DataTableSource.Columns.Add(col.DataPropertyName, typeof(int));
                    }
                    else
                    // Format column datetime with fit input control
                    if (column.GetType().Equals(typeof(DataGridViewTextBoxColumn)) || column.GetType().Equals(typeof(DataGridViewComboBoxExColumn)))
                    {
                        DataTableSource.Columns.Add(col.DataPropertyName, typeof(string));
                    }

                    column.SortMode = DataGridViewColumnSortMode.NotSortable;

                    dtgAdvMain.Columns.Add(column);

                    if (column.GetType().Equals(typeof(DataGridViewDateTimeInputColumn)))
                    {
                        dtgAdvMain.SetFilterDateAndTimeEnabled(column, true);
                    }
                    // Remove filter
                    if (column.DataPropertyName.Contains("Delete"))
                    {
                        dtgAdvMain.DisableFilterAndSort(column);
                    }
                }

                dtgAdvMain.Name = DataGridViewSource.Name;

                //Load config header
                dtgAdvMain.LoadConfiguration();

                // Set datasource            
                dtgAdvMain.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                dtgAdvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dtgAdvMain.AllowUserToAddRows = DataGridViewSource.AllowUserToAddRows;
                dtgAdvMain.AllowUserToDeleteRows = DataGridViewSource.AllowUserToDeleteRows;

                dtgAdvMain.AllowUserToOrderColumns = true;
                // Init event clear filter and sort               
                mnSearchToolBar.SetColumns(dtgAdvMain.Columns);
                dtgAdvMain.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            }));
        }

        /// <summary>
        /// Display data
        /// </summary>
        public override void LoadData()
        {
            if (DataTableSource == null || DataTableSource.Rows.Count == 0)
            {
                dtgAdvMain.AutoGenerateColumns = false;
            }

            RemoveEventDataGridView();

            bindingSource_main.DataSource = DataTableSource;
            // Performance loading datasource
            dtgAdvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dtgAdvMain.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dtgAdvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dtgAdvMain.RowHeadersVisible = false;
            dtgAdvMain.SetDoubleBuffered();
            dtgAdvMain.DataSource = bindingSource_main;
            dtgAdvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dtgAdvMain.RowHeadersVisible = true;

            bindingSource_main.Filter = string.Empty;
            // dtgAdvMain.LoadConfiguration();
            if (isFirstLoadData && !dtgAdvMain.IsLoadConfig)
            {
                DataGridViewUtils.FastAutoSizeColumns(dtgAdvMain);
                isFirstLoadData = false;
            }

            if (IsDisplayItemSeleted != null && (bool)IsDisplayItemSeleted)
            {
                DisplayItemSeleted(IsDisplayItemSeleted);
            }

            dtgAdvMain.CleanFilterAndSort();
            navDataGridView.EnableClearFilterAndSortButton();
            InitDataGridViewEvent();
        }

        /// <summary>
        /// Display header cell columns
        /// </summary>
        public override void CreateFilter()
        {
            if (dtgAdvMain == null)
                return;
            foreach (DataGridViewColumn col in dtgAdvMain.Columns)
            {
                dtgAdvMain.EnableFilterAndSort(col);
            }
        }

        public override void UnFilter()
        {
            if (bindingSource_main == null)
                return;
            this.IsFilterActive = false;
            bindingSource_main.RemoveFilter();
        }

        public override void ApplyFilter(DataGridViewFilterEntity dataGridViewFilter)
        {
            if (dataGridViewFilter == null || DataTableSource == null)
                return;

            RemoveEventDataGridView();
            this.IsFilterActive = true;
            DataGridViewUtils.Filter(bindingSource_main, dataGridViewFilter);
            InitDataGridViewEvent();
        }

        public override void Frozen(bool? isFrozen)
        {
            DataGridViewUtils.Frozen(isFrozen, dtgAdvMain, CurrentColumnIndex);
        }

        public override void UpdateCell(DataGridViewCell cell, object data)
        {
            if (dtgAdvMain.Rows.Count == 0 || cell.ColumnIndex == -1 || cell.RowIndex == -1 || cell.RowIndex > dtgAdvMain.Rows.Count - 1)
                return;

            string keyId = dtgAdvMain.Rows[cell.RowIndex].Cells[ColumnKeyName].Value.ToString();
            RemoveEventDataGridView();
            UpdateTableSource(keyId, cell.OwningColumn.DataPropertyName, data);
            InitDataGridViewEvent();
        }

        private void UpdateTableSource(string keyId, string columUpdateDataPropertyName, object data)
        {
            if (string.IsNullOrWhiteSpace(ColumnUpdateTimeDataPropertyName) || string.IsNullOrWhiteSpace(columUpdateDataPropertyName) || string.IsNullOrWhiteSpace(ColumnKeyDataPropertyName))
                return;
            string columDateTimeUpdate = ColumnUpdateTimeDataPropertyName;
            if (columUpdateDataPropertyName.Equals(ColumnDeletedDataPropertyName) || columUpdateDataPropertyName.Equals(ColumnChoiseDataPropertyName))
                columDateTimeUpdate = string.Empty;
            int currentHorizontalScrollingOffset = dtgAdvMain.HorizontalScrollingOffset;
            DataGridViewUtils.UpdateDataSource(bindingSource_main, ColumnKeyDataPropertyName, columDateTimeUpdate, columUpdateDataPropertyName, keyId, data, ref CurrentColumnIndex, ref CurrentRowsIndex);

            dtgAdvMain.HorizontalScrollingOffset = currentHorizontalScrollingOffset;
        }

        public void ExecuteUpdateColumn(bool isBulkUpdate, DataTable tbData, ColumnDisplayDataCollection Columns, DataGridViewCell cell, object data)
        {
            RemoveEventDataGridView();

            CurrentColumnIndex = cell.ColumnIndex;
            CurrentRowsIndex = cell.RowIndex;

            if (isBulkUpdate)
            {
                DataTable dtFilter = DataTableSource.DefaultView.ToTable();
                if (dtFilter.Rows.Count == 0)
                {
                    dtFilter = DataTableSource;
                }
                foreach (DataRow row in dtFilter.Rows)
                {
                    string keyId = row[ColumnKeyDataPropertyName].ToString();
                    ExecuteUpdateDataColumn(keyId, tbData, Columns);
                    UpdateTableSource(keyId, cell.OwningColumn.DataPropertyName, data);
                }
            }
            else
            {
                if (cell.RowIndex == -1) return;

                string keyId = dtgAdvMain.Rows[cell.RowIndex].Cells[ColumnKeyName].Value.ToString();
                UpdateTableSource(keyId, cell.OwningColumn.DataPropertyName, data);
                ExecuteUpdateDataColumn(keyId, tbData, Columns);
            }

            InitDataGridViewEvent();
        }

        private void ExecuteUpdateDataColumn(string keyId, DataTable dtValues, ColumnDisplayDataCollection columns)
        {
            if (dtValues == null || columns == null || columns.CollumnList.Count == 0)
                return;
            object data = null;
            foreach (ColumnDisplayEntity col in columns.CollumnList)
            {
                data = dtValues.Rows.Count == 0 ? DBNull.Value : dtValues.Rows[0][col.DataPropertyName];

                UpdateTableSource(keyId, col.DataPropertyName, data);
            }
        }

        public override void DisplayItemSeleted(bool? isDisplayItemSeleted)
        {
            if (DataTableSource == null || isDisplayItemSeleted == null)
                return;

            if (isDisplayItemSeleted == false)
            {
                // Reset index
                CurrentRowsIndex = -1;
            }

            DataGridViewUtils.DisplayRowSelected(dtgAdvMain, DataTableSource, ColumnChoiseDataPropertyName, (bool)isDisplayItemSeleted, CurrentRowsIndex);

            // Save current display status
            this.IsDisplayItemSeleted = isDisplayItemSeleted;
        }

        public override void UpdateColumnSelected(DataGridViewCell cell, object data)
        {
            if (CurrentColumnIndex == -1 || DataTableSource == null)
                return;
            CurrentColumnDataPropertyName = cell.OwningColumn.DataPropertyName;
            CurrentColumnName = cell.OwningColumn.Name;
            UpdateColumnProccess(data);
        }

        private void UpdateColumnProccess(object updateValue)
        {
            // End edit current cell before update column 
            if (dtgAdvMain == null || dtgAdvMain.Rows.Count == 0 || CurrentColumnIndex == -1 || CurrentColumnIndex == ColChoiseIndex || string.IsNullOrEmpty(ColumnUpdateTimeDataPropertyName))
                return;

            RemoveEventDataGridView();

            bgwProcess = CreateThread();
            bgwProcess.RunWorkerCompleted += UpdateColumn_RunWorkerCompleted;
            bgwProcess.DoWork += UpdateColumn_DoWork;

            bgwProcess.RunWorkerAsync(updateValue);
            this.ShowWating();
        }

        private void UpdateColumn_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateColumns(e.Argument);
        }

        private void UpdateColumns(object data)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    ColumnUpdateEntity columns = new ColumnUpdateEntity()
                    {
                        ColumnKeyDataPropertyName = ColumnKeyDataPropertyName,
                        ColumnCurrentUpdateDataPropertyName = CurrentColumnDataPropertyName,
                        ColumnUpdateDateTimeDataPropertyName = CurrentColumnName.Equals(ColumnDeletedName) ? string.Empty : ColumnUpdateTimeDataPropertyName,
                        DataUpdate = data
                    };
                    DataGridViewUtils.UpdateColum(DataTableSource, columns, ref CurrentColumnIndex, ref CurrentRowsIndex);
                }));
            }
            catch (Exception ex)
            {
                this.ClosedWaiting();
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = Constants.LOG_FILE_PATH_ERROR
                };

                LogException(error);
                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        private void UpdateColumn_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            InitDataGridViewEvent();

            this.ClosedWaiting();
            if (bgwProcess != null)
            {
                bgwProcess.RunWorkerCompleted -= UpdateColumn_RunWorkerCompleted;
                bgwProcess.DoWork -= UpdateColumn_DoWork;
            }
            bgwProcess = null;
            GC.Collect();
        }

        public override void Sort(SortType sortType)
        {
            if (dtgAdvMain == null || dtgAdvMain.Rows.Count == 0 || CurrentColumnIndex == -1)
                return;
            try
            {
                RemoveEventDataGridView();

                if (sortType == SortType.AtoZ)
                    dtgAdvMain.SortASC(dtgAdvMain.Columns[CurrentColumnIndex]);
                else if (sortType == SortType.ZtoA)
                    dtgAdvMain.SortDESC(dtgAdvMain.Columns[CurrentColumnIndex]);
                else
                    dtgAdvMain.CleanSort();

                InitDataGridViewEvent();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = Constants.LOG_FILE_PATH_ERROR
                };

                LogException(error);
            }
        }

        public override void SetColumnVisible(string columnName, bool isVisible)
        {
            if (dtgAdvMain == null)
                return;
            // Visible column
            DataGridViewUtils.ColumnVisible(dtgAdvMain, columnName, isVisible);
            navDataGridView.InitHScroll();
        }

        public override void Cut()
        {
            seletedCellCollection = null;
            if (dtgAdvMain == null || dtgAdvMain.CurrentCell == null || dtgAdvMain.CurrentCell.IsInEditMode)
                return;
            try
            {
                Clipboard.Clear();

                // Copy data to clipboard
                Clipboard.SetDataObject(dtgAdvMain.GetClipboardContent(), true, 10, 200);
                //Save all cut cell
                seletedCellCollection = dtgAdvMain.SelectedCells;

            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = Constants.LOG_FILE_PATH_ERROR
                };

                LogException(error);
                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        public override void Copy()
        {
            if (dtgAdvMain == null || dtgAdvMain.CurrentCell == null || dtgAdvMain.CurrentCell.IsInEditMode)
                return;
            try
            {
                // Get scroll before copy
                int position = dtgAdvMain.HorizontalScrollingOffset;
                // Removed first tab
                dtgAdvMain.RowHeadersVisible = false;
                //Copy with header
                if (dtgAdvMain.CountSeletedColumn > 1)
                    dtgAdvMain.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                else // Copy without header
                    dtgAdvMain.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

                Clipboard.Clear();

                DataObject copyData = dtgAdvMain.GetClipboardContent();

                dtgAdvMain.RowHeadersVisible = true;
                //Set scroll position after copy
                dtgAdvMain.HorizontalScrollingOffset = position;

                // Copy data to clipboard
                Clipboard.SetDataObject(copyData, true, 10, 200);
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = Constants.LOG_FILE_PATH_ERROR
                };

                LogException(error);
                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        /// <summary>
        /// Paste data to cell
        /// </summary>
        public override void Paste()
        {
            try
            {                
                Pastes();
            }
            catch (Exception ex)
            {
                // Exception no same type
                if (ex.Message.Equals(GetResources.GetResourceMesssage(Constants.EXPASTE003)))
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = Constants.LOG_FILE_PATH_ERROR
                };

                LogException(error);
                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        /// <summary>
        /// Paste value copy and cut 
        /// </summary>
        /// <param name="dataGridView"></param>
        private void Pastes()
        {
            if (dtgAdvMain == null || dtgAdvMain.CurrentCell == null || dtgAdvMain.CurrentCell.IsInEditMode)
                return;

            try
            {
                // Get all data  from clipboard
                string data = Clipboard.GetText();
                string[] lines = data.Split('\n');

                int iFail = 0;
                int iRow = dtgAdvMain.CurrentCell.RowIndex;
                int iCol = dtgAdvMain.CurrentCell.ColumnIndex;

                DataGridViewCell oCell;

                foreach (string line in lines)
                {
                    if (iRow > dtgAdvMain.RowCount || line.Length < 0)
                    {
                        break;
                    }

                    string[] sCells = line.Replace("\r", "").Split('\t');

                    for (int i = 0; i < sCells.GetLength(0); ++i)
                    {
                        if (iCol + i > dtgAdvMain.ColumnCount)
                        {
                            break;
                        }

                        oCell = dtgAdvMain[iCol + i, iRow];

                        if (oCell.ReadOnly)
                        {
                            // throw new ArgumentException(string.Format(GetResources.GetResourceMesssage(Constants.EXPASTE001), iFail));
                            return;
                        }

                        if (!CheckValidCell(oCell, data))
                        {
                            MessageBox.Show(string.Format("存在する{0}を指定してください。", oCell.OwningColumn.HeaderText), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        UpdateCell(oCell, data);
                        //oCell.Value = Convert.ChangeType(sCells[i], oCell.FormattedValueType);
                    }

                    iRow++;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException(GetResources.GetResourceMesssage(Constants.EXPASTE003));
            }
        }

        private bool CheckValidCell(DataGridViewCell cell, object data)
        {
            if (cell == null)
                return false;
            int MaxLength = 0;
            int MinLength = 0;
            if (data == null || data == DBNull.Value || string.IsNullOrWhiteSpace(data.ToString()))
                return true;

            if (cell.GetType().Equals(typeof(DataGridViewNumericCell)))
            {
                MaxLength = ((DataGridViewNumericColumn)cell.OwningColumn).MaxInputLength;
                MinLength = ((DataGridViewNumericColumn)cell.OwningColumn).MinInputLength;

                if (data.ToString().Length > MaxLength || data.ToString().Length < MinLength)
                    return false;

                return Utils.IsNumeric(data.ToString());
            }
            if (cell.GetType().Equals(typeof(DataGridViewTextBoxCell)))
            {
                MaxLength = ((DataGridViewTextBoxColumn)cell.OwningColumn).MaxInputLength;
                if (data.ToString().Length > MaxLength || data.ToString().Length < MinLength)
                    return false;
            }
            if (cell.GetType().Equals(typeof(DataGridViewDateTimeInputCell)))
            {
                DateTime dateValue = DateTime.MinValue;
                string[] formats = {"M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt",
                   "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss","yyyy/MM/dd","yyyyMMdd","yyyy/MM/dd HH:mm:ss",
                   "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt",
                   "M/d/yyyy h:mm", "M/d/yyyy h:mm",
                   "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm"};

                DateTime.TryParseExact(data.ToString(), formats, null,
                               DateTimeStyles.AllowWhiteSpaces |
                               DateTimeStyles.AdjustToUniversal,
                               out dateValue);

                return dateValue != DateTime.MinValue;
            }
            if (cell.GetType().Equals(typeof(DataGridViewComboBoxExCell)))
            {
                var cbo = (DataGridViewComboBoxExColumn)cell.OwningColumn;
                DataTable dtSource = cbo.DataSource as DataTable;
                var exist = dtSource.AsEnumerable().Where(r => r.Field<object>(0) != null && r.Field<object>(0).ToString().Equals(data.ToString())).FirstOrDefault();
                if (exist == null)
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Set value for cell after cut
        /// </summary>
        private void SetValueCellActionCut()
        {
            if (seletedCellCollection == null)
                return;

            // Set cell empty
            try
            {
                seletedCellCollection.Cast<DataGridViewCell>().ToList().ForEach(cell => cell.Value = DBNull.Value);
            }
            catch
            {
            }
            // reset
            seletedCellCollection = null;
        }

        public override AdvancedDataGridView GetDataGridViewSource()
        {
            return this.dtgAdvMain;
        }

        private void advancedDataGridViewSearchToolBar_Search(object sender, AdvancedDataGridViewSearchToolBarSearchEventArgs e)
        {
            if (dtgAdvMain.Rows.Count == 0)
                return;
            bool restartsearch = true;
            int startColumn = 0;
            int startRow = 0;
            if (!e.FromBegin)
            {
                bool endcol = dtgAdvMain.CurrentCell.ColumnIndex + 1 >= dtgAdvMain.ColumnCount;
                bool endrow = dtgAdvMain.CurrentCell.RowIndex + 1 >= dtgAdvMain.RowCount;

                if (endcol && endrow)
                {
                    startColumn = dtgAdvMain.CurrentCell.ColumnIndex;
                    startRow = dtgAdvMain.CurrentCell.RowIndex;
                }
                else
                {
                    startColumn = endcol ? 0 : dtgAdvMain.CurrentCell.ColumnIndex + 1;
                    startRow = dtgAdvMain.CurrentCell.RowIndex + (endcol ? 1 : 0);
                }
            }

            DataGridViewCell c = dtgAdvMain.FindCell(
                e.ValueToSearch,
                e.ColumnToSearch != null ? e.ColumnToSearch.Name : null,
                startRow,
                startColumn,
                e.WholeWord,
                e.CaseSensitive);
            if (c == null && restartsearch)
                c = dtgAdvMain.FindCell(
                    e.ValueToSearch,
                    e.ColumnToSearch != null ? e.ColumnToSearch.Name : null,
                    0,
                    0,
                    e.WholeWord,
                    e.CaseSensitive);
            if (c != null)
                dtgAdvMain.CurrentCell = c;

        }

        public override DataGridViewColumnCollection GetDataGridViewColumns()
        {
            if (dtgAdvMain == null)
                return null;
            return dtgAdvMain.Columns;
        }

        public DataGridViewCell GetCellInCurrentRowByColumnName(string columName)
        {
            return dtgAdvMain.CurrentRow.Cells[columName];
        }

        /// <summary>
        /// Get all id selected
        /// </summary>
        public List<string> GetDisplayedIdList(bool isSelected = false)
        {
            List<string> contentSelected = new List<string>();
            if (dtgAdvMain == null)
                return contentSelected;

            dtgAdvMain.EndEdit();

            if (isSelected)
            {
                // All data with filter 
                contentSelected = DataTableSource.AsEnumerable().Where(r => (bool)r[ColumnChoiseDataPropertyName]).Select(r => r[ColumnKeyDataPropertyName].ToString()).ToList();
            }
            else if (this.IsFilterActive)
            {
                contentSelected = dtgAdvMain.Rows.Cast<DataGridViewRow>().Select(r => r.Cells[ColumnKeyName].Value.ToString()).ToList();
            }

            return contentSelected;
        }

        public void AddNewRow(RowAddNewObject rowAddObject)
        {
            if (DataTableSource == null || rowAddObject == null || rowAddObject.Columns == null)
                return;

            RemoveEventDataGridView();

            ClearFilterAndSort();

            int rowIndex = DataTableSource.Rows.Count - 1;
            // Add new row
            DataTableSource.Rows.Add();
            DataTableSource.Rows[rowIndex + 1][ColumnKeyDataPropertyName] = rowAddObject.KeyId;

            // Set column check is false
            var columnCheck = DataTableSource.Columns.Cast<DataColumn>().Where(r => r.DataType.Equals(typeof(bool))).ToList();
            foreach (DataColumn col in columnCheck)
            {
                DataTableSource.Rows[rowIndex + 1][col.ColumnName] = false;
            }

            // Update column bulk insert            
            foreach (var colm in rowAddObject.Columns)
            {
                UpdateTableSource(rowAddObject.KeyId, colm.ColumnDataPropertyName, colm.Data);
            }

            InitDataGridViewEvent();
            GC.Collect();
            if (dtgAdvMain.RowCount >= 1)
                dtgAdvMain.FirstDisplayedScrollingRowIndex = dtgAdvMain.RowCount - 1;
            if (rowIndex > 0)
                dtgAdvMain.Rows[rowIndex - 1].Selected = false;
            dtgAdvMain.Rows[rowIndex + 1].Selected = true;
        }

        public void RemoveRow(string keyId)
        {
            if (DataTableSource == null || string.IsNullOrWhiteSpace(keyId) || string.IsNullOrWhiteSpace(ColumnKeyDataPropertyName))
                return;
            DataRow removeRow = DataTableSource.AsEnumerable().Where(r => r.Field<object>(ColumnKeyDataPropertyName).ToString().Equals(keyId)).FirstOrDefault();
            if (removeRow != null)
                DataTableSource.Rows.Remove(removeRow);
        }


        public void SetRowSeleted(string id, string columName)
        {
            if (dtgAdvMain == null || dtgAdvMain.Rows.Count == 0)
                return;
            dtgAdvMain.ClearSelection();
            var exist = dtgAdvMain.Rows.Cast<DataGridViewRow>().Where(r => r.Cells[ColumnKeyName].Value.ToString().Equals(id)).FirstOrDefault();
            if (exist != null)
            {
                dtgAdvMain.CurrentCell = dtgAdvMain.Rows[exist.Index].Cells[columName];
            }
        }

        private void DataGridViewFilter_Load(object sender, EventArgs e)
        {
            this.dtgAdvMain.Size = new Size(this.Size.Width, this.Size.Height - navDataGridView.Height - mnSearchToolBar.Height - 5);
            this.navDataGridView.Location = new Point(0, this.dtgAdvMain.Height);
            this.navDataGridView.Size = new Size(this.dtgAdvMain.Width, this.navDataGridView.Height);
        }

        public void ColumnAutoSizeMode(DataGridViewColumn column)
        {
            if (dtgAdvMain == null || column == null || dtgAdvMain.Columns.Count == 0)
                return;

            try
            {
                var checkExist = dtgAdvMain.Columns.Cast<DataGridViewColumn>().Where(r => r.Name.Equals(column.Name)).FirstOrDefault();
                if (checkExist == null)
                {
                    return;
                }

                dtgAdvMain.Columns[column.Name].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dtgAdvMain.Columns[column.Name].AutoSizeMode = column.AutoSizeMode;
                dtgAdvMain.Columns[column.Name].Width = column.Width;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void SaveConfig()
        {
            dtgAdvMain.SaveConfiguration();
        }


        private void UpdateVideoLockStatuColum(DataGridViewCell columnUpdateCell, DataTable tbVideoLock, IList<string> festaLocks, object data)
        {
            if (string.IsNullOrWhiteSpace(ColumnVideoCodeDataPropertyName) || string.IsNullOrWhiteSpace(ColumnVideoLockTypeDataPropertyName) || string.IsNullOrWhiteSpace(ColumnVideoContentTypeDataPropertyName))
                return;
            RemoveEventDataGridView();

            CurrentColumnIndex = columnUpdateCell.ColumnIndex;
            CurrentRowsIndex = columnUpdateCell.RowIndex;

            string lockTypeText = string.Empty;

            object contentType = null;
            object videoCode = null;
            object lockType = null;
            object updateValue = data;

            DataTable dtView = this.DataTableSource.DefaultView.ToTable();

            if (dtView == null || dtView.Rows.Count == 0)
                return;

            foreach (DataRow row in dtView.Rows)
            {
                DataRow updateRow = this.DataTableSource.AsEnumerable().Where(r => r.Field<object>(ColumnKeyDataPropertyName).ToString().Equals(row[ColumnKeyDataPropertyName].ToString())).FirstOrDefault();
                if (updateRow == null) continue;

                lockTypeText = string.Empty;

                contentType = row[ColumnVideoContentTypeDataPropertyName];

                if (columnUpdateCell.OwningColumn.DataPropertyName.Equals(ColumnVideoCodeDataPropertyName))
                {
                    lockType = row[ColumnVideoLockTypeDataPropertyName];
                    videoCode = updateValue;
                }
                else if (columnUpdateCell.OwningColumn.DataPropertyName.Equals(ColumnVideoLockTypeDataPropertyName))
                {
                    videoCode = row[ColumnVideoCodeDataPropertyName];
                    lockType = updateValue;
                }

                //Lock by user on layout
                if (lockType != null && lockType.ToString().Equals("1"))
                {
                    lockTypeText = string.Format("{0}/", Constants.VIDEO_LOCK_TYPE_INDIVIDUAL);
                }

                if (videoCode != null && videoCode != DBNull.Value)
                {
                    var checkVideoLock = tbVideoLock.AsEnumerable().Where(r => r.Field<object>("VideoCode").ToString().Trim().Equals(videoCode.ToString().Trim()));
                    if (checkVideoLock != null && checkVideoLock.Count() > 0)
                    {
                        //Lockvideo code in table lock
                        lockTypeText += string.Format("{0}/", Constants.VIDEO_LOCK_TYPE_NO_CHANGE);
                    }
                }

                if (festaLocks != null)
                {
                    if (contentType != null && festaLocks.Contains(contentType.ToString()))
                    {
                        lockTypeText += string.Format("{0}/", Constants.VIDEO_LOCK_TYPE_FESTA);
                    }
                }
                //Removed last sepread character 
                if (lockTypeText.Length > 0 || lockTypeText.LastIndexOf('/', lockTypeText.Length - 1) == 0)
                    lockTypeText = lockTypeText.Remove(lockTypeText.Length - 1, 1);

                if (updateValue != null && string.IsNullOrWhiteSpace(updateValue.ToString()) || updateValue == null)
                    updateRow[columnUpdateCell.OwningColumn.DataPropertyName] = DBNull.Value;
                else
                    updateRow[columnUpdateCell.OwningColumn.DataPropertyName] = updateValue;

                updateRow[ColumnVideoLockTypeTextDataPropertyName] = lockTypeText;
                updateRow[ColumnUpdateTimeDataPropertyName] = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT);
            }

            this.DataTableSource.AcceptChanges();

            InitDataGridViewEvent();
        }

        private void UpdateVideoLockStatusColumnSigleCell(DataGridViewCell columnUpdateCell, DataTable tbVideoLock, IList<string> festaLocks, object data)
        {
            RemoveEventDataGridView();

            CurrentColumnIndex = columnUpdateCell.ColumnIndex;
            CurrentRowsIndex = columnUpdateCell.RowIndex;

            string lockTypeText = string.Empty;

            object contentType = null;
            object videoCode = null;
            object lockType = null;
            object updateValue = data;

            DataRow updateRow = this.DataTableSource.AsEnumerable().Where(r => r.Field<object>(ColumnKeyDataPropertyName).ToString().Equals(CurrentKeyValue)).FirstOrDefault();

            if (updateRow == null) return;

            lockTypeText = string.Empty;

            contentType = updateRow[ColumnVideoContentTypeDataPropertyName];

            if (columnUpdateCell.OwningColumn.DataPropertyName.Equals(ColumnVideoCodeDataPropertyName))
            {
                lockType = updateRow[ColumnVideoLockTypeDataPropertyName];
                videoCode = updateValue;
            }
            else if (columnUpdateCell.OwningColumn.DataPropertyName.Equals(ColumnVideoLockTypeDataPropertyName))
            {
                videoCode = updateRow[ColumnVideoCodeDataPropertyName];
                lockType = updateValue;
            }

            //Lock by user on layout
            if (lockType != null && lockType.ToString().Equals("1"))
            {
                lockTypeText = string.Format("{0}/", Constants.VIDEO_LOCK_TYPE_INDIVIDUAL);
            }

            if (videoCode != null && videoCode != DBNull.Value)
            {
                var checkVideoLock = tbVideoLock.AsEnumerable().Where(r => r.Field<object>("VideoCode").ToString().Trim().Equals(videoCode.ToString().Trim()));
                if (checkVideoLock != null && checkVideoLock.Count() > 0)
                {
                    //Lockvideo code in table lock
                    lockTypeText += string.Format("{0}/", Constants.VIDEO_LOCK_TYPE_NO_CHANGE);
                }
            }

            if (festaLocks != null)
            {
                if (contentType != null && festaLocks.Contains(contentType.ToString()))
                {
                    lockTypeText += string.Format("{0}/", Constants.VIDEO_LOCK_TYPE_FESTA);
                }
            }
            //Removed last sepread character 
            if (lockTypeText.Length > 0 || lockTypeText.LastIndexOf('/', lockTypeText.Length - 1) == 0)
                lockTypeText = lockTypeText.Remove(lockTypeText.Length - 1, 1);

            if (updateValue != null && string.IsNullOrWhiteSpace(updateValue.ToString()) || updateValue == null)
                updateRow[columnUpdateCell.OwningColumn.DataPropertyName] = DBNull.Value;
            else
                updateRow[columnUpdateCell.OwningColumn.DataPropertyName] = updateValue;

            updateRow[ColumnVideoLockTypeTextDataPropertyName] = lockTypeText;
            updateRow[ColumnUpdateTimeDataPropertyName] = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT);

            this.DataTableSource.AcceptChanges();

            InitDataGridViewEvent();
        }

        public void UpdateVideoLockColumn(bool isBulkUpdate, DataGridViewCell columnUpdateCell, object data, DataTable tbVideoLock = null, IList<string> festaLocks = null)
        {
            if (columnUpdateCell.OwningColumn.DataPropertyName.Equals(ColumnVideoLockTypeDataPropertyName))
            {
                //Check value
                var cbo = (DataGridViewComboBoxExColumn)columnUpdateCell.OwningColumn;
                DataTable dtSource = cbo.DataSource as DataTable;
                var exist = dtSource.AsEnumerable().Where(r => r.Field<object>(0).Equals(data)).FirstOrDefault();
                if (exist == null && !string.IsNullOrEmpty(data.ToString()))
                {
                    MessageBox.Show(string.Format("存在する{0}を指定してください。", columnUpdateCell.OwningColumn.HeaderText), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (columnUpdateCell.OwningColumn.DataPropertyName.Equals(ColumnVideoCodeDataPropertyName) || columnUpdateCell.OwningColumn.DataPropertyName.Equals(ColumnVideoLockTypeDataPropertyName))
            {
                if (isBulkUpdate)
                {
                    UpdateVideoLockStatuColum(columnUpdateCell, tbVideoLock, festaLocks, data);
                }
                else
                {
                    UpdateVideoLockStatusColumnSigleCell(columnUpdateCell, tbVideoLock, festaLocks, data);
                }
            }
        }
    }
}
