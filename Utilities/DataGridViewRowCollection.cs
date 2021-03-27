using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FestivalUtilities
{
    public class DataGridViewRowCollection
    {
        public IList<DataGridViewRow> ListDataRows { get; set; }

        public DataGridViewRowCollection()
        {
            ListDataRows = new List<DataGridViewRow>();
        }

        public int Count { get { return ListDataRows.Count; } }

        public void Add(DataGridViewRow row, int columnIndex)
        {
            if (columnIndex == -1) return;
            var checkUpdate = ListDataRows.Where(r => r.Cells[columnIndex].Value != null && r.Cells[columnIndex].Value.Equals(row.Cells[columnIndex].Value)).FirstOrDefault();

            if (checkUpdate == null)
                ListDataRows.Add(row);
            else
            {
                checkUpdate = row;
            }
        }

        public DataGridViewRow GetDataGridViewRow(DataGridViewRow row)
        {
            return ListDataRows.Where(r => r.DataGridView == row.DataGridView).FirstOrDefault<DataGridViewRow>();
        }
    }

}
