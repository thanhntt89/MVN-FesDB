namespace FestivalBusiness
{
    public class FesExecuteQuery
    {
        internal static string GetExecuteAllQuery()
        {
            string query = string.Format("select [ID], [項目], [状態], [担当者], [PC名] from Wii.dbo.tbl_Fesロック where [状態] = 1");
            return query;
        }

        internal static string GetDeleteByIdQuery(string executeId)
        {
            string query = string.Format("UPDATE Wii.dbo.tbl_Fesロック SET  [状態] = 0 where ID = '{0}'", executeId);
            return query;
        }
    }
}
