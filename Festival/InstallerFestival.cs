using FestivalCommon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Linq;

namespace Festival
{
    [RunInstaller(true)]
    public partial class InstallerFestival : Installer
    {
        string currentLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string[] transformationfiles = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "*.config");
              

        public override void Uninstall(IDictionary savedState)
        {
            Process application = null;
            try
            {
                foreach (var process in Process.GetProcesses())
                {
                    if (!process.ProcessName.ToLower().Contains("creatinginstaller"))
                    {
                        continue;
                    }

                    application = process;

                    break;
                }

                if (application != null && application.Responding)
                {
                    application.Kill();

                    base.Uninstall(savedState);
                }
            }
            catch
            {

            }

            DeleteSetting();
        }

        /// <summary>
        /// Delete config files
        /// </summary>
        private void DeleteSetting()
        {
            string settingPath = string.Empty;
            string pathtodelete = string.Empty;
            string productName = string.Empty;
            try
            {
                settingPath = Constants.SETTING_DATAGRIDVIEW_USER_ROOT_PATH;
                //Delete config
                DeleteAllFileInFolder(settingPath);
                productName = Assembly.GetExecutingAssembly().FullName;
                pathtodelete = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                // MessageBox.Show(string.Format("DeleteSetting folder:{0}", pathtodelete));
                string[] subDirectory = Directory.GetDirectories(pathtodelete);
                // Delete sub folder
                foreach (var folder in subDirectory)
                {
                    DeleteAllFileInFolder(folder);
                }

                //Delete root folder
                DeleteAllFileInFolder(pathtodelete, new string[] { productName + ".exe" });
            }
            catch (Exception ex)
            {
                //MessageBox.Show(string.Format("DeleteSetting error:{0}", ex.Message));
            }
        }

        /// <summary>
        /// Delete all file in folder
        /// </summary>
        /// <param name="folderPath"></param>
        private void DeleteAllFileInFolder(string folderPath, string[] ignor = null)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                    return;

                List<string> listFile = Directory.GetFiles(folderPath).ToList();

                List<string> listDelete = new List<string>();

                //Delete file              
                if (ignor != null)
                {
                    foreach (string file in listFile)
                    {
                        string fileName = Path.GetFileName(file);
                        if (ignor.Contains(fileName))
                            continue;
                        listDelete.Add(file);
                    }
                }
                else
                {
                    listDelete = listFile;
                }

                foreach (var file in listDelete)
                {
                    File.Delete(file);
                }

                //Delete Folder
                Directory.Delete(folderPath, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckFolderEmpty(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }

            var folder = new DirectoryInfo(path);
            if (folder.Exists)
            {
                return folder.GetFileSystemInfos().Length == 0;
            }

            throw new DirectoryNotFoundException();
        }
    }
}
