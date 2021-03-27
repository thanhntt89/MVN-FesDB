using FestivalUtilities;

namespace FestivalBusiness
{
    public class SearchFestivalContentBusiness
    {
        private string connectionString = GetConnection.GetWiiSqlConnectionString();

        public SearchFestivalContentBusiness()
        {
            SqlHelpers.CommandTimeOut = GetConnection.SqlCommandTimeOut;
        }

        public void UpdateDataGridView(DataGridViewRowCollection ListRowsUpdate)
        {
            foreach (var row in ListRowsUpdate.ListDataRows)
            {
                if (row.Cells.Count > 0)
                    row.Cells[1].Value.ToString();
            }
        }
    }
}
