/*
 * Create by Nguyen Tat Thanh
 * Created date: Mar-20
 * Email: thanhntt89bk@gmail.com
 */

using System.Configuration;
using System.Data.SqlClient;

namespace FestivalBusiness
{
    public class GetConnection
    {
        public static string WiiConnectionString { get; set; }
        public static string WiiTmpConnectionString { get; set; }

        public static string ConnectionShortTimeOutString { get; set; }
        public static string DataBaseName { get; set; }
        public static string TmpDataBaseName { get; set; }
        /// <summary>
        /// Get sqlcommand timeout
        /// </summary>
        public static int SqlCommandTimeOut { get; set; }

        /// <summary>
        /// Check Sql Connection String
        /// </summary>
        /// <returns></returns>
        public static bool CheckConnectionString(string sqlConnectionString)
        {
            try
            {
                SettingConnectionApplication(sqlConnectionString);
                SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);
                sqlConnection.Open();
                sqlConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check Sql Connection String
        /// </summary>
        /// <param name="serverName">serverName</param>
        /// <param name="userName">userName</param>
        /// <param name="passwords">passwords</param>
        /// <param name="databaseName">databaseName</param>
        /// <param name="timeOut">timeOut</param>
        /// <returns></returns>
        public static bool CheckConnectionString(string serverName, string userName, string passwords, string databaseName, int timeOut, int commandTimeOut)
        {
           WiiConnectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};Connect Timeout={4};", serverName, databaseName, userName, passwords, timeOut);

            ConnectionShortTimeOutString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};Connect Timeout={4};", serverName, databaseName, userName, passwords, 20);

            SqlCommandTimeOut = commandTimeOut;
            DataBaseName = databaseName;
            try
            {                
                SqlConnection sqlConnection = new SqlConnection(ConnectionShortTimeOutString);
                sqlConnection.Open();
                sqlConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool CheckConnectionStringTmp(string serverName, string userName, string passwords, string databaseName, int timeOut, int commandTimeOut)
        {
            WiiTmpConnectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};Connect Timeout={4};", serverName, databaseName, userName, passwords, timeOut);

            TmpDataBaseName = databaseName;
            try
            {             
                SqlConnection sqlConnection = new SqlConnection(WiiTmpConnectionString);
                sqlConnection.Open();
                sqlConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Setting sql connection
        /// </summary>
        public static void SettingConnectionApplication(string sqlConnectString)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Properties.Settings.Default["WiiConnectionString"] = sqlConnectString;
            config.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("WiiConnectionString");
        }

        public static void SettingConnectionApplicationTmp(string sqlConnectString)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Properties.Settings.Default["WiiTmpConnectionString"] = sqlConnectString;
            config.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("WiiTmpConnectionString");
        }

        /// <summary>
        /// Get connection
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(GetWiiSqlConnectionString());
        }

        /// <summary>
        /// Get sql connection string
        /// </summary>
        /// <returns></returns>
        public static string GetWiiSqlConnectionString()
        {
            return WiiConnectionString;
        }

        public static string GetWiiTmpSqlConnectionString()
        {
            return WiiTmpConnectionString;
        }
    }
}
