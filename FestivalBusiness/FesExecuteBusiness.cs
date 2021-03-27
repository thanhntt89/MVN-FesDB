using System;
using System.Data;

namespace FestivalBusiness
{
    public class FesExecuteBusiness : BusinessBase
    {
        public DataTable GetExecuteAll()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesExecuteQuery.GetExecuteAllQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteById(string executeId)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesExecuteQuery.GetDeleteByIdQuery(executeId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
