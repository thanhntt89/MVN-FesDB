using System.Data;

namespace FestivalBusiness
{
    public class FesPackageQuery
    {
        internal static string GetPackegeAllQuery()
        {
            string sql = string.Format("select パッケージID, FesDISCID,CONVERT(DATETIME, NULL) as UpdateDate, FesDISCID as OldFesDISCID from Wii.dbo.[FesパッケージID情報] order by [パッケージID]");
            return sql;
        }

        internal static string GetPackegeByFesDiscId(string fesdiscId)
        {
            string sql = string.Format("select パッケージID, FesDISCID from Wii.dbo.[FesパッケージID情報] where FesDISCID ='{0}'", fesdiscId);
            return sql;
        }


        internal static string GetSavePackegeQuery(DataTable dataUpdte, ref Parameters parmeters)
        {
            DataRow row = dataUpdte.Rows[0];
            string columnValue = string.Empty;
            string values = string.Empty;
            string columns = string.Empty;

            foreach (DataColumn col in dataUpdte.Columns)
            {
                if (col.ColumnName.Equals("OldFesDISCID"))
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

            string query = string.Format("INSERT INTO Wii.dbo.[FesパッケージID情報] ({0}) VALUES({1})", columns, values);
            return query;
        }

        internal static string GetUpdatePackegeQuery(DataTable dtUpdate, ref Parameters parmeters)
        {
            DataRow row = dtUpdate.Rows[0];
            string values = string.Empty;

            foreach (DataColumn col in dtUpdate.Columns)
            {
                if (!col.ColumnName.Equals("OldFesDISCID"))
                    values += string.Format("{0}=@{0}, ", col.ColumnName);

                parmeters.Add(new Parameter()
                {
                    Name = string.Format("@{0}", col.ColumnName),
                    Values = row[col]
                });
            }

            values = values.Trim();
            values = values.Remove(values.Length - 1, 1);

            string query = string.Format("UPDATE Wii.dbo.[FesパッケージID情報] SET {0} WHERE FesDISCID = @OldFesDISCID", values);
            return query;
        }


        internal static string GetSavePackegeQuery(DataTable dtPackege)
        {
            DataRow row = dtPackege.Rows[0];
            string columns = string.Empty;
            string values = string.Empty;

            foreach (DataColumn col in dtPackege.Columns)
            {
                if (col.ColumnName.Equals("OldFesDISCID"))
                    continue;

                columns += string.Format("[{0}],", col.ColumnName);               
                if (row[col] == null || string.IsNullOrWhiteSpace(row[col].ToString()))
                    values += "NULL,";
                else
                    values += "N'" + row[col].ToString().Replace("'", "''") + "',";
            }

            columns = columns.Remove(columns.Length - 1, 1);
            values = values.Remove(values.Length - 1, 1);

            string query = string.Format("INSERT INTO Wii.dbo.[FesパッケージID情報]({0}) VALUES({1})", columns, values);
            return query;
        }

        internal static string GetUpdatePackegeQuery(DataTable dtPackege)
        {
            DataRow row = dtPackege.Rows[0];
            string id = string.Empty;
            string columnValue = string.Empty;
            string values = string.Empty;
            foreach (DataColumn col in dtPackege.Columns)
            {
                if (col.ColumnName.Equals("OldFesDISCID"))
                {
                    id = row[col].ToString();
                    continue;
                }    

                if (row[col] == null || string.IsNullOrWhiteSpace(row[col].ToString()))
                    columnValue = "NULL";
                else
                    columnValue = "'" + row[col].ToString().Replace("'", "''") + "'";
              
                values += col.ColumnName + " = " + columnValue + ",";
            }
            values = values.Remove(values.Length - 1, 1);
            string query = string.Format("UPDATE Wii.dbo.[FesパッケージID情報] SET {0} WHERE FesDISCID = '{1}'", values, id);
            return query;
        }

        internal static string GetDataByIdQuery(string userId)
        {
            string sql = string.Format("select パッケージID, FesDISCID from Wii.dbo.[FesパッケージID情報] WHERE FesDISCID='{0}'", userId);
            return sql;
        }

        internal static string GetDeleteByIdQuery(string deletedId)
        {
            string query = string.Format("DELETE FROM Wii.dbo.[FesパッケージID情報] WHERE FesDISCID = '{0}'", deletedId);
            return query;
        }
    }
}
