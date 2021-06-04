using System;
using System.Data;
using System.Data.SqlClient;

namespace FestivalBusiness
{
    public class FesProjectBusiness : BusinessBase
    {
        private CommonBusiness commonBusiness = new CommonBusiness();

        public DataTable GetProjectAll()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesProjectQuery.GetProjectAllQuery()).Tables[0];
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

                sqlTransac = connection.BeginTransaction();

                DataTable dataUpdte = new DataTable();
                dataUpdte.Columns.Add("プロジェクトID");
                dataUpdte.Columns.Add("機能名");
                dataUpdte.Columns.Add("OldプロジェクトID");

                string sqlExecuteString = string.Empty;
                string oldId = string.Empty;
                Parameters parameter;

                foreach (DataRow row in dtSource.Rows)
                {
                    dataUpdte.Rows.Clear();
                    sqlExecuteString = string.Empty;
                    dataUpdte.Rows.Add(row["プロジェクトID"], row["機能名"], row["OldプロジェクトID"]);

                    oldId = row["OldプロジェクトID"] == null ? string.Empty : row["OldプロジェクトID"].ToString();

                    parameter = new Parameters();

                    if (string.IsNullOrWhiteSpace(oldId))
                    {
                        sqlExecuteString = FesProjectQuery.GetInsertProjectQuery(dataUpdte, ref parameter);
                    }
                    else
                    {
                        sqlExecuteString = FesProjectQuery.GetUpdateProjectQuery(dataUpdte, ref parameter);
                    }

                    SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, sqlExecuteString, parameter);
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

        public DataTable GetDataById(string id)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesProjectQuery.GetDataById(id)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteById(string projectId)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesProjectQuery.GetDeleteById(projectId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
