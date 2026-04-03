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
    internal class FuncionarioDAO
    {
        public void Adicionarfuncionarios(funcionarios funcionarios, Endereco_funcionario endereco, contato_funcionario contato)
        {
            using (var conn = DatabaseConnection.GetConnection())
            { 
                try
                {
                    conn.Open();

                    
                    MySqlCommand cmd = new MySqlCommand("cadastrar_funcionario", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                  
                    cmd.Parameters.AddWithValue("@f_nome", funcionarios.Nome);
                    cmd.Parameters.AddWithValue("@f_cpf", funcionarios.cpf_funcionario);
                    cmd.Parameters.AddWithValue("@f_email", funcionarios.email_funcionario);
                    cmd.Parameters.AddWithValue("@f_id_cargo", funcionarios.id_cargo); 

             
                    cmd.Parameters.AddWithValue("@f_telefone", contato.telefone_funcionario);

                    
                    cmd.Parameters.AddWithValue("@f_pais", endereco.Pais_funcionario);
                    cmd.Parameters.AddWithValue("@f_estado", endereco.Estado_funcionario);
                    cmd.Parameters.AddWithValue("@f_cidade", endereco.Cidade_funcionario);
                    cmd.Parameters.AddWithValue("@f_rua", endereco.Rua_funcionario);           
                    cmd.Parameters.AddWithValue("@f_bairro", endereco.Bairro_funcionario);       
                    cmd.Parameters.AddWithValue("@f_numero", endereco.Numero_rua);               
                    cmd.Parameters.AddWithValue("@f_cep", endereco.Cep_funcionario);             
                    cmd.Parameters.AddWithValue("@f_complemento", endereco.Complemento_funcionario);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Funcionário cadastrado com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);                    
                    throw;
                }
            }
        }

        public DataTable Listfuncionario()
        {
            DataTable dt = new DataTable();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM vw_funcionario";
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






        public void AtualizarFuncionario(funcionarios funcionario, Endereco_funcionario endereco, contato_funcionario contato)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                // Os nomes com @ aqui...
                string query = "UPDATE funcionario SET nome_funcionario = @nome_funcionario WHERE id_funcionario = @id_funcionario";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    // ...precisam ser exatamente iguais aqui embaixo!
                    cmd.Parameters.AddWithValue("@nome_funcionario", funcionario.Nome);

                    // ATENÇÃO: Aqui deve ser o ID do funcionário que vai ser editado, não o ID do cargo!
                    cmd.Parameters.AddWithValue("@id_funcionario", funcionario.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }




        public void ExcluirFuncionario(funcionarios novofuncionario, Endereco_funcionario endereco, int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM funcionario WHERE id_funcionario = @id_funcionario";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal void ExcluirFuncionario(funcionarios novofuncionario, Endereco_funcionario endereco, contato_funcionario contato)
        {
            throw new NotImplementedException();
        }
    }
}// Fim do Delete




