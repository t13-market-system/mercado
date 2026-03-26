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
    internal class FornecedorDAO
    {
        public void Adicionar(Fornecedor fornecedor)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO fornecedo (nome_fornecedor) VALUES (@nome_fornecedor)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome_fornecedor", fornecedor.Nome_Fornecedor);
                        cmd.ExecuteNonQuery();
                    }



                }

            }
            catch (MySqlException err)
            {
                if (err.Number == 1062) // Erro de UNIQUE (Duplicidade)
                {
                    throw new Exception("Este fornecedor já está cadastrada no sistema.");
                }


                // Lança uma mensagem mascarada e segura para a interface gráfica
                throw new Exception("Ocorreu um erro interno ao tentar salvar a fornecedor.");

            }




        }
        public DataTable Listfornecedor()
        {
            DataTable dt = new DataTable();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT id_fornecedor AS 'ID', nome_fornecedor AS 'fornecedor' FROM fornecedor";
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
        public void AtualizarFornecedores(Fornecedor fornecedor)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE fornecedor SET nome_fornecedor = @nome WHERE id_fornecedor = @id_fornecedor";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome_fornecedor", fornecedor.Nome_Fornecedor);
                    cmd.Parameters.AddWithValue("@id", fornecedor.Id_Fornecedor);
                    cmd.ExecuteNonQuery();
                }
            }
        } // Fim do Update

        //Delete
        public void ExcluirFornecedor(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM fornecedor WHERE id_fornecedor = @id_fornecedor";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        } // Fim do Delete
    }


   
    

}

    

    





















