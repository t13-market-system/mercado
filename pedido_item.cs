using MySqlConnector;
using SistemaLogin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogin
{
    internal class pedido_item
    {

        public void Adicionar(Pedido_item  item  )
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO pedido_item (id_pedido, Id_produto, quantidade_item, preco_unitario  )" +
                                   "  VALUES (@idPedido, @idProduto, @quantidadeItem, preco_unitario )";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idPedido", item.Id_pedido);
                        cmd.Parameters.AddWithValue("@idProduto", item.Id_produto);
                        cmd.Parameters.AddWithValue("@quantidadeItem", item.Qtd_item);
                        cmd.Parameters.AddWithValue("preco_unitario", item.Preco_uni);
                    }

                }

            }
            catch (MySqlException err)
            {
                if (err.Number == 1062) // Erro de UNIQUE (Duplicidade)
                {
                    throw new Exception("Esta categoria já está cadastrada no sistema.");
                }


                // Lança uma mensagem mascarada e segura para a interface gráfica
                throw new Exception("Ocorreu um erro interno ao tentar salvar a categoria.");

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
                string query = "SELECT id_item AS 'ID', id_pedido AS 'id_produto' AS 'quantidade_item' AS 'preco_unitario' FROM Pedido_item";
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
        public void Atualizar(Pedido_item item)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Pedido_Item SET Pedido_Item = @idPedido WHERE id_categoria = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idPedido", item.Id_pedido);
                    cmd.Parameters.AddWithValue("@idProduto", item.Id_produto);
                    cmd.Parameters.AddWithValue("@quantidadeItem", item.Qtd_item);
                    cmd.Parameters.AddWithValue("preco_unitario", item.Preco_uni);
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
                string query = "DELETE FROM categoria WHERE id_categoria = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        } // Fim do Delete


    }
}

    

