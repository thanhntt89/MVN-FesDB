using System;
using System.Data;
using System.Data.SqlClient;

namespace FestivalBusiness
{
    public class FesSongWithDiscImportBusiness : BusinessBase
    {
        private FesSongWithDiscBusiness fesSongWithDiscBusiness = new FesSongWithDiscBusiness();

        public void TruncateFesDiscAllocationTable()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, System.Data.CommandType.Text, FesSongWithDiscImportQuery.GetTruncateFesDiscAllocationTableQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BulkImportFesDisc(string serverFile)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, System.Data.CommandType.Text, FesSongWithDiscImportQuery.GetBulkInsertFesDiscAllocationTableQuery(serverFile));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CheckDuplicateSongSelected()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, System.Data.CommandType.Text, FesSongWithDiscImportQuery.GetCheckDuplicateSongSelectionQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CheckSongSelectedUpdate()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, System.Data.CommandType.Text, FesSongWithDiscImportQuery.GetCheckSongSelectionUpdateQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecuteImportCheck(int verSion, ref string message)
        {
            try
            {
                connection = new SqlConnection(GetConnection.GetWiiSqlConnectionString());
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                sqlTransac = connection.BeginTransaction();

                // FesDISC収録管理論理削除              
                SqlHelpers.ExecuteNonQuery(sqlTransac, System.Data.CommandType.Text, FesSongWithDiscImportQuery.GetUpdateFesDiscRecordingManagementQuery(verSion));

                // FesDISC収録管理追加              
                SqlHelpers.ExecuteNonQuery(sqlTransac, System.Data.CommandType.Text, FesSongWithDiscImportQuery.GetInsertFesDiscRecordingManagementQuery(verSion));
                // FesDISC収録管理レコードチェック
                DataTable dtCheck = SqlHelpers.ExecuteDataset(sqlTransac, CommandType.Text, FesSongWithDiscImportQuery.GetCheckFesDiscCommitQuery(verSion)).Tables[0];

                if (dtCheck.Rows.Count == 0)
                {
                    sqlTransac.Commit();
                }
                else
                {
                    message = "他のユーザの操作により取込に失敗しました。\n 再度、取込なおしてください。";
                    sqlTransac.Rollback();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                sqlTransac.Rollback();
                connection.Close();
                throw ex;
            }
        }

        public void TruncateWorkTableTmp()
        {
            fesSongWithDiscBusiness.TruncateWorkTableTmp();
        }
    }
}
