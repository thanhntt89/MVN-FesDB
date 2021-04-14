using System;
using System.Data;
using System.Data.SqlClient;

namespace FestivalBusiness
{
    public class FesFunctionBusiness : BusinessBase
    {
        private CommonBusiness commonBusiness = new CommonBusiness();

        public DataTable GetFunctionAll()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesFunctionQuery.GetFunctionAllQuery()).Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Save(DataTable dtSave, ref int updateCount)
        {
            try
            {
                DataTable dtInsert = new DataTable();
                dtInsert.Columns.Add("プロジェクトID");
                dtInsert.Columns.Add("機能ID");
                dtInsert.Columns.Add("機能名");
                dtInsert.Columns.Add("OldプロジェクトID");
                dtInsert.Columns.Add("Old機能ID");

                connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                sqlTransac = connection.BeginTransaction();
                string query = string.Empty;
                string functionId = string.Empty;

                foreach (DataRow row in dtSave.Rows)
                {
                    dtInsert.Rows.Clear();
                    dtInsert.Rows.Add(row["プロジェクトID"], row["機能ID"], row["機能名"], row["OldプロジェクトID"], row["Old機能ID"]);
                    query = string.Empty;
                    functionId = row["OldプロジェクトID"] == null ? string.Empty : row["OldプロジェクトID"].ToString();

                    if (string.IsNullOrWhiteSpace(functionId))
                    {
                        query = FesFunctionQuery.GetInsertQuery(dtInsert);
                    }
                    else
                    {
                        query = FesFunctionQuery.GetUpdateQuery(dtInsert);

                    }

                    SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, query);
                    updateCount++;
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

        public DataTable GetProjectAll()
        {
            try
            {
                DataTable dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesProjectQuery.GetProjectAllQuery()).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        row["機能名"] = string.Format("{0} | {1}", row["プロジェクトID"], row["機能名"]);
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        public DataTable GetDataById(string projectId, string functionId)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesFunctionQuery.GetDataByIdQuery(projectId, functionId)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteById(string projectId, string functionId)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text,
                    FesFunctionQuery.DeleteByIdQuery(projectId, functionId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
