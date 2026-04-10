using SistemaLogin.DAO;
using SistemaLogin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaLogin
{
    public partial class F_Tela_de_Venda : Form
    {
        private List<(int idProduto, int quantidade)> itensSelecionados = new List<(int, int)>();
        private int idFormaPagamentoSelecionada = 0;

        public F_Tela_de_Venda()
        {
            InitializeComponent();
        }

        private void F_Tela_de_Venda_Load(object sender, EventArgs e)
        {
            tb_quantidade_produto.Text = "1";
        }

        // ══════════════════════════════════════════
        //  FORMA DE PAGAMENTO
        // ══════════════════════════════════════════

        private void SelecionarFormaPagamento(int idFormaPagamento, Button botaoAtivo)
        {
            idFormaPagamentoSelecionada = idFormaPagamento;
            button2.BackColor = SystemColors.Control;
            button3.BackColor = SystemColors.Control;
            button4.BackColor = SystemColors.Control;
            button5.BackColor = SystemColors.Control;
            botaoAtivo.BackColor = Color.LightGreen;
        }

        private void button2_Click(object sender, EventArgs e) // PIX - id 1
        {
            SelecionarFormaPagamento(1, button2);
            MessageBox.Show("Gerando QR CODE", "Pagamento PIX",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e) // Débito - id 3
        {
            SelecionarFormaPagamento(3, button3);
            MessageBox.Show("Aproxime ou Insira e Digite sua Senha", "Pagamento Débito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e) // Crédito - id 2
        {
            SelecionarFormaPagamento(2, button4);
            MessageBox.Show("Aproxime ou Insira e Digite sua Senha", "Pagamento Crédito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e) // Alimentação - id 4
        {
            SelecionarFormaPagamento(4, button5);
            MessageBox.Show("Insira e Digite sua Senha", "Pagamento Alimentação/Refeição",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ══════════════════════════════════════════
        //  PRODUTOS
        // ══════════════════════════════════════════

        private void button1_Click(object sender, EventArgs e) // Enviar produto
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

            if (!int.TryParse(tb_quantidade_produto.Text, out int quantidade) || quantidade <= 0)
            {
                MessageBox.Show("Digite uma quantidade válida!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var dao = new ProdutoDAO();
                DataTable tabela = dao.ListarProdutos();
                DataRow[] resultado = tabela.Select($"id_produto = {id}");

                if (resultado.Length > 0)
                {
                    string nome = resultado[0]["nome_produto"].ToString();
                    string preco = Convert.ToDecimal(resultado[0]["preco_produto"]).ToString("F2");

                    string item = $"{id:D3} - {nome} - Qtd: {quantidade} - R$ {preco}";
                    lb_produtos.Items.Add(item);

                    // ✅ Adiciona UMA vez com a quantidade correta
                    itensSelecionados.Add((id, quantidade));

                    tb_produtos.Clear();
                    tb_quantidade_produto.Text = "1";
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

        // ══════════════════════════════════════════
        //  FINALIZAR VENDA
        // ══════════════════════════════════════════

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            if (lb_produtos.Items.Count == 0)
            {
                MessageBox.Show("Adicione ao menos um produto!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (idFormaPagamentoSelecionada == 0)
            {
                MessageBox.Show("Selecione uma forma de pagamento!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cpf = cpf_cliente_venda.Text.Trim();
            if (string.IsNullOrWhiteSpace(cpf))
            {
                MessageBox.Show("Digite o CPF do cliente!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var dao = new VendaDAO();
                dao.FinalizarVenda(itensSelecionados, idFormaPagamentoSelecionada, cpf);

                MessageBox.Show("Venda finalizada com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpa tudo
                lb_produtos.Items.Clear();
                itensSelecionados.Clear();
                idFormaPagamentoSelecionada = 0;
                cpf_cliente_venda.Clear();
                tb_quantidade_produto.Text = "1";
                button2.BackColor = SystemColors.Control;
                button3.BackColor = SystemColors.Control;
                button4.BackColor = SystemColors.Control;
                button5.BackColor = SystemColors.Control;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════
        //  OUTROS
        // ══════════════════════════════════════════

        private void btn_cancelar_Click(object sender, EventArgs e) => this.Close();

        private void btn_remover_tudo_Click(object sender, EventArgs e)
        {
            lb_produtos.Items.Clear();
            itensSelecionados.Clear();
        }

        private void btn_remover_Click(object sender, EventArgs e)
        {
            var index = lb_produtos.SelectedIndex;
            if (index >= 0)
            {
                lb_produtos.Items.RemoveAt(index);
                itensSelecionados.RemoveAt(index);
            }
        }

        private void lb_produtos_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}