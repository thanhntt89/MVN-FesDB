using DevComponents.DotNetBar.Controls;
using Festival.Base;
using Festival.Base.DataGridViewColumnCustom;
using Festival.Common;
using FestivalBusiness;
using FestivalCommon;
using FestivalObjects;
using FestivalUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Zuby.ADGV;

namespace Festival.DiscVideoTab.FesVideoAssigment
{
    public partial class FesVideoAssigmentMainAdvance : UserControlBaseAdvance
    {
        public FesVideoAssigmentMainAdvance()
        {
            InitializeComponent();
            dataGridViewFilter.Visible = false;
            GetHiraganaColumns();
            InitMenuSearchMain();
            InitVideoLockColumnDisplayData();
        }

        private DataGridViewFilterEntity currentDataFilter = null;
        private LayoutCollection EnableButtonScreens = new LayoutCollection();
        private FesVideoAssigmentBusiness videoAssigmentBusiness = null;
        private FesVideoAssigmentSearch fesVideoAssigmentSearch;


        public override void InitMenuSearchMain()
        {
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnExportFile });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnSearchCondition });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnRowSelectUnselect });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnAllOn });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnAllOff });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnAllInPut });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnSave });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnImportData, MenuText = "映像割付リスト取込(&A)" });
        }

        private void InitVideoLockColumnDisplayData()
        {
            VideoLockTypesColumns.CollumnList.Clear();

            VideoLockTypesColumns.Add(new ColumnDisplayEntity { ColumnIndex = col映像ロック対象.Index, ColumnName = col映像ロック対象.Name, DataPropertyName = col映像ロック対象.DataPropertyName, ColumnDataIndex = 1 });
        }


        /// <summary>
        /// Load resource for column combox
        /// </summary>
        private void LoadResourceColumnCombox()
        {
            try
            {
                DataTable dt取消フラグ = videoAssigmentBusiness.GetCancalFlag();
                col取消フラグ.DataSource = dt取消フラグ;
                col取消フラグ.DisplayMember = dt取消フラグ.Columns[0].ColumnName;
                col取消フラグ.ValueMember = dt取消フラグ.Columns[0].ColumnName;
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

        private void LoadDataSourceIndividualVideoLockColumn()
        {
            try
            {
                DataTable dt個別映像ロック = videoAssigmentBusiness.GetIndividualVideoLockFlag();
                col個別映像ロック.DataSource = dt個別映像ロック;
                col個別映像ロック.DisplayMember = dt個別映像ロック.Columns[1].ColumnName;
                col個別映像ロック.ValueMember = dt個別映像ロック.Columns[0].ColumnName;
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

        public override void InitData()
        {
            videoAssigmentBusiness = new FesVideoAssigmentBusiness();

            // set struct datagridview
            dataGridViewFilter.DataGridViewSource = advFesVideoAssigment;
            dataGridViewFilter.ColChoiseIndex = col選択.Index;
            dataGridViewFilter.ColUpdatedIndex = col更新日時.Index;
            dataGridViewFilter.ColKeyIndex = colデジドココンテンツID.Index;
            dataGridViewFilter.ColDeletedIndex = col削除.Index;

            dataGridViewFilter.ColumnDeletedDataPropertyName = col削除.DataPropertyName;
            dataGridViewFilter.ColumnChoiseDataPropertyName = col選択.DataPropertyName;
            dataGridViewFilter.ColumnKeyDataPropertyName = colデジドココンテンツID.DataPropertyName;
            dataGridViewFilter.ColumnKeyName = colデジドココンテンツID.Name;
            dataGridViewFilter.ColumnUpdateTimeDataPropertyName = col更新日時.DataPropertyName;
            dataGridViewFilter.ColumnChoiseName = col選択.Name;
            dataGridViewFilter.ColumnUpdateName = col更新日時.Name;
            dataGridViewFilter.ColumnDeletedName = col削除.Name;

            //VideoLock type
            dataGridViewFilter.ColumnVideoContentTypeDataPropertyName = colコンテンツ種類ID.DataPropertyName;
            dataGridViewFilter.ColumnVideoCodeDataPropertyName = col背景映像コード.DataPropertyName;
            dataGridViewFilter.ColumnOldVideoCodeDataPropertyName = colOld背景映像コード.DataPropertyName;
            dataGridViewFilter.ColumnVideoLockTypeDataPropertyName = col個別映像ロック.DataPropertyName;
            dataGridViewFilter.ColumnOldVideoLockTypeDataPropertyName = colOld個別映像ロック.DataPropertyName;
            dataGridViewFilter.ColumnVideoLockTypeTextDataPropertyName = col映像ロック対象.DataPropertyName;

            this.ColKeyIndex = colデジドココンテンツID.Index;
            this.ColChoiseIndex = col選択.Index;

            dataGridViewFilter.EditCellEvent += EditCell;
            LoadResourceColumnCombox();
            LoadDataSourceIndividualVideoLockColumn();
            InitGridProcess();
        }

        public override void LayoutEditMode(EnumEditMode editMode)
        {
            if (editMode == EnumEditMode.ReadOnly || editMode == EnumEditMode.None)
            {
                foreach (DataGridViewColumn colm in advFesVideoAssigment.Columns)
                {
                    if (colm.DataPropertyName.Equals(col選択.DataPropertyName))
                        continue;
                    colm.ReadOnly = true;
                }
            }
        }

        private void InitGridProcess()
        {
            bgwProcess = CreateThread();
            bgwProcess.RunWorkerCompleted += InitGrid_RunWorkerCompleted;
            bgwProcess.DoWork += InitGrid_DoWork;
            bgwProcess.RunWorkerAsync();
            this.ShowWating();
        }

        private void InitGrid_DoWork(object sender, DoWorkEventArgs e)
        {
            dataGridViewFilter.InitData();
        }

        private void InitGrid_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (bgwProcess != null)
            {
                bgwProcess.RunWorkerCompleted -= InitGrid_RunWorkerCompleted;
                bgwProcess.DoWork -= InitGrid_DoWork;
                bgwProcess.Dispose();
            }

            this.ClosedWaiting();
            Thread.Sleep(1000);
            dataGridViewFilter.Visible = true;
        }

        public override void LoadData()
        {
            DisplayThread();
        }

        private void DisplayThread()
        {
            if (bgwProcess == null)
                bgwProcess = CreateThread();

            bgwProcess.RunWorkerCompleted += DisPlayCompleted;
            bgwProcess.DoWork += DisplayDoWork;
            bgwProcess.RunWorkerAsync();
            this.ShowWating();
        }

        private void DisplayDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // Get data from work table
                dataGridViewFilter.DataTableSource = videoAssigmentBusiness.LoadFesVideoAssigmentWorkTable();

                Invoke(new Action(() =>
                {
                    dataGridViewFilter.LoadData();
                }));
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

        private void DisPlayCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.ClosedWaiting();

            if (bgwProcess != null)
            {
                bgwProcess.DoWork -= DisplayDoWork;
                bgwProcess.RunWorkerCompleted -= DisPlayCompleted;
                bgwProcess.Dispose();
            }

            bgwProcess = null;
            GC.Collect();

            //Hase data active menu
            if (ActiveMenuHasDataEvent != null)
            {
                ActiveMenuHasDataEvent(dataGridViewFilter.HasData);
            }
        }

        public override void Choise(bool? isSelected)
        {
            dataGridViewFilter.Choise(isSelected);
        }

        public override void DisplayItemSeleted(bool? isDisplaySeleted)
        {
            this.IsDisplayItemSeleted = isDisplaySeleted;
            dataGridViewFilter.DisplayItemSeleted(isDisplaySeleted);
        }

        public override void UpdateColumnSelected(DataGridViewCell cell, object data)
        {
            //Exception column
            if (cell.OwningColumn.Name.Equals(col個別映像ロック.Name) || cell.OwningColumn.Name.Equals(col背景映像コード.Name))
            {
                UpdateVideoLockColumn(true, cell, data);
            }
            else
            {
                dataGridViewFilter.UpdateColumnSelected(cell, data);
            }
        }

        public override void UpdateCell(DataGridViewCell cell, object data)
        {
            //Exception column
            if (cell.OwningColumn.Name.Equals(col個別映像ロック.Name) || cell.OwningColumn.Name.Equals(col背景映像コード.Name))
            {
                UpdateVideoLockColumn(false, cell, data);
            }
            else
            {
                dataGridViewFilter.UpdateCell(cell, data);
            }
        }

        public override void EditCell(DataGridViewCell cell)
        {
            if (EditCellEvent != null)
                EditCellEvent(cell);
        }

        /// 個別映像ロック
        private void UpdateVideoLockColumn(bool isBulkUpdate, DataGridViewCell cell, object data)
        {
            try
            {                
                //Check video lock festa type in file
                var festaLocks = videoAssigmentBusiness.GetFestaVideoLock();

                //All video lock in table
                DataTable tbvideoLockAll = videoAssigmentBusiness.GetVideoCodeLockedAll();

                dataGridViewFilter.UpdateVideoLockColumn(isBulkUpdate, cell, data, tbvideoLockAll, festaLocks);
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

        public override void UnFilter()
        {
            currentDataFilter = null;
            dataGridViewFilter.UnFilter();
        }

        public override void Frozen(bool? isFrozen)
        {
            dataGridViewFilter.Frozen(isFrozen);
        }

        public override void ApplyFilter(DataGridViewFilterEntity dataFilter)
        {
            currentDataFilter = dataFilter;
            dataGridViewFilter.ApplyFilter(currentDataFilter);
        }

        public override void Sort(SortType sortType)
        {
            dataGridViewFilter.Sort(sortType);
        }

        public override void SetColumnVisible(string columnName, bool isVisible)
        {
            dataGridViewFilter.SetColumnVisible(columnName, isVisible);
        }

        private bool ValidSave()
        {
            DataTable dtUpdate = dataGridViewFilter.GetUpdateData();

            // Get delete fill
            DataTable dtDelete = dataGridViewFilter.GetDeletedData();

            if ((dtUpdate == null || dtUpdate.Rows.Count == 0) && (dtDelete == null || dtDelete.Rows.Count == 0))
            {
                MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGI009), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            StringBuilder messageContents = new StringBuilder();
            SaveCount = 0;
            DeleteCount = 0;
            VideoCodeInFestaLockCount = 0;
            VideoCodeInTableLockLockedCount = 0;
            VideoCodeStausNotChangeAndVideoCodeChangeCount = 0;
            VideoCodeChangeCount = 0;

            // Get count delete
            if (dtDelete != null)
            {
                DeleteCount = dtDelete.Rows.Count;
            }

            //Get Count save   
            if (dtUpdate != null && dtUpdate.Rows.Count > 0)
            {
                SaveCount = dtUpdate.Rows.Count;

                //Video code change
                videoCodeChangeList = dtUpdate.AsEnumerable().Where(r => r.Field<object>(colOld背景映像コード.DataPropertyName) != null && !string.IsNullOrWhiteSpace(r.Field<object>(colOld背景映像コード.DataPropertyName).ToString()) && !r.Field<string>(colOld背景映像コード.DataPropertyName).Equals(r.Field<string>(col背景映像コード.DataPropertyName))).ToList();

                if (videoCodeChangeList != null && videoCodeChangeList.Count > 0)
                {
                    VideoCodeChangeCount = videoCodeChangeList.Count;

                    //Video code change and status not change  
                    var videoCodeChangeAndStatusNotChange = videoCodeChangeList.Where(r => r.Field<int?>(col個別映像ロック.DataPropertyName) != null && r.Field<int>(col個別映像ロック.DataPropertyName) == 1);

                    VideoCodeStausNotChangeAndVideoCodeChangeCount = videoCodeChangeAndStatusNotChange.ToList().Count();

                    IList<string> contentsLocked = Utils.GetDataFromFileToList(Properties.Settings.Default.FES_PEREMIUM_CONTENT_VIDEO_LOCKED_PATH, ',');

                    //Count Video code Festa file
                    if (contentsLocked != null)
                    {
                        // colコンテンツ種類ID
                        foreach (DataRow row in videoCodeChangeList)
                        {
                            if (contentsLocked.Contains(row[colコンテンツ種類ID.DataPropertyName].ToString()))
                            {
                                VideoCodeInFestaLockCount++;
                            }
                        }
                    }

                    //Count video code lock in  database
                    try
                    {
                        DataTable dtVideoCodeLocked = videoAssigmentBusiness.GetVideoCodeLockedAll();
                        if (dtVideoCodeLocked != null || dtVideoCodeLocked.Rows.Count > 0)
                        {
                            foreach (DataRow row in videoCodeChangeList)
                            {
                                var exist = dtVideoCodeLocked.AsEnumerable().Where(r => r.Field<string>("VideoCode").Equals(row[col背景映像コード.DataPropertyName].ToString())).FirstOrDefault();
                                if (exist != null)
                                {
                                    VideoCodeInTableLockLockedCount++;
                                }
                            }
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
            }

            if (SaveCount == 0)
                SaveCount = DeleteCount;

            //Update
            messageContents.AppendLine(string.Format("登録曲数\t\t\t{0}件", SaveCount - DeleteCount));
            //Delete
            messageContents.AppendLine(string.Format("件削除曲数\t\t\t{0}件", DeleteCount));
            messageContents.AppendLine("----------------------------------------");
            //Video code change 
            messageContents.AppendLine(string.Format("背景映像コード変更曲数\t\t{0}件", VideoCodeChangeCount));
            //Video code change and status not change 
            messageContents.AppendLine(string.Format("\t映像ロック曲\t\t{0}件", VideoCodeStausNotChangeAndVideoCodeChangeCount));
            // Check video lock column col映像ロック対象
            messageContents.AppendLine(string.Format("\t背景映像変更NG曲\t{0}件", VideoCodeInTableLockLockedCount));
            //CheckLockCount from setting
            messageContents.AppendLine(string.Format("\tプレミアムコンテンツ曲\t{0}件", VideoCodeInFestaLockCount));
            messageContents.AppendLine("----------------------------------------");
            messageContents.AppendLine("            登録しますか？");

            DialogResult rst = MessageBox.Show(messageContents.ToString(), GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rst != DialogResult.Yes)
                return false;

            dtUpdate = null;
            dtDelete = null;
            GC.Collect();
            return true;
        }

        public override void Save()
        {
            if (!ValidSave())
                return;

            ProcessSave();
        }

        private void ProcessSave()
        {
            bgwProcess = CreateThread();
            bgwProcess.RunWorkerCompleted += Save_RunWorkerCompleted;
            bgwProcess.DoWork += Save_DoWork;

            bgwProcess.RunWorkerAsync();
            this.ShowWating();
        }


        private void SaveVideoCodeChange()
        {
            try
            {
                if (videoCodeChangeList == null || videoCodeChangeList.Count == 0)
                    return;
                StringBuilder contents = new StringBuilder();
                string header = string.Format("登録日時\tデジドコNo\t利用者ID\t背景映像コード(変更前)\t背景映像コード(変更後)");

                foreach (DataRow row in videoCodeChangeList)
                {
                    contents.AppendLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), row[colWiiデジドコ選曲番号.DataPropertyName], Environment.UserName, row[colOld背景映像コード.DataPropertyName], row[col背景映像コード.DataPropertyName]));
                }

                FileUtils.WriteFile(Properties.Settings.Default.FES_VIDEO_LOCK_HISTORIES_FILE_PATH, contents.ToString(), header);
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

        private void SaveExecute()
        {
            FesVideoAssigmentObject message = new FesVideoAssigmentObject();
            DataTable dtUpdate = null;
            // Update fescontentwork
            int updatedCount = 0;

            try
            {
                dtUpdate = dataGridViewFilter.GetDataSave();
                videoAssigmentBusiness.Save(dtUpdate, DeleteCount, ref message, ref updatedCount);
                SaveVideoCodeChange();              
                this.ClosedWaiting();

                if (updatedCount == SaveCount)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format("登録が完了しました。"), GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                }
                else
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format("データの更新に失敗しました。\n更新予定件数：{0}件\n処理件数：{1}件", SaveCount, updatedCount), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
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

            message = null;
            dtUpdate = null;
            GC.Collect();
        }

        private void Save_DoWork(object sender, DoWorkEventArgs e)
        {
            SaveExecute();
        }

        private void Save_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.ClosedWaiting();

            if (bgwProcess != null)
            {
                bgwProcess.RunWorkerCompleted -= Save_RunWorkerCompleted;
                bgwProcess.DoWork -= Save_DoWork;
            }

            bgwProcess = null;
            GC.Collect();

            dataGridViewFilter.IsDisplayItemSeleted = this.IsDisplayItemSeleted;
            LoadData();
        }

        public override DataGridViewColumnCollection GetDataGridViewColumns()
        {
            return dataGridViewFilter.GetDataGridViewColumns();
        }

        public override AdvancedDataGridView GetDataGridViewSource()
        {
            return dataGridViewFilter.GetDataGridViewSource();
        }

        public override List<string> GetDisableBulkInsertColumns()
        {
            DisableBulkInsertColumns.Clear();
            DisableBulkInsertColumns.Add(col選択.DataPropertyName);
            return DisableBulkInsertColumns;
        }

        public override void Cut()
        {
            dataGridViewFilter.Cut();
        }

        public override void Copy()
        {
            dataGridViewFilter.Copy();
        }

        public override void Paste()
        {
            try
            {
                // Get all data  from clipboard
                string data = Clipboard.GetText();
                string[] lines = data.Split('\n');

                int iRow = dataGridViewFilter.CurrentRowsIndex;
                int iCol = dataGridViewFilter.CurrentColumnIndex;
                AdvancedDataGridView dataGridView = dataGridViewFilter.GetDataGridViewSource();
                DataGridViewCell oCell;

                foreach (string line in lines)
                {
                    if (iRow > dataGridView.RowCount || line.Length < 0)
                    {
                        break;
                    }

                    object[] sCells = line.Replace("\r", "").Split('\t');

                    for (int i = 0; i < sCells.GetLength(0); ++i)
                    {
                        if (iCol + i > dataGridView.ColumnCount)
                        {
                            break;
                        }

                        oCell = dataGridView[iCol + i, iRow];

                        if (!CheckValidCell(oCell, data))
                        {
                            return;
                        }

                        //Check valid type

                        UpdateCell(oCell, sCells[i]);
                    }

                    iRow++;
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

        private bool CheckValidCell(DataGridViewCell cell, object data)
        {
            if (cell == null || cell.ReadOnly)
                return false;

            int MaxLength = 0;
            int MinLength = 0;
            if (data == null || data == DBNull.Value || string.IsNullOrWhiteSpace(data.ToString()))
                return true;

            if (cell.GetType().Equals(typeof(DataGridViewNumericCell)))
            {
                MaxLength = ((DataGridViewNumericColumn)cell.OwningColumn).MaxInputLength;
                MinLength = ((DataGridViewNumericColumn)cell.OwningColumn).MinInputLength;

                if (data.ToString().Length > MaxLength || data.ToString().Length < MinLength)
                    return false;

                return Utils.IsNumeric(data.ToString());
            }
            if (cell.GetType().Equals(typeof(DataGridViewTextBoxCell)))
            {
                MaxLength = ((DataGridViewTextBoxColumn)cell.OwningColumn).MaxInputLength;
                if (data.ToString().Length > MaxLength || data.ToString().Length < MinLength)
                {
                    return false;
                }
            }
            if (cell.GetType().Equals(typeof(DataGridViewDateTimeInputCell)))
            {
                DateTime dateValue = DateTime.MinValue;
                string[] formats = {"M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt",
                   "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss","yyyy/MM/dd","yyyyMMdd","yyyy/MM/dd HH:mm:ss",
                   "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt",
                   "M/d/yyyy h:mm", "M/d/yyyy h:mm",
                   "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm"};

                DateTime.TryParseExact(data.ToString(), formats, null,
                               DateTimeStyles.AllowWhiteSpaces |
                               DateTimeStyles.AdjustToUniversal,
                               out dateValue);

                return dateValue != DateTime.MinValue;
            }
            if (cell.GetType().Equals(typeof(DataGridViewComboBoxExCell)))
            {
                var cbo = (DataGridViewComboBoxExColumn)cell.OwningColumn;
                DataTable dtSource = cbo.DataSource as DataTable;
                var exist = dtSource.AsEnumerable().Where(r => r.Field<object>(0) != null && r.Field<object>(0).ToString().Equals(data.ToString())).FirstOrDefault();
                if (exist == null)
                {
                    MessageBox.Show(string.Format("存在する{0}を指定してください。", cell.OwningColumn.HeaderText), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        public override int ExportExecute(FileExportEntity exportFileInfo)
        {
            DataTable dataExport = new DataTable();

            if (!dataGridViewFilter.HasData)
            {
                return 0;
            }

            List<string> dataFilter = new List<string>();

            // If Export with fillter and nothing selected
            if (exportFileInfo.IsExportWithFilter || dataGridViewFilter.IsFilterActive)
            {  // Export chose filter
                dataFilter = dataGridViewFilter.GetDisplayedIdList(exportFileInfo.IsExportWithFilter);
                if (dataFilter.Count == 0)
                    return 0;
            }

            dataExport = videoAssigmentBusiness.GetDataExportVideoAssigment(dataFilter);

            if (exportFileInfo.FileType == FileType.TSV)
            {
                FileUtils.ExportToTSV(dataExport, exportFileInfo.FilePath, exportFileInfo.IncludeHeader);
            }
            else if (exportFileInfo.FileType == FileType.Excel)
            {
                ExcelUtils.ExportToFile(dataExport, exportFileInfo.FilePath);
            }

            return 1;
        }

        public override void OpenImportFile()
        {
            FesVideoAssigmentImport importList = new FesVideoAssigmentImport();
            importList.ShowDialog();
            if (importList.IsActive)
            {
                dataGridViewFilter.IsDisplayItemSeleted = false;
                LoadData();
                UnFilter();
            }
        }

        public override bool IsDataUpdated
        {
            get { return dataGridViewFilter.IsDataUpdated; }
        }

        public override List<string> GetHideColumns()
        {
            HideColumns.Clear();
            HideColumns.Add(colデジドココンテンツID.DataPropertyName);
            HideColumns.Add(col更新日時.DataPropertyName);

            //HideColumns.Add(colコンテンツ種類ID.DataPropertyName);
            HideColumns.Add(colOld背景映像コード.DataPropertyName);
            HideColumns.Add(colOld個別映像ロック.DataPropertyName);

            return HideColumns;
        }

        public override ColumnsCollection GetHiraganaColumns()
        {
            HiraganaColumns.Clear();
            HiraganaColumns.Add(new ColumnEntity() { ColumName = col備考.DataPropertyName });
            return HiraganaColumns;
        }

        public override ColumnsCollection GetHankakuEiSuColumns()
        {
            HankakuEiSuColumns.Clear();
            HankakuEiSuColumns.Add(new ColumnEntity() { ColumName = col背景映像コード.DataPropertyName, IsDataRequired = true, IsHankakuEiSu = true });
            return base.GetHankakuEiSuColumns();
        }

        public override bool IsFilterActive
        {
            get
            {
                return dataGridViewFilter.IsFilterActive;
            }

            set
            {
                base.IsFilterActive = value;
            }
        }

        public override void OpenSearchingCondition(LayOutEntity currentLayout)
        {
            if (fesVideoAssigmentSearch == null)
                fesVideoAssigmentSearch = new FesVideoAssigmentSearch(CurrentLayout);
            fesVideoAssigmentSearch.ShowDialog();

            if (fesVideoAssigmentSearch.IsActive)
            {
                dataGridViewFilter.IsDisplayItemSeleted = false;
                LoadData();
                // Reset active
                fesVideoAssigmentSearch.IsActive = false;
            }
        }

        private void FesVideoAssigmentMainAdvance_Load(object sender, EventArgs e)
        {
            InitData();
        }

        public override void SaveConfig()
        {
            dataGridViewFilter.SaveConfig();
        }
    }
}
