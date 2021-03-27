using FestivalCommon;
using System;
using System.Collections.Generic;

namespace FestivalBusiness
{
    public class FesSongWithDiscInputSongNumberQuery
    {
        internal static string GetTruncateInputSongNumberTableTmpQuery()
        {
            string query = string.Format("truncate table WiiTmp.dbo.[tbl_Wrk_Fes選曲番号_{0}]", Environment.MachineName.Replace(" -", "_"));
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

            query = string.Format("INSERT INTO WiiTmp.dbo.[tbl_Wrk_Fes選曲番号_{0}] (選曲番号) VALUES {1}", Environment.MachineName.Replace("-", ""), songNumbers);

            return query;
        }

        internal static string GetTruncateFesSongWithDiscWorkTableQuery(FunctionEntity function, DisVersion currentVersion)
        {
           return FesSongWithDiscQuery.GetTruncateWorkTable();   
        }

        internal static string GetInsertFesSongWithDiscWorkTableQuery(FunctionEntity function, DisVersion currentVersion)
        {
            var query = FesSongWithDiscQuery.GetInsertFesSongWithDiscWorkTmp(currentVersion);
            if (function.FunctionName == EnumInputTypeName.選曲番号入力)
            {
                query += string.Format(" where [Wii(デジドコ)選曲番号] in ( select [選曲番号] from  WiiTmp.dbo.[tbl_Wrk_Fes選曲番号_{0}])", Environment.MachineName.Replace("-", "_"));
            }
            else if (function.FunctionName == EnumInputTypeName.選曲番号入力カラオケ)
            {
                query += string.Format(" where [カラオケ選曲番号] in ( select [選曲番号] from WiiTmp.dbo.[tbl_Wrk_Fes選曲番号_{0}])", Environment.MachineName.Replace("-", "_"));
            }
            else if (currentVersion == DisVersion.VERSION_NUMBER_V1)
            {
                query += string.Format(" where [FesDISCID] in ( select [選曲番号] from  WiiTmp.dbo.[tbl_Wrk_Fes選曲番号_{0}])", Environment.MachineName.Replace("-", "_"));
            }
            else if (currentVersion == DisVersion.VERSION_NUMBER_V2)
            {
                query += string.Format(" where [FesDISCID(Ver2)] in ( select [選曲番号] from WiiTmp.dbo.[tbl_Wrk_Fes選曲番号_{0}])", Environment.MachineName.Replace("-", "_"));
            }

            return query;
        }
    }
}
