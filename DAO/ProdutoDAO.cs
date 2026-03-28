using MySqlConnector;
using SistemaLogin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaLogin.DAO
{
    internal class ProdutoDAO
    {

        public int AdicionarProduto(Produto produto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(produto.Nome_produto))
                    throw new Exception("Nome do produto é obrigatório.");

                if (produto.Preco_produto <= 0)
                    throw new Exception("Preço deve ser maior que zero.");

                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
            INSERT INTO produto 
            (nome_produto, id_categoria, id_fornecedor, preco_produto, codigo_produto) 
            VALUES 
            (@nomeProduto, @categoria, @fornecedor, @preco, @codigo)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nomeProduto", produto.Nome_produto);
                        cmd.Parameters.AddWithValue("@categoria", produto.Id_categoria);
                        cmd.Parameters.AddWithValue("@fornecedor", produto.Id_fornecedor);
                        cmd.Parameters.AddWithValue("@preco", produto.Preco_produto);
                        cmd.Parameters.AddWithValue("@codigo", produto.Codigo_produto);

                        cmd.ExecuteNonQuery();
                        return (int)cmd.LastInsertedId;


                    }
                }
            }
            catch (MySqlException err)
            {
                if (err.Number == 1062)
                    throw new Exception("Esse produto já está cadastrado no sistema.");

                throw new Exception($"Erro ao salvar produto: {err.Message}");
            }
        }


        // Read
        // este método fará uma consulta no bando de dados e retornará todas as categorias cadastradas
        public DataTable ObterTodas()
        {
            DataTable dt = new DataTable();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT id_produto AS 'ID', nome_produto AS 'produto' FROM produto";
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

        //delete
        public void Excluir(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // 1. Apaga itens relacionados
                string query1 = "DELETE FROM pedido_item WHERE id_produto = @id";

                using (var cmd1 = new MySqlCommand(query1, conn))
                {
                    cmd1.Parameters.AddWithValue("@id", id);
                    cmd1.ExecuteNonQuery();
                }

                // 2. Agora sim apaga o produto
                string query2 = "DELETE FROM produto WHERE Id_produto = @id";

                using (var cmd2 = new MySqlCommand(query2, conn))
                {
                    cmd2.Parameters.AddWithValue("@id", id);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("O Produto Foi Apagado");
                }
            }
        }





        public DataTable ListarProdutos()
        {
         
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                string query = "SELECT * FROM produto";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

    }


}

