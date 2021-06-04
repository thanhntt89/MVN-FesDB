using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Festival.DiscVideoTab.FesVideoLock
{
    public partial class ImportVideoCodeLock : FormBase
    {

        private DataTable dtImport = new DataTable();
        private VideoCodeLockBusiness videoCodeLockBusiness = new VideoCodeLockBusiness();

        public ImportVideoCodeLock()
        {
            InitializeComponent();
        }

        private void btnClosed_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnOpenFile_Click(object sender, System.EventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "TSV|*.tsv|CSV|*.csv|TXT|*.txt";
            var rst = openFile.ShowDialog();
            if (rst != DialogResult.OK)
                return;
            txtInputFilePath.Text = openFile.FileName;
        }

        private void btnImport_Click(object sender, System.EventArgs e)
        {
            ImportData();
        }

        private bool Valid()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtInputFilePath.Text))
                {
                    this.ClosedWaiting();
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(GetResources.GetResourceMesssage(Constants.MESSAGE_ERROR_FILE_NOT_FOUND), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInputFilePath.Focus();
                    }));
                    return false;
                }

                FileInfo file = new FileInfo(txtInputFilePath.Text);

                if (!file.Exists)
                {
                    Invoke(new Action(() =>
                    {
                        this.ClosedWaiting();
                        MessageBox.Show(GetResources.GetResourceMesssage(Constants.MESSAGE_ERROR_FILE_NOT_FOUND), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInputFilePath.Focus();
                    }));
                    return false;
                }

                if (file.Length == 0 ||
                    (file.Length > 0 && !File.ReadAllLines(txtInputFilePath.Text).Where(dat => !String.IsNullOrWhiteSpace(dat.Trim())).Any())
                )
                {
                    Invoke(new Action(() =>
                    {
                        this.ClosedWaiting();
                        MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGE026), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInputFilePath.Focus();
                    }));

                    return false;
                }

                //Define column
                if (dtImport.Columns.Count == 0)
                {
                    dtImport.Columns.Add("VideoCode", typeof(string));
                    dtImport.Columns.Add("MaterialID", typeof(int));
                    dtImport.Columns.Add("Contents", typeof(string));
                    dtImport.Columns.Add("MaterialEndDate", typeof(string));
                }
                //Clear row
                dtImport.Rows.Clear();

                var dataImport = File.ReadAllLines(txtInputFilePath.Text);
                var totalRecords = dataImport.Count();

                for (int index = 0; index < totalRecords; index++)
                {
                    var row = dataImport[index].Split('\t');
                    int columns = row.Count();
                    if (columns != 4)
                    {
                        Invoke(new Action(() =>
                        {
                            this.ClosedWaiting();
                            MessageBox.Show(string.Format("4カラム以外の行があったため取り込めませんでした。: {0} 行目", index), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    if (string.IsNullOrWhiteSpace(row[0]))
                    {
                        MessageBox.Show(string.Format("{0} 行目、{1} 番目の列はご入力必須項目です。", index, "背景映像コード"), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    // Check length
                    if (row[3].Length > 9 || !Utils.IsNumeric(row[3]) || !Utils.IsNumeric(row[1]))
                    {
                        Invoke(new Action(() =>
                        {
                            this.ClosedWaiting();
                            MessageBox.Show(string.Format("{0}行目 素材終了日タサイズのフォーマットが違います。", index), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        return false;
                    }

                    dtImport.Rows.Add(row[0], int.Parse(row[1]), row[2], row[3]);
                }

                return true;
            }
            catch (Exception ex)
            {
                this.ClosedWaiting();
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = Constants.LOG_FILE_PATH_ERROR
                };

                LogException(error);
                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));

                return false;
            }
        }

        private void ImportData()
        {
            try
            {
                if (!Valid())
                    return;

                videoCodeLockBusiness.ImportData(dtImport);
                //Set active import
                this.IsActive = true;
                this.Close();
            }
            catch (Exception ex)
            {
                this.ClosedWaiting();
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = Constants.LOG_FILE_PATH_ERROR
                };

                LogException(error);
                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        private void ImportVideoCodeLock_Load(object sender, EventArgs e)
        {
            txtInputFilePath.Text = Properties.Settings.Default.FES_IMPORT_VIDEO_CODE_LOCK_PATH_背景映像コード;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                btnImport_Click(null, null);
                return true;
            }
            if(keyData == Keys.C)
            {
                btnClosed_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
