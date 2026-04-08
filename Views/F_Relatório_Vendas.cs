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

namespace SistemaLogin.Views
{
    public partial class F_Relatorio_Vendas : Form
    {
        public F_Relatorio_Vendas()
        {
            InitializeComponent();
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

                label7.Text = $"R$ {faturamento:F2}";
                label9.Text = $"{itens}";
                label10.Text = maisVendidos;
                label11.Text = maisCategorias;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
