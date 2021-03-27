using System;
using System.Data;

namespace FestivalBusiness
{
    public class FesVideoDiscBusiness : BusinessBase
    {
        public DataTable GetFesIndividualVideoDisc()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesVideoDiscQuery.GetFesIndividualVideoDiscQuery()).Tables[0];
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
