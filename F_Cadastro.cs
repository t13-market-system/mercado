using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaLogin
{
    public partial class F_Cadastro : Form
    {
        public F_Cadastro()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = tb_usuario.Text.Trim();
            string password = tb_senha.Text;
            string email = tb_email.Text.Trim();

            // 1. Validação básica
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Preencha todos os campos para cadastrar!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          
            string hashSeguro = PasswordHasher.HashPassword(password);

            // 3. Salvar no Banco de Dados
            using (var conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();

                  
                    string sql = "INSERT INTO usuarios (username, password_hash, email) VALUES (@username, @password_hash, @email)";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        // Parâmetros para evitar SQL Injection 
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password_hash", hashSeguro);
                        cmd.Parameters.AddWithValue("@email", email);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Usuário cadastrado com sucesso! Agora você pode fazer login.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpa os campos após o cadastro
                        tb_usuario.Clear();
                        tb_senha.Clear();
                    }
                }
                catch (MySqlException ex)
                {
                   // O código 1062 no MySQL/MariaDB significa que tentou inserir um valor UNIQUE que já existe
                    if (ex.Number == 1062)
                    {
                        MessageBox.Show("Este usuário já existe. Tente outro nome.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar no banco: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }



        }
    }
}
