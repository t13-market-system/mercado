using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaLogin.UI;

namespace SistemaLogin
{
    public partial class F_VendasCadastro : Form
    {
        private PictureBox logo;

        private Panel pnlHeader;
        private Panel pnlToolbar;
        private Panel pnlBody;
        private Panel pnlFooter;

        private Button btnSalvar;
        private Button btnLimpar;
        private Button btnCancelar;

        
        private TextBox txtDataVenda;
        private TextBox txtIdPedido;
        private TextBox txtIdFormaPagamento;
        private ComboBox cmbIdFormaPagamento;

        
        private TextBox txtIdCliente;

        
        private TextBox txtIdProduto;
        private TextBox txtQuantidadeItem;
        private TextBox txtPrecoUnitario;

        public F_VendasCadastro()
        {
            InitializeComponent();
            BuildLayout();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        private void BuildLayout()
        {
            Text = "Cadastro de Vendas - Market 100 Stress";
            Size = new Size(1024, 740);
            MinimumSize = new Size(900, 600);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = UI_FornecedorCadastro.CorFundo;

           
            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = UI_FornecedorCadastro.HeaderHeight,
                Padding = new Padding(UI_FornecedorCadastro.Padding, 0, UI_FornecedorCadastro.Padding, 0),
                BackColor = UI_FornecedorCadastro.CorPrimaria
            };

            var lblTitulo = new Label
            {
                Text = "MARKET 100 STRESS - Cadastro de Vendas",
                AutoSize = true,
                Font = UI_FornecedorCadastro.FontTitulo,
                ForeColor = Color.White,
                Location = new Point(UI_FornecedorCadastro.Padding, 8)
            };

            var lblSubtitulo = new Label
            {
                Text = "Registre uma nova venda:",
                AutoSize = true,
                Font = UI_FornecedorCadastro.FontSubtitulo,
                ForeColor = UI_FornecedorCadastro.CorPrimariaClara,
                Location = new Point(UI_FornecedorCadastro.Padding + 3, 50)
            };

            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblSubtitulo);

           
            pnlToolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = UI_FornecedorCadastro.ToolbarHeight,
                BackColor = UI_FornecedorCadastro.CorPrimariaClara,
                Padding = new Padding(16, 10, 16, 10)
            };

            btnSalvar = CriarBotao("✓ Salvar", 16, 10, UI_FornecedorCadastro.CorSucesso);
            btnLimpar = CriarBotao("↻ Limpar", 128, 10, UI_FornecedorCadastro.CorAviso);
            btnCancelar = CriarBotao("✕ Cancelar", 240, 10, UI_FornecedorCadastro.CorDanger);

            pnlToolbar.Controls.Add(btnSalvar);
            pnlToolbar.Controls.Add(btnLimpar);
            pnlToolbar.Controls.Add(btnCancelar);

            
            pnlFooter = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = UI_FornecedorCadastro.FooterHeight,
                BackColor = UI_FornecedorCadastro.CorPrimaria,
                Padding = new Padding(UI_FornecedorCadastro.Padding, 8, UI_FornecedorCadastro.Padding, 8)
            };

           
            pnlBody = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = UI_FornecedorCadastro.CorFundo,
                Padding = new Padding(UI_FornecedorCadastro.Padding),
                AutoScroll = false
            };

       

           
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlHeader);

            
            MontarCamposTabela();

          
            btnSalvar.Click += (s, e) =>
            {
                MessageBox.Show(
                    "UI tá ok. Agora falta conexão com BD.",
                    "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            };

            btnLimpar.Click += (s, e) => LimparCampos();
            btnCancelar.Click += (s, e) => Close();
        }

        private void MontarCamposTabela()
        {
            int posY = 25;

            
            posY = AdicionarSecao(pnlBody, "VENDA", posY);

            txtDataVenda = AdicionarCampoTexto(pnlBody, "Data Venda (DateTime)", 20, posY, 300);

            cmbIdFormaPagamento = AdicionarComboBoxCampo(pnlBody, "Forma de Pagamento *", 350, posY, 200,
    new[] { "À Vista", "Débito", "Crédito", "Boleto", "PIX" });
            posY += UI_FornecedorCadastro.EspacoCampo;

            txtIdPedido = AdicionarCampoTexto(pnlBody, "Pedido *", 20, posY, 250);
            posY += UI_FornecedorCadastro.EspacoCampo;


            txtIdCliente = AdicionarCampoTexto(pnlBody, "Cliente *", 20, posY, 250);
            posY += UI_FornecedorCadastro.EspacoCampo;

            
            posY = AdicionarSecao(pnlBody, "ITEM DO PEDIDO", posY + 5);

            txtIdProduto = AdicionarCampoTexto(pnlBody, "Produto *", 20, posY, 250);
            txtQuantidadeItem = AdicionarCampoTexto(pnlBody, "Quantidade Item *", 300, posY, 200);
            posY += UI_FornecedorCadastro.EspacoCampo;

            txtPrecoUnitario = AdicionarCampoTexto(pnlBody, "Preço Unitario (decimal)", 20, posY, 250);
            posY += UI_FornecedorCadastro.EspacoCampo;
        }

        
        private int AdicionarSecao(Panel container, string titulo, int posY)
        {
            var lblSecao = new Label
            {
                Text = titulo,
                AutoSize = true,
                Font = UI_FornecedorCadastro.FontSecao,
                ForeColor = UI_FornecedorCadastro.CorPrimaria,
                Location = new Point(UI_FornecedorCadastro.Padding, posY + 10)
            };

            var separador = new Panel
            {
                Location = new Point(UI_FornecedorCadastro.Padding, posY + 32),
                Size = new Size(680, 2),
                BackColor = UI_FornecedorCadastro.CorPrimariaClara
            };

            container.Controls.Add(lblSecao);
            container.Controls.Add(separador);

            return posY + 40;
        }

        private TextBox AdicionarCampoTexto(Panel container, string label, int x, int y, int largura)
        {
            var lbl = new Label
            {
                Text = label,
                AutoSize = true,
                Font = UI_FornecedorCadastro.FontLabel,
                ForeColor = UI_FornecedorCadastro.CorTexto,
                Location = new Point(x, y)
            };

            var txt = new TextBox
            {
                Location = new Point(x, y + 22),
                Size = new Size(largura, UI_FornecedorCadastro.AlturaCampo),
                Font = UI_FornecedorCadastro.FontCampo,
                BackColor = Color.White,
                ForeColor = UI_FornecedorCadastro.CorTexto,
                BorderStyle = BorderStyle.FixedSingle
            };
 

            container.Controls.Add(lbl);
            container.Controls.Add(txt);
            

            return txt;
        }

        private ComboBox AdicionarComboBoxCampo(Panel container, string label, int x, int y, int largura, string[] itens)
        {
            var lbl = new Label
            {
                Text = label,
                AutoSize = true,
                Font = UI_FornecedorCadastro.FontLabel,
                ForeColor = UI_FornecedorCadastro.CorTexto,
                Location = new Point(x, y)
            };

            var cmb = new ComboBox
            {
                Location = new Point(x, y + 22),
                Size = new Size(largura, UI_FornecedorCadastro.AlturaCampo),
                Font = UI_FornecedorCadastro.FontCampo,
                BackColor = Color.White,
                ForeColor = UI_FornecedorCadastro.CorTexto,
                DropDownStyle = ComboBoxStyle.DropDownList,
            };

            cmb.Items.AddRange(itens);
            container.Controls.Add(lbl);
            container.Controls.Add(cmb);

            return cmb;
        }

        private Button CriarBotao(string texto, int x, int y, Color corFundo)
        {
            var btn = new Button
            {
                Text = texto,
                Location = new Point(x, y),
                Size = new Size(100, 35),
                BackColor = corFundo,
                ForeColor = Color.White,
                Font = UI_FornecedorCadastro.FontBotao,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Dark(corFundo, 0.15f);
            btn.MouseLeave += (s, e) => btn.BackColor = corFundo;

            return btn;
        }

        private void LimparCampos()
        {
            txtDataVenda?.Clear();
            txtIdPedido?.Clear();
            txtIdFormaPagamento?.Clear();

            cmbIdFormaPagamento.SelectedIndex = -1;

            txtIdCliente?.Clear();

            txtIdProduto?.Clear();
            txtQuantidadeItem?.Clear();
            txtPrecoUnitario?.Clear();
        }
    }
}