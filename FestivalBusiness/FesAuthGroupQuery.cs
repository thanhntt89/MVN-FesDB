using System.Data;

namespace FestivalBusiness
{
    class FesAuthGroupQuery
    {
        public static string GetDataByIdQuery(string authGroupId)
        {
            string query = string.Format("select 権限グループ , 権限名 FROM [Wii].[dbo].[Fes権限グループ] where 権限グループ = '{0}'", authGroupId);
            return query;
        }

        internal static string GetGroupAuthorityAllQuery()
        {
            string query = string.Format("SELECT 権限グループ ,権限名,  CONVERT(DATETIME, NULL) as UpdateDate, 権限グループ as Old権限グループ  FROM [Wii].[dbo].[Fes権限グループ]");
            return query;
        }


        internal static string GetInsertQuery(DataTable dataUpdte, ref Parameters parmeters)
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
                values += string.Format("@{0},", col.ColumnName);
                parmeters.Add(new Parameter()
                {
                    Name = string.Format("@{0}", col.ColumnName),
                    Values = row[col]
                });
            }

            values = values.Remove(values.Length - 1, 1);
            columns = columns.Remove(columns.Length - 1, 1);

            string query = string.Format("INSERT INTO [Wii].[dbo].[Fes権限グループ] ({0}) VALUES({1})", columns, values);
            return query;
        }

        internal static string GetUpdateQuery(DataTable dtUpdate, ref Parameters parmeters)
        {
            DataRow row = dtUpdate.Rows[0];
            string values = string.Empty;

            foreach (DataColumn col in dtUpdate.Columns)
            {
                if (!col.ColumnName.Contains("Old"))
                    values += string.Format("{0}=@{0}, ", col.ColumnName);

                parmeters.Add(new Parameter()
                {
                    Name = string.Format("@{0}", col.ColumnName),
                    Values = row[col]
                });
            }

            values = values.Trim();
            values = values.Remove(values.Length - 1, 1);

            string query = string.Format("UPDATE [Wii].[dbo].[Fes権限グループ] SET {0} WHERE 権限グループ = @Old権限グループ", values);
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
                    columnValue = "N'" + row[col].ToString().Replace("'","''") + "'";
                values += columnValue + ",";
            }
            values = values.Remove(values.Length - 1, 1);
            columns = columns.Remove(columns.Length - 1, 1);

            string query = string.Format("INSERT INTO [Wii].[dbo].[Fes権限グループ]  ({0}) VALUES({1})", columns, values);
            return query;
        }

        internal static string GetUpdateQuery(DataTable dtUpdate)
        {
            DataRow row = dtUpdate.Rows[0];
            string oldId = row["Old権限グループ"].ToString();
            string 権限グループ = row["権限グループ"].ToString().Replace("'", "''");
            string 権限名 = row["権限名"].ToString().Replace("'", "''");

            string query = string.Format("UPDATE [Wii].[dbo].[Fes権限グループ]  SET 権限グループ = N'{0}',権限名 =N'{1}'  WHERE 権限グループ = '{2}'", 権限グループ, 権限名, oldId);
            return query;
        }

        internal static string GetDeleteByIdQuery(string userId)
        {
            string query = string.Format("DELETE FROM [Wii].[dbo].[Fes権限グループ]  WHERE 権限グループ = '{0}'", userId);
            return query;
        }
    }
}
