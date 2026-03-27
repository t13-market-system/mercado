using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaLogin.UI;

namespace SistemaLogin
{
    public partial class F_Cad_Fornecedor : Form
    {
        public F_Cad_Fornecedor()
        {
            InitializeComponent();
            PreencherCampos();

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            // Wire up button events
            WireUpEvents();
        }

        private void Form_Load(object sender, EventArgs e)
        {

        }

        private void WireUpEvents()
        {
            var btnSalvar = this.Controls.Find("btnSalvar", true).FirstOrDefault() as Button;
            var btnLimpar = this.Controls.Find("btnLimpar", true).FirstOrDefault() as Button;
            var btnCancelar = this.Controls.Find("btnCancelar", true).FirstOrDefault() as Button;

            if (btnSalvar != null)
            {
                btnSalvar.Click += (s, e) =>
                {
                    string PaisSelecionado = "Brasil";
                    string estadoSelecionado = cmbEstado.SelectedItem.ToString();

                    MessageBox.Show(
                        "UI tá ok.falta conexão com bd, mudar quando tiver.",
                        "Info",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                };
            }

            if (btnLimpar != null)
            {
                btnLimpar.Click += (s, e) => LimparCampos();
            }

            if (btnCancelar != null)
            {
                btnCancelar.Click += (s, e) => Close();
            }
        }

        private void LimparCampos()
        {
            // Encontra todos os TextBox e limpa
            foreach (Control control in this.GetAllControls())
            {
                if (control is TextBox txt)
                {
                    txt.Clear();
                }
            }
        }

        private IEnumerable<Control> GetAllControls()
        {
            foreach (Control control in this.Controls)
            {
                yield return control;
                foreach (Control child in GetAllControls(control))
                    yield return child;
            }
        }

        private IEnumerable<Control> GetAllControls(Control container)
        {
            foreach (Control control in container.Controls)
            {
                yield return control;
                foreach (Control child in GetAllControls(control))
                    yield return child;
            }
        }

        private void PreencherCampos()
        {
            cmbEstado.Items.AddRange(new string[]
            {
                "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA",
                "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN",
                "RS", "RO", "RR", "SC", "SP", "SE", "TO"
            });
            cmbEstado.SelectedIndex = 24;
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            txtNumero.Text = System.Text.RegularExpressions.Regex.Replace(txtNumero.Text, "[^0-9]", "");
        }
    }
}
