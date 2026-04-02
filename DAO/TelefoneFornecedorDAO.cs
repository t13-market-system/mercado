using MySqlConnector;
using SistemaLogin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogin.DAO
{
    internal class TelefoneFornecedorDAO
    {
        //Create

        public void Adicionar(TelefoneFornecedor telefone_fornecedor)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO telefone_fornecedor (id_telefone_fornecedor) VALUES (@id_telefone_fornecedor)" +
                    "INSERT INTO telefone_fornecedor (telefone_fornecedor) VALUES (@telefone_fornecedor)" +
                    "INSERT INTO telefone_fornecedor (id_fornecedor) VALUES (@id_fornecedor)"; ;
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_telefone_fornecedor", telefone_fornecedor.Id_Telefone_Fornecedor);
                        cmd.Parameters.AddWithValue("@telefone_fornecedor", telefone_fornecedor.Telefone_Fornecedor);
                        cmd.Parameters.AddWithValue("@id_fornecedor", telefone_fornecedor.Id_Fornecedor);
                        cmd.ExecuteNonQuery();
                    }

                }

            }
            catch (MySqlException err)
            {
                if (err.Number == 1062) // Erro de UNIQUE (Duplicidade)
                {
                    throw new Exception("Este fornecedor já está cadastrado no sistema.");
                }


                // Lança uma mensagem mascarada e segura para a interface gráfica
                throw new Exception("Ocorreu um erro interno ao tentar salvar o fornecedor.");

            }

        } // Fim do método adicionar


        // Read
        // este método fará uma consulta no banco de dados e retornará todos os telefones de fornecedor cadastrados
        public DataTable ObterTodos()
        {
            DataTable dt = new DataTable();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT id_telefone_fornecedor AS 'ID_Telefone_Fornecedor', telefone_fornecedor AS 'Telefone_Fornecedor', id_fornecedor AS 'ID_Fornecedor' FROM telefone_fornecedor"; 

 
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        } // Fim do Read

        // UPDATE
        public void Atualizar(TelefoneFornecedor telefone_fornecedor)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE telefone_fornecedor SET id_telefone_fornecedor = @id_telefone_fornecedor WHERE id_telefone_fornecedor = @id_fornecedor" +
                "UPDATE telefone_fornecedor SET telefone_fornecedor = @telefone_fornecedor WHERE telefone_fornecedor = @telefone_fornecedor" +
                "UPDATE id_fornecedor SET id_fornecedor = @id_fornecedor WHERE id_fornecedor = @id_fornecedor";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_telefone_fornecedor", telefone_fornecedor.Id_Telefone_Fornecedor);
                    cmd.Parameters.AddWithValue("@telefone_fornecedor", telefone_fornecedor.Telefone_Fornecedor);
                    cmd.Parameters.AddWithValue("@id_fornecedor", telefone_fornecedor.Id_Fornecedor);

                    cmd.ExecuteNonQuery();
                }
            }
        } // Fim do Update

        //Delete
        public void Excluir(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM telefone_fornecedor WHERE id_telefone_fornecedor = @id_telefone_fornecedor" +
                "DELETE FROM telefone_fornecedor WHERE telefone-fornecedor = @telefone_fornecedor" +
                "DELETE FROM telefone_fornecedor WHERE id_fornecedor = @id_fornecedor";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_telefone_fornecedor", id);
                    cmd.Parameters.AddWithValue("@telefone_fornecedor", id);
                    cmd.Parameters.AddWithValue("@id_fornecedor", id);
                    cmd.ExecuteNonQuery();
                }
            }
        } // Fim do Delete


    }
}

