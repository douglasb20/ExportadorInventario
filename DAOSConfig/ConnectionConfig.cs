using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace ExportadorInventario
{
    internal class ConnectionConfig
    {

        public static string caminho = Path.GetDirectoryName(Application.ExecutablePath);
        public static string fileDB = "config.db";
        public static string pathDB = Path.Combine(caminho, fileDB);
        public static string connectionString = $"Data Source={pathDB}";

        public static SQLiteConnection con = new SQLiteConnection();
        public static SQLiteTransaction transaction;
        public static void Connect()
        {
            bool newDB = false;

            if (!File.Exists(pathDB))
            {
                newDB = true;
                SQLiteConnection.CreateFile(pathDB);
            }

            con = new SQLiteConnection(connectionString);
            con.Open();

            if (newDB)
            {

                // Criar tabela
                string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS config (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    key TEXT NOT NULL,
                    value TEXT NOT NULL
                );
                CREATE TABLE log_acoes (
                    id        INTEGER PRIMARY KEY,
                    tipo_acao INTEGER NOT NULL,
                    nome_acao TEXT    NOT NULL,
                    modo      TEXT    NOT NULL,
                    data_acao TEXT    NOT NULL
                );
                ";
                using (var createTableCmd = new SQLiteCommand(createTableQuery, con))
                {
                    createTableCmd.ExecuteNonQuery();
                    Console.WriteLine("Tabela criada ou já existente.");
                }

                string createValues = $@"
                    insert into config(key, value) 
                    values 
                    ('mail_host', 'smtp.gmail.com'),
                    ('mail_port', '587'),
                    ('mail_user', 'automatec.oriontaxsync@gmail.com'),
                    ('mail_pwd', ''),
                    ('mail_from', 'OriontaxSync'),
                    ('mail_suport', 'automatec.suporte.cn@gmail.com'),
                    ('primeiro_acesso', '0')
                    ;
                ";
                using (var createConfigValues = new SQLiteCommand(createValues, con))
                {
                    createConfigValues.ExecuteNonQuery();
                    Console.WriteLine("Configs definidos.");
                }
            }

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
    }
}
