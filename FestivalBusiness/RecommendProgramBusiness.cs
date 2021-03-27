using System;
using System.Data;
using System.Data.SqlClient;

namespace FestivalBusiness
{
    public class RecommendProgramBusiness : BusinessBase
    {
        public DataTable GetProgramById(string updateId)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, RecommendProgramQuery.GetRecommendProgramByIdQuery(updateId)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetRecommendProgramTable()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, RecommendProgramQuery.GetRecommendProgramTableQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteRecommendProgramById(string deletedId)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, RecommendProgramQuery.DeleteRecommendProgramByIdQuery(deletedId));
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
                dataUpdte.Columns.Add("プログラムID");
                dataUpdte.Columns.Add("プログラム名");
                dataUpdte.Columns.Add("備考");               
                dataUpdte.Columns.Add("OldプログラムID");

                sqlTransac = connection.BeginTransaction();
                string sqlExecuteString = string.Empty;
                string oldId = string.Empty;

                foreach (DataRow row in dtSource.Rows)
                {
                    dataUpdte.Rows.Clear();
                    sqlExecuteString = string.Empty;
                    dataUpdte.Rows.Add(row["プログラムID"], row["プログラム名"], row["備考"], row["OldプログラムID"]);

                    oldId = row["OldプログラムID"] == null ? string.Empty : row["OldプログラムID"].ToString();

                    if (string.IsNullOrWhiteSpace(oldId))
                    {
                        sqlExecuteString = RecommendProgramQuery.GetInsertQuery(dataUpdte);
                    }
                    else
                    {
                        sqlExecuteString = RecommendProgramQuery.GetUpdateQuery(dataUpdte);
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

        public void Save(DataTable dtData, string updateId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(updateId))
                {
                    DataTable dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, RecommendProgramQuery.GetCreateId()).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        dtData.Rows[0]["プログラムID"] = dt.Rows[0][0];
                        SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, RecommendProgramQuery.GetInsertQuery(dtData));
                    }                   
                }
                else
                    SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, RecommendProgramQuery.GetUpdateQuery(dtData));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDataById(string groupId)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, RecommendProgramQuery.GetDataByIdQuery(groupId)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
