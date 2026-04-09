

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

    }

}
