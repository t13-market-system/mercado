

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

    internal class VendaDAO

    {

        public decimal ObterFaturamentoHoje()

        {

            using (var conn = DatabaseConnection.GetConnection())

            {

                conn.Open();

                string query = @"SELECT IFNULL(SUM(pi.quantidade_item * pi.preco_unitario), 0)

                         FROM pedido_item pi

                         INNER JOIN venda v ON v.id_pedido = pi.id_pedido

                         WHERE DATE(v.data_venda) = CURDATE()";

                using (var cmd = new MySqlCommand(query, conn))

                {

                    var result = cmd.ExecuteScalar();

                    return result == null || result == DBNull.Value ? 0 : Convert.ToDecimal(result);

                }

            }

        }







        public DataTable ObterItensVendidosHoje()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT 
                p.nome_produto        AS Produto,
                c.nome_categoria      AS Categoria,
                SUM(pi.quantidade_item)                        AS Quantidade,
                pi.preco_unitario                              AS 'Preço Unitário',
                SUM(pi.quantidade_item * pi.preco_unitario)    AS Total
            FROM pedido_item pi
            INNER JOIN venda v    ON v.id_pedido   = pi.id_pedido
            INNER JOIN produto p  ON p.id_produto  = pi.id_produto
            INNER JOIN categoria c ON c.id_categoria = p.id_categoria
            WHERE DATE(v.data_venda) = CURDATE()
            GROUP BY p.id_produto, p.nome_produto, c.nome_categoria, pi.preco_unitario
            ORDER BY Total DESC";

                using (var cmd = new MySqlCommand(query, conn))
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }














        public int ObterQuantidadeItensHoje()

        {

            using (var conn = DatabaseConnection.GetConnection())

            {

                conn.Open();

                string query = @"SELECT IFNULL(SUM(pi.quantidade_item), 0)

                FROM pedido_item pi

                INNER JOIN venda v ON v.id_pedido = pi.id_pedido

                WHERE DATE(v.data_venda) = CURDATE()";

                using (var cmd = new MySqlCommand(query, conn))

                {

                    var result = cmd.ExecuteScalar();

                    return result == null || result == DBNull.Value ? 0 : Convert.ToInt32(result);

                }

            }

        }

        public string ObterProdutoMaisVendidoHoje()

        {

            using (var conn = DatabaseConnection.GetConnection())

            {

                conn.Open();

                string query = @"SELECT p.nome_produto

                FROM pedido_item pi

                INNER JOIN venda v ON v.id_pedido = pi.id_pedido

                INNER JOIN produto p ON p.id_produto = pi.id_produto

                WHERE DATE(v.data_venda) = CURDATE()

                GROUP BY p.id_produto, p.nome_produto

                ORDER BY SUM(pi.quantidade_item) DESC

                LIMIT 1";

                using (var cmd = new MySqlCommand(query, conn))

                {

                    var result = cmd.ExecuteScalar();

                    return result == null || result == DBNull.Value ? "Nenhum" : result.ToString();

                }

            }

        }

        public string ObterCategoriaMaisVendidaHoje()

        {

            using (var conn = DatabaseConnection.GetConnection())

            {

                conn.Open();

                string query = @"SELECT c.nome_categoria

                FROM pedido_item pi

                INNER JOIN venda v ON v.id_pedido = pi.id_pedido

                INNER JOIN produto p ON p.id_produto = pi.id_produto

                INNER JOIN categoria c ON c.id_categoria = p.id_categoria

                WHERE DATE(v.data_venda) = CURDATE()

                GROUP BY c.id_categoria, c.nome_categoria

                ORDER BY SUM(pi.quantidade_item) DESC

                LIMIT 1";

                using (var cmd = new MySqlCommand(query, conn))

                {

                    var result = cmd.ExecuteScalar();

                    return result == null || result == DBNull.Value ? "Nenhuma" : result.ToString();

                }

            }

        }
        public void FinalizarVenda(List<(int idProduto, int quantidade)> itens, int idFormaPagamento, string cpf)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Cria o pedido com CPF
                        int idPedido;
                        using (var cmd = new MySqlCommand("INSERT INTO pedido (cpf) VALUES (@cpf)", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@cpf", cpf);
                            cmd.ExecuteNonQuery();
                            idPedido = (int)cmd.LastInsertedId;
                        }

                        // 2. Cria a venda
                        using (var cmd = new MySqlCommand(
                            "INSERT INTO venda (id_pedido, data_venda, id_forma_pagamento) VALUES (@idPedido, NOW(), @idFormaPagamento)",
                            conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@idPedido", idPedido);
                            cmd.Parameters.AddWithValue("@idFormaPagamento", idFormaPagamento);
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Insere cada produto com quantidade correta
                        foreach (var (idProduto, quantidade) in itens)
                        {
                            decimal preco;
                            using (var cmd = new MySqlCommand(
                                "SELECT preco_produto FROM produto WHERE id_produto = @id", conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", idProduto);
                                preco = Convert.ToDecimal(cmd.ExecuteScalar());
                            }

                            using (var cmd = new MySqlCommand(
                                "INSERT INTO pedido_item (id_pedido, id_produto, quantidade_item, preco_unitario) VALUES (@idPedido, @idProduto, @quantidade, @preco)",
                                conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@idPedido", idPedido);
                                cmd.Parameters.AddWithValue("@idProduto", idProduto);
                                cmd.Parameters.AddWithValue("@quantidade", quantidade);
                                cmd.Parameters.AddWithValue("@preco", preco);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

    }

}
