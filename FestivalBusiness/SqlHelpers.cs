using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FestivalBusiness
{
    public class SqlHelpers
    {
        public static int CommandTimeOut { get; set; }
        private static int DefaultTimeOut = 30;

        public static void ExecuteNonQuery(string connectionString, CommandType commandType, string commandText)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandTimeout = CommandTimeOut == 0 ? DefaultTimeOut : CommandTimeOut;
            command.CommandType = commandType;
            command.CommandText = commandText;
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static void ExecuteNonQuery(SqlConnection sqlConnection, CommandType commandType, string commandText)
        {
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandTimeout = CommandTimeOut == 0 ? DefaultTimeOut : CommandTimeOut;
            command.CommandType = commandType;
            command.CommandText = commandText;
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static void ExecuteNonQuery(SqlTransaction sqlTransaction, CommandType commandType, string commandText)
        {
            SqlCommand command = new SqlCommand();
            command.Transaction = sqlTransaction;
            command.Connection = sqlTransaction.Connection;
            command.CommandTimeout = CommandTimeOut == 0 ? DefaultTimeOut : CommandTimeOut;
            command.CommandType = commandType;
            command.CommandText = commandText;
            command.ExecuteNonQuery();
        }

        public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText)
        {
            DataSet dataSet = new DataSet();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandTimeout = CommandTimeOut == 0 ? DefaultTimeOut : CommandTimeOut;
            command.CommandType = commandType;
            command.CommandText = commandText;
            dataSet = ExecuteDataSet(command);
            sqlConnection.Close();
            return dataSet;
        }

        public static DataSet ExecuteDataset(SqlConnection sqlConnection, CommandType commandType, string commandText)
        {
            DataSet dataSet = new DataSet();
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandTimeout = CommandTimeOut == 0 ? DefaultTimeOut : CommandTimeOut;
            command.CommandType = commandType;
            command.CommandText = commandText;
            dataSet = ExecuteDataSet(command);
            sqlConnection.Close();
            return dataSet;
        }

        public static DataSet ExecuteDataset(SqlTransaction sqlTransaction, CommandType commandType, string commandText)
        {
            DataSet dataSet = new DataSet();
            SqlCommand command = new SqlCommand();
            command.Connection = sqlTransaction.Connection;
            command.CommandTimeout = CommandTimeOut == 0 ? DefaultTimeOut : CommandTimeOut;
            command.CommandType = commandType;
            command.CommandText = commandText;
            dataSet = ExecuteDataSet(command);
            return dataSet;
        }

        private static DataSet ExecuteDataSet(SqlCommand sqlCommand)
        {
            var ds = new DataSet();
            using (var dataAdapter = new SqlDataAdapter(sqlCommand))
            {
                dataAdapter.Fill(ds);
            }

            return ds;
        }

        public static IEnumerable<T> ExecuteObject<T>(SqlTransaction sqlTransaction, CommandType commandType, string commandText)
        {
            IList<T> items = new List<T>();
            DataSet dataSet = new DataSet();
            SqlCommand command = new SqlCommand();
            command.Connection = sqlTransaction.Connection;
            command.CommandTimeout = CommandTimeOut == 0 ? DefaultTimeOut : CommandTimeOut;
            command.CommandType = commandType;
            command.CommandText = commandText;
            dataSet = ExecuteDataSet(command);

            foreach (var row in dataSet.Tables[0].Rows)
            {
                T item = (T)Activator.CreateInstance(typeof(T), row);
                items.Add(item);
            }

            return items;
        }

        public static IEnumerable<T> ExecuteObject<T>(SqlConnection connection, CommandType commandType, string commandText)
        {
            IList<T> items = new List<T>();
            DataSet dataSet = new DataSet();
            SqlCommand command = new SqlCommand();
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            command.Connection = connection;
            command.CommandTimeout = CommandTimeOut == 0 ? DefaultTimeOut : CommandTimeOut;
            command.CommandType = commandType;
            command.CommandText = commandText;
            dataSet = ExecuteDataSet(command);

            connection.Close();

            foreach (var row in dataSet.Tables[0].Rows)
            {
                T item = (T)Activator.CreateInstance(typeof(T), row);
                items.Add(item);
            }

            return items;
        }

        public static IEnumerable<T> ExecuteObject<T>(string connectionString, CommandType commandType, string commandText)
        {
            IList<T> items = new List<T>();
            DataSet dataSet = new DataSet();
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandTimeout = CommandTimeOut == 0 ? DefaultTimeOut : CommandTimeOut;
                command.CommandType = commandType;
                command.CommandText = commandText;
                dataSet = ExecuteDataSet(command);

                sqlConnection.Close();

                foreach (var row in dataSet.Tables[0].Rows)
                {
                    T item = (T)Activator.CreateInstance(typeof(T), row);
                    items.Add(item);
                }

                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Execute bulk insert into table
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="tableName"></param>
        public static void ExecuteBulkInsert(string connectionString, DataTable dataTable)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // make sure to enable triggers
                    // more on triggers in next post
                    SqlBulkCopy bulkCopy =
                        new SqlBulkCopy
                        (
                        connection,
                        SqlBulkCopyOptions.TableLock |
                        SqlBulkCopyOptions.FireTriggers |
                        SqlBulkCopyOptions.UseInternalTransaction,
                        null
                        );

                    // set the destination table name
                    bulkCopy.BulkCopyTimeout = CommandTimeOut == 0 ? DefaultTimeOut : CommandTimeOut;
                    bulkCopy.DestinationTableName = dataTable.TableName;
                    connection.Open();

                    // write the data in the "dataTable"
                    bulkCopy.WriteToServer(dataTable);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExecuteBulkInsert(SqlConnection sqlConnection, DataTable dataTable)
        {
            try
            {
                using (SqlConnection connection = sqlConnection)
                {
                    // make sure to enable triggers
                    // more on triggers in next post
                    SqlBulkCopy bulkCopy =
                        new SqlBulkCopy
                        (
                        connection,
                        SqlBulkCopyOptions.TableLock |
                        SqlBulkCopyOptions.FireTriggers |
                        SqlBulkCopyOptions.UseInternalTransaction,
                        null
                        );

                    // set the destination table name
                    bulkCopy.BulkCopyTimeout = CommandTimeOut == 0 ? DefaultTimeOut : CommandTimeOut;
                    bulkCopy.DestinationTableName = dataTable.TableName;
                    connection.Open();

                    // write the data in the "dataTable"
                    bulkCopy.WriteToServer(dataTable);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExecuteBulkInsert(SqlTransaction sqlTransaction, DataTable dataTable)
        {
            try
            {
                // make sure to enable triggers
                // more on triggers in next post
                SqlBulkCopy bulkCopy =
                    new SqlBulkCopy
                    (
                    sqlTransaction.Connection,
                    SqlBulkCopyOptions.TableLock,
                    sqlTransaction
                    );

                // set the destination table name
                bulkCopy.BulkCopyTimeout = CommandTimeOut == 0 ? DefaultTimeOut : CommandTimeOut;
                bulkCopy.DestinationTableName = dataTable.TableName;
                // write the data in the "dataTable"
                bulkCopy.WriteToServer(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
