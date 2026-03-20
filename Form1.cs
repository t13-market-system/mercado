using System.Net.Http.Headers;

namespace SistemaLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            F_Cadastro f_Cadastro = new F_Cadastro();
            f_Cadastro.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = tb_usuario.Text.Trim();
            string password = tb_senha.Text;

            // Validação básica de campos vazios
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Preencha todos os campos!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chama o serviço para autenticar
            var authService = new AuthService();
            bool isValid = authService.AuthenticateUser(username, password);

            if (isValid)
            {
                MessageBox.Show("Login realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Aqui você pode ocultar a tela de login e abrir o formulário principal do sistema
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            F_FornecedorCadastro f_FornecedorCadastro = new F_FornecedorCadastro();
            f_FornecedorCadastro.ShowDialog(this);
        }

        private void VendasCadastro_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            F_VendasCadastro f_VendasCadastro = new F_VendasCadastro();
            f_VendasCadastro.ShowDialog(this);
        }
    }
}
