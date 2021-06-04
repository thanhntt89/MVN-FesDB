using FestivalCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace FestivalBusiness
{
    public class FesContentQuery
    {
        public static string GetSaveUpdateDataFesServiceQuery(string contentId)
        {
            string query = string.Format("select [デジドココンテンツID],[アップ予定日],[サービス発表日],[ライツ用サービス発表日],[検索表示可否フラグ],[取消フラグ],[停止日],[削除情報],[録画可否フラグ],[録音可否フラグ],[有料コンテンツフラグ],[著作権備考],[備考],[Fesアレンジコード],[邦題優先フラグ],[曲名補正],[かなNULLフラグ],[曲名よみがな補正],[曲名ソート補正],[映像区分],[歌手ID補正],[INTRO_TYPE補正],[最終更新日時],[最終更新者],[最終更新PC名],[新譜本扱月],[曲名ソート英字補正],[演奏時間補正],[支援レベル],[チャプターフラグ],[個別映像ロック] from  Wii.dbo.[Fesサービス] where  [デジドココンテンツID] = '{0}'", contentId);
            return query;
        }

        public static string GetSaveUpdateDataFescontentQuery()
        {
            string query = string.Format("select [デジドココンテンツID] ,[アップ予定日] ,[サービス発表日],[ライツ用サービス発表日] ,[検索表示可否フラグ] ,[取消フラグ] ,[停止日] ,[削除情報] ,[録画可否フラグ] ,[録音可否フラグ] ,[有料コンテンツフラグ] ,[チャプターフラグ]    ,[著作権備考] ,[備考]  ,[Fesアレンジコード] ,[楽曲名邦題] ,[邦題優先フラグ],[曲名補正] ,[かなNULLフラグ] ,[曲名よみがな補正] ,[曲名ソート補正] ,[曲名ソート英字補正] ,[歌手ID補正] ,[映像区分] ,[Wii(デジドコ)選曲番号] ,[表示用Fesアレンジコード] ,[INTRO_TYPE補正] ,[新譜本扱月] ,[演奏時間補正] ,[支援レベル],[背景映像コード],[個別映像ロック] from WiiTmp.dbo.[tbl_Wrk_Fesコンテンツ_{0}] where [更新日時] is not null order by [Wii(デジドコ)選曲番号] ", Environment.MachineName.Replace("-", "_"));

            return query;
        }

        public static string GetDeleteRegisteredFesContentQuery()
        {
            string query = string.Format("delete from Wii.dbo.[Fesサービス] where [デジドココンテンツID] in ( select [デジドココンテンツID] from WiiTmp.dbo.[tbl_Wrk_Fesコンテンツ_{0}] where [削除] = 1 )", Environment.MachineName.Replace("-", "_"));
            return query;
        }

        public static string GetExportFesContentExportQuery(List<string> SongNumberList)
        {
            string query = string.Format("SELECT  CONVERT(VARCHAR,CONVERT(DATETIME, GETDATE()),112) + replace(convert(varchar, getdate(),108),':','')  AS [処理日時] ,[Wii(デジドコ)選曲番号] AS [デジドコNo] ,[カラオケ選曲番号] AS [カラオケNo] ,CONVERT(VARCHAR,CONVERT(DATETIME, [サービス発表日]),111) AS [Fes_サービス発表日] ,CONVERT(VARCHAR,CONVERT(DATETIME, [Wii_U_サービス発表日]),111) AS [Orch_サービス発表日] ,[Wii_U_取消フラグ]  AS [Orch_取消フラグ] from WiiTmp.dbo.[tbl_Wrk_Fesコンテンツ_{0}] ", Environment.MachineName.Replace("-", "_"));
            if (SongNumberList.Count > 0)
            {
                string songNumbers = string.Empty;
                foreach (var songNum in SongNumberList)
                {
                    songNumbers += string.Format("{0},", songNum);
                }

                songNumbers = songNumbers.Remove(songNumbers.Length - 1);

                //Filter data
                if (!string.IsNullOrEmpty(songNumbers))
                    query += " where [デジドココンテンツID] in (" + songNumbers + ")";
            }
            query += " ORDER BY [Wii(デジドコ)選曲番号]";
            return query;
        }

        public static string GetExportContentSongListQuery(List<string> SongNumberList)
        {
            string query = string.Format("SELECT t1.[Wii(デジドコ)選曲番号] AS [デジドコNo],t1.[カラオケ選曲番号] AS [カラオケNo],t1.[親選曲番号] AS [親カラオケNo],t1.[コンテンツ種類] AS [コンテンツ種類],t1.[配信マーク] AS [配信マーク],t1.[表示用Fesアレンジコード] AS [Fesアレンジコード(自動設定)],t1.[Fesアレンジコード] AS [Fesアレンジコード(補正)],t1.[カラオケアレンジコード] AS [カラオケアレンジコード],t1.[アレンジ名] AS [アレンジ名],t1.[かなNULLフラグ] AS [かなNULLフラグ],t1.[楽曲名] AS [曲名(MARY)],t1.[曲名補正]  AS [曲名補正],t1.[楽曲名検索用カナ] AS [曲名カナ],t1.[曲名よみがな補正] AS [曲名カナ補正],t1.[楽曲名ソート用かな] AS [曲名ソート],t1.[曲名ソート補正]  AS [曲名ソート補正],t1.[楽曲名検索ソート英字] AS [曲名ソート英数],t1.[曲名ソート英字補正] AS [曲名ソート英数補正],t1.[カラオケ楽曲名] AS [曲名(Ca)],t1.[カラオケ楽曲名かな] AS [曲名カナ(Ca)],t1.[邦題優先フラグ] AS [邦題優先フラグ],t1.[楽曲名邦題] AS [邦題],t1.[楽曲名邦題かな]  AS [邦題カナ],t1.[PU_ARTIST_ID] AS [PU_ARTIST_ID],t1.[歌手ID補正] AS [歌手ID補正],t1.[歌手名]  AS [歌手名],t2.[歌手名]  AS [歌手名補正],t1.[歌手名検索用カナ] AS [歌手名カナ],t2.[歌手名検索用カナ]  AS [歌手名カナ補正],t1.[歌手名ソート用カナ] AS [歌手名ソート],t2.[歌手名ソート用カナ]  AS [歌手名ソート補正],t1.[歌手名検索ソート英字] AS [歌手名ソート英数],t2.[歌手名ソート用英数] AS [歌手名ソート英数補正],(case when t1.[Fesアレンジコード] = 2 then t1.[SONG_GROUP_INTRO_TYPE] else t1.[INTRO_TYPE] end ) AS [INTRO_TYPE] ,t1.[INTRO_TYPE補正] AS [INTRO_TYPE補正],t1.[COUNTRY_CODE] AS[COUNTRY_CODE],t1.[歌いだし]AS[歌いだし],t1.[原曲比] AS [原曲比],t1.[演奏時間]AS[演奏時間],t1.[演奏時間補正]AS[演奏時間(補正)],t1.[支援レベル]AS[支援レベル],t1.[原曲比2]AS[原曲比2],t1.[情報欄_JSTYLE] AS [情報欄_JSTYLE],t1.[カラオケ削除情報] AS [削除情報],t1.[発売日] AS [発売日],t1.[新譜本扱月] AS [新譜本扱月],t1.[歌唱可能日] AS [歌唱可能日],t1.[カラオケ完パケ期限日] AS [カラオケ完パケ期限日],t1.[カラオケ完パケ日] AS [カラオケ完パケ日],t1.[アップ予定日] AS [Fes_アップ予定日],t1.[サービス発表日] AS [Fes_サービス発表日],t1.[ライツ用サービス発表日]AS[Fes_ライツ用サービス発表日],t1.[検索表示可否フラグ] AS [Fes_検索表示可否フラグ],t1.[取消フラグ] AS [Fes_取消フラグ],t1.[停止日] AS [Fes_停止日],t1.[削除情報] AS [Fes_削除情報],t1.[FesDISCID]AS[Fes_DISCID_V1],t1.[FesDISCID(Ver2)] AS [Fes_DISCID_V2],t1.[NET利用フラグ] AS [Fes_NET利用フラグ_V1],t1.[NET利用フラグ(Ver2)] AS [Fes_NET利用フラグ_V2],t1.[録画可否フラグ]AS[Fes_録画可否フラグ],t1.[録音可否フラグ]AS[Fes_録音可否フラグ],t1.[有料コンテンツフラグ] AS [Fes_有料コンテンツフラグ],t1.[チャプターフラグ] AS [Fes_チャプターフラグ],t1.[Wii_U_制作完了日]AS[Orch_制作完了日],t1.[Wii_U_サービス発表日]AS[Orch_サービス発表日],t1.[Wii_U_取消フラグ] AS [Orch_取消フラグ],t1.[Wii_U_停止日] AS [Orch_停止日],t1.[Wii_U_削除情報] AS [Orch_削除情報],t1.[Wii_U_録画可否フラグ]AS[Orch_録画可否フラグ],t1.[Wii_U_録音可否フラグ]AS[Orch_録音可否フラグ],t1.[Wii_U_無料配信フラグ] AS [Orch_無料配信フラグ],t1.[JV映像区分(背景映像区分)] AS [JV映像区分(背景映像区分)],t1.[映像ジャンル]AS[映像ジャンル],t1.[映像区分] AS [Fes_映像ジャンル],t1.[背景映像コード] AS [背景映像コード],t1.[著作権備考] AS [著作権備考],t1.[備考]AS[備考],t1.[登録日時]AS[登録日時] from WiiTmp.dbo.[tbl_Wrk_Fesコンテンツ_{0}] as t1 left outer join dbo.Fes独自歌手管理 as t2 on t1.[歌手ID補正] = t2.[Fes独自歌手ID]", Environment.MachineName.Replace(" -", "_"));
            if (SongNumberList.Count > 0)
            {
                string songNumbers = string.Empty;
                foreach (var songNum in SongNumberList)
                {
                    songNumbers += string.Format("{0},", songNum);
                }

                songNumbers = songNumbers.Remove(songNumbers.Length - 1);

                //Filter data
                if (!string.IsNullOrEmpty(songNumbers))
                    query += " where [デジドココンテンツID] in (" + songNumbers + ")";
            }
            query += " ORDER BY [Wii(デジドコ)選曲番号]";

            return query;
        }

        public static string GetSelectFesContentSql()
        {
            string query = string.Format("Select [選択] as 選択,[Wii(デジドコ)選曲番号] as Wiiデジドコ選曲番号,[カラオケ選曲番号] as カラオケ選曲番号,[親選曲番号] as 親選曲番号,t3.CONTENT_TYPE_NAME as コンテンツ種類,[配信マーク] as 配信マーク,[表示用Fesアレンジコード] as 表示用Fesアレンジコード,[Fesアレンジコード] as Fesアレンジコード,[カラオケアレンジコード] as カラオケアレンジコード,[アレンジ名] as アレンジ名,[かなNULLフラグ] as かなNULLフラグ,[楽曲名] as 楽曲名,[曲名補正] as 曲名補正,[楽曲名検索用カナ] as 楽曲名検索用カナ,[曲名よみがな補正] as 曲名よみがな補正,[楽曲名ソート用かな] as 楽曲名ソート用かな,[曲名ソート補正] as 曲名ソート補正,[楽曲名検索ソート英字] as 楽曲名検索ソート英字,[曲名ソート英字補正] as 曲名ソート英字補正,[カラオケ楽曲名] as カラオケ楽曲名,[カラオケ楽曲名かな] as カラオケ楽曲名かな,[邦題優先フラグ] as 邦題優先フラグ,[楽曲名邦題] as 楽曲名邦題,[楽曲名邦題かな] as 楽曲名邦題かな,[PU_ARTIST_ID] as PU_ARTIST_ID,[歌手ID補正] as 歌手ID補正,t1.[歌手名] as 歌手名,t2.[歌手名] as  歌手名補正,t1.[歌手名検索用カナ] as 歌手名検索用カナ,t2.[歌手名検索用カナ] as  歌手名カナ補正,t1.[歌手名ソート用カナ] as 歌手名ソート用カナ,t2.[歌手名ソート用カナ] as  歌手名ソート補正,[歌手名検索ソート英字] as 歌手名検索ソート英字,t2.[歌手名ソート用英数] as  歌手名ソート英数補正,(CASE WHEN [Fesアレンジコード] = 2 THEN [SONG_GROUP_INTRO_TYPE] ELSE [INTRO_TYPE] end ) as INTRO_TYPE,[INTRO_TYPE補正] as INTRO_TYPE補正,[COUNTRY_CODE] as COUNTRY_CODE,[歌いだし] as 歌いだし,[演奏時間] as 演奏時間,[演奏時間補正] as 演奏時間補正,[支援レベル] as 支援レベル,[原曲比] as 原曲比,[原曲比2] as 原曲比2,[情報欄_JSTYLE] as 情報欄_JSTYLE,[カラオケ削除情報] as カラオケ削除情報,CONVERT(datetime,[発売日], 111) as 発売日,[新譜本扱月] as 新譜本扱月,CONVERT(datetime,[歌唱可能日], 111) as 歌唱可能日,CONVERT(datetime,[カラオケ完パケ期限日], 111) as カラオケ完パケ期限日,CONVERT(datetime,[カラオケ完パケ日], 111) as カラオケ完パケ日,CONVERT(datetime,[アップ予定日], 111) as アップ予定日,CONVERT(datetime,[サービス発表日], 111) as サービス発表日,CONVERT(datetime,[ライツ用サービス発表日], 111) as ライツ用サービス発表日,[検索表示可否フラグ] as 検索表示可否フラグ,[取消フラグ] as 取消フラグ,CONVERT(datetime,[停止日],111) as 停止日,[削除情報] as 削除情報,[FesDISCID] as FesDISCID,[FesDISCID(Ver2)] as FesDISCIDVer2,[NET利用フラグ] as NET利用フラグ,[NET利用フラグ(Ver2)] as NET利用フラグVer2,[録画可否フラグ] as 録画可否フラグ,[録音可否フラグ] as 録音可否フラグ,[有料コンテンツフラグ] as 有料コンテンツフラグ,[チャプターフラグ] as チャプターフラグ,CONVERT(datetime,[Wii_U_制作完了日], 111) as Wii_U_制作完了日,CONVERT(datetime,[Wii_U_サービス発表日], 111) as Wii_U_サービス発表日,[Wii_U_取消フラグ] as Wii_U_取消フラグ,CONVERT(datetime,[Wii_U_停止日], 111) as Wii_U_停止日,[Wii_U_削除情報] as Wii_U_削除情報,[Wii_U_録画可否フラグ] as Wii_U_録画可否フラグ,[Wii_U_録音可否フラグ] as Wii_U_録音可否フラグ,[Wii_U_無料配信フラグ] as Wii_U_無料配信フラグ,[JV映像区分(背景映像区分)] as JV映像区分背景映像区分,[映像ジャンル] as 映像ジャンル,[映像区分] as 映像区分,t1.[コンテンツ種類] AS [コンテンツ種類ID],[背景映像コード] as 背景映像コード,[背景映像コード] as Old背景映像コード,個別映像ロック, 個別映像ロック as Old個別映像ロック,(case when 個別映像ロック = 1 AND t4.BackgroundVideoLock = 1 AND t5.[ContentType] is not null then '映像ロック曲/背景映像変更NG曲/プレミアムコンテンツ曲' when 個別映像ロック = 1 AND t4.BackgroundVideoLock = 1 then '映像ロック曲/背景映像変更NG曲' when 個別映像ロック = 1 AND t5.[ContentType] is not null then '映像ロック曲/プレミアムコンテンツ曲' when t4.BackgroundVideoLock = 1 AND t5.[ContentType] is not null then '背景映像変更NG曲/プレミアムコンテンツ曲' when 個別映像ロック = 1 then '映像ロック曲' when t4.BackgroundVideoLock = 1 then '背景映像変更NG曲' when t5.[ContentType] is not null then 'プレミアムコンテンツ曲' end ) as 映像ロック対象,[著作権備考] as 著作権備考,[備考] as 備考,[削除] as 削除,CONVERT(datetime,CONVERT(varchar(8), [登録日時]),111) as 登録日時,[Artist_Id] as Artist_Id,CONVERT(datetime,[更新日時],111) as 更新日時,[SONG_GROUP_INTRO_TYPE] as SONG_GROUP_INTRO_TYPE,[デジドココンテンツID] as デジドココンテンツID FROM [WiiTmp].[dbo].[tbl_Wrk_Fesコンテンツ_{0}] as t1 left join Wii.dbo.[Fes独自歌手管理] as t2 on  t1.歌手ID補正 = t2.Fes独自歌手ID left join[XKara].[xdb].[XDB_M_CONTENT_TYPE] as t3 on  CAST(t1.[コンテンツ種類] as varbinary) =  CAST(t3.CONTENT_TYPE_KBN as varbinary) left join [dbo].[VideoCodeLock] as t4 on t1.背景映像コード = t4.VideoCode left join [dbo].[FestaVideoLock] as t5 on t1.コンテンツ種類 = t5.[ContentType] ORDER BY[Wii(デジドコ)選曲番号]", Environment.MachineName.Replace(" -", "_"));

            return query;
        }

        internal static string GetDeleteFesContentWorkQuery()
        {
            string query = string.Format("delete from WiiTmp.dbo.[tbl_Wrk_Fesコンテンツ_{0}] where [削除] = 1", Environment.MachineName.Replace("-", "_"));
            return query;
        }

        internal static string GetUpdateFesContentWorkTableQuery(string contentId)
        {
            string query = string.Format("UPDATE [WiiTmp].[dbo].[tbl_Wrk_Fesコンテンツ_{0}] SET 更新日時 = NULL WHERE デジドココンテンツID ='{1}'", Environment.MachineName.Replace("-", "_"), contentId);
            return query;
        }

        internal static string GetUpdateFesContentsQuery(DataTable dtFesServiceTable, ref Parameters parameters)
        {
            DataRow row = dtFesServiceTable.Rows[0];
            string id = string.Empty;
            string columnValue = string.Empty;
            string values = string.Empty;

            foreach (DataColumn col in dtFesServiceTable.Columns)
            {
                parameters.Add(new Parameter()
                {
                    Name = string.Format("@{0}", col.ColumnName),
                    Values = col.ColumnName.Equals("最終更新日時") ? DateTime.Now : row[col]
                });
                if (!col.ColumnName.Equals("デジドココンテンツID"))
                    values += string.Format("{0} = @{0}, ", col.ColumnName);
            }

            values = values.Trim();
            values = values.Remove(values.Length - 1, 1);

            string query = string.Format("UPDATE Wii.[dbo].[Fesサービス] SET {0} WHERE デジドココンテンツID = @デジドココンテンツID ", values);
            return query;
        }

        internal static string GetUpdateFesContentQuery(DataTable dtFesServiceTable)
        {
            DataRow row = dtFesServiceTable.Rows[0];
            string id = string.Empty;
            string columnValue = string.Empty;
            string values = string.Empty;
            foreach (DataColumn col in dtFesServiceTable.Columns)
            {
                if (col.ColumnName.Equals("デジドココンテンツID"))
                {
                    id = row[col].ToString();
                    continue;
                }

                if (col.ColumnName.Equals("曲名ソート英字補正"))
                {
                    // columnValue = row[col].ToString();
                    //  continue;
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
            string query = string.Format("UPDATE Wii.[dbo].[Fesサービス] SET {0} WHERE デジドココンテンツID = '{1}' ", values, id);
            return query;
        }

        internal static string GetInserFestContentQuery(DataTable dtRegist)
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

            string query = string.Format("INSERT INTO Wii.[dbo].[Fesサービス]({0}) VALUES({1})", columns, values);
            return query;
        }

        public static string GetCreateFestTmpQuery(string festTableTmpName)
        {
            string query = string.Format("IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'{0}') AND type in (N'U')) BEGIN drop table {0} END; CREATE TABLE {0}([選択] [bit] NULL DEFAULT ((0)),[Wiiデジドコ選曲番号] [int] NULL,[カラオケ選曲番号] [int] NULL,[親選曲番号] [int] NULL,[配信マーク] [nvarchar](100) NULL,[表示用Fesアレンジコード] [int] NULL,[Fesアレンジコード] [int] NULL,[カラオケアレンジコード] [int] NULL,[アレンジ名] [nvarchar](50) NULL,[かなNULLフラグ] [tinyint] NULL,[楽曲名] [nvarchar](150) NULL,[曲名補正] [nvarchar](384) NULL,[楽曲名検索用カナ] [nvarchar](900) NOT NULL,[曲名よみがな補正] [nvarchar](256) NULL,[楽曲名ソート用かな] [nvarchar](200) NOT NULL,[曲名ソート補正] [nvarchar](256) NULL,[楽曲名検索ソート英字] [nvarchar](100) NULL,[曲名ソート英字補正] [nvarchar](180) NULL,[カラオケ楽曲名] [nvarchar](450) NULL,[カラオケ楽曲名かな] [nvarchar](450) NULL,[邦題優先フラグ] [tinyint] NULL,[楽曲名邦題] [nvarchar](450) NULL,[楽曲名邦題かな] [nvarchar](450) NULL,[PU_ARTIST_ID] [nvarchar](4000) NULL,[歌手ID補正] [int] NULL,[歌手名] [nvarchar](100) NULL,[歌手名補正] [nvarchar](450) NULL,[歌手名検索用カナ] [nvarchar](450) NULL,[歌手名カナ補正] [nvarchar](450) NULL,[歌手名ソート用カナ] [nvarchar](450) NULL,[歌手名ソート補正] [nvarchar](450) NULL,[歌手名検索ソート英字] [nvarchar](100) NULL,[歌手名ソート英数補正] [nvarchar](450) NULL,[INTRO_TYPE] [nchar](1) NULL,[INTRO_TYPE補正] [tinyint] NULL,[COUNTRY_CODE] [nchar](2) NULL,[歌いだし] [nvarchar](450) NULL,[演奏時間] [int] NULL,[演奏時間補正] [int] NULL,[支援レベル] [nchar](3) NULL,[原曲比] [nvarchar](5) NULL,[原曲比2] [nvarchar](5) NULL,[情報欄_JSTYLE] [nvarchar](450) NULL,[カラオケ削除情報] [nvarchar](450) NULL,[発売日] [datetime] NULL,[新譜本扱月] [int] NULL,[歌唱可能日] [datetime] NULL,[カラオケ完パケ期限日] [datetime] NULL,[カラオケ完パケ日] [datetime] NULL,[アップ予定日] [datetime] NULL,[サービス発表日] [datetime] NULL,[ライツ用サービス発表日] [datetime] NULL,[検索表示可否フラグ] [tinyint] NULL,[取消フラグ] [tinyint] NULL,[停止日] [datetime] NULL,[削除情報] [nvarchar](255) NULL,[FesDISCID] [nvarchar](10) NULL,[FesDISCIDVer2] [nvarchar](10) NULL,[NET利用フラグ] [tinyint] NULL,[NET利用フラグVer2] [tinyint] NULL,[録画可否フラグ] [tinyint] NULL,[録音可否フラグ] [tinyint] NULL,[有料コンテンツフラグ] [tinyint] NULL,[チャプターフラグ] [tinyint] NULL,[Wii_U_制作完了日] [datetime] NULL,[Wii_U_サービス発表日] [datetime] NULL,[Wii_U_取消フラグ] [tinyint] NULL,[Wii_U_停止日] [datetime] NULL,[Wii_U_削除情報] [nvarchar](50) NULL,[Wii_U_録画可否フラグ] [tinyint] NULL,[Wii_U_録音可否フラグ] [tinyint] NULL,[Wii_U_無料配信フラグ] [tinyint] NULL,[JV映像区分背景映像区分] [nvarchar](100) NULL,[映像ジャンル] [nvarchar](10) NULL,[映像区分] [nvarchar](255) NULL,[コンテンツ種類] [nvarchar](3) NULL,[背景映像コード] [nvarchar](7) NULL,[個別映像ロック] [int] NULL,[著作権備考] [nvarchar](255) NULL,[備考] [nvarchar](255) NULL,[削除] [bit] NULL DEFAULT ((0)),[登録日時] [datetime] NULL,[Artist_Id] [int] NULL,[更新日時] [datetime] NULL,[SONG_GROUP_INTRO_TYPE] [nchar](1) NULL,[デジドココンテンツID] [int] NOT NULL, PRIMARY KEY CLUSTERED ([デジドココンテンツID] ASC ) WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY]", festTableTmpName);
            return query;
        }

        public static string GetFesCancelFlagQuery()
        {
            string query = "select [取り消しID],  CONCAT([取り消しID], '  ', [説明文])  as [説明文] from Wii.dbo.[Fes非公開理由] order by [取り消しID]";
            return query;
        }

        public static string GetSelectSingerIdCorrectionQuery()
        {
            string query = string.Format("select [Fes独自歌手ID], [歌手名], [歌手名検索用カナ], [歌手名ソート用カナ],[歌手名ソート用英数] from Wii.dbo.[Fes独自歌手管理]");
            return query;
        }

        public static string GetSelectFesJVVideoSegmentQuery()
        {
            string query = string.Format("select [JV映像区分], [JV映像区分] +'   '+ [ジャンル1] +'   '+ [ジャンル2] from [Fes_JV映像区分] order by [演出カテゴリ区分], [JV映像区分]");
            return query;
        }

        public static string GetSelectSuportLevelQuery()
        {
            string query = string.Format("SELECT 支援レベル, 支援レベル +' '+ 支援レベル名 FROM dbo.Fes支援レベル WHERE ([ソート順] IS NOT NULL) ORDER BY [ソート順]");
            return query;
        }

        public static string GetUpdateFestTmpQuery(string festTableTmpName)
        {
            string query = string.Format("UPDATE [WiiTmp].[dbo].[tbl_Wrk_Fesコンテンツ_{0}] set 選択 = 0 , 更新日時 =NULL;UPDATE [WiiTmp].[dbo].[tbl_Wrk_Fesコンテンツ_{0}] SET [Wii(デジドコ)選曲番号] = tmp.[Wiiデジドコ選曲番号],[カラオケ選曲番号] = tmp.[カラオケ選曲番号],[配信マーク] = tmp.[配信マーク],[カラオケアレンジコード] = tmp.[カラオケアレンジコード],[アレンジ名] = tmp.[アレンジ名],[表示用Fesアレンジコード] = tmp.[表示用Fesアレンジコード],[Fesアレンジコード] = tmp.[Fesアレンジコード],[発売日] = CONVERT(varchar(8),tmp.[発売日],112),[楽曲名] = tmp.[楽曲名],[歌手名] = tmp.[歌手名],[楽曲名検索用カナ] = tmp.[楽曲名検索用カナ],[曲名よみがな補正] = tmp.[曲名よみがな補正],[楽曲名ソート用かな] = tmp.[楽曲名ソート用かな],[楽曲名検索ソート英字] = tmp.[楽曲名検索ソート英字],[曲名ソート英字補正] = tmp.[曲名ソート英字補正],[Artist_Id] = tmp.[Artist_Id],[PU_ARTIST_ID] = tmp.[PU_ARTIST_ID],[歌手名検索用カナ] = tmp.[歌手名検索用カナ],[歌手名ソート用カナ] = tmp.[歌手名ソート用カナ],[歌手名検索ソート英字] = tmp.[歌手名検索ソート英字],[歌唱可能日] = CONVERT(varchar(8),tmp.[歌唱可能日],112),[アップ予定日] = CONVERT(varchar(8),tmp.[アップ予定日],112),[カラオケ完パケ期限日] = CONVERT(varchar(8),tmp.[カラオケ完パケ期限日],112),[カラオケ完パケ日] = CONVERT(varchar(8),tmp.[カラオケ完パケ日],112),[Wii_U_制作完了日] = CONVERT(varchar(8),tmp.[Wii_U_制作完了日],112),[サービス発表日] = CONVERT(varchar(8),tmp.[サービス発表日],112),[ライツ用サービス発表日] = CONVERT(varchar(8),tmp.[ライツ用サービス発表日],112),[検索表示可否フラグ] = tmp.[検索表示可否フラグ],[取消フラグ] = tmp.[取消フラグ],[停止日] = CONVERT(varchar(8),tmp.[停止日],112),[削除情報] = tmp.[削除情報],[FesDISCID] = tmp.[FesDISCID],[FesDISCID(Ver2)] = tmp.[FesDISCIDVer2],[NET利用フラグ] = tmp.[NET利用フラグ],[NET利用フラグ(Ver2)] = tmp.[NET利用フラグVer2],[録画可否フラグ] = tmp.[録画可否フラグ],[録音可否フラグ] = tmp.[録音可否フラグ],[有料コンテンツフラグ] = tmp.[有料コンテンツフラグ],[チャプターフラグ] = tmp.[チャプターフラグ],[Wii_U_サービス発表日] = CONVERT(varchar(8),tmp.[Wii_U_サービス発表日],112),[Wii_U_取消フラグ] = tmp.[Wii_U_取消フラグ],[Wii_U_停止日] = CONVERT(varchar(8),tmp.[Wii_U_停止日],112),[Wii_U_削除情報] = tmp.[Wii_U_削除情報],[Wii_U_録画可否フラグ] = tmp.[Wii_U_録画可否フラグ],[Wii_U_録音可否フラグ] = tmp.[Wii_U_録音可否フラグ],[Wii_U_無料配信フラグ] = tmp.[Wii_U_無料配信フラグ],[INTRO_TYPE] = tmp.[INTRO_TYPE],[SONG_GROUP_INTRO_TYPE] = tmp.[SONG_GROUP_INTRO_TYPE],[COUNTRY_CODE] = tmp.[COUNTRY_CODE],[歌いだし] = tmp.[歌いだし],[演奏時間] = tmp.[演奏時間],[演奏時間補正] = tmp.[演奏時間補正],[支援レベル] = tmp.[支援レベル],[原曲比] = tmp.[原曲比],[原曲比2] = tmp.[原曲比2],[情報欄_JSTYLE] = tmp.[情報欄_JSTYLE],[JV映像区分(背景映像区分)] = tmp.[JV映像区分背景映像区分],[映像ジャンル] = tmp.[映像ジャンル],[映像区分] = tmp.[映像区分],[背景映像コード] = tmp.[背景映像コード],[個別映像ロック] = tmp.[個別映像ロック],[親選曲番号] = tmp.[親選曲番号],[著作権備考] = tmp.[著作権備考],[備考] = tmp.[備考],[登録日時] = convert(nchar(8),tmp.[登録日時],112) + replace(convert(varchar(8), tmp.[登録日時],108),':',''),[コンテンツ種類] = tmp.[コンテンツ種類],[楽曲名邦題] = tmp.[楽曲名邦題],[楽曲名邦題かな] = tmp.[楽曲名邦題かな],[カラオケ楽曲名かな] = tmp.[カラオケ楽曲名かな],[カラオケ楽曲名] = tmp.[カラオケ楽曲名],[邦題優先フラグ] = tmp.[邦題優先フラグ],[曲名補正] = tmp.[曲名補正],[かなNULLフラグ] = tmp.[かなNULLフラグ],[曲名ソート補正] = tmp.[曲名ソート補正],[歌手ID補正] = tmp.[歌手ID補正],[INTRO_TYPE補正] = tmp.[INTRO_TYPE補正],[新譜本扱月] = tmp.[新譜本扱月],[カラオケ削除情報] = tmp.[カラオケ削除情報],[選択] = tmp.[選択],[削除] = tmp.[削除],[更新日時] = tmp.[更新日時] FROM  [WiiTmp].[dbo].[tbl_Wrk_Fesコンテンツ_{0}] inner join [{1}] as tmp on [WiiTmp].[dbo].[tbl_Wrk_Fesコンテンツ_{0}].[デジドココンテンツID] = tmp.[デジドココンテンツID]; DROP TABLE {1}", Environment.MachineName.Replace("-", "_"), festTableTmpName);
            return query;
        }

        internal static string GetSelectSingerIdCorrectionByIdQuery(string id)
        {
            string query = string.Format("select Fes独自歌手ID, 歌手名 as 歌手名補正, 歌手名検索用カナ as 歌手名カナ補正, 歌手名ソート用カナ as 歌手名ソート補正,歌手名ソート用英数 as 歌手名ソート英数補正 from Wii.dbo.[Fes独自歌手管理] where Fes独自歌手ID ={0}", id);
            return query;
        }

        public static string GetInsertTmpWithCoditionsQuery(List<string> conditions)
        {
            string query = string.Empty;
            query = GetInsertFesContentTmpQuery();
            // Input not set
            if (conditions.Count == 0)
            {
                query = query + " where [デジドココンテンツID] in ( select [デジドココンテンツID] From [v_デジ・ドココンテンツ] where [取消連番] = 0 )";
            }// User in put data
            else
            {
                string parameter = string.Empty;
                conditions.ToList().ForEach(para => parameter += para + " ");
                query = query + " where 1=1 " + parameter;
            }
            return query;
        }

        /// <summary>
        /// GetInsertTmpTblQuery(ID_FES_CONTENTS)
        /// </summary>
        /// <returns></returns>
        private static string GetInsertFesContentTmpQuery()
        {
            string query = string.Empty;
            query = string.Format("insert into  WiiTmp.dbo.[tbl_Wrk_Fesコンテンツ_{0}]  ( [デジドココンテンツID],[Wii(デジドコ)選曲番号],[カラオケ選曲番号],[コンテンツ種類],[配信マーク],[カラオケアレンジコード],[アレンジ名],[表示用Fesアレンジコード],[Fesアレンジコード],[発売日],[邦題優先フラグ],[楽曲名],[楽曲名邦題],[曲名補正],[歌手名],[歌手名検索ソート英字],[楽曲名検索用カナ],[かなNULLフラグ],[曲名よみがな補正],[楽曲名ソート用かな],[曲名ソート補正],[楽曲名検索ソート英字],[曲名ソート英字補正],[楽曲名邦題かな],[カラオケ楽曲名],[カラオケ楽曲名かな],[PU_ARTIST_ID],[歌手名検索用カナ],[歌手名ソート用カナ],[歌手ID補正],[歌唱可能日],[アップ予定日],[カラオケ完パケ期限日],[カラオケ完パケ日],[Wii_U_制作完了日],[サービス発表日],[ライツ用サービス発表日],[検索表示可否フラグ],[取消フラグ],[停止日],[削除情報],[FesDISCID],[FesDISCID(Ver2)],[NET利用フラグ],[NET利用フラグ(Ver2)],[録画可否フラグ],[録音可否フラグ],[有料コンテンツフラグ],[チャプターフラグ],[Wii_U_サービス発表日],[Wii_U_取消フラグ],[Wii_U_停止日],[Wii_U_削除情報],[Wii_U_録画可否フラグ],[Wii_U_録音可否フラグ],[Wii_U_無料配信フラグ],[INTRO_TYPE],[SONG_GROUP_INTRO_TYPE],[INTRO_TYPE補正],[COUNTRY_CODE],[歌いだし],[演奏時間],[演奏時間補正],[支援レベル],[原曲比],[原曲比2],[情報欄_JSTYLE],[JV映像区分(背景映像区分)],[映像ジャンル],[映像区分],[背景映像コード],[個別映像ロック],[親選曲番号],[著作権備考],[備考],[登録日時],[新譜本扱月],[カラオケ削除情報] ) select [デジドココンテンツID],[Wii(デジドコ)選曲番号],[カラオケ選曲番号],[コンテンツ種類],[配信マーク],[カラオケアレンジコード],[アレンジ名],[表示用Fesアレンジコード],[Fesアレンジコード],[発売日],[邦題優先フラグ],[楽曲名],[楽曲名邦題],[曲名補正],[歌手名],[歌手名検索ソート英字],[楽曲名検索用カナ],[かなNULLフラグ],[曲名よみがな補正],[楽曲名ソート用かな],[曲名ソート補正],[楽曲名検索ソート英字],[曲名ソート英字補正],[楽曲名邦題かな],[カラオケ楽曲名],[カラオケ楽曲名かな],[PU_ARTIST_ID],[歌手名検索用カナ],[歌手名ソート用カナ],[歌手ID補正],[歌唱可能日],[アップ予定日],[カラオケ完パケ期限日],[カラオケ完パケ日],[Wii_U_制作完了日],[サービス発表日],[ライツ用サービス発表日],[検索表示可否フラグ],[取消フラグ],[停止日],[削除情報],[FesDISCID],[FesDISCID(Ver2)],[NET利用フラグ],[NET利用フラグ(Ver2)],[録画可否フラグ],[録音可否フラグ],[有料コンテンツフラグ],[チャプターフラグ],[Wii_U_サービス発表日],[Wii_U_取消フラグ],[Wii_U_停止日],[Wii_U_削除情報],[Wii_U_録画可否フラグ],[Wii_U_録音可否フラグ],[Wii_U_無料配信フラグ],[INTRO_TYPE],[SONG_GROUP_INTRO_TYPE],[INTRO_TYPE補正],[COUNTRY_CODE],[歌いだし],[演奏時間],[演奏時間補正],[支援レベル],[原曲比],[原曲比2],[情報欄_JSTYLE],[JV映像区分(背景映像区分)],[映像ジャンル],[映像区分],[背景映像コード],[個別映像ロック],[親選曲番号],[著作権備考],[備考],[登録日時],[新譜本扱月],[カラオケ削除情報] from Wii.dbo.[v_Fesコンテンツ_WiiU_21] ", Environment.MachineName.Replace("-", "_"));

            return query;
        }

        public static string GetFesContentTruncateSelectionSongNumberQuery()
        {
            string query = string.Format("truncate table WiiTmp.dbo.[tbl_Wrk_Fes選曲番号_{0}]", Environment.MachineName.Replace("-", "_"));
            return query;
        }

        public static string GetSelectFesContentSqlOutputWhere(List<string> songNumberList)
        {
            string songNumbers = string.Empty;
            foreach (string songNumber in songNumberList)
            {
                songNumbers += songNumber + ",";
            }
            // Remove last comma
            songNumbers = songNumbers.Remove(songNumbers.Length - 1);

            string query = string.Format("select [デジドココンテンツID],[Wii(デジドコ)選曲番号],[カラオケ選曲番号],[コンテンツ種類],[配信マーク],[カラオケアレンジコード],[アレンジ名],[表示用Fesアレンジコード],[Fesアレンジコード], [Fesアレンジコード] as [OldFesアレンジコード],[発売日],[邦題優先フラグ],[楽曲名],[楽曲名邦題],[曲名補正],[歌手名],[歌手名検索ソート英字],[楽曲名検索用カナ],[かなNULLフラグ],[曲名よみがな補正],[楽曲名ソート用かな],[曲名ソート補正],[楽曲名検索ソート英字],[曲名ソート英字補正],[楽曲名邦題かな],[カラオケ楽曲名],[カラオケ楽曲名かな],[PU_ARTIST_ID],[歌手名検索用カナ],[歌手名ソート用カナ],[歌手ID補正],[歌唱可能日],[アップ予定日],[カラオケ完パケ期限日],[カラオケ完パケ日],[Wii_U_制作完了日],[サービス発表日],[ライツ用サービス発表日],[検索表示可否フラグ],[取消フラグ],[停止日],[削除情報],[FesDISCID],[NET利用フラグ],[録画可否フラグ],[録音可否フラグ],[有料コンテンツフラグ],[チャプターフラグ],[Wii_U_サービス発表日],[Wii_U_取消フラグ],[Wii_U_停止日],[Wii_U_削除情報],[Wii_U_録画可否フラグ],[Wii_U_録音可否フラグ],[Wii_U_無料配信フラグ],[INTRO_TYPE],[SONG_GROUP_INTRO_TYPE],[INTRO_TYPE補正],[COUNTRY_CODE],[歌いだし],[演奏時間補正],[支援レベル],[原曲比],[原曲比2],[情報欄_JSTYLE],[JV映像区分(背景映像区分)],[映像ジャンル],[映像区分],[背景映像コード],[親選曲番号],[著作権備考],[備考],[登録日時],[新譜本扱月],[カラオケ削除情報],[選択],[削除],[更新日時] from  WiiTmp.dbo.[tbl_Wrk_Fesコンテンツ_{0}]  where [カラオケ選曲番号] in ({1})", Environment.MachineName.Replace("-", "_"), songNumbers);
            return query;
        }

        public static string GetFesConentInsertWorkTableQuery()
        {
            string query = string.Format("insert into WiiTmp.dbo.[tbl_Wrk_Fesコンテンツ_{0}]( [デジドココンテンツID],[Wii(デジドコ)選曲番号],[カラオケ選曲番号],[コンテンツ種類],[配信マーク],[カラオケアレンジコード],[アレンジ名],[表示用Fesアレンジコード],[Fesアレンジコード],[発売日],[邦題優先フラグ],[楽曲名],[楽曲名邦題],[曲名補正],[歌手名],[歌手名検索ソート英字],[楽曲名検索用カナ],[かなNULLフラグ],[曲名よみがな補正],[楽曲名ソート用かな],[曲名ソート補正],[楽曲名検索ソート英字],[曲名ソート英字補正],[楽曲名邦題かな],[カラオケ楽曲名],[カラオケ楽曲名かな],[PU_ARTIST_ID],[歌手名検索用カナ],[歌手名ソート用カナ],[歌手ID補正],[歌唱可能日],[アップ予定日],[カラオケ完パケ期限日],[カラオケ完パケ日],[Wii_U_制作完了日],[サービス発表日],[ライツ用サービス発表日],[検索表示可否フラグ],[取消フラグ],[停止日],[削除情報],[FesDISCID],[FesDISCID(Ver2)],[NET利用フラグ],[NET利用フラグ(Ver2)],[録画可否フラグ],[録音可否フラグ],[有料コンテンツフラグ],[チャプターフラグ],[Wii_U_サービス発表日],[Wii_U_取消フラグ],[Wii_U_停止日],[Wii_U_削除情報],[Wii_U_録画可否フラグ],[Wii_U_録音可否フラグ],[Wii_U_無料配信フラグ],[INTRO_TYPE],[SONG_GROUP_INTRO_TYPE],[INTRO_TYPE補正],[COUNTRY_CODE],[歌いだし],[演奏時間],[演奏時間補正],[支援レベル],[原曲比],[原曲比2],[情報欄_JSTYLE],[JV映像区分(背景映像区分)],[映像ジャンル],[映像区分],[背景映像コード],[個別映像ロック],[親選曲番号],[著作権備考],[備考],[登録日時],[新譜本扱月],[カラオケ削除情報] ) select [デジドココンテンツID],[Wii(デジドコ)選曲番号],[カラオケ選曲番号],[コンテンツ種類],[配信マーク],[カラオケアレンジコード],[アレンジ名],[表示用Fesアレンジコード],[Fesアレンジコード],[発売日],[邦題優先フラグ],[楽曲名],[楽曲名邦題],[曲名補正],[歌手名],[歌手名検索ソート英字],[楽曲名検索用カナ],[かなNULLフラグ],[曲名よみがな補正],[楽曲名ソート用かな],[曲名ソート補正],[楽曲名検索ソート英字],[曲名ソート英字補正],[楽曲名邦題かな],[カラオケ楽曲名],[カラオケ楽曲名かな],[PU_ARTIST_ID],[歌手名検索用カナ],[歌手名ソート用カナ],[歌手ID補正],[歌唱可能日],[アップ予定日],[カラオケ完パケ期限日],[カラオケ完パケ日],[Wii_U_制作完了日],[サービス発表日],[ライツ用サービス発表日],[検索表示可否フラグ],[取消フラグ],[停止日],[削除情報],[FesDISCID],[FesDISCID(Ver2)],[NET利用フラグ],[NET利用フラグ(Ver2)],[録画可否フラグ],[録音可否フラグ],[有料コンテンツフラグ],[チャプターフラグ],[Wii_U_サービス発表日],[Wii_U_取消フラグ],[Wii_U_停止日],[Wii_U_削除情報],[Wii_U_録画可否フラグ],[Wii_U_録音可否フラグ],[Wii_U_無料配信フラグ],[INTRO_TYPE],[SONG_GROUP_INTRO_TYPE],[INTRO_TYPE補正],[COUNTRY_CODE],[歌いだし],[演奏時間],[演奏時間補正],[支援レベル],[原曲比],[原曲比2],[情報欄_JSTYLE],[JV映像区分(背景映像区分)],[映像ジャンル],[映像区分],[背景映像コード],[個別映像ロック],[親選曲番号],[著作権備考],[備考],[登録日時],[新譜本扱月],[カラオケ削除情報] from [v_Fesコンテンツ_WiiU_21]", Environment.MachineName.Replace("-", "_"));

            return query;
        }

        public static string GetFesContentInsertServiceTableQuery()
        {
            string query = string.Format("insert into Wii.dbo.[Fesサービス] ([デジドココンテンツID] ,[録音可否フラグ] ,[最終更新日時] ,[最終更新者] ,[最終更新PC名]) select t5.[デジドココンテンツID],1,getdate() , '{0}' , '{1}' from  (select t1.[カラオケ選曲番号] from Wii.dbo.[tbl_Fes録音可能リスト] as t1  where  not exists (select  'x'  from  Wii.dbo.[Fesサービス] as t2  inner join Wii.dbo.[v_デジ・ドココンテンツ] as t3 on  t2.[デジドココンテンツID] = t3.[デジドココンテンツID] where t1.[カラオケ選曲番号] = t3.[カラオケ選曲番号])) as t4 inner join  Wii.dbo.[v_デジ・ドココンテンツ] as t5  on  t4.[カラオケ選曲番号] = t5.[カラオケ選曲番号]", Environment.UserName, Environment.MachineName.Replace("-", "_"));
            return query;
        }

        //update null
        public static string GetFesContentRecordAbilityFlagQuery()
        {
            string query = string.Format("update Wii.dbo.[Fesサービス]  set [録音可否フラグ] = null,[最終更新日時] = getdate(),[最終更新者] = '{0}',[最終更新PC名] = '{1}' where [デジドココンテンツID] not in (select  t1.[デジドココンテンツID] from  Wii.dbo.[Fesサービス] as t1 inner join  dbo.[v_デジ・ドココンテンツ] as t2   on  t1.[デジドココンテンツID] = t2.[デジドココンテンツID] inner join  Wii.dbo.[tbl_Fes録音可能リスト] as t3  on  t2.[カラオケ選曲番号] = t3.[カラオケ選曲番号])", Environment.UserName, Environment.MachineName.Replace("-", "_"));
            return query;
        }


        public static string GetUpdateFesServicesQuery()
        {
            string query = string.Format("update Wii.dbo.[Fesサービス]  set [録音可否フラグ] = 1,[最終更新日時] = getdate(),[最終更新者] = '{0}',[最終更新PC名] = '{1}' where [デジドココンテンツID] in (select  t1.[デジドココンテンツID] from  Wii.dbo.[Fesサービス] as t1 inner join  dbo.[v_デジ・ドココンテンツ] as t2   on  t1.[デジドココンテンツID] = t2.[デジドココンテンツID] inner join  Wii.dbo.[tbl_Fes録音可能リスト] as t3  on  t2.[カラオケ選曲番号] = t3.[カラオケ選曲番号]) ", Environment.UserName, Environment.MachineName.Replace("-", "_"));
            return query;
        }

        public static string GetTruncateFesContentTableQuery()
        {
            string query = string.Format("truncate table WiiTmp.dbo.[tbl_Wrk_Fesコンテンツ_{0}]", Environment.MachineName.Replace("-", "_"));
            return query;
        }

        public static string GetTruncateTableRecordAbleListQuery()
        {
            var query = string.Format("truncate table Wii.dbo.[{0}]", Constants.RECORDABLE_LIST_TABLE_NAME);
            return query;
        }

        public static string GetBulkInsertFesContentRecordAbleQuery(string filePath)
        {
            string query = string.Format("BULK INSERT Wii.dbo.[{0}] FROM '{1}'", Constants.RECORDABLE_LIST_TABLE_NAME, filePath);
            return query;
        }

        public static string GetCreateNewColumnsQuery()
        {
            // 個別映像ロック
            string query = string.Format("IF COL_LENGTH('[dbo].[Fesサービス]', '個別映像ロック') IS NULL BEGIN ALTER TABLE [dbo].[Fesサービス] ADD 個別映像ロック INT; END;");
            return query;
        }

        public static string GetCreateNewColumnTableTmpQuery()
        {
            string query = string.Format("use [WiiTmp]; IF COL_LENGTH('WiiTmp.dbo.[tbl_Wrk_Fesコンテンツ_{0}]', '個別映像ロック') IS NULL BEGIN ALTER TABLE WiiTmp.dbo.[tbl_Wrk_Fesコンテンツ_{0}] ADD 個別映像ロック INT; END;", Environment.MachineName.Replace("-", ""));
            return query;
        }
    }
}
