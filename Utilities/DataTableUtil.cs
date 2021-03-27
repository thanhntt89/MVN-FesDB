using System.Data;
using System.Linq;

namespace FestivalUtilities
{
    public class DataTableUtil
    {
        public static string GetDataInColumn(DataRow row, string columnName, DataTable tableName)
        {
            if (string.IsNullOrEmpty(columnName) || row == null || tableName == null)
                return null;
            var query = from DataColumn col in tableName.Columns
                        where col.ColumnName.Equals(columnName)
                        select col;

            if (query != null)
                return row[query.FirstOrDefault()].ToString();
            else
                return null;
        }

        public static bool CheckDataInColumn(string values, string columnName, DataTable tableName)
        {
            var query = from DataRow row in tableName.Rows
                        where row[columnName].Equals(values)
                        select row;
            if (query.Count() > 0)
                return true;
            else
                return false;
        }
    }
}
