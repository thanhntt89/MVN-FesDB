using FestivalObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalBusiness
{
    public class SingerIdChangeManagementBusiness : BusinessBase
    {
        public DataTable GetSingerIdChangeAllTable()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, SingerIdChangeManagementQuery.GetSingerIdChangeDataAllQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Save(SingerIdChangeManagementObject singerManagement)
        {
            try
            {
                // Add New
                if (string.IsNullOrEmpty(singerManagement.履歴No))
                    SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, SingerIdChangeManagementQuery.GetInsertSingerIdChangeManagmentQuery(singerManagement));
                else // Update
                    SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, SingerIdChangeManagementQuery.GetUpdateSingerIdChangeManagmentQuery(singerManagement));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteSingerId(string deleteId)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, SingerIdChangeManagementQuery.GetDeleteSingerIdChangeByIdQuery(deleteId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public SingerIdChangeManagementObject GetSingerIdChangeById(string updateId)
        {
            try
            {
                SingerIdChangeManagementObject singerManagement = new SingerIdChangeManagementObject();
                // Add New
                DataTable dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, SingerIdChangeManagementQuery.GetSingerIdChangeManagmentByIdQuery(updateId)).Tables[0];
                if (dt.Rows.Count == 0)
                    return null;
                singerManagement.履歴No = dt.Rows[0]["履歴No"].ToString();
                singerManagement.変更前_歌手ID = int.Parse(dt.Rows[0]["変更前_歌手ID"].ToString());
                singerManagement.変更前_歌手名 = dt.Rows[0]["変更前_歌手名"] == null ? string.Empty : dt.Rows[0]["変更前_歌手名"].ToString();
                singerManagement.変更前_歌手名検索用カナ = dt.Rows[0]["変更前_歌手名検索用カナ"] == null ? string.Empty : dt.Rows[0]["変更前_歌手名検索用カナ"].ToString();
                singerManagement.変更前_歌手名ソート用カナ = dt.Rows[0]["変更前_歌手名ソート用カナ"] == null ? string.Empty : dt.Rows[0]["変更前_歌手名ソート用カナ"].ToString();
                singerManagement.変更後_歌手ID = int.Parse(dt.Rows[0]["変更後_歌手ID"].ToString());
                singerManagement.変更後_歌手名 = dt.Rows[0]["変更後_歌手名"] == null ? string.Empty : dt.Rows[0]["変更後_歌手名"].ToString();
                singerManagement.変更後_歌手名検索用カナ = dt.Rows[0]["変更後_歌手名検索用カナ"] == null ? string.Empty : dt.Rows[0]["変更後_歌手名検索用カナ"].ToString();
                singerManagement.変更後_歌手名ソート用カナ = dt.Rows[0]["変更後_歌手名ソート用カナ"] == null ? string.Empty : dt.Rows[0]["変更後_歌手名ソート用カナ"].ToString();
                singerManagement.変更日時 = (DateTime)dt.Rows[0]["変更日時"];
                singerManagement.変更利用者ID = dt.Rows[0]["変更利用者ID"].ToString();

                return singerManagement;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
