using FestivalCommon;
using System;
using System.Data;
using System.Data.SqlClient;

namespace FestivalBusiness
{
    public class VideoCodeLockBusiness : CommonBusiness
    {
        public DataTable GetVideoCodeLockAll()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, VideoCodeLockQuery.GetVideoCodeLockQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDataCombox()
        {
            try
            {
                return CommonComboxData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable CommonComboxData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");
            dt.Rows.Add(0, Constants.CONDITION_VALUE_BLANK);
            dt.Rows.Add(1, Constants.CONDITION_VALUE_NOT_CHANGE);
            return dt;
        }

        public void Delete(string videoLockId)
        {
            try
            {
                Parameters paramters = new Parameters();

                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, VideoCodeLockQuery.GetDeleteVideoCodeLockQuery(videoLockId, ref paramters), paramters);
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

                dataUpdte.Columns.Add("VideoCode", typeof(string));
                dataUpdte.Columns.Add("MaterialID");
                dataUpdte.Columns.Add("Contents");
                dataUpdte.Columns.Add("MaterialEndDate");
                dataUpdte.Columns.Add("BackgroundVideoLock");
                dataUpdte.Columns.Add("OldVideoCode");

                sqlTransac = connection.BeginTransaction();
                string sqlExecuteString = string.Empty;
                string videoLockId = string.Empty;
                Parameters paramters;
                object dateTime = DBNull.Value;

                foreach (DataRow row in dtSave.Rows)
                {
                    dataUpdte.Rows.Clear();
                    sqlExecuteString = string.Empty;
                    dateTime = DBNull.Value;
                    if (row["MaterialEndDate"] != DBNull.Value)
                        dateTime = Convert.ToDateTime(row["MaterialEndDate"]).ToString("yyyyMMdd");

                    dataUpdte.Rows.Add(row["VideoCode"], row["MaterialID"], row["Contents"], dateTime, row["BackgroundVideoLock"], row["OldVideoCode"]);

                    videoLockId = row["OldVideoCode"] == null ? string.Empty : row["OldVideoCode"].ToString();

                    paramters = new Parameters();

                    if (string.IsNullOrWhiteSpace(videoLockId))
                    {
                        sqlExecuteString = VideoCodeLockQuery.GetInsertQuery(dataUpdte, ref paramters);
                    }
                    else
                    {
                        sqlExecuteString = VideoCodeLockQuery.GetUpdateQuery(dataUpdte, ref paramters);
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


        public void ImportData(DataTable dtImport)
        {
            try
            {
                //Truncate table tmp
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, VideoCodeLockQuery.GetTruncateTmpQuery());

                dtImport.TableName = string.Format("WiiTmp.dbo.[Wrk_VideoCodeLock_{0}]", Environment.MachineName.Replace("-", "_"));
                SqlHelpers.ExecuteBulkInsert(connectionString, dtImport);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadDataImport()
        {
            try
            {
                //Truncate table tmp
                DataTable dt = new DataTable();

                dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, VideoCodeLockQuery.GetDataImportQuery()).Tables[0];

                //Truncate table tmp
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, VideoCodeLockQuery.GetTruncateTmpQuery());

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetVideoCodeLockById(string videoCode)
        {
            try
            {
                //Truncate table tmp
                DataTable dt = new DataTable();
                Parameters paramters = new Parameters();

                dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, VideoCodeLockQuery.GetVideoCodeLockByVideoCodeQuery(videoCode, ref paramters), paramters).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetVideoCodeLocked()
        {
            try
            {
                //Truncate table tmp
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, VideoCodeLockQuery.GetVideoCodeLockedQuery()).Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
