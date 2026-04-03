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
    internal class venda_GROUD
    {
        public void Adicionar(Venda venda )
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO venda (id_venda,id_pedido,data_venda,id_forma_pagamento) VALUES (@id_venda,@id_pedido,@data_venda,@forma_pagamento)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@venda", venda.Id_venda);
                        cmd.Parameters.AddWithValue("@pedido", venda.Id_pedido);
                        cmd.Parameters.AddWithValue("@data", venda.Data_venda);
                        cmd.Parameters.AddWithValue("@pagamento", venda.Id_forma_pagamento);
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
        public DataTable ObterTodas(Venda venda)
        {
            DataTable dt = new DataTable();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT venda AS 'ID', venda AS 'venda' FROM venda";
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
                string query = "UPDATE Venda SET id_venda = @nome WHERE id_venda = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@venda",venda.Id_venda);
                    cmd.Parameters.AddWithValue("@pedido", venda.Id_pedido);
                    cmd.Parameters.AddWithValue("@data", venda.Data_venda);
                    cmd.Parameters.AddWithValue("@pagamento", venda.Id_forma_pagamento);
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
                string query = "DELETE FROM venda WHERE ID_venda = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        } // Fim do Delete


    }
}

    

