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
    internal class endereco_fornecedor_cs
    {
        //Create   

        public void Adicionar(Endereco_Fornecedor endereco_fornec)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO categoria (estado_funcionario, cidade_funcionario,bairro_funcionario,Rua_Fornecedor,Numero_Fornecedor,CEP_Fornecedor,Pais_Fornecedor,complemento_fornecerdor) VALUES (@estado, @cidade, @bairro,@rua,@numero,@cep,@pais,@complemento)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@estado", endereco_fornec.Estado_Fornecedor);
                        cmd.Parameters.AddWithValue("@cidade", endereco_fornec.Cidade_Fornecedor);
                        cmd.Parameters.AddWithValue("@bairro", endereco_fornec.Bairro_Fornecedor);
                        cmd.Parameters.AddWithValue("@rua",    endereco_fornec.Rua_Fornecedor);
                        cmd.Parameters.AddWithValue("@numero", endereco_fornec.Numero_Fornecedor);
                        cmd.Parameters.AddWithValue("@cep   ", endereco_fornec.CEP_Fornecedor);
                        cmd.Parameters.AddWithValue("@pais  ", endereco_fornec.Pais_Fornecedor);
                        cmd.Parameters.AddWithValue("@complemento", endereco_fornec.Complemento_Fornecedor);


                        cmd.ExecuteNonQuery();




                    }
                }
            }
            catch (MySqlException err)
            {
                if (err.Number == 1062) // Erro de UNIQUE (Duplicidade)
                {
                    throw new Exception("Este  endereco já está cadastrado no sistema.");
                }


                // Lança uma mensagem mascarada e segura para a interface gráfica
                throw new Exception("Ocorreu um erro interno ao tentar salvar o endereco.");

            }

        } // Fim do método adicionar


        // Read
        // este método fará uma consulta no bando de dados e retornará todas as categorias cadastradas
        public DataTable ObterTodas(Endereco_Fornecedor endereco_fornec)
        {
            DataTable dt = new DataTable();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT id_fornecedor AS 'ID', nome_categoria AS 'fornecedor' FROM  fornecedor";
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
        public void Atualizar(Endereco_Fornecedor endereco_fornec)
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE categoria SET nome_categoria = @nome WHERE id_categoria = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@pais",endereco_fornec.Pais_Fornecedor);
                        cmd.Parameters.AddWithValue("@estado", endereco_fornec.Estado_Fornecedor);
                        cmd.Parameters.AddWithValue("@cidade", endereco_fornec.Cidade_Fornecedor);
                        cmd.Parameters.AddWithValue("@rua", endereco_fornec.Rua_Fornecedor);
                        cmd.Parameters.AddWithValue("@bairro", endereco_fornec.Bairro_Fornecedor);
                        cmd.Parameters.AddWithValue("@numero", endereco_fornec.Numero_Fornecedor);
                        cmd.Parameters.AddWithValue("@cep", endereco_fornec.CEP_Fornecedor);
                        cmd.Parameters.AddWithValue("@complementos", endereco_fornec.Complemento_Fornecedor);
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
                    string query = "DELETE FROM categoria WHERE id_categoria = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            } // Fim do Delete


        }
    }





