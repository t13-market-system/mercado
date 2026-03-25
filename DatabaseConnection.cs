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
<<<<<<< Tela-Cadastro-Fornecedor--Thiago

        private static readonly string connectionString =
            "Server=10.141.45.42;" +
=======
        private static readonly string connectionString =
            //"Server=10.141.45.42;" +
            "Server=localhost;" +
>>>>>>> main
            "Database=sistema_login;" +
            "Uid=mercado;" +
            "Pwd=senac;" +
            "Port=3306;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
