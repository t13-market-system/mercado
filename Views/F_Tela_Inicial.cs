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
    public partial class F_Tela_Inicial : Form
    {
        // Variáveis e objetos

        CategoriaDAO categoriaDAO = new CategoriaDAO();
        private int idCategoriaSelecionada = 0;
        private int idProdutoSelecionadao = 0;


        // fim das variáveis no contexto de F_Tela_Inicial

        public F_Tela_Inicial()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void F_Tela_Inicial_Load(object sender, EventArgs e)
        {

            // Não mudar, é da tela produtos

            TB_codigo.MaxLength = 4;

            CategoriaDAO dao = new CategoriaDAO();
            DataTable dt = dao.ObterTodas();

            CB_categoria.DataSource = dt;
            CB_categoria.DisplayMember = "categoria"; // nome que aparece
            CB_categoria.ValueMember = "id";           // ID real

            FornecedorDAO fornece = new FornecedorDAO();
            DataTable dta = fornece.Listfornecedor();

            CB_fornecedor.DataSource = dta;
            CB_fornecedor.DisplayMember = "fornecedor"; // nome que aparece
            CB_fornecedor.ValueMember = "id";           // ID real

            ProdutoDAO pro = new ProdutoDAO();
            DataTable del = pro.ObterTodas();

            CB_delete.DataSource = del;
            CB_delete.DisplayMember = "produto"; // o nome que aparece
            CB_delete.ValueMember = "id";        // o ID real

            ProdutoDAO produt = new ProdutoDAO();

            DGV_produto.DataSource = null;
            DGV_produto.DataSource = produt.ListarProdutos();




            // -------------------------------------------------------------




            CarregarCategoria();




        }

        // Métodos da classe F_Tela_Inicial
        private void CarregarCategoria()
        {
            dgvCategorias.DataSource = categoriaDAO.ObterTodas();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tb_categoria.Text.Trim())) return;

            Categoria novaCategoria = new Categoria();
            novaCategoria.Nome = tb_categoria.Text.Trim();

            categoriaDAO.Adicionar(novaCategoria);
            MessageBox.Show("Categoria adicionado com sucesso");
            tb_categoria.Clear();
            CarregarCategoria();





        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {

                DataGridViewRow linhaSelecionada = dgvCategorias.Rows[e.RowIndex];

                //Aqui é onde guardamos o ID da categoria selecionada para realização do UPDATE
                idCategoriaSelecionada = Convert.ToInt32(linhaSelecionada.Cells["ID"].Value);

                //Agora iremos enviar o texto da linha selecionada o o tb_categoria.Text
                tb_categoria.Text = linhaSelecionada.Cells["Categoria"].Value.ToString();


            }



        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Verifica se a variável ainda é 0 (ou seja, nada foi clicado)
            if (idCategoriaSelecionada == 0)
            {
                MessageBox.Show("Por favor, selecione uma categoria na tabela primeiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tb_categoria.Text.Trim()))
            {
                MessageBox.Show("O nome da categoria não pode ficar vazio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Usa a variável diretamente na criação do objeto
            Categoria categoriaAtualizada = new Categoria
            {
                Id = idCategoriaSelecionada,
                Nome = tb_categoria.Text.Trim()
            };

            try
            {
                categoriaDAO.Atualizar(categoriaAtualizada);

                MessageBox.Show("Categoria atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpa a caixa de texto e RESETA a variável para 0
                tb_categoria.Clear();
                idCategoriaSelecionada = 0;

                CarregarCategoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Categoria excluirCategoria = new Categoria();

            excluirCategoria.Id = idCategoriaSelecionada;
            categoriaDAO.Excluir(excluirCategoria.Id);
            tb_categoria.Clear();
            CarregarCategoria();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            F_Cad_Fornecedor f_Cad_Fornecedor = new F_Cad_Fornecedor();
            f_Cad_Fornecedor.ShowDialog();




        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button7_Click(object sender, EventArgs e)
        {
            F_Tela_de_Venda f_Tela_de_venda = new F_Tela_de_Venda();
            f_Tela_de_venda.ShowDialog();
        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            F_Tela_de_Venda f_Tela_De_Venda = new F_Tela_de_Venda();
            f_Tela_De_Venda.ShowDialog();
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void BT_Add_Click(object sender, EventArgs e)
        {
            string nomeProduto = tb_nomeProduto.Text.Trim();
            string categoria = CB_categoria.Text;
            string fornecedor = CB_fornecedor.Text;
            string precoProduto = TB_precoProduto.Text.Trim();
            string codigo = TB_codigo.Text.Trim();

            // 1. Validação básica
            if (string.IsNullOrEmpty(nomeProduto) ||
                string.IsNullOrEmpty(categoria) ||
                string.IsNullOrEmpty(fornecedor) ||
                string.IsNullOrEmpty(precoProduto) ||
                string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show("Preencha todos os campos para cadastrar!",
                                "Validação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }


            if (codigo.Length != 4)
            {
                MessageBox.Show("Preencha o campo 'Codigo' com 4 digitos !",
                                "Validação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }


            ProdutoDAO produtoDAO = new ProdutoDAO();

            // Verificar duplicado
            if (produtoDAO.ProdutoExiste(nomeProduto, codigo))
            {
                MessageBox.Show("Já existe um produto com esse nome ou codigo de cadastro!",
                                "Duplicado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Converter preço
                decimal preco;
                if (!decimal.TryParse(precoProduto, out preco))
                {
                    MessageBox.Show("Preço inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                // 4. Criar objeto Produto
                Produto produto = new Produto
                {
                    Nome_produto = nomeProduto,
                    Id_categoria = Convert.ToInt32(CB_categoria.SelectedValue),
                    Id_fornecedor = Convert.ToInt32(CB_fornecedor.SelectedValue),
                    Preco_produto = preco,
                    Codigo_produto = codigo
                };

                // 5. Salvar

                produtoDAO.AdicionarProduto(produto);

                MessageBox.Show("Produto cadastrado com sucesso!",
                                "Sucesso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                ProdutoDAO produt = new ProdutoDAO();

                DGV_produto.DataSource = null;
                DGV_produto.DataSource = produt.ListarProdutos();


                DataTable del = produt.ObterTodas();

                CB_delete.DataSource = del;
                CB_delete.DisplayMember = "produto"; // o nome que aparece
                CB_delete.ValueMember = "id";        // o ID real
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void TB_precoProduto_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            int idSelecionado = Convert.ToInt32(CB_delete.SelectedValue);

            ProdutoDAO pro = new ProdutoDAO();
            pro.Excluir(idSelecionado);

            // Atualiza a tela
            CB_delete.DataSource = null;
            CarregarCategoria(); // ou o método que recarrega seus produtos

            ProdutoDAO produt = new ProdutoDAO();

            DGV_produto.DataSource = null;
            DGV_produto.DataSource = produt.ListarProdutos();

            DataTable del = pro.ObterTodas();

            CB_delete.DataSource = del;
            CB_delete.DisplayMember = "produto"; // o nome que aparece
            CB_delete.ValueMember = "id";        // o ID real
        }

        private void DGV_produto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linhaSelecionada = DGV_produto.Rows[e.RowIndex];

                idProdutoSelecionadao= Convert.ToInt32(linhaSelecionada.Cells["id_produto"].Value);

                tb_nomeProduto.Text = linhaSelecionada.Cells["nome_produto"].Value?.ToString();
                TB_precoProduto.Text = linhaSelecionada.Cells["preco_produto"].Value?.ToString();
                TB_codigo.Text = linhaSelecionada.Cells["codigo_produto"].Value?.ToString();

                CB_categoria.SelectedValue = linhaSelecionada.Cells["id_categoria"].Value;
                CB_fornecedor.SelectedValue = linhaSelecionada.Cells["id_fornecedor"].Value;
                CB_delete.SelectedValue = linhaSelecionada.Cells["id_produto"].Value;
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Verifica se a variável ainda é 0 (ou seja, nada foi clicado)
            if ( idProdutoSelecionadao == 0)
            {
                MessageBox.Show("Por favor, selecione uma categoria na tabela primeiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tb_nomeProduto.Text.Trim()))
            {
                MessageBox.Show("O Nome do Produto não pode ficar vazio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(string.IsNullOrEmpty(TB_precoProduto.Text.Trim()))
            {
                MessageBox.Show("O preco Produto não pode ficar vazio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(TB_codigo.Text.Trim()))
            {
                MessageBox.Show("O codigo Produto não pode ficar vazio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Usa a variável diretamente na criação do objeto
              Produto produto = new Produto();
            

                produto.Id_produto = idProdutoSelecionadao;
                produto.Nome_produto = tb_categoria.Text.Trim();
            

            try
            {
                //categoriaDAO.Atualizar(categoriaAtualizada);

                MessageBox.Show("Categoria atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpa a caixa de texto e RESETA a variável para 0
                tb_categoria.Clear();
                idCategoriaSelecionada = 0;

                CarregarCategoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    } // Fim da classe
}
