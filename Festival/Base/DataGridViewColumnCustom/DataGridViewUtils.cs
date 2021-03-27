using DevComponents.DotNetBar.Controls;
using FestivalCommon;
using FestivalObjects;
using FestivalUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Zuby.ADGV;

namespace Festival.Base
{
    public class DataGridViewUtils
    {
        public static void FastAutoSizeColumns(DataGridViewX targetGrid)
        {
            // Cast out a DataTable from the target grid datasource.
            // We need to iterate through all the data in the grid and a DataTable supports enumeration.
            var gridTable = (DataTable)targetGrid.DataSource;

            // Create a graphics object from the target grid. Used for measuring text size.
            using (var gfx = targetGrid.CreateGraphics())
            {
                // Iterate through the columns.
                for (int i = 0; i < gridTable.Columns.Count; i++)
                {
                    // Leverage Linq enumerator to rapidly collect all the rows into a string array, making sure to exclude null values.
                    string[] colStringCollection = gridTable.AsEnumerable().Where(r => r.Field<object>(i) != null).Select(r => r.Field<object>(i).ToString().Trim()).ToArray();

                    // Sort the string array by string lengths.
                    colStringCollection = colStringCollection.OrderBy((x) => x.Length).ToArray();

                    if (colStringCollection.Count() == 0)
                        continue;

                    // targetGrid.Columns[i].HeaderText.Length;

                    // Get the last and longest string in the array.
                    string longestColString = colStringCollection.Last();

                    // Use the graphics object to measure the string size.
                    int colWidth = (int)gfx.MeasureString(longestColString, targetGrid.Font).Width;

                    int headerTitleWidth = (int)gfx.MeasureString(targetGrid.Columns[i].HeaderText, targetGrid.Font).Width + 20;
                    int currentHeaderWidth = targetGrid.Columns[i].Width;

                    // If the calculated width is larger than the column header width, set the new column width.
                    if (colWidth > currentHeaderWidth)//targetGrid.Columns[i].HeaderCell.Size.Width)
                    {
                        targetGrid.Columns[i].Width = colWidth > 2 * currentHeaderWidth ? 2 * currentHeaderWidth : colWidth;
                    }
                    else if (headerTitleWidth > currentHeaderWidth) // Otherwise, set the column width to the header width.
                    {
                        targetGrid.Columns[i].Width = currentHeaderWidth > headerTitleWidth ? currentHeaderWidth : 2 * headerTitleWidth - currentHeaderWidth;
                    }

                }
            }
        }

        public static void FastAutoSizeColumns(AdvancedDataGridView targetGrid)
        {
            // BindingSource bs = new BindingSource();
            // bs.DataSource = targetGrid.DataSource;
            BindingSource bs = (BindingSource)targetGrid.DataSource;
            if (bs == null)
                return;
            DataTable gridTable = (DataTable)bs.DataSource;


            // Cast out a DataTable from the target grid datasource.
            // We need to iterate through all the data in the grid and a DataTable supports enumeration.           

            // Create a graphics object from the target grid. Used for measuring text size.
            using (var gfx = targetGrid.CreateGraphics())
            {
                // Iterate through the columns.
                for (int i = 0; i < gridTable.Columns.Count; i++)
                {
                    // Leverage Linq enumerator to rapidly collect all the rows into a string array, making sure to exclude null values.
                    string[] colStringCollection = gridTable.AsEnumerable().Where(r => r.Field<object>(i) != null).Select(r => r.Field<object>(i).ToString().Trim()).ToArray();

                    // Sort the string array by string lengths.
                    colStringCollection = colStringCollection.OrderBy((x) => x.Length).ToArray();

                    if (colStringCollection.Count() == 0)
                        continue;

                    // targetGrid.Columns[i].HeaderText.Length;

                    // Get the last and longest string in the array.
                    string longestColString = colStringCollection.Last();

                    // Use the graphics object to measure the string size.
                    int colWidth = (int)gfx.MeasureString(longestColString, targetGrid.Font).Width;

                    int headerTitleWidth = (int)gfx.MeasureString(targetGrid.Columns[i].HeaderText, targetGrid.Font).Width + 20;
                    int currentHeaderWidth = targetGrid.Columns[i].Width;

                    // If the calculated width is larger than the column header width, set the new column width.
                    if (colWidth > currentHeaderWidth)//targetGrid.Columns[i].HeaderCell.Size.Width)
                    {
                        targetGrid.Columns[i].Width = colWidth > 2 * currentHeaderWidth ? 2 * currentHeaderWidth : colWidth;
                    }
                    else if (headerTitleWidth > currentHeaderWidth) // Otherwise, set the column width to the header width.
                    {
                        targetGrid.Columns[i].Width = currentHeaderWidth > headerTitleWidth ? currentHeaderWidth : 2 * headerTitleWidth - currentHeaderWidth;
                    }

                }
            }
        }

        /// <summary>
        /// Visible all row in datagridviewx by status
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="isVisible"></param>
        public static void RowVisible(DataGridViewX DataGridViewSource, DataGridViewRow[] DataRowsSource, bool isVisible)
        {
            // DataGridViewSource.DataSource = null;
            // Clean all searching data
            DataGridViewSource.Rows.Clear();
            DataRowsSource.Cast<DataGridViewRow>().ToList().ForEach(r => r.Visible = isVisible);
            //Update data all
            DataGridViewSource.Rows.AddRange(DataRowsSource);
        }

        /// <summary>
        /// Get all rows in datagridview to Array DataGridViewRow
        /// </summary>
        /// <param name="dataGridView">DataGridView</param>
        /// <returns>DataGridViewRow[]</returns>
        public static DataGridViewRow[] GetDataRows(DataGridViewX dataGridView)
        {
            try
            {
                DataGridViewRow[] dataRows = new DataGridViewRow[dataGridView.Rows.Count];
                dataGridView.Rows.CopyTo(dataRows, 0);
                return dataRows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all rows in datagridview to Array DataGridViewRow
        /// </summary>
        /// <param name="dataGridView">DataGridView</param>
        /// <returns>DataGridViewRow[]</returns>
        public static DataGridViewRow[] GetDataRows(AdvancedDataGridView dataGridView)
        {
            try
            {
                DataGridViewRow[] dataRows = new DataGridViewRow[dataGridView.Rows.Count];
                dataGridView.Rows.CopyTo(dataRows, 0);
                return dataRows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<DataGridViewRow> GetDataRowList(DataGridViewX dataGridView)
        {
            try
            {
                DataGridViewRow[] dataRows = new DataGridViewRow[dataGridView.Rows.Count];
                dataGridView.Rows.CopyTo(dataRows, 0);
                return dataRows.ToList<DataGridViewRow>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Copy column
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        public static DataGridViewColumn[] GetDataColumns(DataGridViewX dataGridView)
        {
            try
            {
                DataGridViewColumn[] dataColumns = new DataGridViewColumn[dataGridView.Columns.Count];
                int index = 0;

                foreach (DataGridViewColumn item in dataGridView.Columns)
                {
                    dataColumns[index] = (DataGridViewColumn)item.Clone();
                    index++;
                }

                //dataGridView.Columns.CopyTo(dataColumns, 0);
                return dataColumns;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static List<DataRow> GetDataAddNew(DataTable dataSource, string columnUpdateTimeDataPropertyName, string columnKeyDataPropertyName)
        {
            List<DataRow> rows = new List<DataRow>();
            if (dataSource == null || dataSource.Rows.Count == 0)
                return rows;
            var query = dataSource.AsEnumerable().Where(ud => ud.Field<object>(columnUpdateTimeDataPropertyName) != null && ud.Field<object>(columnKeyDataPropertyName) == null).Count();

            if (query == 0)
                return rows;

            DataTable data = dataSource.AsEnumerable().Where(ud => ud.Field<object>(columnUpdateTimeDataPropertyName) != null && ud.Field<object>(columnKeyDataPropertyName) == null).CopyToDataTable();

            foreach (DataRow row in data.Rows)
            {
                rows.Add(row);
            }

            return rows;
        }

        internal static DataTable GetDataSave(DataTable dataSource, string columnChoiseName, string colUpdateName, string deltedColumnName, string columnKeyName)
        {
            if (dataSource == null || dataSource.Rows.Count == 0)
                return null;
            var query = dataSource.AsEnumerable().Where(ud => (ud.Field<object>(colUpdateName) != null || ud.Field<bool?>(deltedColumnName) == true || ud.Field<bool?>(columnChoiseName) == true) && ud.Field<object>(columnKeyName) != null).Count();

            if (query == 0)
                return null;

            DataTable data = dataSource.AsEnumerable().Where(ud => (ud.Field<object>(colUpdateName) != null || ud.Field<bool?>(deltedColumnName) == true || ud.Field<bool?>(columnChoiseName) == true) && ud.Field<object>(columnKeyName) != null).CopyToDataTable();

            return data;
        }

        /// <summary>
        /// Get all rows in datagridview to Array DataGridViewRow by checkbox column
        /// </summary>
        /// <param name="dataGridView">DataGridView</param>
        /// <param name="colChoiseIndex">Column filter index</param>
        /// <param name="isChecked">Value filter</param>
        /// <returns>DataGridViewRow[]</returns>
        private static DataGridViewRow[] GetDataRows(DataGridViewRow[] dataRows, int colChoiseIndex, bool isChecked)
        {
            try
            {
                return (from DataGridViewRow r in dataRows
                        where (bool)r.Cells[colChoiseIndex].Value == isChecked
                        select r).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Filter datagridview before filter need set DataFilterRows by type DataGridViewRow[]
        /// </summary>
        /// <param name="dataGridView">DataGridViewX</param>
        /// <param name="filterColChoiseIndex">filterColumnIndex</param>
        /// <param name="isChecked">isChecked</param>
        /// <param name="currentRowIndex">currentRowIndex</param>
        public static void FilterRows(DataGridViewX dataGridView, DataGridViewRow[] DataRowsSource, int filterColChoiseIndex, bool isChecked, int currentRowIndex)
        {
            DataGridViewRow[] dataRows = null;

            //Clear data before display
            dataGridView.Rows.Clear();

            if (isChecked)
            {
                dataRows = GetDataRows(DataRowsSource, filterColChoiseIndex, isChecked);
                //  DataRowsSource.ToList().ForEach(r => r.Cells[filterColChoiseIndex].Value = isChecked);
            }
            else
            {
                dataRows = DataRowsSource;
            }

            dataGridView.Rows.AddRange(dataRows);

            if (currentRowIndex <= 0 || dataGridView.Rows.Count < currentRowIndex)
                return;

            // total display row count
            int displayedRowCount = dataGridView.DisplayedRowCount(false);

            // Scroll to current row seleted
            dataGridView.FirstDisplayedScrollingRowIndex = currentRowIndex > displayedRowCount ? currentRowIndex - 1 : 0;
            // Focus row current
            dataGridView.Rows[currentRowIndex - 1].Selected = true;
        }

        public static void DisplayRowSelected(DataGridViewX dataGridView, DataTable dataSource, int filterColChoiseIndex, bool isChecked, int currentRowIndex)
        {
            string filterString = string.Empty;
            try
            {
                if (isChecked)
                {

                    if (filterColChoiseIndex == -1)
                        return;
                    filterString = dataSource.Columns[filterColChoiseIndex].ColumnName + "=" + isChecked;
                }

                dataSource.DefaultView.RowFilter = filterString;
                dataSource.AcceptChanges();
            }
            catch (Exception ex)
            {

            }
            if (currentRowIndex <= 0 || dataGridView.Rows.Count < currentRowIndex)
                return;

            // total display row count
            int displayedRowCount = dataGridView.DisplayedRowCount(false);

            // Scroll to current row seleted
            dataGridView.FirstDisplayedScrollingRowIndex = currentRowIndex > displayedRowCount ? currentRowIndex - 1 : 0;
            // Focus row current
            dataGridView.Rows[currentRowIndex - 1].Selected = true;
        }

        public static void DisplayRowSelected(AdvancedDataGridView dataGridView, DataTable dataSource, int filterColChoiseIndex, bool isChecked, int currentRowIndex)
        {
            string filterString = string.Empty;
            try
            {
                if (isChecked)
                {

                    if (filterColChoiseIndex == -1)
                        return;
                    filterString = dataSource.Columns[filterColChoiseIndex].ColumnName + "=" + isChecked;
                }

                dataSource.DefaultView.RowFilter = filterString;
                dataSource.AcceptChanges();
            }
            catch (Exception ex)
            {

            }
            if (currentRowIndex <= 0 || dataGridView.Rows.Count < currentRowIndex)
                return;

            // total display row count
            int displayedRowCount = dataGridView.DisplayedRowCount(false);

            // Scroll to current row seleted
            dataGridView.FirstDisplayedScrollingRowIndex = currentRowIndex > displayedRowCount ? currentRowIndex - 1 : 0;

            // Focus row current
            dataGridView.Rows[currentRowIndex - 1].Selected = true;
        }

        public static void DisplayRowSelected(AdvancedDataGridView dataGridView, DataTable dataSource, string filterColChoiseName, bool isChecked, int currentRowIndex)
        {
            string filterString = string.Empty;
            try
            {
                if (isChecked)
                {

                    if (string.IsNullOrEmpty(filterColChoiseName))
                        return;
                    filterString += dataSource.Columns[filterColChoiseName].ColumnName + "=" + isChecked;
                }

                dataSource.DefaultView.RowFilter = filterString;
                dataSource.AcceptChanges();
            }
            catch (Exception ex)
            {

            }
            if (currentRowIndex <= 0 || dataGridView.Rows.Count < currentRowIndex)
                return;

            // total display row count
            int displayedRowCount = dataGridView.DisplayedRowCount(false);

            // Scroll to current row seleted
            dataGridView.FirstDisplayedScrollingRowIndex = currentRowIndex > displayedRowCount ? currentRowIndex - 1 : 0;
            // Focus row current
            dataGridView.Rows[currentRowIndex - 1].Selected = true;
        }

        internal static bool HasUpdateData(DataTable dataTableSource, string columnUpdateTime)
        {
            if (dataTableSource == null || dataTableSource.Rows.Count == 0)
                return false;
            var exist = dataTableSource.AsEnumerable().Where(r => r.Field<object>(columnUpdateTime) != null);
            if (exist.Count() > 0)
                return true;
            return false;
        }

        internal static bool HasUpdateData(DataTable dataTableSource, string columnUpdateTime, string columDeletedName)
        {
            if (dataTableSource == null || dataTableSource.Rows.Count == 0)
                return false;
            var exist = dataTableSource.AsEnumerable().Where(r => r.Field<object>(columnUpdateTime) != null || (bool)r.Field<object>(columDeletedName) == true);
            if (exist.Count() > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Update data in column
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="DataFilterRows"></param>
        /// <param name="colChoiseIndex"></param>
        /// <param name="value"></param>
        public static void UpdateColum(DataGridViewX dataGridView, DataGridViewRow[] DataFilterRows, int colIndex, object value)
        {
            // Clear all data before update
            dataGridView.Rows.Clear();
            // Set data null | empty
            if (value == null || value.Equals(string.Empty))
            {
                if (value == null)
                {
                    DataFilterRows.Cast<DataGridViewRow>().ToList().ForEach(row => row.Cells[colIndex].Value = DBNull.Value);
                }
                else if (value.Equals(string.Empty))
                {
                    DataFilterRows.Cast<DataGridViewRow>().ToList().ForEach(row => row.Cells[colIndex].Value = string.Empty);
                }
            }
            // Update column type bool
            else if (value.GetType().Equals(typeof(bool)))
            {
                var chose = (bool)value;
                DataFilterRows.Cast<DataGridViewRow>().ToList().ForEach(row => row.Cells[colIndex].Value = chose);
            }// other type
            else if (value.GetType().Equals(typeof(string)))
            {
                var result = value.ToString();
                DataFilterRows.Cast<DataGridViewRow>().ToList().ForEach(row => row.Cells[colIndex].Value = result);
            }

            dataGridView.Rows.AddRange(DataFilterRows);


        }

        /// <summary>
        /// Update column in table
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="colIndex"></param>
        /// <param name="value"></param>
        public static void UpdateColum(DataTable dataSource, int colUpdateIndex, int colIndex, object value)
        {
            if (dataSource == null || colIndex == -1)
                return;

            dataSource.AsEnumerable().Select(b => b[colIndex] = value == null ? DBNull.Value : value).ToList();
            dataSource.AsEnumerable().Select(b => b[colUpdateIndex] = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT)).ToList();
        }

        /// <summary>
        /// Update column in table
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="colIndex"></param>
        /// <param name="value"></param>
        public static void UpdateColum(AdvancedDataGridView dataGridView, int colUpdateIndex, int colIndex, object value)
        {
            if (dataGridView == null || colIndex == -1 || dataGridView.Rows.Count == 0)
                return;

            dataGridView.Columns.Cast<DataGridViewRow>().Select(b => b.Cells[colIndex].Value = value == null ? DBNull.Value : value);
            dataGridView.Columns.Cast<DataGridViewRow>().Select(b => b.Cells[colUpdateIndex].Value = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT));
            dataGridView.EndEdit();
        }

        /// <summary>
        /// Update column in table
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="colUpdateValueName"></param>
        /// <param name="value"></param>
        public static void UpdateColum(BindingSource bindingSource_main, string colUpdateDatetimeName, string colUpdateValueName, object value)
        {
            AdvancedDataGridView dataGridView = new AdvancedDataGridView();
            var existChecked = dataGridView.Rows.Cast<DataGridViewRow>().ToList().Where(r => (bool)r.Cells[0].Value).FirstOrDefault();

            if (bindingSource_main == null || string.IsNullOrEmpty(colUpdateValueName))
                return;

            DataTable dataSource = bindingSource_main.DataSource as DataTable;
            if (dataSource == null)
                return;
            if (value == "")
                value = null;

            dataSource.AsEnumerable().Where(r => r.Field<bool>(0)).Select(b => b[colUpdateValueName] = value == null ? DBNull.Value : value).ToList();
            dataSource.AsEnumerable().Select(b => b[colUpdateDatetimeName] = DateTime.Now).ToList();
        }

        internal static void Frozen(bool? isFrozen, AdvancedDataGridView dtgAdvMain, int currentColumnIndex)
        {
            if (dtgAdvMain == null || currentColumnIndex == -1 || currentColumnIndex > dtgAdvMain.ColumnCount - 1)
                return;

            // Reset columns 
            if (isFrozen == false)
            {
                dtgAdvMain.SelectionMode = DataGridViewSelectionMode.CellSelect;
                if (dtgAdvMain.Columns.GetFirstColumn(DataGridViewElementStates.Frozen) != null)
                    dtgAdvMain.Columns.GetFirstColumn(DataGridViewElementStates.Frozen).Frozen = false;
                return;
            }

            int displayColumnIndex = dtgAdvMain.Columns[currentColumnIndex].DisplayIndex;
            int freezeColumnCount = dtgAdvMain.Columns.GetColumnCount(DataGridViewElementStates.Frozen);

            if (displayColumnIndex > freezeColumnCount)
            {
                dtgAdvMain.Columns[currentColumnIndex].DisplayIndex = freezeColumnCount;
            }
            else if (displayColumnIndex < freezeColumnCount)
            {
                dtgAdvMain.Columns[currentColumnIndex].DisplayIndex = freezeColumnCount - 1;
            }

            dtgAdvMain.Columns[currentColumnIndex].Frozen = true;
        }

        internal static bool UpdateDataSource(BindingSource bindingSource_main, string columnKeyDataPropertyName, string columnUpdateTimeDataPropertyName, string columUpdateDataPropertyName, string keyId, object data, ref int columIndex, ref int rowIndex)
        {
            int currentCoumnIndex = columIndex;
            int currentRowIndex = rowIndex;
            DataTable dtSource = bindingSource_main.DataSource as DataTable;
            if (dtSource == null)
                return false;
            DataRow updateRow = dtSource.AsEnumerable().Where(r => r.Field<object>(columnKeyDataPropertyName).ToString().Equals(keyId)).FirstOrDefault();

            if (updateRow != null)
            {
                if (data != null && string.IsNullOrWhiteSpace(data.ToString()) || data == null)
                    updateRow[columUpdateDataPropertyName] = DBNull.Value;
                else
                    updateRow[columUpdateDataPropertyName] = data;
                if (!string.IsNullOrWhiteSpace(columnUpdateTimeDataPropertyName))
                    updateRow[columnUpdateTimeDataPropertyName] = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT);
                // To update filter
                dtSource.AcceptChanges();
                columIndex = currentCoumnIndex;
                rowIndex = currentRowIndex;
                // Data is updated
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Update column in table
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="colUpdateValueName"></param>
        /// <param name="value"></param>
        public static void UpdateColum(BindingSource bindingSource_main, ColumnUpdateEntity columns, ref int columnIndex, ref int rowsIndex)
        {
            if (bindingSource_main == null || string.IsNullOrEmpty(columns.ColumnCurrentUpdateDataPropertyName))
                return;

            int currentColumnIndex = columnIndex;
            int currentRowIndex = rowsIndex;

            DataTable dataSource = bindingSource_main.DataSource as DataTable;
            if (dataSource == null)
                return;
            if (columns.DataUpdate != null && string.IsNullOrEmpty(columns.DataUpdate.ToString()))
                columns.DataUpdate = null;

            DataTable dtFilter = dataSource.DefaultView.ToTable();
            if (dtFilter.Rows.Count == 0)
            {
                dtFilter = dataSource;
            }

            string keyId = string.Empty;

            foreach (DataRow row in dtFilter.Rows)
            {
                keyId = row[columns.ColumnKeyDataPropertyName].ToString();
                DataRow updateRow = dataSource.AsEnumerable().Where(r => r.Field<object>(columns.ColumnKeyDataPropertyName).ToString().Equals(keyId)).FirstOrDefault();

                if (updateRow != null)
                {
                    if (columns.DataUpdate != null && string.IsNullOrWhiteSpace(columns.DataUpdate.ToString()))
                        updateRow[columns.ColumnCurrentUpdateDataPropertyName] = DBNull.Value;
                    else
                        updateRow[columns.ColumnCurrentUpdateDataPropertyName] = columns.DataUpdate == null ? DBNull.Value : columns.DataUpdate;
                    if (!string.IsNullOrWhiteSpace(columns.ColumnUpdateDateTimeDataPropertyName))
                        updateRow[columns.ColumnUpdateDateTimeDataPropertyName] = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT);
                }
            }

            dataSource.AcceptChanges();

            columnIndex = currentColumnIndex;
            rowsIndex = currentRowIndex;
        }

        public static void UpdateColum(DataTable dataSource, ColumnUpdateEntity columns, ref int columnIndex, ref int rowsIndex)
        {
            DataTable dtFilter = dataSource.DefaultView.ToTable();

            var listKey = dtFilter.AsEnumerable().Select(r => r.Field<object>(columns.ColumnKeyDataPropertyName)).ToList();

            object updateValue = DBNull.Value;

            if (columns.DataUpdate != null && string.IsNullOrWhiteSpace(columns.DataUpdate.ToString()))
                updateValue = DBNull.Value;
            else
                updateValue = columns.DataUpdate == null ? DBNull.Value : columns.DataUpdate;

            // Update value
            var dt = dataSource.AsEnumerable().Where(r => listKey.Contains(r.Field<object>(columns.ColumnKeyDataPropertyName)))
                  .Select(ud => ud[columns.ColumnCurrentUpdateDataPropertyName] = updateValue).ToList();

            // Update date time
            if (!string.IsNullOrWhiteSpace(columns.ColumnUpdateDateTimeDataPropertyName))
            {
                object dateTimeValue = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT);
                dataSource.AsEnumerable().Where(r => listKey.Contains(r.Field<object>(columns.ColumnKeyDataPropertyName)))
                .Select(ud => ud[columns.ColumnUpdateDateTimeDataPropertyName] = dateTimeValue).ToList();
            }
        }

        /// <summary>
        /// Update column in table
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="colUpdateValueName"></param>
        /// <param name="value"></param>
        public static void UpdateColum(AdvancedDataGridView dataGridView, string colUpdateDatetimeName, string colUpdateValueName, object value)
        {
            if (dataGridView == null || dataGridView.Rows.Count == 0)
                return;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.Cells[colUpdateValueName].Value = value == null ? DBNull.Value : value;
                row.Cells[colUpdateDatetimeName].Value = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT);
            }
        }

        /// <summary>
        /// Get data to update
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="colUpdateIndex"></param>
        /// <returns></returns>
        public static DataTable GetDataExport(DataTable dataSource, string colUpdateName, string colChoiseName)
        {
            if (dataSource == null || dataSource.Rows.Count == 0)
                return null;

            var data = dataSource.AsEnumerable().Where(ud => ud.Field<object>(colUpdateName) != null || ud.Field<bool?>(colChoiseName) == true);
            if (data.Count() > 0)
                return data.CopyToDataTable();
            else
                return null;
        }

        public static DataTable GetDataUpdateAndDeleted(DataTable dataSource, string colUpdateName, string deltedColumnName, string columnKeyName)
        {
            if (dataSource == null || dataSource.Rows.Count == 0)
                return null;
            var query = dataSource.AsEnumerable().Where(ud => (ud.Field<object>(colUpdateName) != null || ud.Field<bool?>(deltedColumnName) == true) && ud.Field<object>(columnKeyName) != null).Count();

            if (query == 0)
                return null;

            DataTable data = dataSource.AsEnumerable().Where(ud => (ud.Field<object>(colUpdateName) != null || ud.Field<bool?>(deltedColumnName) == true) && ud.Field<object>(columnKeyName) != null).CopyToDataTable();

            return data;
        }

        public static DataTable GetDataUpdate(DataTable dataSource, string colUpdateName)
        {
            if (dataSource == null || dataSource.Rows.Count == 0)
                return null;
            var query = dataSource.AsEnumerable().Where(ud => ud.Field<object>(colUpdateName) != null).Count();

            if (query == 0)
                return null;

            return dataSource.AsEnumerable().Where(ud => ud.Field<object>(colUpdateName) != null).CopyToDataTable();
        }

        public static DataTable GetDataDeleted(DataTable dataSource, string colDeletedName)
        {
            if (dataSource == null || dataSource.Rows.Count == 0)
                return null;
            var query = dataSource.AsEnumerable().Where(ud => ud.Field<bool?>(colDeletedName) == true).Count();
            if (query == 0)
                return null;
            return dataSource.AsEnumerable().Where(ud => ud.Field<bool?>(colDeletedName) == true).CopyToDataTable();
        }

        public static void ResetUpdateColumn(DataTable dataSource, string colUpdateDataPropertyName, string colDeletedName, ref int currentColumnIndex, ref int curretRowIndex)
        {
            if (dataSource == null || string.IsNullOrEmpty(colUpdateDataPropertyName))
                return;

            int columnIndex = currentColumnIndex;
            int rowIndex = curretRowIndex;

            //Reset column update
            dataSource.AsEnumerable().Where(row => row.Field<object>(colUpdateDataPropertyName) != null)
                                   .Select(b => b[colUpdateDataPropertyName] = DBNull.Value)
                                   .ToList();

            // Remove column deleted
            if (!string.IsNullOrWhiteSpace(colDeletedName))
            {
                DataRow[] deltedRows = dataSource.AsEnumerable().Where(row => row.Field<bool?>(colDeletedName) == true).ToArray();
                if (deltedRows != null)
                {
                    foreach (DataRow row in deltedRows)
                    {
                        row.Delete();
                    }
                }
            }

            dataSource.AcceptChanges();
            currentColumnIndex = columnIndex;
            curretRowIndex = rowIndex;
        }

        /// <summary>
        /// Get search list
        /// </summary>
        /// <param name="dataGridViewRows"></param>
        /// <returns></returns>
        private static IDictionary<string, object> ConvertToSearchList(DataGridViewRow dataGridViewRows)
        {
            return (from DataGridViewCell cell in dataGridViewRows.Cells
                    where cell.Value != null
                    select new
                    {
                        Key = cell.OwningColumn.DataPropertyName,
                        Value = cell.Value
                    }).ToDictionary(d => d.Key, d => d.Value);
        }

        /// <summary>
        /// Filter datagridview with mutil column
        /// </summary>
        /// <param name="dataGridViewSource"></param>
        /// <param name="dataRowsSouce"></param>
        /// <param name="filterCondition"></param>
        public static void Filter(DataGridViewX dataGridViewSource, DataGridViewRow[] dataRowsSouce, DataGridViewFilterEntity filterCondition)
        {
            // dataGridViewSource.DataSource = null;
            // Clean data
            dataGridViewSource.Rows.Clear();

            bool isMatched = false;

            // Count matching column
            int matchingCount = 0;

            DictionaryCollection dictionConditions = new DictionaryCollection();

            // Get All condition
            foreach (DataGridViewRow dict in filterCondition.DataSearch)
            {
                dictionConditions.Add(ConvertToSearchList(dict));
            }

            // Distint condition list
            List<IDictionary<string, object>> filteredDictionary = dictionConditions.GetDictionariesWithDistint();

            // Value in source
            string dictionData = string.Empty;
            // Value search
            string searchData = string.Empty;

            // Display data
            foreach (DataGridViewRow row in dataRowsSouce)
            {
                // Hide row
                row.Visible = false;
                // Loop each diction            
                foreach (IDictionary<int, object> diction in filteredDictionary)
                {
                    // Reset count matching foreach diction
                    matchingCount = 0;

                    // Foreach colum
                    foreach (int columnIndex in diction.Keys)
                    {
                        // Date time compare
                        if (row.Cells[columnIndex].GetType().Equals(typeof(DataGridViewDateTimeInputCell)))
                        {
                            dictionData = Convert.ToDateTime(row.Cells[columnIndex].Value).ToString("yyyyMMdd");
                            searchData = Convert.ToDateTime(diction[columnIndex]).ToString("yyyyMMdd");
                        }
                        else
                        {
                            dictionData = Convert.ToString(row.Cells[columnIndex].Value).Trim();
                            searchData = Convert.ToString(diction[columnIndex]).Trim();
                        }

                        // Matching data with contains/equals value
                        if (dictionData.Contains(searchData))//string.Compare(value1, value2, true) == 0)
                        {
                            matchingCount++;
                            isMatched = true;
                        }
                        else
                        {
                            // One column not matching 
                            isMatched = false;
                            break;
                        }
                    }
                    //Display row with columns maching all condition 
                    if (isMatched && matchingCount == diction.Count)
                    {
                        // If row not exist then add new row
                        //if (!CheckDataGridViewRowExist(dataGridViewSource, row))
                        //{
                        // Display row matching condition
                        row.Visible = true;
                        //}
                    }
                }
            }


            // Display performance
            dataGridViewSource.Rows.AddRange(dataRowsSouce);

        }

        /// <summary>
        /// Filter datatable
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="filterCondition"></param>
        public static void Filter(BindingSource bindingSource, DataGridViewFilterEntity filterCondition)
        {
            if (bindingSource == null || filterCondition == null)
                return;

            DictionaryCollection dictionConditions = new DictionaryCollection();

            // Get All condition
            foreach (DataGridViewRow dict in filterCondition.DataSearch)
            {
                dictionConditions.Add(ConvertToSearchList(dict));
            }

            if (dictionConditions.Count == 0)
                return;

            // Distint condition list
            List<IDictionary<string, object>> filteredDictionary = dictionConditions.GetDictionariesWithDistint();

            string filterString = string.Empty;

            foreach (IDictionary<string, object> diction in filteredDictionary)
            {
                // Foreach colum
                foreach (string columnName in diction.Keys)
                {
                    if (string.IsNullOrWhiteSpace(diction[columnName].ToString()))
                        continue;

                    if (diction[columnName].ToString().Trim().Replace(" ", "").Contains("IsNull"))
                    {
                        filterString += string.Format("CONVERT(IsNull({0},''), System.String) = '' and ", ((DataTable)bindingSource.DataSource).Columns[columnName].ColumnName);
                    }
                    else if (diction[columnName].ToString().Trim().Replace(" ", "").Contains("IsNotNull"))
                    {
                        filterString += string.Format("CONVERT(IsNull({0},''), System.String) <> '' and ", ((DataTable)bindingSource.DataSource).Columns[columnName].ColumnName);
                    }
                    else
                    {
                        filterString += ((DataTable)bindingSource.DataSource).Columns[columnName].ColumnName + "=" + diction[columnName] + " and ";
                    }
                }
                filterString = filterString.Remove(filterString.Length - 5);
                filterString = filterString + " or ";
            }

            filterString = filterString.Remove(filterString.Length - 4);

            bindingSource.Filter = filterString;
        }


        /// <summary>
        /// Filter datatable
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="filterCondition"></param>
        public static void Filter(DataTable dataSource, DataGridViewFilterEntity filterCondition)
        {
            if (dataSource == null || filterCondition == null)
                return;

            DictionaryCollection dictionConditions = new DictionaryCollection();

            // Get All condition
            foreach (DataGridViewRow dict in filterCondition.DataSearch)
            {
                dictionConditions.Add(ConvertToSearchList(dict));
            }

            // Distint condition list
            List<IDictionary<string, object>> filteredDictionary = dictionConditions.GetDictionariesWithDistint();

            string filterString = string.Empty;

            foreach (IDictionary<string, object> diction in filteredDictionary)
            {
                // Foreach colum
                foreach (string columnIndex in diction.Keys)
                {
                    if (string.IsNullOrWhiteSpace(diction[columnIndex].ToString()))
                        continue;

                    if (diction[columnIndex].ToString().Trim().Replace(" ", "").Contains("IsNull"))
                    {
                        filterString += string.Format("CONVERT(IsNull({0},''), System.String) = '' and ", dataSource.Columns[columnIndex].ColumnName);
                    }
                    else if (diction[columnIndex].ToString().Trim().Replace(" ", "").Contains("IsNotNull"))
                    {
                        filterString += string.Format("CONVERT(IsNull({0},''), System.String) <> '' and ", dataSource.Columns[columnIndex].ColumnName);
                    }
                    else
                    {
                        filterString += dataSource.Columns[columnIndex].ColumnName + "=" + diction[columnIndex] + " and ";
                    }

                }
                filterString = filterString.Remove(filterString.Length - 5);
                filterString = filterString + " or ";
            }
            filterString = filterString.Remove(filterString.Length - 4);

            dataSource.DefaultView.RowFilter = filterString;
            dataSource.AcceptChanges();
        }



        /// <summary>
        /// Check row exist in datagridview
        /// </summary>
        /// <param name="dataGridViewSource">dataGridViewSource</param>
        /// <param name="row">row</param>
        /// <returns>TRUE exist | FALSE not exist</returns>
        private static bool CheckDataGridViewRowExist(DataGridViewX dataGridViewSource, DataGridViewRow row)
        {
            var rowExist = from DataGridViewRow r in dataGridViewSource.Rows
                           where r == row
                           select r;
            if (rowExist.Count() > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// SortColumn
        /// </summary>
        /// <param name="dataGridViewSource"></param>
        /// <param name="columnIndex"></param>
        /// <param name="sortType"></param>
        public static void SortColumn(DataGridViewX dataGridViewSource, int columnIndex, SortType sortType)
        {
            if (dataGridViewSource == null || columnIndex == -1)
            {
                return;
            }
            // Get current scroll position
            int scrollPosition = dataGridViewSource.HorizontalScrollingOffset;

            dataGridViewSource.Columns[columnIndex].Selected = false;
            dataGridViewSource.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.None;
            dataGridViewSource.Columns[columnIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewSource.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dataGridViewSource.SortCompare += DataGridViewSource_SortCompare;

            if (sortType == SortType.AtoZ)
            {
                dataGridViewSource.Columns[columnIndex].SortMode = DataGridViewColumnSortMode.Programmatic;
                dataGridViewSource.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                dataGridViewSource.Sort(dataGridViewSource.Columns[columnIndex], ListSortDirection.Ascending);
            }
            else if (sortType == SortType.ZtoA)
            {
                dataGridViewSource.Columns[columnIndex].SortMode = DataGridViewColumnSortMode.Programmatic;
                dataGridViewSource.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                dataGridViewSource.Sort(dataGridViewSource.Columns[columnIndex], ListSortDirection.Descending);
            }

            dataGridViewSource.HorizontalScrollingOffset = scrollPosition;

            dataGridViewSource.SortCompare -= DataGridViewSource_SortCompare;
        }

        public static void SortColumn(AdvancedDataGridView dataGridViewSource, int columnIndex, SortType sortType)
        {
            if (dataGridViewSource == null || columnIndex == -1)
            {
                return;
            }
            // Get current scroll position
            int scrollPosition = dataGridViewSource.HorizontalScrollingOffset;

            dataGridViewSource.Columns[columnIndex].Selected = false;
            dataGridViewSource.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.None;
            dataGridViewSource.Columns[columnIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewSource.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dataGridViewSource.SortCompare += DataGridViewSource_SortCompare;

            if (sortType == SortType.AtoZ)
            {
                dataGridViewSource.Columns[columnIndex].SortMode = DataGridViewColumnSortMode.Programmatic;
                dataGridViewSource.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                dataGridViewSource.Sort(dataGridViewSource.Columns[columnIndex], ListSortDirection.Ascending);
            }
            else if (sortType == SortType.ZtoA)
            {
                dataGridViewSource.Columns[columnIndex].SortMode = DataGridViewColumnSortMode.Programmatic;
                dataGridViewSource.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                dataGridViewSource.Sort(dataGridViewSource.Columns[columnIndex], ListSortDirection.Descending);
            }

            dataGridViewSource.HorizontalScrollingOffset = scrollPosition;

            dataGridViewSource.SortCompare -= DataGridViewSource_SortCompare;
        }

        private static void DataGridViewSource_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (DBNull.Value.Equals(e.CellValue1) || DBNull.Value.Equals(e.CellValue2))
            {
                if (DBNull.Value.Equals(e.CellValue1) || e.CellValue1.Equals(null))
                {
                    e.SortResult = 1;
                }
                else if (DBNull.Value.Equals(e.CellValue2) || e.CellValue2.Equals(null))
                {
                    e.SortResult = -1;
                }
            }
            else
            {
                e.SortResult = (e.CellValue1 as IComparable).CompareTo(e.CellValue2 as IComparable);
            }
            e.Handled = true;
        }

        /// <summary>
        /// ColumnVisible
        /// </summary>
        /// <param name="dataGridViewSource"></param>
        /// <param name="isVisible"></param>
        public static void ColumnVisible(DataGridViewX dataGridViewSource, bool isVisible)
        {
            if (isVisible)
            {
                // Show all hide columns
                dataGridViewSource.Columns.Cast<DataGridViewColumn>().Where(col => !col.Visible).ToList().ForEach(col => col.Visible = isVisible);
            }
            else
            {
                // Hide all seleted columns
                foreach (DataGridViewCell cell in dataGridViewSource.SelectedCells)
                {
                    dataGridViewSource.Columns[cell.ColumnIndex].Visible = isVisible;
                }
            }
        }


        /// <summary>
        /// ColumnVisible
        /// </summary>
        /// <param name="dataGridViewSource"></param>
        /// <param name="isVisible"></param>
        public static void ColumnVisible(AdvancedDataGridView dataGridViewSource, string columnName, bool isVisible)
        {
            dataGridViewSource.Columns[columnName].Visible = isVisible;
        }

        private static void CellSelected(DataGridViewRow[] dataGridViewRows, bool isSelected)
        {
            if (dataGridViewRows == null || dataGridViewRows.Length == 0) return;

            foreach (DataGridViewRow row in dataGridViewRows)
            {
                row.Cells.Cast<DataGridViewCell>().Where(c => c.Selected).ToList().ForEach(c => c.Selected = isSelected);
            }
        }

        public static void CreateTableColumns(DataTable dataTable, DataGridViewX dataGridViewSource)
        {
            string userPc = Environment.UserName;
            string PcName = Environment.MachineName;
            // dataTable.TableName = PcName;
            if (dataTable.Columns.Count == 0)
            {
                DataColumn[] columns = new DataColumn[dataGridViewSource.Columns.Count];
                columns = (from DataGridViewColumn col in dataGridViewSource.Columns
                           where col.Index != 0
                           select new DataColumn(
                               col.DataPropertyName,
                               col.ValueType = col.GetType() == null ? typeof(object) : col.GetType())
                           ).ToArray<DataColumn>();

                dataTable.Columns.AddRange(columns);
            }
        }

        /// <summary>
        /// Fill datatable from Datagridviews
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="dataRowsSource"></param>
        public static void FillDataRowToDataTale(DataGridViewRow[] dataRows, DataTable dataTable)
        {
            if (dataRows == null)
                return;
            if (dataTable == null)
                dataTable = new DataTable();
            else
                dataTable.Clear();
            // Create columns
            if (dataTable.Columns.Count == 0)
            {
                DataColumn[] columns = new DataColumn[dataRows.FirstOrDefault().Cells.Count];
                columns = (from DataGridViewCell cel in dataRows.FirstOrDefault().Cells
                           where cel.ColumnIndex != 0 // Remove chose column
                           select new DataColumn(
                               cel.DataGridView.Columns[cel.ColumnIndex].Name,
                           cel.ValueType == null ? typeof(object) : cel.ValueType)
                           ).ToArray<DataColumn>();
                dataTable.Columns.AddRange(columns);
            }
            // Add data
            foreach (DataGridViewRow row in dataRows)
            {
                DataRow rows = dataTable.NewRow();
                row.Cells.Cast<DataGridViewCell>().ToList().Where(cel => cel.ColumnIndex != 0).ToList().ForEach(col => rows[col.ColumnIndex - 1] = col.Value); // remove choose column
                dataTable.Rows.Add(rows);
            }
        }

        public static DataGridViewRow[] GetDataGridViewRows(DataTable dataTable, DataGridViewX dataGridViewSource)
        {
            if (dataTable.Rows.Count == 0 || dataGridViewSource == null) return null;

            int indexR = 0;
            DataGridViewRow[] dataRows = new DataGridViewRow[dataTable.Rows.Count];
            DataGridViewRow drow = new DataGridViewRow();
            int indexC = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                drow = new DataGridViewRow();
                drow.CreateCells(dataGridViewSource);
                indexC = 0;
                // Frist column check box
                drow.Cells[indexC].Value = false;
                foreach (DataColumn col in dataTable.Columns)
                {
                    if (dataGridViewSource.Columns[indexC].DataPropertyName.Equals(col.ColumnName))
                    {
                        if (drow.Cells[indexC].GetType().Equals(typeof(DataGridViewCheckBoxXCell)))
                        {
                            bool isBool = false;
                            bool.TryParse(row[col].ToString(), out isBool);
                            drow.Cells[indexC].Value = isBool;
                        }
                        else
                            drow.Cells[indexC].Value = row[col];
                    }

                    indexC++;
                }
                dataRows[indexR] = drow;
                drow = null;
                GC.Collect();
                indexR++;
            }

            return dataRows;
        }

        public static void ExportToFile(DataGridView dataGridView, DataGridViewRow[] dataRowsSource, FileExportEntity exportInfo)
        {
            if (dataRowsSource == null)
                return;
            if (exportInfo.FileType == FileType.Excel)
            {
                ExcelUtils.ExportFile(dataGridView, dataRowsSource, exportInfo.FilePath, exportInfo.IsExportWithFilter);
            }
            else
            {
                FileUtils.ExportFile(dataGridView, dataRowsSource, exportInfo.FilePath, exportInfo.IsExportWithFilter);
            }
        }

        public static void ExportToFile(DataTable dataTable, FileExportEntity exportInfo)
        {
            if (exportInfo.FileType == FileType.Excel)
            {
                ExcelUtils.ExportToFile(dataTable, exportInfo.FilePath);
            }
            else
            {

            }
        }
    }
}
