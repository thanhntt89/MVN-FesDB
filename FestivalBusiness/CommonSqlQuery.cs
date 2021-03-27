using Festival.Common;
using FestivalCommon;
using System;
using System.Collections.Generic;
using System.Data;

namespace FestivalBusiness
{
    public class CommonSqlQuery
    {
        public static string UpdateColumnWorkTable(string tableName, List<string> Columns, DataTable datValues, bool IsChoiseUpdate)
        {
            string query = string.Format("UPDATE {0} SET {1}");
            string columns = string.Empty;

            foreach (string col in Columns)
            {
                columns += string.Format("{0} = '{1}',", col, datValues.Rows[0][col]);
            }
            columns = columns.Remove(columns.Length - 1, 1);
            if (IsChoiseUpdate)
            {
                query += query + columns + " where 選択 = 1";
            }

            return query;
        }

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


        public static string GetFesImportUpdateItemListSqlOutQuery()
        {
            string query = string.Format("select [デジドココンテンツID],[Wii(デジドコ)選曲番号],[カラオケ選曲番号],[コンテンツ種類],[配信マーク],[カラオケアレンジコード],[アレンジ名],[表示用Fesアレンジコード],[Fesアレンジコード],[発売日],[邦題優先フラグ],[楽曲名],[楽曲名邦題],[曲名補正],[歌手名],[歌手名検索ソート英字],[楽曲名検索用カナ],[かなNULLフラグ],[曲名よみがな補正],[楽曲名ソート用かな],[曲名ソート補正],[楽曲名検索ソート英字],[曲名ソート英字補正],[楽曲名邦題かな],[カラオケ楽曲名],[カラオケ楽曲名かな],[PU_ARTIST_ID],[歌手名検索用カナ],[歌手名ソート用カナ],[歌手ID補正],[歌唱可能日],[アップ予定日],[カラオケ完パケ期限日],[カラオケ完パケ日],[Wii_U_制作完了日],[サービス発表日],[ライツ用サービス発表日],[検索表示可否フラグ],[取消フラグ],[停止日],[削除情報],[FesDISCID],[NET利用フラグ],[録画可否フラグ],[録音可否フラグ],[有料コンテンツフラグ],[チャプターフラグ],[Wii_U_サービス発表日],[Wii_U_取消フラグ],[Wii_U_停止日],[Wii_U_削除情報],[Wii_U_録画可否フラグ],[Wii_U_録音可否フラグ],[Wii_U_無料配信フラグ],[INTRO_TYPE],[SONG_GROUP_INTRO_TYPE],[INTRO_TYPE補正],[COUNTRY_CODE],[歌いだし],[演奏時間補正],[支援レベル],[原曲比],[原曲比2],[情報欄_JSTYLE],[JV映像区分(背景映像区分)],[映像ジャンル],[映像区分],[背景映像コード],[親選曲番号],[著作権備考],[備考],[登録日時],[新譜本扱月],[カラオケ削除情報],[選択],[削除],[更新日時] from  WiiTmp.dbo.[tbl_Wrk_Fesコンテンツ_{0}]", Environment.MachineName.Replace("-", "_"));
            return query;
        }

        private static string GetExportSqlQuerySelected1()
        {
            string PrefixTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string query = string.Format("select '{0}' AS [処理日時] ,[Wii(デジドコ)選曲番号] AS [デジドコNo] ,[カラオケ選曲番号] AS [カラオケNo] ,CONVERT(VARCHAR,CONVERT(DATETIME, [サービス発表日]),111) AS [Fes_サービス発表日] ,CONVERT(VARCHAR,CONVERT(DATETIME, [Wii_U_サービス発表日]),111) AS [Orch_サービス発表日] ,[Wii_U_取消フラグ]  AS [Orch_取消フラグ] from WiiTmp.dbo.[tbl_Wrk_Fesコンテンツ_{1}]", PrefixTime, Environment.MachineName.Replace("-", "_"));
            return query;
        }

        private static string GetExportSqlQuerySelected2()
        {
            string PrefixTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string query = string.Format("select  t1.[Wii(デジドコ)選曲番号] AS [デジドコNo],t1.[カラオケ選曲番号] AS [カラオケNo],t1.[親選曲番号] AS [親カラオケNo],t1.[コンテンツ種類]AS [コンテンツ種類],t1.[配信マーク] AS [配信マーク],t1.[表示用Fesアレンジコード] AS [Fesアレンジコード(自動設定)],t1.[Fesアレンジコード]AS [Fesアレンジコード(補正)],t1.[カラオケアレンジコード] AS [カラオケアレンジコード],t1.[アレンジ名]    AS [アレンジ名],t1.[かなNULLフラグ]AS [かなNULLフラグ],t1.[楽曲名]  AS [曲名(MARY)],t1.[曲名補正]AS [曲名補正],t1.[楽曲名検索用カナ] AS [曲名カナ],t1.[曲名よみがな補正] AS [曲名カナ補正],t1.[楽曲名ソート用かな]AS [曲名ソート],t1.[曲名ソート補正]AS [曲名ソート補正],t1.[楽曲名検索ソート英字]   AS [曲名ソート英数],t1.[曲名ソート英字補正]AS [曲名ソート英数補正],t1.[カラオケ楽曲名]AS [曲名(Ca)],t1.[カラオケ楽曲名かな]AS [曲名カナ(Ca)],t1.[邦題優先フラグ]AS [邦題優先フラグ],t1.[楽曲名邦題]    AS [邦題],t1.[楽曲名邦題かな]AS [邦題カナ],t1.[PU_ARTIST_ID]  AS [PU_ARTIST_ID],t1.[歌手ID補正]    AS [歌手ID補正],t1.[歌手名]  AS [歌手名],t2.[歌手名]  AS [歌手名補正],t1.[歌手名検索用カナ] AS [歌手名カナ],t2.[歌手名検索用カナ] AS [歌手名カナ補正],t1.[歌手名ソート用カナ]AS [歌手名ソート],t2.[歌手名ソート用カナ]AS [歌手名ソート補正],t1.[歌手名検索ソート英字]   AS [歌手名ソート英数],t2.[歌手名ソート用英数]AS [歌手名ソート英数補正],(casewhen   t1.[Fesアレンジコード] = 2 then t1.[SONG_GROUP_INTRO_TYPE]else   t1.[INTRO_TYPE]end )   AS [INTRO_TYPE],t1.[INTRO_TYPE補正]AS [INTRO_TYPE補正],t1.[COUNTRY_CODE]  AS [COUNTRY_CODE],t1.[歌いだし]AS [歌いだし],t1.[原曲比]  AS [原曲比],t1.[演奏時間]AS [演奏時間],t1.[演奏時間補正] AS [演奏時間(補正)],t1.[支援レベル]  AS [支援レベル],t1.[原曲比2] AS [原曲比2],t1.[情報欄_JSTYLE] AS [情報欄_JSTYLE],t1.[カラオケ削除情報] AS [削除情報],t1.[発売日] AS [発売日],t1.[新譜本扱月]  AS [新譜本扱月],t1.[歌唱可能日] AS [歌唱可能日],t1.[カラオケ完パケ期限日]  AS [カラオケ完パケ期限日],t1.[カラオケ完パケ日] AS [カラオケ完パケ日],t1.[アップ予定日] AS [Fes_アップ予定日],t1.[サービス発表日]AS [Fes_サービス発表日],t1.[ライツ用サービス発表日] AS [Fes_ライツ用サービス発表日],t1.[検索表示可否フラグ]AS [Fes_検索表示可否フラグ],t1.[取消フラグ]  AS [Fes_取消フラグ],t1.[停止日] AS [Fes_停止日],t1.[削除情報]AS [Fes_削除情報],t1.[FesDISCID]AS [Fes_DISCID_V1],t1.[FesDISCID(Ver2)] AS [Fes_DISCID_V2],t1.[NET利用フラグ] AS [Fes_NET利用フラグ_V1],t1.[NET利用フラグ(Ver2)]  AS [Fes_NET利用フラグ_V2],t1.[録画可否フラグ]AS [Fes_録画可否フラグ],t1.[録音可否フラグ]AS [Fes_録音可否フラグ],t1.[有料コンテンツフラグ]  AS [Fes_有料コンテンツフラグ],t1.[チャプターフラグ] AS [Fes_チャプターフラグ],t1.[Wii_U_制作完了日] AS [Orch_制作完了日],t1.[Wii_U_サービス発表日]  AS [Orch_サービス発表日],t1.[Wii_U_取消フラグ] AS [Orch_取消フラグ],t1.[Wii_U_停止日] AS [Orch_停止日],t1.[Wii_U_削除情報]AS [Orch_削除情報],t1.[Wii_U_録画可否フラグ]  AS [Orch_録画可否フラグ],t1.[Wii_U_録音可否フラグ]  AS [Orch_録音可否フラグ],t1.[Wii_U_無料配信フラグ]  AS [Orch_無料配信フラグ],t1.[JV映像区分(背景映像区分)]AS [JV映像区分(背景映像区分)],t1.[映像ジャンル] AS [映像ジャンル],t1.[映像区分]AS [Fes_映像ジャンル],t1.[背景映像コード]AS [背景映像コード],t1.[著作権備考]  AS [著作権備考],t1.[備考]  AS [備考],t1.[登録日時]AS [登録日時] from WiiTmp.dbo.[tbl_Wrk_Fesコンテンツ_{0}] as t1 left outer join dbo.Fes独自歌手管理 as t2 on t1.[歌手ID補正] = t2.[Fes独自歌手ID]", Environment.MachineName.Replace("-", "_"));
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

    }
}
