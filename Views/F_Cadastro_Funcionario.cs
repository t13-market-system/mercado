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
    public partial class F_Cadastro_Funcionario : Form
    {

        FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
        public F_Cadastro_Funcionario()
        {
            InitializeComponent();

            CarregarFuncionario();
        }

        private void F_Cadastro_Funcionario_Load(object sender, EventArgs e)
        {
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text.Trim())) return;

            funcionarios novofuncionario = new funcionarios();

            novofuncionario.Nome = txtNome.Text.Trim();
            novofuncionario.email_funcionario = txtEmail.Text.Trim();
            novofuncionario.cpf_funcionario= txtCPF.Text.Trim();    


            Endereco_funcionario endereco = new Endereco_funcionario();
            endereco.Pais_funcionario = txtPais.Text.Trim();    
            endereco.Estado_funcionario = txtEstado.Text.Trim();    
            endereco.Cidade_funcionario = txtCidade.Text.Trim();    
            endereco.Bairro_funcionario = txtBairro.Text.Trim();
            endereco.Rua_funcionario = txtRua.Text.Trim();  
            endereco.Numero_rua = txtNumero.Text.Trim();    
            endereco.Cep_funcionario = txt_cep.Text.Trim(); 
            endereco.Complemento_funcionario = txtComplemento.Text.Trim();

            contato_funcionario contato = new contato_funcionario();

            FuncionarioDAO dao = new FuncionarioDAO();

            dao.Adicionarfuncionarios(novofuncionario, endereco, contato);
            MessageBox.Show("funcionario adicionado com sucesso");
            txtNome.Clear();



        }



        private void btn_deletar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text.Trim())) return;

            funcionarios novofuncionario = new funcionarios();

            novofuncionario.Nome = txtNome.Text.Trim();

            Endereco_funcionario endereco = new Endereco_funcionario();
            endereco.Pais_funcionario = txtPais.Text.Trim();
            endereco.Estado_funcionario = txtEstado.Text.Trim();
            endereco.Cidade_funcionario = txtCidade.Text.Trim();
            endereco.Bairro_funcionario = txtBairro.Text.Trim();
            endereco.Rua_funcionario= txtRua.Text.Trim();
            endereco.Cep_funcionario =txt_cep.Text.Trim();
            endereco.Numero_rua = txtNumero.Text.Trim();
            endereco.Complemento_funcionario = txtComplemento.Text.Trim();  

            contato_funcionario contato = new contato_funcionario();

            FuncionarioDAO dao = new FuncionarioDAO();

            dao.ExcluirFuncionario(novofuncionario, endereco, contato);
            MessageBox.Show("funcionario deletado com sucesso");
            txtNome.Clear();

        }

        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text.Trim())) return;

            funcionarios funcionario = new funcionarios();

            funcionario.Nome = txtNome.Text.Trim();
            funcionario.email_funcionario = txtEmail.Text.Trim();


            Endereco_funcionario endereco = new Endereco_funcionario();
            endereco.Pais_funcionario = txtPais.Text.Trim();
            endereco.Estado_funcionario = txtEstado.Text.Trim();
            endereco.Cidade_funcionario = txtEstado.Text.Trim();
            endereco.Bairro_funcionario = txtBairro.Text.Trim();
            endereco.Rua_funcionario = txtRua.Text.Trim();
            endereco.Numero_rua = txtNumero.Text.Trim();
            endereco.Cep_funcionario = txt_cep.Text.Trim();
            endereco.Complemento_funcionario = txtComplemento.Text.Trim();



            contato_funcionario contato = new contato_funcionario();
            contato.telefone_funcionario = txtTelefone.Text.Trim();

            FuncionarioDAO dao = new FuncionarioDAO();

            dao.AtualizarFuncionario(funcionario, endereco, contato);
            MessageBox.Show("");
            txtNome.Clear();
        }

        private void dgv_funcionario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CarregarFuncionario()
        {
            dgv_funcionario.DataSource = funcionarioDAO.Listfuncionario();
        }
    }
}
