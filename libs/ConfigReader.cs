using System.Data;
using System.Data.SQLite;


namespace ExportadorInventario
{
    public static class ConfigReader
    {

        public static SQLiteConnection con;
        public static string titulo = "AutomatecSistema | Exportador de inventario";
        public static string sistema = "VR";
        public static string dbhost = "localhost";
        public static string dbuser = "sa";
        public static string dbpwd = "senha";
        public static string dbport = "1433";
        public static bool isNeededTest = true;

        public static void Start()
        {
            con = ConnectionConfig.con;
        }

        public static void SetConfigValue(string key, string value)
        {
            SQLiteCommand cmd = new SQLiteCommand("UPDATE config SET value=@Value WHERE key=@Key", con);
            cmd.Parameters.AddWithValue("@Key", key.ToLower());
            cmd.Parameters.AddWithValue("@Value", value);
            cmd.ExecuteNonQuery();
        }

        public static string GetConfigValue(string key)
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT value FROM config WHERE key=@Key", con);
            cmd.Parameters.AddWithValue("@Key", key);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt.Rows[0]["value"].ToString();
        }
    }
}
