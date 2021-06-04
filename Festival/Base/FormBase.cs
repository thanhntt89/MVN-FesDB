using Festival.Common;
using Festival.DBTab;
using FestivalObjects;
using FestivalUtilities;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using static Festival.Common.FestivalEvents;

namespace Festival.Base
{
    public partial class FormBase : DevComponents.DotNetBar.Metro.MetroForm
    {
        public string logExceptionPath = Application.StartupPath + "\\exception_log.txt";
        public string logFesTsvExportPath = Properties.Settings.Default.FEST_TSV_LOG_PATH_ログファイル;
        public const string MODULE_FES_TSV_EXPORT = "MODULE_FES_TSV_EXPORT";
        public static string EXPORT_LOCAL_FOLDER_WORK = Application.StartupPath + "\\" + Properties.Settings.Default.FES_EXPORT_LOCAL_FOLDER_WORK_作業フォルダ;

        public CommonEventHandler FilterOffEvent;
        public AddNewEventHandler AddNewRowEvent;
        public AddNewEventHandler UpdateRowEvent;

        public LayOut CurrentLayOutName;
        public LayOutEntity CurrentLayOut;

        public TsvExportCollection exportCollection = new TsvExportCollection();

        // Set status
        public bool IsActive = false;
        public object DataUpdate;
        public bool? Status = null;
        
        /// <summary>
        /// Write log exception
        /// </summary>
        /// <param name="ex">Exception</param>
        public void LogException(ErrorEntity error)
        {
            try
            {
                LogWriter.Write(error.FilePath, error.GetLogInfo());
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    MessageBox.Show("Writer log files fail: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        /// <summary>
        /// Write log info
        /// </summary>
        /// <param name="content"></param>
        /// <param name="logFilePath"></param>
        public void LogInfo(string content, string logFilePath)
        {
            try
            {
                LogWriter.Write(logFilePath, content);
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    MessageBox.Show("Writer log files fail: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        public void DeleteLogFile()
        {
            try
            {
                if (File.Exists(logFesTsvExportPath))
                    File.Delete(logFesTsvExportPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExportToCSV(FileExportEntity exportFileEntity)
        {
            try
            {
                if (File.Exists(exportFileEntity.FilePath))
                {
                    File.Delete(exportFileEntity.FilePath);
                }

                if (exportFileEntity.TotalRecord > 0)
                {
                    //  LogWriter.Write(exportFileEntity.FilePath, exportFileEntity.Content);
                    LogInfo(string.Format("--- {0} -> {1}：{2} 件", DateTime.Now.ToString(), exportFileEntity.FunctionName, exportFileEntity.TotalRecord), exportFileEntity.ModuleName);
                }
                else if (!exportFileEntity.FunctionName.Contains("削除"))
                {
                    LogInfo(string.Format("--- {0} -> {1}：{2} 件", DateTime.Now.ToString(), exportFileEntity.FunctionName, exportFileEntity.TotalRecord), exportFileEntity.ModuleName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add log file
        /// </summary>
        /// <param name="content"></param>
        public void AddLog(string content, string logModule)
        {
            try
            {
                string logFilePath = logExceptionPath;

                if (logModule.Equals(MODULE_FES_TSV_EXPORT))
                {
                    logFilePath = logFesTsvExportPath;
                }

                LogWriter.Write(logFilePath, content);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Return class Name
        /// </summary>
        /// <returns></returns>
        public string GetClassName()
        {
            return this.GetType().Name;
        }

        public WaitingForm waiting = null;
        public BackgroundWorker bgwProcess = null;

        public BackgroundWorker CreateThread()
        {
            if (bgwProcess == null)
                bgwProcess = new BackgroundWorker();
            bgwProcess.WorkerSupportsCancellation = true;
            return bgwProcess;
        }

        public void ShowWating()
        {
            if (waiting == null)
                waiting = new WaitingForm();
            waiting.ShowDialog();
        }

        public void ClosedWaiting()
        {
            Invoke(new Action(() =>
            {
                if (waiting != null)
                {
                    waiting.Close();
                    waiting = null;
                }
            }));
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormBase
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.DoubleBuffered = true;
            this.Name = "FormBase";
            this.ResumeLayout(false);

        }
    }

    public class LogInfoEntity
    {
        public string FilePath { get; set; }
        public string Conents { get; set; }
        public string ModuleName { get; set; }
    }
}
