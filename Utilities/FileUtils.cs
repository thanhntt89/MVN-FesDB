using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FestivalUtilities
{
    public class FileUtils
    {
        public static void ConvertUTF8toShiftjis(string filePathOut)
        {
            try
            {
                string fileContent = File.ReadAllText(filePathOut, Encoding.UTF8);
                File.WriteAllText(filePathOut, fileContent, Encoding.GetEncoding("shift_jis"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<string> GetSongNumberInput(string filePath)
        {
            List<string> list = new List<string>();

            try
            {
                FileInfo fileInfo = new FileInfo(filePath);

                if (IsFileinUse(fileInfo))
                    throw new ArgumentException("File in used");
                if (fileInfo.Length == 0 ||
                   (fileInfo.Length > 0
                   && !File.ReadAllLines(filePath).Where(data => !String.IsNullOrWhiteSpace(data.Trim())).Any())
               )
                    throw new ArgumentException("File is empty!!");

                var dataSongs = File.ReadAllLines(filePath);
                var totalRowsCount = dataSongs.Count();

                for (int rowIndex = 0; rowIndex < totalRowsCount; rowIndex++)
                {
                    var dataRow = dataSongs[rowIndex].Split('\t');
                    int columns = dataSongs.Count();
                    if (columns == 0)
                        break;
                    if (IsNumeric(dataRow[0]))
                    {
                        list.Add(dataRow[0]);
                    }
                }

                return list;
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
            return Double.TryParse(Convert.ToString(expression, CultureInfo.InvariantCulture), NumberStyles.Any
                                  , NumberFormatInfo.InvariantInfo, out number);
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
            string endCoding = "shift_jis";
            endCoding = "ut-f8";
            using (FileStream file = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
            using (StreamWriter writer = new StreamWriter(file, Encoding.GetEncoding(endCoding)))
            {
                writer.NewLine = "\r\n";

                DataGridViewColumn[] columns = dataGridView.Columns.Cast<DataGridViewColumn>().ToArray();
                string header = string.Empty;

                // storing header part in Excel  
                foreach (DataGridViewColumn col in columns)
                {
                    if (col.Index == 0)
                        continue;

                    if (col.Index == 1)
                    {
                        header = col.HeaderText;
                    }
                    else
                        header += "\t" + col.HeaderText;
                }
                // Writer header
                writer.WriteLine(header);

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

                string dataRow = string.Empty;

                foreach (DataGridViewRow row in exportRows)
                {
                    dataRow = string.Empty;
                    row.Cells.Cast<DataGridViewCell>().ToList().ForEach(cell =>
                    {
                        if (cell.ColumnIndex == 1)
                        {
                            dataRow = cell.Value.ToString();
                        }
                        else if (cell.ColumnIndex > 1)
                            dataRow += "\t" + cell.Value;
                    });
                    writer.WriteLine(dataRow);
                }
                writer.Close();
            }
        }

        public static void ExportToTSV(DataTable dataTable, string filePath, bool hasHeader = false)
        {
            if (dataTable.Rows.Count == 0 || dataTable == null)
                return;
            try
            {
                int rowIndex = 0;
                int columnIndex = 0;
                int columnTotals = dataTable.Columns.Count;

                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }

                string endCoding = "shift_jis";
                //endCoding = "UTF-8";

                string header = string.Empty;

                using (FileStream file = new FileStream(filePath, FileMode.Truncate, FileAccess.Write, FileShare.Read))
                using (StreamWriter writer = new StreamWriter(file, Encoding.GetEncoding(endCoding)))
                {
                    if (hasHeader)
                    {
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            if (columnIndex == 0)
                            {
                                header += column.ColumnName;
                            }
                            else
                            {
                                header += "\t" + column.ColumnName;
                            }
                            columnIndex++;
                        }
                        // Save to file with mutilpart  
                        if (!string.IsNullOrEmpty(header))
                        {
                            writer.WriteLine(header);
                        }
                    }

                    foreach (DataRow row in dataTable.Rows)
                    {
                        columnIndex = 0;
                        string result = string.Empty;

                        #region loop column
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            string columName = column.ColumnName;

                            string value = string.Empty;
                            if (row.Field<object>(column.ColumnName) == null || row.Field<object>(column.ColumnName) == DBNull.Value)
                                value = string.Empty;
                            else
                                value = row.Field<object>(column.ColumnName).ToString();

                            result += value + "\t";

                            columnIndex++;

                        }
                        #endregion
                        result = result.Remove(result.Length - 1);

                        // Save to file with mutilpart                            
                        writer.WriteLine(result);

                        rowIndex++;
                    }

                    // End write file
                    writer.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void WriteFile(string filePath, string content, string header = null)
        {
            DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(filePath));
            if (!dir.Exists)
            {
                dir.Create();
            }
            string firstLine = string.Empty;

            if (File.Exists(filePath))
            {
                using (var readerForFileStream = new StreamReader(filePath))
                {
                    firstLine = readerForFileStream.ReadLine();

                    if (firstLine != null && firstLine.Equals(header))
                    {
                        header = null;
                    }
                    readerForFileStream.Close();
                }
            }

            using (FileStream file = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
            using (StreamWriter writer = new StreamWriter(file))
            {
                if (header != null)
                    writer.WriteLine(header);
                writer.Write(content);
                writer.Close();
            }
        }
    }
}
