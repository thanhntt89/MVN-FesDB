using System;
using System.Data;
using System.Data.SqlClient;

namespace FestivalBusiness
{
    public class FesAuthGroupBusiness : BusinessBase
    {

        private CommonBusiness commonBusiness = new CommonBusiness();

        public void Save(DataTable dtSource, ref int countUpdate)
        {
            try
            {
                // Save data
                connection = new SqlConnection(GetConnection.GetWiiSqlConnectionString());

                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DataTable dataUpdte = new DataTable();
                dataUpdte.Columns.Add("権限グループ");
                dataUpdte.Columns.Add("権限名");
                dataUpdte.Columns.Add("Old権限グループ");

                sqlTransac = connection.BeginTransaction();
                string sqlExecuteString = string.Empty;
                string oldId = string.Empty;
                Parameters parmeters;

                foreach (DataRow row in dtSource.Rows)
                {
                    dataUpdte.Rows.Clear();
                    sqlExecuteString = string.Empty;
                    dataUpdte.Rows.Add(row["権限グループ"], row["権限名"], row["Old権限グループ"]);

                    oldId = row["Old権限グループ"] == null ? string.Empty : row["Old権限グループ"].ToString();

                    parmeters = new Parameters();

                    if (string.IsNullOrWhiteSpace(oldId))
                    {
                        sqlExecuteString = FesAuthGroupQuery.GetInsertQuery(dataUpdte, ref parmeters);
                    }
                    else
                    {
                        sqlExecuteString = FesAuthGroupQuery.GetUpdateQuery(dataUpdte, ref parmeters);
                    }

                    SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, sqlExecuteString, parmeters);
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

        public DataTable GetGroupAuthorityAll()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesAuthGroupQuery.GetGroupAuthorityAllQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDataById(string authGroupId)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesAuthGroupQuery.GetDataByIdQuery(authGroupId)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DeleteById(string userId)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text,
                    FesAuthGroupQuery.GetDeleteByIdQuery(userId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
