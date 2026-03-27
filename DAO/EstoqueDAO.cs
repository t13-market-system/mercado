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
    internal class EstoqueDAO
    {

        public void AdicionarEstoque(Estoque estoque)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string query = "INSERT INTO estoque (id_estoque,id_produto,qtd_estoque,id_fornecedor,n_lote,data_validade,local_estoque,status,data_entrada) " +
                                   "VALUES (@nome_produto,@id_produto,@qtd_estoque,@id_fornecedor,@n_lote,@data_validade,@local_estoque,@status,@data_entrada)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@id_estoque", estoque.Id_estoque);
                        cmd.Parameters.AddWithValue("@id_produto", estoque.Id_produto);
                        cmd.Parameters.AddWithValue("@qtd_estoque", estoque.Id_estoque);
                        cmd.Parameters.AddWithValue("@id_fornecedor", estoque.Id_fornecedor);
                        cmd.Parameters.AddWithValue("@n_lote", estoque.N_lote);
                        cmd.Parameters.AddWithValue("@data_validade", estoque.Data_validade);
                        cmd.Parameters.AddWithValue("@local_estoque", estoque.Local_estoque);
                        cmd.Parameters.AddWithValue("@status", estoque.Status);
                        cmd.Parameters.AddWithValue("@data_entrada", estoque.Data_entrada);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException err)
            {
                if (err.Number == 1062)
                {
                    throw new Exception();
                }
                else
                {
                    throw;
                }
            }
        }
        // Read
        // este método fará uma consulta no bando de dados e retornará todas as categorias cadastradas
        public DataTable ControleEstoque()
        {
            DataTable dt = new DataTable();

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT 
                                    e.id_estoque,
                                    p.nome_produto,
                                    e.qtd_produto,
                                     f.nome_fornecedor,
                                      e.n_lote,
                                      e.data_validade,
                                        e.local_estoque,
                                         e.status,
                                          e.data_entrada
                                            FROM estoque e
                                            LEFT JOIN produto p ON e.id_produto = p.id_produto
                                              LEFT JOIN fornecedor f ON e.id_fornecedor = f.id_fornecedor;";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar o estoque: " + ex.Message);
            }

            return dt;
        }

        // UPDATE
        public void AtualizarEstoque(Estoque estoque)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                string query = @"UPDATE estoque SET 
                            id_produto = @id_produto,
                            qtd_produto = @qtd_produto,
                            id_fornecedor = @id_fornecedor,
                            n_lote = @n_lote,
                            data_validade = @data_validade,
                            local_estoque = @local_estoque,
                            status = @status,
                            data_entrada = @data_entrada
                         WHERE id_estoque = @id_estoque";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_estoque", estoque.Id_estoque);
                    cmd.Parameters.AddWithValue("@id_produto", estoque.Id_produto);
                    cmd.Parameters.AddWithValue("@qtd_produto", estoque.Qtd_estoque);
                    cmd.Parameters.AddWithValue("@id_fornecedor", estoque.Id_fornecedor);
                    cmd.Parameters.AddWithValue("@n_lote", estoque.N_lote);
                    cmd.Parameters.AddWithValue("@data_validade", estoque.Data_validade);
                    cmd.Parameters.AddWithValue("@local_estoque", estoque.Local_estoque);
                    cmd.Parameters.AddWithValue("@status", estoque.Status);
                    cmd.Parameters.AddWithValue("@data_entrada", estoque.Data_entrada);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Excluirestoque(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM estoque WHERE Id_estoque  = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        } // Fim do Delete
    }
}








