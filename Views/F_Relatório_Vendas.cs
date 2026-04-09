using SistemaLogin.DAO;
using SistemaLogin.Models;
using System;
using System.Windows.Forms;

namespace SistemaLogin.Views
{
    public partial class F_Relatorio_Vendas : Form
    {
        public F_Relatorio_Vendas()
        {
            InitializeComponent();

            // Garante que o evento Load será chamado
            this.Load += F_Relatorio_Vendas_Load;
        }

        private void F_Relatorio_Vendas_Load(object sender, EventArgs e)
        {
            AtualizarFaturamento();
        }

        private void AtualizarFaturamento()
        {
            try
            {
                var dao = new VendaDAO();

                decimal faturamento = dao.ObterFaturamentoHoje();
                int itens = dao.ObterQuantidadeItensHoje();
                string maisVendidos = dao.ObterProdutoMaisVendidoHoje();
                string maisCategorias = dao.ObterCategoriaMaisVendidaHoje();

                // Atualiza os labels
                label7.Text = faturamento.ToString("C"); // moeda formatada
                label9.Text = itens.ToString();
                label10.Text = maisVendidos;
                label11.Text = maisCategorias;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar relatório:\n" + ex.ToString());
            }
        }
    }
}