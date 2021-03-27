using FestivalCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalBusiness
{
    public class TieupConfirmBusiness : BusinessBase
    {
        private CommonBusiness commonBusiness = new CommonBusiness();

        public void SaveTieupContentTmp(DataTable updateDataWorkFesContentTable)
        {
            if (updateDataWorkFesContentTable == null || updateDataWorkFesContentTable.Rows.Count == 0)
                return;
            updateDataWorkFesContentTable.TableName = Constants.FES_TIEUP_TABLE_DBTMP;

            // Save fescontent work
            commonBusiness.Save(TieupConfirmQuery.CreateTieupTempTable(Constants.FES_TIEUP_TABLE_DBTMP), TieupConfirmQuery.UpdateTieupTempTable(Constants.FES_TIEUP_TABLE_DBTMP), updateDataWorkFesContentTable);
        }


        public DataTable GetDataTieupTable()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, TieupConfirmQuery.GetFesGenreQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
