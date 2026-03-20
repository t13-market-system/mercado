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
    public partial class Tela_de_Vendas : Form
    {
        public Tela_de_Vendas()
        {
            InitializeComponent();
        }

        private void Tela_de_Vendas_Load(object sender, EventArgs e)
        {
            {
                // ── Aparência geral ──────────────────────────────────────
                listView1.View = View.Tile;
                listView1.TileSize = new Size(190, 60);
                listView1.BackColor = Color.PeachPuff;
                listView1.ForeColor = Color.FromArgb(59, 26, 8);
                listView1.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);

                // ── Necessário para o Tile mostrar subitens ──────────────
                // Adiciona colunas (não aparecem visualmente no Tile,
                // mas são obrigatórias para os SubItems funcionarem)
                listView1.Columns.Add("Nome", 190);
                listView1.Columns.Add("Preco", 190);

                // ── Lista de produtos de teste ───────────────────────────
                var produtos = new[]
                {
        new { Nome = "🍎 Maçã Gala",          Preco = "R$ 4,99"  },
        new { Nome = "🍌 Banana Prata",        Preco = "R$ 3,49"  },
        new { Nome = "🥛 Leite Integral",      Preco = "R$ 5,79"  },
        new { Nome = "🍶 Iogurte Natural",     Preco = "R$ 3,89"  },
        new { Nome = "🍞 Pão de Forma",        Preco = "R$ 8,49"  },
        new { Nome = "🥤 Coca-Cola 2L",        Preco = "R$ 9,99"  },
        new { Nome = "💧 Água Mineral",        Preco = "R$ 2,49"  },
        new { Nome = "🍗 Frango Inteiro",      Preco = "R$ 19,90" },
        new { Nome = "🥩 Picanha Bovina",      Preco = "R$ 69,90" },
        new { Nome = "🧼 Sabonete Dove",       Preco = "R$ 4,29"  },
        new { Nome = "🧴 Shampoo Elseve",      Preco = "R$ 18,90" },
        new { Nome = "🧹 Detergente Ypê",      Preco = "R$ 2,99"  },
        new { Nome = "🍨 Sorvete Napolitano",  Preco = "R$ 14,99" },
        new { Nome = "🍕 Pizza Margherita",    Preco = "R$ 22,90" },
        new { Nome = "🧀 Queijo Muçarela",     Preco = "R$ 39,90" },
        new { Nome = "☕ Café Torrado",        Preco = "R$ 11,99" },
    };

                // ── Popula o ListView ────────────────────────────────────
                foreach (var p in produtos)
                {
                    var item = new ListViewItem(p.Nome);
                    item.SubItems.Add(p.Preco);   // aparece na segunda linha do Tile
                    listView1.Items.Add(item);
                }
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            var item = listView1.SelectedItems[0];
            string nome = item.Text;
            string preco = item.SubItems[1].Text;
            lb_produtos.Items.Add($"{nome}  →  {preco}");

            MessageBox.Show(
                $"Produto selecionado:\n\n{nome}\n{preco}",
                "Produto",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btn_remover_Click(object sender, EventArgs e)
        {
            var index = lb_produtos.SelectedIndex;
            lb_produtos.Items.RemoveAt(index);
        }

        private void btn_remover_tudo_Click(object sender, EventArgs e)
        {
            lb_produtos.Items.Clear();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            
        }
    }
}
