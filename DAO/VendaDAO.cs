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
        //Create

        public void Adicionar(Venda venda)
        {
            int teste1 = 0;
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO venda (id_pedido, data_venda, id_forma_pagamento) VALUES (@id_pedido, @data_venda, @id_forma_pagamento)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_venda", venda.Id_venda);
                        cmd.Parameters.AddWithValue("@id_pedido", venda.Id_pedido);
                        cmd.Parameters.AddWithValue("@data_venda", venda.Data_venda);
                        cmd.Parameters.AddWithValue("@id_forma_pagamento", venda.Id_forma_pagamento);
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (MySqlException err)
            {
                if (err.Number == 1062) // Erro de UNIQUE (Duplicidade)
                {
                    throw new Exception("Esta venda já está cadastrada no sistema.");
                }


                // Lança uma mensagem mascarada e segura para a interface gráfica
                throw new Exception("Ocorreu um erro interno ao tentar salvar a venda.");

            }

        } // Fim do método adicionar


        // Read
        // este método fará uma consulta no banco de dados e retornará todas as vendas cadastradas
        public DataTable ObterTodas()
        {
            DataTable dt = new DataTable();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT id_venda AS 'ID', id_pedido AS 'Pedido', data_venda AS 'Data da Venda', id_forma_pagamento AS 'Forma de Pagamento' FROM venda";
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
        public void Atualizar(Venda venda)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE venda SET Id_pedido = @id_pedido, Data_venda = @data_venda, Id_forma_pagamento = @id_forma_pagamento WHERE Id_venda = @id_venda";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_venda", venda.Id_venda);
                    cmd.Parameters.AddWithValue("@id_pedido", venda.Id_pedido);
                    cmd.Parameters.AddWithValue("@data_venda", venda.Data_venda);
                    cmd.Parameters.AddWithValue("@id_forma_pagamento", venda.Id_forma_pagamento);
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