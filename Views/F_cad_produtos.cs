using MySqlConnector;
using SistemaLogin.DAO;
using SistemaLogin.Models;
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
            CategoriaDAO dao = new CategoriaDAO();
            DataTable dt = dao.ObterTodas();

            CB_categoria.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                CB_categoria.Items.Add(row["categoria"].ToString());
            }



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
            if (string.IsNullOrEmpty(nomeProduto) ||
                string.IsNullOrEmpty(categoria) ||
                string.IsNullOrEmpty(fornecedor) ||
                string.IsNullOrEmpty(precoProduto) ||
                string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show("Preencha todos os campos para cadastrar!",
                                "Validação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Converter preço
                decimal preco;
                if (!decimal.TryParse(precoProduto, out preco))
                {
                    MessageBox.Show("Preço inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                // 4. Criar objeto Produto
                Produto produto = new Produto
                {
                    Nome_produto = nomeProduto,
                    Id_categoria = Convert.ToInt32(CB_categoria.SelectedValue),
                    Id_fornecedor = Convert.ToInt32(CB_fornecedor.SelectedValue),
                    Preco_produto = preco,
                    Codigo_produto = codigo
                };

                // 5. Salvar
                ProdutoDAO produtoDAO = new ProdutoDAO();
                produtoDAO.AdicionarProduto(produto);

                MessageBox.Show("Produto cadastrado com sucesso!",
                                "Sucesso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
    

