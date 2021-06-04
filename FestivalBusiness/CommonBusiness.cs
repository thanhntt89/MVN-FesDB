using Festival.Common;
using FestivalBusiness.Interface;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

namespace FestivalBusiness
{
    public class CommonBusiness : BusinessBase, ICommonBusiness
    {
        public void UpdateColumntable(string tableName, ColumnsCollection columns, bool isUpdate = false)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, CommonSqlQuery.GetUpdateColumntableQuery(tableName, columns, isUpdate));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        public void DropTableFesWork()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, CommonSqlQuery.GetDropTableFesWorkQuery());

                //Drop table Wrk_VideoCodeLock_{0}
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, VideoCodeLockQuery.GetDropTableWorkQuery());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void CreateWorkTable()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, CommonSqlQuery.GetCreateTableFesWorkQuery());

                CreateInitTables();
            }
            catch (Exception ex)
            {
                this.LogException(ex, MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
        }

        /// <summary>
        /// Update table feslock by tag id
        /// </summary>
        /// <param name="idFesMenu"></param>
        public bool SetFesEditLock(string idFesMenu, bool status)
        {
            try
            {
                string computerName = Environment.MachineName;
                string userName = Environment.UserName;

                string query = CommonSqlQuery.GetInsertLockModuleTableQuery(idFesMenu);

                var dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, CommonSqlQuery.GetFesEditLockSatusQuery(idFesMenu)).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    query = CommonSqlQuery.GetUpdateModuleTablekQuery(idFesMenu, status);
                }

                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
                return true;
            }
            catch (Exception ex)
            {
                this.LogException(ex, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        public string GetFesEditLockSatus(string idFesMenu)
        {
            string userName = string.Empty;
            try
            {
                var dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, CommonSqlQuery.GetFesEditLockSatusQuery(idFesMenu)).Tables[0];
                if (dt.Rows.Count != 0 && !dt.Rows[0]["状態"].ToString().Equals("0"))
                {
                    userName = dt.Rows[0]["担当者"].ToString();
                }
                return userName;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable GetDataComboxSingerId()
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

        /// <summary>
        /// Save data in wiicommon 
        /// </summary>
        /// <param name="queryCreateTableTmp"></param>
        /// <param name="queryUpdateTable"></param>
        /// <param name="dataTable"></param>
        public void Save(string queryCreateTableTmp, string queryUpdateTable, DataTable dataTable)
        {
            if (dataTable == null) return;

            try
            {
                connection = new SqlConnection(GetConnection.GetWiiSqlConnectionString());
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                sqlTransac = connection.BeginTransaction();
                // Truncade temp table               
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, queryCreateTableTmp);
                // Bulk insert tmp temp
                SqlHelpers.ExecuteBulkInsert(sqlTransac, dataTable);
                // Bulk update tmp
                SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, queryUpdateTable);

                sqlTransac.Commit();
            }
            catch (Exception ex)
            {
                sqlTransac.Rollback();
                connection.Close();
                throw ex;
            }

            connection.Close();
        }

        public void RunSqlQuery()
        {
            try
            {
                if (!File.Exists(Constants.SQL_QUERY_FILE_PATH))
                {
                    return;
                }

                if (CheckSqlHasFinished())
                {
                    File.Delete(Constants.SQL_QUERY_FILE_PATH);
                    return;
                }

                string sql_query = File.ReadAllText(Constants.SQL_QUERY_FILE_PATH, Encoding.GetEncoding("shift-jis")).ToString();

                IEnumerable<string> commandStrings = Regex.Split(sql_query, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

                connection.Open();
                foreach (string commandString in commandStrings)
                {
                    if (!string.IsNullOrWhiteSpace(commandString.Trim()))
                    {
                        using (var command = new SqlCommand(commandString, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
                connection.Close();

                //Delete sql file                
                File.Delete(Constants.SQL_QUERY_FILE_PATH);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetCurrentVersion()
        {
            string currentVersion = string.Empty;
            var dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, CommonSqlQuery.GetVersionQuery()).Tables[0];
            if (dt.Rows.Count > 0)
                currentVersion = dt.Rows[0].Field<object>(0).ToString();
            return currentVersion;
        }

        public void LockMenu()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, CommonSqlQuery.GetLockMenuQuery());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable GetRole()
        {
            DataTable dtRole = new DataTable();
            try
            {
                dtRole = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, CommonSqlQuery.GetRoleByUserQuery()).Tables[0];

                if (dtRole.Rows.Count == 0)
                {
                    dtRole = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, CommonSqlQuery.GetRoleByGuestQuery()).Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRole;
        }

        public DataTable GetData(string tableName)
        {
            var query = string.Format("SELECT * FROM {0}.dbo.{1}", GetConnection.TmpDataBaseName, tableName);
            try
            {
                DataTable dt = new DataTable();
                dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
                dt.TableName = tableName;
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateTableTmp(DataTable dataTable)
        {
            try
            {
                if (CheckTableExist(dataTable.TableName))
                {
                    DropTable(dataTable.TableName);
                }

                string sql = CreateSqlQueryString.BuildCreateTableScript(dataTable, GetConnection.TmpDataBaseName);
                SqlHelpers.ExecuteNonQuery(tempConnectionString, CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private bool CheckTableExist(string tableName)
        {
            try
            {
                string query = string.Format("SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'{0}') AND type in (N'U')", tableName);
                var dt = SqlHelpers.ExecuteDataset(tempConnectionString, CommandType.Text, query).Tables[0];
                if (dt.Rows.Count == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecuteQuery(string sql)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertSongNumber(List<string> songNumberList)
        {
            ExecuteQuery(CommonSqlQuery.GetFesContentInsertSongNumberQuery(songNumberList));
        }

        public void DropTable(string tableName)
        {
            try
            {
                // Drop table            
                var sqlDrop = string.Format("DROP TABLE {0}.dbo.{1}", GetConnection.TmpDataBaseName, tableName);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, sqlDrop);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertInputNumerWorkTable(EnumInputNumberType inputNumberType, List<string> songNumberList)
        {
            string query = CommonSqlQuery.GetInsertInputNumerWorkTableQuery(inputNumberType, songNumberList);

            try
            {
                TruncateInputNumberWorkTable(inputNumberType);

                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void TruncateInputNumberWorkTable(EnumInputNumberType inputNumberType)
        {
            string query = string.Empty;
            if (inputNumberType == EnumInputNumberType.SongNumber)
            {
                query = CommonSqlQuery.GetTruncateSongNumberWorkTmpQuery();
            }
            else if (inputNumberType == EnumInputNumberType.VideoNumber)
            {
                query = CommonSqlQuery.GetTruncateVideoNumberWorkTmpQuery();
            }

            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
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
        public void TruncateTableTmp(string tableName)
        {
            try
            {
                // Drop table            
                var truncate = string.Format("TRUNCATE TABLE {0}.dbo.{1}", GetConnection.TmpDataBaseName, tableName);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, truncate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TruncateTableWorkFesSongNumber()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, CommonSqlQuery.GetTruncateSongNumberWorkTmpQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Check data not empty TRUE table empty | FALSE table not empty
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns>TRUE table empty | FALSE table not empty</returns>
        public bool CheckTableEmpty(string tableName)
        {
            try
            {
                // Drop table            
                var query = string.Format("SELECT TOP 1 * FROM {0}.dbo.[{1}]", GetConnection.TmpDataBaseName, tableName);
                var dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
                if (dt.Rows.Count > 0) return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert worktable by song number
        /// </summary>
        public void InsertWorkTableTmpBySongNumber()
        {
            ExecuteQuery(CommonSqlQuery.GetInsertWorkTableTmpBySongSelectedNumberQuery());
        }

        public void InsertWorkTableMatchingKaraoke()
        {
            try
            {
                ExecuteQuery(CommonSqlQuery.GetInsertWorkTableMatchingKaraokeQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// GetDataComboxFesUpDate
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataComboxFesUpDate()
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

        /// <summary>
        /// GetDataComboxOrchFinishedDate
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataComboxOrchFinishedDate()
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

        /// <summary>
        /// GetDataComboxFesServicePublicDate
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataComboxFesServicePublicDate()
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

        /// <summary>
        /// GetComboxFesCancelFlag
        /// </summary>
        /// <returns></returns>
        public DataTable GetComboxOrchCancelFlag()
        {
            try
            {
                DataTable resut = CommonComboxData();

                DataTable dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, CommonSqlQuery.GetOrchCancelFlagQuery()).Tables[0];
                dt.Rows.Cast<DataRow>().ToList().ForEach(r => resut.Rows.Add(r[0], r[1]));

                return resut;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// GetComboxFesPaidContentFlag
        /// </summary>
        /// <returns></returns>
        public DataTable GetComboxFesPaidContentFlag()
        {
            try
            {
                DataTable dt = CommonComboxData();
                dt.Rows.Add(0, "0");
                dt.Rows.Add(1, "1");
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetComboxFesChapterFlag()
        {
            try
            {
                DataTable dt = CommonComboxData();
                dt.Rows.Add(0, "0");
                dt.Rows.Add(1, "1");

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// GetComboxSupportLevel_支援レベル
        /// </summary>
        /// <returns></returns>
        public DataTable GetComboxSupportLevel()
        {
            try
            {
                DataTable rstdt = CommonComboxData();
                DataTable dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, CommonSqlQuery.GetSuportLevelQuery()).Tables[0];
                dt.Rows.Cast<DataRow>().ToList().ForEach(r => rstdt.Rows.Add(r[0], r[1]));
                return rstdt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetComboxOrchServicePublic()
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

        /// <summary>
        /// GetComboxOrchCancelFlag_Orch取消フラグ
        /// </summary>
        /// <returns></returns>
        public DataTable GetComboxFesCancelFlag()
        {
            try
            {
                DataTable dtrst = CommonComboxData();
                DataTable dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, CommonSqlQuery.GetFesCancelFlagQuery()).Tables[0];
                dt.Rows.Cast<DataRow>().ToList().ForEach(r => dtrst.Rows.Add(r[0], r[1]));
                return dtrst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// GetComboxRegisteredConditions
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetComboxRegisteredConditions(string data)
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

        /// <summary>
        /// Combox data
        /// </summary>
        /// <returns></returns>
        private DataTable CommonComboxData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");
            dt.Rows.Add(null, Constants.CONDITION_VALUE_BLANK);
            dt.Rows.Add(Constants.CONDITION_VALUE_NULL, Constants.CONDITION_VALUE_NULL);
            dt.Rows.Add(Constants.CONDITION_VALUE_NOT_NULL, Constants.CONDITION_VALUE_NOT_NULL);
            return dt;
        }

        public void CreateInitTables()
        {
            try
            {
                //Create VideoCodeLockTMP
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, VideoCodeLockQuery.GetCreateTmpQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertFestaVideoLock(IList<string> videoCodes)
        {
            try
            {
                //Truncate video table
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, CommonSqlQuery.GetTruncateFestaVideoLockTableQuery());

                connection = new SqlConnection(GetConnection.GetWiiSqlConnectionString());
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                sqlTransac = connection.BeginTransaction();

                foreach (string video in videoCodes)
                {
                    try
                    {
                        Parameters par = new Parameters();
                        SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, CommonSqlQuery.GetInsertFestaVideoLockTableQuery(video, ref par), par);
                    }
                    catch (Exception ex)
                    {
                        sqlTransac.Rollback();
                        connection.Close();
                        throw ex;
                    }
                }

                sqlTransac.Commit();
            }
            catch (Exception ex)
            {
                sqlTransac.Rollback();
                connection.Close();
                throw ex;
            }

            connection.Close();
        }

        public IList<string> GetFestaVideoLock()
        {
            try
            {
                IList<string> videoLock = new List<string>();
                DataTable tb = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, CommonSqlQuery.GetSelectFestaVideoLockTableQuery()).Tables[0];
                if (tb.Rows.Count > 0)
                    videoLock = tb.AsEnumerable().Select(p => p.Field<int>(0).ToString()).ToList<string>();
                return videoLock;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateNewColumns()
        {
            try
            {
                try
                {
                    //Fescontent tmp column
                    SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesContentQuery.GetCreateNewColumnTableTmpQuery());
                    // Column table Fes映像コード管理 tmp
                    SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesVideoAssigmentQuery.GetCreateNewColumnsTableTmpQuery());
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

        public bool CheckSqlHasFinished()
        {
            try
            {
                //Number sql used in this version
                int sqlNumber = 10;
                DataSet dtSet = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, CommonSqlQuery.GetCheckInitCondition());

                return dtSet.Tables.Count == sqlNumber;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
