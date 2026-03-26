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
            F_cad_produtos f_cad_produtos = new F_cad_produtos();  
            f_cad_produtos.ShowDialog();

        }
    } // Fim da classe
}
