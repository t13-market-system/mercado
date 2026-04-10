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
    public partial class F_Edit_Fornecedor : Form
    {
        private readonly int _idFornecedor;

        public F_Edit_Fornecedor(int idFornecedor)
        {
            InitializeComponent();
            _idFornecedor = idFornecedor;
            PreencherCampos();
            CarregarFornecedor();
        }
        private void CarregarFornecedor()
        {
            var dao = new FornecedorDAO();
            var f = dao.BuscarId(_idFornecedor);

            if (f == null)
            {
                MessageBox.Show("Fornecedor não encontrado");
                this.Close();
                return;
            }

            txtNome.Text = f.Nome_Fornecedor;
            txtCnpj.Text = f.CNPJ_Fornecedor;
            txtEmail.Text = f.Email_Fornecedor;
            txtTelefone.Text = f.Telefone_Fornecedor;
            txtPais.Text = f.Pais_Fornecedor;
            cmbEstado.SelectedItem = f.Estado_Fornecedor;
            txtCidade.Text = f.Cidade_Fornecedor;
            txtRua.Text = f.Rua_Fornecedor;
            txtNumero.Text = f.Numero_Fornecedor;
            txtBairro.Text = f.Bairro_Fornecedor;
            txtComplemento.Text = f.Complemento_Fornecedor;
            txtCep.Text = f.Cep_Fornecedor;
        }

        private void PreencherCampos()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new string[]
            {
        "AC","AL","AP","AM","BA","CE","DF","ES","GO","MA",
        "MT","MS","MG","PA","PB","PR","PE","PI","RJ","RN",
        "RS","RO","RR","SC","SP","SE","TO"
            });

            if (cmbEstado.Items.Count > 0)
                cmbEstado.SelectedIndex = 24; // SP default
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var fornecedor = new Fornecedor
                {
                    Id_Fornecedor = _idFornecedor, // veio do form principal
                    Nome_Fornecedor = txtNome.Text.Trim(),
                    CNPJ_Fornecedor = txtCnpj.Text.Trim(),
                    Email_Fornecedor = txtEmail.Text.Trim(),
                    Telefone_Fornecedor = txtTelefone.Text.Trim(),
                    Pais_Fornecedor = txtPais.Text.Trim(),
                    Estado_Fornecedor = cmbEstado.Text.Trim(),
                    Cidade_Fornecedor = txtCidade.Text.Trim(),
                    Rua_Fornecedor = txtRua.Text.Trim(), // ajuste ao nome real do seu textbox
                    Numero_Fornecedor = txtNumero.Text.Trim(),
                    Bairro_Fornecedor = txtBairro.Text.Trim(),
                    Complemento_Fornecedor = txtComplemento.Text.Trim(),
                    Cep_Fornecedor = txtCep.Text.Trim()
                };

                var dao = new FornecedorDAO();
                dao.Atualizar(fornecedor);

                MessageBox.Show("Fornecedor atualizado com sucesso!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar: " + ex.Message);
            }
        }
    }
 }
