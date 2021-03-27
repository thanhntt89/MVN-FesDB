using System;
using System.Data;
using System.Data.SqlClient;

namespace FestivalBusiness
{
    public class ImportRankingBusiness: BusinessBase
    {       
        /// <summary>
        /// Truncate table total ranking
        /// </summary>
        public void TruncateTablTotalRanking()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, "truncate table Wii.dbo.tbl_FesTotal_Ranking");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert bukl data into database
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="tableName">Table in database</param>
        public void BulkInsert(DataTable dataTable, string tableName)
        {
            try
            {
                using (SqlConnection connection = GetConnection.GetSqlConnection())
                {
                    // make sure to enable triggers
                    // more on triggers in next post
                    SqlBulkCopy bulkCopy =
                        new SqlBulkCopy
                        (
                        connection,
                        SqlBulkCopyOptions.TableLock |
                        SqlBulkCopyOptions.FireTriggers |
                        SqlBulkCopyOptions.UseInternalTransaction,
                        null
                        );

                    // Set buk timeout
                    bulkCopy.BulkCopyTimeout = SqlHelpers.CommandTimeOut;

                    // set the destination table name
                    bulkCopy.BulkCopyTimeout = SqlHelpers.CommandTimeOut;
                    bulkCopy.DestinationTableName = tableName;
                    connection.Open();

                    // write the data in the "dataTable"
                    bulkCopy.WriteToServer(dataTable);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// CreateTotalRankingTable
        /// </summary>
        public void CreateTotalRankingTable()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, "exec usp_CreateFesTotalRankingTable");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// UpdateRankingAggregationPeriod
        /// </summary>
        /// <param name="dateTimeFrom">dateTimeFrom</param>
        /// <param name="dateTimeTo">dateTimeTo</param>
        public void UpdateRankingAggregationPeriod(string dateTimeFrom, string dateTimeTo)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, System.Data.CommandType.Text,
                    string.Format("truncate table Wii.dbo.[tbl_Fesランク集計期間]; INSERT INTO dbo.[tbl_Fesランク集計期間] ([集計開始日], [集計終了日]) VALUES ('{0}', '{1}')", dateTimeFrom, dateTimeTo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// TruncateKaraokeYearRanking
        /// </summary>
        public void TruncateKaraokeYearRanking()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, System.Data.CommandType.Text, "truncate table Wii.dbo.tbl_Fes_Karaoke_Year_Ranking");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
