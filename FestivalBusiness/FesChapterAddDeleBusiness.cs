using System;
using System.Data;
using FestivalObjects;
using System.Data.SqlClient;
using FestivalCommon;

namespace FestivalBusiness
{
    public class FesChapterAddDeleBusiness : BusinessBase
    {
        private CommonBusiness commonBusiness = new CommonBusiness();

        public DataTable LoadWorkTable()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesChapterAddDeleQuery.GetWorkTmpQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Save(DataTable dtUpdate, int deleteCount, ref FesChapterAddDeleteMessage message, ref int updatedCount)
        {
            try
            {
                SaveWorkTable(dtUpdate);

                // Table Register: "dbo.[Fesチャプター追加削除管理]"
                DataTable tbWorkUpdate = GetChapterUpdatedFromWorkTable();
                DataTable tbChapterUpdate = new DataTable();
                DataTable tbChapterCheck = new DataTable();

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
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    sqlTransac = connection.BeginTransaction();

                    isUpdate = true;
                    isAddNew = false;
                    isEdit = false;
                    isCommit = true;

                    id = row["ID"].ToString();
                    fesDiscId = row["FesDISCID"] == null ? string.Empty : row["FesDISCID"].ToString();
                    contentId = row["デジドココンテンツID"] == null ? string.Empty : row["デジドココンテンツID"].ToString();
                    deleteStatus = row["追加削除区分"] == null ? string.Empty : row["追加削除区分"].ToString();

                    tbChapterUpdate = GetChapterSourceById(id);

                    if (tbChapterUpdate.Rows.Count == 0)
                    {
                        tbChapterUpdate.Rows.Add();
                        isAddNew = true;
                    }

                    updateRow = tbChapterUpdate.Rows[0];

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
                            tbChapterCheck = GetChapterCheckAdd(id, contentId);

                            if (tbChapterCheck.Rows.Count > 0)
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
                            tbChapterCheck = GetChapterCheckDelete(id, fesDiscId, contentId);

                            if (tbChapterCheck.Rows.Count == 0)
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
                    }// Not allow edit
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
                                    if (!updateRow["デジドココンテンツID"].Equals(row["デジドココンテンツID"]))
                                    {
                                        UpdateChapterSetDeleteFlag(sqlTransac, id, updateRow["デジドココンテンツID"].ToString());
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
                            InsertChapterManagement(sqlTransac, tbChapterUpdate);
                        }
                        else
                        {
                            UpdateChapterManagement(sqlTransac, tbChapterUpdate);
                        }

                        if (isAddNew || isKeyUpdate || deleteStatus.Equals("1"))
                            // Update last
                            UpdateChapterLastDate(sqlTransac, id, contentId);

                        UpdateChapterWorkTable(sqlTransac, id);

                        sqlTransac.Commit();

                        updatedCount++;
                    }
                    else
                    {
                        sqlTransac.Rollback();
                    }
                }

                if (deleteCount > 0)
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    sqlTransac = connection.BeginTransaction();

                    DeleteChapterMangement(sqlTransac);

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

        private void UpdateChapterWorkTable(SqlTransaction sqlTransac, string id)
        {

            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesChapterAddDeleQuery.GetUpdateChapterWorkTableQuery(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateChapterLastDate(SqlTransaction sqlTransac, string id, string contentId)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesChapterAddDeleQuery.GetUpdateChapterLastDateQuery(id, contentId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetChapterCheckDelete(string id, string fesDiscId, string contentId)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesChapterAddDeleQuery.GetChapterCheckDeleteQuery(id, fesDiscId, contentId)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DeleteChapterMangement(SqlTransaction sqlTransac)
        {
            try
            {
                // Update flag 削除フラグ
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesChapterAddDeleQuery.GetUpdateFlagChapterManagementQuery());
                // Delete table Video 削除可能レコードのみ削除   初期搭載分以外の現在搭載データ
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesChapterAddDeleQuery.GetDeleteChapterMangementQuery());
                // Delete table video worktable ワークテーブルの削除フラグ更新(1→0)
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesChapterAddDeleQuery.GetUpdateChapterWorkTableQuery());
                // Update table video status 削除フラグ更新(2→1)
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesChapterAddDeleQuery.GetUpdateChapterTableQuery());
                // Delete in work table
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesChapterAddDeleQuery.GetDeleteChapterWorkTableQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateChapterManagement(SqlTransaction sqlTransac, DataTable tbChapterUpdate)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesChapterAddDeleQuery.GetUpdateChapterManagementQuery(tbChapterUpdate));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertChapterManagement(SqlTransaction sqlTransac, DataTable tbChapterUpdate)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesChapterAddDeleQuery.GetInsertChapterManagementQuery(tbChapterUpdate));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateChapterSetDeleteFlag(SqlTransaction sqlTransac, string id, string contentId)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesChapterAddDeleQuery.GetUpdateChapterSetDeleteFlagQuery(id, contentId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetChapterCheckAdd(string id, string contentId)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesChapterAddDeleQuery.GetChapterCheckAddQuery(id, contentId)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetChapterSourceById(string id)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesChapterAddDeleQuery.GetChapterDataByIdQuery(id)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetChapterUpdatedFromWorkTable()
        {
            try
            {
                DataTable dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesChapterAddDeleQuery.GetChapterUpdatedFromWorkTableQuery()).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetFesSongRelatedInfoById(string songNumber)
        {
            try
            {
                DataTable dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesChapterAddDeleQuery.GetFesSongRelatedInfoByIdQuery(songNumber)).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SaveWorkTable(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
                return;
            dataTable.TableName = Constants.FES_CHAPTER_MANAGEMENT_WORK_TABLE_DBTMP;

            // Save fescontent work
            commonBusiness.Save(FesChapterAddDeleQuery.GetCreateWorkTableQuery(dataTable.TableName), FesChapterAddDeleQuery.GetUpdateWorkTmpQuery(dataTable.TableName), dataTable);
        }

        public DataTable InsertNewRowChapterManagementWorkTable()
        {
            try
            {
                string id = string.Empty;
                bool isDataSourceEmpty = false;
                DataTable dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesChapterAddDeleQuery.GetSelectLastChapterRecordQuery()).Tables[0];
                if (dt.Rows.Count == 0)
                    isDataSourceEmpty = true;

                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesChapterAddDeleQuery.GetInsertNewRowChapterManagementWorkTableQuery(isDataSourceEmpty));
                dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesChapterAddDeleQuery.GetSelectLastChapterRecordQuery()).Tables[0];
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

        public void TruncateWorkTable()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesChapterAddDeleQuery.GetTruncateWorkTableQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
