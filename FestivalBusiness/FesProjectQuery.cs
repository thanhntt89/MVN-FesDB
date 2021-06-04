using System.Data;

namespace FestivalBusiness
{
    class FesProjectQuery
    {
        internal static string GetProjectAllQuery()
        {
            string query = string.Format("SELECT プロジェクトID, 機能名,  CONVERT(DATETIME, NULL) as UpdateDate, プロジェクトID as OldプロジェクトID  FROM Wii.dbo.FesプロジェクトID");
            return query;
        }

        public static string GetDataById(string id)
        {
            string query = string.Format("select プロジェクトID , 機能名 FROM Wii.dbo.FesプロジェクトID where プロジェクトID = '{0}'", id);
            return query;
        }
        
        internal static string GetInsertProjectQuery(DataTable dataUpdte, ref Parameters parmeters)
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

            string query = string.Format("INSERT INTO Wii.dbo.FesプロジェクトID ({0}) VALUES({1})", columns, values);
            return query;
        }

        internal static string GetUpdateProjectQuery(DataTable dtUpdate, ref Parameters parmeters)
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

            string query = string.Format("UPDATE Wii.dbo.FesプロジェクトID SET {0} WHERE プロジェクトID = @OldプロジェクトID", values);
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
                    columnValue = "N'" + row[col] + "'";
                values += columnValue + ",";
            }
            values = values.Remove(values.Length - 1, 1);
            columns = columns.Remove(columns.Length - 1, 1);

            string query = string.Format("INSERT INTO Wii.dbo.FesプロジェクトID  ({0}) VALUES({1})", columns, values);
            return query;
        }

        internal static string GetUpdateQuery(DataTable dataUpdte)
        {
            DataRow row = dataUpdte.Rows[0];
            string oldId = row["OldプロジェクトID"].ToString();
            string プロジェクトID = row["プロジェクトID"].ToString();
            string 機能名 = row["機能名"].ToString();
            string query = string.Format("UPDATE Wii.dbo.FesプロジェクトID  SET プロジェクトID = N'{0}',機能名 =N'{1}'  WHERE プロジェクトID = '{2}'", プロジェクトID, 機能名, oldId);
            return query;
        }

        internal static string GetDeleteById(string projectId)
        {
            string query = string.Format("DELETE FROM Wii.dbo.FesプロジェクトID where プロジェクトID = '{0}'", projectId);
            return query;
        }
    }
}
