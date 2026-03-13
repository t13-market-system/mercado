using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogin
{
    internal class AuthService
    {
        public bool AuthenticateUser(string username, string password)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    // Busca apenas o hash da senha, prevenindo SQL Injection com parâmetros
                    string sql = "SELECT password_hash FROM usuarios WHERE username = @username";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        var result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string storedHash = result.ToString();
                            // Usa o BCrypt para verificar se a senha digitada bate com o hash do banco
                            return PasswordHasher.VerifyPassword(password, storedHash);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
            return false;
        }
    }
}
