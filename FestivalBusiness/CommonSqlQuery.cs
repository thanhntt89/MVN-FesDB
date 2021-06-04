using Festival.Common;
using FestivalCommon;
using System;
using System.Collections.Generic;
using System.Data;

namespace FestivalBusiness
{
    public class CommonSqlQuery
    {
        internal static string GetUpdateColumntableQuery(string tableName, ColumnsCollection columns, bool isUpdate = false)
        {
            string column = string.Empty;
            foreach (ColumnEntity col in columns.Columns)
            {
                column += string.Format(" {0} = '{1}',", col.ColumName, col.Values);
            }
            column = column.Remove(column.Length - 1, 1);
            if (isUpdate == true)
            {
                column += " ,更新日時 = GetDate()";
            }
            string query = string.Format("UPDATE {0} SET {1}", tableName, column);
            return query;
        }

        public static string GetUpdateModuleTablekQuery(string idFesContents, bool status)
        {
            string computerName = Environment.MachineName;
            string userName = Environment.UserName;
            int statusValue = 0;
            string sql = string.Format("update Wii.dbo.[tbl_Fesロック] set [状態] = {0} where [担当者] = '{1}' and ID = '{2}'", statusValue, userName, idFesContents);
            if (status)
            {
                statusValue = 1;
                sql = string.Format("update Wii.dbo.[tbl_Fesロック] set [状態] = {0}, [担当者] = '{1}', [PC名] = '{2}' where ID = '{3}'", statusValue, userName, computerName, idFesContents);
            }
            return sql;
        }

        internal static string GetInsertLockModuleTableQuery(string idFesMenu)
        {
            string computerName = Environment.MachineName;
            string userName = Environment.UserName;

            string sql = string.Format("insert into Wii.dbo.[tbl_Fesロック] select 機能ID, 機能名,1,'{0}','{1}' from [Wii].[dbo].[Fes機能ID] where 機能ID='{2}'", userName, computerName, idFesMenu);

            return sql;
        }

        public static string GetCreateTableFesWorkQuery()
        {
            string sql = "exec Wii.dbo.usp_CreateFesWorkTable";
            return sql;
        }

        public static string GetDropTableFesWorkQuery()
        {
            string query1 = string.Format("exec Wii.dbo.usp_DropFesWorkTable");

            return query1;
        }

        internal static string GetFesEditLockSatusQuery(string tagId)
        {
            string query1 = string.Format("SELECT * FROM  Wii.dbo.tbl_Fesロック where ID='{0}'", tagId);

            return query1;
        }

        public static string GetRoleByUserQuery()
        {
            string userName = Environment.UserName;
            string query1 = string.Format("select t2.[権限名], t3.[機能ID], t3.[更新タイプ] from ( [Fes利用者] as t1 left join [Fes権限グループ] as t2 on t1.[権限グループ] = t2.[権限グループ] ) left join [Fes権限グループ機能割当] as t3 on t2.[権限グループ] = t3.[権限グループ] where t1.[利用者ID] = '{0}';", userName);

            return query1;
        }

        public static string GetRoleByGuestQuery()
        {
            string query2 = "select t2.[権限名], t3.[機能ID], t3.[更新タイプ] from ( [Fes利用者] as t1 left join [Fes権限グループ] as t2 on t1.[権限グループ] = t2.[権限グループ] ) left join [Fes権限グループ機能割当] as t3 on t2.[権限グループ] = t3.[権限グループ] where t1.[利用者ID] = '__Guest__';";

            return query2;
        }

        public static string GetLockMenuQuery()
        {
            string query = string.Format("update dbo.[tbl_Fesロック] set [状態] = 0 where [担当者] = {0} and [PC名] = {1} and ID = 110", Environment.UserName, Environment.MachineName.Replace("-", "_"));
            return query;
        }


        public static string GetFesCancelFlagQuery()
        {
            string query = "select [取り消しID], [説明文] from Wii.dbo.[Fes非公開理由] order by [取り消しID]";
            return query;
        }

        public static string GetOrchCancelFlagQuery()
        {
            string query = "select [取り消しID], [説明文] from Wii.dbo.[非公開理由] order by [取り消しID]";
            return query;
        }

        public static string GetSuportLevelQuery()
        {
            string query = "SELECT [支援レベル], [支援レベル名] FROM dbo.Fes支援レベル WHERE ([ソート順] IS NOT NULL) ORDER BY [ソート順]";
            return query;
        }

        internal static string GetInsertInputNumerWorkTableQuery(EnumInputNumberType inputNumberType, List<string> songNumberList)
        {
            string songNumbers = string.Empty;

            if (songNumberList.Count == 0)
                return songNumbers;

            foreach (var songNum in songNumberList)
            {
                songNumbers += string.Format("('{0}'),", songNum);
            }
            songNumbers = songNumbers.Remove(songNumbers.Length - 1);
            string query = string.Empty;

            if (inputNumberType == EnumInputNumberType.SongNumber)
            {
                query = string.Format("INSERT INTO WiiTmp.dbo.[tbl_Wrk_Fes選曲番号_{0}] (選曲番号) VALUES {1}", Environment.MachineName.Replace("-", "_"), songNumbers);
            }
            else if (inputNumberType == EnumInputNumberType.VideoNumber)
            {
                query = string.Format("INSERT INTO WiiTmp.dbo.[tbl_Wrk_Fes背景映像コード_{0}] (背景映像コード) VALUES {1}", Environment.MachineName.Replace("-", "_"), songNumbers);
            }
            return query;
        }


        public static string GetFesContentInsertSongNumberQuery(List<string> SongNumberList)
        {
            string songNumbers = string.Empty;

            if (SongNumberList.Count == 0)
                return songNumbers;

            foreach (var songNum in SongNumberList)
            {
                songNumbers += string.Format("({0}),", songNum);
            }
            songNumbers = songNumbers.Remove(songNumbers.Length - 1);
            string query = string.Format("INSERT INTO WiiTmp.dbo.[tbl_Wrk_Fes選曲番号_{0}] (選曲番号) VALUES {1}", Environment.MachineName.Replace("-", "_"), songNumbers);

            return query;
        }

        public static string GetInsertWorkTableMatchingKaraokeQuery()
        {
            string query = FesContentQuery.GetFesConentInsertWorkTableQuery();
            query += string.Format(" where [カラオケ選曲番号] in ( select [選曲番号] from WiiTmp.dbo.{0} )", Constants.SONG_NUMBER_NAME_TABLE_TMP);
            return query;
        }

        public static string GetInsertWorkTableTmpBySongSelectedNumberQuery()
        {
            string query = FesContentQuery.GetFesConentInsertWorkTableQuery();
            query += string.Format(" where [Wii(デジドコ)選曲番号] in ( select [選曲番号] from WiiTmp.dbo.{0} )", Constants.SONG_NUMBER_NAME_TABLE_TMP);
            return query;
        }

        public static string GetTruncateSongNumberWorkTmpQuery()
        {
            string query = string.Empty;
            query = string.Format("TRUNCATE TABLE WiiTmp.[dbo].[tbl_Wrk_Fes選曲番号_{0}]", Environment.MachineName);
            return query;
        }

        public static string GetTruncateVideoNumberWorkTmpQuery()
        {
            string query = string.Empty;
            query = string.Format("TRUNCATE TABLE WiiTmp.[dbo].[tbl_Wrk_Fes背景映像コード_{0}]", Environment.MachineName);
            return query;
        }

        public static string GetVersionQuery()
        {
            string query = "select max([バージョンNO]) as Version  from Wii.dbo.[tbl_Fesバージョン]";
            return query;
        }


        //Create Festa table to save video lock
        public static string GetCreateFestaVideoLockTableQuery()
        {
            string query = string.Format("Use [Wii]; IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'FestaVideoLock') AND type in (N'U')) BEGIN CREATE TABLE [Wii].[dbo].[FestaVideoLock]( [ContentType][int] NULL) ON[PRIMARY] END;");
            return query;
        }

        public static string GetTruncateFestaVideoLockTableQuery()
        {
            string query = string.Format("TRUNCATE TABLE [Wii].[dbo].[FestaVideoLock]");
            return query;
        }

        public static string GetInsertFestaVideoLockTableQuery(string videoCode, ref Parameters parameter)
        {
            parameter.Add(new Parameter()
            {
                Name = "@contentType",
                Values = videoCode
            });

            string query = string.Format("INSERT INTO [dbo].[FestaVideoLock]([ContentType]) VALUES(@contentType)");
            return query;
        }

        public static string GetSelectFestaVideoLockTableQuery()
        {
            string query = string.Format("SELECT * FROM [dbo].[FestaVideoLock]");
            return query;
        }

        public static string GetCheckInitCondition()
        {
            string query = string.Format("Use[Wii];  IF exists(select * from sys.objects where object_id = OBJECT_ID(N'[Wii].[dbo].[FestaVideoLock]') AND type in (N'U')) select 1; IF exists(select * from sys.objects where object_id = OBJECT_ID(N'[Wii].[dbo].[VideoCodeLock]') AND type in (N'U')) select 1; IF COL_LENGTH('[dbo].[Fesサービス]', '個別映像ロック') IS NOT NULL select 1; IF COL_LENGTH('[dbo].[Fes映像コード管理]', '個別映像ロック') IS NOT NULL select 1; IF COL_LENGTH('[WiiTmp].[dbo].[tbl_Fesコンテンツ_演奏時間追加]', '演奏時間NULL') IS NOT NULL  select 1; if exists(select 1 from sys.views where name='v_Fesコンテンツ_21' and type  in (N'V')) select 1; if exists(select 1 from sys.views where name='v_Fesコンテンツ_WiiU_21' and type in (N'V')) select 1; if exists(select 1 from sys.views where name='v_Fes映像コード管理_21' and type in (N'V')) select 1; IF OBJECT_ID('usp_CreateFesContentsTable_AddPlayTime_21','P') IS NOT NULL select 1;IF OBJECT_ID('usp_SelectFesContentsAll_AddPlayTime_21','P') IS NOT NULL select 1;");
            return query;
        }      
    }
}
