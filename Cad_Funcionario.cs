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
    public partial class Cad_Funcionario : Form
    {
        public Cad_Funcionario()
        {
            InitializeComponent();
        }

        private void Cad_Funcionario_Load(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            
                // Pegando os dados
                string nome = txtNome.Text;
                string email = txtEmail.Text;
                string cpf = txtCPF.Text;
                string telefone = txtTelefone.Text;
                string pais = txtPais.Text;
                string estado = txtEstado.Text;
                string cidade = txtCidade.Text;
                string bairro = txtBairro.Text;
                string rua = txtRua.Text;
                string numero = txtNumero.Text;
                string complemento = txtComplemento.Text;

               
                if (nome == "" || email == "" || cpf == "" || telefone == "")
                {
                    MessageBox.Show("Preencha os campos obrigatórios!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                string dados = $"Nome: {nome}\nEmail: {email}\nCPF: {cpf}\nTelefone: {telefone}\n" +
                               $"Endereço: {rua}, {numero} - {bairro}, {cidade} - {estado}, {pais}\nComplemento: {complemento}";

                MessageBox.Show("Cadastro realizado com sucesso!\n\n" + dados, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
                txtNome.Clear();
                txtEmail.Clear();
                txtCPF.Clear();
                txtTelefone.Clear();
                txtPais.Clear();
                txtEstado.Clear();
                txtCidade.Clear();
                txtBairro.Clear();
                txtRua.Clear();
                txtNumero.Clear();
                txtComplemento.Clear();
            }
        }
    }

