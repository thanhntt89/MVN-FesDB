using System.Collections.Generic;
using System.Linq;

namespace FestivalCommon
{
    public class ColumnsCollection
    {
        public IList<ColumnEntity> Columns;
        public ColumnsCollection()
        {
            Columns = new List<ColumnEntity>();
        }

        public void Add(ColumnEntity column)
        {
            this.Columns.Add(column);
        }

        public int Count
        {
            get
            {
                return this.Columns.Count;
            }

        }

        public bool Contains(string columnName)
        {
            var exist = this.Columns.Where(r => r.ColumName.Contains(columnName)).FirstOrDefault();
            if (exist != null)
                return true;
            return false;
        }

        public bool Exist(string columnName)
        {
            var exist = this.Columns.Where(r => r.ColumName.Equals(columnName)).FirstOrDefault();
            if (exist != null)
                return true;
            return false;
        }

        public void Clear()
        {
            this.Columns.Clear();
        }

        public bool IsDataRequired(string columName)
        {
            return this.Columns.Where(r => r.ColumName.Equals(columName)).FirstOrDefault().IsDataRequired;
        }

        public bool IsNumericRequired(string columName)
        {
            return this.Columns.Where(r => r.ColumName.Equals(columName)).FirstOrDefault().IsNumeric;
        }
       
        public ColumnEntity GetColumn(string columnName)
        {
            return Columns.Where(r => r.ColumName.Equals(columnName)).FirstOrDefault();
        }
    }

    public class ColumnEntity
    {
        public string ColumName { get; set; }
        public bool IsNumeric { get; set; }
        public bool IsOnlyKatakana { get; set; }
        public bool IsOnlyHiragana { get; set; }
        public bool IsDataRequired { get; set; }
        public bool IsHankakuEiSu { get; set; }
        public bool IsUpperCase { get; set; }
        // Value update
        public object Values { get; set; }
    }
}
