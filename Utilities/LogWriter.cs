using System;
using System.IO;
using System.Text;

namespace FestivalUtilities
{
    public  class LogWriter
    {
        public static void Write(ErrorEntity error)
        {
            Write(error.FilePath, error.GetLogInfo());
        }

        public static void Write(string filePath, string message)
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
                using (StreamWriter writer = new StreamWriter(file, Encoding.Unicode))
                {
                    writer.WriteLine(message);
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

    public class ErrorEntity
    {
        public string LogTime { get; set; }
        public string ModuleName { get; set; }
        public string ErrorMessage { get; set; }
        public int ErrorNumber { get; set; }
        public string FilePath { get; set; }
        public string GetLogInfo()
        {
            return string.Format("***************************************************************\n【発生日時】 {0}\n【発生箇所】 {1}\n【障害内容】 {2}\n", this.LogTime, this.ModuleName, this.ErrorMessage);
        }
    }
}
