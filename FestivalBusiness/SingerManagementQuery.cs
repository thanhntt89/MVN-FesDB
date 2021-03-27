using System;
using System.Data;
using FestivalObjects;

namespace FestivalBusiness
{
    public class SingerManagementQuery
    {
        internal static string GetSingerDataAllQuery()
        {
            string query = string.Format("SELECT Fes独自歌手ID,歌手名,歌手名検索用カナ,歌手名ソート用カナ,歌手名ソート用英数, CONVERT(datetime,NULL) as DateTimeUpdate, Fes独自歌手ID as OldFes独自歌手ID FROM Wii.dbo.Fes独自歌手管理 ORDER BY Fes独自歌手ID");
            return query;
        }

        internal static string GetDeleteSingerByIdQuery(string deletedId)
        {
            string query = string.Format("DELETE FROM Wii.dbo.Fes独自歌手管理  WHERE Fes独自歌手ID ={0}", deletedId);
            return query;
        }

        internal static string GetSingerByIdQuery(string updateId)
        {
            string query = string.Format("SELECT Fes独自歌手ID,歌手名,歌手名検索用カナ,歌手名ソート用カナ,歌手名ソート用英数 FROM Wii.dbo.Fes独自歌手管理 WHERE Fes独自歌手ID ='{0}'", updateId);
            return query;
        }

        internal static string GetInsertSingerQuery(DataTable dtPackege)
        {
            DataRow row = dtPackege.Rows[0];
            string columns = string.Empty;
            string values = string.Empty;

            foreach (DataColumn col in dtPackege.Columns)
            {
                if (col.ColumnName.Equals("OldFes独自歌手ID")) continue;

                columns += string.Format("[{0}],", col.ColumnName);
                if (row[col] == null || string.IsNullOrWhiteSpace(row[col].ToString()))
                    values += "NULL,";
                else
                    values += "'" + row[col].ToString().Replace("'", "''") + "',";
            }

            columns = columns.Remove(columns.Length - 1, 1);
            values = values.Remove(values.Length - 1, 1);

            string query = string.Format("INSERT INTO  Wii.dbo.Fes独自歌手管理 ({0}) VALUES({1})", columns, values);
            return query;
        }

        internal static string GetUpdateSingerQuery(DataTable tbData)
        {
            DataRow row = tbData.Rows[0];
            string id = string.Empty;
            string columnValue = string.Empty;
            string values = string.Empty;
            foreach (DataColumn col in tbData.Columns)
            {               
                if (col.ColumnName.Equals("OldFes独自歌手ID"))
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
            string query = string.Format("UPDATE Wii.dbo.Fes独自歌手管理  SET {0} WHERE Fes独自歌手ID = '{1}'", values, id);
            return query;
        }
    }
}
