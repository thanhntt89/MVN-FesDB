using FestivalCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FestivalBusiness
{
    public class FesVideoAssigmentQuery
    {
        internal static string GetUpdateColumnNameQuery(List<string> keys, string columnKey, string columName, object value, ref Parameters param)
        {
            string parameters = string.Empty;
            keys.ToList().ForEach(para => parameters += para + ",");
            //Removed lastid
            if (parameters.Length > 0 || parameters.LastIndexOf(',', parameters.Length - 1) == 0)
                parameters = parameters.Remove(parameters.Length - 1, 1);

            param.Add(new Parameter()
            {
                Name = string.Format("@{0}", columName),
                Values = value
            });
            string query = string.Format("UPDATE WiiTmp.dbo.[tbl_Wrk_Fes個別映像割付_{0}] set {1} = @{1},更新日時 = GetDate() where {2} in ({3})", Environment.MachineName.Replace("-", ""), columName, columnKey, parameters);
            return query;
        }

        internal static string GetUpdateFieldQuery(string IdUpdate, string fielName, object filedValue, ref Parameters param, bool isUpdateDate = true)
        {
            param.Add(new Parameter()
            {
                Name = string.Format("@デジドココンテンツID"),
                Values = IdUpdate
            });
            param.Add(new Parameter()
            {
                Name = string.Format("@{0}", fielName),
                Values = filedValue
            });
            string query = string.Empty;


            if (isUpdateDate)
            {
                query = string.Format("UPDATE WiiTmp.dbo.[tbl_Wrk_Fes個別映像割付_{0}] set {1} = @{1}, 更新日時 = GetDate() where [デジドココンテンツID] = @{2}", Environment.MachineName.Replace("-", ""), fielName, IdUpdate);
            }
            else
            {
                query = string.Format("UPDATE WiiTmp.dbo.[tbl_Wrk_Fes個別映像割付_{0}] set {1} = @{1} where [デジドココンテンツID] = @{2}", Environment.MachineName.Replace("-", ""), fielName, IdUpdate);
            }

            return query;
        }


        internal static string GetFesVideoCodeManagementByIdQuery(string contentId, ref Parameters param)
        {
            param.Add(new Parameter()
            {
                Name = string.Format("@デジドココンテンツID"),
                Values = contentId
            });
            string query = string.Format("select デジドココンテンツID,背景映像コード,個別映像ロック,備考,最終更新日時,最終更新者,最終更新PC名 from Wii.dbo.[Fes映像コード管理]  where [デジドココンテンツID] = @デジドココンテンツID");
            return query;
        }


        internal static string GetInsertFesVideoQuery(DataTable dtRegist, ref Parameters param)
        {
            string query = string.Empty;
            string columns = string.Empty;
            string values = string.Empty;
            DataRow row = dtRegist.Rows[0];

            foreach (DataColumn col in dtRegist.Columns)
            {
                columns += string.Format("[{0}],", col.ColumnName);

                values += string.Format("@{0},", col.ColumnName);

                param.Add(new Parameter()
                {
                    Name = string.Format("@{0}", col.ColumnName),
                    Values = col.ColumnName.Equals("最終更新日時") ? DateTime.Now : row[col]
                });

            }
            columns = columns.Remove(columns.Length - 1, 1);
            values = values.Remove(values.Length - 1, 1);

            query = string.Format("INSERT INTO Wii.dbo.Fes映像コード管理({0}) VALUES({1})", columns, values);
            return query;
        }

        internal static string GetUpdateFesVideoQuery(DataTable dtRegist, ref Parameters param)
        {
            string query = string.Empty;
            string values = string.Empty;
            DataRow row = dtRegist.Rows[0];
            string id = string.Empty;

            foreach (DataColumn col in dtRegist.Columns)
            {
                if (!col.ColumnName.Equals("デジドココンテンツID"))
                {
                    values += string.Format("{0} = @{0},", col.ColumnName);
                }

                param.Add(new Parameter()
                {
                    Name = string.Format("@{0}", col.ColumnName),
                    Values = col.ColumnName.Equals("最終更新日時") ? DateTime.Now : row[col]
                });
            }

            values = values.Remove(values.Length - 1, 1);

            query = string.Format("UPDATE  Wii.dbo.Fes映像コード管理 SET {0} WHERE デジドココンテンツID = @デジドココンテンツID ", values);
            return query;
        }

        internal static string GetUpdateFesVideoManagementWorkQuery(string contentId, ref Parameters param)
        {
            param.Add(new Parameter()
            {
                Name = string.Format("@デジドココンテンツID"),
                Values = contentId
            });

            string query = string.Format("UPDATE WiiTmp.dbo.[tbl_Wrk_Fes個別映像割付_{0}] set [更新日時] = null where デジドココンテンツID = @デジドココンテンツID",
            Environment.MachineName.Replace("-", ""));

            return query;
        }


        public static string GetFesAssigmentWorkUpdateQuery()
        {
            string query = string.Format("select [デジドココンテンツID] ,[背景映像コード] ,[個別映像ロック],[備考] from WiiTmp.dbo.[tbl_Wrk_Fes個別映像割付_{0}] where[更新日時] is not null order by[Wii(デジドコ)選曲番号]", Environment.MachineName.Replace("-", ""));
            return query;
        }

        public static string GetFesVideoAssimentWorkTmpQuery()
        {
            string query = string.Format("SELECT 選択,[Wii(デジドコ)選曲番号] as Wiiデジドコ選曲番号 ,カラオケ選曲番号,楽曲名,歌手名,楽曲名検索用カナ,曲名よみがな補正,歌手名検索用カナ,コンテンツ種類 as コンテンツ種類ID,背景映像コード,背景映像コード as Old背景映像コード,個別映像ロック,(case when 個別映像ロック = 1 AND t3.BackgroundVideoLock = 1 AND t4.[ContentType] is not null then '{0}/{1}/{2}' when 個別映像ロック = 1 AND t3.BackgroundVideoLock = 1 then '{0}/{1}' when 個別映像ロック = 1 AND t4.[ContentType] is not null then '{0}/{2}' when t3.BackgroundVideoLock = 1 AND t4.[ContentType] is not null then '{1}/{2}' when 個別映像ロック = 1 then '{0}' when t3.BackgroundVideoLock = 1 then '{1}' when t4.[ContentType] is not null then '{2}' end) as 映像ロック対象,Old個別映像ロック,CONVERT(datetime,[アップ予定日]) as アップ予定日,CONVERT(datetime,[サービス発表日]) as サービス発表日,取消フラグ,[JV映像区分(背景映像区分)] as JV映像区分背景映像区分 ,備考,削除,CONVERT(datetime,[更新日時]) as 更新日時,デジドココンテンツID FROM WiiTmp.dbo.[tbl_Wrk_Fes個別映像割付_{3}] as t1 left join Wii.dbo.[Fes非公開理由] as t2 on t1.取消フラグ = t2.[取り消しID] left join [dbo].[VideoCodeLock] as t3 on t1.背景映像コード = t3.VideoCode left join [dbo].[FestaVideoLock] as t4 on t1.コンテンツ種類 = t4.[ContentType] order by [Wii(デジドコ)選曲番号]", Constants.VIDEO_LOCK_TYPE_INDIVIDUAL, Constants.VIDEO_LOCK_TYPE_NO_CHANGE, Constants.VIDEO_LOCK_TYPE_FESTA, Environment.MachineName.Replace("-", ""));

            return query;
        }

        public static string GetCreateFesVideoAssigmentWorkTmpQuery(string tableName)
        {
            string query = string.Format("IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'{0}') AND type in (N'U')) BEGIN drop table {0} END; CREATE TABLE {0} (選択 [bit] NULL,Wiiデジドコ選曲番号[int] NULL,カラオケ選曲番号[int] NULL,楽曲名[nvarchar](150) NULL,歌手名	[nvarchar](100) NULL,楽曲名検索用カナ	[nvarchar](900) NOT NULL,曲名よみがな補正	[nvarchar](256) NULL,歌手名検索用カナ	[nvarchar](450) NULL,コンテンツ種類[int] NULL,背景映像コード[nvarchar](7) NULL,Old背景映像コード[nvarchar](7) NULL,個別映像ロック[int] NULL,Old個別映像ロック[int] NULL,アップ予定日[datetime] NULL,サービス発表日[datetime] NULL,取消フラグ[tinyint] NULL,JV映像区分背景映像区分[nvarchar](100) NULL,備考[nvarchar](255) NULL,削除[bit] NULL,更新日時[datetime] NULL,デジドココンテンツID [int] NOT NULL PRIMARY KEY CLUSTERED ([デジドココンテンツID] ASC))", tableName);
            return query;
        }

        internal static string GetDeleteFesVideoWorkQuery()
        {
            string query = string.Format("delete from [WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}]  where [削除] = 1", Environment.MachineName.Replace("-", ""));
            return query;
        }

        public static string GetUpdateFesVideoAssigmentWorkTmpQuery(string tableName)
        {
            string query = string.Format("UPDATE [WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}] set 選択 = 0, 更新日時 = NULL;UPDATE [WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}] SET 選択 = t2.選択,[Wii(デジドコ)選曲番号] = t2.Wiiデジドコ選曲番号,カラオケ選曲番号 = t2.カラオケ選曲番号,楽曲名 = t2.楽曲名,歌手名 = t2.歌手名,楽曲名検索用カナ = t2.楽曲名検索用カナ,曲名よみがな補正 = t2.曲名よみがな補正,歌手名検索用カナ = t2.歌手名検索用カナ,コンテンツ種類 = t2.コンテンツ種類,背景映像コード = t2.背景映像コード,個別映像ロック =t2.個別映像ロック, アップ予定日 = t2.アップ予定日,サービス発表日 = t2.サービス発表日,取消フラグ = t2.取消フラグ,[JV映像区分(背景映像区分)] = t2.JV映像区分背景映像区分,備考 = t2.備考,削除 = t2.削除,更新日時 = t2.更新日時,デジドココンテンツID = t2.デジドココンテンツID FROM [WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}] as t1 inner join {1} as t2 on t1.[デジドココンテンツID] = t2.デジドココンテンツID", Environment.MachineName.Replace("-", ""), tableName);
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

        internal static string GetDeleteFesVideoManagementQueryFromFesContents()
        {
            string query = string.Format("delete from Wii.dbo.Fes映像コード管理  where [デジドココンテンツID] in (select [デジドココンテンツID] from [WiiTmp].[dbo].[tbl_Wrk_Fesコンテンツ_{0}]  where [削除] = 1)", Environment.MachineName.Replace("-", ""));
            return query;
        }

        public static string GetInsertVideoAssimentWorkTmpQuery()
        {
            string query = string.Format("insert into [WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}]([デジドココンテンツID] ,[Wii(デジドコ)選曲番号] ,[カラオケ選曲番号] ,[楽曲名] ,[歌手名] ,[楽曲名検索用カナ] ,[曲名よみがな補正] ,[歌手名検索用カナ] ,[コンテンツ種類],[背景映像コード],[Old背景映像コード],[個別映像ロック],[Old個別映像ロック],[アップ予定日] ,[サービス発表日] ,[取消フラグ] ,[JV映像区分(背景映像区分)] ,[備考] ) select [デジドココンテンツID] ,[Wii(デジドコ)選曲番号] ,[カラオケ選曲番号] ,[楽曲名] ,[歌手名] ,[楽曲名検索用カナ] ,[曲名よみがな補正] ,[歌手名検索用カナ] ,[コンテンツ種類],[背景映像コード],[背景映像コード],[個別映像ロック],[個別映像ロック],[アップ予定日] ,[サービス発表日] ,[取消フラグ] ,[JV映像区分(背景映像区分)] ,[備考] from Wii.dbo.[v_Fes映像コード管理_21] ", Environment.MachineName.Replace("-", ""));
            return query;
        }


        internal static string GetExportFesVideoAssigmentExportQuery(List<string> dataFilter)
        {
            string query = string.Format("SELECT [カラオケ選曲番号] AS [カラオケNo],[背景映像コード] AS [背景映像コード] FROM [WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}] ", Environment.MachineName.Replace("-", "_"));
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

        internal static string GetCreateNewColumnsQuery()
        {
            string query = string.Format("IF COL_LENGTH('[Wii].[dbo].[Fes映像コード管理]', '個別映像ロック') IS NULL BEGIN ALTER TABLE [Wii].[dbo].[Fes映像コード管理] ADD 個別映像ロック INT; END;");
            return query;
        }

        internal static string GetCreateNewColumnsTableTmpQuery()
        {
            string query = string.Format("use [WiiTmp]; IF COL_LENGTH('[WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}]', '個別映像ロック') IS NULL BEGIN ALTER TABLE [WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}] ADD 個別映像ロック INT; END; IF COL_LENGTH('[WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}]', 'コンテンツ種類') IS NULL BEGIN ALTER TABLE [WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}] ADD コンテンツ種類 INT; END;IF COL_LENGTH('[WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}]', 'Old背景映像コード') IS NULL BEGIN ALTER TABLE [WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}] ADD Old背景映像コード nvarchar(7); END;IF COL_LENGTH('[WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}]', 'Old個別映像ロック') IS NULL BEGIN ALTER TABLE [WiiTmp].[dbo].[tbl_Wrk_Fes個別映像割付_{0}] ADD Old個別映像ロック INT; END;", Environment.MachineName.Replace("-", ""));
            return query;
        }
       
    }
}
