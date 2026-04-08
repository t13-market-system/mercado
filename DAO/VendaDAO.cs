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

            // 🔥 FINALIZAR VENDA (COM ITENS)
            public void FinalizarVenda(List<int> idsProdutos)
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var transaction = conn.BeginTransaction();

                    try
                    {
                        int idVenda;

                        // 1. Criar venda
                        using (var cmdVenda = new MySqlCommand(
                            "INSERT INTO venda (data_venda) VALUES (NOW()); SELECT LAST_INSERT_ID();",
                            conn, transaction))
                        {
                            idVenda = Convert.ToInt32(cmdVenda.ExecuteScalar());
                        }

                        // 2. Inserir itens
                        foreach (int idProduto in idsProdutos)
                        {
                            using (var cmdItem = new MySqlCommand(
                                @"INSERT INTO itens_venda (id_venda, id_produto, preco)
                          SELECT @idVenda, id_produto, preco_produto
                          FROM produto
                          WHERE id_produto = @idProduto",
                                conn, transaction))
                            {
                                cmdItem.Parameters.AddWithValue("@idVenda", idVenda);
                                cmdItem.Parameters.AddWithValue("@idProduto", idProduto);
                                cmdItem.ExecuteNonQuery();
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

            // 💰 FATURAMENTO
            public decimal ObterFaturamentoHoje()
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
            SELECT IFNULL(SUM(iv.preco), 0)
            FROM itens_venda iv
            INNER JOIN venda v ON v.id_venda = iv.id_venda
            WHERE DATE(v.data_venda) = CURDATE()";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        return Convert.ToDecimal(cmd.ExecuteScalar());
                    }
                }
            }

            // 📦 QUANTIDADE
            public int ObterQuantidadeItensHoje()
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
            SELECT COUNT(*)
            FROM itens_venda iv
            INNER JOIN venda v ON v.id_venda = iv.id_venda
            WHERE DATE(v.data_venda) = CURDATE()";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }

            // 🏆 PRODUTO MAIS VENDIDO
            public string ObterProdutoMaisVendidoHoje()
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
            SELECT p.nome_produto
            FROM itens_venda iv
            INNER JOIN produto p ON p.id_produto = iv.id_produto
            INNER JOIN venda v ON v.id_venda = iv.id_venda
            WHERE DATE(v.data_venda) = CURDATE()
            GROUP BY p.nome_produto
            ORDER BY COUNT(*) DESC
            LIMIT 1";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        var result = cmd.ExecuteScalar();
                        return result?.ToString() ?? "Nenhum";
                    }
                }
            }

            // 📊 CATEGORIA MAIS VENDIDA
            public string ObterCategoriaMaisVendidaHoje()
            {
                conn.Open();
                string query = "DELETE FROM venda WHERE Id_venda = @idvenda";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idvenda", id);
                    cmd.ExecuteNonQuery();
                }
            }
        } // Fim do Delete

        public decimal ObterFaturamentoHoje(Venda venda)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT COALESCE(SUM(pi.quantidade_item * pi.preco_unitario), 0) " +
                               "FROM venda v " +
                               "INNER JOIN pedido_item pi ON v.id_pedido = pi.id_pedido " +
                               "WHERE DATE(v.data_venda) = CURDATE()";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
        }
        public int ObterQuantidadeItensHoje()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT COALESCE(SUM(pi.quantidade_item), 0) " +
                               "FROM venda v " +
                               "INNER JOIN pedido_item pi ON v.id_pedido = pi.id_pedido " +
                               "WHERE DATE(v.data_venda) = CURDATE()";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public string ObterProdutosMaisVendidosHoje()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT p.nome_produto " +
                               "FROM venda v " +
                               "INNER JOIN pedido_item pi ON v.id_pedido = pi.id_pedido " +
                               "INNER JOIN produto p ON pi.id_produto = p.id_produto " +
                               "WHERE DATE(v.data_venda) = CURDATE() " +
                               "GROUP BY p.id_produto, p.nome_produto " +
                               "ORDER BY SUM(pi.quantidade_item) DESC " +
                               "LIMIT 3";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        var produtos = new List<string>();
                        int posicao = 1;

                        while (reader.Read())
                        {
                            produtos.Add($"{posicao}º {reader.GetString("nome_produto")}");
                            posicao++;
                        }

                        return produtos.Count > 0
                            ? string.Join("\n", produtos)
                            : "Nenhum produto vendido hoje";
                    }
                }
            }
        }
        public string ObterCategoriasMaisVendidasHoje()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT c.nome_categoria " +
                               "FROM venda v " +
                               "INNER JOIN pedido_item pi ON v.id_pedido = pi.id_pedido " +
                               "INNER JOIN produto p ON pi.id_produto = p.id_produto " +
                               "INNER JOIN categoria c ON p.id_categoria = c.id_categoria " +
                               "WHERE DATE(v.data_venda) = CURDATE() " +
                               "GROUP BY c.id_categoria, c.nome_categoria " +
                               "ORDER BY SUM(pi.quantidade_item) DESC " +
                               "LIMIT 3";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        var categorias = new List<string>();
                        int posicao = 1;

                        while (reader.Read())
                        {
                            categorias.Add($"{posicao}º {reader.GetString("nome_categoria")}");
                            posicao++;
                        }

                        return categorias.Count > 0
                            ? string.Join("\n", categorias)
                            : "Nenhuma categoria vendida hoje";
                    }
                }
            }
        }
        public void FinalizarVenda(List<int> idsProdutos)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Cria o pedido
                        int idPedido;
                        using (var cmd = new MySqlCommand("INSERT INTO pedido (cpf) VALUES (0)", conn, transaction))
                        {
                            cmd.ExecuteNonQuery();
                            idPedido = (int)cmd.LastInsertedId;
                        }

                        // 2. Cria a venda
                        using (var cmd = new MySqlCommand(
                            "INSERT INTO venda (id_pedido, data_venda, id_forma_pagamento) VALUES (@idPedido, NOW(), 1)",
                            conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@idPedido", idPedido);
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Insere cada produto
                        foreach (int idProduto in idsProdutos)
                        {
                            decimal preco;
                            using (var cmd = new MySqlCommand(
                                "SELECT preco_produto FROM produto WHERE id_produto = @id", conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", idProduto);
                                preco = Convert.ToDecimal(cmd.ExecuteScalar());
                            }

                            using (var cmd = new MySqlCommand(
                                "INSERT INTO pedido_item (id_pedido, id_produto, quantidade_item, preco_unitario) VALUES (@idPedido, @idProduto, 1, @preco)",
                                conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@idPedido", idPedido);
                                cmd.Parameters.AddWithValue("@idProduto", idProduto);
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
