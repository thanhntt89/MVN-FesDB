using System;
using System.Data;
using System.Collections.Generic;
using FestivalCommon;
using System.Linq;
using System.Data.SqlClient;
using System.IO;
using FestivalObjects;

namespace FestivalBusiness
{
    public class FesContentBusiness : BusinessBase
    {
        private CommonBusiness commonBusiness = new CommonBusiness();
        private FesVideoAssigmentBusiness fesVideoAssigmentBusiness = new FesVideoAssigmentBusiness();
        private VideoCodeLockBusiness videoCodeLockBusiness = new VideoCodeLockBusiness();

        public IList<string> GetFestaVideoLock()
        {          
            return commonBusiness.GetFestaVideoLock();
        }

        public DataTable GetVideoCodeLockedAll()
        {
            try
            {
                return videoCodeLockBusiness.GetVideoCodeLocked();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDataExportContentList(List<string> getDisplayedIdList)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesContentQuery.GetExportFesContentExportQuery(getDisplayedIdList)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDataExportContentSongList(List<string> getDisplayedIdList)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesContentQuery.GetExportContentSongListQuery(getDisplayedIdList)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDataWorkTableTmp()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesContentQuery.GetSelectFesContentSql()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveWorkTableTmp(DataTable updateDataWorkFesContentTable)
        {
            if (updateDataWorkFesContentTable == null || updateDataWorkFesContentTable.Rows.Count == 0)
                return;
            updateDataWorkFesContentTable.TableName = Constants.FES_CONSTENT_TABLE_DBTMP;

            // Save fescontent work
            commonBusiness.Save(FesContentQuery.GetCreateFestTmpQuery(Constants.FES_CONSTENT_TABLE_DBTMP), FesContentQuery.GetUpdateFestTmpQuery(Constants.FES_CONSTENT_TABLE_DBTMP), updateDataWorkFesContentTable);
        }

        public void Save(DataTable updateDataWorkFesContentTable, int deleteCount, ref int countSucess, ref FesContentMessage message)
        {
            try
            {
                // Valid_data
                //Removed display column コンテンツ種類 映像ロック対象 Old背景映像コード    
                updateDataWorkFesContentTable.Columns.Remove("コンテンツ種類");
                updateDataWorkFesContentTable.Columns.Remove("Old個別映像ロック");
                updateDataWorkFesContentTable.Columns.Remove("Old背景映像コード");
                updateDataWorkFesContentTable.Columns.Remove("映像ロック対象");

                SaveWorkTableTmp(updateDataWorkFesContentTable);

                // Save data
                connection = new SqlConnection(GetConnection.GetWiiSqlConnectionString());

                //Get data work fescontent
                DataTable dtFesContentWorkTable = GetDataFesContentWork();

                // Ignor column check
                List<string> ignorColumns = new List<string>()
                {
                    "デジドココンテンツID",
                    "楽曲名邦題",
                    "Wii(デジドコ)選曲番号",
                    "表示用Fesアレンジコード"
                };

                bool isUpdate = false;
                bool isAddNew = false;
                string contentId = string.Empty;

                string columnName = string.Empty;
                DataRow updateRow = null;

                //FesVideoCode              
                bool isAddNewVideoCode = false;
                DataTable dtFesVideoCode = new DataTable();

                DataTable dtFesServiceTable = null;

                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                sqlTransac = connection.BeginTransaction();

                foreach (DataRow row in dtFesContentWorkTable.Rows)
                {
                    //ContentId
                    contentId = row[0].ToString();

                    //FesVideoCode
                    dtFesVideoCode = fesVideoAssigmentBusiness.GetFesVideoCodeManagementById(contentId);
                    isAddNewVideoCode = false;

                    if (dtFesVideoCode.Rows.Count == 0)
                    {
                        isAddNewVideoCode = true;
                        dtFesVideoCode.Rows.Add();
                        //FesVideoCode
                        dtFesVideoCode.Rows[0]["デジドココンテンツID"] = row["デジドココンテンツID"];
                    }

                    isAddNew = false;
                    isUpdate = true;

                    dtFesServiceTable = GetDataFesServiceTable(contentId);
                    // Insert new
                    if (dtFesServiceTable.Rows.Count == 0)
                    {
                        dtFesServiceTable.Rows.Add();
                        dtFesServiceTable.Rows[0]["デジドココンテンツID"] = row["デジドココンテンツID"];

                        isAddNew = true;
                    }// Update

                    updateRow = dtFesServiceTable.Rows[0];

                    foreach (DataColumn col in dtFesContentWorkTable.Columns)
                    {
                        columnName = col.ColumnName;

                        var exist = ignorColumns.Where(r => r.Equals(columnName)).FirstOrDefault();
                        if (exist != null)
                        {
                            continue;
                        }

                        if (columnName.Equals("Fesアレンジコード"))
                        {
                            if (row[col] != null && string.IsNullOrWhiteSpace(row[col].ToString()))
                            {
                                updateRow["Fesアレンジコード"] = row["表示用Fesアレンジコード"];
                            }
                            else
                            {
                                updateRow["Fesアレンジコード"] = row[columnName];
                            }
                        }
                        else if (columnName.Equals("邦題優先フラグ"))
                        {
                            if (!string.IsNullOrWhiteSpace(row[col].ToString()) && row[col] == DBNull.Value)
                            {
                                if (!string.IsNullOrWhiteSpace(message.NoUpdateRecord))
                                {
                                    message.NoUpdateRecord += ",";
                                }
                                message.NoUpdateRecord += row["Wii(デジドコ)選曲番号"].ToString();
                                isUpdate = false;
                            }
                            else
                            {
                                updateRow[columnName] = row[columnName];
                            }
                        }
                        else if (columnName.Equals("検索表示可否フラグ"))
                        {
                            if (row[col] != DBNull.Value || row[col] == null || row[col] != null && string.IsNullOrWhiteSpace(row[col].ToString()))
                            {
                                updateRow[columnName] = 0;
                            }
                            else
                            {
                                updateRow[columnName] = row[columnName];
                            }
                        }
                        //FesVideoCode colum
                        else if (columnName.Equals("背景映像コード"))
                        {
                            dtFesVideoCode.Rows[0]["背景映像コード"] = row["背景映像コード"];
                        }
                        else
                        {
                            updateRow[col.ColumnName] = row[col.ColumnName];

                            //FesVideoCode colum 備考
                            //if (columnName.Equals("備考"))
                            //{
                            //    //dtFesVideoCode.Rows[0]["備考"] = row["備考"];
                            //}
                        }
                    }

                    if (isUpdate)
                    {
                        updateRow["最終更新日時"] = DateTime.Now;
                        updateRow["最終更新者"] = Environment.UserName;
                        updateRow["最終更新PC名"] = Environment.MachineName;

                        //FesVideoCode colum
                        dtFesVideoCode.Rows[0]["最終更新日時"] = updateRow["最終更新日時"];
                        dtFesVideoCode.Rows[0]["最終更新者"] = updateRow["最終更新者"];
                        dtFesVideoCode.Rows[0]["最終更新PC名"] = updateRow["最終更新PC名"];

                        if (isAddNew)
                        {
                            InsertFesContent(sqlTransac, dtFesServiceTable);
                        }
                        else
                        {
                            UpdateFesContent(sqlTransac, dtFesServiceTable);
                        }

                        // Update table work
                        UpdateFesContentWorkTable(sqlTransac, contentId);

                        //FesVideoCode
                        if (isAddNewVideoCode)
                        {
                            fesVideoAssigmentBusiness.InsertFesVideoManagement(sqlTransac, dtFesVideoCode);
                        }
                        else
                        {
                            fesVideoAssigmentBusiness.UpdateFesViedeosManagment(sqlTransac, dtFesVideoCode);
                        }

                        countSucess++;
                    }
                }

                if (deleteCount > 0)
                {
                    // Delete
                    DeleteFesManagement(sqlTransac);
                }

                if (dtFesContentWorkTable.Rows.Count == 0)
                    countSucess = deleteCount;

                sqlTransac.Commit();
                connection.Close();
            }

            catch (Exception ex)
            {
                countSucess = 0;
                sqlTransac.Rollback();
                connection.Close();
                throw ex;
            }
        }

        private void DeleteFesManagement(SqlTransaction sqlTransac)
        {
            try
            {
                // Delete registable
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesContentQuery.GetDeleteRegisteredFesContentQuery());

                //Delete Fes映像コード管理
                fesVideoAssigmentBusiness.DeleteFromFesContents(sqlTransac);

                // Delete work table
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesContentQuery.GetDeleteFesContentWorkQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateFesContentWorkTable(SqlTransaction sqlTransac, string contentId)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesContentQuery.GetUpdateFesContentWorkTableQuery(contentId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateFesContent(SqlTransaction sqlTransac, DataTable dtFesServiceTable)
        {
            try
            {
                Parameters paramters = new Parameters();

                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesContentQuery.GetUpdateFesContentsQuery(dtFesServiceTable, ref paramters), paramters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertFesContent(SqlTransaction sqlTransac, DataTable dtFesServiceTable)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesContentQuery.GetInserFestContentQuery(dtFesServiceTable));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecuteSearch(List<string> parameters)
        {
            // Truncate table fest content
            TruncateWorkTableTmp();

            var query = FesContentQuery.GetInsertTmpWithCoditionsQuery(parameters);
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertFestaVideoLock(IList<string> festaVideo)
        {
            try
            {
                commonBusiness.InsertFestaVideoLock(festaVideo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetIndividualVideoLockFlag()
        {
            try
            {
                return videoCodeLockBusiness.GetDataCombox();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Truncate tmp table
        /// </summary>
        /// <param name="tableName"></param>
        private void TruncateWorkTableTmp()
        {
            try
            {
                // Drop table            
                var truncate = string.Format("TRUNCATE TABLE WiiTmp.dbo.tbl_Wrk_Fesコンテンツ_{0}", Environment.MachineName).Replace("-", "_");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, truncate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetComboxTSVData(string values)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Column1");
            string[] data = values.Split(';');
            foreach (string item in data)
            {
                dt.Rows.Add(item);
            }
            return dt;
        }

        public void ImportFile(string pathFileLocal, string pathFileServer)
        {
            try
            {
                // Save data
                connection = new SqlConnection(GetConnection.GetWiiSqlConnectionString());

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                sqlTransac = connection.BeginTransaction();

                // ワークテーブルの内容削除
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesContentQuery.GetTruncateTableRecordAbleListQuery());

                // Copy file to server
                File.Copy(pathFileLocal, pathFileServer, true);

                // Call Bulk insert data 
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesContentQuery.GetBulkInsertFesContentRecordAbleQuery(pathFileServer));

                // Delete file copy
                File.Delete(pathFileServer);

                // Fesテーブル更新(録音可否フラグ = 1)
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesContentQuery.GetUpdateFesServicesQuery());

                // Fesテーブル更新(録音可否フラグ=null)
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesContentQuery.GetFesContentRecordAbilityFlagQuery());

                // Fesテーブル追加
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesContentQuery.GetFesContentInsertServiceTableQuery());

                // ワークテーブル更新
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesContentQuery.GetFesConentInsertWorkTableQuery());

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

        public void TruncateRecordAbleList()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesContentQuery.GetTruncateTableRecordAbleListQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TruncateFesConentTable()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesContentQuery.GetTruncateFesContentTableQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BulkInsertRecordAble(string filePath)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesContentQuery.GetBulkInsertFesContentRecordAbleQuery(filePath));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void UpdateRecordingPermissionFlag()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesContentQuery.GetUpdateFesServicesQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateRecordAbilityFlag()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesContentQuery.GetFesContentRecordAbilityFlagQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void InsertServiceTable()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesContentQuery.GetFesContentInsertServiceTableQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void InsertWorkTable()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesContentQuery.GetFesConentInsertWorkTableQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TruncateSelectionSongNumber()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesContentQuery.GetFesContentTruncateSelectionSongNumberQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertSongNumberList(List<string> SongNumberList)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, CommonSqlQuery.GetFesContentInsertSongNumberQuery(SongNumberList));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectKaraokeSongNumber(List<string> songNumberList)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesContentQuery.GetSelectFesContentSqlOutputWhere(songNumberList)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetFesCancelFlagQuery()
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

        public DataTable GetDataComboxDefaultValue2Items()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");
            dt.Rows.Add(null, null);
            dt.Rows.Add(0, 0);
            dt.Rows.Add(1, 1);
            return dt;
        }

        public DataTable GetDataComboxDefaultValue1Item()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");
            dt.Rows.Add(0, 0);
            dt.Rows.Add(1, 1);
            return dt;
        }


        public DataTable GetDataComboxSuportLevel()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesContentQuery.GetSelectSuportLevelQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetDataComboxFesJVVideoSegment()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesContentQuery.GetSelectFesJVVideoSegmentQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDataComboxSingerIdCorrection()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesContentQuery.GetSelectSingerIdCorrectionQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDataComboxSingerIdCorrectionById(string id)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesContentQuery.GetSelectSingerIdCorrectionByIdQuery(id)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDataFesContentWork()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesContentQuery.GetSaveUpdateDataFescontentQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDataFesServiceTable(string contentId)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesContentQuery.GetSaveUpdateDataFesServiceQuery(contentId)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
