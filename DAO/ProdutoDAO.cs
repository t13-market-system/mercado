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
    internal class ProdutoDAO
    {

        public void AdicionarProduto(Produto produto)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO produto (nome_produto, id_categoria, id_fornecedor, preco_produto, codigo_produto) VALUES (@nomeProduto, @categoria, @fornecedor, " +
                        " @preco, @codigo)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nomeProduto", produto.Nome_produto);
                        cmd.Parameters.AddWithValue("@categoria", produto.Id_categoria);
                        cmd.Parameters.AddWithValue("@fornecedor", produto.Id_fornecedor);
                        cmd.Parameters.AddWithValue("@preco", produto.Preco_produto);
                        cmd.Parameters.AddWithValue("@codigo", produto.Codigo_produto);

                        cmd.ExecuteNonQuery();
                    }



                }

            }
            catch (MySqlException err)
            {
                if (err.Number == 1062) // Erro de UNIQUE (Duplicidade)
                {
                    throw new Exception("Esse Produto já está cadastrada no sistema.");
                }


                // Lança uma mensagem mascarada e segura para a interface gráfica
                throw new Exception("Ocorreu um erro interno ao tentar salvar o Produto.");

            }

        } // Fim do método adicionar


        // Read
        // este método fará uma consulta no bando de dados e retornará todas as categorias cadastradas
        public DataTable ObterTodas()
        {
            DataTable dt = new DataTable();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM produto";
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
        public void Atualizar(Produto produto)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE produto SET nome_produto = @nomeProduto, id_categoria = @categoria, id_fornecedor = @fornecedor, preco_produto = @preco, codigo_produto = @codigo " +
               "WHERE id_produto = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nomeProduto", produto.Nome_produto);
                    cmd.Parameters.AddWithValue("@categoria", produto.Id_categoria);
                    cmd.Parameters.AddWithValue("@fornecedor", produto.Id_fornecedor);
                    cmd.Parameters.AddWithValue("@preco", produto.Preco_produto);
                    cmd.Parameters.AddWithValue("@codigo", produto.Codigo_produto);
                    cmd.Parameters.AddWithValue("@id", produto.Id_produto);
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
                string query = "DELETE FROM produto WHERE Id_produto  = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        } // Fim do Delete


    }


}

