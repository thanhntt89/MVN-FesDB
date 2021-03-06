using Festival.Base;
using Festival.Common;
using FestivalBusiness;
using FestivalCommon;
using FestivalObjects;
using FestivalUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Zuby.ADGV;
using Festival.Base.DataGridViewColumnCustom;
using System.Globalization;
using DevComponents.DotNetBar.Controls;
using System.Linq;

namespace Festival.DiscVideoTab.FesSongAddDelete
{
    public partial class FesSongAddDeleteMainAdvance : UserControlBaseAdvance
    {
        public FesSongAddDeleteMainAdvance()
        {
            InitializeComponent();
            dataGridViewFilter.Visible = false;
            GetHiraganaColumns();
            InitMenuSearchMain();
            InitColumnDisplayData();
        }

        private DataGridViewFilterEntity currentDataFilter = null;
        private LayoutCollection EnableButtonScreens = new LayoutCollection();
        private FesSongAddDeleteBusiness fesSongAddDeleteBusiness = null;
        private FesSongAddDeleteSearch fesSongAddDeleteSearch;
        public ColumnDisplayDataCollection ColumnSongSelectChangeDisplay;

        public override void InitMenuSearchMain()
        {
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnSearchCondition });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnRowSelectUnselect });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnAllOn });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnAllOff });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnAllInPut });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnSave });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnAddNew });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnImportData, MenuText = "データサイズ取込(&A)" });
        }

        /// <summary>
        /// Load resource for column combox
        /// </summary>
        private void LoadResourceColumnCombox()
        {
            try
            {
                DataTable dt追加削除区分 = fesSongAddDeleteBusiness.GetAddtionalDeletionCategory();
                col追加削除区分.DataSource = dt追加削除区分;
                col追加削除区分.DisplayMember = dt追加削除区分.Columns[0].ColumnName;
                col追加削除区分.ValueMember = dt追加削除区分.Columns[0].ColumnName;

                DataTable dt有償情報フラグ = fesSongAddDeleteBusiness.GetPaidInfoFlag();
                col有償情報フラグ.DataSource = dt有償情報フラグ;
                col有償情報フラグ.DisplayMember = dt有償情報フラグ.Columns[0].ColumnName;
                col有償情報フラグ.ValueMember = dt有償情報フラグ.Columns[0].ColumnName;

                DataTable dt有料コンテンツフラグ = fesSongAddDeleteBusiness.GetAddtinalDeleteCategory();
                col有料コンテンツフラグ.DataSource = dt有料コンテンツフラグ;
                col有料コンテンツフラグ.DisplayMember = dt有料コンテンツフラグ.Columns[0].ColumnName;
                col有料コンテンツフラグ.ValueMember = dt有料コンテンツフラグ.Columns[0].ColumnName;

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
            fesSongAddDeleteBusiness = new FesSongAddDeleteBusiness();

            // set struct datagridview
            dataGridViewFilter.DataGridViewSource = advFesSongAddDelete;
            dataGridViewFilter.ColChoiseIndex = col選択.Index;
            dataGridViewFilter.ColUpdatedIndex = col更新日時.Index;
            dataGridViewFilter.ColKeyIndex = colID.Index;
            dataGridViewFilter.ColDeletedIndex = col削除.Index;

            dataGridViewFilter.ColumnDeletedDataPropertyName = col削除.DataPropertyName;
            dataGridViewFilter.ColumnChoiseDataPropertyName = col選択.DataPropertyName;
            dataGridViewFilter.ColumnKeyDataPropertyName = colID.DataPropertyName;
            dataGridViewFilter.ColumnKeyName = colID.Name;
            dataGridViewFilter.ColumnUpdateTimeDataPropertyName = col更新日時.DataPropertyName;
            dataGridViewFilter.ColumnChoiseName = col選択.Name;
            dataGridViewFilter.ColumnUpdateName = col更新日時.Name;
            dataGridViewFilter.ColumnDeletedName = col削除.Name;


            this.ColKeyIndex = colID.Index;
            this.ColChoiseIndex = col選択.Index;

            dataGridViewFilter.EditCellEvent += EditCell;
            LoadResourceColumnCombox();
            InitGridProcess();
            try
            {
                dataGridViewFilter.LoadData();
                fesSongAddDeleteBusiness.TruncateSongManagementWorkTmp();
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

        /// <summary>
        /// Column change text when column col歌手ID補正 change value
        /// </summary>
        private void InitColumnDisplayData()
        {
            if (ColumnSongSelectChangeDisplay == null)
                ColumnSongSelectChangeDisplay = new ColumnDisplayDataCollection();
            ColumnSongSelectChangeDisplay.CollumnList.Clear();

            ColumnSongSelectChangeDisplay.Add(new ColumnDisplayEntity { ColumnIndex = colカラオケ選曲番号.Index, ColumnName = colカラオケ選曲番号.Name, DataPropertyName = colカラオケ選曲番号.DataPropertyName });
            ColumnSongSelectChangeDisplay.Add(new ColumnDisplayEntity { ColumnIndex = col楽曲名.Index, ColumnName = col楽曲名.Name, DataPropertyName = col楽曲名.DataPropertyName });
            ColumnSongSelectChangeDisplay.Add(new ColumnDisplayEntity { ColumnIndex = col歌手名.Index, ColumnName = col歌手名.Name, DataPropertyName = col歌手名.DataPropertyName });
            ColumnSongSelectChangeDisplay.Add(new ColumnDisplayEntity { ColumnIndex = col有料コンテンツフラグ.Index, ColumnName = col有料コンテンツフラグ.Name, DataPropertyName = col有料コンテンツフラグ.DataPropertyName });
            ColumnSongSelectChangeDisplay.Add(new ColumnDisplayEntity { ColumnIndex = colアップ予定日.Index, ColumnName = colアップ予定日.Name, DataPropertyName = colアップ予定日.DataPropertyName });
            ColumnSongSelectChangeDisplay.Add(new ColumnDisplayEntity { ColumnIndex = colサービス発表日.Index, ColumnName = colサービス発表日.Name, DataPropertyName = colサービス発表日.DataPropertyName });
            ColumnSongSelectChangeDisplay.Add(new ColumnDisplayEntity { ColumnIndex = col取消フラグ.Index, ColumnName = col取消フラグ.Name, DataPropertyName = col取消フラグ.DataPropertyName });
        }

        public override void LayoutEditMode(EnumEditMode editMode)
        {
            if (editMode == EnumEditMode.ReadOnly || editMode == EnumEditMode.None)
            {
                foreach (DataGridViewColumn colm in advFesSongAddDelete.Columns)
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
                dataGridViewFilter.DataTableSource = fesSongAddDeleteBusiness.LoadWorkTable();

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

        public override void DisplayItemSeleted(bool? isDisplayItemSeleted)
        {
            this.IsDisplayItemSeleted = isDisplayItemSeleted;
            dataGridViewFilter.DisplayItemSeleted(isDisplayItemSeleted);
        }

        public override void UpdateCell(DataGridViewCell cell, object data)
        {
            if (cell.OwningColumn.Name.Equals(colWiiデジドコ選曲番号.Name))
            {
                UpdateSongSelectionChangeDisplayColumn(cell, false, data);
            }
            else
            {
                dataGridViewFilter.UpdateCell(cell, data);
            }
        }

        private void UpdateSongSelectionChangeDisplayColumn(DataGridViewCell cell, bool isBulkUpdate, object data)
        {
            string id = data == null ? string.Empty : data.ToString();
            DataTable dtDataValues = new DataTable();
            try
            {
                if (!string.IsNullOrEmpty(id))
                    dtDataValues = fesSongAddDeleteBusiness.GetFesSongRelatedInfoById(id);
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
            if (dtDataValues.Rows.Count == 0)
            {
                MessageBox.Show("存在するデジドコNoを指定してください。", GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataGridViewFilter.ExecuteUpdateColumn(isBulkUpdate, dtDataValues, ColumnSongSelectChangeDisplay, cell, data);

            dtDataValues = null;
            GC.Collect();
        }

        public override void EditCell(DataGridViewCell cell)
        {
            if (EditCellEvent != null)
                EditCellEvent(cell);
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

        public override void UpdateColumnSelected(DataGridViewCell cell, object data)
        {
            dataGridViewFilter.UpdateColumnSelected(cell, data);
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
            string id = string.Empty;
            if (dtUpdate != null)
            {
                foreach (DataRow row in dtUpdate.Rows)
                {
                    id = row[colID.DataPropertyName].ToString();

                    if (row[col通番.DataPropertyName] == DBNull.Value || row[col通番.DataPropertyName] == null || string.IsNullOrWhiteSpace(row[col通番.DataPropertyName].ToString()))
                    {
                        dataGridViewFilter.SetRowSeleted(id, col通番.Name);
                        MessageBox.Show(string.Format("{0} ご入力必須項目です。", col通番.HeaderText), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            string messageContents = string.Empty;
            DeleteCount = 0;
            SaveCount = 0;

            //Get count edit
            if (dtUpdate != null && dtUpdate.Rows.Count > 0)
            {
                SaveCount = dtUpdate.Rows.Count;
                messageContents = SaveCount + " 件更新します。\n";
            }
            // Get count delete
            if (dtDelete != null && dtDelete.Rows.Count > 0)
            {
                DeleteCount = dtDelete.Rows.Count;
                messageContents += DeleteCount + " 件削除します。\n";
            }

            if (SaveCount == 0)
                SaveCount = DeleteCount;

            messageContents += "よろしいでしょうか。";

            DialogResult rst = MessageBox.Show(messageContents, GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void SaveExecute()
        {
            FesSongAddDeleteMessage message = new FesSongAddDeleteMessage();
            // Update fescontentwork
            int updatedCount = 0;
            DataTable dtUpdate = null;

            try
            {
                dtUpdate = dataGridViewFilter.GetDataSave();

                fesSongAddDeleteBusiness.Save(dtUpdate, DeleteCount, ref message, ref updatedCount);

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

                    MessageDisplay(message);
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

        private void MessageDisplay(FesSongAddDeleteMessage message)
        {
            Invoke(new Action(() =>
            {
                if (!string.IsNullOrWhiteSpace(message.NotRequiredRecord))
                {
                    MessageBox.Show(string.Format("通番:{0}の設定が不正なため登録処理を中断しました。\n追加削除区分、デジドコNo、DISCIDは必須項目です。", message.NotRequiredRecord), GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (!string.IsNullOrWhiteSpace(message.NotFileNameRecord))
                {
                    MessageBox.Show(string.Format("通番:{0}の設定が不正なため登録処理を中断しました。\n設定済のデジドコNoを設定しています。", message.NotFileNameRecord), GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (!string.IsNullOrWhiteSpace(message.NotDelRecord))
                {
                    MessageBox.Show(string.Format("通番:{0}の設定が不正なため登録処理を中断しました。\n存在しないデジドコNo、DISCIDの削除を設定しています。", message.NotDelRecord), GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (!string.IsNullOrWhiteSpace(message.NoUpdateRecord))
                {
                    MessageBox.Show(string.Format("通番:{0}は、更新できないレコードです。\n初期搭載データ(通番:ブランク)、追加削除区分=1:削除、現在DISC搭載想定でない過去のレコードの編集は行えません。", message.NoUpdateRecord), GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }));
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

        public override void OpenImportFile()
        {
            FesSongImport importList = new FesSongImport();
            importList.ShowDialog();
            if (importList.IsActive)
            {
                dataGridViewFilter.IsDisplayItemSeleted = false;
                LoadData();
                UnFilter();
            }
        }

        public override void AddNewRow()
        {
            try
            {
                RowAddNewObject rowAdd = new RowAddNewObject();
                string serialNumber = string.Empty;
                DataTable dtAddNew = fesSongAddDeleteBusiness.InsertNewRowSongManagementWorkTable();

                if (dtAddNew.Rows.Count == 0)
                    return;

                rowAdd.KeyId = dtAddNew.Rows[0][colID.DataPropertyName].ToString();
                serialNumber = dtAddNew.Rows[0][col通番.DataPropertyName].ToString();

                rowAdd.Columns.Add(new ColumnObject { ColumnIndex = col通番.Index, ColumnName = col通番.Name, ColumnDataPropertyName = col通番.DataPropertyName, Data = serialNumber });

                rowAdd.Columns.Add(new ColumnObject { ColumnIndex = col登録日.Index, ColumnName = col登録日.Name, ColumnDataPropertyName = col登録日.DataPropertyName, Data = DateTime.Now.ToString("yyyy/MM/dd") });

                dataGridViewFilter.AddNewRow(rowAdd);

                if (ActiveMenuHasDataEvent != null)
                    ActiveMenuHasDataEvent(dataGridViewFilter.HasData);

                rowAdd = null;
                GC.Collect();
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

        public override bool IsDataUpdated
        {
            get { return dataGridViewFilter.IsDataUpdated; }
        }

        public override List<string> GetHideColumns()
        {
            HideColumns.Clear();
            HideColumns.Add(col削除.DataPropertyName);
            HideColumns.Add(colID.DataPropertyName);
            HideColumns.Add(col更新日時.DataPropertyName);
            return HideColumns;
        }

        public override ColumnsCollection GetHiraganaColumns()
        {
            HiraganaColumns.Clear();
            HiraganaColumns.Add(new ColumnEntity() { ColumName = col備考.DataPropertyName });
            return HiraganaColumns;
        }

        public override List<string> GetDisableBulkInsertColumns()
        {
            DisableBulkInsertColumns.Clear();
            DisableBulkInsertColumns.Add(colWiiデジドコ選曲番号.DataPropertyName);
            DisableBulkInsertColumns.Add(col選択.DataPropertyName);
            return DisableBulkInsertColumns;
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
            if (fesSongAddDeleteSearch == null)
                fesSongAddDeleteSearch = new FesSongAddDeleteSearch(CurrentLayout);
            fesSongAddDeleteSearch.ShowDialog();

            if (fesSongAddDeleteSearch.IsActive)
            {
                dataGridViewFilter.IsDisplayItemSeleted = false;
                LoadData();
                // Reset active
                fesSongAddDeleteSearch.IsActive = false;
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
