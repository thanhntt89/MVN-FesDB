using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;

namespace Festival.DiscVideoTab.FesVideoLock
{
    public partial class VideoMaintenanceMain : FormBase
    {
        private VideoCodeLockBusiness videoCodeLockBusiness = new VideoCodeLockBusiness();
        private DataGridViewCell currentCell = null;
        public VideoMaintenanceMain()
        {
            InitializeComponent();
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

            System.Drawing.Size screenSize = Screen.PrimaryScreen.Bounds.Size;

            if (this.Height > screenSize.Height)
            {
                this.Height = screenSize.Height;
            }
            if (this.Width > screenSize.Width)
            {
                this.Width = screenSize.Width;
            }
        }

        private void InitDataGridView()
        {
            dataGridViewFilter.ColumnDeletedDataPropertyName = colDelete.DataPropertyName;
            dataGridViewFilter.AllowUserEdit = true;
            dataGridViewFilter.DataGridViewSource = advVideoMain;
            dataGridViewFilter.ColumnKeyDataPropertyName = colVideoCodeId.DataPropertyName;
            dataGridViewFilter.ColumnUpdateTimeDataPropertyName = colUpdateDate.DataPropertyName;
            dataGridViewFilter.ColumnUpdateTimeName = colUpdateDate.Name;
            dataGridViewFilter.CellClickedEvent += CellClick;
            dataGridViewFilter.CellEndEditEvent += CellEndEditEvent;

            LoadCombox();
            dataGridViewFilter.InitData();
        }

        private void CellClick(DataGridViewCell cell)
        {
            currentCell = cell;
            Delete(cell);
        }

        private void Delete(DataGridViewCell cell)
        {
            if (cell == null || !cell.OwningColumn.Name.Equals(colDelete.Name) || cell.OwningRow.Index == cell.DataGridView.Rows.Count - 1)
                return;

            string videoLockId = string.Empty;
            string videoCode = string.Empty;
            videoLockId = cell.OwningRow.Cells[colVideoCodeId.Name].Value.ToString();

            if (cell.OwningRow.Cells[colOldVideoCode.Name].Value == DBNull.Value)
            {
                //Delete import
                if (this.IsActive)
                {
                    try
                    {
                        dataGridViewFilter.RemoveRow(videoLockId);
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
                //Add new 
                else
                {
                    cell.DataGridView.Rows.Remove(cell.OwningRow);
                }
                //If empty import reload
                if (dataGridViewFilter.Count == 0)
                {
                    LoadData();
                }

                return;
            }
            //Delete not null          
            videoCode = cell.OwningRow.Cells[colOldVideoCode.Name].Value.ToString();
            string message = colVideoCode.HeaderText + ": " + videoCode;
            DialogResult rst = MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA004), message), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;
            try
            {
                videoCodeLockBusiness.Delete(videoCode);
                dataGridViewFilter.RemoveRow(videoLockId);

                //If empty import reload
                if (dataGridViewFilter.Count == 0)
                {
                    LoadData();
                }
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

        private void CellEndEditEvent(DataGridViewCell cell)
        {
            if (cell == null || cell.OwningColumn.Index < 1)
                return;
            cell.OwningRow.Cells[colVideoCodeId.Name].Value = Guid.NewGuid();
            if (cell.OwningColumn.Name.Equals(colVideoCode.Name))
            {
                cell.OwningRow.Cells[colVideoCode.Name].Value = cell.OwningRow.Cells[colVideoCode.Name].Value.ToString().Trim();
            }
            cell.OwningRow.Cells[colChoice.Name].Value = true;
        }

        private void VideoMaintenanceMain_Load(object sender, System.EventArgs e)
        {
            InitDataGridView();
            LoadData();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                btnSave_Click(null, null);
            }
            else if (keyData == (Keys.Control | Keys.I))
            {
                btnImport_Click(null, null);
            }
            else if (keyData == (Keys.Control | Keys.C))
            {
                dataGridViewFilter.Copy();
                return true;
            }
            else if (keyData == Keys.Delete)
            {
                DeleteDateTime();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DeleteDateTime()
        {
            if (currentCell == null || !currentCell.OwningColumn.Name.Equals(colMaterialEndDate.Name))
                return;
            currentCell.Value = DBNull.Value;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (!Valid())
                return;

            DataTable dtSave = GetUpdateData();
            int updateCount = 0;
            try
            {
                videoCodeLockBusiness.Save(dtSave, ref updateCount);
                if (dtSave.Rows.Count == updateCount)
                {
                    ResetStatus();
                    MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGI007), GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadData();
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

        private void ResetStatus()
        {
            DataTable dt = GetUpdateData();

            foreach (DataRow row in dt.Rows)
            {
                string videoLockId = row[colVideoCode.DataPropertyName].ToString();

                DataRow rowUpdate = dataGridViewFilter.DataTableSource.AsEnumerable().Where(r => r.Field<object>(colVideoCode.DataPropertyName).ToString().Equals(videoLockId)).FirstOrDefault();

                rowUpdate[colUpdateDate.DataPropertyName] = DBNull.Value;
                rowUpdate[colOldVideoCode.DataPropertyName] = videoLockId;
                rowUpdate[colChoice.DataPropertyName] = DBNull.Value;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            this.IsActive = false;
            ImportVideoCodeLock importVideoCodeLock = new ImportVideoCodeLock();
            importVideoCodeLock.ShowDialog();
            if (importVideoCodeLock.IsActive)
            {
                LoadImportData();
            }
        }


        private void LoadImportData()
        {
            try
            {
                DataTable tbTmp = videoCodeLockBusiness.LoadDataImport();
                DataTable tbCurrentData = dataGridViewFilter.DataTableSource;
                //Check exist file 
                var videoCodeExist = (from t1 in tbTmp.AsEnumerable()
                                      join t2 in tbCurrentData.AsEnumerable()
                                      on t1.Field<string>("VideoCode") equals t2.Field<string>("VideoCode")
                                      select new
                                      {
                                          Choice = t1.Field<int?>("Choice"),
                                          VideoCode = t1.Field<string>("VideoCode"),
                                          MaterialID = t1.Field<int?>("MaterialID"),
                                          Contents = t1.Field<string>("Contents"),
                                          MaterialEndDate = t1.Field<DateTime?>("MaterialEndDate"),
                                          BackgroundVideoLock = t1.Field<int?>("BackgroundVideoLock"),
                                          OldVideoCode = t2.Field<string>("OldVideoCode"),
                                          OldMaterialID = t2.Field<int?>("OldMaterialID"),
                                          OldContents = t2.Field<string>("Contents"),
                                          OldMaterialEndDate = t2.Field<DateTime?>("OldMaterialEndDate"),
                                          OldBackgroundVideoLock = t2.Field<int?>("OldBackgroundVideoLock"),
                                          UpdateDate = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                                          VideoCodeId = t1.Field<object>("VideoCodeId")
                                      }).ToList();

                if (videoCodeExist.Count > 0)
                {
                    DialogResult rst = MessageBox.Show(string.Format("既に登録されている背景映像コードが含まれていますが、入力を進めてよろしいでしょうか。"), GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rst == DialogResult.No)
                        return;
                }

                //Delete old value
                foreach (var row in videoCodeExist)
                {
                    DataRow existRow = tbCurrentData.AsEnumerable().Where(r => r.Field<string>("VideoCode").Equals(row.VideoCode)).FirstOrDefault();
                    if (existRow != null)
                        tbCurrentData.Rows.Remove(existRow);
                }
                //Merge new values
                tbCurrentData.Merge(tbTmp);

                //Sort
                //tbCurrentData.DefaultView.Sort = string.Format("VideoCode asc");
                dataGridViewFilter.DataTableSource = tbCurrentData;

                Invoke(new Action(() =>
                {
                    dataGridViewFilter.LoadData();
                }));
                //Set import status
                this.IsActive = true;
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

        private void LoadCombox()
        {
            try
            {
                // 邦題優先フラグ
                DataTable dtSource = videoCodeLockBusiness.GetDataCombox();
                colBackgroundVideoLock.DataSource = dtSource;
                colBackgroundVideoLock.DisplayMember = dtSource.Columns[1].ColumnName;
                colBackgroundVideoLock.ValueMember = dtSource.Columns[0].ColumnName;
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

        private void LoadData()
        {
            try
            {
                dataGridViewFilter.DataTableSource = videoCodeLockBusiness.GetVideoCodeLockAll();
                Invoke(new Action(() =>
                {
                    dataGridViewFilter.LoadData();
                }));
                //Reset filter
                this.IsActive = false;
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

        private bool Valid()
        {
            try
            {
                var dtUpdate = GetUpdateData();

                if ((dtUpdate == null || dtUpdate.Rows.Count == 0))
                {
                    MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGI009), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                DataTable dtVideos = new DataTable();

                var countExist = dtUpdate.AsEnumerable().GroupBy(r => r.Field<string>(colVideoCode.DataPropertyName)).Select(g => new
                {
                    VideoCode = g.Key,
                    Count = g.Count()
                });

                if (countExist != null)
                {
                    foreach (var video in countExist)
                    {
                        if (video.Count > 1)
                        {
                            MessageBox.Show(string.Format("{0}: {1} は存在しています。", colVideoCode.HeaderText, video.VideoCode), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }

                // Valid info
                foreach (DataRow row in dtUpdate.Rows)
                {
                    if (!CheckIsNull(colVideoCode.HeaderText, row[colVideoCode.DataPropertyName]))
                        return false;

                    //Check exist
                    if (!row[colOldVideoCode.DataPropertyName].Equals(row[colVideoCode.DataPropertyName]))
                    {
                        dtVideos = videoCodeLockBusiness.GetVideoCodeLockById(row[colVideoCode.DataPropertyName].ToString());
                        if (dtVideos.Rows.Count != 0)
                        {
                            MessageBox.Show(string.Format("{0}: {1} は存在しています。", colVideoCode.HeaderText, row[colVideoCode.DataPropertyName].ToString()), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }

                string messageContents = string.Empty;

                //Get count edit
                if (dtUpdate != null && dtUpdate.Rows.Count > 0)
                {
                    messageContents = dtUpdate.Rows.Count + " 件更新します。\n";
                }

                messageContents += "よろしいでしょうか。";

                DialogResult rst = MessageBox.Show(messageContents, GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rst != DialogResult.Yes)
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }

        private bool CheckIsNull(string columnName, object dataCheck)
        {
            if (dataCheck == DBNull.Value || string.IsNullOrWhiteSpace(dataCheck.ToString().Trim()))
            {
                MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA002), columnName), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private DataTable GetUpdateData()
        {
            try
            {
                return dataGridViewFilter.GetUpdateData();
            }
            catch
            {
                return null;
            }
        }

        private void VideoMaintenanceMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridViewFilter.SaveConfig();
            CloseAndSave(e);
        }

        public void CloseAndSave(FormClosingEventArgs e)
        {
            DataTable dtUpdate = GetUpdateData();

            if ((dtUpdate == null || dtUpdate.Rows.Count == 0))
            {
                return;
            }

            string messageContents = string.Format(GetResources.GetResourceMesssage(Constants.MSGI004), "\n");

            DialogResult rst = MessageBox.Show(messageContents, GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Cancel close
            if (rst != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }

            GC.Collect();
        }
    }
}
