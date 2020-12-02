using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Assessment1_ADO.NET
{
    public class SQLAbstactDAO : IAbstactDAO
    {
        public string connectionString;

        public SQLAbstactDAO()
        {
            connectionString = ConfigurationManager.ConnectionStrings["flightConnection"].ConnectionString;
        }
        public IDbConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public void ReleaseConnection(IDbConnection connection)
        {
            connection.Close();
        }
    }
}
