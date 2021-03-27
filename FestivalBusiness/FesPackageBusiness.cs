using System;
using System.Data;
using System.Data.SqlClient;

namespace FestivalBusiness
{
    public class FesPackageBusiness : BusinessBase
    {
        public DataTable GetPackegeAll()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesPackageQuery.GetPackegeAllQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetPackegeByFesDiscId(string fesdiscId)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesPackageQuery.GetPackegeByFesDiscId(fesdiscId)).Tables[0];
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
                connection = new SqlConnection(GetConnection.GetWiiSqlConnectionString());

                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DataTable dataUpdte = new DataTable();
                dataUpdte.Columns.Add("パッケージID");
                dataUpdte.Columns.Add("FesDISCID");
                dataUpdte.Columns.Add("OldFesDISCID");

                sqlTransac = connection.BeginTransaction();
                string sqlExecuteString = string.Empty;
                string olUserId = string.Empty;

                foreach (DataRow row in dtSource.Rows)
                {
                    dataUpdte.Rows.Clear();
                    sqlExecuteString = string.Empty;
                    dataUpdte.Rows.Add(row["パッケージID"], row["FesDISCID"], row["OldFesDISCID"]);

                    olUserId = row["OldFesDISCID"] == null ? string.Empty : row["OldFesDISCID"].ToString();

                    if (string.IsNullOrWhiteSpace(olUserId))
                    {
                        sqlExecuteString = FesPackageQuery.GetSavePackegeQuery(dataUpdte);
                    }
                    else
                    {
                        sqlExecuteString = FesPackageQuery.GetUpdatePackegeQuery(dataUpdte);
                    }

                    SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, sqlExecuteString);
                    countUpdate++;
                }

                sqlTransac.Commit();
                connection.Close();                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteById(string deletedId)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesPackageQuery.GetDeleteByIdQuery(deletedId));
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
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesPackageQuery.GetDataByIdQuery(userId)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
