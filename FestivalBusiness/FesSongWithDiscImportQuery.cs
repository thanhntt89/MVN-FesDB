using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalBusiness
{
    public class FesSongWithDiscImportQuery
    {
        internal static string GetBulkInsertFesDiscAllocationTableQuery(string serverFile)
        {
            string query = string.Format("BULK INSERT Wii.dbo.[tbl_FesDISCID割付リスト] FROM '{0}'", serverFile);
            return query;
        }

        internal static string GetTruncateFesDiscAllocationTableQuery()
        {
            string query = string.Format("truncate table Wii.dbo.[tbl_FesDISCID割付リスト]");
            return query;
        }

        internal static string GetCheckDuplicateSongSelectionQuery()
        {
            string query = string.Format("select iv1.[選曲番号] as [選曲番号] from(select t1.[選曲番号], count(t1.[選曲番号]) as [件数] from Wii.dbo.[tbl_FesDISCID割付リスト] as t1 group by t1.[選曲番号]) as iv1 where iv1.[件数] > 1 order by iv1.[選曲番号]");
            return query;
        }

        internal static string GetCheckSongSelectionUpdateQuery()
        {
            string query = string.Format("select t1.[選曲番号] as [選曲番号] from Wii.dbo.[tbl_FesDISCID割付リスト] as t1 where not exists(select 'x' from Wii.dbo.[v_FesDISC収録情報] as t2  where  t1.[選曲番号] = t2.[Wii(デジドコ)選曲番号])");
            return query;
        }

        internal static string GetUpdateFesDiscRecordingManagementQuery(int versionNo)
        {
            string query = string.Format("update  Wii.dbo.[FesDISC収録管理] set  [削除フラグ] = 1 ,[最終更新日時] = getdate() ,[最終更新者] = '{0}' ,[最終更新PC名] = '{1}'  where  [デジドココンテンツID] in ( select t2.[デジドココンテンツID] from  Wii.dbo.[v_FesDISC収録情報] as t2  where  exists(select 'x' from  Wii.dbo.[tbl_FesDISCID割付リスト] as t3 where  t2.[Wii(デジドコ)選曲番号] = t3.[選曲番号])) and [削除フラグ] = 0 and [バージョンNO] = '{2}'", Environment.UserName, Environment.MachineName.Replace("-",""), versionNo);
            return query;
        }

        internal static string GetInsertFesDiscRecordingManagementQuery(int versionNo)
        {
            string query = string.Format("insert into  Wii.dbo.[FesDISC収録管理] select t2.[デジドココンテンツID] ,t1.[FesDISCID] ,t1.[NET利用フラグ] ,t1.[取消日] ,null ,0 ,getdate() ,'{0} ' ,'{1}' ,'{2}' from  Wii.dbo.[tbl_FesDISCID割付リスト] as t1 inner join  Wii.dbo.[v_デジ・ドココンテンツ] as t2  on  t1.[選曲番号] = t2.[選曲番号] ", Environment.UserName, Environment.MachineName.Replace("-", ""), versionNo);
            return query;
        }

        internal static string GetCheckFesDiscCommitQuery(int verSion)
        {
            string query = string.Format("select iv1.[デジドココンテンツID]  from (select t1.[デジドココンテンツID] ,count(t1.[デジドココンテンツID]) as [件数]  from Wii.dbo.[FesDISC収録管理] as t1  where t1.[削除フラグ] = 0  and t1.[バージョンNO] = '{0}'  group by  t1.[デジドココンテンツID]) as iv1  where iv1.[件数] > 1 ", verSion);
            return query;
        }
    }
}
