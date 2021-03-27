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

namespace Festival.DiscVideoTab.FesSongWithDisc
{
    public partial class FesSongWithDiscMainAdvance : UserControlBaseAdvance
    {
        public FesSongWithDiscMainAdvance(DisVersion version)
        {
            InitializeComponent();
            dataGridViewFilter.Visible = false;
            currentVersion = version;
            InitColumnByVersion(version);
            InitMenuSearchMain();
            this.SCREEN_TITLE = string.Format("{0}{1}", this.SCREEN_TITLE, (int)version);
        }

        private DisVersion currentVersion;

        private DataGridViewFilterEntity currentDataFilter = null;
        private LayoutCollection EnableButtonScreens = new LayoutCollection();
        private FesSongWithDiscBusiness fesSongWithDiscBusiness = null;
        private FesSongWithDiscSearch fesSongWithDiscSearch;

        public override void InitMenuSearchMain()
        {
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnSearchCondition });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnRowSelectUnselect });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnAllOn });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnAllOff });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnAllInPut });
            ActiveMenusSearchMain.Add(new MenuEntity() { MenuName = EnumMenusSearchMain.btnSave });
        }


        /// <summary>
        /// Load resource for column combox
        /// </summary>
        private void LoadResourceColumnCombox()
        {
            try
            {
                DataTable dt取消フラグ = fesSongWithDiscBusiness.GetCancelFlag();
                col取消フラグ.DataSource = dt取消フラグ;
                col取消フラグ.DisplayMember = dt取消フラグ.Columns[0].ColumnName;
                col取消フラグ.ValueMember = dt取消フラグ.Columns[0].ColumnName;

                DataTable dtNET利用フラグ = fesSongWithDiscBusiness.GetUseAgeFlagData();
                colNET利用フラグ.DataSource = dtNET利用フラグ;
                colNET利用フラグ.DisplayMember = dtNET利用フラグ.Columns[0].ColumnName;
                colNET利用フラグ.ValueMember = dtNET利用フラグ.Columns[0].ColumnName;

                DataTable dtNET利用フラグV2 = fesSongWithDiscBusiness.GetUseAgeFlagData();
                colNET利用フラグVer2.DataSource = dtNET利用フラグV2;
                colNET利用フラグVer2.DisplayMember = dtNET利用フラグV2.Columns[0].ColumnName;
                colNET利用フラグVer2.ValueMember = dtNET利用フラグV2.Columns[0].ColumnName;
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

        private void InitColumnByVersion(DisVersion version)
        {
            DataGridViewCellStyle dataGridViewCellStyleYellow = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyleDefault = new DataGridViewCellStyle();

            dataGridViewCellStyleDefault.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyleDefault.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyleDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyleDefault.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyleDefault.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyleDefault.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyleDefault.WrapMode = DataGridViewTriState.False;

            this.colFesDISCID.DefaultCellStyle = dataGridViewCellStyleDefault;
            this.colNET利用フラグ.DefaultCellStyle = dataGridViewCellStyleDefault;
            this.col取消日.DefaultCellStyle = dataGridViewCellStyleDefault;
            this.col備考.DefaultCellStyle = dataGridViewCellStyleDefault;

            this.colFesDISCIDVer2.DefaultCellStyle = dataGridViewCellStyleDefault;
            this.colNET利用フラグVer2.DefaultCellStyle = dataGridViewCellStyleDefault;
            this.col取消日Ver2.DefaultCellStyle = dataGridViewCellStyleDefault;
            this.col備考Ver2.DefaultCellStyle = dataGridViewCellStyleDefault;

            dataGridViewCellStyleYellow.BackColor = System.Drawing.Color.Yellow;
            this.colFesDISCID.ReadOnly = true;
            this.colNET利用フラグ.ReadOnly = true;
            this.col取消日.ReadOnly = true;
            this.col備考.ReadOnly = true;

            this.colFesDISCIDVer2.ReadOnly = true;
            this.colNET利用フラグVer2.ReadOnly = true;
            this.col取消日Ver2.ReadOnly = true;
            this.col備考Ver2.ReadOnly = true;


            if (version == DisVersion.VERSION_NUMBER_V1)
            {
                this.colFesDISCID.DefaultCellStyle = dataGridViewCellStyleYellow;
                this.colNET利用フラグ.DefaultCellStyle = dataGridViewCellStyleYellow;
                this.col取消日.DefaultCellStyle = dataGridViewCellStyleYellow;
                this.col備考.DefaultCellStyle = dataGridViewCellStyleYellow;

                this.colFesDISCID.ReadOnly = false;
                this.colNET利用フラグ.ReadOnly = false;
                this.col取消日.ReadOnly = false;
                this.col備考.ReadOnly = false;

            }
            else if (version == DisVersion.VERSION_NUMBER_V2)
            {
                this.colFesDISCIDVer2.DefaultCellStyle = dataGridViewCellStyleYellow;
                this.colNET利用フラグVer2.DefaultCellStyle = dataGridViewCellStyleYellow;
                this.col取消日Ver2.DefaultCellStyle = dataGridViewCellStyleYellow;
                this.col備考Ver2.DefaultCellStyle = dataGridViewCellStyleYellow;

                this.colFesDISCIDVer2.ReadOnly = false;
                this.colNET利用フラグVer2.ReadOnly = false;
                this.col取消日Ver2.ReadOnly = false;
                this.col備考Ver2.ReadOnly = false;
            }
        }

        public override void InitData()
        {
            fesSongWithDiscBusiness = new FesSongWithDiscBusiness();

            // set struct datagridview
            dataGridViewFilter.DataGridViewSource = advDisplayMain;
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

            this.ColKeyIndex = colデジドココンテンツID.Index;
            this.ColChoiseIndex = col選択.Index;

            dataGridViewFilter.EditCellEvent += EditCell;
            LoadResourceColumnCombox();
            InitGridProcess();
        }

        public override void LayoutEditMode(EnumEditMode editMode)
        {
            if (editMode == EnumEditMode.ReadOnly || editMode == EnumEditMode.None)
            {
                foreach (DataGridViewColumn colm in advDisplayMain.Columns)
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
                dataGridViewFilter.DataTableSource = fesSongWithDiscBusiness.GetFesSongWithDiscWorkData();

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

        public override void UpdateColumnSelected(DataGridViewCell cell, object data)
        {
            dataGridViewFilter.UpdateColumnSelected(cell, data);
        }

        public override void UpdateCell(DataGridViewCell cell, object data)
        {
            dataGridViewFilter.UpdateCell(cell, data);
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
            FesVideoAssigmentObject message = new FesVideoAssigmentObject();
            int countSuccess = 0;
            // Update fescontentwork
            DataTable dtUpdate = null;

            try
            {
                dtUpdate = dataGridViewFilter.GetDataSave();

                fesSongWithDiscBusiness.Save(dtUpdate, currentVersion, DeleteCount, ref countSuccess, ref message);

                this.ClosedWaiting();

                Invoke(new Action(() =>
                {
                    if (countSuccess == SaveCount)
                    {
                        MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGI007), GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("データの更新に失敗しました。\n更新予定件数：{0} 件\n処理件数：{1}", SaveCount, countSuccess), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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

            message = null;
            dtUpdate = null;
            GC.Collect();
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
            HideColumns.Add(col削除.DataPropertyName);
            return HideColumns;
        }

        public override ColumnsCollection GetHiraganaColumns()
        {
            HiraganaColumns.Clear();           
            HiraganaColumns.Add(new ColumnEntity() { ColumName = col備考.DataPropertyName, IsDataRequired = false });
            HiraganaColumns.Add(new ColumnEntity() { ColumName = col備考Ver2.DataPropertyName, IsDataRequired = false });
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
            if (fesSongWithDiscSearch == null)
                fesSongWithDiscSearch = new FesSongWithDiscSearch(currentLayout);
            fesSongWithDiscSearch.ShowDialog();
            if (fesSongWithDiscSearch.IsActive)
            {
                dataGridViewFilter.IsDisplayItemSeleted = false;
                LoadData();
                fesSongWithDiscSearch.IsActive = false;
            }
        }
    }
}
