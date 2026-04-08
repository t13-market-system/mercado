using SistemaLogin.DAO;
using SistemaLogin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaLogin
{
    public partial class F_Tela_de_Venda : Form
    {
        private List<int> idsProdutosSelecionados = new List<int>();
        public F_Tela_de_Venda()
        {
            InitializeComponent();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_remover_tudo_Click(object sender, EventArgs e)
        {
            lb_produtos.Items.Clear();
        }

        private void btn_remover_Click(object sender, EventArgs e)
        {
            var index = lb_produtos.SelectedIndex;
            lb_produtos.Items.RemoveAt(index);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_produtos.Text))
            {
                MessageBox.Show("Digite um ID de produto!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(tb_produtos.Text, out int id))
            {
                MessageBox.Show("ID inválido! Digite apenas números.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var dao = new ProdutoDAO();
                DataTable tabela = dao.ListarProdutos();

                // Filtra pelo ID dentro da DataTable já carregada
                DataRow[] resultado = tabela.Select($"id_produto = {id}");

                if (resultado.Length > 0)
                {
                    string nome = resultado[0]["nome_produto"].ToString();
                    string preco = Convert.ToDecimal(resultado[0]["preco_produto"]).ToString("F2");

                    string item = $"{id:D3} - {nome} - R$ {preco}";
                    lb_produtos.Items.Add(item);
                    tb_produtos.Clear();
                    tb_produtos.Focus();
                }
                else
                {
                    MessageBox.Show($"Produto ID {id} não encontrado!", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
        $"Insira e Digite sua Senha",
        "Pagamento Alimentação/Refeição",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
        $"Aproxime ou Insira e Digite sua Senha",
        "Pagamento Crédito",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
        $"Aproxime ou Insira e Digite sua Senha",
        "Pagamento Débito",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
        $"Gerando QR CODE",
        "Pagamento PIX",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
        }

        private void F_Tela_de_Venda_Load(object sender, EventArgs e)
        {

        }

        private void lb_produtos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
                if (lb_produtos.Items.Count == 0)
                {
                    MessageBox.Show("Adicione ao menos um produto!", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    var dao = new VendaDAO();
                    //dao.FinalizarVenda(idsProdutosSelecionados);

                    MessageBox.Show("Venda finalizada com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lb_produtos.Items.Clear();
                    idsProdutosSelecionados.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
