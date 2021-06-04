using System;
using System.Data;
using System.IO;
using System.Text;

namespace FestivalUtilities
{
    public class TsvConvert
    {
        public static void CreateRecommendSongFile(string filePath, DataTable dataTable)
        {
            try
            {
                string folderPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                using (FileStream file = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
                using (StreamWriter sw = new StreamWriter(file, Encoding.GetEncoding("shift_jis")))
                {
                    sw.NewLine = "\r\n";

                    foreach (DataRow row in dataTable.Rows)
                    {
                        string dataLine = string.Empty;
                        int columnIndex = 0;

                        foreach (DataColumn recomCol in dataTable.Columns)
                        {
                            string value = row.IsNull(columnIndex) ? string.Empty : row.Field<string>(columnIndex).ToString();

                            if (columnIndex == 0)
                            {
                                dataLine += value;
                            }
                            else
                            {
                                dataLine += "\t" + value;
                            }
                            columnIndex++;
                        }
                        sw.WriteLine(dataLine);
                    }

                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExportToTSV(FileExportTsvEntity fileExport)
        {
            string strVatoBa = string.Empty;
            if (fileExport == null)
                return;

            try
            {
                if (fileExport.DataExport.Rows.Count == 0)
                {
                    if (!fileExport.FunctionName.Contains("削除"))
                    {
                        LogWriter.Write(fileExport.LogPathFile, string.Format("--- {0} -> {1}：{2}件", DateTime.Now.ToString(), fileExport.FunctionName, fileExport.TotalRecord));
                    }

                    return;
                }

                int rowIndex = 0;
                int columnIndex = 0;
                string header = string.Empty;
                string result = string.Empty;
                string columName = string.Empty;
                string value = string.Empty;

                if (!File.Exists(fileExport.FilePath))
                {
                    File.Create(fileExport.FilePath).Close();
                }

                StringBuilder logContents = new StringBuilder();
                StringBuilder exportContents = new StringBuilder();

                using (FileStream file = new FileStream(fileExport.FilePath, FileMode.Append, FileAccess.Write, FileShare.Read))
                using (StreamWriter writer = new StreamWriter(file, Encoding.GetEncoding("shift_jis")))
                {
                    writer.NewLine = "\r\n";
                    columnIndex = 0;

                    if (fileExport.IsHeader)
                    {
                        foreach (DataColumn column in fileExport.DataExport.Columns)
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
                            // exportContents.AppendLine(header);
                        }
                    }

                    bool flag = false;

                    foreach (DataRow row in fileExport.DataExport.Rows)
                    {
                        columnIndex = 0;
                        result = string.Empty;

                        flag = false;

                        #region loop column
                        foreach (DataColumn column in fileExport.DataExport.Columns)
                        {
                            columName = column.ColumnName;
                            value = row.IsNull(column.ColumnName) ? null : row.Field<object>(column.ColumnName).ToString();

                            //Exception column
                            if (columName.Equals("演奏時間NULL"))
                            {
                                //LogContents
                                if (value != null && value.ToString().Equals("270") && fileExport.IsWriteLog)
                                    logContents.AppendLine(row.Field<object>("選曲番号").ToString());

                                continue;
                            }


                            if (columnIndex > 0)
                            {
                                result += "\t";
                            }

                            switch (columName)
                            {
                                case "清音処理フラグ":
                                    if (!string.IsNullOrEmpty(result))
                                    {
                                        result = result.Remove(result.Length - 1, 1);
                                    }

                                    if (!string.IsNullOrEmpty(value) && value.Equals("1"))
                                    {
                                        flag = true;
                                    }

                                    break;
                                case "楽曲名ソート用カナ":
                                    if (string.IsNullOrEmpty(value))
                                    {
                                        result += value;
                                    }
                                    else
                                    {
                                        if (flag)
                                        {
                                            strVatoBa = Utils.ConvertVatoBa(value);
                                            strVatoBa = Utils.ConverNoise(strVatoBa);
                                            strVatoBa = Utils.ConvertYouonHatsuon(strVatoBa);
                                            strVatoBa = Utils.DelelteTyouon(strVatoBa);

                                            result += Utils.ToHiragana(strVatoBa);
                                        }
                                        else
                                        {
                                            result += Utils.ToHiragana(value);
                                        }
                                    }

                                    break;

                                case "タイアップ表示名":
                                    {
                                        if (string.IsNullOrEmpty(value))
                                        {
                                            result += value;
                                        }
                                        else
                                        {
                                            result += Utils.ConverTieup(value);
                                        }
                                    }
                                    break;
                                case "情報欄":
                                    {
                                        if (string.IsNullOrEmpty(value))
                                        {
                                            result += value;
                                        }
                                        else
                                        {
                                            value = Utils.ConvertDakutenNew(value);
                                            result += Utils.ToWideDakuten(value);
                                        }
                                    }
                                    break;
                                case "楽曲名":
                                case "歌手名":
                                case "タイアップ表示用":
                                case "タイアップ情報欄":
                                case "歌い出し":
                                    {
                                        if (string.IsNullOrEmpty(value))
                                        {
                                            result += value;
                                        }
                                        else
                                        {
                                            result += Utils.ToWideDakuten(value);
                                        }
                                    }
                                    break;
                                case "楽曲名検索用かな":
                                case "楽曲名ソート用かな":
                                case "歌手名検索用かな":
                                case "歌手名ソート用かな":
                                case "タイアップ検索用かな":
                                case "タイアップソート用かな":
                                case "楽曲名検索用カナ":
                                case "歌手名検索用カナ":
                                case "タイアップ検索用カナ":
                                    {
                                        if (string.IsNullOrEmpty(value))
                                        {
                                            result += value;
                                        }
                                        else
                                        {
                                            strVatoBa = Utils.ConvertVatoBa(value);
                                            result += Utils.ToHiragana(strVatoBa);
                                        }
                                    }
                                    break;
                                case "タイアップソート用カナ":
                                case "歌手名ソート用カナ":
                                    if (string.IsNullOrEmpty(value))
                                    {
                                        result += value;
                                    }
                                    else
                                    {
                                        result += Utils.ToHiragana(value);
                                    }
                                    break;
                                case "サービス発表日":
                                case "Wiiサービス発表日":
                                case "3DSサービス発表日":
                                case "Uサービス発表日":
                                    {
                                        if (string.IsNullOrEmpty(value))
                                        {
                                            result += value;
                                        }
                                        else
                                        {
                                            result += Utils.ConvertDate(value);
                                        }
                                    }
                                    break;
                                case "Lowキー":
                                case "Highキー":
                                    {
                                        if (string.IsNullOrEmpty(value))
                                        {
                                            result += '0';
                                        }
                                        else
                                        {
                                            result += value;
                                        }
                                    }
                                    break;
                                case "楽曲発売日(整備用)":
                                case "発売日":
                                case "発表日":
                                    {
                                        if (string.IsNullOrEmpty(value))
                                        {
                                            result += value;
                                        }
                                        else
                                        {
                                            DateTime outValue = DateTime.MinValue;
                                            DateTime.TryParse(value, out outValue);

                                            if (outValue != DateTime.MinValue)
                                            {
                                                result += (outValue.Year + "/" + outValue.Month.ToString().PadLeft(2, '0') + "/" + outValue.Day.ToString().PadLeft(2, '0'));
                                            }
                                            else
                                            {
                                                result += null;
                                            }
                                        }
                                    }
                                    break;
                                case "歌手ID":
                                    {
                                        if (columnIndex == 4)
                                        {
                                            if (string.IsNullOrEmpty(value))
                                            {
                                                //MsgBox("コンテンツTSV" + Constants.vbCrLf + rowIndex + 1 + "行目 " + "選曲番号:「" + withBlock.Fields.Item(0).Value + "」 の歌手IDが空です。", Constants.vbOKOnly, Constants.vbExclamation);
                                            }
                                            else
                                            {
                                                result += value;
                                            }
                                        }
                                        else if (columnIndex == 0)
                                        {
                                            if (string.IsNullOrEmpty(value))
                                            {
                                                //MsgBox("歌手TSVか歌手ランキングTSV" + Constants.vbCrLf + rowIndex + 1 + "行目 " + "選曲番号:「" + withBlock.Fields.Item(0).Value + "」 の歌手IDが空です。", Constants.vbOKOnly, Constants.vbExclamation);
                                            }
                                            else
                                            {
                                                result += value;
                                            }
                                        }
                                        else
                                        {
                                            result += value;
                                        }
                                    }
                                    break;
                                default:
                                    {
                                        result += value;
                                    }
                                    break;
                            }

                            columnIndex++;

                        }
                        #endregion

                        //exportContents.AppendLine(result);
                        writer.WriteLine(result);

                        rowIndex++;
                    }

                    // writer.WriteLine(exportContents.ToString());

                    // End write file
                    writer.Close();

                    if (fileExport.IsWriteLog)
                        LogWriter.Write(fileExport.LogPathFile1, logContents.ToString());
                }

                // Write log success
                LogWriter.Write(fileExport.LogPathFile, string.Format("--- {0} -> {1}：{2}件", DateTime.Now.ToString(), fileExport.FunctionName, fileExport.TotalRecord));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExportToTSV(string filePath, string content)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                    return;
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }

                using (FileStream file = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
                using (StreamWriter writer = new StreamWriter(file, Encoding.GetEncoding("shift_jis")))
                {
                    writer.WriteLine(content);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }

    public class FileExportTsvEntity
    {
        public DataTable DataExport { get; set; }
        public bool IsHeader { get; set; }
        public string FilePath { get; set; }
        public string FunctionName { get; set; }
        public int TotalRecord { get { return DataExport.Rows.Count; } }
        public string LogPathFile { get; set; }
        public string LogPathFile1 { get; set; }
        public bool IsWriteLog { get; set; }
    }
}
