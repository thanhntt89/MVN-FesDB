using System;
using System.Data;
using System.Data.SqlClient;

namespace FestivalBusiness
{
    public class FesUserBusiness : BusinessBase
    {
        private FesAuthorityBusiness authorityBusiness = new FesAuthorityBusiness();
        public DataTable GetUsersAll()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesUserQuery.GetUsersAllQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAuthorityAll()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesUserQuery.GetAuthorityAllQuery()).Tables[0];
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
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesUserQuery.GetDeleteByIdQuery(userId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDataById(string userId)
        {
            try
            {
                Parameters parameters = new Parameters();

                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesUserQuery.GetDataByIdQuery(userId, ref parameters), parameters).Tables[0];
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
                // Save data
                connection = new SqlConnection(GetConnection.GetWiiSqlConnectionString());

                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DataTable dataUpdte = new DataTable();
                dataUpdte.Columns.Add("利用者ID");
                dataUpdte.Columns.Add("権限グループ");
                dataUpdte.Columns.Add("利用者名");
                dataUpdte.Columns.Add("Old利用者ID");

                sqlTransac = connection.BeginTransaction();
                string sqlExecuteString = string.Empty;
                string userId = string.Empty;
                Parameters paramters;

                foreach (DataRow row in dtSave.Rows)
                {
                    dataUpdte.Rows.Clear();
                    sqlExecuteString = string.Empty;
                    dataUpdte.Rows.Add(row["利用者ID"], row["権限グループ"], row["利用者名"], row["Old利用者ID"]);

                    userId = row["Old利用者ID"] == null ? string.Empty : row["Old利用者ID"].ToString();

                    paramters = new Parameters();

                    if (string.IsNullOrWhiteSpace(userId))
                    {
                        sqlExecuteString = FesUserQuery.GetInsertUserQuery(dataUpdte, ref paramters);
                    }
                    else
                    {
                        sqlExecuteString = FesUserQuery.GetUpdateUserQuery(dataUpdte, ref paramters);
                    }

                    SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, sqlExecuteString, paramters);
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
    }
}
