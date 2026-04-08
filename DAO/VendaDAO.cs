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
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
            SELECT c.nome_categoria
            FROM itens_venda iv
            INNER JOIN produto p ON p.id_produto = iv.id_produto
            INNER JOIN categoria c ON c.id_categoria = p.id_categoria
            INNER JOIN venda v ON v.id_venda = iv.id_venda
            WHERE DATE(v.data_venda) = CURDATE()
            GROUP BY c.nome_categoria
            ORDER BY COUNT(*) DESC
            LIMIT 1";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        var result = cmd.ExecuteScalar();
                        return result?.ToString() ?? "Nenhuma";
                    }
                }
            }
        }
    }
