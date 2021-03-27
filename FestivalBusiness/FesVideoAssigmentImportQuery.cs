using System;
using System.Data;

namespace FestivalBusiness
{
    public class FesVideoAssigmentImportQuery
    {   
        internal static string GetFesVideoAssigmentByKaraokeNumberQuery(string karaokeNumber)
        {
            string query = string.Format("select  [デジドココンテンツID] ,[Wii(デジドコ)選曲番号] ,[カラオケ選曲番号] ,[楽曲名] ,[歌手名] ,[楽曲名検索用カナ] ,[曲名よみがな補正] ,[歌手名検索用カナ] ,[背景映像コード] ,[アップ予定日] ,[サービス発表日] ,[取消フラグ] ,[JV映像区分(背景映像区分)] ,[備考] from  Wii.dbo.[v_Fes映像コード管理] where カラオケ選曲番号 = '{0}'", karaokeNumber);
            return query;
        }

        internal static string GetFesVideoAssigmentColumnsQuery()
        {
            string query = string.Format("select TOP 0 [デジドココンテンツID] ,[Wii(デジドコ)選曲番号] ,[カラオケ選曲番号] ,[楽曲名] ,[歌手名] ,[楽曲名検索用カナ] ,[曲名よみがな補正] ,[歌手名検索用カナ] ,[背景映像コード] ,[アップ予定日] ,[サービス発表日] ,[取消フラグ] ,[JV映像区分(背景映像区分)] ,[備考] ,[選択] ,[削除] ,[更新日時] from WiiTmp.dbo.[tbl_Wrk_Fes個別映像割付_{0}]", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetInsertFesVideoAssigmentQuery(DataTable dtFesAssigmentDes)
        {
            DataRow row = dtFesAssigmentDes.Rows[0];
            string columns = string.Empty;
            string values = string.Empty;

            foreach (DataColumn col in dtFesAssigmentDes.Columns)
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
                    values += "N'" + row[col].ToString().Replace("'", "''") + "',";
            }

            columns = columns.Remove(columns.Length - 1, 1);
            values = values.Remove(values.Length - 1, 1);

            string query = string.Format("INSERT INTO WiiTmp.dbo.[tbl_Wrk_Fes個別映像割付_{0}]({1}) VALUES({2})", Environment.MachineName.Replace("-", ""), columns, values);
            return query;            
        }

        internal static string GetTruncateFesVideoAssigmentWorkQuery()
        {
            string query = string.Format("TRUNCATE TABLE WiiTmp.dbo.[tbl_Wrk_Fes個別映像割付_{0}]", Environment.MachineName.Replace("-", ""));
            return query;
        }
    }
}
