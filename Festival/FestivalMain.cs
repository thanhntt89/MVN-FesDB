using Festival.Base;
using Festival.UC;
using FestivalBusiness;
using FestivalBusiness.Interface;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Festival.Common;

namespace Festival
{
    public partial class FestivalMain : FormBase
    {
        private UCSqlConnection ucSqlConnection = null;
        private ICommonBusiness iCommonBusiness;

        public FestivalMain()
        {
            InitializeComponent();
            InitUCControl();         
        }

        private void InitUCControl()
        {
            tabMain.Visible = false;
            ucSqlConnection = new UC.UCSqlConnection();
            this.panelSqlChecking.Controls.Add(ucSqlConnection);
            ucSqlConnection.BackColor = System.Drawing.Color.Transparent;
            ucSqlConnection.Location = new System.Drawing.Point(7, 3);
            ucSqlConnection.Name = "ucSqlConnection";
            ucSqlConnection.Size = new System.Drawing.Size(166, 166);
            ucSqlConnection.TabIndex = 5;
        }

        private void ThreadCheckConnection()
        {
            bgwProcess = CreateThread();
            bgwProcess.DoWork += BgwProcess_DoWork;
            bgwProcess.RunWorkerCompleted += BgwProcess_RunWorkerCompleted;
            bgwProcess.RunWorkerAsync();
        }

        private void BgwProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (bgwProcess != null)
            {
                bgwProcess.DoWork -= BgwProcess_DoWork;
                bgwProcess.RunWorkerCompleted -= BgwProcess_RunWorkerCompleted;
            }
            bgwProcess = null;
            GC.Collect();
        }

        private void BgwProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckConnection();
        }

        private void CheckConnection()
        {
            Invoke(new Action(() =>
            {
                ucSqlConnection.sqlConnectedEvent += HideCheckConnect;
                ucSqlConnection.ProgeressCheckDatabase();
                panelSqlChecking.Left = (this.Width - panelSqlChecking.Width) / 2;
                panelSqlChecking.Top = (this.Height - panelSqlChecking.Height) / 2;
                Thread.Sleep(1000);
                this.panelSqlChecking.Visible = true;

                iCommonBusiness = new CommonBusiness();
            }));
        }

        private void HideCheckConnect(bool status, string databaseName)
        {
            panelSqlChecking.Visible = false;
            // Database connected
            if (status)
            {
                InitData();
                tabMain.Visible = true;
                return;
            }
            MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE044), Properties.Settings.Default.CONNECT_Server, databaseName), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);

            btnClose_Click(null, null);
        }

        private void InitData()
        {
            GetVersion();
            Authority();
            CreateTaleWork();
            RunSqlQuery();
            CreateNewColumns();
        }

        private void CreateNewColumns()
        {
            try
            {
                iCommonBusiness.CreateNewColumns();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = Constants.LOG_FILE_PATH_ERROR
                };

                this.LogException(error);
            }
        }

        private void RunSqlQuery()
        {
            try
            {
                iCommonBusiness.RunSqlQuery();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetType().Name + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = Constants.LOG_FILE_PATH_ERROR
                };

                this.LogException(error);

                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        private void CreateTaleWork()
        {
            try
            {
                iCommonBusiness.CreateWorkTable();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = Constants.LOG_FILE_PATH_ERROR
                };

                this.LogException(error);
            }
        }

        private void DropTableFesWork()
        {
            try
            {
                if (tabMain.Visible)
                    iCommonBusiness.DropTableFesWork();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = Constants.LOG_FILE_PATH_ERROR
                };

                this.LogException(error);
            }
        }

        private void GetVersion()
        {
            try
            {
                lblCurrentVersion.Text = Constants.VERSION_TEXT;// + iCommonBusiness.GetCurrentVersion();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = Constants.LOG_FILE_PATH_ERROR
                };

                this.LogException(error);
            }
        }

        private void Authority()
        {
            string userAuthority = string.Empty;
            try
            {
                DataTable dtRole = iCommonBusiness.GetRole();

                int rowIndex = 0;

                int countRole = 0;

                foreach (DataRow row in dtRole.Rows)
                {
                    if (rowIndex == 0)
                    {
                        userAuthority = row.Field<string>(0).ToString();
                    }
                    var tagId = row.Field<int?>(1);
                    var roleType = row.Field<int?>(2);
                    if ((roleType == 1 || roleType == 2) && tagId != null && roleType != null)
                    {
                        // Set menu active
                        if (menuDataBaseTab.ActiveMenuByTagId(tagId.ToString(), (EnumEditMode)roleType))
                        {
                            countRole++;
                            continue;
                        }
                        if (menuDisTab.ActiveMenuByTagId(tagId.ToString(), (EnumEditMode)roleType))
                        {
                            countRole++;
                            continue;
                        }
                        if (menuManagementTab.ActiveMenuByTagId(tagId.ToString(), (EnumEditMode)roleType))
                        {
                            countRole++;
                            continue;
                        }
                    }
                    rowIndex++;
                }

                if (countRole == 0)
                {
                    userAuthority = string.Empty;
                }
                if (string.IsNullOrEmpty(userAuthority))
                {
                    MessageBox.Show(GetResources.GetResourceMesssage(Constants.MESSAGE_ERROR_NO_AUTHORITY), GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

                this.Text = string.Format("Festival　メニュー　<< {0}({1}) >>", userAuthority.Trim(), Environment.UserName);
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = Constants.LOG_FILE_PATH_ERROR
                };

                LogException(error);

                MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }

        private void FestivalMain_Load(object sender, EventArgs e)
        {
            ThreadCheckConnection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FestivalMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DropTableFesWork();
        }        

    }
}
