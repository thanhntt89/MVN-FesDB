using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FestivalObjects;

namespace FestivalBusiness
{
    public class SingerIdChangeManagementQuery
    {
        internal static string GetSingerIdChangeDataAllQuery()
        {
            string query = string.Format("SELECT 変更利用者ID,変更日時,変更前_歌手ID,	変更前_歌手名,変更前_歌手名検索用カナ,変更前_歌手名ソート用カナ,変更後_歌手ID,変更後_歌手名,変更後_歌手名検索用カナ,変更後_歌手名ソート用カナ, 履歴No, CONVERT(datetime,NULL) as DateTimeUpdate FROM Wii.dbo.[Fes歌手ID変更履歴] order by 履歴No desc");
            return query;
        }

        internal static string GetInsertSingerIdChangeManagmentQuery(SingerIdChangeManagementObject singerManagement)
        {
            string dateTime = ((DateTime)singerManagement.変更日時).ToString("yyyy/MM/dd") +" "+ DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            string query = string.Format("INSERT INTO Wii.[dbo].[Fes歌手ID変更履歴](変更前_歌手ID,変更前_歌手名,変更前_歌手名検索用カナ,変更前_歌手名ソート用カナ,変更後_歌手ID,変更後_歌手名,変更後_歌手名検索用カナ,変更後_歌手名ソート用カナ,変更日時,変更利用者ID) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
                singerManagement.変更前_歌手ID,
                singerManagement.変更前_歌手名,
                singerManagement.変更前_歌手名検索用カナ,
                singerManagement.変更前_歌手名ソート用カナ,
                singerManagement.変更後_歌手ID,
                singerManagement.変更後_歌手名,
                singerManagement.変更後_歌手名検索用カナ,
                singerManagement.変更後_歌手名ソート用カナ,
                dateTime,
                singerManagement.変更利用者ID
                );
            return query;
        }

        internal static string GetDeleteSingerIdChangeByIdQuery(string deleteId)
        {
            string query = string.Format("DELETE FROM Wii.[dbo].[Fes歌手ID変更履歴] WHERE 履歴No = {0}", deleteId);
            return query;
        }

        internal static string GetUpdateSingerIdChangeManagmentQuery(SingerIdChangeManagementObject singerManagement)
        {
            string dateTime = ((DateTime)singerManagement.変更日時).ToString("yyyy/MM/dd") + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            string query = string.Format("UPDATE Wii.[dbo].[Fes歌手ID変更履歴] SET 変更前_歌手ID = '{0}',変更前_歌手名 = '{1}',変更前_歌手名検索用カナ = '{2}',変更前_歌手名ソート用カナ = '{3}',変更後_歌手ID = '{4}',変更後_歌手名 = '{5}',変更後_歌手名検索用カナ = '{6}',変更後_歌手名ソート用カナ = '{7}',変更日時 = '{8}',変更利用者ID = '{9}' WHERE 履歴No = {10}",
               singerManagement.変更前_歌手ID,
               singerManagement.変更前_歌手名,
               singerManagement.変更前_歌手名検索用カナ,
               singerManagement.変更前_歌手名ソート用カナ,
               singerManagement.変更後_歌手ID,
               singerManagement.変更後_歌手名,
               singerManagement.変更後_歌手名検索用カナ,
               singerManagement.変更後_歌手名ソート用カナ,
               dateTime,
               singerManagement.変更利用者ID,
               singerManagement.履歴No
               );
            return query;
        }

        internal static string GetSingerIdChangeManagmentByIdQuery(string updateId)
        {
            string query = string.Format("SELECT 履歴No,変更前_歌手ID,変更前_歌手名,変更前_歌手名検索用カナ,変更前_歌手名ソート用カナ,変更後_歌手ID,変更後_歌手名,変更後_歌手名検索用カナ,変更後_歌手名ソート用カナ,変更日時,変更利用者ID,Time_Stamp FROM [Fes歌手ID変更履歴] WHERE [履歴No] = {0}", updateId);
            return query;
        }
    }
}
