using FestivalObjects;
using System.Data;

namespace FestivalBusiness
{
    public class RecommendProgramQuery
    {
        internal static string GetRecommendProgramByIdQuery(string updateId)
        {
            string query = string.Format("SELECT プログラムID,プログラム名,備考 FROM dbo.Fesおすすめプログラム WHERE プログラムID ='{0}'", updateId);
            return query;
        }

        internal static string GetRecommendProgramTableQuery()
        {
            string query = string.Format("SELECT プログラムID,プログラム名,備考, CONVERT(datetime,NULL) as DateTimeUpdate, プログラムID as OldプログラムID FROM dbo.Fesおすすめプログラム ORDER BY プログラムID");
            return query;
        }

        internal static string DeleteRecommendProgramByIdQuery(string deletedId)
        {
            string query = string.Format("DELETE FROM dbo.Fesおすすめプログラム WHERE プログラムID ={0}", deletedId);
            return query;
        }

        internal static string GetUpdateRecommendProgramQuery(RecommendProgramObject recommendProgram)
        {
            string query = string.Format("UPDATE Wii.dbo.Fesおすすめプログラム SET プログラム名 ='{0}',備考 ='{1}' WHERE プログラムID ={2}",
                 recommendProgram.プログラム名,
                 recommendProgram.備考,
                 recommendProgram.プログラムID
                 );
            return query;
        }

        internal static string GetInsertRecommendProgramQuery(RecommendProgramObject recommendProgram)
        {
            string query = string.Format("INSERT INTO Wii.dbo.Fesおすすめプログラム (プログラムID,プログラム名,備考) VALUES((select count(*)+ 1 from dbo.Fesおすすめプログラム),'{0}','{1}')",
                recommendProgram.プログラム名,
                recommendProgram.備考
                );
            return query;
        }

        public static string GetCreateId()
        {
            string query = string.Format("SELECT max(プログラムID) + 1 from  Wii.dbo.Fesおすすめプログラム");
            return query;
        }

        internal static string GetInsertQuery(DataTable dtData)
        {
            DataRow row = dtData.Rows[0];
            string columns = string.Empty;
            string values = string.Empty;

            foreach (DataColumn col in dtData.Columns)
            {
                if (col.ColumnName.Equals("OldプログラムID"))
                    continue;

                columns += string.Format("[{0}],", col.ColumnName);
                if (row[col] == null || string.IsNullOrWhiteSpace(row[col].ToString()))
                    values += "NULL,";
                else
                    values += "'" + row[col].ToString().Replace("'", "''") + "',";
            }

            columns = columns.Remove(columns.Length - 1, 1);
            values = values.Remove(values.Length - 1, 1);

            string query = string.Format("INSERT INTO Wii.dbo.Fesおすすめプログラム({0}) VALUES({1})", columns, values);
            return query;
        }

        internal static string GetDataByIdQuery(string groupId)
        {
            string query = string.Format("SELECT プログラムID,プログラム名,備考, CONVERT(datetime,NULL) as DateTimeUpdate FROM dbo.Fesおすすめプログラム WHERE プログラムID = '{0}'", groupId);
            return query;
        }

        internal static string GetUpdateQuery(DataTable dtData)
        {
            DataRow row = dtData.Rows[0];
            string id = string.Empty;
            string columnValue = string.Empty;
            string values = string.Empty;
            foreach (DataColumn col in dtData.Columns)
            {
                if (col.ColumnName.Equals("OldプログラムID"))
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
            string query = string.Format("UPDATE Wii.dbo.Fesおすすめプログラム SET {0} WHERE プログラムID = '{1}'", values, id);
            return query;
        }
    }
}
