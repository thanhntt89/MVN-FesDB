using System;
using System.Data;

namespace FestivalBusiness
{
    public class RecommendSongImportBusiness : BusinessBase
    {
        private RecommendSongBusiness recommendSongBusiness = new RecommendSongBusiness();

        public void InsertFesRecommendSongWorkTable(DataTable dtRecommendSongDes)
        {
            try
            {
                try
                {
                    SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, ImportRecommendSongQuery.GetInsertRecommendSongWorkTableQuery(dtRecommendSongDes));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetFeRecommendProgram()
        {
            try
            {
                return recommendSongBusiness.GetFeRecommendProgram();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetFesRecommendSongDes(object programCheckId, string contentId, string displayOrder)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, ImportRecommendSongQuery.GetRecommendSongDesQuery(programCheckId, contentId, displayOrder)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetFesRecommendSongSource(string programCheckId)
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, ImportRecommendSongQuery.GetRecommendSongSourceQuery(programCheckId)).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateFesRecommendSongWorkTable(DataTable dtRecommendSongDes)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, ImportRecommendSongQuery.GetUpdateRecommendSongWorkTableQuery(dtRecommendSongDes));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
