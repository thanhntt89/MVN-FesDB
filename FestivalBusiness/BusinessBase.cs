using FestivalCommon;
using FestivalUtilities;
using System;
using System.Data.SqlClient;
using static FestivalUtilities.LogWriter;

namespace FestivalBusiness
{
    public class BusinessBase
    {
        public string connectionString = null;
        public string tempConnectionString = null;
        public string connectionStringShortTimeOut = null;
        public SqlTransaction sqlTransac = null;
        public SqlConnection connection = null;

        public BusinessBase()
        {
            SqlHelpers.CommandTimeOut = GetConnection.SqlCommandTimeOut;
            connection = GetConnection.GetSqlConnection();
            connectionString = GetConnection.GetWiiSqlConnectionString();
            connectionStringShortTimeOut = GetConnection.ConnectionShortTimeOutString;
            tempConnectionString = GetConnection.GetWiiTmpSqlConnectionString();
        }

        public void LogException(Exception ex, string methodName)
        {
            ErrorEntity error = new ErrorEntity()
            {
                LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                ErrorMessage = ex.Message,
                ModuleName = this.GetClassName() + " " + methodName,
                FilePath = Constants.LOG_FILE_PATH_ERROR
            };

            try
            {
                LogWriter.Write(error);
            }
            catch
            {

            }
        }

        public string GetClassName()
        {
            return this.GetType().Name;
        }
    }
}
