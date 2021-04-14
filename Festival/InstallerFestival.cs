using FestivalCommon;
using FestivalUtilities;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Festival
{
    [RunInstaller(true)]
    public partial class InstallerFestival : Installer
    {
        public InstallerFestival()
        {
            InitializeComponent();
        }

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
            try
            {               
                string settingPath = string.Empty;
                string pathtodelete = string.Empty;
                string productName = string.Empty;

                settingPath = Constants.SETTING_DATAGRIDVIEW_USER_ROOT_PATH;
                //Delete config
                Utils.DeleteAllFileInFolder(settingPath);
                productName = Assembly.GetExecutingAssembly().FullName;
                pathtodelete = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                string[] subDirectory = Directory.GetDirectories(pathtodelete);
                // Delete sub folder
                foreach (var folder in subDirectory)
                {
                    Utils.DeleteAllFileInFolder(folder);
                }
                //Delete root folder
                Utils.DeleteAllFileInFolder(pathtodelete, new string[] { productName + ".exe" });
            }
            catch
            {

            }
        }
    }
}
