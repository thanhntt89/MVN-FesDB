using System;
using System.Data;

namespace FestivalBusiness
{
    public static class RecommendSongQuery
    {
        internal static string GetRecommendSongTmpQuery()
        {
            string query = string.Format("SELECT 選択, t1.プログラムID, t2.プログラム名, [Wii(デジドコ)選曲番号] as Wiiデジドコ選曲番号,カラオケ選曲番号,楽曲名,歌手名,[FesDISCID] as FesDISCID,有料コンテンツフラグ, 有償情報フラグ, CONVERT(DATETIME, [サービス発表日]) as サービス発表日,取消フラグ, 表示順,削除, CONVERT(DATETIME, [更新日時]) as 更新日時, デジドココンテンツID, ID FROM WiiTmp.[dbo].[tbl_Wrk_Fesおすすめ曲管理_{0}] as t1 left join [Wii].[dbo].[Fesおすすめプログラム] as t2 on t1.プログラムID = t2.プログラムID order by t1.[プログラムID], [表示順], [Wii(デジドコ)選曲番号]", Environment.MachineName.Replace(" -", "_"));
            return query;
        }

        public static string GetCreateFesRecommendSongTmpQuery(string tableName)
        {
            string query = string.Format("IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'{0}') AND type in (N'U')) BEGIN drop table {0} END; CREATE TABLE {0}(選択[bit] NULL DEFAULT ((0)),プログラムID [int] NULL,プログラム名 [nvarchar](500) NULL,Wiiデジドコ選曲番号 [int] NULL,カラオケ選曲番号 [int] NULL,楽曲名 [nvarchar](150) NULL,歌手名 [nvarchar](100) NULL,FesDISCID [nvarchar](10) NULL,有料コンテンツフラグ [tinyint] NULL,有償情報フラグ [tinyint] NULL,サービス発表日[datetime] NULL,取消フラグ [int] NULL,表示順 [int] NULL,削除 [bit] NULL DEFAULT ((0)),更新日時 [datetime] NULL,デジドココンテンツID [int] NOT NULL,ID [int] NOT NULL)", tableName);
            return query;
        }

        internal static string GetUpdateFesRecommendSongTmpQuery(string tableName)
        {
            string query = string.Format("UPDATE [WiiTmp].[dbo].[tbl_Wrk_Fesおすすめ曲管理_{0}] set 選択 = 0, 更新日時 = NULL; UPDATE [WiiTmp].[dbo].[tbl_Wrk_Fesおすすめ曲管理_{0}] SET [プログラムID] = t2.プログラムID,[デジドココンテンツID] = t2.デジドココンテンツID,[Wii(デジドコ)選曲番号] = t2.Wiiデジドコ選曲番号,[カラオケ選曲番号] = t2.カラオケ選曲番号,[楽曲名] = t2.楽曲名,[歌手名] = t2.歌手名,[FesDISCID] = t2.FesDISCID,[有料コンテンツフラグ] = t2.有料コンテンツフラグ,[有償情報フラグ] = t2.有償情報フラグ,[サービス発表日] = CONVERT(VARCHAR,CONVERT(DATETIME,t2.サービス発表日),112) ,[取消フラグ] = t2.取消フラグ,[表示順] = t2.表示順,[選択] = t2.選択,[削除] = t2.削除,[更新日時] = t2.更新日時  FROM  [WiiTmp].[dbo].[tbl_Wrk_Fesおすすめ曲管理_{0}] as t1 inner join {1} as t2 on t1.[ID] = t2.ID; DROP TABLE {1};", Environment.MachineName.Replace(" -", "_"), tableName);
            return query;
        }

        public static string GetInsertRecommendSongTmpQuery()
        {
            string query = string.Format("insert into  WiiTmp.dbo.[tbl_Wrk_Fesおすすめ曲管理_{0}]([プログラムID],[デジドココンテンツID],[Wii(デジドコ)選曲番号],[カラオケ選曲番号],[楽曲名],[歌手名],[FesDISCID],[有料コンテンツフラグ],[有償情報フラグ],[サービス発表日],[取消フラグ],[表示順] ) select [プログラムID],[デジドココンテンツID],[Wii(デジドコ)選曲番号],[カラオケ選曲番号],[楽曲名],[歌手名],[FesDISCID],[有料コンテンツフラグ],[有償情報フラグ],[サービス発表日],[取消フラグ],[表示順] from Wii.dbo.[v_Fesおすすめ曲管理]", Environment.MachineName.Replace(" -", "_"));
            return query;
        }

        internal static string GetFesRecommendSongRegisTablelBySatusQuery(bool isKenkouSong, string progamId, string contentId, string displayOrder)
        {
            string tableRegister = "Wii.dbo.[Fes健康王国おすすめ曲管理]";
            string whereClause = string.Format(" where [デジドココンテンツID] = '{0}' and [表示順] = '{1}' ", contentId, displayOrder);

            if (!isKenkouSong)
            {
                tableRegister = "Wii.dbo.[Fesおすすめ曲管理]";
                whereClause += string.Format(" and [プログラムID] = '{0}'", progamId);
            }              

            string query = string.Format("select * from {0} {1}", tableRegister, whereClause);
            return query;
        }

        internal static string GetFeSongSelectionRelatedInfoQuery(string selectedId)
        {
            string query = string.Format("select  v1.[デジドココンテンツID] as デジドココンテンツID,v1.[カラオケ選曲番号] as カラオケ選曲番号 ,v1.[楽曲名] as 楽曲名 ,v1.[歌手名] as 歌手名 ,t2.[FesDISCID] as  FesDISCID,v1.[有料コンテンツフラグ] as 有料コンテンツフラグ,t2.[有償情報フラグ] as 有償情報フラグ,CONVERT(VARCHAR,CONVERT(DATETIME,  v1.[サービス発表日]),111) as  サービス発表日,v1.[取消フラグ] as 取消フラグ from  dbo.v_Fes選曲番号関連情報 as v1  left outer join  dbo.FesDISC追加削除管理 as t2 WITH (NOLOCK)  on  v1.[デジドココンテンツID] = t2.[デジドココンテンツID]  and t2.[追加削除区分] = 0  and t2.[削除フラグ] = 0 where [Wii(デジドコ)選曲番号] = {0}", selectedId);
            return query;
        }

        public static string GetDeleteRegisterRecommendSongTableQuery(bool isKenkouSong)
        {
            string strTable_Regist = "Wii.dbo.[Fes健康王国おすすめ曲管理]";
            if (!isKenkouSong)
            {
                strTable_Regist = "Wii.dbo.[Fesおすすめ曲管理]";
            }

            string query = string.Format("DELETE FROM {0} WHERE NOT exists (SELECT 'x' FROM WiiTmp.[dbo].[tbl_Wrk_Fesおすすめ曲管理_{1}] as t2 WHERE t2.[削除] = 0 and {0}.デジドココンテンツID = t2.デジドココンテンツID and {0}.表示順 = t2.表示順 ", strTable_Regist, Environment.MachineName.Replace("-", ""));
            if (isKenkouSong)
                query += " and t2.[プログラムID] is null )";
            else
                query += string.Format(" and t2.[プログラムID] is not null and {0}.プログラムID = t2.プログラムID)", strTable_Regist);

            return query;
        }

        public static string GetCreateRegisterRecommendSongTmpQuery(bool isKenkouSong, string tableName)
        {
            string query = string.Format("IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'{0}') AND type in (N'U')) BEGIN drop table {0} END; CREATE TABLE {0}( デジドココンテンツID [int] NOT NULL,表示順 [int] NOT NULL,最終更新日時 [datetime] NULL,最終更新者 [nvarchar](50) NULL,最終更新PC名 [nvarchar](50) NULL CONSTRAINT [PK_Fes健康王国おすすめ曲管理] PRIMARY KEY CLUSTERED ( [デジドココンテンツID] ASC, [表示順] ASC) )", tableName);
            if (!isKenkouSong)
                query = string.Format("IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'{0}') AND type in (N'U')) BEGIN drop table {0} END; CREATE TABLE {0}(プログラムID [int] NOT NULL,デジドココンテンツID [int] NOT NULL,表示順 [int] NOT NULL,最終更新日時 [datetime] NULL,最終更新者[nvarchar](50) NULL, 最終更新PC名[nvarchar](50) NULL CONSTRAINT[PK_Fesおすすめ曲管理] PRIMARY KEY CLUSTERED([プログラムID] ASC, [デジドココンテンツID] ASC, [表示順] ASC))", tableName);
            return query;
        }

        public static string GetUpdateRegisterRecommendSongQuery(bool isKenkouSong, string tableName)
        {
            string query = string.Format("UPDATE Wii.[dbo].[Fes健康王国おすすめ曲管理] SET [最終更新日時] = t2.[最終更新日時] ,[最終更新者] = t2.[最終更新者],[最終更新PC名] = t2.[最終更新PC名] FROM Wii.[dbo].[Fes健康王国おすすめ曲管理] as t1 inner join {0} as t2 on t1.[デジドココンテンツID] = t2.[デジドココンテンツID] and t1.[表示順] = t2.[表示順]; DROP TABLE {0}", tableName);
            if (!isKenkouSong)
                query = string.Format("UPDATE Wii.[dbo].[Fesおすすめ曲管理] SET [最終更新日時] = t2.[最終更新日時] ,[最終更新者] = t2.[最終更新者],[最終更新PC名] = t2.[最終更新PC名] FROM Wii.[dbo].[Fesおすすめ曲管理] as t1 inner join {0} as t2 on t1.[デジドココンテンツID] = t2.[デジドココンテンツID] and t1.[プログラムID] = t2.プログラムID and t1.[表示順] = t2.[表示順]; DROP TABLE {0}", tableName);
            return query;
        }

        public static string GetRegistrationPreCheckQuery(bool isKenkouSong)
        {
            string query = string.Format("select distinct  [プログラムID] from WiiTmp.[dbo].[tbl_Wrk_Fesおすすめ曲管理_{0}] where [デジドココンテンツID]  is null and [プログラムID] {1} ", Environment.MachineName.Replace(" -", "_"), isKenkouSong ? "is null" : "is not null");

            return query;
        }

        /// <summary>
        /// TRUE is not null
        /// FALSE is null
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        internal static string GetFesRecommendSongWorkTmpQuery(bool isKenkouSong)
        {
            string query = string.Format("select [デジドココンテンツID],[Wii(デジドコ)選曲番号],[表示順] from WiiTmp.[dbo].[tbl_Wrk_Fesおすすめ曲管理_{0}] where [プログラムID] {1} and [更新日時] is not null order by [表示順],[Wii(デジドコ)選曲番号]", Environment.MachineName.Replace(" -", "_"), "is null");
            if (!isKenkouSong)
                query = string.Format("select [プログラムID],[デジドココンテンツID],[Wii(デジドコ)選曲番号],[表示順] from WiiTmp.[dbo].[tbl_Wrk_Fesおすすめ曲管理_{0}] where [プログラムID] {1} and [更新日時] is not null order by [表示順],[Wii(デジドコ)選曲番号]", Environment.MachineName.Replace(" -", "_"), "is not null");
            return query;
        }

        internal static string GetDisplayOrderMutipleCheckQuery(bool isKenkouSong)
        {
            string query = string.Format("select iv1.[プログラムID] as [プログラムID],iv1.[表示順] as [表示順] from (select [プログラムID] ,[表示順],count([表示順]) as [件数] from WiiTmp.[dbo].[tbl_Wrk_Fesおすすめ曲管理_{0}] where  [削除] <> 1 and [プログラムID] {1} group by  [プログラムID],[表示順]) as iv1 where iv1.[件数] > 1 order by iv1.[プログラムID] ,iv1.[表示順]", Environment.MachineName.Replace(" -", "_"), isKenkouSong ? "is null" : "is not null");

            return query;
        }

        public static string GetTruncateRecommendSongTmpQuery()
        {
            string query = string.Format("TRUNCATE TABLE WiiTmp.dbo.[tbl_Wrk_Fesおすすめ曲管理_{0}]", Environment.MachineName.Replace(" -", "_"));
            return query;
        }

        public static string GetFesRecommendProgramQuery()
        {
            string query = string.Format("SELECT プログラムID ,CONCAT(プログラムID,' | ',プログラム名) as  プログラム名 ,備考  FROM [Wii].[dbo].[Fesおすすめプログラム]");
            return query;
        }
        internal static string GetFesRecommendProgramByIdQuery(string id)
        {
            string query = string.Format("SELECT プログラムID ,プログラム名 ,備考  FROM [Wii].[dbo].[Fesおすすめプログラム] where プログラムID={0}", id);
            return query;
        }


        internal static string GetUpdateFesRecommendWorkQuery(bool isKenkouSong)
        {
            string query = string.Format("update WiiTmp.dbo.[tbl_Wrk_Fesおすすめ曲管理_{0}] set [更新日時] = null where [更新日時] is not null and [プログラムID] is null", Environment.MachineName.Replace(" -", "_"));
            if (!isKenkouSong)
            {
                query = string.Format("update WiiTmp.dbo.[tbl_Wrk_Fesおすすめ曲管理_{0}] set [更新日時] = null where [更新日時] is not null and [プログラムID] is not null", Environment.MachineName.Replace(" -", "_"));
            }
            return query;
        }

        internal static string GetDeleteFesRecommendWorkTableQuery(bool isKenkouSong)
        {
            string query = string.Format("delete from WiiTmp.dbo.[tbl_Wrk_Fesおすすめ曲管理_{0}] where [削除] = 1 and [プログラムID] is null", Environment.MachineName.Replace(" -", "_"));
            if (!isKenkouSong)
            {
                query = string.Format("delete from WiiTmp.dbo.[tbl_Wrk_Fesおすすめ曲管理_{0}] where [削除] = 1 and [プログラムID] is not null", Environment.MachineName.Replace(" -", "_"));
            }
            return query;
        }

        internal static string GetSongSelectionQuery()
        {
            string query = string.Format("select  v1.選曲番号 from Wii.dbo.[v_Fesおすすめ曲管理] as t1 left join Wii.dbo.Fesサービス as t2 on t1.デジドココンテンツID = t2.デジドココンテンツID left join  Wii.dbo.[v_デジ・ドココンテンツ] v1 on  t1.デジドココンテンツID = v1.デジドココンテンツID where t2.サービス発表日 is null or t2.取消フラグ <> 0 ");
            return query;
        }

        internal static string GetInsertRecommendSongRegist(DataTable dtUpdateTable, bool isKenkouSong)
        {
            string query = string.Format("INSERT INTO  Wii.dbo.[Fes健康王国おすすめ曲管理] (デジドココンテンツID,表示順,最終更新日時,最終更新者,最終更新PC名) Values ('{0}','{1}',GETDATE(),'{2}','{3}')",
                dtUpdateTable.Rows[0]["デジドココンテンツID"],
                dtUpdateTable.Rows[0]["表示順"],
                dtUpdateTable.Rows[0]["最終更新者"],
                dtUpdateTable.Rows[0]["最終更新PC名"]
                );
            if (!isKenkouSong)
            {
                query = string.Format("INSERT INTO  Wii.dbo.[Fesおすすめ曲管理] (プログラムID,デジドココンテンツID,表示順,最終更新日時,最終更新者,最終更新PC名) Values ('{0}','{1}','{2}',GETDATE(),'{3}','{4}')",
                dtUpdateTable.Rows[0]["プログラムID"],
                dtUpdateTable.Rows[0]["デジドココンテンツID"],
                dtUpdateTable.Rows[0]["表示順"],
                dtUpdateTable.Rows[0]["最終更新者"],
                   dtUpdateTable.Rows[0]["最終更新PC名"]
                );
            }

            return query;
        }

        internal static string GetMaxIdRecommendSongWorkTableQuery()
        {
            string query = string.Format("select top (1) Id from  WiiTmp.dbo.[tbl_Wrk_Fesおすすめ曲管理_{0}] ORDER BY ID DESC",
                  Environment.MachineName.Replace(" -", "_"));
            return query;
        }

        internal static string GetInsertNewRowRecommendSongWorkTableQuery()
        {
            string query = string.Format("insert into  WiiTmp.dbo.[tbl_Wrk_Fesおすすめ曲管理_{0}]([更新日時]) VALUES (GETDATE())",
                   Environment.MachineName.Replace(" -", "_"));
            return query;
        }

        internal static string GetInsertRecommendSongWorkTableQuery(DataRow rowAdded)
        {
            string query = string.Format("insert into  WiiTmp.dbo.[tbl_Wrk_Fesおすすめ曲管理_{0}]([プログラムID],[デジドココンテンツID],[Wii(デジドコ)選曲番号],[カラオケ選曲番号],[楽曲名],[歌手名],[FesDISCID],[有料コンテンツフラグ],[有償情報フラグ],[サービス発表日],[取消フラグ],[表示順],[更新日時] ) VALUES ('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',CONVERT(VARCHAR,CONVERT(DATETIME,'{10}'),112),'{11}','{12}',GETDATE())",
                Environment.MachineName.Replace(" -", "_"),
                rowAdded.Field<object>("プログラムID") == null ? DBNull.Value : rowAdded.Field<object>("プログラムID"),
                rowAdded.Field<object>("デジドココンテンツID") == null ? DBNull.Value : rowAdded.Field<object>("デジドココンテンツID"),
                rowAdded.Field<object>("Wiiデジドコ選曲番号") == null ? DBNull.Value : rowAdded.Field<object>("Wiiデジドコ選曲番号"),
                rowAdded.Field<object>("カラオケ選曲番号") == null ? DBNull.Value : rowAdded.Field<object>("カラオケ選曲番号"),
                rowAdded.Field<object>("楽曲名") == null ? string.Empty : rowAdded.Field<object>("楽曲名").ToString().Replace("'", "''"),
                rowAdded.Field<object>("歌手名") == null ? string.Empty : rowAdded.Field<object>("歌手名").ToString().Replace("'", "''"),
                rowAdded.Field<object>("FesDISCID") == null ? DBNull.Value : rowAdded.Field<object>("FesDISCID"),
                rowAdded.Field<object>("有料コンテンツフラグ") == null ? DBNull.Value : rowAdded.Field<object>("有料コンテンツフラグ"),
                rowAdded.Field<object>("有償情報フラグ") == null ? DBNull.Value : rowAdded.Field<object>("有償情報フラグ"),
                rowAdded.Field<object>("サービス発表日") == null ? DBNull.Value : rowAdded.Field<object>("サービス発表日"),
                rowAdded.Field<object>("取消フラグ") == null ? DBNull.Value : rowAdded.Field<object>("取消フラグ"),
                rowAdded.Field<object>("表示順") == null ? DBNull.Value : rowAdded.Field<object>("表示順")               
                );
            return query;
        }

        internal static string GetUpdateRecommendSongRegist(DataTable dtUpdateTable, bool isKenkouSong)
        {
            string strTable_Regist = "Wii.dbo.[Fes健康王国おすすめ曲管理]";
            if (!isKenkouSong)
            {
                strTable_Regist = "Wii.dbo.[Fesおすすめ曲管理]";
            }

            string query = string.Format("Update {0} SET 最終更新日時= GETDATE(),最終更新者='{1}',最終更新PC名 ='{2}', 表示順='{3}' where [デジドココンテンツID] = {4}",
                strTable_Regist,
                dtUpdateTable.Rows[0]["最終更新者"],
                dtUpdateTable.Rows[0]["最終更新PC名"],
                dtUpdateTable.Rows[0]["表示順"],
                dtUpdateTable.Rows[0]["デジドココンテンツID"]
                );
            if (!isKenkouSong)
            {
                query = string.Format("Update  {0} SET 最終更新日時= GETDATE(),最終更新者='{1}',最終更新PC名 ='{2}', 表示順 ='{3}' , [プログラムID] ='{4}' where [デジドココンテンツID] = {5}",
                    strTable_Regist,
               dtUpdateTable.Rows[0]["最終更新者"],
               dtUpdateTable.Rows[0]["最終更新PC名"],
               dtUpdateTable.Rows[0]["表示順"],
               dtUpdateTable.Rows[0]["プログラムID"],
               dtUpdateTable.Rows[0]["デジドココンテンツID"]
               );
            }

            return query;
        }


    }
}
