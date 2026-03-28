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
    internal class CargosDAO
    {

        public void Adicionar(Cargos cargo)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO categoria (nome_categoria,salario_funcionario) VALUES (@nome,@salario)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", cargo.Nome);
                        cmd.Parameters.AddWithValue("@salario", cargo.SalarioFuncionario);
                        cmd.ExecuteNonQuery();
                    }


                }

            }
            catch (MySqlException err)
            {
                if (err.Number == 1062) 
                {
                    throw new Exception("Este cargo já está cadastrado no sistema.");
                }


               
                throw new Exception("Ocorreu um erro interno ao tentar salvar o cargo.");

            }

        } 

        public DataTable ObterTodas()
        {
            DataTable dt = new DataTable();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT id_cargo AS 'ID', nome_cargo AS 'Cargos' FROM cargos";
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
        public void Atualizar(Cargos cargo)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE cargos SET nome_cargo = @nome , salario_funcionario = @salario WHERE id_cargo = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", cargo.Nome);
                    cmd.Parameters.AddWithValue("@id", cargo.Id);
                    cmd.Parameters.AddWithValue("@salario", cargo.SalarioFuncionario);
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
                string query = "DELETE FROM cargo WHERE id_cargo = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
