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
    internal class Pedido_itemDAO
    {
        public void Adicionar(Pedido_item pedido_item)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO pedido_item(id_pedido, id_produto, quantidade_item, preco_unitario) VALUES (@id_ped, @id_prod, @qtd_item, @preco )";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_ped", pedido_item.Id_pedido);
                        cmd.Parameters.AddWithValue("@id_prod", pedido_item.Id_produto);
                        cmd.Parameters.AddWithValue("@qtd_item", pedido_item.Qtd_item);
                        cmd.Parameters.AddWithValue("@preco", pedido_item.Preco_uni);
                        cmd.ExecuteNonQuery();
                    }


                }

            }
            catch (MySqlException err)
            {
                if (err.Number == 1062)
                {
                    throw new Exception("Este pedido já está cadastrado no sistema.");
                }


                throw new Exception("Ocorreu um erro interno ao tentar salvar o pedido.");

            }

        }


        public DataTable ObterTodas()
        {
            DataTable dt = new DataTable();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT pedido_item.id_item AS 'ID', pedido_item.id_pedido AS 'Pedido',produto.nome_produto AS 'Nome do produto'," +
                    "pedido_item.quantidade_item AS 'Quantidade',pedido_item.preco_unitario AS 'Preço' " +
                    "FROM pedido_item " +
                    "inner join produto on pedido_item.id_produto = produto.id_produto";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }


        public void Atualizar(Pedido_item pedido_item)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE pedido_item SET id_produto(@id_prod), id_pedido(@id_ped), quantidade_item(@qtd_item), preco_unitario(@preco) WHERE id_item = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_prod", pedido_item.Id_produto);
                    cmd.Parameters.AddWithValue("@id_ped", pedido_item.Id_pedido);
                    cmd.Parameters.AddWithValue("@qtd_item", pedido_item.Qtd_item);
                    cmd.Parameters.AddWithValue("@preco", pedido_item.Preco_uni);
                    cmd.Parameters.AddWithValue("@id", pedido_item.Id_item);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Excluir(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM pedido WHERE id_pedido = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
