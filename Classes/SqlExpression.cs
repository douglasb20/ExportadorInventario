
namespace ExportadorInventario
{
    public class SqlExpression
    {
        private string sql;
        public SqlExpression(string sql) { 
            this.sql = sql;
        }

        public string GetSql() { return sql; }
    }
}
