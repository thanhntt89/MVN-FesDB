using System.Data;

namespace FestivalBusiness
{
    public class FesFunctionQuery
    {
        internal static string GetFunctionAllQuery()
        {
            string query = string.Format("SELECT [プロジェクトID] ,[機能ID],[機能名],[タイムスタンプ], CONVERT(VARCHAR,CONVERT(DATETIME, NULL),111) as UpdateDate, [プロジェクトID] as OldプロジェクトID,機能ID as Old機能ID  FROM [Wii].[dbo].[Fes機能ID]");
            return query;
        }       
    
        public static string GetDataByIdQuery(string projectId, string functionId)
        {
            string query = string.Format("select [プロジェクトID] , [機能ID], [機能名], [タイムスタンプ] FROM [Wii].[dbo].[Fes機能ID] where [プロジェクトID] = '{0}' AND [機能ID] = '{1}' ", projectId, functionId);
            return query;
        }
        
        internal static string GetInsertFunctionQuery(DataTable dataUpdte, ref Parameters parmeters)
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

            string query = string.Format("INSERT INTO [Wii].[dbo].[Fes機能ID] ({0}) VALUES({1})", columns, values);
            return query;
        }
        
        internal static string GetUpdateFunctionQuery(DataTable dtUpdate, ref Parameters parmeters)
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

            string query = string.Format("UPDATE [Wii].[dbo].[Fes機能ID] SET {0} WHERE プロジェクトID = @OldプロジェクトID AND 機能ID= @Old機能ID", values);
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

            string query = string.Format("INSERT INTO [Wii].[dbo].[Fes機能ID] ({0}) VALUES({1})", columns, values);
            return query;
        }

        internal static string GetUpdateQuery(DataTable dataUpdte)
        {
            DataRow row = dataUpdte.Rows[0];
            string oldProjectId = row["OldプロジェクトID"].ToString();
            string oldFunctionId = row["Old機能ID"].ToString();

            string newProjectId = row["プロジェクトID"].ToString();
            string newFunctionId = row["機能ID"].ToString();
            string fuctionName = row["機能名"].ToString().Replace("'", "''");

            string query = string.Format("UPDATE [Wii].[dbo].[Fes機能ID] SET プロジェクトID = N'{0}',機能ID =N'{1}', 機能名=N'{2}'  WHERE プロジェクトID = '{3}' AND 機能ID ='{4}'", newProjectId, newFunctionId, fuctionName, oldProjectId, oldFunctionId);
            return query;
        }
              

        internal static string DeleteByIdQuery(string projectId, string functionId)
        {
            string query = string.Format("DELETE FROM [Wii].[dbo].[Fes機能ID] WHERE プロジェクトID = '{0}' AND 機能ID ='{1}'", projectId, functionId);
            return query;
        }
    }
}
