using System;
using System.Text;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace FestivalUtilities
{
    public class Utils
    {
        public static bool IsHankakuEiSu(string values)
        {
            if (string.IsNullOrEmpty(values))
                return false;
            return Regex.IsMatch(values, "^[A-Za-z0-9]+$");
        }

        public static bool IsHiragana(string values)
        {
            if (string.IsNullOrEmpty(values))
                return false;
            return Regex.IsMatch(values, "^[ぁ-んー]+$");//[一-龥ぁ-ん]
        }

        public static bool IsKatakana(string values)
        {
            if (string.IsNullOrEmpty(values))
                return false;
            return Regex.IsMatch(values, "^[ァ-ンー]+$");//[ァ-ン一-龥]
        }

        /// <summary>
        /// string with comma
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IList<string> GetItems(string values)
        {
            return values.Split(';').ToList();
        }

        // Unicodeでは濁点や半濁点を別扱いしてることがあるので結合した
        public static string ConvertDakutenNew(string str)
        {
            string result = str;
            try
            {
                string[,] replaceArr = new string[50, 2] {
                    { "ヂ", "ヂ"},
                    { "グ", "グ"},
                    { "ボ", "ボ"},
                    { "ぎ", "ぎ"},
                    { "ず", "ず"},
                    { "プ", "プ"},
                    { "デ", "デ"},
                    { "パ", "パ"},
                    { "ゼ", "ゼ"},
                    { "ぴ", "ぴ"},
                    { "ぞ", "ぞ"},
                    { "ブ", "ブ"},
                    { "ギ", "ギ"},
                    { "だ", "だ"},
                    { "バ", "バ"},
                    { "ぽ", "ぽ"},
                    { "ズ", "ズ"},
                    { "ぷ", "ぷ"},
                    { "ポ", "ポ"},
                    { "じ", "じ"},
                    { "ぢ", "ぢ"},
                    { "べ", "べ"},
                    { "ぱ", "ぱ"},
                    { "ジ", "ジ"},
                    { "ザ", "ザ"},
                    { "び", "び"},
                    { "げ", "げ"},
                    { "が", "が"},
                    { "ビ", "ビ"},
                    { "ベ", "ベ"},
                    { "ぶ", "ぶ"},
                    { "ば", "ば"},
                    { "ざ", "ざ"},
                    { "ペ", "ペ"},
                    { "ぼ", "ぼ"},
                    { "ヅ", "ヅ"},
                    { "ゲ", "ゲ"},
                    { "ぺ", "ぺ"},
                    { "ガ", "ガ"},
                    { "ゴ", "ゴ"},
                    { "ゾ", "ゾ"},
                    { "ピ", "ピ"},
                    { "で", "で"},
                    { "ぜ", "ぜ"},
                    { "ぐ", "ぐ"},
                    { "ド", "ド"},
                    { "ど", "ど"},
                    { "ダ", "ダ"},
                    { "づ", "づ"},
                    { "ご", "ご"},
                    };


                for (int i = 0; i < replaceArr.GetLength(0); i++)
                {
                    result = result.Replace(replaceArr[i, 0], replaceArr[i, 1]);
                }
            }
            catch
            {

            }
            return result;
        }

        // Convert　タイアップ表示名
        public static string ConverTieup(string str)
        {
            string result = str;
            try
            {
                string[,] replaceArr = new string[50, 2] {
                    { "ヂ", "チ゛"},
                    { "グ", "ク゛"},
                    { "ボ", "ホ゛"},
                    { "ぎ", "き゛"},
                    { "ず", "す゛"},
                    { "プ", "フ゛"},
                    { "デ", "テ゛"},
                    { "パ", "ハ゛"},
                    { "ゼ", "セ゛"},
                    { "ぴ", "ひ゛"},
                    { "ぞ", "そ゛"},
                    { "ブ", "フ゛"},
                    { "ギ", "キ゛"},
                    { "だ", "た゛"},
                    { "バ", "ハ゛"},
                    { "ぽ", "ほ゛"},
                    { "ズ", "ス゛"},
                    { "ぷ", "ふ゛"},
                    { "ポ", "ホ゛"},
                    { "じ", "し゛"},
                    { "ぢ", "ち゛"},
                    { "べ", "へ゛"},
                    { "ぱ", "は゛"},
                    { "ジ", "シ゛"},
                    { "ザ", "サ゛"},
                    { "び", "ひ゛"},
                    { "げ", "け゛"},
                    { "が", "か゛"},
                    { "ビ", "ヒ゛"},
                    { "ベ", "へ゛"},
                    { "ぶ", "ふ゛"},
                    { "ば", "は゛"},
                    { "ざ", "さ゛"},
                    { "ペ", "へ゛"},
                    { "ぼ", "ほ゛"},
                    { "ヅ", "そ゛"},
                    { "ゲ", "ケ゛"},
                    { "ぺ", "へ゛"},
                    { "ガ", "カ゛"},
                    { "ゴ", "コ゛"},
                    { "ゾ", "ソ゛"},
                    { "ピ", "ヒ゛"},
                    { "で", "て゛"},
                    { "ぜ", "せ゛"},
                    { "ぐ", "く゛"},
                    { "ド", "ト゛"},
                    { "ど", "と゛"},
                    { "ダ", "タ゛"},
                    { "づ", "つ゛"},
                    { "ご", "こ゛"},
                    };

                for (int i = 0; i < replaceArr.GetLength(0); i++)
                {
                    result = result.Replace(replaceArr[i, 0], replaceArr[i, 1]);
                }
            }
            catch
            {

            }
            return result;
        }

        /// <summary>
        /// Check string is datetime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>TRUE is date time | False not datetime</returns>
        public static bool IsDataTime(string value)
        {
            DateTime dateOut = DateTime.MinValue;
            return DateTime.TryParse(value, out dateOut);
        }

        /// <summary>
        /// Convert to date time
        /// </summary>
        /// <param name="value">yyyyMMdd</param>
        /// <returns>datetime</returns>
        public static DateTime? ConvertToDataTime(string value)
        {
            if (!IsNumeric(value))
                return null;
            try
            {
                int year = int.Parse(value.Substring(0, 4));
                int month = int.Parse(value.Substring(4, 2));
                int day = int.Parse(value.Substring(6, 2));
                return new DateTime(year, month, day);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Convert to date time
        /// </summary>
        /// <param name="value">yyyyMMdd</param>
        /// <returns>datetime</returns>
        public static string ConvertDataTimeToString(string value, string format)
        {
            if (!IsNumeric(value))
                return string.Empty;
            try
            {
                int year = int.Parse(value.Substring(0, 4));
                int month = int.Parse(value.Substring(4, 2));
                int day = int.Parse(value.Substring(6, 2));
                DateTime dt = new DateTime(year, month, day);
                return dt.ToString(format);
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Check data is number
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        public static bool IsNumericEN(string value)
        {
            return Regex.IsMatch(value, "^[0-9]*$");
        }

        public static bool IsCharacterEN(string value)
        {
            return Regex.IsMatch(value, "^[A-Za-z0-9]+$");
        }


        /// <summary>
        /// Check data is boolean
        /// </summary>
        /// <param name="value"></param>
        /// <returns>TRUE is boolean | False not boolean</returns>
        public static bool IsBoolean(string value)
        {
            bool data = false;
            return Boolean.TryParse(value, out data);
        }

        internal static string ConverNoise(string strVatoBa)
        {
            string result = strVatoBa;
            try
            {
                string[,] replaceArr = new string[25, 2] {
                    { "ガ", "カ"},
                    { "ギ", "キ"},
                    { "グ", "ク"},
                    { "ゲ", "ケ"},
                    { "ゴ", "コ"},
                    { "ザ", "サ"},
                    { "ジ", "シ"},
                    { "ズ", "ス"},
                    { "ゼ", "セ"},
                    { "ゾ", "ソ"},
                    { "ダ", "タ"},
                    { "ヂ", "チ"},
                    { "ヅ", "ツ"},
                    { "デ", "テ"},
                    { "ド", "ト"},
                    { "バ", "ハ"},
                    { "ビ", "ヒ"},
                    { "ブ", "フ"},
                    { "ベ", "ヘ"},
                    { "ボ", "ホ"},
                    { "パ", "ハ"},
                    { "ピ", "ヒ"},
                    { "プ", "フ"},
                    { "ペ" ,"ヘ"},
                    { "ポ","ホ"},
                    };

                for (int i = 0; i < replaceArr.GetLength(0); i++)
                {
                    result = result.Replace(replaceArr[i, 0], replaceArr[i, 1]);
                }
            }
            catch
            {

            }
            return result;
        }

        internal static string ConvertYouonHatsuon(string strVatoBa)
        {
            string result = strVatoBa;
            try
            {
                string[,] replaceArr = new string[9, 2] {
                    { "ァ", "ア"},
                    { "ィ", "イ"},
                    { "ゥ", "ウ"},
                    { "ェ", "エ"},
                    { "ォ", "オ"},
                    { "ッ", "ツ"},
                    { "ャ", "ヤ"},
                    { "ュ", "ユ"},
                    { "ョ", "ヨ"}
                    };

                for (int i = 0; i < replaceArr.GetLength(0); i++)
                {
                    result = result.Replace(replaceArr[i, 0], replaceArr[i, 1]);
                }
            }
            catch
            {

            }
            return result;
        }

        internal static string DelelteTyouon(string strVatoBa)
        {
            string strSerch = "ー";
            string strChange = "";
            return strVatoBa.Replace(strSerch, strChange);
        }

        // Convert string to WideDakuten
        public static string ToWideDakuten(string str)
        {

            bool bIsDakuten = false;
            bool bIsHanDakuten = false;
            string result = str;

            try
            {
                if (result.Contains("゛"))
                {
                    bIsDakuten = true;
                    result = result.Replace("゛", @"\濁点\");
                }

                if (result.Contains("゜"))
                {
                    bIsHanDakuten = true;
                    result = result.Replace("゜", @"\半濁点\");
                }
                result = Strings.StrConv(result, VbStrConv.Wide);

                if (bIsDakuten)
                {
                    result = result.Replace(@"\濁点\", "゛");
                }

                if (bIsHanDakuten)
                {
                    result = result.Replace(@"\半濁点\", "゜");
                }
            }
            catch
            {

            }
            return result;
        }

        // Convert Date from YYYYMMDD to YYYY/MM/DD
        public static string ConvertDate(string date, string originFormat = "yyyymmdd", string targetFormat = @"yyyy\/mm\/dd")
        {
            string result = string.Empty;
            try
            {
                return DateTime.ParseExact(date, originFormat, DateTimeFormatInfo.InvariantInfo).ToString(targetFormat);
            }
            catch
            {

            }
            return result;
        }

        // Convert katakana characters into hiragana.
        public static string ToHiragana(string str)
        {
            string result = string.Empty;
            try
            {
                result = Strings.StrConv(str, VbStrConv.Hiragana);
            }
            catch
            {

            }
            return result;
        }

        // Convert string to Vatoba
        public static string ConvertVatoBa(string str)
        {
            string result = str;
            try
            {
                string[,] replaceArr = new string[5, 2] { { "ヴァ", "バ" }, { "ヴィ", "ビ" }, { "ヴェ", "ベ" }, { "ヴォ", "ボ" }, { "ヴ", "ブ" }, };
                for (int i = 0; i < replaceArr.GetLength(0); i++)
                {
                    result = result.Replace(replaceArr[i, 0], replaceArr[i, 1]);
                }
            }
            catch
            {

            }
            return result;
        }

        /// <summary>
        /// Create file path
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string CreateFilePath(string[] array = null)
        {
            if (array == null)
                return string.Empty;

            string filePath = string.Empty;

            foreach (var item in array)
            {
                filePath += item + "\\";
            }

            return filePath.Remove(filePath.Length - 1);
        }

        public static void OpenFileByPath(string filePath)
        {
            try
            {
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete all file in folder
        /// </summary>
        /// <param name="folderPath"></param>
        public static void DeleteAllFileInFolder(string folderPath, string[] ignor = null)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                    return;
                // Delete files
                string[] listFile = Directory.GetFiles(folderPath);
                bool exist = false;

                foreach (var file in listFile)
                {
                    if (ignor != null)
                    {
                        foreach (var item in ignor)
                        {
                            if (file.Contains(item))
                                exist = true;
                        }
                        if (exist) continue;
                    }

                    File.Delete(file);
                }

                // Get sub directory
                string[] subDirectory = Directory.GetDirectories(folderPath);
                // Loop
                foreach (var folder in subDirectory)
                {
                    DeleteAllFileInFolder(folder);
                }

                //Delete Folder
                Directory.Delete(folderPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Check file exist in folder
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public static bool CheckFileExistInFolder(string folderPath)
        {
            try
            {
                string[] listFile = Directory.GetFiles(folderPath);
                return listFile.Length > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CheckPathIsFolder(string folderPath)
        {

            return Path.GetDirectoryName(folderPath) == folderPath.TrimEnd(Path.DirectorySeparatorChar.ToString().ToCharArray());
        }

        public static void DeleteExistAndCreateNewFile(string filePath)
        {
            try
            {
                // Directory Exist delete file 
                if (File.Exists(filePath) && !CheckFileInUsed(filePath))
                {
                    File.Delete(filePath);
                }
                // Create a new file
                File.Create(filePath).Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteFile(string filePath)
        {
            try
            {
                // Directory Exist delete file 
                if (File.Exists(filePath) && !CheckFileInUsed(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CheckFileInUsed(string filePath)
        {
            FileStream stream = null;
            try
            {
                FileInfo file = new FileInfo(filePath);
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                // File in used
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();

            }
            // file free
            return false;
        }


        public static int OpenFileByNotepad(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return -1;
                }

                var shellType = Type.GetTypeFromProgID("Wscript.Shell");
                dynamic shell = Activator.CreateInstance(shellType);
                //oShell.Run strArgs, 0, false

                var startArgs = new ProcessStartInfo
                {
                    Arguments = filePath,
                    FileName = "notepad.exe",
                    WorkingDirectory = Path.GetDirectoryName(filePath),
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Normal
                };

                var shellProcess = Process.Start(startArgs);
                shellProcess.Close();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        public static bool CreateDirectory(string directoryPath)
        {
            try
            {
                if (string.IsNullOrEmpty(directoryPath))
                    return false;
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
