using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalBusiness
{
    public class TieupDuplicateQuery
    {

        public static string GetFesGenreQuery()
        {
            string query = string.Format("SELECT t1.[バージョンNO], t1.タイアップID, t1.タイアップ区分, t1.タイアップ表示用, t1.タイアップ検索用カナ, t1.[タイアップソート用カナ] FROM WiiTmp.dbo.tbl_Fesタイアップ情報 t1 INNER JOIN (SELECT [バージョンNO], [タイアップ表示用], COUNT([タイアップID]) AS [同名件数] FROM WiiTmp.dbo.[tbl_Fesタイアップ情報] GROUP BY [バージョンNO], [タイアップ表示用]) iv1 ON t1.[バージョンNO] = iv1.[バージョンNO] AND t1.タイアップ表示用 = iv1.タイアップ表示用 AND iv1.同名件数 > 1 ORDER BY t1.[バージョンNO], t1.タイアップ表示用, t1.タイアップID, t1.タイアップ区分");
            return query;
        }
    }
}
