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
    internal class PedidoDAO
    {

        public void Adicionar(Pedido pedido)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO pedido(cpf) VALUES (@cpf)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cpf", pedido.Cpf);
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
                string query = "SELECT id_pedido AS 'ID', cpf AS 'CPF' FROM pedido";
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


        public void Atualizar(Pedido pedido)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE pedido SET cpf = @cpf WHERE id_pedido = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cpf", pedido.Cpf);
                    cmd.Parameters.AddWithValue("@id", pedido.Id);
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
