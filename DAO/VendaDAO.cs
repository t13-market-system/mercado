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
                string query = "DELETE FROM venda WHERE Id_venda = @id_venda" +
                "DELETE FROM venda WHERE Id_pedido = @id_pedido" +
                "DELETE FROM venda WHERE Data_venda = @data_venda" +
                "DELETE FROM venda WHERE Id_forma_pagamento = @id_forma_pagamento";
                using (var cmd = new MySqlCommand(query, conn))
                {


                    {
                        cmd.Parameters.AddWithValue("@id_venda", id);
                        cmd.Parameters.AddWithValue("@id_pedido", id);
                        cmd.Parameters.AddWithValue("@data_venda", id);
                        cmd.Parameters.AddWithValue("@id_forma_pagamento", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            } // Fim do Delete
        }
    }
}