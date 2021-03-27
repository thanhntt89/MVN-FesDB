using FestivalCommon;
using FestivalObjects;
using System;
using System.Data;
using System.Data.SqlClient;

namespace FestivalBusiness
{
    public class RecommendSongBusiness : BusinessBase
    {
        private CommonBusiness commonBusiness = new CommonBusiness();

        public void SaveWorkTable(DataTable updateDataFesRecommendSongTable)
        {
            if (updateDataFesRecommendSongTable == null || updateDataFesRecommendSongTable.Rows.Count == 0)
                return;
            updateDataFesRecommendSongTable.TableName = Constants.FEST_RECOMMEND_SONG_TABLE_DBTMP;

            // Save fescontent work
            commonBusiness.Save(RecommendSongQuery.GetCreateFesRecommendSongTmpQuery(Constants.FEST_RECOMMEND_SONG_TABLE_DBTMP), RecommendSongQuery.GetUpdateFesRecommendSongTmpQuery(Constants.FEST_RECOMMEND_SONG_TABLE_DBTMP), updateDataFesRecommendSongTable);
        }

        public void Save(DataTable updateDataWorkFesContentTable, int deleteCount, ref RecommendSongMessage recommendSongMessage, ref int updatedCount)
        {
            try
            {
                SaveWorkTable(updateDataWorkFesContentTable);

                SaveRecommendSong(true, ref recommendSongMessage, ref updatedCount, deleteCount);
                int lngUpdateCountKenkouSong = updatedCount;

                updatedCount = 0;
                SaveRecommendSong(false, ref recommendSongMessage, ref updatedCount, deleteCount);

                updatedCount += lngUpdateCountKenkouSong;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetFeSongSelectionRelatedInfo(string selectedId)
        {
            try
            {
                try
                {
                    return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, RecommendSongQuery.GetFeSongSelectionRelatedInfoQuery(selectedId)).Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SaveRecommendSong(bool isKenkouSong, ref RecommendSongMessage recommendSongMessage, ref int updatedCount, int deleteCount)
        {
            try
            {
                updatedCount = 0;
                bool isUpdate = false;
                bool blnIsCommit = true;
                bool isAddNew = false;

                string programId = string.Empty;
                string contentId = string.Empty;
                string displayOrder = string.Empty;

                DataTable dtWork = new DataTable();
                DataTable dtUpdateTable = new DataTable();
                DataTable dtPrecheck = new DataTable();
                DataTable dtDisplayOrderMutilCheck = new DataTable();
                // Save data
                connection = new SqlConnection(GetConnection.GetWiiSqlConnectionString());

                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                sqlTransac = connection.BeginTransaction();

                dtWork = GetDataWorkTmp(isKenkouSong);

                if (dtWork.Rows.Count > 0)
                {
                    isUpdate = true;

                    #region Get Precheck

                    dtPrecheck = GetPreCheck(isKenkouSong);

                    if (dtPrecheck.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtPrecheck.Rows)
                        {
                            if (isKenkouSong)
                            {
                                recommendSongMessage.IsNotDigiNoKenkouSong = true;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(recommendSongMessage.NotDigiNoRecommendSong))
                                {
                                    recommendSongMessage.NotDigiNoRecommendSong += ", ";
                                }
                                recommendSongMessage.NotDigiNoRecommendSong += row["プログラムID"].ToString();
                            }
                        }
                        blnIsCommit = false;
                        isUpdate = false;
                    }
                    #endregion

                    #region  表示順複数設定チェック
                    dtDisplayOrderMutilCheck = GetDisplayOrderMutipleCheck(isKenkouSong);
                    if (dtDisplayOrderMutilCheck.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtDisplayOrderMutilCheck.Rows)
                        {
                            if (isKenkouSong)
                            {
                                // 健康王国おすすめ曲管理
                                if (!string.IsNullOrEmpty(recommendSongMessage.DisplayOrderDuplicationRecordKenkouSong))
                                {
                                    recommendSongMessage.DisplayOrderDuplicationRecordKenkouSong += ",";
                                }
                                recommendSongMessage.DisplayOrderDuplicationRecordKenkouSong += row["表示順"].ToString();
                            }
                            // おすすめ曲管理
                            else
                            {
                                if (!string.IsNullOrEmpty(recommendSongMessage.DisplayOrderDuplicationRecordRecommendSong))
                                {
                                    recommendSongMessage.DisplayOrderDuplicationRecordRecommendSong += ",";
                                }
                                recommendSongMessage.DisplayOrderDuplicationRecordRecommendSong += "[" + row["プログラムID"].ToString() + ":" + row["表示順"].ToString() + "]";
                            }
                        }
                        blnIsCommit = false;
                        isUpdate = false;
                    }
                    #endregion

                    #region Update
                    if (isUpdate)
                    {
                        foreach (DataRow row in dtWork.Rows)
                        {

                            isAddNew = false;
                            displayOrder = row["表示順"].ToString();
                            contentId = row["デジドココンテンツID"].ToString();
                            programId = isKenkouSong ? string.Empty : row["プログラムID"].ToString();

                            // Update table: Fes健康王国おすすめ曲管理
                            dtUpdateTable = GetFesRecommendSongRegistableByStatus(isKenkouSong, programId, contentId, displayOrder);

                            // レコードが存在しなければ追加する Add new
                            if (dtUpdateTable.Rows.Count == 0)
                            {
                                dtUpdateTable.Rows.Add();

                                dtUpdateTable.Rows[0]["デジドココンテンツID"] = row["デジドココンテンツID"];
                                if (!isKenkouSong)
                                {
                                    dtUpdateTable.Rows[0]["プログラムID"] = row["プログラムID"];
                                }
                                isAddNew = true;
                            }

                            if (row.Field<object>("表示順") == DBNull.Value || row.Field<object>("表示順") == null || string.IsNullOrEmpty(row.Field<object>("表示順").ToString()))
                            {
                                if (!string.IsNullOrEmpty(recommendSongMessage.NotRequiredRecord))
                                {
                                    recommendSongMessage.NotRequiredRecord += ",";
                                }
                                recommendSongMessage.NotRequiredRecord += row.Field<object>("Wii(デジドコ)選曲番号").ToString();
                                blnIsCommit = false;
                            }

                            if (blnIsCommit)
                            {
                                // Update foreach column
                                foreach (DataColumn colUpdate in dtWork.Columns)
                                {
                                    if (colUpdate.ColumnName.Equals("デジドココンテンツID") || colUpdate.ColumnName.Equals("Wii(デジドコ)選曲番号"))
                                    {
                                        continue;
                                    }

                                    dtUpdateTable.Rows[0][colUpdate.ColumnName] = row[colUpdate];
                                }

                                // Update database
                                dtUpdateTable.Rows[0]["最終更新日時"] = DateTime.Now;
                                dtUpdateTable.Rows[0]["最終更新者"] = Environment.UserName;
                                dtUpdateTable.Rows[0]["最終更新PC名"] = Environment.MachineName.Replace("-", "");

                                if (isAddNew)
                                {
                                    InsertRecommendSonRegist(sqlTransac, dtUpdateTable, isKenkouSong);
                                }
                                else
                                {
                                    UpdateRecommendSonRegist(sqlTransac, dtUpdateTable, isKenkouSong);
                                }

                                updatedCount++;
                            }
                        }
                    }
                    #endregion

                }

                #region おすすめ曲管理 レコード削除 
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, RecommendSongQuery.GetDeleteRegisterRecommendSongTableQuery(isKenkouSong));

                if (blnIsCommit)
                {
                    sqlTransac.Commit();
                }
                else
                {
                    sqlTransac.Rollback();
                    updatedCount = 0;
                }
                #endregion

                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                sqlTransac = connection.BeginTransaction();

                if (blnIsCommit)
                {
                    // Update work
                    SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, RecommendSongQuery.GetUpdateFesRecommendWorkQuery(isKenkouSong));
                }

                if (blnIsCommit && deleteCount > 0)
                {
                    // ワークテーブルからも削除（本当はレコード削除でなく編集項目のみnullにしたほうが良い）
                    SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, RecommendSongQuery.GetDeleteFesRecommendWorkTableQuery(isKenkouSong));
                }
              
                sqlTransac.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                updatedCount = 0;
                sqlTransac.Rollback();
                connection.Close();
                throw ex;
            }
        }

        public string InsertNewRowWorkTable()
        {
            try
            {
                string id = string.Empty;
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, RecommendSongQuery.GetInsertNewRowRecommendSongWorkTableQuery());

                DataTable dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, RecommendSongQuery.GetMaxIdRecommendSongWorkTableQuery()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    id = dt.Rows[0][0].ToString();
                }

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertWorkTable(DataRow rowAdded)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, RecommendSongQuery.GetInsertRecommendSongWorkTableQuery(rowAdded));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertRecommendSonRegist(SqlTransaction sqlTran, DataTable dtUpdateTable, bool isKenkouSong)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTran, CommandType.Text, RecommendSongQuery.GetInsertRecommendSongRegist(dtUpdateTable, isKenkouSong));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateRecommendSonRegist(SqlTransaction sqlTran, DataTable dtUpdateTable, bool isKenkouSong)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTran, CommandType.Text, RecommendSongQuery.GetUpdateRecommendSongRegist(dtUpdateTable, isKenkouSong));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetSongSelectionNumber()
        {
            try
            {
                try
                {
                    return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, RecommendSongQuery.GetSongSelectionQuery()).Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetDisplayOrderMutipleCheck(bool isKenkouSong)
        {
            try
            {
                try
                {
                    return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, RecommendSongQuery.GetDisplayOrderMutipleCheckQuery(isKenkouSong)).Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetFesRecommendSongRegistableByStatus(bool isKenkouSong, string programId, string contentId, string displayOrder)
        {
            try
            {
                try
                {
                    return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, RecommendSongQuery.GetFesRecommendSongRegisTablelBySatusQuery(isKenkouSong, programId, contentId, displayOrder)).Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Register pre check
        /// </summary>
        /// <param name="isKenkouSong"></param>
        /// <returns></returns>
        public DataTable GetPreCheck(bool isKenkouSong)
        {
            try
            {
                try
                {
                    return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, RecommendSongQuery.GetRegistrationPreCheckQuery(isKenkouSong)).Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetDataWorkTmp(bool isKenkouSong)
        {
            try
            {
                try
                {
                    return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, RecommendSongQuery.GetFesRecommendSongWorkTmpQuery(isKenkouSong)).Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetPaidContentFlag()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");
            dt.Rows.Add(null, null);
            dt.Rows.Add(0, 0);
            dt.Rows.Add(1, 1);
            return dt;
        }

        public DataTable GetFeRecommendProgram()
        {
            try
            {
                try
                {
                    return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, RecommendSongQuery.GetFesRecommendProgramQuery()).Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetFeRecommendProgramById(string id)
        {
            try
            {
                try
                {
                    return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, RecommendSongQuery.GetFesRecommendProgramByIdQuery(id)).Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetRecommendSongWorkTmp(bool isReload)
        {
            try
            {
                try
                {
                    if (!isReload)
                    {
                        TruncateWorkTableTmp();
                        InsertRecommendSongTmp();
                    }
                    return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, RecommendSongQuery.GetRecommendSongTmpQuery()).Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void TruncateWorkTableTmp()
        {
            try
            {
                try
                {
                    SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, RecommendSongQuery.GetTruncateRecommendSongTmpQuery());
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetCancelFlag()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesContentQuery.GetFesCancelFlagQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetPaidInformationFlag()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");
            dt.Rows.Add(null, null);
            dt.Rows.Add(2, "2 | 無償");
            dt.Rows.Add(3, "3 | 有償");
            return dt;
        }

        private void InsertRecommendSongTmp()
        {
            try
            {
                try
                {
                    SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, RecommendSongQuery.GetInsertRecommendSongTmpQuery());
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
