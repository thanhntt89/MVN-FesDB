using System;
using System.Data;
using System.Data.SqlClient;

namespace FestivalBusiness
{
    public class SingerManagementBusiness : BusinessBase
    {
        public void DeleteSingerId(string deletedId)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, SingerManagementQuery.GetDeleteSingerByIdQuery(deletedId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetSingerTable()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, SingerManagementQuery.GetSingerDataAllQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetSingerDataById(string updateId)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, SingerManagementQuery.GetSingerByIdQuery(updateId)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Save(DataTable dtSource, ref int countUpdate)
        {
            try
            {
                // Save data
                connection = new SqlConnection(GetConnection.GetWiiSqlConnectionString());

                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DataTable dataUpdte = new DataTable();
                dataUpdte.Columns.Add("Fes独自歌手ID");
                dataUpdte.Columns.Add("歌手名");
                dataUpdte.Columns.Add("歌手名検索用カナ");
                dataUpdte.Columns.Add("歌手名ソート用カナ");
                dataUpdte.Columns.Add("歌手名ソート用英数");
                dataUpdte.Columns.Add("OldFes独自歌手ID");

                sqlTransac = connection.BeginTransaction();
                string sqlExecuteString = string.Empty;
                string oldId = string.Empty;

                foreach (DataRow row in dtSource.Rows)
                {
                    dataUpdte.Rows.Clear();
                    sqlExecuteString = string.Empty;
                    dataUpdte.Rows.Add(row["Fes独自歌手ID"], row["歌手名"], row["歌手名検索用カナ"], row["歌手名ソート用カナ"], row["歌手名ソート用英数"], row["OldFes独自歌手ID"]);

                    oldId = row["OldFes独自歌手ID"] == null ? string.Empty : row["OldFes独自歌手ID"].ToString();

                    if (string.IsNullOrWhiteSpace(oldId))
                    {
                        sqlExecuteString = SingerManagementQuery.GetInsertSingerQuery(dataUpdte);
                    }
                    else
                    {
                        sqlExecuteString = SingerManagementQuery.GetUpdateSingerQuery(dataUpdte);
                    }

                    SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, sqlExecuteString);
                    countUpdate++;
                }

                sqlTransac.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                sqlTransac.Rollback();
                connection.Close();
                throw ex;
            }
        }

        public void Save(DataTable tbData, string updateId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(updateId))
                    SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, SingerManagementQuery.GetInsertSingerQuery(tbData));
                else
                    SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, SingerManagementQuery.GetUpdateSingerQuery(tbData));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDataById(string singerId)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, SingerManagementQuery.GetSingerByIdQuery(singerId)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
