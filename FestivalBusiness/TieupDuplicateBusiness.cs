using FestivalCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalBusiness
{
    public class TieupDuplicateBusiness : BusinessBase
    {
        private CommonBusiness commonBusiness = new CommonBusiness();

        public DataTable GetDataTieupTable()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, TieupDuplicateQuery.GetFesGenreQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
