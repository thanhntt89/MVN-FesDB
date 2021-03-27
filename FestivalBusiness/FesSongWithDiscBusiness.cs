using System;
using System.Collections.Generic;
using System.Data;
using FestivalObjects;
using FestivalCommon;
using FestivalUtilities;
using System.Data.SqlClient;

namespace FestivalBusiness
{
    public class FesSongWithDiscBusiness : BusinessBase
    {
        private CommonBusiness commonBusiness = new CommonBusiness();

        public DataTable GetFesSongWithDiscWorkData()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesSongWithDiscQuery.GetFesSongWithDiscWorkDataQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetUseAgeFlagData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");
            dt.Rows.Add(null, null);
            dt.Rows.Add(0, 0);
            dt.Rows.Add(1, 1);
            return dt;
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

        private void SaveWorkTable(DataTable dtUpdateWorktable)
        {
            if (dtUpdateWorktable == null || dtUpdateWorktable.Rows.Count == 0)
                return;
            dtUpdateWorktable.TableName = Constants.FES_SONG_WITH_DISC_TABLE_DBTMP;

            // Save fescontent work
            commonBusiness.Save(FesSongWithDiscQuery.GetCreateFesSongWithDiscWorkTmpQuery(Constants.FES_SONG_WITH_DISC_TABLE_DBTMP), FesSongWithDiscQuery.GetUpdateFesSongWithDiscWorkTmpQuery(Constants.FES_SONG_WITH_DISC_TABLE_DBTMP), dtUpdateWorktable);
        }

        public void Save(DataTable dtUpdate, DisVersion version, int deleteCount, ref int countSuccess, ref FesVideoAssigmentObject messageVideoAssigment)
        {
            try
            {
                SaveWorkTable(dtUpdate);

                // Save registable strTable_Regist = "dbo.[FesDISC収録管理]"
                DataTable tbWorkUpdate = GetFesSongWithDiscWorkDataUpdate(version);
                DataTable dtRegist = new DataTable();
                bool isUpdated = false;
                bool isAddNew = false;
                string contentId = string.Empty;
                // Update data

                DataRow updateRow = null;

                connection = new SqlConnection(connectionString);

                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                sqlTransac = connection.BeginTransaction();

                foreach (DataRow row in tbWorkUpdate.Rows)
                {
                    contentId = row["デジドココンテンツID"].ToString();
                    dtRegist = GetRegistFesSongWithDis(version, contentId);

                    isAddNew = false;
                    isUpdated = true;

                    // Add new
                    if (dtRegist.Rows.Count == 0)
                    {
                        dtRegist.Rows.Add();
                        isAddNew = true;
                        isUpdated = false;
                    }

                    updateRow = dtRegist.Rows[0];

                    if (isAddNew)
                    {
                        updateRow["デジドココンテンツID"] = contentId;

                        // Wii(デジドコ)選曲番号は更新テーブルにカラムなし
                        // エラーメッセージ用項目
                        foreach (DataColumn col in tbWorkUpdate.Columns)
                        {
                            if (col.ColumnName.Equals("デジドココンテンツID") || col.ColumnName.Equals("Wii(デジドコ)選曲番号"))
                                continue;
                            updateRow[col.ColumnName] = row[col];
                        }

                        updateRow["バージョンNO"] = (int)version;
                        updateRow["削除フラグ"] = 0;
                    }

                    if (isUpdated)
                    {
                        //更新前FesDISCIDがNULL
                        if (updateRow["FesDISCID"] == null || string.IsNullOrWhiteSpace(updateRow["FesDISCID"].ToString()))
                        {
                            // Update new data from work table
                            foreach (DataColumn col in tbWorkUpdate.Columns)
                            {
                                if (col.ColumnName.Equals("デジドココンテンツID") || col.ColumnName.Equals("Wii(デジドコ)選曲番号"))
                                    continue;
                                updateRow[col.ColumnName] = row[col];
                            }
                        }
                        // FesDISCID以外更新
                        else if (Utils.IsNumeric(updateRow["FesDISCID"].ToString()) && row["FesDISCID"].Equals(updateRow["FesDISCID"]))
                        {
                            // Update new data from work table
                            foreach (DataColumn col in tbWorkUpdate.Columns)
                            {
                                if (col.ColumnName.Equals("デジドココンテンツID") || col.ColumnName.Equals("FesDISCID") || col.ColumnName.Equals("Wii(デジドコ)選曲番号"))
                                    continue;
                                updateRow[col.ColumnName] = row[col];
                            }
                        }
                        else
                        {
                            foreach (DataColumn col in tbWorkUpdate.Columns)
                            {
                                if (col.ColumnName.Equals("Wii(デジドコ)選曲番号"))
                                    continue;
                                updateRow[col.ColumnName] = row[col];
                            }

                            updateRow["バージョンNO"] = (int)version;
                            updateRow["削除フラグ"] = 0;
                        }
                    }

                    updateRow["最終更新日時"] = DateTime.Now;
                    updateRow["最終更新者"] = Environment.UserName;
                    updateRow["最終更新PC名"] = Environment.MachineName.Replace("-", "");

                    if (isAddNew)
                    {
                        InsertFesSongWidthDisc(sqlTransac, dtRegist);
                    }
                    else
                    {
                        UpdateFesSongWithDis(sqlTransac, dtRegist);
                    }

                    // Update DISC搭載曲管理
                    UpdateFesSongWithDis(sqlTransac, contentId, version);

                    // Update songwitdis work table
                    UpdateFesSongWorkTable(sqlTransac, contentId);

                    countSuccess++;
                }

                if (deleteCount > 0)
                {
                    DeleteFesSongWithDisc(sqlTransac);
                }

                if (tbWorkUpdate.Rows.Count == 0)
                    countSuccess = deleteCount;

                sqlTransac.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                countSuccess = 0;
                sqlTransac.Rollback();
                connection.Close();
                throw ex;
            }
        }

        private void UpdateFesSongWithDis(SqlTransaction sqlTransac, string contentId, DisVersion version)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesSongWithDiscQuery.GetUpdateFesSongWithDisQuery(contentId, version));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateFesSongWorkTable(SqlTransaction sqlTransac, string contentId)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesSongWithDiscQuery.GetUpdateFesSongWorkTableQuery(contentId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DeleteFesSongWithDisc(SqlTransaction sqlTransac)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesSongWithDiscQuery.GetDeleteFesSongWithDiscRegistTableQuery());

                // Delete work table
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesSongWithDiscQuery.GetDeleteFesSongWithDiscWorkQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertFesSongWidthDisc(SqlTransaction sqlTransac, DataTable dtRegist)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesSongWithDiscQuery.GetInsertFesSongWithDiscRegistTableQuery(dtRegist));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateFesSongWithDis(SqlTransaction sqlTransac, DataTable dtRegist)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesSongWithDiscQuery.GetUpdateFesSongWithDiscRegistTableQuery(dtRegist));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetRegistFesSongWithDis(DisVersion version, string contentId)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesSongWithDiscQuery.GetRegistFesSongWithDisQuery(version, contentId)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetFesSongWithDiscWorkDataUpdate(DisVersion version)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesSongWithDiscQuery.GetFesSongWithDiscWorkDataUpdateQuery(version)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDataExport(List<string> dataFilter)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRegisteredConditionData(string data)
        {
            try
            {
                string[] list = data.Split(';');
                DataTable dt = new DataTable();
                dt.Columns.Add("Column1");
                dt.Columns.Add("Column2");
                dt.Rows.Add(string.Empty, string.Empty);

                for (int i = 0; i < list.Length; i++)
                {
                    if (i % 2 == 0)
                        dt.Rows.Add(list[i + 1], list[i]);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetUseAgeFlagDataForCombox()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");
            dt.Rows.Add(null, null);
            dt.Rows.Add("null", "null");
            dt.Rows.Add("not null", "not null");
            dt.Rows.Add(0, 0);
            dt.Rows.Add(1, 1);
            return dt;
        }

        public void ExecuteSearch(List<string> slqParameters, DisVersion currentVersion)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesSongWithDiscQuery.GetInsertWorkTableTmpQuery(slqParameters, currentVersion));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TruncateWorkTableTmp()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesSongWithDiscQuery.GetTruncateWorkTable());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
