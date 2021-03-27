namespace FestivalBusiness
{
    public class FesDiskCapacityQuery
    {
        internal static string GetDiskCapacityInfoQuery(int diskSize, int unitFile)
        {
            string query = string.Format("SELECT  iv2.FesDISCID as FesDISCID ,CONVERT(char, iv2.合計) as 合計 ,CONVERT(char,{0} - iv2.合計) as 残り FROM  (SELECT CONVERT(int, iv1.FesDISCID) as FesDISCID,CONVERT(decimal(10,2), ROUND((CONVERT(float,sum(CONVERT(bigint,iv1.データサイズ))) / {1} ) + 0.009, 2)) as 合計 FROM (SELECT FesDISCID ,データサイズ  FROM Wii.dbo.[FesDISC追加削除管理] WHERE 追加削除区分 = 0 AND 削除フラグ = 0 UNION ALL SELECT FesDISCID ,データサイズ FROM  Wii.dbo.[Fes映像DISC追加削除管理] WHERE 追加削除区分 = 0 AND 削除フラグ = 0) as iv1  GROUP BY CONVERT(int,iv1.FesDISCID)) as iv2", diskSize, unitFile);
            return query;
        }
    }
}
