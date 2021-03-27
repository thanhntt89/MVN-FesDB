using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalBusiness
{
    public class ImportRecommendSongQuery
    {
        internal static string GetRecommendSongSourceQuery(string songNumer)
        {
            string query = string.Format("select v1.[デジドココンテンツID],v1.[Wii(デジドコ)選曲番号],v1.[カラオケ選曲番号],v1.[楽曲名],v1.[歌手名],t2.[FesDISCID],v1.[有料コンテンツフラグ],t2.[有償情報フラグ],v1.[サービス発表日],v1.[取消フラグ] from Wii.dbo.v_Fes選曲番号関連情報 as v1 left outer join Wii.dbo.FesDISC追加削除管理 as t2 WITH (NOLOCK) on  v1.[デジドココンテンツID] = t2.[デジドココンテンツID] and t2.[追加削除区分] = 0 and t2.[削除フラグ] = 0 where v1.[Wii(デジドコ)選曲番号] ={0}", songNumer);

            return query;
        }

        internal static string GetInsertRecommendSongWorkTableQuery(DataTable dtRecommendSongDes)
        {
            DataRow row = dtRecommendSongDes.Rows[0];
            string columns = string.Empty;
            string values = string.Empty;

            foreach (DataColumn col in dtRecommendSongDes.Columns)
            {
                if (col.ColumnName.Equals("ID")) continue;

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

            string query = string.Format("INSERT INTO WiiTmp.[dbo].[tbl_Wrk_Fesおすすめ曲管理_{0}]({1}) VALUES({2})", Environment.MachineName.Replace("-", ""), columns, values);
            return query;            
        }

        internal static string GetRecommendSongDesQuery(object programCheckId, string contentId, string displayOrder)
        {
            string query = string.Empty;
            if (programCheckId == null || string.IsNullOrEmpty(programCheckId.ToString()))
                query = string.Format("select [プログラムID],[デジドココンテンツID],[Wii(デジドコ)選曲番号],[カラオケ選曲番号],[楽曲名],[歌手名],[FesDISCID],[有料コンテンツフラグ],[有償情報フラグ],[サービス発表日],[取消フラグ],[表示順],[ID],[選択],[削除],[更新日時] from WiiTmp.dbo.[tbl_Wrk_Fesおすすめ曲管理_{0}] where [プログラムID] is null ", Environment.MachineName.Replace("-", ""));
            else
                query = string.Format("select [プログラムID],[デジドココンテンツID],[Wii(デジドコ)選曲番号],[カラオケ選曲番号],[楽曲名],[歌手名],[FesDISCID],[有料コンテンツフラグ],[有償情報フラグ],[サービス発表日],[取消フラグ],[表示順],[ID],[選択],[削除],[更新日時] from WiiTmp.dbo.[tbl_Wrk_Fesおすすめ曲管理_{0}] where [プログラムID] ={1} ", Environment.MachineName.Replace("-", ""), programCheckId);

            query += string.Format(" and [デジドココンテンツID] ={0} and [表示順] = {1} ", contentId, displayOrder);

            return query;
        }

        internal static string GetUpdateRecommendSongWorkTableQuery(DataTable dtRecommendSongDes)
        {
            DataRow row = dtRecommendSongDes.Rows[0];
            string id = string.Empty;
            string columnValue = string.Empty;
            string values = string.Empty;
            foreach (DataColumn col in dtRecommendSongDes.Columns)
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
                if (col.ColumnName.Equals("更新日時"))
                    columnValue = "GetDate()";
                values += "[" + col.ColumnName + "] = " + columnValue + ",";
            }
            values = values.Remove(values.Length - 1, 1);
            string query = string.Format("UPDATE  WiiTmp.[dbo].[tbl_Wrk_Fesおすすめ曲管理_{0}]  SET {1} WHERE ID = {2} ", Environment.MachineName.Replace("-", ""), values, id);
            return query;            
        }
    }
}
