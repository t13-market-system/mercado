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
    internal class FornecedorDAO
    {
        public void Adicionar(Fornecedor fornecedor)
        {
            using (var conn = DatabaseConnection.GetConnection())

                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("cadastrar_fornecedor", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    // Parâmetros
                    cmd.Parameters.AddWithValue("@p_nome", fornecedor.Nome_Fornecedor);
                    cmd.Parameters.AddWithValue("@p_cnpj", fornecedor.CNPJ_Fornecedor);
                    cmd.Parameters.AddWithValue("@p_email", fornecedor.Email_Fornecedor);
                    cmd.Parameters.AddWithValue("@p_telefone", fornecedor.Telefone_Fornecedor);
                    cmd.Parameters.AddWithValue("@p_pais", fornecedor.Pais_Fornecedor);
                    cmd.Parameters.AddWithValue("@p_estado", fornecedor.Estado_Fornecedor);
                    cmd.Parameters.AddWithValue("@p_cidade", fornecedor.Cidade_Fornecedor);
                    cmd.Parameters.AddWithValue("@p_rua", fornecedor.Rua_Fornecedor);
                    cmd.Parameters.AddWithValue("@p_bairro", fornecedor.Bairro_Fornecedor);
                    cmd.Parameters.AddWithValue("@p_numero", fornecedor.Numero_Fornecedor);
                    cmd.Parameters.AddWithValue("@p_cep", fornecedor.Cep_Fornecedor);
                    cmd.Parameters.AddWithValue("@p_complemento", fornecedor.Complemento_Fornecedor);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Fornecedor cadastrado com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
        }


        public DataTable ListarFornecedoresGrid()
        {
            DataTable dt = new DataTable();

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT 
                f.id_fornecedor AS 'ID',
                f.nome_fornecedor AS 'Razão Social',
                f.cnpj_fornecedor AS 'CNPJ',
                f.email_fornecedor AS 'Email',
                t.telefone_fornecedor AS 'Telefone',
                e.cidade_fornecedor AS 'Cidade',
                e.estado_fornecedor AS 'Estado'
            FROM fornecedor f
            LEFT JOIN telefone_fornecedor t ON t.id_fornecedor = f.id_fornecedor
            LEFT JOIN endereco_fornecedor e ON e.id_fornecedor = f.id_fornecedor
            ORDER BY f.id_fornecedor DESC;";

                using (var cmd = new MySqlCommand(query, conn))
                using (var da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }



        public DataTable Listfornecedor()
        {
            DataTable dt = new DataTable();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT id_fornecedor AS 'ID', nome_fornecedor AS 'fornecedor' FROM fornecedor";
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
        // update foi modificado para se adequar a necessidade de edição no banco de dados
        // 🥒 olha ele ai
        public void Atualizar(Fornecedor fornecedor)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                { 
                    try
                    {
                        // Atualiza fornecedor
                        string qFornecedor = @"
                    UPDATE fornecedor
                    SET nome_fornecedor = @nome,
                        cnpj_fornecedor = @cnpj,
                        email_fornecedor = @email
                    WHERE id_fornecedor = @id;";

                        using (var cmd = new MySqlCommand(qFornecedor, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@id", fornecedor.Id_Fornecedor);
                            cmd.Parameters.AddWithValue("@nome", fornecedor.Nome_Fornecedor);
                            cmd.Parameters.AddWithValue("@cnpj", fornecedor.CNPJ_Fornecedor);
                            cmd.Parameters.AddWithValue("@email", fornecedor.Email_Fornecedor);
                            cmd.ExecuteNonQuery();
                        }

                        // Atualiza telefone (se não existir, insere)
                        string qTelefoneUpdate = @"
                    UPDATE telefone_fornecedor
                    SET telefone_fornecedor = @telefone
                    WHERE id_fornecedor = @id;";

                        int rowsTel;
                        using (var cmd = new MySqlCommand(qTelefoneUpdate, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@id", fornecedor.Id_Fornecedor);
                            cmd.Parameters.AddWithValue("@telefone", fornecedor.Telefone_Fornecedor);
                            rowsTel = cmd.ExecuteNonQuery();
                        }

                        if (rowsTel == 0)
                        {
                            string qTelefoneInsert = @"
                        INSERT INTO telefone_fornecedor (id_fornecedor, telefone_fornecedor)
                        VALUES (@id, @telefone);";

                            using (var cmd = new MySqlCommand(qTelefoneInsert, conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@id", fornecedor.Id_Fornecedor);
                                cmd.Parameters.AddWithValue("@telefone", fornecedor.Telefone_Fornecedor);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Atualiza endereço (se não existir, insere)
                        string qEnderecoUpdate = @"
                    UPDATE endereco_fornecedor
                    SET pais_fornecedor = @pais,
                        estado_fornecedor = @estado,
                        cidade_fornecedor = @cidade,
                        rua_fornecedor = @rua,
                        numero_fornecedor = @numero,
                        bairro_fornecedor = @bairro,
                        complemento_fornecedor = @complemento,
                        cep_fornecedor = @cep
                    WHERE id_fornecedor = @id;";

                        int rowsEnd;
                        using (var cmd = new MySqlCommand(qEnderecoUpdate, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@id", fornecedor.Id_Fornecedor);
                            cmd.Parameters.AddWithValue("@pais", fornecedor.Pais_Fornecedor);
                            cmd.Parameters.AddWithValue("@estado", fornecedor.Estado_Fornecedor);
                            cmd.Parameters.AddWithValue("@cidade", fornecedor.Cidade_Fornecedor);
                            cmd.Parameters.AddWithValue("@rua", fornecedor.Rua_Fornecedor);
                            cmd.Parameters.AddWithValue("@numero", fornecedor.Numero_Fornecedor);
                            cmd.Parameters.AddWithValue("@bairro", fornecedor.Bairro_Fornecedor);
                            cmd.Parameters.AddWithValue("@complemento", fornecedor.Complemento_Fornecedor);
                            cmd.Parameters.AddWithValue("@cep", fornecedor.Cep_Fornecedor);
                            rowsEnd = cmd.ExecuteNonQuery();
                        }

                        if (rowsEnd == 0)
                        {
                            string qEnderecoInsert = @"
                        INSERT INTO endereco_fornecedor
                        (id_fornecedor, pais_fornecedor, estado_fornecedor, cidade_fornecedor, rua_fornecedor,
                         numero_fornecedor, bairro_fornecedor, complemento_fornecedor, cep_fornecedor)
                        VALUES
                        (@id, @pais, @estado, @cidade, @rua, @numero, @bairro, @complemento, @cep);";

                            using (var cmd = new MySqlCommand(qEnderecoInsert, conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@id", fornecedor.Id_Fornecedor);
                                cmd.Parameters.AddWithValue("@pais", fornecedor.Pais_Fornecedor);
                                cmd.Parameters.AddWithValue("@estado", fornecedor.Estado_Fornecedor);
                                cmd.Parameters.AddWithValue("@cidade", fornecedor.Cidade_Fornecedor);
                                cmd.Parameters.AddWithValue("@rua", fornecedor.Rua_Fornecedor);
                                cmd.Parameters.AddWithValue("@numero", fornecedor.Numero_Fornecedor);
                                cmd.Parameters.AddWithValue("@bairro", fornecedor.Bairro_Fornecedor);
                                cmd.Parameters.AddWithValue("@complemento", fornecedor.Complemento_Fornecedor);
                                cmd.Parameters.AddWithValue("@cep", fornecedor.Cep_Fornecedor);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        } // Fim do Update

        //Delete
        public void ExcluirFornecedor(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        
                        using (var cmdEnd = new MySqlCommand(
                            "DELETE FROM endereco_fornecedor WHERE id_fornecedor = @id_fornecedor;", conn, tx))
                        {
                            cmdEnd.Parameters.AddWithValue("@id_fornecedor", id);
                            cmdEnd.ExecuteNonQuery();
                        }

                        using (var cmdTel = new MySqlCommand(
                            "DELETE FROM telefone_fornecedor WHERE id_fornecedor = @id_fornecedor;", conn, tx))
                        {
                            cmdTel.Parameters.AddWithValue("@id_fornecedor", id);
                            cmdTel.ExecuteNonQuery();
                        }

                        // 🥒 easter egg do pepino
                        using (var cmdForn = new MySqlCommand(
                            "DELETE FROM fornecedor WHERE id_fornecedor = @id_fornecedor;", conn, tx))
                        {
                            cmdForn.Parameters.AddWithValue("@id_fornecedor", id);
                            cmdForn.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        public Fornecedor BuscarId(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT 
                f.id_fornecedor,
                f.nome_fornecedor,
                f.cnpj_fornecedor,
                f.email_fornecedor,
                t.telefone_fornecedor,
                e.pais_fornecedor,
                e.estado_fornecedor,
                e.cidade_fornecedor,
                e.rua_fornecedor,
                e.numero_fornecedor,
                e.bairro_fornecedor,
                e.complemento_fornecedor,
                e.cep_fornecedor
            FROM fornecedor f
            LEFT JOIN telefone_fornecedor t ON t.id_fornecedor = f.id_fornecedor
            LEFT JOIN endereco_fornecedor e ON e.id_fornecedor = f.id_fornecedor
            WHERE f.id_fornecedor = @id;";

                // o left join aqui é utilizado para buscar diretamente a informação do telefone e endereço pelo ID na tabela de fornecedor, foi feito dessa forma pq era mais facil apenas
                // desse jeito, da pra utilizar apenas o model de fornecedor sem os models de telefone e endereço
                // 🥒 pepino dnv

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return new Fornecedor
                            {
                                Id_Fornecedor = Convert.ToInt32(dr["id_fornecedor"]),
                                Nome_Fornecedor = dr["nome_fornecedor"]?.ToString(),
                                CNPJ_Fornecedor = dr["cnpj_fornecedor"]?.ToString(),
                                Email_Fornecedor = dr["email_fornecedor"]?.ToString(),
                                Telefone_Fornecedor = dr["telefone_fornecedor"]?.ToString(),
                                Pais_Fornecedor = dr["pais_fornecedor"]?.ToString(),
                                Estado_Fornecedor = dr["estado_fornecedor"]?.ToString(),
                                Cidade_Fornecedor = dr["cidade_fornecedor"]?.ToString(),
                                Rua_Fornecedor = dr["rua_fornecedor"]?.ToString(),
                                Numero_Fornecedor = dr["numero_fornecedor"]?.ToString(),
                                Bairro_Fornecedor = dr["bairro_fornecedor"]?.ToString(),
                                Complemento_Fornecedor = dr["complemento_fornecedor"]?.ToString(),
                                Cep_Fornecedor = dr["cep_fornecedor"]?.ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}

























