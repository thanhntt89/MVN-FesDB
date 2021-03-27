using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using FestivalCommon;
using FestivalObjects;
using Festival.Common;
using static Festival.Common.FestivalEvents;
using FestivalUtilities;
using Zuby.ADGV;
using Festival.Base.DataGridViewColumnCustom;
using System.Linq;
namespace Festival.Base
{
    public partial class UserControlBaseAdvance : UserControl, IFesCommonFunction
    {
        public DataGridViewColumnCollection ColumnCollection { get; set; }
        public ActiveMenuCollection ActiveMenusSearchMain = new ActiveMenuCollection();

        public List<string> SearchConditionColumnComboxData;

        public List<string> HideColumns = new List<string>();

        public ColumnsCollection HiraganaColumns = new ColumnsCollection();

        public ColumnsCollection KatakanaColumns = new ColumnsCollection();

        public ColumnsCollection HankakuEiSuColumns = new ColumnsCollection();

        public List<string> DisableBulkInsertColumns = new List<string>();

        public MenuMainCollection MainMenuEditModeCollection { get; set; }

        public List<int> noUpdateRecordList = new List<int>();

        /// <summary>
        /// Datasource display column text
        /// </summary>
        public DataTable DataSourceDisplay { get; set; }

        public string ColumnComboxChangeName { get; set; }

        public virtual bool IsDataUpdated
        {
            get;
        }
        
        //public bool HasData { get; set; }

        public bool CancelClose { get; set; }


        public UserControlBaseAdvance()
        {
            InitializeComponent();
            MainMenuEditModeCollection = new MenuMainCollection();
        }

        public BindingSource bindingSource_main = new BindingSource();

        public WaitingForm waiting = null;
        public BackgroundWorker bgwProcess = null;

        public static LayOutEntity CurrentLayout;

        // Screen title
        public string SCREEN_TITLE { get; set; }

        public DataTable DataTableSource { get; set; }
        //Copy all data row of datagridview
        public DataGridViewRow[] DataRowsSource;
        public AdvancedDataGridView DataGridViewSource { get; set; }
        // Colum check box status
        public int ColChoiseIndex { get; set; }
        //Column key table using update data
        public int ColUpdatedIndex { get; set; }
        public string ColumnUpdateName { get; set; }
        public int ColKeyIndex { get; set; }

        //Column deleted
        public int ColDeletedIndex { get; set; }
        public string ColumnDeletedName { get; set; }
        public string ColumnDeletedDataPropertyName { get; set; }
        public string ColumnUpdateTimeDataPropertyName { get; set; }
        public string ColumnUpdateTimeName { get; set; }
        public string ColumnKeyDataPropertyName { get; set; }
        public string ColumnKeyName { get; set; }
        public string ColumnChoiseDataPropertyName { get; set; }
        public string ColumnChoiseName { get; set; }

        // current row index selected
        public int CurrentRowsIndex;
        public int DeleteCount = 0;
        public int SaveCount = 0;

        // Current display status: Default value must is False
        public bool? IsDisplayItemSeleted;
        public int CurrentColumnIndex = -1;
        public string CurrentColumnDataPropertyName = string.Empty;
        public string CurrentColumnName = string.Empty;
        public string CurrentKeyValue = string.Empty;
        // Event cell edit
        public EditCellHandler EditCellEvent;
        public EditCellHandler UpdateCellEvent;
        public EditCellHandler CellEndEditEvent;
        public EditCellHandler RowLeaveEvent;       
        public EditCellHandler ValidatingRowEvent;

        public GetTextHandler DisplayTitleEvent;
        public CommonEventHandler UnFilterEvent;
        public CommonEventHandler ActiveMenuEvent;
        public StatusEventHandler ActiveMenuColumnEvent;
        public StatusEventHandler ActiveMenuFreezeEvent;
        public StatusEventHandler ActiveMenuHasDataEvent;
        public CellClickedHandler CellClickedEvent;
        public CellDoubleClickedHandler CellDoubleClickedEvent;
        public StatusEventHandler CancelCloseEvent;

        // Filter Active
        public virtual bool IsFilterActive { get; set; }

        public void InitSearchConditionColumnCombox()
        {
            if (SearchConditionColumnComboxData == null)
                SearchConditionColumnComboxData = new List<string>();
            SearchConditionColumnComboxData.Add(string.Empty);
            SearchConditionColumnComboxData.Add("Is Null");
            SearchConditionColumnComboxData.Add("Is Not Null");
        }

        public BackgroundWorker CreateThread()
        {
            bgwProcess = new BackgroundWorker();
            bgwProcess.WorkerSupportsCancellation = true;
            return bgwProcess;
        }

        public void ShowWating()
        {
            if (waiting == null)
                waiting = new WaitingForm();
            if (waiting != null)
                waiting.ShowDialog();
        }


        public void ClosedWaiting()
        {
            Invoke(new Action(() =>
            {
                if (waiting != null)
                {
                    //if (bgwProcess != null)
                    //{
                    //    bgwProcess.CancelAsync();
                    //    bgwProcess.Dispose();
                    //    bgwProcess = null;
                    //}
                    waiting.Close();
                    waiting = null;
                }
            }));
        }

        /// <summary>
        /// Write log exception
        /// </summary>
        /// <param name="ex">Exception</param>
        public void LogException(ErrorEntity error)
        {
            try
            {
                LogWriter.Write(error.FilePath, error.GetLogInfo());
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    MessageBox.Show("Writer log files fail: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        public string GetClassName()
        {
            return this.GetType().Name;
        }

        public virtual bool ActiveMenuByTagId(string tagId, EnumEditMode editMode)
        {
            var button = this.Controls.Cast<Button>().Where(b => b.Tag.Equals(tagId)).FirstOrDefault();

            //var button = buttons.Where(r => r.Tag.Equals(tagId)).FirstOrDefault();
            if (button != null && !button.Enabled)
            {
                button.Enabled = true;
                MainMenuEditModeCollection.Add(new MenuMainEntity { TagId = tagId, EditMode = editMode });
                return true;
            }
            return false;
        }

        public virtual void LayoutEditMode(EnumEditMode editMode)
        {

        }

        public virtual void LoadData(List<string> SlqParameters)
        {

        }

        public virtual void LoadData()
        {

        }

        /// <summary>
        /// Init all data for data griview include all event using for datagridview
        /// </summary>
        public virtual void InitData()
        {

        }

        /// <summary>
        /// DataGridviewEvent
        /// </summary>
        private void InitDataGridViewEvent()
        {

        }

        /// <summary>
        /// Export File
        /// </summary>
        /// <param name="FileInfo"></param>
        public virtual void ExportToFile(FileExportEntity exportFileInfo)
        {
        }

        /// <summary>
        /// Seleted all in datagridview
        /// </summary>
        /// <param name="isSelected"></param>
        public virtual void Choise(bool? isSelected)
        {

        }

        /// <summary>
        /// Display seleted item
        /// </summary>
        /// <param name="isDisplaySeleted"></param>
        public virtual void DisplayItemSeleted(bool? isDisplayItemSeleted)
        {

        }

        public virtual void EditCell(DataGridViewCell cell)
        {

        }

        /// <summary>
        /// CreateFilter
        /// </summary>
        public virtual void CreateFilter()
        {

        }

        /// <summary>
        /// UnFilter
        /// </summary>
        public virtual void UnFilter()
        {

        }

        /// <summary>
        /// Filter
        /// </summary>
        public virtual void Filter()
        {

        }

        /// <summary>
        /// Apply filter
        /// </summary>
        /// <param name="dataGridViewFilter"></param>
        public virtual void ApplyFilter(DataGridViewFilterEntity dataGridViewFilter)
        {

        }

        /// <summary>
        /// Frozen column selected
        /// </summary>
        /// <param name="isFrozen"></param>
        public virtual void Frozen(bool? isFrozen)
        {

        }

        /// <summary>
        /// Update data in column selected
        /// </summary>
        /// <param name="data"></param>
        public virtual void UpdateColumnSelected(DataGridViewCell cell, object data)
        {

        }

        /// <summary>
        /// Sort column
        /// </summary>
        /// <param name="sortType"></param>
        public virtual void Sort(SortType sortType)
        {

        }

        public virtual void SetColumnVisible(string columnName, bool isVisible)
        {

        }

        public virtual void Cut()
        {

        }

        public virtual void Paste()
        {

        }

        public virtual void Copy()
        {

        }

        public virtual void Save()
        {

        }

        public virtual AdvancedDataGridView GetDataGridViewSource()
        {
            throw new NotImplementedException();
        }

        public virtual void ResetStatusUpdateColum()
        {

        }

        public virtual DataTable GetUpdateData()
        {
            throw new NotImplementedException();
        }

        public virtual void ClearFilterAndSort()
        {

        }

        public virtual DataGridViewColumnCollection GetDataGridViewColumns()
        {
            return this.ColumnCollection;
        }

        public virtual void OpenColumnVisible()
        {

        }

        public virtual void CloseAndSave()
        {

        }

        public virtual int ExportExecute(FileExportEntity exportFileInfo)
        {
            throw new NotImplementedException();
        }

        public virtual void ActiveMenuFreeze(bool? isActive)
        {
            throw new NotImplementedException();
        }

        public virtual void ActiveMenuHasData(bool? isActive)
        {
        }


        public virtual List<string> GetHideColumns()
        {
            return this.HideColumns;
        }

        public virtual DataTable GetDeletedData()
        {
            throw new NotImplementedException();
        }

        public virtual ColumnsCollection GetHiraganaColumns()
        {
            return this.HiraganaColumns;
        }

        public virtual ColumnsCollection GetKatakanaColumns()
        {
            return this.KatakanaColumns;
        }

        public virtual ColumnsCollection GetHankakuEiSuColumns()
        {
            return this.HankakuEiSuColumns;
        }

        public virtual List<string> GetDisableBulkInsertColumns()
        {
            return this.DisableBulkInsertColumns;
        }

        public virtual DataTable GetExportData()
        {
            throw new NotImplementedException();
        }

        public virtual void OpenSearchingCondition(LayOutEntity currentLayout)
        {

        }

        public virtual void OpenImportFile()
        {

        }

        public virtual DataTable GetUpdateAndDeletedData()
        {
            throw new NotImplementedException();
        }


        public virtual void UpdateCell(DataGridViewCell cell, object data)
        {

        }

        public virtual void AddNewRow()
        {

        }

        public virtual void InitMenuSearchMain()
        {

        }
    }
}
