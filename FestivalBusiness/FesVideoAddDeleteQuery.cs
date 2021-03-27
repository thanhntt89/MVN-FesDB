using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Festival.Common;

namespace FestivalBusiness
{
    public class FesVideoAddDeleteQuery
    {
        public static string GetCreateWorkTableQuery(string workTmpName)
        {
            string query = string.Format("IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'{0}') AND type in (N'U')) BEGIN drop table {0} END; CREATE TABLE {0}([選択] [bit] NULL DEFAULT ((0)),[通番] [int] NULL,[追加削除区分] [tinyint] NULL,[背景ファイル名] [nvarchar](255) NULL,[FesDISCID] [nvarchar](10) NULL,[データサイズ] [int] NULL,[有償情報フラグ] [tinyint] NULL,[備考] [nvarchar](255) NULL,[登録日] [datetime] NULL,[削除] [bit] NULL DEFAULT ((0)),[更新日時] [datetime] NULL, [ID] [int] NOT NULL)", workTmpName);
            return query;
        }

        public static string GetUpdateWorkTmpQuery(string workTmpName)
        {
            string query = string.Format("UPDATE WiiTmp.[dbo].[tbl_Wrk_Fes映像DISC追加削除管理_{0}] set 選択 = 0, 更新日時 = NULL; UPDATE WiiTmp.[dbo].[tbl_Wrk_Fes映像DISC追加削除管理_{0}] SET 選択 = t1.選択,通番= t1.通番,追加削除区分 = t1.追加削除区分,背景ファイル名 = t1.背景ファイル名, FesDISCID = t1.FesDISCID,データサイズ = t1.データサイズ,有償情報フラグ = t1.有償情報フラグ,備考 = t1.備考,登録日 = CONVERT(varchar(8),t1.登録日,112),削除 = t1.削除,更新日時 = t1.更新日時 FROM WiiTmp.[dbo].[tbl_Wrk_Fes映像DISC追加削除管理_{0}] INNER JOIN [{1}] AS t1 ON WiiTmp.[dbo].[tbl_Wrk_Fes映像DISC追加削除管理_{0}].ID = t1.ID ; DROP TABLE {1}", Environment.MachineName.Replace("-", ""), workTmpName);
            return query;
        }

        internal static string GetWorkTmpQuery()
        {
            string query = string.Format("select 選択,通番,追加削除区分,背景ファイル名,FesDISCID,データサイズ,有償情報フラグ,備考,CONVERT(datetime,登録日) as 登録日,削除,CONVERT(datetime,更新日時) as 更新日時,ID from WiiTmp.dbo.[tbl_Wrk_Fes映像DISC追加削除管理_{0}] order by [通番], [ID]", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetTruncateInputSongNumberTableTmpQuery()
        {
            string query = string.Format("TRUNCATE TABLE WiiTmp.dbo.[tbl_Wrk_Fes背景映像コード_{0}]", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetInsertVideoNumberTableTmpQuery(List<string> SongNumberList)
        {
            string songNumbers = string.Empty;
            var query = string.Empty;

            if (SongNumberList.Count == 0)
                return songNumbers;

            foreach (var songNum in SongNumberList)
            {
                songNumbers += string.Format("('{0}'),", songNum);
            }
            songNumbers = songNumbers.Remove(songNumbers.Length - 1);

            query = string.Format("INSERT INTO WiiTmp.dbo.[tbl_Wrk_Fes背景映像コード_{0}] ([背景映像コード]) VALUES {1}", Environment.MachineName.Replace("-", "_"), songNumbers);

            return query;
        }

        public static string GetInsertWorkTableTmpQuery()
        {
            string query = string.Format("insert into WiiTmp.dbo.[tbl_Wrk_Fes映像DISC追加削除管理_{0}]([ID],[通番],[追加削除区分],[背景ファイル名],[FesDISCID],[データサイズ],[有償情報フラグ],[備考],[登録日],[未出力フラグ],[削除フラグ]) select[ID],[通番],[追加削除区分],[背景ファイル名],[FesDISCID],[データサイズ],[有償情報フラグ],[備考],[登録日],[未出力フラグ],[削除フラグ]  from Wii.dbo.[v_Fes映像DISC追加削除管理] ", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetIndividualVideoFISCManagementWorkUpdateDataQuery()
        {
            string query = string.Format("select  [ID],[通番],[追加削除区分],[背景ファイル名],[FesDISCID],[データサイズ],[有償情報フラグ],[備考] ,[登録日] from  WiiTmp.dbo.[tbl_Wrk_Fes映像DISC追加削除管理_{0}] where [更新日時] is not null and [削除] <> 1 order by [通番],[ID]", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetImportVideoDiscManagementWorkTableQuery()
        {
            string query = GetInsertWorkTableTmpQuery();
            query += string.Format(" where [背景ファイル名] in ( select [背景映像コード] from  WiiTmp.dbo.[tbl_Wrk_Fes背景映像コード_{0}])", Environment.MachineName.Replace("-", "_"));
            return query;
        }

        internal static string GetGetRegisterDataByIdQuery(string id)
        {
            string query = string.Format("select ID,通番,追加削除区分,背景ファイル名,FesDISCID,データサイズ,有償情報フラグ,備考,登録日,未出力フラグ,削除フラグ,	最終更新日時,最終更新者,最終更新PC名 from Wii.dbo.[Fes映像DISC追加削除管理] where [ID] = {0} ", id);
            return query;
        }

        internal static string GetTruncateVideoDiscManagementWorkTmpQuery()
        {
            string query = string.Format("TRUNCATE TABLE WiiTmp.dbo.[tbl_Wrk_Fes映像DISC追加削除管理_{0}] ", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetUpdateFlagVideoManagementQuery()
        {
            string query = string.Format("update Wii.dbo.[Fes映像DISC追加削除管理] set [削除フラグ] = 2 from (select max([ID]) as [更新ID]  from Wii.dbo.[Fes映像DISC追加削除管理] as t2 where exists (select 'x' from Wii.dbo.[Fes映像DISC追加削除管理]  as t3 where t3.[削除フラグ] = 0 and t3.[ID] in (select [ID] from WiiTmp.dbo.[tbl_Wrk_Fes映像DISC追加削除管理_{0}] where [削除] = 1 ) and t3.[背景ファイル名] = t2.[背景ファイル名]  and t3.[FesDISCID] = t2.[FesDISCID]) and t2.[削除フラグ] = 1 group by t2.[背景ファイル名] ,t2.[FesDISCID]) iv1 where [ID] = iv1.[更新ID] ", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetInsertNewRowVideoManagementWorkTableQuery(bool isDataSourceEmpty)
        {
            string query = string.Format("INSERT INTO WiiTmp.dbo.[tbl_Wrk_Fes映像DISC追加削除管理_{0}] (ID,通番, 更新日時) select (max(Id) + 1), (max(通番) + 1), GetDate() from WiiTmp.dbo.[tbl_Wrk_Fes映像DISC追加削除管理_{0}]  ", Environment.MachineName.Replace("-", ""));
            if (isDataSourceEmpty)
                query = string.Format("INSERT INTO WiiTmp.dbo.[tbl_Wrk_Fes映像DISC追加削除管理_{0}] (ID,通番, 更新日時) select (max(Id) + 1), (max(通番) + 1),GetDate() from Wii.dbo.[v_Fes映像DISC追加削除管理]", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetSelectLastVideoRecordQuery()
        {
            string query = string.Format("select top(1)* from WiiTmp.dbo.[tbl_Wrk_Fes映像DISC追加削除管理_{0}] order by ID desc", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetExecuteSearchVideoDiscManagementWorkTmpQuery(List<string> slqParameters)
        {
            string query = GetInsertWorkTableTmpQuery();
            // Input not set
            if (slqParameters.Count > 0)
            {
                string parameter = string.Empty;
                slqParameters.ToList().ForEach(para => parameter += para + " ");
                query = query + " where 1=1 " + parameter;
            }

            return query;
        }

        internal static string GetInsertInputNumberToWorkTableQuery(EnumInputNumberType inputNumberType)
        {
            string query = GetInsertWorkTableTmpQuery();
            if (inputNumberType == EnumInputNumberType.VideoNumber)
            {
                query += string.Format(" where [背景ファイル名] in ( select [背景映像コード] from WiiTmp.dbo.[tbl_Wrk_Fes背景映像コード_{0}])", Environment.MachineName.Replace("-", ""));
            }
            return query;
        }

        internal static string GetInsertRegisterTableQuery(DataTable tbRegister)
        {
            DataRow row = tbRegister.Rows[0];
            string columnValue = string.Empty;
            string values = string.Empty;
            foreach (DataColumn col in tbRegister.Columns)
            {
                if (row[col] == null || string.IsNullOrWhiteSpace(row[col].ToString()))
                    columnValue = "NULL";
                else
                    columnValue = "N'" + row[col] + "'";
                if (col.ColumnName.Equals("最終更新日時"))
                    columnValue = "GetDate()";
                values += columnValue + ",";
            }
            values = values.Remove(values.Length - 1, 1);
            string query = string.Format("INSERT INTO Wii.dbo.[Fes映像DISC追加削除管理] (ID,通番,追加削除区分,背景ファイル名,FesDISCID,データサイズ,有償情報フラグ,備考,登録日,未出力フラグ,削除フラグ,最終更新日時,最終更新者,最終更新PC名) VALUES({0})", values);
            return query;
        }

        internal static string GetVideoCheckQuery(string id, string fesId, string fileName)
        {
            string query = string.Format("select [背景ファイル名] from  Wii.dbo.[Fes映像DISC追加削除管理] where [追加削除区分] = 0 and [削除フラグ] = 0 and [背景ファイル名] = '{0}' and [FesDISCID] <> '{1}' and [ID] <> '{2}'", fileName, fesId, id);
            return query;
        }

        internal static string GetFesVideoSourceByIdQuery(string id)
        {
            string query = string.Format("select [ID],[通番],[追加削除区分],[背景ファイル名],[FesDISCID],[データサイズ],[有償情報フラグ],[備考],[登録日],[未出力フラグ],[削除フラグ]  from Wii.dbo.[v_Fes映像DISC追加削除管理] where [追加削除区分] = 0 and [削除フラグ] = 0 and [背景ファイル名] = '{0}'", id);
            return query;
        }

        internal static string GetColumnsAddNewVideoWorkTableQuery()
        {
            string query = string.Format("select [ID],[通番],[追加削除区分],[背景ファイル名],[FesDISCID],[データサイズ],[有償情報フラグ],[備考],[登録日] ,[未出力フラグ],[削除フラグ],[選択],[削除],[更新日時] from WiiTmp.dbo.[tbl_Wrk_Fes映像DISC追加削除管理_{0}]", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetUpdateRegisterTableQuery(DataTable tbRegister)
        {
            DataRow row = tbRegister.Rows[0];
            string id = string.Empty;
            string columnValue = string.Empty;
            string values = string.Empty;
            foreach (DataColumn col in tbRegister.Columns)
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
                if (col.ColumnName.Equals("最終更新日時"))
                    columnValue = "GetDate()";
                values += col.ColumnName + " = " + columnValue + ",";
            }
            values = values.Remove(values.Length - 1, 1);
            string query = string.Format("UPDATE Wii.dbo.[Fes映像DISC追加削除管理] SET {0} WHERE ID = '{1}' ", values, id);
            return query;
        }

        internal static string GetInsertNewRowVideoManagementWorkTableQuery(DataTable dtAddNewVideoWorkTable)
        {
            DataRow row = dtAddNewVideoWorkTable.Rows[0];
            string columns = string.Empty;
            string values = string.Empty;

            foreach (DataColumn col in dtAddNewVideoWorkTable.Columns)
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

            string query = string.Format("INSERT INTO WiiTmp.dbo.[tbl_Wrk_Fes映像DISC追加削除管理_{0}]({1}) VALUES({2})", Environment.MachineName.Replace("-", ""), columns, values);
            return query;
        }

        internal static string GetVideoCheckDeleteQuery(string id, string fesDiscId, string fileName)
        {
            string query = string.Format("select [背景ファイル名] from  Wii.dbo.[Fes映像DISC追加削除管理] where [追加削除区分] = 0 and [削除フラグ] = 0 and [背景ファイル名] = '{0}' and [FesDISCID] = '{1}' and [ID] <> '{2}'", fileName, fesDiscId, id);
            return query;
        }

        internal static string GetUpdateVideoWorkTableQuery(string id)
        {
            string query = string.Format("update WiiTmp.dbo.[tbl_Wrk_Fes映像DISC追加削除管理_{0}] set [更新日時]= NULL WHERE [ID] = '{1}'", Environment.MachineName.Replace("-", ""), id);
            return query;
        }

        internal static string GetUpdateVideoLastDateQuery(string id, string fesId, string fileName)
        {
            string query = string.Format("update dbo.[Fes映像DISC追加削除管理] set [削除フラグ] = (CASE WHEN [ID] = '{0}' THEN [削除フラグ] ELSE 1 END) ,[最終更新日時] = getdate(),[最終更新者] = '{1}',[最終更新PC名] = '{2}' where[ID] in (select t2.[ID] from dbo.[Fes映像DISC追加削除管理] as t2 where t2.[削除フラグ] = 0 and t2.[背景ファイル名] = '{3}' and t2.[FesDISCID] = '{4}')", id, Environment.UserName, Environment.MachineName.Replace("-", ""), fileName, fesId);
            return query;
        }

        internal static string GetUpdateVideoTableQuery()
        {
            string query = string.Format("update Wii.dbo.[Fes映像DISC追加削除管理] set [削除フラグ] = 0 WHERE [削除フラグ] = 2");
            return query;
        }

        internal static string GetUpdateVideoWorkTableQuery()
        {
            string query = string.Format("update WiiTmp.dbo.[tbl_Wrk_Fes映像DISC追加削除管理_{0}] set [削除フラグ] = 0 WHERE [ID] in (select ID from Wii.dbo.[Fes映像DISC追加削除管理] where [削除フラグ] = 2)", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetDeleteVideoManagementQuery()
        {
            string query = string.Format("DELETE FROM Wii.dbo.[Fes映像DISC追加削除管理] WHERE  [削除フラグ] = 0 AND [未出力フラグ] = 0 AND [ID] in (SELECT [ID] FROM WiiTmp.dbo.[tbl_Wrk_Fes映像DISC追加削除管理_{0}] WHERE [削除] = 1)", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetDeleteVideoWorkTableQuery()
        {
            string query = string.Format("DELETE FROM WiiTmp.dbo.[tbl_Wrk_Fes映像DISC追加削除管理_{0}] WHERE [削除] = 1", Environment.MachineName.Replace("-", ""));
            return query;
        }

        internal static string GetUpdateVideoSetDeleteFlagQuery(string id, string fesId, string fileName)
        {
            string query = string.Format("update Wii.dbo.[Fes映像DISC追加削除管理] set [削除フラグ] = 0 where [ID] = (select max([ID]) from Wii.dbo.[Fes映像DISC追加削除管理] where [ID] <> '{0}'  and [FesDISCID] = '{1}' and [背景ファイル名] = '{2}') and [追加削除区分] = 1 and [削除フラグ] = 1 ", id, fesId, fileName);
            return query;
        }
    }
}
