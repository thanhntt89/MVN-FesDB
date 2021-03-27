using System;
using System.Data;

namespace FestivalBusiness
{
    public class FesDiskCapacityBusiness : BusinessBase
    {
        public DataTable GetDiskCapacityInfoAll(int diskSize, int unitFile)
        {
            try
            {
                DataTable dt = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesDiskCapacityQuery.GetDiskCapacityInfoQuery(diskSize, unitFile)).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
