using Npgsql;
using System;

namespace ExportadorInventario
{
    static class ConnectionPG
    {
        public static NpgsqlConnection con;
        private static NpgsqlTransaction transaction;
        public static void Connect()
        {
            string dbBase = ConfigReader.sistema == "LeCheff" ? "RP" : "SOFTMOBILE";
            string host = ConfigReader.dbhost;
            string dbuser = ConfigReader.dbuser;
            string port = ConfigReader.dbport;
            string password = ConfigReader.dbpwd;

            con = new NpgsqlConnection(string.Format(@"Server={0};Port={1};User Id={2};Password={3};Database={4};", host, port, dbuser, password, dbBase));
            con.Open();

        }

        public static void ReConnect()
        {
            con.Close();
            Connect();
        }

        public static void BeginTransaction() { transaction = con.BeginTransaction(); }
        public static void Commit() { transaction.Commit(); }

        public static void Rollback() { transaction.Rollback(); }

        public static void Close() { con.Close(); con.Dispose(); }

        public static void TesteConn(string host, string porta, string user, string pwd)
        {
            try
            {
                string dbBase = ConfigReader.sistema == "LeCheff" ? "RP" : "SOFTMOBILE";
                NpgsqlConnection conTest;
                conTest = new NpgsqlConnection(string.Format(@"Server={0};Port={1};User Id={2};Password={3};Database={4};", host, porta, user, pwd, dbBase));
                conTest.Open();
                conTest.Close();

            }
            catch (NpgsqlException ex)
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
