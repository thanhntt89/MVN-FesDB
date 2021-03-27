using Festival.Base.DataGridViewColumnCustom;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Festival.Base
{
    public class RowAddNewObject
    {
        public string KeyId { get; set; }

        public List<ColumnObject> Columns;
        public RowAddNewObject()
        {
            Columns = new List<ColumnObject>();
        }

        public void Add(ColumnObject column)
        {
            Columns.Add(column);
        }

        public ColumnObject GetColumn(string columnName)
        {
            var exist = Columns.Where(r => r.ColumnDataPropertyName.Equals(columnName)).FirstOrDefault();
            return exist;
        }
    }
    public class ColumnObject
    {
       
        public int ColumnIndex { get; set; }
        public string ColumnName { get; set; }
        public string ColumnDataPropertyName { get; set; }
        public object Data { get; set; }
        public bool IsBulkInsert { get; set; }
        public DataTable DataTableBulkInsert { get; set; }
        public ColumnDisplayDataCollection ColumnsBulkInsert { get; set; }
    }
}
