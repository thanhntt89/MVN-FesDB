using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalObjects;
using FestivalUtilities;
using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Festival.Common
{
    public partial class ExportSearchingFile : FormBase
    {
        private FesContentBusiness contentBusiness;

        public FileExportEntity fileExportInfo = new FileExportEntity();


        public ExportSearchingFile(LayOut currentLayOut)
        {
            InitializeComponent();

            CurrentLayOutName = currentLayOut;
        }

        private void ExportSearchingFile_Load(object sender, EventArgs e)
        {
            LoadInit();
        }

        private void Export()
        {
            if (!Valid())
                return;
            if (CurrentLayOutName == LayOut.FesContentMainAdvance)
            {
                fileExportInfo = new FileExportEntity()
                {
                    FilePath = txtExportFile.Text,
                    FileName = Path.GetFileName(txtExportFile.Text),
                    FileType = radExcelExport.Checked ? FileType.Excel : FileType.TSV,
                    IsExportWithFilter = radCheckOnRecord.Checked,
                    ExportType = cboExportContent.SelectedIndex == 0 ? Constants.FES_CONTENT_EXPORT_TYPE_FES_COLLECTION_LIST : Constants.FES_CONTENT_EXPORT_TYPE_SONG_LIST
                };
            }
            else if (CurrentLayOutName == LayOut.FesVideoAssigmentMainAdvance)
            {
                if (cboExportContent.Items.Count > 0 && cboExportContent.SelectedIndex == 0)
                    fileExportInfo = new FileExportEntity()
                    {
                        FilePath = txtExportFile.Text,
                        FileName = Path.GetFileName(txtExportFile.Text),
                        FileType = radExcelExport.Checked ? FileType.Excel : FileType.TSV,
                        IsExportWithFilter = radCheckOnRecord.Checked
                    };
            }
            IsActive = true;
            this.Close();
        }

        private void bntExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileFilter();
        }

        private void OpenFileFilter()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (radTSVExport.Checked)
            {
                saveFile.Filter = Constants.SaveFileFilterTSV;
            }
            else if (radExcelExport.Checked)
            {
                saveFile.Filter = Constants.SaveFileFilterExcel;

            }
            // Load default folder export         
            var rst = saveFile.ShowDialog();
            if (rst != DialogResult.OK)
                return;

            txtExportFile.Text = saveFile.FileName;
        }

        private void radExcelExport_CheckedChanged(object sender, EventArgs e)
        {
            LoadExportChange();
        }

        private void radTSVExport_CheckedChanged(object sender, EventArgs e)
        {
            LoadExportChange();
        }

        private void LoadInit()
        {
            contentBusiness = new FesContentBusiness();
            LoadInitFesFile();
        }

        private void LoadInitFesFile()
        {
            string filePath = string.Empty;
            if (CurrentLayOutName == LayOut.FesContentMainAdvance)
            {
                radFilterRecord.Checked = true;
                radTSVExport.Checked = true;
                filePath = Properties.Settings.Default.RIBBON_EXPORT_MENU_FES_CONTENT_Fes収集リストパス + Constants.DefaultUploadFileTSV_Fes収集リスト;
            }
            else if (CurrentLayOutName == LayOut.FesVideoAssigmentMainAdvance)
            {
                radCheckOnRecord.Checked = true;
                radExcelExport.Checked = true;
                filePath = Properties.Settings.Default.RIBBON_EXPORT_MENU_FES_VIDEO_ASSIGMENT_映像割付リストパス + Constants.DefaultUploadFileExcel_Fes収集リスト;
            }
            txtExportFile.Text = filePath;
            LoadInitFesContentComboxTSV();
        }

        private void LoadInitFesContentComboxTSV()
        {
            try
            {
                string comboxData = string.Empty;
                if (CurrentLayOutName == LayOut.FesContentMainAdvance)
                    comboxData = Properties.Settings.Default.COMBOX_TSV_出力条件;
                else if (CurrentLayOutName == LayOut.FesVideoAssigmentMainAdvance)
                    comboxData = Properties.Settings.Default.FES_VIDEO_ASSIGMENT_EXPORT_DATA_出力条件;

                if (string.IsNullOrEmpty(comboxData))
                    return;

                DataTable data = contentBusiness.GetComboxTSVData(comboxData);
                // Insert data to worktable table
                cboExportContent.DataSource = data;
                cboExportContent.DisplayMember = data.Columns[0].ColumnName;
                cboExportContent.SelectedIndex = 0;
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

                LogException(error);
                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        private bool Valid()
        {
            if (cboExportContent.SelectedIndex < 0)
            {
                MessageBox.Show(GetResources.GetResourceMesssage(Constants.MESSAGE_ERROR_FILE_NOT_FOUND), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string folderOutputPath = Path.GetDirectoryName(txtExportFile.Text);

            DirectoryInfo folder = new DirectoryInfo(folderOutputPath);
            if (!folder.Exists)
            {
                MessageBox.Show(GetResources.GetResourceMesssage(Constants.MESSAGE_ERROR_FILE_NOT_FOUND), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtExportFile.Focus();
                return false;
            }

            FileInfo fileInfo = new FileInfo(txtExportFile.Text);
            if (fileInfo.Extension.Contains(Constants.OpenFileFilter))
            {
                MessageBox.Show(GetResources.GetResourceMesssage(Constants.MESSAGE_ERROR_FILE_NOT_FOUND), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtExportFile.Focus();
                return false;
            }

            return true;
        }

        private void cboExportContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadExportChange();
        }

        private void LoadExportChange()
        {
            if (CurrentLayOutName == LayOut.FesContentMainAdvance)
            {
                LoadExportContentChanged();
            }
            else if (CurrentLayOutName == LayOut.FesVideoAssigmentMainAdvance)
            {
                LoadFesVideoAssigmentChanged();
            }
        }

        private void LoadFesVideoAssigmentChanged()
        {
            if (cboExportContent.SelectedIndex == 0)
            {
                if (radExcelExport.Checked)
                {
                    txtExportFile.Text = Properties.Settings.Default.RIBBON_EXPORT_MENU_FES_VIDEO_ASSIGMENT_映像割付リストパス + Constants.DefaultUploadFileExcel_Fes収集リスト;
                }
                else if (radTSVExport.Checked)
                {
                    txtExportFile.Text = Properties.Settings.Default.RIBBON_EXPORT_MENU_FES_VIDEO_ASSIGMENT_映像割付リストパス + Constants.DefaultUploadFileTSV_Fes収集リスト;
                }
            }
        }

        private void LoadExportContentChanged()
        {
            // Fes収集リスト selected
            if (cboExportContent.SelectedIndex == 0)
            {
                if (radExcelExport.Checked)
                {
                    txtExportFile.Text = Properties.Settings.Default.RIBBON_EXPORT_MENU_FES_CONTENT_Fes収集リストパス + Constants.DefaultUploadFileExcel_Fes収集リスト;
                }
                else if (radTSVExport.Checked)
                {
                    txtExportFile.Text = Properties.Settings.Default.RIBBON_EXPORT_MENU_FES_CONTENT_Fes収集リストパス + Constants.DefaultUploadFileTSV_Fes収集リスト;
                }

            }//楽曲リスト
            else if (cboExportContent.SelectedIndex == 1)
            {
                if (radExcelExport.Checked)
                {
                    txtExportFile.Text = Properties.Settings.Default.RIBBON_EXPORT_MENU_楽曲リストパス + Constants.DefaultUploadFileExcel_楽曲リスト;
                }
                else if (radTSVExport.Checked)
                {
                    txtExportFile.Text = Properties.Settings.Default.RIBBON_EXPORT_MENU_楽曲リストパス + Constants.DefaultUploadFileTSV_楽曲リスト;
                }
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.O))
            {
                bntExport_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
