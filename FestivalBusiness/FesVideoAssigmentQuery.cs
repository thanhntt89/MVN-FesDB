using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using FestivalCommon;

namespace FestivalBusiness
{
    public class FesVideoAssigmentQuery
    {
        internal static string GetFesVideoCodeManagementByIdQuery(string contentId)
        {
            string query = string.Format("select デジドココンテンツID,背景映像コード,備考,最終更新日時,最終更新者,最終更新PC名 from Wii.dbo.[Fes映像コード管理]  where [デジドココンテンツID] = '{0}'", contentId);
            return query;
        }

        internal static string GetInsertFesVideoManagementQuery(DataTable dtRegist)
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

            string query = string.Format("INSERT INTO Wii.dbo.Fes映像コード管理({1}) VALUES({2})", Environment.MachineName.Replace("-", ""), columns, values);
            return query;
        }

        internal static string GetUpdateFesVideoManagementQuery(DataTable dtRegist)
        {
            DataRow row = dtRegist.Rows[0];
            string id = string.Empty;
            string columnValue = string.Empty;
            string values = string.Empty;
            foreach (DataColumn col in dtRegist.Columns)
            {
                if (col.ColumnName.Equals("デジドココンテンツID"))
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
            string query = string.Format("UPDATE  Wii.dbo.Fes映像コード管理 SET {0} WHERE デジドココンテンツID = {1} ", values, id);
            return query;
        }

        internal static string GetUpdateFesVideoManagementWorkQuery(string contentId)
        {
            string query = string.Format("UPDATE WiiTmp.dbo.[tbl_Wrk_Fes個別映像割付_{0}] set [更新日時] = null where デジドココンテンツID ='{1}'",
            Environment.MachineName.Replace(" -", ""), contentId);

            return query;
        }


        public static string GetFesAssigmentWorkUpdateQuery()
        {
            string query = string.Format("select [デジドココンテンツID] ,[背景映像コード] ,[備考] from WiiTmp.dbo.[tbl_Wrk_Fes個別映像割付_{0}] where[更新日時] is not null order by[Wii(デジドコ)選曲番号]", Environment.MachineName.Replace("-", ""));
            return query;
        }

        public static string GetFesVideoAssimentWorkTmpQuery()
        {
            string query = string.Format("SELECT 選択,[Wii(デジドコ)選曲番号] as Wiiデジドコ選曲番号 ,カラオケ選曲番号,楽曲名,歌手名,楽曲名検索用カナ,曲名よみがな補正,歌手名検索用カナ,背景映像コード,CONVERT(datetime,[アップ予定日]) as アップ予定日,CONVERT(datetime,[サービス発表日]) as サービス発表日,取消フラグ,[JV映像区分(背景映像区分)] as JV映像区分背景映像区分 ,備考,削除,CONVERT(datetime,[更新日時]) as 更新日時,デジドココンテンツID FROM WiiTmp.dbo.[tbl_Wrk_Fes個別映像割付_{0}] as t1 left join Wii.dbo.[Fes非公開理由] as t2 on t1.取消フラグ = t2.[取り消しID] order by [Wii(デジドコ)選曲番号]", Environment.MachineName.Replace(" -", ""));
            return query;
        }

        public static string GetCreateFesVideoAssigmentWorkTmpQuery(string tableName)
        {
            string query = string.Format("IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'{0}') AND type in (N'U')) BEGIN drop table {0} END; CREATE TABLE {0} (選択 [bit] NULL,Wiiデジドコ選曲番号[int] NULL,カラオケ選曲番号[int] NULL,楽曲名[nvarchar](150) NULL,歌手名	[nvarchar](100) NULL,楽曲名検索用カナ	[nvarchar](900) NOT NULL,曲名よみがな補正	[nvarchar](256) NULL,歌手名検索用カナ	[nvarchar](450) NULL,背景映像コード[nvarchar](7) NULL,アップ予定日[datetime] NULL,サービス発表日[datetime] NULL,取消フラグ[tinyint] NULL,JV映像区分背景映像区分[nvarchar](100) NULL,備考[nvarchar](255) NULL,削除[bit] NULL,更新日時[datetime] NULL,デジドココンテンツID	[int] NOT NULL PRIMARY KEY CLUSTERED ([デジドココンテンツID] ASC))", tableName);
            return query;
        }

        internal static string GetDeleteFesVideoWorkQuery()
        {
            string query = string.Format("delete from [WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}]  where [削除] = 1", Environment.MachineName.Replace("-", ""));
            return query;
        }

        public static string GetUpdateFesVideoAssigmentWorkTmpQuery(string tableName)
        {
            string query = string.Format("UPDATE [WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}] set 選択 = 0, 更新日時 =NULL;UPDATE [WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}] SET 選択 = t2.選択,[Wii(デジドコ)選曲番号] = t2.Wiiデジドコ選曲番号,カラオケ選曲番号 = t2.カラオケ選曲番号,楽曲名 = t2.楽曲名,歌手名 = t2.歌手名,楽曲名検索用カナ = t2.楽曲名検索用カナ,曲名よみがな補正 = t2.曲名よみがな補正,歌手名検索用カナ = t2.歌手名検索用カナ,背景映像コード = t2.背景映像コード,アップ予定日 = t2.アップ予定日,サービス発表日 = t2.サービス発表日,取消フラグ = t2.取消フラグ,[JV映像区分(背景映像区分)] = t2.JV映像区分背景映像区分,備考 = t2.備考,削除 = t2.削除,更新日時 = t2.更新日時,デジドココンテンツID = t2.デジドココンテンツID FROM [WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}] as t1 inner join {1} as t2 on t1.[デジドココンテンツID] = t2.デジドココンテンツID", Environment.MachineName.Replace("-", ""), tableName);
            return query;
        }

        internal static string GetInsertVideoAssimentWorkTmpQuery(List<string> slqParameters)
        {
            string query = string.Empty;
            query = GetInsertVideoAssimentWorkTmpQuery();
            // Input not set
            if (slqParameters.Count == 0)
            {
                query = query + "where [デジドココンテンツID] in ( select [デジドココンテンツID] from [v_デジ・ドココンテンツ] where [取消連番] = 0 )";
            }// User in put data
            else
            {
                string parameter = string.Empty;
                slqParameters.ToList().ForEach(para => parameter += para + " ");
                query = query + " where 1=1 " + parameter;
            }
            return query;
        }

        internal static string GetDeleteFesVideoManagementQuery()
        {
            string query = string.Format("delete from Wii.dbo.Fes映像コード管理  where [デジドココンテンツID] in (select [デジドココンテンツID] from [WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}]  where [削除] = 1)", Environment.MachineName.Replace("-", ""));
            return query;
        }

        public static string GetInsertVideoAssimentWorkTmpQuery()
        {
            string query = string.Format("insert into [WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}]([デジドココンテンツID] ,[Wii(デジドコ)選曲番号] ,[カラオケ選曲番号] ,[楽曲名] ,[歌手名] ,[楽曲名検索用カナ] ,[曲名よみがな補正] ,[歌手名検索用カナ] ,[背景映像コード] ,[アップ予定日] ,[サービス発表日] ,[取消フラグ] ,[JV映像区分(背景映像区分)] ,[備考] ) select [デジドココンテンツID] ,[Wii(デジドコ)選曲番号] ,[カラオケ選曲番号] ,[楽曲名] ,[歌手名] ,[楽曲名検索用カナ] ,[曲名よみがな補正] ,[歌手名検索用カナ] ,[背景映像コード] ,[アップ予定日] ,[サービス発表日] ,[取消フラグ] ,[JV映像区分(背景映像区分)] ,[備考] from Wii.dbo.[v_Fes映像コード管理] ", Environment.MachineName.Replace("-", ""));
            return query;
        }


        internal static string GetExportFesVideoAssigmentExportQuery(List<string> dataFilter)
        {
            string query = string.Format("SELECT [カラオケ選曲番号] AS [カラオケNo],[背景映像コード] AS [背景映像コード] FROM [WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}] ", Environment.MachineName.Replace(" -", "_"));
            if (dataFilter.Count > 0)
            {
                string songNumbers = string.Empty;
                foreach (var songNum in dataFilter)
                {
                    songNumbers += string.Format("{0},", songNum);
                }

                songNumbers = songNumbers.Remove(songNumbers.Length - 1);

                //Filter data
                if (!string.IsNullOrEmpty(songNumbers))
                    query += " where [デジドココンテンツID] in (" + songNumbers + ")";
            }
            query += " ORDER BY [カラオケ選曲番号]";
            return query;
        }

        internal static string GetTruncateVideoAssimentWorkTmpQuery()
        {
            string query = string.Format("Truncate table [WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}]", Environment.MachineName.Replace("-", ""));
            return query;
        }
    }
}
