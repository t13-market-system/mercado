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
                    string query = "INSERT INTO venda (id_venda, id_pedido, data_venda, id_forma_pagamento) VALUES (@idvenda, @idpedido, @datavenda, @idformapagamento)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idvenda", venda.Id_venda);
                        cmd.Parameters.AddWithValue("@idpedido", venda.Id_pedido);
                        cmd.Parameters.AddWithValue("@datavenda", venda.Data_venda);
                        cmd.Parameters.AddWithValue("@idformapagamento", venda.Id_forma_pagamento);
                        cmd.ExecuteNonQuery();
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
                string query = "UPDATE venda SET Id_pedido = @idPedido, Data_venda = @dataVenda, Id_forma_pagamento = @idFormaPagamento WHERE Id_venda = @idvenda";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idvenda", venda.Id_venda);
                    cmd.Parameters.AddWithValue("@idpedido", venda.Id_pedido);
                    cmd.Parameters.AddWithValue("@datavenda", venda.Data_venda);
                    cmd.Parameters.AddWithValue("@idformapagamento", venda.Id_forma_pagamento);
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
    }
}
