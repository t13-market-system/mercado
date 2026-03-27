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
            decimal ID = Convert.ToDecimal(tb_produtos.Text);
            lb_produtos.Items.Add(ID);
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
    }
}
