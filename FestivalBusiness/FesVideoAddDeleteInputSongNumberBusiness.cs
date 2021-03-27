using System;
using System.Collections.Generic;
using System.Data;

namespace FestivalBusiness
{
    public class FesVideoAddDeleteInputSongNumberBusiness : BusinessBase
    {
        private FesVideoAddDeleteBusiness fesVideoAddDeleteBusiness = new FesVideoAddDeleteBusiness();
        public void TruncateInputSongNumberTableTmp()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesVideoAddDeleteQuery.GetTruncateInputSongNumberTableTmpQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertSongNumberTableTmp(List<string> songNumberList)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesVideoAddDeleteQuery.GetInsertVideoNumberTableTmpQuery(songNumberList));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TruncateImportVideoDiscManagementWorkTable()
        {
            try
            {
                fesVideoAddDeleteBusiness.TruncateVideoDiscManagementWorkTmp();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ImportVideoDiscManagementWorkTable()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesVideoAddDeleteQuery.GetImportVideoDiscManagementWorkTableQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
