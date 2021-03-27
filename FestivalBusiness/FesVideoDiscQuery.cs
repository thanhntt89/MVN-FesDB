using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalBusiness
{
    public class FesVideoDiscQuery
    {
        internal static string GetFesIndividualVideoDiscQuery()
        {
            string query = string.Format("SELECT 背景ファイル名, FesDISCID FROM Wii.dbo.Fes映像DISC追加削除管理 WHERE (追加削除区分 = 0) AND (削除フラグ = 0) ORDER BY 背景ファイル名, FesDISCID");
            return query;
        }
    }
}
