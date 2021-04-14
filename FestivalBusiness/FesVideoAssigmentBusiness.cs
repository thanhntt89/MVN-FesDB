using FestivalCommon;
using FestivalObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FestivalBusiness
{
    public class FesVideoAssigmentBusiness : BusinessBase
    {
        private CommonBusiness commonBusiness = new CommonBusiness();
        public DataTable LoadFesVideoAssigmentWorkTable()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesVideoAssigmentQuery.GetFesVideoAssimentWorkTmpQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveVideoAssigmentWorkTmp(DataTable dtUpdate)
        {
            if (dtUpdate == null || dtUpdate.Rows.Count == 0)
                return;
            dtUpdate.TableName = Constants.FES_VIDEO_ASSIGMENT_TABLE_DBTMP;

            // Save fescontent work
            commonBusiness.Save(FesVideoAssigmentQuery.GetCreateFesVideoAssigmentWorkTmpQuery(Constants.FES_VIDEO_ASSIGMENT_TABLE_DBTMP), FesVideoAssigmentQuery.GetUpdateFesVideoAssigmentWorkTmpQuery(Constants.FES_VIDEO_ASSIGMENT_TABLE_DBTMP), dtUpdate);
        }

        public DataTable GetCancalFlag()
        {
            try
            {
                return commonBusiness.GetComboxFesCancelFlag();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Save(DataTable dtUpdate, int deleteCount, ref FesVideoAssigmentObject messageVideoAssigment, ref int updatedCount)
        {
            try
            {
                SaveVideoAssigmentWorkTmp(dtUpdate);

                bool isUpdate = false;

                // Table update dbo.[Fes映像コード管理] 
                // Get all fes video assigment work update
                DataTable tbWorkUpdate = GetFesVideoAssigmentWorkUpdate();
                DataTable dtRegist = new DataTable();

                DataRow updateRow = null;

                connection = new SqlConnection(connectionString);

                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                sqlTransac = connection.BeginTransaction();
                string contentId = string.Empty;

                foreach (DataRow row in tbWorkUpdate.Rows)
                {
                    contentId = row["デジドココンテンツID"].ToString();
                    dtRegist = GetFesVideoCodeManagementById(contentId);

                    bool isAddNew = false;
                    isUpdate = true;

                    // Add new
                    if (dtRegist.Rows.Count == 0)
                    {
                        dtRegist.Rows.Add();
                        dtRegist.Rows[0]["デジドココンテンツID"] = row["デジドココンテンツID"];
                        isAddNew = true;
                    }

                    updateRow = dtRegist.Rows[0];

                    foreach (DataColumn col in tbWorkUpdate.Columns)
                    {
                        if (col.ColumnName.Equals("デジドココンテンツID"))
                            continue;
                        updateRow[col.ColumnName] = row[col];
                    }

                    updateRow["最終更新日時"] = DateTime.Now;
                    updateRow["最終更新者"] = Environment.UserName;
                    updateRow["最終更新PC名"] = Environment.MachineName.Replace("-", "");

                    if (isUpdate)
                    {
                        if (isAddNew)
                        {
                            InsertFesVideoManagement(sqlTransac, dtRegist);
                        }
                        else
                        {
                            UpdateFesViedeosManagment(sqlTransac, dtRegist);
                        }

                        // Update work table
                        UpdateFesVideoManagmentWork(sqlTransac, contentId);

                        updatedCount++;
                    }
                }

                if (deleteCount > 0)
                {
                    // Delete 
                    DeleteFesVideoManagement(sqlTransac);
                }

                if (tbWorkUpdate.Rows.Count == 0)
                    updatedCount = deleteCount;

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


        public void SaveFromFesContents(SqlTransaction sqlTransac, DataTable dtFesVideo)
        {
            try
            {        
                DataRow row = dtFesVideo.Rows[0];

                bool isUpdate = false;
                DataTable dtRegist = new DataTable();
                DataRow updateRow = null;
                string contentId = string.Empty;
                                
                contentId = row["デジドココンテンツID"].ToString();
                dtRegist = GetFesVideoCodeManagementById(contentId);

                bool isAddNew = false;
                isUpdate = true;

                // Add new
                if (dtRegist.Rows.Count == 0)
                {
                    dtRegist.Rows.Add();
                    dtRegist.Rows[0]["デジドココンテンツID"] = row["デジドココンテンツID"];
                    isAddNew = true;
                }

                updateRow = dtRegist.Rows[0];

                foreach (DataColumn col in dtFesVideo.Columns)
                {
                    if (col.ColumnName.Equals("デジドココンテンツID"))
                        continue;
                    updateRow[col.ColumnName] = row[col];
                }

                //updateRow["最終更新日時"] = DateTime.Now;
                //updateRow["最終更新者"] = Environment.UserName;
                //updateRow["最終更新PC名"] = Environment.MachineName.Replace("-", "");

                if (isUpdate)
                {
                    if (isAddNew)
                    {
                        InsertFesVideoManagement(sqlTransac, dtRegist);
                    }
                    else
                    {
                        UpdateFesViedeosManagment(sqlTransac, dtRegist);
                    }

                    // Update work table
                    UpdateFesVideoManagmentWork(sqlTransac, contentId);
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

       public void DeleteFromFesContents(SqlTransaction sqlTransac)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesVideoAssigmentQuery.GetDeleteFesVideoManagementQueryFromFesContents());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DeleteFesVideoManagement(SqlTransaction sqlTransac)
        {
            try
            {
                //Delete Wii.dbo.Fes映像コード管理
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesVideoAssigmentQuery.GetDeleteFesVideoManagementQuery());
                // Delete work table
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesVideoAssigmentQuery.GetDeleteFesVideoWorkQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateFesViedeosManagment(SqlTransaction sqlTransac, DataTable dtRegist)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesVideoAssigmentQuery.GetUpdateFesVideoManagementQuery(dtRegist));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateFesVideoManagmentWork(SqlTransaction sqlTransac, string contentId)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesVideoAssigmentQuery.GetUpdateFesVideoManagementWorkQuery(contentId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertFesVideoManagement(SqlTransaction sqlTransac, DataTable dtRegist)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, FesVideoAssigmentQuery.GetInsertFesVideoManagementQuery(dtRegist));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetFesVideoCodeManagementById(string contentId)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesVideoAssigmentQuery.GetFesVideoCodeManagementByIdQuery(contentId)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetFesVideoAssigmentWorkUpdate()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesVideoAssigmentQuery.GetFesAssigmentWorkUpdateQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public void TruncateVideoAssigmentWorkTmp()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesVideoAssigmentQuery.GetTruncateVideoAssimentWorkTmpQuery());
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
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesVideoAssigmentQuery.GetInsertVideoAssimentWorkTmpQuery(slqParameters));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDataExportVideoAssigment(List<string> dataFilter)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesVideoAssigmentQuery.GetExportFesVideoAssigmentExportQuery(dataFilter)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
