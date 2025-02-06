using Microsoft.Data.SqlClient;
using System;

namespace ExportadorInventario
{
    internal class ConnectionVR
    {
        public static SqlConnection con = new SqlConnection();
        public static SqlTransaction transaction;
        public static void Connect()
        {
            string host = ConfigReader.dbhost;
            string dbuser = ConfigReader.dbuser;
            string password = ConfigReader.dbpwd;
            string port = ConfigReader.dbport;

            if (port == string.Empty)
            {
                con = new SqlConnection(string.Format(@"Data Source={0};Initial Catalog=Etrade; User ID={1};Password={2};TrustServerCertificate=True;", host, dbuser, password));
            }
            else
            {
                con = new SqlConnection(string.Format(@"Data Source={0},{1};Initial Catalog=Etrade; User ID={2};Password={3};TrustServerCertificate=True;", host, port, dbuser, password));
            }
            con.Open();
        }
        public static void ReConnect()
        {
            Close();
            Connect();
        }
        public static void BeginTransaction() { transaction = con.BeginTransaction(); }
        public static void Commit() { transaction.Commit(); }
        public static void Rollback() { transaction.Rollback(); }
        public static void Close() { con.Close(); con.Dispose(); }
        public static void TesteConn(string host, string port, string user, string pwd)
        {
            try
            {
                SqlConnection conTest = new SqlConnection();

                if(port == string.Empty)
                {
                    conTest = new SqlConnection(string.Format(@"Data Source={0};Initial Catalog=Etrade; User ID={1};Password={2};TrustServerCertificate=True;", host, user, pwd));
                }else
                {
                    conTest = new SqlConnection(string.Format(@"Data Source={0},{1};Initial Catalog=Etrade; User ID={2};Password={3};TrustServerCertificate=True;", host, port, user, pwd));
                }
                conTest.Open();
                conTest.Close();

            }
            catch (SqlException ex)
            {
                throw ex;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
