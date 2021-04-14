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
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Zuby.ADGV;
using System.Linq;

namespace Festival.DBTab.RecommendSong
{
    public partial class RecommendSongMainAdvance : UserControlBaseAdvance
    {
        public RecommendSongMainAdvance()
        {
            InitializeComponent();
            dataGridViewFilter.Visible = false;
            InitMenuSearchMain();
        }
        private bool isReload = false;

        private DataGridViewFilterEntity currentDataFilter = null;
        private LayoutCollection EnableButtonScreens = new LayoutCollection();
        private RecommendSongBusiness fecommendSongBusiness = null;

        public ColumnDisplayDataCollection ColumnSongSelectChangeDisplay;
        public ColumnDisplayDataCollection ColumnRecocomendProgramChangeDisplay;

        private DataTable dtプログラムID = new DataTable();

        public override void InitMenuSearchMain()
        {
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnRowSelectUnselect });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnAllOn });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnAllOff });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnAllInPut });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnAddNew });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnSave });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnImportData, MenuText = "リスト取込(&A)" });
        }

        /// <summary>
        /// Load resource for column combox
        /// </summary>
        private void LoadResourceColumnCombox()
        {
            try
            {
                int disPlayIndex = 0;
                int valueMemberIndex = 0;

                // Column 
                dtプログラムID = fecommendSongBusiness.GetFeRecommendProgram();
                colプログラムID.DataSource = dtプログラムID;
                colプログラムID.ValueMember = dtプログラムID.Columns[valueMemberIndex].ColumnName;
                colプログラムID.DisplayMember = dtプログラムID.Columns[disPlayIndex].ColumnName;

                // Colum 有料コンテンツフラグ
                DataTable dt有料コンテンツフラグ = fecommendSongBusiness.GetPaidContentFlag();
                col有料コンテンツフラグ.DataSource = dt有料コンテンツフラグ;
                col有料コンテンツフラグ.ValueMember = dt有料コンテンツフラグ.Columns[valueMemberIndex].ColumnName;
                col有料コンテンツフラグ.DisplayMember = dt有料コンテンツフラグ.Columns[disPlayIndex].ColumnName;

                // 有償情報フラグ
                DataTable dt有償情報フラグ = fecommendSongBusiness.GetPaidInformationFlag();
                col有償情報フラグ.DataSource = dt有償情報フラグ;
                col有償情報フラグ.ValueMember = dt有償情報フラグ.Columns[valueMemberIndex].ColumnName;
                col有償情報フラグ.DisplayMember = dt有償情報フラグ.Columns[disPlayIndex].ColumnName;

                // 取消フラグ
                DataTable dt取消フラグ = fecommendSongBusiness.GetCancelFlag();
                col取消フラグ.DataSource = dt取消フラグ;
                col取消フラグ.ValueMember = dt取消フラグ.Columns[0].ColumnName;
                col取消フラグ.DisplayMember = dt取消フラグ.Columns[1].ColumnName;
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
            fecommendSongBusiness = new RecommendSongBusiness();

            // set struct datagridview
            dataGridViewFilter.DataGridViewSource = advRecommendSong;
            dataGridViewFilter.ColChoiseIndex = col選択.Index;
            dataGridViewFilter.ColUpdatedIndex = col更新日時.Index;
            dataGridViewFilter.ColKeyIndex = colId.Index;
            dataGridViewFilter.ColDeletedIndex = col削除.Index;

            dataGridViewFilter.ColumnDeletedDataPropertyName = col削除.DataPropertyName;
            dataGridViewFilter.ColumnChoiseDataPropertyName = col選択.DataPropertyName;
            dataGridViewFilter.ColumnKeyDataPropertyName = colId.DataPropertyName;
            dataGridViewFilter.ColumnKeyName = colId.Name;
            dataGridViewFilter.ColumnUpdateTimeDataPropertyName = col更新日時.DataPropertyName;
            dataGridViewFilter.ColumnChoiseName = col選択.Name;
            dataGridViewFilter.ColumnUpdateName = col更新日時.Name;
            dataGridViewFilter.ColumnDeletedName = col削除.Name;

            this.ColKeyIndex = colId.Index;
            this.ColChoiseIndex = col選択.Index;

            dataGridViewFilter.EditCellEvent += EditCell;
            LoadResourceColumnCombox();
            InitColumnDisplayData();
            InitGridProcess();
        }

        /// <summary>
        /// Column change text when column col歌手ID補正 change value
        /// </summary>
        private void InitColumnDisplayData()
        {
            if (ColumnRecocomendProgramChangeDisplay == null)
                this.ColumnRecocomendProgramChangeDisplay = new ColumnDisplayDataCollection();

            this.ColumnRecocomendProgramChangeDisplay.CollumnList.Clear();

            this.ColumnRecocomendProgramChangeDisplay.Add(new ColumnDisplayEntity { ColumnIndex = colプログラム名.Index, DataPropertyName = colプログラム名.DataPropertyName, ColumnName = colプログラム名.Name, ColumnDataIndex = 1 });

            if (ColumnSongSelectChangeDisplay == null)
                ColumnSongSelectChangeDisplay = new ColumnDisplayDataCollection();
            ColumnSongSelectChangeDisplay.CollumnList.Clear();

            ColumnSongSelectChangeDisplay.Add(new ColumnDisplayEntity { ColumnIndex = colカラオケ選曲番号.Index, ColumnName = colカラオケ選曲番号.Name, DataPropertyName = colカラオケ選曲番号.DataPropertyName });
            ColumnSongSelectChangeDisplay.Add(new ColumnDisplayEntity { ColumnIndex = col楽曲名.Index, ColumnName = col楽曲名.Name, DataPropertyName = col楽曲名.DataPropertyName });
            ColumnSongSelectChangeDisplay.Add(new ColumnDisplayEntity { ColumnIndex = col歌手名.Index, ColumnName = col歌手名.Name, DataPropertyName = col歌手名.DataPropertyName });
            ColumnSongSelectChangeDisplay.Add(new ColumnDisplayEntity { ColumnIndex = col有料コンテンツフラグ.Index, ColumnName = col有料コンテンツフラグ.Name, DataPropertyName = col有料コンテンツフラグ.DataPropertyName });
            ColumnSongSelectChangeDisplay.Add(new ColumnDisplayEntity { ColumnIndex = colサービス発表日.Index, ColumnName = colサービス発表日.Name, DataPropertyName = colサービス発表日.DataPropertyName });
            ColumnSongSelectChangeDisplay.Add(new ColumnDisplayEntity { ColumnIndex = col取消フラグ.Index, ColumnName = col取消フラグ.Name, DataPropertyName = col取消フラグ.DataPropertyName });
            ColumnSongSelectChangeDisplay.Add(new ColumnDisplayEntity { ColumnIndex = colFes_DISCID.Index, ColumnName = colFes_DISCID.Name, DataPropertyName = colFes_DISCID.DataPropertyName });
            ColumnSongSelectChangeDisplay.Add(new ColumnDisplayEntity { ColumnIndex = col有償情報フラグ.Index, ColumnName = col有償情報フラグ.Name, DataPropertyName = col有償情報フラグ.DataPropertyName });
            ColumnSongSelectChangeDisplay.Add(new ColumnDisplayEntity { ColumnIndex = colデジドココンテンツID.Index, ColumnName = colデジドココンテンツID.Name, DataPropertyName = colデジドココンテンツID.DataPropertyName });
        }

        public override void LayoutEditMode(EnumEditMode editMode)
        {
            if (editMode == EnumEditMode.ReadOnly || editMode == EnumEditMode.None)
            {
                foreach (DataGridViewColumn colm in advRecommendSong.Columns)
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
                dataGridViewFilter.DataTableSource = fecommendSongBusiness.GetRecommendSongWorkTmp(isReload);

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
            dataGridViewFilter.Visible = true;
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

        public override void UpdateColumnSelected(DataGridViewCell cell, object data)
        {
            if (cell == null)
                return;

            if (cell.OwningColumn.Name.Equals(colWiiデジドコ選曲番号.Name))
            {
                UpdateSongSelectionChangeDisplayColumn(cell, true, data);
            }
            else if (cell.OwningColumn.Name.Equals(colプログラムID.Name))
            {
                UpdateRecocomendProgramChangeDisplayColumn(cell, true, data);
            }
            else
            {
                dataGridViewFilter.UpdateColumnSelected(cell, data);
            }
        }

        public override void UpdateCell(DataGridViewCell cell, object data)
        {
            if (cell.OwningColumn.Name.Equals(colWiiデジドコ選曲番号.Name))
            {
                UpdateSongSelectionChangeDisplayColumn(cell, false, data);
            }
            else if (cell.OwningColumn.Name.Equals(colプログラムID.Name))
            {
                UpdateRecocomendProgramChangeDisplayColumn(cell, false, data);
            }
            else
            {
                dataGridViewFilter.UpdateCell(cell, data);
            }
        }

        public void UpdateRecocomendProgramChangeDisplayColumn(DataGridViewCell cell, bool isBulkUpdate, object data)
        {
            string id = data == null ? string.Empty : data.ToString();
            DataTable dtDataValues = new DataTable();
            try
            {
                if (!string.IsNullOrEmpty(id))
                    dtDataValues = fecommendSongBusiness.GetFeRecommendProgramById(id);
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
                MessageBox.Show(string.Format("存在する{0}を指定してください。", cell.OwningColumn.HeaderText), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataGridViewFilter.ExecuteUpdateColumn(isBulkUpdate, dtDataValues, ColumnRecocomendProgramChangeDisplay, cell, data);

            dtDataValues = null;
            GC.Collect();
        }

        public void UpdateSongSelectionChangeDisplayColumn(DataGridViewCell cell, bool isBulkUpdate, object data)
        {
            string id = data == null ? string.Empty : data.ToString();

            DataTable dtDataValues = new DataTable();

            try
            {
                if (!string.IsNullOrEmpty(id))
                    dtDataValues = fecommendSongBusiness.GetFeSongSelectionRelatedInfo(id);
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

            if (dtUpdate != null)
            {
                foreach (DataRow row in dtUpdate.Rows)
                {
                    string id = row[colId.DataPropertyName].ToString();
                    if (row[colWiiデジドコ選曲番号.DataPropertyName] == DBNull.Value || row[colWiiデジドコ選曲番号.DataPropertyName] == null || string.IsNullOrWhiteSpace(row[colWiiデジドコ選曲番号.DataPropertyName].ToString()))
                    {
                        dataGridViewFilter.SetRowSeleted(id, colWiiデジドコ選曲番号.Name);
                        MessageBox.Show(string.Format("{0}のデーターが入力されていません。。", colWiiデジドコ選曲番号.HeaderText), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            SaveCount = 0;
            DeleteCount = 0;
            string messageContents = string.Empty;

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

        private void Save_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DataTable dtUpdate = dataGridViewFilter.GetDataSave();
                RecommendSongMessage recommendSongMessage = new RecommendSongMessage();

                int updatedCount = 0;
                // Update fescontentwork
                fecommendSongBusiness.Save(dtUpdate, DeleteCount, ref recommendSongMessage, ref updatedCount);

                this.ClosedWaiting();

                int count = SaveCount != 0 ? SaveCount - DeleteCount : DeleteCount;

                if (updatedCount == count)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format("登録が完了しました。", recommendSongMessage.WarningRecord), GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));

                    DataTable dtSongSelection = fecommendSongBusiness.GetSongSelectionNumber();

                    if (dtSongSelection.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtSongSelection.Rows)
                        {
                            recommendSongMessage.WarningRecord += row[0].ToString() + ",";
                        }

                        recommendSongMessage.WarningRecord = recommendSongMessage.WarningRecord.Remove(recommendSongMessage.WarningRecord.Length - 1, 1);

                        Invoke(new Action(() =>
                        {
                            if (!string.IsNullOrEmpty(recommendSongMessage.WarningRecord))
                            {
                                MessageBox.Show(string.Format("デジドコNo:{0}は、サービス対象ではありません。サービス発表日が未設定または取消フラグが設定されています。", recommendSongMessage.WarningRecord), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }));
                    }
                }
                else
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(string.Format("データの更新に失敗しました。\n更新予定件数：{0}件\n処理件数：{1}件", SaveCount, updatedCount), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);


                        if (!string.IsNullOrEmpty(recommendSongMessage.NotRequiredRecord))
                        {
                            MessageBox.Show(string.Format("デジドコNo:{0} の設定が不正なため登録処理を中断しました。\n表示順は必須項目です。", recommendSongMessage.NotRequiredRecord), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (recommendSongMessage.IsNotDigiNoKenkouSong)
                        {
                            MessageBox.Show(string.Format("健康王国おすすめ曲設定 \nデジドコNoが未設定のため登録処理を中断しました"), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (!string.IsNullOrEmpty(recommendSongMessage.NotDigiNoRecommendSong))
                        {
                            MessageBox.Show(string.Format("おすすめ曲設定\n プログラムID:{0} のデジドコNoが未設定のため登録処理を中断しました。", recommendSongMessage.NotDigiNoRecommendSong), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (!string.IsNullOrEmpty(recommendSongMessage.DisplayOrderDuplicationRecordKenkouSong))
                        {
                            MessageBox.Show(string.Format("健康王国おすすめ曲設定\n 表示順:{0} の設定が不正なため登録処理を中断しました。\n同じ表示順を複数設定しています。", recommendSongMessage.DisplayOrderDuplicationRecordKenkouSong), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (!string.IsNullOrEmpty(recommendSongMessage.DisplayOrderDuplicationRecordRecommendSong))
                        {
                            MessageBox.Show(string.Format("おすすめ曲設定\n [プログラムID:表示順]:{0} の設定が不正なため登録処理を中断しました。\n同じ表示順を複数設定しています。", recommendSongMessage.DisplayOrderDuplicationRecordRecommendSong), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
        }

        private void Save_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (bgwProcess != null)
            {
                bgwProcess.RunWorkerCompleted -= Save_RunWorkerCompleted;
                bgwProcess.DoWork -= Save_DoWork;
            }

            bgwProcess = null;
            GC.Collect();

            isReload = true;
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

                        if (oCell.ReadOnly)
                        {
                            return;
                        }

                        if (oCell.ValueType == null)
                        {
                            return;
                        }

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

        private void DisVideoSearchMain_Load(object sender, EventArgs e)
        {
            InitData();
            LoadData();
        }

        public override void OpenImportFile()
        {
            FesRecommendSongImport importList = new FesRecommendSongImport();
            importList.ShowDialog();
            if (importList.IsActive)
            {
                isReload = true;
                dataGridViewFilter.IsDisplayItemSeleted = false;
                LoadData();
                UnFilter();
            }
        }

        public override bool IsDataUpdated
        {
            get
            {
                return dataGridViewFilter.IsDataUpdated;
            }
        }

        public override List<string> GetHideColumns()
        {
            HideColumns.Clear();
            HideColumns.Add(col更新日時.DataPropertyName);
            HideColumns.Add(colデジドココンテンツID.DataPropertyName);
            HideColumns.Add(colId.DataPropertyName);
            return HideColumns;
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

        public override void AddNewRow()
        {
            try
            {
                RowAddNewObject rowAdd = new RowAddNewObject();

                rowAdd.KeyId = fecommendSongBusiness.InsertNewRowWorkTable();
                rowAdd.Columns.Add(new ColumnObject { ColumnIndex = colId.Index, ColumnName = colId.Name, ColumnDataPropertyName = colId.DataPropertyName, Data = rowAdd.KeyId });

                dataGridViewFilter.AddNewRow(rowAdd);

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

        public override void SaveConfig()
        {
            dataGridViewFilter.SaveConfig();
        }
    }
}
