using System;
using System.Collections.Generic;
using System.Data;
using FestivalObjects;
using System.Data.SqlClient;
using System.Linq;
using Festival.Common;
using FestivalCommon;

namespace FestivalBusiness
{
    public class FesSongAddDeleteBusiness : BusinessBase
    {
        private CommonBusiness commonBusiness = new CommonBusiness();

        public void UpdateColumn(ColumnsCollection columns, bool isUpdate = false)
        {
            try
            {
                string tableName = Constants.TABLE_SONG_ADD_DELETE_NAME;
                commonBusiness.UpdateColumntable(tableName, columns, isUpdate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetRegisteredConditionData(string data)
        {
            return commonBusiness.GetComboxRegisteredConditions(data);
        }

        public DataTable GetFesSongRelatedInfoById(string songNumber)
        {
            try
            {
                DataTable dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesSongAddDeleteQuery.GetFesSongRelatedInfoByIdQuery(songNumber)).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAddtinalDeleteCategory()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Column1", typeof(int));
                dt.Columns.Add("Column2", typeof(string));
                dt.Rows.Add(null, string.Empty);
                dt.Rows.Add(0, "0");
                dt.Rows.Add(1, "1");

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecuteSearch(List<string> slqParameters)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesSongAddDeleteQuery.GetExecuteSearchQuery(slqParameters));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TruncateSongManagementWorkTmp()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesSongAddDeleteQuery.GetTruncateSongManagementWorkTmpQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadWorkTable()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesSongAddDeleteQuery.GetWorkTmpQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Save(DataTable dtUpdate, int deleteCount, ref FesSongAddDeleteMessage message, ref int updatedCount)
        {
            try
            {
                SaveWorkTable(dtUpdate);

                // Table Register: dbo.[FesDISC追加削除管理]
                DataTable tbWorkUpdate = GetSongUpdatedFromWorkTable();
                DataTable tbSongUpdate = new DataTable();
                DataTable tbSongCheck = new DataTable();
                string id = string.Empty;
                string fesDiscId = string.Empty;
                string contentId = string.Empty;
                string deleteStatus = string.Empty;

                bool isUpdate = false;
                bool isAddNew = false;
                bool isEdit = false;
                bool isCommit = false;
                bool isKeyUpdate = false;

                DataRow updateRow = null;

                connection = new SqlConnection(connectionString);

                foreach (DataRow row in tbWorkUpdate.Rows)
                {
                    #region Update data
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    sqlTransac = connection.BeginTransaction();

                    isUpdate = true;
                    isAddNew = false;
                    isEdit = false;
                    isCommit = true;
                    isKeyUpdate = false;

                    id = row["ID"].ToString();
                    fesDiscId = row["FesDISCID"] == null ? string.Empty : row["FesDISCID"].ToString();
                    contentId = row["デジドココンテンツID"] == null ? string.Empty : row["デジドココンテンツID"].ToString();
                    deleteStatus = row["追加削除区分"] == null ? string.Empty : row["追加削除区分"].ToString();

                    tbSongUpdate = GetSongSourceById(id);

                    if (tbSongUpdate.Rows.Count == 0)
                    {
                        tbSongUpdate.Rows.Add();
                        isAddNew = true;
                    }

                    updateRow = tbSongUpdate.Rows[0];

                    if (isAddNew)
                    {
                        updateRow["ID"] = row["ID"];
                        updateRow["削除フラグ"] = 0;
                        updateRow["未出力フラグ"] = 0;
                        updateRow["追加削除区分"] = 0;
                        isEdit = true;
                    }
                    else if (updateRow["削除フラグ"] != null && updateRow["削除フラグ"].ToString().Equals("0") &&
   updateRow["追加削除区分"] != null && updateRow["追加削除区分"].ToString().Equals("0") &&
   updateRow["未出力フラグ"] != null && updateRow["未出力フラグ"].ToString().Equals("0"))
                    {
                        isEdit = true;
                    }

                    #region Edit
                    if (isEdit)
                    {
                        if (row["Wiiデジドコ選曲番号"] == null || string.IsNullOrWhiteSpace(row["Wiiデジドコ選曲番号"].ToString()) ||
                         row["追加削除区分"] == null || string.IsNullOrWhiteSpace(row["追加削除区分"].ToString()) ||
                         row["FesDISCID"] == null || string.IsNullOrWhiteSpace(row["FesDISCID"].ToString())
                         )
                        {
                            if (!string.IsNullOrWhiteSpace(message.NotRequiredRecord))
                            {
                                message.NotRequiredRecord += ",";
                            }
                            message.NotRequiredRecord += row["通番"].ToString();
                            isUpdate = false;
                            isCommit = false;
                        }
                        else if (row["追加削除区分"] != null && row["追加削除区分"].ToString().Equals("0"))
                        {
                            tbSongCheck = GetSongCheck(id, fesDiscId, contentId);

                            if (tbSongCheck.Rows.Count > 0)
                            {
                                if (!string.IsNullOrWhiteSpace(message.NotFileNameRecord))
                                {
                                    message.NotFileNameRecord += ",";
                                }
                                message.NotFileNameRecord += row["通番"].ToString();
                                isUpdate = false;
                                isCommit = false;
                            }
                        }
                        else if (row["追加削除区分"] != null && row["追加削除区分"].ToString().Equals("1"))
                        {
                            tbSongCheck = GetSongCheck(id, fesDiscId, contentId);

                            if (tbSongCheck.Rows.Count == 0)
                            {
                                if (!string.IsNullOrWhiteSpace(message.NotDelRecord))
                                {
                                    message.NotDelRecord += ",";
                                }
                                message.NotDelRecord += row["通番"].ToString();
                                isUpdate = false;
                                isCommit = false;
                            }
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(message.NoUpdateRecord))
                        {
                            message.NoUpdateRecord += ",";
                        }
                        message.NoUpdateRecord += row["通番"].ToString();
                        isUpdate = false;
                    }

                    #endregion

                    #region Update
                    if (isCommit && isUpdate)
                    {
                        foreach (DataColumn col in tbWorkUpdate.Columns)
                        {
                            if (col.ColumnName.Equals("ID") || col.ColumnName.Equals("Wiiデジドコ選曲番号"))
                                continue;

                            if (col.ColumnName.Equals("デジドココンテンツID"))
                            {
                                if (!isAddNew)
                                {
                                    if (!updateRow["デジドココンテンツID"].Equals(row["デジドココンテンツID"]) ||
                                        !updateRow["FesDISCID"].Equals(row["FesDISCID"]))
                                    {
                                        UpdateSongSetDeleteFlag(sqlTransac, id, updateRow["FesDISCID"].ToString(), updateRow["デジドココンテンツID"].ToString());
                                        isKeyUpdate = true;
                                    }
                                }

                                updateRow[col.ColumnName] = row[col];
                            }
                            else
                            {
                                updateRow[col.ColumnName] = row[col];
                            }
                        }
                    }
                    #endregion

                    updateRow["最終更新日時"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    updateRow["最終更新者"] = Environment.UserName;
                    updateRow["最終更新PC名"] = Environment.MachineName.Replace("-", "");
                    if (isUpdate && isCommit)
                    {
                        if (isAddNew)
                        {
                            InsertSongManagement(sqlTransac, tbSongUpdate);
                        }
                        else
                        {
                            UpdateSongManagement(sqlTransac, tbSongUpdate);
                        }

                        if (isAddNew || deleteStatus.Equals("1") || isKeyUpdate)
                            UpdateSongLastDate(sqlTransac, id, contentId, fesDiscId);

                        // Update reset field 更新日時 work table
                        UpdateSongTableWork(sqlTransac, id);

                        sqlTransac.Commit();

                        updatedCount++;
                    }
                    else
                    {
                        sqlTransac.Rollback();
                    }

                    #endregion
                }

                if (deleteCount > 0)
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    sqlTransac = connection.BeginTransaction();

                    DeleteSongMangement(sqlTransac);

                    sqlTransac.Commit();
                }

                if (tbWorkUpdate.Rows.Count == 0)
                    updatedCount = deleteCount;

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

        private void UpdateSongTableWork(SqlTransaction sqlTransac, string id)
        {
            try
            {
                // Update flag 削除フラグ
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesSongAddDeleteQuery.GetUpdateSongTableWorkQuery(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateSongLastDate(SqlTransaction sqlTransac, string id, string contentId, string fesDiscId)
        {
            try
            {
                // Update flag 削除フラグ
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesSongAddDeleteQuery.GetUpdateSongLastDateQuery(id, contentId, fesDiscId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DeleteSongMangement(SqlTransaction sqlTransac)
        {
            try
            {
                // Update flag 削除フラグ
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesSongAddDeleteQuery.GetUpdateFlagSongManagementQuery());
                // Delete table Video
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesSongAddDeleteQuery.GetDeleteSongMangementQuery());
                // Update status work table 
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesSongAddDeleteQuery.GetUpdateSongWorkTableQuery());
                // Update table video status
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesSongAddDeleteQuery.GetUpdateSongTableQuery());
                // Delete in work table
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesSongAddDeleteQuery.GetDeleteSongWorkTableQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateSongManagement(SqlTransaction sqlTransac, DataTable tbSongUpdate)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesSongAddDeleteQuery.GetUpdateSongManagementQuery(tbSongUpdate));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertSongManagement(SqlTransaction sqlTransac, DataTable tbSongUpdate)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesSongAddDeleteQuery.GetInsertSongManagementQuery(tbSongUpdate));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateSongSetDeleteFlag(SqlTransaction sqlTransac, string id, string fesDiscId, string contentId)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesSongAddDeleteQuery.GetUpdateSongSetDeleteFlagQuery(id, fesDiscId, contentId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetSongCheck(string id, string fesDiscId, string contentId)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesSongAddDeleteQuery.GetSongCheckQuery(id, fesDiscId, contentId)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetSongSourceById(string id)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesSongAddDeleteQuery.GetSongDataByIdQuery(id)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetSongUpdatedFromWorkTable()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesSongAddDeleteQuery.GetSongUpdateFromWorkTableQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DeleteFesSong(string id, string fesId, string fileName)
        {

        }

        private void SaveWorkTable(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
                return;
            dataTable.TableName = Constants.FES_SONG_DISC_MANAGEMENT_WORK_TABLE_DBTMP;

            // Save fescontent work
            commonBusiness.Save(FesSongAddDeleteQuery.GetCreateWorkTableQuery(dataTable.TableName), FesSongAddDeleteQuery.GetUpdateWorkTmpQuery(dataTable.TableName), dataTable);
        }

        public DataTable GetAddtionalDeletionCategory()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Column1", typeof(int));
                dt.Columns.Add("Column2", typeof(string));
                dt.Rows.Add(0, "0 | 追加");
                dt.Rows.Add(1, "1 | 削除");

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetPaidInfoFlag()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Column1", typeof(int));
                dt.Columns.Add("Column2", typeof(string));
                dt.Rows.Add(null, string.Empty);
                dt.Rows.Add(2, "2 | 無償");
                dt.Rows.Add(3, "3 | 有償");

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable InsertNewRowSongManagementWorkTable()
        {
            try
            {
                string id = string.Empty;
                bool isDataSourceEmpty = false;
                DataTable dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesSongAddDeleteQuery.GetSelectLastSongRecordQuery()).Tables[0];
                if (dt.Rows.Count == 0)
                    isDataSourceEmpty = true;

                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesSongAddDeleteQuery.GetInsertNewRowSongManagementWorkTableQuery(isDataSourceEmpty));
                dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesSongAddDeleteQuery.GetSelectLastSongRecordQuery()).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ImportSong(DataTable dtImport, ref int sucessCount, ref int failsCount, ref string errorMessage)
        {
            try
            {
                TruncateSongManagementWorkTmp();
                int index = 0;
                DataTable dtSource = new DataTable();

                DataTable dtAddNewSongWorkTable = GetColumnsAddNewSongWorkTable();
                // Save data
                connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                sqlTransac = connection.BeginTransaction();
                List<string> preAddIds = new List<string>();

                foreach (DataRow row in dtImport.Rows)
                {
                    // Blank data
                    if (row[0] == null || string.IsNullOrWhiteSpace(row[0].ToString()))
                    {
                        errorMessage += string.Format("{0}行目　デジドコNoが未設定です。\n", index);
                        failsCount++;
                    }
                    // Not blank
                    else if (!string.IsNullOrWhiteSpace(row[0].ToString()))
                    {
                        //Get datasource by 背景ファイル名
                        dtSource = GetFesSongSourceById(row[0].ToString());
                        // Exist data to add new
                        if (dtSource.Rows.Count > 0)
                        {
                            dtAddNewSongWorkTable.Rows.Clear();
                            dtAddNewSongWorkTable.Rows.Add();
                            DataRow addRow = dtAddNewSongWorkTable.Rows[0];
                            addRow["選択"] = 0;
                            addRow["削除"] = 0;
                            addRow["更新日時"] = DateTime.Now.ToString("yyyy/MM/dd");

                            foreach (DataColumn col in dtSource.Columns)
                            {
                                addRow[col.ColumnName] = dtSource.Rows[0][col];
                            }

                            if (row[1] == null || string.IsNullOrWhiteSpace(row[1].ToString()))
                                addRow["データサイズ"] = DBNull.Value;
                            else
                                addRow["データサイズ"] = row[1];

                            var existId = preAddIds.Where(r => r.Equals(addRow["ID"].ToString())).FirstOrDefault();
                            if (existId == null)
                            {
                                // Insert new to work table
                                InsertNewRowSongWorkTable(sqlTransac, dtAddNewSongWorkTable);
                                preAddIds.Add(addRow["ID"].ToString());
                                sucessCount++;
                            }
                            else
                            {
                                errorMessage += string.Format("{0}行目　デジドコNo={1}\n", index, row[0].ToString());
                                failsCount++;
                            }
                        }
                        // Data not exist '背景ファイル名が見つからない
                        else
                        {
                            errorMessage += string.Format("{0}行目　対応するデジドコNoが見つかりません。デジドコNo={1}\n", index, row[0]);
                            failsCount++;
                        }
                    }
                    index++;
                }
                sqlTransac.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                failsCount = 0;
                sqlTransac.Rollback();
                connection.Close();
                throw ex;
            }
        }

        public void InsertInputNumberToWorkTable(EnumInputTypeName inputType, EnumInputNumberType inputNumberType, List<string> songNumberList)
        {
            try
            {
                TruncateSongManagementWorkTmp();
                commonBusiness.InsertInputNumerWorkTable(inputNumberType, songNumberList);

                string query = FesSongAddDeleteQuery.GetInsertInputNumberToWorkTableQuery(inputType, inputNumberType);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertNewRowSongWorkTable(SqlTransaction sqlTransac, DataTable dtAddNewSongWorkTable)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesSongAddDeleteQuery.GetInsertNewRowSongWorkTableQuery(dtAddNewSongWorkTable));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetFesSongSourceById(string id)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesSongAddDeleteQuery.GetFesSongSourceByIdQuery(id)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetColumnsAddNewSongWorkTable()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesSongAddDeleteQuery.GetColumnsAddNewSongWorkTableQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
