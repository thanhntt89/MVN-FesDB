using System;
using FestivalCommon;
using System.Collections.Generic;

namespace FestivalBusiness
{
    public class FesVideoAssigmentInputSongNumberQuery
    {
        internal static string GetTruncateFesVideoAssigmentWorkTableQuery()
        {
            string query = string.Format("TRUNCATE TABLE WiiTmp.dbo.[tbl_Wrk_Fes個別映像割付_{0}]", Environment.MachineName.Replace("-", "_"));           
            return query;
        }

        internal static string GetInsertFesVideoAssigmentWorkTableQuery(FunctionEntity function)
        {
            string query = FesVideoAssigmentQuery.GetInsertVideoAssimentWorkTmpQuery();
            if (function.FunctionName == EnumInputTypeName.選曲番号入力)
            {
                query += string.Format(" where [Wii(デジドコ)選曲番号] in ( select [選曲番号] from WiiTmp.dbo.[tbl_Wrk_Fes選曲番号_{0}])", Environment.MachineName.Replace(" - ", "_"));
            }
            else if (function.FunctionName == EnumInputTypeName.選曲番号入力カラオケ)
            {
                query += string.Format("where [カラオケ選曲番号] in ( select [選曲番号] from WiiTmp.dbo.[tbl_Wrk_Fes選曲番号_{0}])", Environment.MachineName.Replace(" - ", "_"));
            }
            else if (function.FunctionName == EnumInputTypeName.背景映像コード入力)
            {
                query += string.Format("where [背景映像コード] in ( select [背景映像コード] from WiiTmp.dbo.[tbl_Wrk_Fes背景映像コード_{0}])", Environment.MachineName.Replace(" - ", "_"));
            }
            return query;
        }

        internal static string GetInsertSongNumberTableTmpQuery(FunctionEntity function, List<string> SongNumberList)
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
                                 
            if (function.FunctionName == EnumInputTypeName.選曲番号入力)
                query = string.Format("INSERT INTO WiiTmp.dbo.[tbl_Wrk_Fes選曲番号_{0}] (選曲番号) VALUES {1}", Environment.MachineName.Replace("-", "_"), songNumbers);
            else if (function.FunctionName == EnumInputTypeName.選曲番号入力カラオケ)
                query = string.Format("INSERT INTO WiiTmp.dbo.[tbl_Wrk_Fes選曲番号_{0}] (選曲番号) VALUES {1}", Environment.MachineName.Replace("-", "_"), songNumbers);
            else if (function.FunctionName == EnumInputTypeName.背景映像コード入力)
                query = string.Format("INSERT INTO WiiTmp.dbo.[tbl_Wrk_Fes背景映像コード_{0}] (背景映像コード) VALUES {1}", Environment.MachineName.Replace("-", "_"), songNumbers);
            return query;
        }

        internal static string GetTruncateInputSongNumberTableTmpQuery(FunctionEntity function)
        {
            string query = string.Empty;
            if (function.FunctionName == EnumInputTypeName.選曲番号入力)
                query = string.Format("TRUNCATE TABLE WiiTmp.dbo.[tbl_Wrk_Fes選曲番号_{0}]", Environment.MachineName.Replace("-", "_"));
            else if (function.FunctionName == EnumInputTypeName.選曲番号入力カラオケ)
                query = string.Format("TRUNCATE TABLE WiiTmp.dbo.[tbl_Wrk_Fes選曲番号_{0}]", Environment.MachineName.Replace("-", "_"));
            else if (function.FunctionName == EnumInputTypeName.背景映像コード入力)
                query = string.Format("TRUNCATE TABLE WiiTmp.dbo.[tbl_Wrk_Fes背景映像コード_{0}]", Environment.MachineName.Replace("-", "_"));
            return query;
        }
    }
}
