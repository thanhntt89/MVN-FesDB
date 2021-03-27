using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Festival.Common;
using FestivalCommon;

namespace FestivalBusiness
{
    public class FesSongAddDeleteQuery
    {
        internal static string GetUpdateWorkTmpQuery(string tableName)
        {
            string query = string.Format("UPDATE WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲追加削除管理_{0}] set 選択 = 0, 更新日時 =NULL; UPDATE WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲追加削除管理_{0}] SET 選択 = t1.選択,通番 = t1.通番,追加削除区分 = t1.追加削除区分,[Wii(デジドコ)選曲番号] = t1.Wiiデジドコ選曲番号,カラオケ選曲番号 = t1.カラオケ選曲番号,楽曲名 = t1.楽曲名,歌手名 = t1.歌手名,FesDISCID = t1.FesDISCID,データサイズ = t1.データサイズ,有料コンテンツフラグ = t1.有料コンテンツフラグ,有償情報フラグ = t1.有償情報フラグ,備考 = t1.備考,登録日 = CONVERT(varchar(8),t1.登録日,112),アップ予定日 = CONVERT(varchar(8),t1.アップ予定日,112),サービス発表日 = CONVERT(varchar(8),t1.サービス発表日,112),取消フラグ = t1.取消フラグ,削除 = t1.削除,更新日時 = t1.更新日時,ID = t1.ID FROM WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲追加削除管理_{0}] INNER JOIN [{1}] AS t1 ON WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲追加削除管理_{0}].ID = t1.ID ; DROP TABLE {1}", Environment.MachineName.Replace("-", ""), tableName);
            return query;
        }

        internal static string GetFesSongRelatedInfoByIdQuery(string songNumber)
        {
            string query = string.Format("select v1.[カラオケ選曲番号],v1.[楽曲名] ,v1.[歌手名] ,v1.[有料コンテンツフラグ] , CONVERT(VARCHAR,CONVERT(DATETIME,  v1.[アップ予定日]),111) as [アップ予定日] ,CONVERT(VARCHAR,CONVERT(DATETIME,  v1.[サービス発表日]),111) as [サービス発表日] ,v1.[取消フラグ] from Wii.dbo.[v_Fes選曲番号関連情報] as v1 where v1.[Wii(デジドコ)選曲番号] ={0}", songNumber);
            return query;
        }

        internal static string GetCreateWorkTableQuery(string tableName)
        {
            string query = string.Format("IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'{0}') AND type in (N'U')) BEGIN drop table {0} END; CREATE TABLE {0} ([選択] [bit] NULL DEFAULT ((0)),[通番] [int] NULL,[追加削除区分] [tinyint] NULL,[Wiiデジドコ選曲番号] [int] NULL,[カラオケ選曲番号] [int] NULL,[楽曲名] [nvarchar](150) NULL,[歌手名] [nvarchar](100) NULL,[FesDISCID] [nvarchar](10) NULL,[データサイズ] [int] NULL,[有料コンテンツフラグ] [tinyint] NULL,[有償情報フラグ] [tinyint] NULL,[備考] [nvarchar](255) NULL,[登録日]  [datetime] NULL,[アップ予定日] [datetime] NULL,[サービス発表日] [datetime] NULL,[取消フラグ] [tinyint] NULL,[削除] [bit] NULL DEFAULT ((0)),[更新日時] [datetime] NULL,[ID] [int] NOT NULL)", tableName);
            return query;
        }

        internal static string GetWorkTmpQuery()
        {
            string query = string.Format("select 選択,通番,追加削除区分,[Wii(デジドコ)選曲番号] as Wiiデジドコ選曲番号,カラオケ選曲番号,楽曲名,歌手名,FesDISCID,データサイズ,有料コンテンツフラグ,有償情報フラグ,備考,CONVERT(datetime,登録日) as 登録日,CONVERT(datetime,アップ予定日) as アップ予定日,CONVERT(datetime,サービス発表日) as サービス発表日,取消フラグ,削除,CONVERT(datetime,更新日時) as 更新日時,ID   from WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲追加削除管理_{0}] order by [通番], [ID]", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetTruncateSongManagementWorkTmpQuery()
        {
            string query = string.Format("TRUNCATE TABLE WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲追加削除管理_{0}]", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetExecuteSearchQuery(List<string> slqParameters)
        {
            string query = GetInsertWorkTableTmpQuery();
            // Input not set
            if (slqParameters.Count > 0)
            {
                string parameter = string.Empty;
                slqParameters.ToList().ForEach(para => parameter += para + " ");
                query = query + " where 1=1 " + parameter;
            }

            return query;
        }

        internal static string GetSongUpdateFromWorkTableQuery()
        {
            string query = string.Format("select  t1.[ID] ,t1.[通番] ,t2.[デジドココンテンツID] ,t1.[Wii(デジドコ)選曲番号] as Wiiデジドコ選曲番号,t1.[追加削除区分] ,t1.[FesDISCID] ,t1.[データサイズ] ,t1.[有償情報フラグ] ,t1.[備考] ,t1.[登録日] from  WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲追加削除管理_{0}] as t1  left outer join  Wii.dbo.[v_デジ・ドココンテンツ] as t2  on t1.[Wii(デジドコ)選曲番号] = t2.[選曲番号] where  t1.[更新日時] is not null  and t1.[削除] <> 1 order by  t1.[通番] ,t1.[ID]", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetSongDataByIdQuery(string id)
        {
            string query = string.Format("select ID,通番,追加削除区分,デジドココンテンツID,	FesDISCID,データサイズ,有償情報フラグ,	備考,登録日,	未出力フラグ,削除フラグ,最終更新日時,最終更新者,最終更新PC名 from Wii.dbo.[FesDISC追加削除管理] where [ID] = '{0}'", id);
            return query;
        }

        private static string GetInsertWorkTableTmpQuery()
        {
            string query = string.Format(" insert into WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲追加削除管理_{0}] ([ID] ,[通番] ,[追加削除区分] ,[Wii(デジドコ)選曲番号] ,[カラオケ選曲番号] ,[楽曲名] ,[歌手名] ,[FesDISCID] ,[データサイズ] ,[有料コンテンツフラグ] ,[有償情報フラグ] ,[備考] ,[登録日] ,[アップ予定日] ,[サービス発表日] ,[取消フラグ] ,[未出力フラグ] ,[削除フラグ]) select [ID] ,[通番] ,[追加削除区分] ,[Wii(デジドコ)選曲番号] ,[カラオケ選曲番号] ,[楽曲名] ,[歌手名] ,[FesDISCID] ,[データサイズ] ,[有料コンテンツフラグ] ,[有償情報フラグ] ,[備考] ,[登録日] ,[アップ予定日] ,[サービス発表日] ,[取消フラグ] ,[未出力フラグ] ,[削除フラグ] from Wii.dbo.[v_FesDISC搭載曲追加削除管理] ", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetInsertNewRowSongManagementWorkTableQuery(bool isDataSourceEmpty)
        {
            string query = string.Format("INSERT INTO WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲追加削除管理_{0}] (ID,通番, 更新日時) select (max(Id) + 1), (max(通番) + 1), GetDate() from WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲追加削除管理_{0}] ", Environment.MachineName.Replace("-", ""));
            if (isDataSourceEmpty)
                query = string.Format("INSERT INTO WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲追加削除管理_{0}] (ID,通番, 更新日時) select (max(Id) + 1), (max(通番) + 1),GetDate() from Wii.dbo.[v_FesDISC搭載曲追加削除管理] ", Environment.MachineName.Replace("-", ""));
            return query;
        }


        internal static string GetSelectLastSongRecordQuery()
        {
            string query = string.Format("select top(1)* from WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲追加削除管理_{0}] order by ID desc", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetSongCheckQuery(string id, string fesDiscId, string contentId)
        {
            string query = string.Format("SELECT デジドココンテンツID FROM Wii.dbo.[FesDISC追加削除管理] WHERE [追加削除区分] = 0 AND [削除フラグ] = 0 AND [デジドココンテンツID] = '{0}' AND [FesDISCID] = '{1}' AND [ID] <> '{2}'", contentId, fesDiscId, id);
            return query;
        }

        internal static string GetColumnsAddNewSongWorkTableQuery()
        {
            string query = string.Format("select [ID],[通番],[追加削除区分],[Wii(デジドコ)選曲番号],[カラオケ選曲番号],[楽曲名],[歌手名],[FesDISCID],[データサイズ],[有料コンテンツフラグ],[有償情報フラグ],[備考],[登録日],[アップ予定日],[サービス発表日],[取消フラグ],[未出力フラグ],[削除フラグ],[選択],[削除],[更新日時] from WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲追加削除管理_{0}]", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetFesSongSourceByIdQuery(string id)
        {
            string query = string.Format("select [ID] ,[通番] ,[追加削除区分] ,[Wii(デジドコ)選曲番号] ,[カラオケ選曲番号] ,[楽曲名] ,[歌手名] ,[FesDISCID] ,[データサイズ] ,[有料コンテンツフラグ] ,[有償情報フラグ] ,[備考] ,[登録日] ,[アップ予定日] ,[サービス発表日] ,[取消フラグ] ,[未出力フラグ] ,[削除フラグ] from Wii.dbo.[v_FesDISC搭載曲追加削除管理] where [追加削除区分] = 0 and [削除フラグ] = 0 and [Wii(デジドコ)選曲番号] ='{0}'", id);
            return query;
        }

        internal static string GetInsertNewRowSongWorkTableQuery(DataTable dtAddNewSongWorkTable)
        {
            DataRow row = dtAddNewSongWorkTable.Rows[0];
            string columns = string.Empty;
            string values = string.Empty;

            foreach (DataColumn col in dtAddNewSongWorkTable.Columns)
            {
                columns += string.Format("[{0}],", col.ColumnName);
                if (col.ColumnName.Equals("更新日時"))
                {
                    values += "GetDate(),";
                    continue;
                }
                if (row[col] == null || string.IsNullOrWhiteSpace(row[col].ToString()))
                    values += "NULL,";
                else
                {
                    values += "N'" + row[col].ToString().Replace("'", "''") + "',";
                }
            }

            columns = columns.Remove(columns.Length - 1, 1);
            values = values.Remove(values.Length - 1, 1);

            string query = string.Format("INSERT INTO WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲追加削除管理_{0}]({1}) VALUES({2})", Environment.MachineName.Replace("-", ""), columns, values);
            return query;
        }

        internal static string GetInsertSongWorkByKaraokeInputNumberQuery()
        {
            string query = GetInsertWorkTableTmpQuery();
            query += string.Format(" where [Wii(デジドコ)選曲番号] in (select [選曲番号] from WiiTmp.dbo.[tbl_Wrk_Fes選曲番号_{0}])", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetInsertInputNumberToWorkTableQuery(EnumInputTypeName inputType, EnumInputNumberType inputNumberType)
        {
            string query = GetInsertWorkTableTmpQuery();

            if (inputNumberType == EnumInputNumberType.SongNumber)
            {
                if (inputType == EnumInputTypeName.選曲番号入力 || inputType == EnumInputTypeName.ファイル照合)
                    query += string.Format(" where [Wii(デジドコ)選曲番号] in (select [選曲番号] from WiiTmp.dbo.[tbl_Wrk_Fes選曲番号_{0}])", Environment.MachineName.Replace("-", ""));
                else
                    query += string.Format(" where [カラオケ選曲番号] in (select [選曲番号] from WiiTmp.dbo.[tbl_Wrk_Fes選曲番号_{0}])", Environment.MachineName.Replace("-", ""));
            }
            return query;
        }

        internal static string GetUpdateSongSetDeleteFlagQuery(string id, string fesDiscId, string contentId)
        {
            string query = string.Format("UPDATE Wii.dbo.[FesDISC追加削除管理] SET [削除フラグ] = 0 WHERE [ID] = (select max([ID])  from Wii.dbo.[FesDISC追加削除管理] where [ID] <>'{0}' AND [デジドココンテンツID] ='{1}' AND [FesDISCID] = '{2}') AND [追加削除区分] = 1 AND [削除フラグ] = 1", id, contentId, fesDiscId);
            return query;
        }

        internal static string GetInsertSongManagementQuery(DataTable tbSongUpdate)
        {
            DataRow row = tbSongUpdate.Rows[0];
            string columns = string.Empty;
            string values = string.Empty;

            foreach (DataColumn col in tbSongUpdate.Columns)
            {
                columns += string.Format("[{0}],", col.ColumnName);
                if (col.ColumnName.Equals("最終更新日時"))
                {
                    values += "GetDate(),";
                    continue;
                }
                if (row[col] == null || string.IsNullOrWhiteSpace(row[col].ToString()))
                    values += "NULL,";
                else
                {
                    values += "N'" + row[col].ToString().Replace("'", "''") + "',";
                }
            }

            columns = columns.Remove(columns.Length - 1, 1);
            values = values.Remove(values.Length - 1, 1);

            string query = string.Format("INSERT INTO Wii.dbo.[FesDISC追加削除管理]({1}) VALUES({2})", Environment.MachineName.Replace("-", ""), columns, values);
            return query;
        }

        internal static string GetUpdateSongWorkTableQuery()
        {
            string query = string.Format("update WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲追加削除管理_{0}] set [削除フラグ] = 0 WHERE [ID] in (select ID from Wii.dbo.[FesDISC追加削除管理] where [削除フラグ] = 2)", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetUpdateSongLastDateQuery(string id, string contentId, string fesDiscId)
        {
            string query = string.Format("update Wii.dbo.[FesDISC追加削除管理] set [削除フラグ] = (CASE WHEN [ID] = '{0}' THEN [削除フラグ] ELSE 1 END),[最終更新日時] = getdate(),[最終更新者] = '{1}',[最終更新PC名] = '{2}' where [ID] in (select t2.[ID] from  Wii.dbo.[FesDISC追加削除管理] as t2 where t2.[削除フラグ] = 0 and t2.[デジドココンテンツID] = '{3}' and t2.[FesDISCID] = '{4}')", id, Environment.UserName, Environment.MachineName.Replace("-", ""), contentId, fesDiscId);
            return query;
        }

        internal static string GetUpdateSongTableWorkQuery(string id)
        {
            string query = string.Format("update WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲追加削除管理_{0}] set [更新日時] = NULL WHERE [ID] ='{1}'", Environment.MachineName.Replace("-", ""), id);
            return query;
        }

        internal static string GetUpdateFlagSongManagementQuery()
        {
            string query = string.Format("update Wii.dbo.[FesDISC追加削除管理] set [削除フラグ] = 2 from (select max([ID]) as [更新ID]  from Wii.dbo.[FesDISC追加削除管理] as t2 where exists (select 'x' from Wii.dbo.[FesDISC追加削除管理]  as t3 where t3.[削除フラグ] = 0 and t3.[ID] in (select [ID] from WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲追加削除管理_{0}] where [削除] = 1 ) and t3.[デジドココンテンツID] = t2.[デジドココンテンツID]  and t3.[FesDISCID] = t2.[FesDISCID]) and t2.[削除フラグ] = 1 group by t2.[デジドココンテンツID] ,t2.[FesDISCID]) iv1 where [ID] = iv1.[更新ID] ", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetUpdateSongTableQuery()
        {
            string query = string.Format("update Wii.dbo.[FesDISC追加削除管理] set [削除フラグ] = 0 WHERE [削除フラグ] = 2");
            return query;
        }

        internal static string GetDeleteSongMangementQuery()
        {
            string query = string.Format("DELETE FROM Wii.dbo.[FesDISC追加削除管理] WHERE  [削除フラグ] = 0 AND [未出力フラグ] = 0 AND [ID] in (SELECT [ID] FROM WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲追加削除管理_{0}] WHERE [削除] = 1)", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetDeleteSongWorkTableQuery()
        {
            string query = string.Format("DELETE FROM WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲追加削除管理_{0}] WHERE [削除] = 1", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetUpdateSongManagementQuery(DataTable tbSongUpdate)
        {
            DataRow row = tbSongUpdate.Rows[0];
            string id = string.Empty;
            string columnValue = string.Empty;
            string values = string.Empty;
            foreach (DataColumn col in tbSongUpdate.Columns)
            {
                if (col.ColumnName.Equals("ID"))
                {
                    id = row[col].ToString();
                    continue;
                }

                if (row[col] == null || string.IsNullOrWhiteSpace(row[col].ToString()))
                    columnValue = "NULL";
                else
                    columnValue = "N'" + row[col].ToString().Replace("'", "''") + "'";
                if (col.ColumnName.Equals("最終更新日時"))
                    columnValue = "GetDate()";
                values += col.ColumnName + " = " + columnValue + ",";
            }
            values = values.Remove(values.Length - 1, 1);
            string query = string.Format("UPDATE Wii.dbo.[FesDISC追加削除管理] SET {0} WHERE ID = {1} ", values, id);
            return query;
        }
    }
}
