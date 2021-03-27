using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using FestivalCommon;

namespace FestivalBusiness
{
    public class FesSongWithDiscQuery
    {
        public static string GetInsertFesSongWithDiscWorkTmp(DisVersion currentVersion)
        {
            string query = string.Format("insert into WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲管理_{0}]([デジドココンテンツID] ,[Wii(デジドコ)選曲番号] ,[カラオケ選曲番号] ,[楽曲名] ,[歌手名] ,[楽曲名検索用カナ] ,[曲名よみがな補正] ,[歌手名検索用カナ] ,[FesDISCID] ,[NET利用フラグ] ,[取消日] ,[FesDISCID(Ver2)] ,[NET利用フラグ(Ver2)] ,[取消日(Ver2)] ,[データサイズ] ,[データサイズ(Ver2)] ,[アップ予定日] ,[サービス発表日] ,[取消フラグ] ,[Wii_U_制作完了日] ,[JV映像区分(背景映像区分)] ,[備考] ,[備考(Ver2)] ) select [デジドココンテンツID] ,[Wii(デジドコ)選曲番号] ,[カラオケ選曲番号] ,[楽曲名] ,[歌手名] ,[楽曲名検索用カナ] ,[曲名よみがな補正] ,[歌手名検索用カナ] ,[FesDISCID] ,[NET利用フラグ] ,[取消日] ,[FesDISCID(Ver2)] ,[NET利用フラグ(Ver2)] ,[取消日(Ver2)] ,[データサイズ] ,[データサイズ(Ver2)] ,[アップ予定日] ,[サービス発表日] ,[取消フラグ] ,[Wii_U_制作完了日] ,[JV映像区分(背景映像区分)] ,[備考] ,[備考(Ver2)] from Wii.dbo.[v_FesDISC収録情報]", Environment.MachineName.Replace("-", ""));

            return query;
        }

        internal static string GetFesSongWithDiscWorkDataQuery()
        {
            string query = string.Format("SELECT 選択,[Wii(デジドコ)選曲番号] AS Wiiデジドコ選曲番号,カラオケ選曲番号,楽曲名,歌手名,楽曲名検索用カナ,曲名よみがな補正,歌手名検索用カナ,FesDISCID,[FesDISCID(Ver2)] AS FesDISCIDVer2,NET利用フラグ,[NET利用フラグ(Ver2)] AS NET利用フラグVer2,CONVERT(datetime,取消日,111) AS 取消日,CONVERT(datetime,[取消日(Ver2)],111) AS 取消日Ver2,データサイズ,[データサイズ(Ver2)] AS データサイズVer2,CONVERT(datetime,アップ予定日,111) AS アップ予定日,CONVERT(datetime,サービス発表日,111) AS サービス発表日,取消フラグ,CONVERT(datetime,Wii_U_制作完了日,111) AS Wii_U_制作完了日,[JV映像区分(背景映像区分)] AS JV映像区分背景映像区分,備考,[備考(Ver2)] AS 備考Ver2,削除,CONVERT(datetime,更新日時,111) as 更新日時,デジドココンテンツID FROM WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲管理_{0}] order by [Wii(デジドコ)選曲番号]", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetUpdateFesSongWithDiscWorkTmpQuery(string tableName)
        {
            string query = string.Format("UPDATE WiiTmp.[dbo].[tbl_Wrk_FesDISC搭載曲管理_{0}] set 選択 = 0, 更新日時 = NULL; UPDATE WiiTmp.[dbo].[tbl_Wrk_FesDISC搭載曲管理_{0}] SET 選択 = t2.選択,[Wii(デジドコ)選曲番号] = t2.Wiiデジドコ選曲番号,カラオケ選曲番号 = t2.カラオケ選曲番号,楽曲名 = t2.楽曲名,歌手名 = t2.歌手名,楽曲名検索用カナ = t2.楽曲名検索用カナ,曲名よみがな補正 = t2.曲名よみがな補正,歌手名検索用カナ = t2.歌手名検索用カナ,FesDISCID = t2.FesDISCID,[FesDISCID(Ver2)] = t2.FesDISCIDVer2,NET利用フラグ = t2.NET利用フラグ,[NET利用フラグ(Ver2)] = t2.NET利用フラグVer2,取消日 = CONVERT(varchar(8),t2.取消日,112),[取消日(Ver2)] = CONVERT(varchar(8),t2.取消日Ver2,112), データサイズ = t2.データサイズ,[データサイズ(Ver2)] = t2.データサイズVer2, アップ予定日 = CONVERT(varchar(8),t2.アップ予定日,112), サービス発表日 = CONVERT(varchar(8),t2.サービス発表日,112), 取消フラグ = t2.取消フラグ, Wii_U_制作完了日 = CONVERT(varchar(8),t2.Wii_U_制作完了日,112),[JV映像区分(背景映像区分)] = t2.JV映像区分背景映像区分, 備考 = t2.備考,[備考(Ver2)] = t2.備考Ver2, 削除 = t2.削除, 更新日時 = t2.更新日時 FROM WiiTmp.[dbo].[tbl_Wrk_FesDISC搭載曲管理_{0}] as t1 inner join {1} as t2 on t1.デジドココンテンツID = t2.デジドココンテンツID; DROP TABLE {1};", Environment.MachineName.Replace(" -", "_"), tableName);
            return query;
        }

        internal static string GetFesSongWithDiscWorkDataUpdateQuery(DisVersion version)
        {
            string query = string.Format("select [デジドココンテンツID],[FesDISCID],[NET利用フラグ],[取消日],[備考],[Wii(デジドコ)選曲番号] from [WiiTmp].[dbo].[tbl_Wrk_FesDISC搭載曲管理_{0}] where [更新日時] is not null  order by [Wii(デジドコ)選曲番号]", Environment.MachineName.Replace(" -", "_"));
            if (version == DisVersion.VERSION_NUMBER_V2)
            {
                query = string.Format("select [デジドココンテンツID] ,[FesDISCID(Ver2)] AS [FesDISCID] ,[NET利用フラグ(Ver2)] AS [NET利用フラグ] ,[取消日(Ver2)] AS [取消日] ,[備考(Ver2)] AS [備考] ,[Wii(デジドコ)選曲番号]  from  [WiiTmp].[dbo].[tbl_Wrk_FesDISC搭載曲管理_{0}] where [更新日時] is not null  order by [Wii(デジドコ)選曲番号]", Environment.MachineName.Replace(" -", "_"));
            }
            return query;
        }

        internal static string GetRegistFesSongWithDisQuery(DisVersion version, string contentId)
        {
            string query = string.Format("select  デジドココンテンツID,FesDISCID,NET利用フラグ,取消日,備考,	削除フラグ,最終更新日時,最終更新者,最終更新PC名,バージョンNO  from Wii.dbo.[FesDISC収録管理] where [デジドココンテンツID] = '{0}' and [削除フラグ] = 0  and [バージョンNO] = '{1}'", contentId, (int)version);
            return query;
        }

        internal static string GetCreateFesSongWithDiscWorkTmpQuery(string tableName)
        {
            string query = string.Format("IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'{0}') AND type in (N'U')) BEGIN drop table {0} END; CREATE TABLE {0}(選択 [bit] NULL,Wiiデジドコ選曲番号 [int] NULL,カラオケ選曲番号 [int] NULL,楽曲名 [nvarchar](150) NULL,歌手名 [nvarchar](100) NULL,楽曲名検索用カナ [nvarchar](900) NOT NULL,曲名よみがな補正 [nvarchar](256) NULL,歌手名検索用カナ [nvarchar](450) NULL,FesDISCID [nvarchar](10) NULL,FesDISCIDVer2 [nvarchar](10) NULL,NET利用フラグ [int] NULL,NET利用フラグVer2 [tinyint] NULL,取消日 [datetime] NULL,取消日Ver2 [datetime] NULL,データサイズ [int] NULL,データサイズVer2 [int] NULL,アップ予定日 [datetime] NULL, サービス発表日 [datetime] NULL,取消フラグ [int] NULL,Wii_U_制作完了日 [datetime] NULL,JV映像区分背景映像区分 [nvarchar](100) NULL,備考 [nvarchar](255) NULL,備考Ver2 [nvarchar](255) NULL,削除 [bit] NULL,更新日時 [datetime] NULL,デジドココンテンツID [int] NOT NULL)", tableName);
            return query;
        }

        internal static string GetTruncateWorkTable()
        {
            string query = string.Format("truncate table WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲管理_{0}]", Environment.MachineName.Replace(" -", "_"));
            return query;
        }

        internal static string GetInsertWorkTableTmpQuery(List<string> slqParameters, DisVersion currentVersion)
        {
            string query = string.Empty;
            query = GetInsertFesSongWithDiscWorkTmp(currentVersion);
            // Input not set
            if (slqParameters.Count == 0)
            {
                query = query + " where [デジドココンテンツID] in ( select [デジドココンテンツID] from [v_デジ・ドココンテンツ] where [取消連番] = 0 )";
            }// User in put data
            else
            {
                string parameter = string.Empty;
                slqParameters.ToList().ForEach(para => parameter += para + " ");
                query = query + " where 1=1 " + parameter;
            }
            return query;
        }

        internal static string GetUpdateFesSongWithDiscRegistTableQuery(DataTable dtRegist)
        {
            DataRow row = dtRegist.Rows[0];
            string id = string.Empty;
            string バージョンNO = string.Empty;

            string columnValue = string.Empty;
            string values = string.Empty;
            foreach (DataColumn col in dtRegist.Columns)
            {
                if (col.ColumnName.Equals("デジドココンテンツID"))
                {
                    id = row[col].ToString();
                    continue;
                }
                if (col.ColumnName.Equals("バージョンNO"))
                {
                    バージョンNO = row[col].ToString();
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
            string query = string.Format("UPDATE  Wii.dbo.[FesDISC収録管理] SET {0} WHERE デジドココンテンツID = '{1}' AND [削除フラグ] = 0  AND [バージョンNO] = '{2}'", values, id, バージョンNO);
            return query;
        }

        internal static string GetDeleteFesSongWithDiscRegistTableQuery()
        {
            string query = string.Format("delete from Wii.dbo.[FesDISC収録管理] where [デジドココンテンツID] in ( select [デジドココンテンツID] from [WiiTmp].[dbo].[tbl_Wrk_FesDISC搭載曲管理_{0}] where [削除] = 1)", Environment.MachineName.Replace(" -", "_"));
            return query;
        }

        internal static string GetInsertFesSongWithDiscRegistTableQuery(DataTable dtRegist)
        {
            DataRow row = dtRegist.Rows[0];
            string columns = string.Empty;
            string values = string.Empty;

            foreach (DataColumn col in dtRegist.Columns)
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

            string query = string.Format("INSERT INTO Wii.dbo.[FesDISC収録管理] ({1}) VALUES({2})", Environment.MachineName.Replace("-", ""), columns, values);
            return query;
        }

        internal static string GetDeleteFesSongWithDiscWorkQuery()
        {
            string query = string.Format("delete from [WiiTmp].[dbo].[tbl_Wrk_FesDISC搭載曲管理_{0}] where [削除] = 1", Environment.MachineName.Replace(" -", "_"));
            return query;
        }

        internal static string GetUpdateFesSongWithDisQuery(string contentId, DisVersion version)
        {
            string query = string.Format("update Wii.dbo.[FesDISC収録管理] set [削除フラグ] = (CASE WHEN [削除フラグ] = 2 THEN 1 ELSE [削除フラグ] END),[最終更新日時] = getdate() ,[最終更新者] = '{0}',[最終更新PC名] = '{1}' where [デジドココンテンツID] = '{2}' and [削除フラグ] in (0,2) and [バージョンNO] = '{3}'", Environment.UserName, Environment.MachineName.Replace(" -", "_"), contentId, (int)version);
            return query;
        }

        internal static string GetUpdateFesSongWorkTableQuery(string contentId)
        {
            string query = string.Format("update WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲管理_{0}] set 更新日時 = NULL where デジドココンテンツID ='{1}'", Environment.MachineName.Replace(" -", "_"), contentId);
            return query;
        }
    }
}
