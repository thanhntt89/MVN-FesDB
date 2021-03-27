using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace FestivalUtilities
{
    public class ExcelUtils
    {
        /// <summary>
        /// List data in column index
        /// </summary>
        /// <param name="filePath">filePath</param>
        /// <param name="index">Start: Index = 1</param>
        /// <returns></returns>
        public static List<string> GetSongNumberInput(string filePath, int index)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                if (IsFileinUse(file))
                    throw new ArgumentException("File in used");

                List<string> dataRows = new List<string>();

                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                int columnIndex = index < 1 ? 1 : index;
                for (int i = 2; i <= rowCount; i++)
                {
                    Excel.Range range = (xlWorksheet.Cells[i, columnIndex] as Excel.Range);
                    if (IsNumeric(range.Value))
                    {
                        dataRows.Add(range.Value.ToString());
                    }
                }

                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                return dataRows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static bool IsNumeric(object expression)
        {
            if (expression == null)
                return false;

            double number;
            return Double.TryParse(Convert.ToString(expression
                                                    , CultureInfo.InvariantCulture)
                                  , System.Globalization.NumberStyles.Any
                                  , NumberFormatInfo.InvariantInfo
                                  , out number);
        }

        private static bool IsFileinUse(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }

        public static void ExportFile(DataGridView dataGridView, DataGridViewRow[] dataRowSource, string filePath, bool exportWithFilter)
        {
            if (dataRowSource.Length == 0 || dataGridView == null)
                return;

            try
            {
                // creating Excel Application  
                Excel._Application xlApp = new Excel.Application();
                // creating new WorkBook within Excel application  
                Excel._Workbook xlWorkbook = xlApp.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Excel._Worksheet xlWorksheet = null;
                // see the excel sheet behind the program  
                xlApp.Visible = false;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                xlWorksheet = xlWorkbook.Sheets["Sheet1"];
                xlWorksheet = xlWorkbook.ActiveSheet;

                // changing the name of active sheet  
                xlWorksheet.Name = "Exported";

                DataGridViewColumn[] columns = dataGridView.Columns.Cast<DataGridViewColumn>().ToArray();
                string header = string.Empty;
                // storing header part in Excel  
                foreach (DataGridViewColumn col in columns)
                {
                    if (col.Index == 0)
                        continue;

                    if (col.Index >= 1)
                    {
                        xlWorksheet.Cells[1, col.Index] = col.HeaderText;
                    }
                }

                DataGridViewRow[] exportRows = new DataGridViewRow[dataRowSource.Length];

                // Export row visible with filter
                if (exportWithFilter)
                {
                    exportRows = dataRowSource.Where(r => r.Visible && (bool)r.Cells[0].Value).ToArray();
                }
                else
                {
                    exportRows = dataRowSource.Where(r => (bool)r.Cells[0].Value).ToArray();
                }

                foreach (DataGridViewRow row in exportRows)
                {
                    row.Cells.Cast<DataGridViewCell>().ToList().ForEach(cell =>
                    {
                        if (cell.ColumnIndex >= 1)
                        {
                            if (cell.Value == null)
                                xlWorksheet.Cells[cell.RowIndex + 2, cell.ColumnIndex] = DBNull.Value;
                            else
                                xlWorksheet.Cells[cell.RowIndex + 2, cell.ColumnIndex] = cell.Value.ToString();
                        }
                    });
                }

                // save the application  
                xlWorkbook.SaveAs(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();

                Marshal.ReleaseComObject(xlWorksheet);

                //close and release
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void ExportToFile(DataTable dataTable, string filePath)
        {
            if (dataTable.Rows.Count == 0 || dataTable == null)
                return;

            try
            {
                // creating Excel Application  
                Excel._Application xlApp = new Excel.Application();
                // creating new WorkBook within Excel application  
                Excel._Workbook xlWorkbook = xlApp.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Excel._Worksheet xlWorksheet = null;
                // see the excel sheet behind the program  
                xlApp.Visible = false;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                xlWorksheet = xlWorkbook.Sheets["Sheet1"];
                xlWorksheet = xlWorkbook.ActiveSheet;

                // changing the name of active sheet  
                xlWorksheet.Name = "Exported";

                DataColumn[] columns = dataTable.Columns.Cast<DataColumn>().ToArray();
                string header = string.Empty;

                int columnIndex = 0;
                // storing header part in Excel  
                foreach (DataColumn col in columns)
                {
                    columnIndex++;
                    xlWorksheet.Cells[1, columnIndex] = col.ColumnName;

                    if (col.ColumnName.Contains("日"))
                    {
                        xlWorksheet.Columns[columnIndex].NumberFormat = "@";
                    }
                }

                // Next row index
                int rowIndex = 2;

                foreach (DataRow row in dataTable.Rows)
                {
                    // Reset column foreach row
                    columnIndex = 0;

                    foreach (DataColumn col in dataTable.Columns)
                    {
                        columnIndex++;

                        //Set value
                        if (row[col] == null || row[col] == DBNull.Value)
                        {
                            xlWorksheet.Cells[rowIndex, columnIndex] = DBNull.Value;
                        }
                        else
                        {
                            xlWorksheet.Cells[rowIndex, columnIndex] = row[col].ToString();
                        }
                    }

                    rowIndex++;
                }

                // save the application  
                xlWorkbook.SaveAs(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();

                Marshal.ReleaseComObject(xlWorksheet);

                //close and release
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void ExportToExcell(DataTable dataTable, string filePath)
        {
            OleDbConnection Excel_OLE_Con = new OleDbConnection();
            OleDbCommand Excel_OLE_Cmd = new OleDbCommand();
            string connstring = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties=\"Excel 12.0 Xml;HDR=YES;\"", filePath);
            string sheetName = "Exported";
            try
            {
                //drop Excel file if exists
                File.Delete(filePath);

                // Get the Column List from Data Table so can create Excel Sheet with Header
                string TableColumns = string.Empty;
                foreach (DataColumn column in dataTable.Columns)
                {
                    TableColumns += column + "],[";
                }

                // Replace most right comma from Columnlist
                TableColumns = ("[" + TableColumns.Replace(",", " Text,").TrimEnd(','));
                TableColumns = TableColumns.Remove(TableColumns.Length - 2);

                string createTableQuery = string.Format("Create Table [{0}] ({1})", sheetName, TableColumns);

                //Use OLE DB Connection and Create Excel Sheet
                Excel_OLE_Con.ConnectionString = connstring;
                Excel_OLE_Con.Open();
                Excel_OLE_Cmd.Connection = Excel_OLE_Con;
                Excel_OLE_Cmd.CommandText = createTableQuery;
                Excel_OLE_Cmd.ExecuteNonQuery();

                // Write data
                string columns = string.Empty;
                string sqlCommandInsert = string.Empty;
                string sqlCommandValue = string.Empty;


                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    columns += dataColumn + "],[";
                }

                sqlCommandValue = "[" + sqlCommandValue.TrimEnd(',');
                sqlCommandValue = sqlCommandValue.Remove(sqlCommandValue.Length - 2);

                sqlCommandInsert = string.Format("INSERT into [{0}] ({1}) VALUES(", sheetName, columns);

                string columnvalues = string.Empty;

                foreach (DataRow row in dataTable.Rows)
                {
                    columnvalues = string.Empty;

                    foreach (DataColumn col in dataTable.Columns)
                    {
                        columnvalues += "'" + row[col] + "',";
                    }

                    columnvalues = columnvalues.TrimEnd(',');

                    var command = sqlCommandInsert + columnvalues + ")";

                    Excel_OLE_Cmd.CommandText = command;
                    Excel_OLE_Cmd.ExecuteNonQuery();
                }

                Excel_OLE_Con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
