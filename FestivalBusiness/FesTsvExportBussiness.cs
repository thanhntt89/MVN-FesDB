using FestivalObjects;
using FestivalUtilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FestivalBusiness
{
    public class FesTsvExportBussiness : BusinessBase
    {
        public ParameterObjet GetParameterByFunctioNameAndParamterName()
        {
            ParameterObjet parameterObjet = new ParameterObjet();
            try
            {
                string sqlString = string.Format("SELECT TOP 1 * FROM ");

                var data = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, sqlString).Tables[0];
                if (data.Rows.Count > 0)
                {
                    parameterObjet.FunctionName = data.Rows[0][0] == null ? string.Empty : data.Rows[0][0].ToString();
                    parameterObjet.ParameterName = data.Rows[0][1] == null ? string.Empty : data.Rows[0][1].ToString();
                    parameterObjet.Parameters = data.Rows[0][2] == null ? string.Empty : data.Rows[0][2].ToString();
                    parameterObjet.ParameterRemarks = data.Rows[0][3] == null ? string.Empty : data.Rows[0][3].ToString();
                    parameterObjet.LastModified = data.Rows[0][4] == null ? string.Empty : data.Rows[0][4].ToString();
                    parameterObjet.LastUpdateBy = data.Rows[0][5] == null ? string.Empty : data.Rows[0][5].ToString();
                    parameterObjet.UpdateLastUpdatePCName = data.Rows[0][6] == null ? string.Empty : data.Rows[0][6].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return parameterObjet;
        }

        public void ExportRecommendSong(string filePath, DataTable exportTable)
        {
            try
            {
                StringBuilder logContent = new StringBuilder();

                logContent.AppendLine(string.Format("下記のプログラムIDは、おすすめプログラム管理の設定上、使用できないプログラムIDを設定しています。{0}\nプログラムID", DateTime.Now));

                foreach (DataRow row in exportTable.Rows)
                {
                    if (row[0] != null)
                        logContent.Append(row[0].ToString());
                }

                TsvConvert.ExportToTSV(filePath, logContent.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExportChapterAddDeleteSongFlagTimeCheck(string filePath, DataTable exportTable)
        {
            try
            {
                StringBuilder logContent = new StringBuilder();
                logContent.AppendLine(string.Format("下記の選曲番号は、チャプター設定が不整合です。({0})", DateTime.Now));
                string data = string.Empty;

                foreach (DataRow row in exportTable.Rows)
                {
                    if (row.Field<object>("ID") == null)
                        data = string.Format("[チャプター追加削除管理が設定されていません。] 選曲番号 {0}", row.Field<object>("選曲番号"));
                    else
                        data = data = string.Format("[Fesコンテンツのチャプターフラグが設定されていません。] 選曲番号 {0} 通番 {1} FesDISCID {2}", row.Field<object>("選曲番号"), row.Field<object>("通番"), row.Field<object>("FesDISCID"));
                    logContent.AppendLine(data);
                }

                LogWriter.Write(filePath, logContent.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExportChapterAddDeleteSongLastTimeCheck(string filePath, DataTable exportTable)
        {
            try
            {
                StringBuilder logContent = new StringBuilder();
                //Hai san fill
                logContent.AppendLine(string.Format("下記の通し番号は、前回出力時よりデータの内容が変更・削除されています({0})。", DateTime.Now));
                string data = string.Empty;

                foreach (DataRow row in exportTable.Rows)
                {
                    if (row.Field<object>("変更削除フラグ") != null && row.Field<object>("変更削除フラグ").ToString().Equals("1"))
                    {
                        data = "通番 " + row.Field<object>("通し番号");
                        logContent.AppendLine(data);
                        if (Utils.IsNumeric(row.Field<object>("ディスクID").ToString()) && Utils.IsNumeric(row.Field<object>("前回ディスクID").ToString()) && !row.Field<object>("ディスクID").Equals(row.Field<object>("前回ディスクID")))
                        {
                            data = "ディスクID " + row.Field<object>("前回ディスクID") + " → " + row.Field<object>("ディスクID");
                            logContent.AppendLine(data);
                        }

                        if (Utils.IsNumeric(row.Field<object>("選曲番号").ToString()) && Utils.IsNumeric(row.Field<object>("前回選曲番号").ToString()) && !row.Field<object>("選曲番号").Equals(row.Field<object>("前回選曲番号")))
                        {
                            data = "選曲番号 " + row.Field<object>("前回選曲番号") + " → " + row.Field<object>("選曲番号");
                            logContent.AppendLine(data);
                        }

                        if (Utils.IsNumeric(row.Field<object>("有償情報フラグ").ToString()) && Utils.IsNumeric(row.Field<object>("前回有償情報フラグ").ToString()) && !row.Field<object>("有償情報フラグ").Equals(row.Field<object>("前回有償情報フラグ")))
                        {
                            data = "有償情報フラグ " + row.Field<object>("前回有償情報フラグ") + " → " + row.Field<object>("有償情報フラグ");
                            logContent.AppendLine(data);
                        }

                        if (Utils.IsNumeric(row.Field<object>("追加・削除情報").ToString()) && Utils.IsNumeric(row.Field<object>("前回追加・削除情報").ToString()) && !row.Field<object>("追加・削除情報").Equals(row.Field<object>("前回追加・削除情報")))
                        {
                            data = "追加・削除情報 " + row.Field<object>("前回追加・削除情報") + " → " + row.Field<object>("追加・削除情報");
                            logContent.AppendLine(data);
                        }
                    }
                    else
                    {
                        data = string.Format("通番 [{0}] が前回出力時より削除されています。", row.Field<object>("通し番号"));
                        logContent.AppendLine(data);
                    }
                }

                LogWriter.Write(filePath, logContent.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectFesSingerIDChangeHistryAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesSingerIDChangeHistryAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateFesSingerIDChangeHistryTable()
        {
            try
            {
                string query = string.Format("exec usp_CreateFesSingerIDChangeHistryTable");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertFesSingerIdChangeHistoryUpdate()
        {
            try
            {
                string query = string.Format("INSERT INTO dbo.[fes歌手id変更履歴] ([変更前_歌手id], [変更前_歌手名], [変更前_歌手名検索用カナ], [変更前_歌手名ソート用カナ], [変更後_歌手id], [変更後_歌手名], [変更後_歌手名検索用カナ], [変更後_歌手名ソート用カナ], [変更日時], [変更利用者id]) SELECT t5.[歌手id], t5.[歌手名], t5.[歌手名検索用カナ], t5.[歌手名ソート用カナ], t6.[歌手id], t6.[歌手名], t6.[歌手名検索用カナ], t6.[歌手名ソート用カナ], Getdate(), '{0}' FROM (SELECT DISTINCT t1.[歌手id] AS [変更前_歌手ID], t2.[歌手id] AS [変更後_歌手ID] FROM Wiitmp.dbo.[tbl_fes前回コンテンツ] AS t1 INNER JOIN Wiitmp.dbo.[tbl_fesコンテンツ_演奏時間追加] AS t2 ON t1.[選曲番号] = t2.[選曲番号] AND t1.[歌手id] <> t2.[歌手id]) AS iv1 INNER JOIN (SELECT t3.[歌手id] FROM Wiitmp.dbo.[tbl_fes前回歌手] AS t3 WHERE  NOT EXISTS (SELECT 'x' FROM Wiitmp.dbo.[tbl_fes歌手] AS t4 WHERE  t3.[歌手id] = t4.[歌手id])) AS iv2 ON iv1.[変更前_歌手id] = iv2.[歌手id] INNER JOIN wiitmp.dbo.[tbl_fes前回歌手] AS t5 ON iv1.[変更前_歌手id] = t5.[歌手id] INNER JOIN wiitmp.dbo.[tbl_fes歌手] AS t6 ON iv1.[変更後_歌手id] = t6.[歌手id] WHERE  NOT EXISTS (SELECT 'x' FROM dbo.[fes歌手id変更履歴] AS t7 WHERE  t5.[歌手id] = t7.[変更前_歌手id] AND t6.[歌手id] = t7.[変更後_歌手id])", Environment.UserName.Replace("-", ""));
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BulkInsertFesLastContent(string filePath)
        {
            try
            {
                string query = string.Format("BULK INSERT  WiiTmp.dbo.[tbl_Fes前回コンテンツ] FROM '{0}'", filePath);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TruncateFesLastContent()
        {
            try
            {
                string query = string.Format("truncate table WiiTmp.dbo.[tbl_Fes前回コンテンツ]");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BulkInsertFesLastSinger(string filePath)
        {
            try
            {
                string query = string.Format("BULK INSERT WiiTmp.dbo.[tbl_Fes前回歌手] FROM '{0}'", filePath);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TruncateFesLastSinger()
        {
            try
            {
                string query = string.Format("truncate table WiiTmp.dbo.[tbl_Fes前回歌手]");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetFesDisVersionSongV1()
        {
            try
            {
                string query = string.Format("select t1.[選曲番号],t1.[ディスクID] from WiiTmp.dbo.[tbl_FesDISC版収録曲] as t1 where t1.[NET利用フラグ] = 0 and Not Exists ( select * from dbo.[FesDISC追加削除管理] as t2 inner join dbo.[v_デジ・ドココンテンツ] as t3 on t2.[デジドココンテンツID] = t3.[デジドココンテンツID] where t1.[選曲番号] = t3.[選曲番号] and t1.[ディスクID] = t2.[FesDISCID] and t2.[追加削除区分] = 0 and t2.[未出力フラグ] = 1 ) order by t1.[選曲番号],t1.[ディスクID]");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetFesDisVersionSongV2()
        {
            try
            {
                string query = string.Format("select t1.[選曲番号],t1.[ディスクID] from WiiTmp.dbo.[tbl_FesDISC版収録曲] as t1 where t1.[NET利用フラグ] = 0 and Not Exists ( select * from dbo.[FesDISC追加削除管理] as t2 inner join dbo.[v_デジ・ドココンテンツ] as t3 on t2.[デジドココンテンツID] = t3.[デジドココンテンツID] where t1.[選曲番号] = t3.[選曲番号] and t1.[ディスクID] = t2.[FesDISCID] and t2.[追加削除区分] = 0 and t2.[削除フラグ] = 0 ) order by t1.[選曲番号],t1.[ディスクID]");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectFesRecomendSongAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesRecomendSongAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TruncateFesRecommendSong()
        {
            try
            {
                string query = string.Format("truncate table WiiTmp.dbo.tbl_FesRecommendSong");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesContentsRankAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesContentsRankAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateFesContentsRankTable()
        {
            try
            {
                string query = string.Format("exec usp_CreateFesContentsRankTable");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUpdateDateSingerTable()
        {
            try
            {
                string query = string.Format("INSERT INTO Wii.dbo.[tbl_Fes更新日時_歌手] ([singer_ranking]) VALUES ('{0}')", DateTime.Now.ToString("yyyyMMdd"));
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TruncateUpdateDateSinger()
        {
            try
            {
                string query = string.Format("truncate table Wii.dbo.[tbl_Fes更新日時_歌手]");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesSingerRankAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesSingerRankAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateFesSingerRankTable()
        {
            try
            {
                string query = string.Format("exec usp_CreateFesSingerRankTable");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateFesImageDiskTableAutoByAddDelete()
        {
            try
            {
                string query = string.Format("exec usp_CreateFesImageDiskTable_AutoByAddDelete");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesImageDiskAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesImageDiskAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CreateFesImageDiskTable()
        {
            try
            {
                string query = string.Format("exec usp_CreateFesImageDiskTable");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectFesPackageIdAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesPackageIdAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CreateFesPackageIdTable(string datetime)
        {
            try
            {
                string query = string.Format("exec usp_CreateFesPackageIdTable '{0}'", datetime);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectProgramId()
        {
            try
            {
                string query = string.Format("select distinct t1.[プログラムID] from  WiiTmp.dbo.[tbl_Fesおすすめプログラムリスト] as t1 where Not Exists ( select  *  from dbo.[Fesおすすめプログラム] as t2 where  t1.[プログラムID] = t2.[プログラムID] ) order by  t1.[プログラムID]");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesRecommendProgramListAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesRecommendProgramListAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateFesRecommendProgramListTable(string datetime)
        {
            try
            {
                string query = string.Format("exec usp_CreateFesRecommendProgramListTable '{0}'", datetime);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectFesChapterAddRemoveChapterSong()
        {
            try
            {
                string query = string.Format("select t1.[通し番号], 1 as [変更削除フラグ], t1.[ディスクID], t1.[選曲番号], t1.[有償情報フラグ], t1.[追加・削除情報],iv1.[ディスクID] as [前回ディスクID],iv1.[選曲番号] as [前回選曲番号],iv1.[有償情報フラグ] as [前回有償情報フラグ],iv1.[追加・削除情報] as [前回追加・削除情報] from WiiTmp.dbo.[tbl_Fesチャプター追加削除曲] as t1  inner join  (select*from WiiTmp.dbo.[tbl_Fes前回チャプター追加削除曲] as t2 where Not Exists(   select  *   from  WiiTmp.dbo.[tbl_Fesチャプター追加削除曲] as t3   where  t2.[ディスクID] = t3.[ディスクID]   and  t2.[選曲番号] = t3.[選曲番号]   and  t2.[有償情報フラグ] = ISNULL(t3.[有償情報フラグ], 2)   and  t2.[追加・削除情報] = t3.[追加・削除情報]   and  t2.[通し番号] = t3.[通し番号]) ) as iv1 on t1.[通し番号] = iv1.[通し番号] union select   t4.[通し番号],   2 as [変更削除フラグ], null,   null,   null,null,null,null,null,null from WiiTmp.dbo.[tbl_Fes前回チャプター追加削除曲] as t4 where Not Exists(select*from WiiTmp.dbo.[tbl_Fesチャプター追加削除曲] as t5 where t4.[通し番号] = t5.[通し番号]) order by  t1.[通し番号] ");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void BulkInsertFesLastChapterAddRemoveSong(string filePath)
        {
            try
            {
                string query = string.Format("BULK INSERT  WiiTmp.dbo.[tbl_Fes前回チャプター追加削除曲] FROM '{0}'", filePath);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void TruncateFesLastChapterAddRemoveSong()
        {
            try
            {
                string query = string.Format("truncate table WiiTmp.dbo.[tbl_Fes前回チャプター追加削除曲]");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesChapterAddDeleteChapterSong()
        {
            try
            {
                string query = string.Format("select v1.[選曲番号], t4.[ID], t4.[通番], t4.[FesDISCID] from dbo.[Fesサービス] as t3 left join dbo.[v_デジ・ドココンテンツ] as v1 on  t3.[デジドココンテンツID] = v1.[デジドココンテンツID] left join dbo.[Fesチャプター追加削除管理] as t4 on  t3.[デジドココンテンツID] = t4.[デジドココンテンツID] and t4.[追加削除区分] = 0 and t4.[削除フラグ] = 0 where t3.[デジドココンテンツID] in (   select   t1.[デジドココンテンツID]   from   dbo.[Fesチャプター追加削除管理] as t1   where   t1.[追加削除区分] = 0   and t1.[削除フラグ] = 0 union all select t2.[デジドココンテンツID] from Wii.dbo.[Fesサービス] as t2 where t2.[チャプターフラグ] = 1 ) and (isnull(t3.[チャプターフラグ], 0) <> 1 or t4.[ID] is null) order by t4.[通番], t4.[ID], v1.[選曲番号] ");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesChapterAddDeleteSongAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesChapterAddDeleteSongAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateFesChapterAddDeleteSongTable()
        {
            try
            {
                string query = string.Format("exec usp_CreateFesChapterAddDeleteSongTable");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesHealthyKingdomRecommendSongAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesHealthyKingdomRecommendSongAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateFesHealthyKingdomRecommendSongTable(string datetime)
        {
            try
            {
                string query = string.Format("exec usp_CreateFesHealthyKingdomRecommendSongTable '{0}'", datetime);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectFesChapterAddDeleteManagement()
        {
            try
            {
                string query = string.Format("select v1.[選曲番号], t4.[ID], t4.[通番], t4.[FesDISCID] from dbo.[Fesサービス] as t3 left join dbo.[v_デジ・ドココンテンツ] as v1 on  t3.[デジドココンテンツID] = v1.[デジドココンテンツID] left join dbo.[Fesチャプター追加削除管理] as t4 on  t3.[デジドココンテンツID] = t4.[デジドココンテンツID] and t4.[追加削除区分] = 0 and t4.[削除フラグ] = 0 where t3.[デジドココンテンツID] in (   select   t1.[デジドココンテンツID]   from   dbo.[Fesチャプター追加削除管理] as t1   where   t1.[追加削除区分] = 0   and t1.[削除フラグ] = 0 union all select t2.[デジドココンテンツID] from Wii.dbo.[Fesサービス] as t2 where t2.[チャプターフラグ] = 1 ) and (isnull(t3.[チャプターフラグ], 0) <> 1 or t4.[ID] is null) order by t4.[通番], t4.[ID], v1.[選曲番号]");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectFesImageDiscAddDelete()
        {
            try
            {
                string query = string.Format("select t1.[通し番号], 1 as [変更削除フラグ], t1.[背景ファイル名], t1.[ディスクID], t1.[有償情報フラグ], t1.[追加・削除情報], iv1.[背景ファイル名] as [前回背景ファイル名], iv1.[ディスクID] as [前回ディスクID], iv1.[有償情報フラグ] as [前回有償情報フラグ], iv1.[追加・削除情報] as [前回追加・削除情報] from WiiTmp.dbo.[tbl_Fes個別映像DISC追加削除情報] as t1  inner join  ( select * from WiiTmp.dbo.[tbl_Fes前回個別映像DISC追加削除情報] as t2 where Not Exists ( select * from WiiTmp.dbo.[tbl_Fes個別映像DISC追加削除情報] as t3 where t2.[背景ファイル名] = t3.[背景ファイル名] and   t2.[ディスクID] = t3.[ディスクID] and t2.[有償情報フラグ] = ISNULL(t3.[有償情報フラグ], 2) and t2.[追加・削除情報] = t3.[追加・削除情報] and t2.[通し番号] = t3.[通し番号] ) ) as iv1 on t1.[通し番号] = iv1.[通し番号] union select t1.[通し番号], 2 as [変更削除フラグ], null, null, null, null, null, null, null, null from WiiTmp.dbo.[tbl_Fes前回個別映像DISC追加削除情報] as t1 where Not Exists ( select * from WiiTmp.dbo.[tbl_Fes個別映像DISC追加削除情報] as t2 where t1.[通し番号] = t2.[通し番号] ) order by  t1.[通し番号] ");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BulkInsertFesPreviousIndividualVideoDiscAddionalDeletedInfomation(string filePath)
        {
            try
            {
                string query = string.Format("BULK INSERT  WiiTmp.dbo.[tbl_Fes前回個別映像DISC追加削除情報] FROM '{0}'", filePath);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void TruncateFesPreviousIndividualVideoDiscAddionalDeletedInfomation()
        {
            try
            {
                string query = string.Format("truncate table WiiTmp.dbo.[tbl_Fes前回個別映像DISC追加削除情報]");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesImageDiscAddDeleteAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesImageDiscAddDeleteAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CreateFesImageDiscAddDeleteTable()
        {
            try
            {
                string query = string.Format("exec usp_CreateFesImageDiscAddDeleteTable");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesDISCAddRemoveSong()
        {
            try
            {
                string query = string.Format("select  t1.[通し番号],  1 as [変更削除フラグ],  t1.[ディスクID],  t1.[選曲番号],  t1.[有償情報フラグ],  t1.[追加・削除情報],  iv1.[ディスクID] as [前回ディスクID],  iv1.[選曲番号] as [前回選曲番号],  iv1.[有償情報フラグ] as [前回有償情報フラグ],  iv1.[追加・削除情報] as [前回追加・削除情報] from  WiiTmp.dbo.[tbl_FesDISC追加削除曲] as t1  inner join  (select* from WiiTmp.dbo.[tbl_Fes前回DISC追加削除曲] as t2  where Not Exists  (select*  from WiiTmp.dbo.[tbl_FesDISC追加削除曲] as t3  where t2.[ディスクID] = t3.[ディスクID]  and t2.[選曲番号] = t3.[選曲番号]  and t2.[有償情報フラグ] = ISNULL(t3.[有償情報フラグ], 2)  and t2.[追加・削除情報] = t3.[追加・削除情報]  and t2.[通し番号] = t3.[通し番号] ) ) as iv1 on t1.[通し番号] = iv1.[通し番号] union select  t4.[通し番号],  2 as [変更削除フラグ],  null,  null,  null,  null,  null,  null,  null,  null from  WiiTmp.dbo.[tbl_Fes前回DISC追加削除曲] as t4 where Not Exists ( select*  from WiiTmp.dbo.[tbl_FesDISC追加削除曲] as t5  where t4.[通し番号] = t5.[通し番号] ) order by  t1.[通し番号] ");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void BulkInsertFesLastTimeDiscAddDeletedSongTable(string filePath)
        {
            try
            {
                string query = string.Format("BULK INSERT WiiTmp.dbo.[tbl_Fes前回DISC追加削除曲] FROM '{0}'", filePath);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TruncadeFesLastTimeDiscAddDeletedSongTable()
        {
            try
            {
                string query = string.Format("truncate table WiiTmp.dbo.[tbl_Fes前回DISC追加削除曲]");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectFesDiscSongAddDeleteAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesDiscSongAddDeleteAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CreateFesDiscSongAddDeleteTable()
        {
            try
            {
                string query = string.Format("exec usp_CreateFesDiscSongAddDeleteTable");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectFesVideoAllocationDeleted()
        {
            try
            {
                string query = string.Format("select  t1.[選曲番号], t1.[背景映像コード] from WiiTmp.dbo.[tbl_Fes映像割付] as t1 where t1.[背景映像コード] is not null and not exists(select 'x' from dbo.[Fes映像DISC追加削除管理] as t2 where t2.[背景ファイル名] like t1.[背景映像コード] + '%' and t2.[追加削除区分] = 0 and t2.[削除フラグ] = 0) order by t1.[選曲番号], t1.[背景映像コード] ");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectFesVideoAllocationWarning()
        {
            try
            {
                string query = string.Format("select  t1.[選曲番号] ,t1.[背景映像コード] from WiiTmp.dbo.[tbl_Fes映像割付] as t1 where t1.[背景映像コード] is not null and not exists (select 'x' from  dbo.[Fes映像DISC管理] as t2 where t2.[背景ファイル名] like t1.[背景映像コード] + '%' ) order by t1.[選曲番号] ,t1.[背景映像コード] ");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CreateFesImageAllotmentTable(string datetime)
        {
            try
            {
                string query = string.Format("exec usp_CreateFesImageAllotmentTable {0}", datetime);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesImageAllotmentAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesImageAllotmentAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CreateFesRankSumDurationTable()
        {
            try
            {
                string query = string.Format("exec usp_CreateFesRankSumDurationTable");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectFesRankSumDurationAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesRankSumDurationAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectCountFesKaraokeYearRanking()
        {
            try
            {
                string query = string.Format("select count(*)  as Total from Wii.dbo.tbl_Fes_Karaoke_Year_Ranking");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectCountFesRecommendSong()
        {
            try
            {
                string query = string.Format("select count(*)  as Total from Wii.dbo.tbl_FesRecommendSong");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesServices()
        {
            try
            {
                string query = string.Format("SELECT count(*) as [件数] from dbo.Fesサービス  where [サービス発表日] in (select top 6 convert(nvarchar,[発表日],112)   from  WiiTmp.dbo.tbl_Fes追加曲)");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectFesAddSongAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesAddSongAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CreateFesAddSongTable()
        {
            try
            {
                string query = string.Format("exec usp_CreateFesAddSongTable");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectFesTieupRankAll(string datetime)
        {
            try
            {
                string query = string.Format("exec usp_SelectFesTieupRankAll {0}", datetime);
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateFesTieupRankTable()
        {
            try
            {
                string query = string.Format("exec usp_CreateFesTieupRankTable");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesDiscRecordSongAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesDiscRecordSongAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CreateFesDiscRecordSongTable(string datetime, string verson)
        {
            try
            {
                string query = string.Format("exec usp_CreateFesDiscRecordSongTable {0},{1}", datetime, verson);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectFesMClassGenreListAll(string verson)
        {
            try
            {
                string query = string.Format("exec usp_SelectFesMClassGenreListAll  {0}", verson);
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesGenreListAll(string verson)
        {
            try
            {
                string query = string.Format("exec usp_SelectFesGenreListAll {0}", verson);
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectFesGenreDescriptionAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesGenreDescriptionAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CreateFesGenreDescriptionTable()
        {
            try
            {
                string query = string.Format("exec usp_CreateFesGenreDescriptionTable");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CreateFesGenreListTable()
        {
            try
            {
                string query = string.Format("exec usp_CreateFesGenreListTable");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesTieupAll(string version)
        {
            try
            {
                string query = string.Format("exec usp_SelectFesTieupAll {0}", version);
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateFesTieupTable(string datetime)
        {
            try
            {
                string query = string.Format("exec usp_CreateFesTieupTable {0}", datetime);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateFesUpdateTable()
        {
            try
            {
                string query = string.Format("exec usp_CreateFesUpdateTable");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesUpdateAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesUpdateAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CreateFesSingerEisuuTable()
        {
            try
            {
                string query = string.Format("exec usp_CreateFesSingerEisuuTable");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesSingerEisuuAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesSingerEisuuAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesGenreAll(string version)
        {
            try
            {
                string query = string.Format("exec usp_SelectFesGenreAll {0}", version);
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CreateFesServiceTableAddNewAddFlag(string dateTime, string day)
        {
            try
            {
                string query = string.Format("exec usp_CreateFesServiceTable_AddNewAddFlag {0},{1}", dateTime, day);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectFesServiceAllAddNewAddFlag()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesServiceAll_AddNewAddFlag");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateFesServiceTable(string dateTime)
        {
            try
            {
                string query = string.Format("exec usp_CreateFesServiceTable {0}", dateTime);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesServiceAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesServiceAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void CreateFileGetListTable()
        {
            try
            {
                string query = string.Format("exec usp_CreateFesFileGetListTable");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFileGetListAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesFileGetListAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectFesAgeDistinctionAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesAgeDistinctionAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CreateFesAgeDistinctionTable(string dateTime)
        {
            try
            {
                string query = string.Format("exec usp_CreateFesAgeDistinctionTable {0}", dateTime);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectFesSing()
        {
            try
            {
                string query = string.Format("SELECT [選曲番号] from WiiTmp.dbo.tbl_Fes歌いだし  where [歌いだし] is null order by [選曲番号]");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectFesSingStartAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesSingStartAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CreateFesSingStartTable(string dateTime)
        {
            try
            {
                string query = string.Format("exec usp_CreateFesSingStartTable {0}", dateTime);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CreateFesSongNameEisuuTableAddEisuuHosei()
        {
            try
            {
                string query = string.Format("exec usp_CreateFesSongNameEisuuTable_AddEisuuHosei");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectFesSongNameEisuuAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesSongNameEisuuAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateFesSongNameEisuuTable()
        {
            try
            {
                string query = string.Format("exec usp_CreateFesSongNameEisuuTable");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectFesSingerAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesSingerAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateFesSingerTable(string dateTime)
        {
            try
            {
                string query = string.Format("exec usp_CreateFesSingerTable  {0}", dateTime);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesContentsAllAddPlayTime()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesContentsAll_AddPlayTime");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetFesContentAddPlayTime()
        {
            try
            {
                string query = string.Format("SELECT [選曲番号] from WiiTmp.dbo.tbl_Fesコンテンツ_演奏時間追加 where [歌手ID] is null order by [選曲番号]");

                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateFesContentsTableAddPlayTime(string dateTime)
        {
            try
            {
                string query = string.Format("exec usp_CreateFesContentsTable_AddPlayTime '{0}'", dateTime);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetFesService()
        {
            try
            {
                string query = string.Format("SELECT [選曲番号] from WiiTmp.dbo.tbl_Fesコンテンツ where [歌手ID] is null order by [選曲番号]");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateFesGenreTable(string dateTime)
        {
            try
            {
                string query = string.Format("exec usp_CreateFesGenreTable {0}", dateTime);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SetFesRecommendSong(string dateTimeExport)
        {
            try
            {
                // Search
                DataTable tbKaraokeSong = GetKaraokeByDateTime(dateTimeExport);

                // Data compare
                DataTable dtRecommendSong = GetRecommendSong();


                DataTable dtResut = new DataTable();
                for (int i = 0; i <= 20; i++)
                {
                    dtResut.Columns.Add("Col" + i);
                }

                int columnIndex = 0;

                bool recommandFirstColNull = false;

                string value1;
                string value2;
                string valueRecomend1;


                var myDictionary = new Dictionary<string, string>();

                foreach (DataRow karaRow in tbKaraokeSong.Rows)
                {
                    value1 = karaRow.IsNull(0) ? null : karaRow.Field<object>(0).ToString();
                    value2 = karaRow.IsNull(1) ? null : karaRow.Field<object>(1).ToString();
                    if (string.IsNullOrEmpty(value1) || string.IsNullOrEmpty(value2))
                    {
                        continue;
                    }
                    myDictionary.Add(value1, value2);
                }

                int current_row = 0;

                // おすすめ曲
                foreach (DataRow recomRow in dtRecommendSong.Rows)
                {
                    var myList = new List<string>();

                    recommandFirstColNull = recomRow.IsNull(0);

                    if (recommandFirstColNull)
                    {
                        continue;
                    }

                    valueRecomend1 = recomRow.Field<object>(0).ToString();

                    columnIndex = 0;

                    foreach (DataColumn recomCol in dtRecommendSong.Columns)
                    {

                        if (columnIndex >= 20)
                        {
                            break;
                        }

                        if (columnIndex == 0 && !myDictionary.ContainsKey(valueRecomend1))
                        {
                            break;
                        }

                        if (columnIndex == 0)
                        {

                            myList.Add(myDictionary[valueRecomend1]);
                            columnIndex++;
                            continue;
                        }

                        valueRecomend1 = recomRow.IsNull(recomCol.ColumnName) ? null : recomRow.Field<object>(recomCol.ColumnName).ToString();

                        if (!string.IsNullOrEmpty(valueRecomend1) && myDictionary.ContainsKey(valueRecomend1))
                        {
                            myList.Add(myDictionary[valueRecomend1]);
                        }
                        columnIndex++;
                    }
                    if (myList.Count > 0)
                    {
                        dtResut.Rows.Add(myList.ToArray());
                        current_row++;
                    }
                }

                return dtResut;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BulkInsertRecommendSong(string server_filePath)
        {
            try
            {
                var query = string.Format("BULK INSERT WiiTmp.dbo.tbl_FesRecommendSong FROM '{0}'", server_filePath);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TruncadeRecommendSong()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, "truncate table WiiTmp.dbo.tbl_FesRecommendSong");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // <summary>
        /// GetKaraokeByDateTime
        /// </summary>
        /// <returns></returns>
        public DataTable GetKaraokeByDateTime(string dateTime)
        {
            try
            {
                string query = string.Format("SELECT [カラオケ選曲番号], [Wii(デジドコ)選曲番号] FROM dbo.[v_Fesコンテンツ] WHERE [サービス発表日]  <= {0} And [取消フラグ] is null Order By [カラオケ選曲番号]", dateTime);

                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get recommend song  Capioからのおすすめ曲のデータファイル取込を行う。
        /// </summary>
        /// <returns></returns>
        public DataTable GetRecommendSong()
        {
            try
            {
                string query = "SELECT [選曲番号], [おすすめ曲1], [おすすめ曲2], [おすすめ曲3], [おすすめ曲4], [おすすめ曲5], [おすすめ曲6], [おすすめ曲7], [おすすめ曲8], [おすすめ曲9], [おすすめ曲10], [おすすめ曲11], [おすすめ曲12], [おすすめ曲13], [おすすめ曲14], [おすすめ曲15],[おすすめ曲16], [おすすめ曲17], [おすすめ曲18], [おすすめ曲19], [おすすめ曲20] FROM Wii.dbo.[tbl_FesRecommendSong]";

                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void CreateFesContentsTable(string dateTime)
        {
            try
            {
                string query = string.Format("exec usp_CreateFesContentsTable {0}", dateTime);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesContentsAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesContentsAll");
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TruncateFesUpdateContentTable()
        {
            try
            {
                string query = string.Format("truncate table Wii.dbo.[tbl_Fes更新日時_コンテンツ]");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateFesUpdateContentTable()
        {
            try
            {
                string query = string.Format("INSERT INTO Wii.dbo.[tbl_Fes更新日時_コンテンツ] ([contents_ranking]) VALUES('{0}')", DateTime.Now.ToString("yyyyMMdd"));
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TruncateFesUpdateDateTimeTieUp()
        {
            try
            {
                string query = string.Format("truncate table Wii.dbo.[tbl_Fes更新日時_タイアップ]");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateFesUpdateDateTimeTieUp()
        {
            try
            {
                string query = string.Format("INSERT INTO Wii.dbo.[tbl_Fes更新日時_タイアップ] ([tieup_ranking]) VALUES('{0}')", DateTime.Now.ToString("yyyyMMdd"));
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetKaraokeYearRanking()
        {
            try
            {
                DataTable dtAges = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, string.Format("select [年代] from WiiTmp.dbo.[tbl_Fes年代別ランク] group by [年代] order by [年代]")).Tables[0];

                string updateSql = string.Empty;
                int rank = 1;

                foreach (DataRow row in dtAges.Rows)
                {
                    rank = 1;

                    if (row.IsNull(0))
                    {
                        continue;
                    }

                    object value = row.Field<object>(0);

                    DataTable dtAgeArr = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, string.Format("select [年代], [ランキング], [選曲番号] from WiiTmp.dbo.[tbl_Fes年代別ランク] WHERE [年代] = '{0}'", value)).Tables[0];



                    foreach (DataRow row2 in dtAgeArr.Rows)
                    {
                        string value1 = row2.IsNull(0) ? null : row2.Field<object>(0).ToString();
                        int value2 = row2.IsNull(1) ? -1 : (int)row2.Field<object>(1);
                        string value3 = row2.IsNull(2) ? null : row2.Field<object>(2).ToString();

                        if (value2 == -1)
                            continue;

                        updateSql = string.Format("UPDATE WiiTmp.dbo.[tbl_Fes年代別ランク] SET [ランキング] = {0} Where  [年代] = '{1}' and [ランキング] = {2} and [選曲番号] = '{3}'",

                            rank, value1, value2, value3);

                        SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, updateSql);
                        rank++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateFesRecommendProgramNameTable()
        {
            try
            {
                string query = string.Format("exec usp_CreateFesRecommendProgramNameTable");
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesRecommendProgramNameAll()
        {
            try
            {
                string query = string.Format("exec usp_SelectFesRecommendProgramNameAll");
               return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectFesLClassGenreListAll(string verson)
        {
            try
            {
                string query = string.Format("exec usp_SelectFesLClassGenreListAll {0}", verson);
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
