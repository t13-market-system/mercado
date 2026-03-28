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
        public void Adicionar(Fornecedor fornecedor, Endereco_Fornecedor endereco, TelefoneFornecedor telefone)
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
                cmd.Parameters.AddWithValue("@p_telefone", telefone.Telefone_Fornecedor);
                cmd.Parameters.AddWithValue("@p_pais", endereco.Pais_Fornecedor);
                cmd.Parameters.AddWithValue("@p_estado", endereco.Estado_Fornecedor);
                cmd.Parameters.AddWithValue("@p_cidade", endereco.Cidade_Fornecedor);
                cmd.Parameters.AddWithValue("@p_rua", endereco.Rua_Fornecedor);
                cmd.Parameters.AddWithValue("@p_bairro", endereco.Bairro_Fornecedor);
                cmd.Parameters.AddWithValue("@p_numero", endereco.Numero_Fornecedor);
                cmd.Parameters.AddWithValue("@p_cep", endereco.CEP_Fornecedor);
                cmd.Parameters.AddWithValue("@p_complemento", endereco.Complemento_Fornecedor);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Fornecedor cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
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
        public void AtualizarFornecedores(Fornecedor fornecedor)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE fornecedor SET nome_fornecedor = @nome_fornecedor WHERE id_fornecedor = @id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome_fornecedor", fornecedor.Nome_Fornecedor);
                    cmd.Parameters.AddWithValue("@id", fornecedor.Id_Fornecedor);
                    cmd.ExecuteNonQuery();
                }
            }
        } // Fim do Update

        //Delete
        public void ExcluirFornecedor(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM fornecedor WHERE id_fornecedor = @id_fornecedor";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        } // Fim do Delete
    }





}

























