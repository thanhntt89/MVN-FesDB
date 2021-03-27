using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalBusiness
{
   public class FesVideoAssigmentImportBusiness:BusinessBase
    {
        public DataTable GetFesVideoAssigmentByKaraokeNumber(string karaokeNumber)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesVideoAssigmentImportQuery.GetFesVideoAssigmentByKaraokeNumberQuery(karaokeNumber)).Tables[0];
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetFesVideoAssigmentColumns()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesVideoAssigmentImportQuery.GetFesVideoAssigmentColumnsQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertFesVideoAssigment(DataTable dtFesAssigmentDes)
        {
            try
            {
                 SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesVideoAssigmentImportQuery.GetInsertFesVideoAssigmentQuery(dtFesAssigmentDes));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TruncateFesVideoAssigmentWork()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesVideoAssigmentImportQuery.GetTruncateFesVideoAssigmentWorkQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
