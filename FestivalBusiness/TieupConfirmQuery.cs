using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalBusiness
{
    public class TieupConfirmQuery
    {

        public static string CreateTieupTempTable(string fesTieupTableName)
        {
            string query = string.Format("IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N '{0}') AND type in (N 'U') ) BEGIN drop table {0} END; CREATE TABLE {0}( [バージョンNO] [nvarchar] (50) NULL, [選曲番号] [int] NULL, [カラオケ選曲番号] [int] NULL, [楽曲名] [nvarchar](384) NULL, [歌手ID] [int] NULL, [歌手名] [nvarchar](255) NULL, [ジャンル区分] [nvarchar](50) NULL, [ジャンル名] [nvarchar](50) NULL, [タイアップID] [int] NULL, [タイアップ区分] [int] NULL, [タイアップ区分名] [nvarchar](50) NULL, [タイアップ表示用] [nvarchar](255) NULL, [タイアップ検索用カナ] [nvarchar](255) NULL, [タイアップソート用カナ] [nvarchar](255) NULL, [サービス発表日] [nchar](8) NULL, [UpdateDate] [datetime] NULL, CONSTRAINT [PK_Fesサービス] PRIMARY KEY CLUSTERED ( [バージョンNO] ASC ) WITH ( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY] ) ON [PRIMARY]", fesTieupTableName);
            return query;
        }

        public static string UpdateTieupTempTable(string fesTieupTableName)
        {
            string query = string.Format("", fesTieupTableName);
            return query;
        }

        public static string GetFesGenreQuery()
        {
            string query = string.Format("SELECT t1.バージョンNO, t1.選曲番号, t2.カラオケ選曲番号, t2.楽曲名, t2.歌手ID, t3.歌手名, t1.ジャンル区分, t4.ジャンル名, t1.タイアップID, t5.タイアップ区分, t6.ジャンル名 AS タイアップ区分名, t5.タイアップ表示用, t5.タイアップ検索用カナ, t5.タイアップソート用カナ, CONVERT(DATETIME, t7.サービス発表日) as サービス発表日, CONVERT(DATETIME, NULL) as UpdateDate FROM WiiTmp.dbo.tbl_Fesジャンル t1 INNER JOIN WiiTmp.dbo.tbl_Fesコンテンツ_演奏時間追加 t2 ON t1.選曲番号 = t2.選曲番号 INNER JOIN WiiTmp.dbo.tbl_Fes歌手 t3 ON t2.歌手ID = t3.歌手ID INNER JOIN WiiTmp.dbo.tbl_Fesジャンルリスト t4 ON t1.ジャンル区分 = t4.ジャンル区分 AND t1.バージョンNO = t4.バージョンNO LEFT OUTER JOIN WiiTmp.dbo.tbl_Fesサービス_最新追加フラグ追加 t7 ON t2.選曲番号 = t7.選曲番号 LEFT OUTER JOIN WiiTmp.dbo.tbl_Fesタイアップ情報 t5 ON t1.タイアップID = t5.タイアップID AND t1.バージョンNO = t5.バージョンNO LEFT OUTER JOIN WiiTmp.dbo.tbl_Fesジャンルリスト t6 ON t5.タイアップ区分 = t6.ジャンル区分 AND t1.バージョンNO = t6.バージョンNO WHERE(t1.バージョンNO = 2) ORDER BY t1.バージョンNO, t7.サービス発表日 DESC, t1.選曲番号, t1.ジャンル区分, t1.タイアップID");
            return query;
        }
    }
}
