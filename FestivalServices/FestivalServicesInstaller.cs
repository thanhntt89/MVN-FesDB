using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Windows.Forms;

namespace Festival
{
    [RunInstaller(true)]
    public partial class FestivalServicesInstaller : Installer
    {
        private static string settingPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private static string pathtodelete = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        private static string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        private static string productName = "Festival";
        private static string appConfigFilePath = string.Format("{0}/App.config", pathtodelete);
        private static string configFilePath = string.Format("{0}/{1}.exe.config", pathtodelete, productName);
        private static string configFileNewPath = string.Format("{0}/{1}.exe.config.default", pathtodelete, productName);
              
        public FestivalServicesInstaller()
        {            
            this.BeforeInstall += FestivalInstaller_BeforeInstall;
            this.BeforeUninstall += FestivalInstaller_BeforeUninstall;
            this.AfterInstall += FestivalInstaller_AfterInstall;
        }

        private void FestivalInstaller_AfterInstall(object sender, InstallEventArgs e)
        {          
            if (System.IO.File.Exists(configFilePath))
            {
                try
                {                   
                    if (System.IO.File.Exists(configFileNewPath))
                        System.IO.File.Copy(configFileNewPath, configFilePath, true);              
                }
                catch
                {
                   
                }
            }         
        }

        private void FestivalInstaller_BeforeInstall(object sender, InstallEventArgs e)
        {
            
        }

        protected override void OnBeforeInstall(IDictionary savedState)
        {
            base.OnBeforeInstall(savedState);   
        }

        [SecurityPermission(SecurityAction.Demand)]
        private void FestivalInstaller_BeforeUninstall(object sender, InstallEventArgs e)
        {
            
        }

        [SecurityPermission(SecurityAction.Demand)]
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }

        [SecurityPermission(SecurityAction.Demand)]
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
        }

        [SecurityPermission(SecurityAction.Demand)]
        protected override void OnCommitting(IDictionary savedState)
        {
            base.OnCommitting(savedState);

            string installedPath = string.Format("{0}/{1}.InstallState", pathtodelete, assemblyName);
            if (System.IO.File.Exists(installedPath))
                System.IO.File.Delete(installedPath);
        }

        [SecurityPermission(SecurityAction.Demand)]
        public override void Uninstall(IDictionary savedState)
        {           
           DeleteSetting();

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

        }

        /// <summary>
        /// Delete config files
        /// </summary>
        private void DeleteSetting()
        {
            try
            {
                List<string> listFile = Directory.GetFiles(pathtodelete).ToList();
                List<string> listDelete = new List<string>();                
                try
                {
                    //Delete config
                    Directory.Delete(settingPath, true);
                }
                catch
                {

                }

                string[] subDirectory = Directory.GetDirectories(pathtodelete);
                // Delete sub folder
                foreach (var folder in subDirectory)
                {
                    try
                    {
                        Directory.Delete(folder, true);
                    }
                    catch
                    {

                    }
                }

                string[] ignor = new string[] { "FestivalServices" };
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
                //MessageBox.Show(string.Format("DeleteSetting List:{0}\n Ignors: {1}", string.Join(",", listFile), string.Join(",", ignor)));

                foreach (var file in listDelete)
                {
                    try
                    {
                        System.IO.File.Delete(file);
                    }
                    catch
                    {

                    }
                }

                try
                {
                    //Delete Folder
                    Directory.Delete(pathtodelete, true);
                }
                catch
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("DeleteSetting error:{0}", ex.Message));
            }
        }
    }
}
