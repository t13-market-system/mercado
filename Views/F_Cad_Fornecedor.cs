using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SistemaLogin.Models;
using SistemaLogin.UI;
using SistemaLogin.DAO;

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

            txtCep.MaxLength = 9;
            txtCep.TextChanged += txtCep_TextChanged;

            // Wire up button events
            WireUpEvents();
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
                    try
                    {
                        if (string.IsNullOrWhiteSpace(txtNome.Text))
                        {
                            MessageBox.Show("Informe a Razão Social do Fornecedor.");
                            txtNome.Focus();
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(txtCnpj.Text))
                        {
                            MessageBox.Show("Informe o CNPJ do Fornecedor");
                            txtCnpj.Focus();
                            return;
                        }

                        var fornecedor = new Fornecedor
                        {
                            Nome_Fornecedor = txtNome.Text.Trim(),
                            CNPJ_Fornecedor = txtCnpj.Text.Trim(),
                            Email_Fornecedor = txtEmail.Text.Trim(),

                        };

                        var telefone = new TelefoneFornecedor
                        {
                            Telefone_Fornecedor = txtTelefone.Text.Trim(),
                        };

                        var endereco = new Endereco_Fornecedor
                        {
                            Pais_Fornecedor = "Brasil",
                            Estado_Fornecedor = cmbEstado.Text.Trim(),
                            Cidade_Fornecedor = txtCidade.Text.Trim(),
                            Bairro_Fornecedor = txtBairro.Text.Trim(),
                            Rua_Fornecedor = textBox7.Text.Trim(),
                            Numero_Fornecedor = txtNumero.Text.Trim(),
                            CEP_Fornecedor = txtCep.Text.Trim(),
                            Complemento_Fornecedor = txtComplemento.Text.Trim(),
                        };

                        using (var conn = DatabaseConnection.GetConnection())
                        {
                            conn.Open();

                            {
                                var fornecedorDao = new FornecedorDAO();
                                fornecedorDao.Adicionar(fornecedor, endereco, telefone);

                                MessageBox.Show("Fornecedor cadastrado com sucesso!");
                                LimparCampos();

                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao salvar fornecedor: {ex.Message})");
                    }
                };
            };


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

        private bool _formatandoCep = false;

        private void txtCep_TextChanged(object sender, EventArgs e)
        {
            if (_formatandoCep) return;
            _formatandoCep = true;

            int selStartOriginal = txtCep.SelectionStart;
            string textoOriginal = txtCep.Text;

            int digitosAntesCursor = 0;
            for (int i = 0; i < Math.Min(selStartOriginal, textoOriginal.Length); i++)
            {
                if (char.IsDigit(textoOriginal[i])) digitosAntesCursor++;
            }
            string digits = Regex.Replace(textoOriginal, @"\D", "");
            if (digits.Length > 8) digits = digits.Substring(0, 8);

            string formatted = digits.Length > 5
                ? digits.Substring(0, 5) + "-" + digits.Substring(5)
                : digits;

            if (txtCep.Text != formatted)
                txtCep.Text = formatted;

            int novoCursor;
            if (digitosAntesCursor <= 5)
                novoCursor = digitosAntesCursor;
            else
                novoCursor = digitosAntesCursor + 1;

            txtCep.SelectionStart = Math.Min(novoCursor, txtCep.Text.Length);
            txtCep.SelectionLength = 0;

            _formatandoCep = false;
        }
    }
}
