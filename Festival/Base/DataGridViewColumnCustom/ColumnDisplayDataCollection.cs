using System.Collections.Generic;

namespace Festival.Base.DataGridViewColumnCustom
{
    public class ColumnDisplayDataCollection
    {
        public List<ColumnDisplayEntity> CollumnList;
        public ColumnDisplayDataCollection()
        {
            CollumnList = new List<ColumnDisplayEntity>();
        }

        public void Add(ColumnDisplayEntity columns)
        {
            this.CollumnList.Add(columns);
        }
    }

    public class ColumnDisplayEntity
    {
        public int ColumnIndex { get; set; }
        public string ColumnName { get; set; }
        public string DataPropertyName { get; set; }
        public int ColumnDataIndex { get; set; }
    }
}
