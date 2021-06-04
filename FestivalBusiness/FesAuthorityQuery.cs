using System.Data;

namespace FestivalBusiness
{
    public class FesAuthorityQuery
    {
        internal static string GetFunctionListQuery()
        {
            string query = string.Format("select [プロジェクトID] ,[機能ID], 機能名 from Wii.dbo.[Fes機能ID]");
            return query;
        }

        internal static string GetAuthorityAllQuery()
        {
            string query = string.Format("select 権限グループ,プロジェクトID,機能ID,更新タイプ, CONVERT(DATETIME, NULL) as UpdateDate, 権限グループ as Old権限グループ, プロジェクトID as OldプロジェクトID,機能ID as Old機能ID  from Wii.dbo.[Fes権限グループ機能割当] order by [機能ID], [権限グループ]");
            return query;
        }


        internal static string GetInsertAuthorityQuery(DataTable dataUpdte, ref Parameters parmeters)
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

            string query = string.Format("INSERT INTO Wii.dbo.[Fes権限グループ機能割当] ({0}) VALUES({1})", columns, values);
            return query;
        }

        internal static string GetUpdateAuthorityQuery(DataTable dtUpdate, ref Parameters parmeters)
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

            string query = string.Format("UPDATE Wii.dbo.[Fes権限グループ機能割当] SET {0} WHERE 権限グループ = @Old権限グループ AND プロジェクトID = @OldプロジェクトID AND 機能ID = @Old機能ID", values);
            return query;
        }

        internal static string GetInsertAuthorityQuery(DataTable dataUpdte)
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

            string query = string.Format("INSERT INTO Wii.dbo.[Fes権限グループ機能割当] ({0}) VALUES({1})", columns, values);
            return query;
        }

        internal static string GetUpdateAuthorityQuery(DataTable dtSave)
        {
            DataRow row = dtSave.Rows[0];
            string old権限グループ = row["Old権限グループ"].ToString();
            string oldプロジェクトID = row["OldプロジェクトID"].ToString();
            string old機能ID = row["Old機能ID"].ToString();

            string 権限グループ = row["権限グループ"].ToString();
            string プロジェクトID = row["プロジェクトID"].ToString();
            string 機能ID = row["機能ID"].ToString();
            string 更新タイプ = row["更新タイプ"].ToString();

            string query = string.Format("UPDATE Wii.dbo.[Fes権限グループ機能割当] SET 権限グループ =N'{0}', プロジェクトID ='{1}',機能ID='{2}', 更新タイプ = N'{3}' WHERE 権限グループ = '{4}' AND プロジェクトID ='{5}' AND 機能ID='{6}'", 権限グループ, プロジェクトID, 機能ID, 更新タイプ, old権限グループ, oldプロジェクトID, old機能ID);
            return query;
        }

        internal static string GetDeleteQuery(string userId, string functionId, string roleId)
        {
            string query = string.Format("DELETE FROM Wii.dbo.[Fes権限グループ機能割当]  WHERE 権限グループ = '{0}' AND プロジェクトID ='{1}' AND 機能ID='{2}'", userId, functionId, roleId);
            return query;
        }

        internal static string GetGetAuthorityQuery(string userId, string functionId, string roleId)
        {
            string query = string.Format("SELECT 権限グループ,プロジェクトID,機能ID,更新タイプ FROM Wii.dbo.[Fes権限グループ機能割当]  WHERE 権限グループ = '{0}' AND プロジェクトID ='{1}' AND 機能ID='{2}'", userId, functionId, roleId);
            return query;
        }
    }
}
