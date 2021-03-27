using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalBusiness
{
    public class FesUserQuery
    {
        internal static string GetUsersAllQuery()
        {
            string query = string.Format("select 利用者ID, 権限グループ, 利用者名, CONVERT(DATETIME, NULL) as UpdateDate, 利用者ID as Old利用者ID from Wii.dbo.[Fes利用者]");
            return query;
        }

        internal static string GetAuthorityAllQuery()
        {
            string query = string.Format("SELECT  [権限グループ] ,[権限名]   FROM [Wii].[dbo].[Fes権限グループ]");
            return query;
        }

        internal static string GetDeleteByIdQuery(string userId)
        {
            string query = string.Format("DELETE FROM Wii.dbo.[Fes利用者] WHERE 利用者ID='{0}'", userId);
            return query;
        }

        internal static string GetDataByIdQuery(string userId)
        {
            string query = string.Format("select 利用者ID, 権限グループ, 利用者名 from Wii.dbo.[Fes利用者] where 利用者ID='{0}'", userId);
            return query;
        }

        internal static string GetInsertQuery(DataTable dataUpdte)
        {
            DataRow row = dataUpdte.Rows[0];
            string columnValue = string.Empty;
            string values = string.Empty;
            string columns = string.Empty;

            foreach (DataColumn col in dataUpdte.Columns)
            {
                if (col.ColumnName.Contains("Old"))
                    continue;

                columns += string.Format("[{0}],", col.ColumnName);

                if (row[col] == null || string.IsNullOrWhiteSpace(row[col].ToString()))
                    columnValue = "NULL";
                else
                    columnValue = "N'" + row[col].ToString().Replace("'", "''") + "'";
                values += columnValue + ",";
            }
            values = values.Remove(values.Length - 1, 1);
            columns = columns.Remove(columns.Length - 1, 1);

            string query = string.Format("INSERT INTO Wii.dbo.[Fes利用者]  ({0}) VALUES({1})", columns, values);
            return query;
        }

        internal static string GetUpdateQuery(DataTable dtUpdate)
        {
            DataRow row = dtUpdate.Rows[0];
            string oldId = row["Old利用者ID"].ToString();
            string 利用者ID = row["利用者ID"].ToString();
            string 権限グループ = row["権限グループ"].ToString().Replace("'", "''");
            string 利用者名 = row["利用者名"].ToString().Replace("'", "''");

            string query = string.Format("UPDATE Wii.dbo.[Fes利用者] SET  利用者ID = N'{0}',権限グループ =N'{1}',利用者名=N'{2}' WHERE 利用者ID = '{3}'", 利用者ID, 権限グループ, 利用者名, oldId);
            return query;
        }
    }
}
