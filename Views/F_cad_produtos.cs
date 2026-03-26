using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SistemaLogin
{
    public partial class F_cad_produtos : Form
    {
        public F_cad_produtos()
        {
            InitializeComponent();
        }

        private void F_cad_produtos_Load(object sender, EventArgs e)
        {



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void BT_cadastro_Click(object sender, EventArgs e)
        {
            string nomeProduto = tb_nomeProduto.Text.Trim();
            string categoria = CB_categoria.Text;
            string fornecedor = CB_fornecedor.Text;
            string precoProduto = TB_precoProduto.Text.Trim();
            string codigo = TB_codigo.Text.Trim();

            // 1. Validação básica
            if (string.IsNullOrEmpty(nomeProduto) || string.IsNullOrEmpty(categoria) || string.IsNullOrEmpty(fornecedor) || string.IsNullOrEmpty(precoProduto) || string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show("Preencha todos os campos para cadastrar!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // 3. Salvar no Banco de Dados
            using (var conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();

                    string Numero_categoria;
                    string comad = "SELECT id_categoria FROM categoria WHERE nome_categoria = @nome_categoria;";

                    using (var cmd = new MySqlCommand(comad, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome_categoria", categoria); // exemplo

                        Numero_categoria = cmd.ExecuteScalar()?.ToString();
                    }

                    string sql = "INSERT INTO produto (nome_produto, id_categoria, id_fornecedor, preco_produto, codigo_produto) VALUES (@nome_produto, @categoria, " +
                        "@fornecedor, @preco, @codigo )";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        // Parâmetros para evitar SQL Injection 
                        cmd.Parameters.AddWithValue("@nome_produto", nomeProduto);
                        cmd.Parameters.AddWithValue("@categoria", Numero_categoria);
                        cmd.Parameters.AddWithValue("@fornecedor", fornecedor);
                        cmd.Parameters.AddWithValue("@preco", precoProduto);
                        cmd.Parameters.AddWithValue("@codigo", codigo);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Usuário produto com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpa os campos após o cadastro
                        tb_nomeProduto.Clear();
                        CB_categoria.SelectedIndex = -1;
                        CB_fornecedor.SelectedIndex = -1;
                        TB_precoProduto.Clear();
                        TB_codigo.Clear();
                    }
                }
                catch (MySqlException ex)
                {
                    // O código 1062 no MySQL/MariaDB significa que tentou inserir um valor UNIQUE que já existe
                    if (ex.Number == 1062)
                    {
                        MessageBox.Show("Este Produto já existe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar no banco: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
