using Festival.Base.DataGridViewColumnCustom;
using FestivalCommon;
using FestivalObjects;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Zuby.ADGV;

namespace Festival.Base
{
    public interface IFesCommonFunction
    {
        void ClearFilterAndSort();
        void InitData();

        void LoadData(List<string> SlqParameters);

        void LoadData();

        void Choise(bool? isSelected);
             

        void EditCell(DataGridViewCell cell);
       
        void UpdateCell(DataGridViewCell cell, object data);

        void UnFilter();

        void ApplyFilter(DataGridViewFilterEntity dataGridViewFilter);

        void UpdateColumnSelected(DataGridViewCell cell, object data);

        /// <summary>
        /// Sort column
        /// </summary>
        /// <param name="sortType"></param>
        void Sort(SortType sortType);

        /// <summary>
        /// Show/Hide column
        /// </summary>
        /// <param name="isStatus"></param>
        void SetColumnVisible(string columnName, bool isVisible);

        void OpenColumnVisible();

        void Cut();

        void Paste();

        void Copy();

        void Save();

        void CloseAndSave();

        AdvancedDataGridView GetDataGridViewSource();

        void ExportToFile(FileExportEntity exportFileInfo);

        int ExportExecute(FileExportEntity exportFileInfo);

        void ResetStatusUpdateColum();

        DataTable GetUpdateData();
        DataTable GetUpdateAndDeletedData();
        DataTable GetExportData();

        // Get data deleted
        DataTable GetDeletedData();

        DataGridViewColumnCollection GetDataGridViewColumns();

        void ActiveMenuFreeze(bool? isActive);
        
        List<string> GetHideColumns();

        /// <summary>
        /// Get all column hiragana
        /// </summary>
        /// <returns></returns>
        ColumnsCollection GetHiraganaColumns();

        /// <summary>
        /// Get all column katakana
        /// </summary>
        /// <returns></returns>
        ColumnsCollection GetKatakanaColumns();       
    }
}
