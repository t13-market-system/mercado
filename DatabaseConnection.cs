using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogin
{
    internal class DatabaseConnection
    {
        // String de conexão
        private static readonly string connectionString =
            "Server=localhost;" +
            "Database=sistema_login;" +
            "Uid=root;" +
            "Pwd=;" +
            "Port=3306;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
