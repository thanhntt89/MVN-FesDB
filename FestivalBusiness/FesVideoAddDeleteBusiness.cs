using System;
using System.Collections.Generic;
using System.Data;
using FestivalObjects;
using FestivalCommon;
using System.Data.SqlClient;
using System.Linq;
using Festival.Common;

namespace FestivalBusiness
{
    public class FesVideoAddDeleteBusiness : BusinessBase
    {
        private CommonBusiness commonBusiness = new CommonBusiness();

        public DataTable LoadWorkTable()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesVideoAddDeleteQuery.GetWorkTmpQuery()).Tables[0];
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

        private void SaveWorkTable(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
                return;
            dataTable.TableName = Constants.FES_VIDEO_DISC_MANAGEMENT_WORK_TABLE_DBTMP;

            // Save fescontent work
            commonBusiness.Save(FesVideoAddDeleteQuery.GetCreateWorkTableQuery(dataTable.TableName), FesVideoAddDeleteQuery.GetUpdateWorkTmpQuery(dataTable.TableName), dataTable);
        }

        public void Save(DataTable dtUpdate, int deleteCount, ref FesVideoAddDeleteMessage message, ref int updatedCount)
        {
            try
            {
                // Save Worktable
                SaveWorkTable(dtUpdate);

                // Table Register: dbo.[Fes映像DISC追加削除管理]
                DataTable tbWorkUpdate = GetVideoUpdatedFromWorkTable();
                DataTable tbVideoUpdate = new DataTable();
                DataTable tbVideoCheck = new DataTable();

                bool isAddNew = false;
                bool isUpdate = false;
                bool isEdit = false;
                bool isCommit = true;
                bool isKeyUpdate = false;

                string id = string.Empty;
                string fesDiscId = string.Empty;
                string fileName = string.Empty;
                string adddeleteFlg = string.Empty;
                DataRow updateRow = null;

                connection = new SqlConnection(connectionString);

                foreach (DataRow row in tbWorkUpdate.Rows)
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    sqlTransac = connection.BeginTransaction();

                    isAddNew = false;
                    isUpdate = true;
                    updateRow = null;
                    isEdit = false;
                    isKeyUpdate = false;
                    isCommit = true;

                    id = row.Field<object>("ID").ToString();
                    fesDiscId = row.Field<object>("FesDISCID") == null ? string.Empty : row.Field<object>("FesDISCID").ToString();
                    fileName = row.Field<object>("背景ファイル名") == null ? string.Empty : row.Field<object>("背景ファイル名").ToString();
                    adddeleteFlg = row.Field<object>("追加削除区分") == null ? string.Empty : row.Field<object>("追加削除区分").ToString();

                    tbVideoUpdate = GetSourceVideoUpdateById(id);

                    // Add new
                    if (tbVideoUpdate.Rows.Count == 0)
                    {
                        tbVideoUpdate.Rows.Add();
                        isAddNew = true;
                    }

                    // Get row update/ add new
                    updateRow = tbVideoUpdate.Rows[0];

                    if (isAddNew)
                    {
                        updateRow["ID"] = row["ID"];
                        updateRow["削除フラグ"] = 0;
                        updateRow["未出力フラグ"] = 0;
                        isEdit = true;
                    }
                    else if (updateRow["削除フラグ"] != null && updateRow["削除フラグ"].ToString().Equals("0") &&
    updateRow["追加削除区分"] != null && updateRow["追加削除区分"].ToString().Equals("0") &&
    updateRow["未出力フラグ"] != null && updateRow["未出力フラグ"].ToString().Equals("0"))
                    {
                        isEdit = true;
                    }

                    // Allow edit
                    if (isEdit)
                    {
                        #region Edit 

                        // 必須項目チェック "追加削除区分", "背景ファイル名", "FesDISCID"
                        if (row["追加削除区分"] == null || string.IsNullOrWhiteSpace(row["追加削除区分"].ToString()) ||
                         row["背景ファイル名"] == null || string.IsNullOrWhiteSpace(row["背景ファイル名"].ToString()) ||
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
                        }//同名ファイルチェック(追加時)
                        else if (row["追加削除区分"] != null && row["追加削除区分"].ToString().Equals("0"))
                        {
                            tbVideoCheck = GetVideoCheck(id, fesDiscId, fileName);

                            if (tbVideoCheck.Rows.Count > 0)
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
                            tbVideoCheck = GetVideoCheckDelete(id, fesDiscId, fileName);

                            if (tbVideoCheck.Rows.Count != 1)
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
                        #endregion
                    }
                    // Not allow edit
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(message.NoUpdateRecord))
                        {
                            message.NoUpdateRecord += ",";
                        }
                        message.NoUpdateRecord += row["通番"].ToString();
                        isUpdate = false;
                    }

                    #region Commit and update       
                    if (isCommit && isUpdate)
                    {
                        foreach (DataColumn col in tbWorkUpdate.Columns)
                        {
                            if (col.ColumnName.Equals("ID"))
                                continue;

                            if (col.ColumnName.Equals("背景ファイル名"))
                            {
                                if (!isAddNew)
                                {
                                    if (!updateRow["背景ファイル名"].Equals(row["背景ファイル名"]) ||
                                        !updateRow["FesDISCID"].Equals(row["FesDISCID"]))
                                    {
                                        UpdateVideoSetDeleteFlag(sqlTransac, id, updateRow["FesDISCID"].ToString(), updateRow["背景ファイル名"].ToString());
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
                            InsertRegisterTable(sqlTransac, tbVideoUpdate);
                        }
                        else
                        {
                            UpdateRegisterTable(sqlTransac, tbVideoUpdate);
                        }

                        // Update total
                        if (isAddNew || adddeleteFlg.Equals("1") || isKeyUpdate)
                        {
                            UpdateVideoLastDate(sqlTransac, id, fesDiscId, fileName);
                        }

                        // Update work table is updated
                        UpdateVideoWorkTable(sqlTransac, id);

                        sqlTransac.Commit();

                        updatedCount++;
                    }
                    else
                    {
                        sqlTransac.Rollback();
                    }
                }// End foreach

                if (deleteCount > 0 && isCommit)
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    sqlTransac = connection.BeginTransaction();

                    DeleteVideoManagement(sqlTransac);
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

        private void UpdateVideoWorkTable(SqlTransaction sqlTransac, string id)
        {
            try
            {
                // Update flag 削除フラグ
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesVideoAddDeleteQuery.GetUpdateVideoWorkTableQuery(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetVideoCheckDelete(string id, string fesDiscId, string fileName)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesVideoAddDeleteQuery.GetVideoCheckDeleteQuery(id, fesDiscId, fileName)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateVideoLastDate(SqlTransaction sqlTransac, string id, string fesId, string fileName)
        {
            try
            {
                // Update flag 削除フラグ
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesVideoAddDeleteQuery.GetUpdateVideoLastDateQuery(id, fesId, fileName));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DeleteVideoManagement(SqlTransaction sqlTransac)
        {
            try
            {
                // Update flag 削除フラグ
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesVideoAddDeleteQuery.GetUpdateFlagVideoManagementQuery());
                // Delete table Video
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesVideoAddDeleteQuery.GetDeleteVideoManagementQuery());
                // Delete table video worktable
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesVideoAddDeleteQuery.GetUpdateVideoWorkTableQuery());
                // Update table video status
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesVideoAddDeleteQuery.GetUpdateVideoTableQuery());
                // Delete in work table
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesVideoAddDeleteQuery.GetDeleteVideoWorkTableQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateVideoSetDeleteFlag(SqlTransaction sqlTranc, string id, string fesId, string fileName)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTranc, CommandType.Text, FesVideoAddDeleteQuery.GetUpdateVideoSetDeleteFlagQuery(id, fesId, fileName));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetVideoCheck(string id, string fesId, string fileName)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesVideoAddDeleteQuery.GetVideoCheckQuery(id, fesId, fileName)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable InsertNewRowVideoManagementWorkTable()
        {
            try
            {
                string id = string.Empty;
                bool isDataSourceEmpty = false;
                DataTable dtWork = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesVideoAddDeleteQuery.GetSelectLastVideoRecordQuery()).Tables[0];
                if (dtWork.Rows.Count == 0)
                    isDataSourceEmpty = true;

                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesVideoAddDeleteQuery.GetInsertNewRowVideoManagementWorkTableQuery(isDataSourceEmpty));
                DataTable dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesVideoAddDeleteQuery.GetSelectLastVideoRecordQuery()).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateRegisterTable(SqlTransaction sqlTransac, DataTable tbRegister)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesVideoAddDeleteQuery.GetUpdateRegisterTableQuery(tbRegister));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertInputNumberToWorkTable(EnumInputNumberType inputNumberType, List<string> songNumberList)
        {
            try
            {
                TruncateVideoDiscManagementWorkTmp();
                commonBusiness.InsertInputNumerWorkTable(inputNumberType, songNumberList);

                string query = FesVideoAddDeleteQuery.GetInsertInputNumberToWorkTableQuery(inputNumberType);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ImportVideo(DataTable dtImport, ref int sucessCount, ref int failsCount, ref string errorMessage)
        {
            try
            {
                TruncateVideoDiscManagementWorkTmp();
                int index = 0;
                DataTable dtSource = new DataTable();

                DataTable dtAddNewVideoWorkTable = GetColumnsAddNewVideoWorkTable();
                // Save data
                connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                sqlTransac = connection.BeginTransaction();

                List<string> preAddIds = new List<string>();
                bool isStopImport = false;

                foreach (DataRow row in dtImport.Rows)
                {
                    index++;

                    // Blank data
                    if (row[0] == null || string.IsNullOrWhiteSpace(row[0].ToString()))
                    {
                        errorMessage += string.Format("{0}行目　背景ファイル名が未設定です。\n", index);
                        failsCount++;
                        continue;
                    }

                    //Get datasource by 背景ファイル名
                    dtSource = GetFesVideoSourceById(row[0].ToString());

                    // Exist data to add new
                    if (dtSource.Rows.Count == 0)
                    {
                        // Data not exist '背景ファイル名が見つからない
                        isStopImport = true;
                        errorMessage += string.Format("{0}行目　対応する背景ファイル名が見つかりません。背景ファイル名={1}\n", index, row[0]);
                        failsCount++;
                        continue;
                    }

                    dtAddNewVideoWorkTable.Rows.Clear();
                    dtAddNewVideoWorkTable.Rows.Add();
                    DataRow addRow = dtAddNewVideoWorkTable.Rows[0];
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
                        InsertNewRowVideoManagementWorkTable(sqlTransac, dtAddNewVideoWorkTable);
                        preAddIds.Add(addRow["ID"].ToString());
                        sucessCount++;
                    }
                    else
                    {
                        errorMessage += string.Format("{0}行目　背景ファイル名={1}\n", index, row[0].ToString());
                        failsCount++;
                    }
                }

                if (isStopImport)
                {
                    sucessCount = 0;
                    failsCount = 0;
                    sqlTransac.Rollback();
                }
                else
                {
                    sqlTransac.Commit();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                sucessCount = 0;
                failsCount = 0;
                sqlTransac.Rollback();
                connection.Close();
                throw ex;
            }
        }

        private void InsertNewRowVideoManagementWorkTable(SqlTransaction sqlTransac, DataTable dtAddNewVideoWorkTable)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesVideoAddDeleteQuery.GetInsertNewRowVideoManagementWorkTableQuery(dtAddNewVideoWorkTable));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetColumnsAddNewVideoWorkTable()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesVideoAddDeleteQuery.GetColumnsAddNewVideoWorkTableQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetFesVideoSourceById(string id)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesVideoAddDeleteQuery.GetFesVideoSourceByIdQuery(id)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertRegisterTable(SqlTransaction sqlTransac, DataTable tbRegister)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesVideoAddDeleteQuery.GetInsertRegisterTableQuery(tbRegister));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetSourceVideoUpdateById(string id)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesVideoAddDeleteQuery.GetGetRegisterDataByIdQuery(id)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetVideoUpdatedFromWorkTable()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesVideoAddDeleteQuery.GetIndividualVideoFISCManagementWorkUpdateDataQuery()).Tables[0];
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

        public void TruncateVideoDiscManagementWorkTmp()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesVideoAddDeleteQuery.GetTruncateVideoDiscManagementWorkTmpQuery());
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
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesVideoAddDeleteQuery.GetExecuteSearchVideoDiscManagementWorkTmpQuery(slqParameters));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
