using FestivalCommon;
using FestivalObjects;
using System.Windows.Forms;

namespace Festival.Common
{
    public class FestivalEvents
    {
        //Export file Event
        public delegate void ExportFileEventHandler(FileExportEntity FileInfo);
        // Common events
        public delegate void CommonEventHandler();
        public delegate void StatusEventHandler(bool? status);
        public delegate void EditCellHandler(DataGridViewCell cell);
        public delegate void ColumnsVisibleHandler(string columnName, bool isVisible);
        public delegate void ColumnSortHandler(SortType sortType);
        public delegate void GetTextHandler(string text);
        public delegate void CellClickedHandler(DataGridViewCell cell);
        public delegate void CellDoubleClickedHandler(DataGridViewCell cell);
        public delegate void AddNewEventHandler(object data);
    }
}
