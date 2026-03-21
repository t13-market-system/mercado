using System;
using System;
using System.Drawing;
using System.Net.Http.Headers;
using System.Windows.Forms;
using SistemaLogin.UI;

namespace SistemaLogin
{
    public partial class F_Cad_Fornecedor : Form
    {

        private PictureBox logo;

        private Panel pnlHeader;
        private Panel pnlToolbar;
        private Panel pnlBody;
        private Panel pnlFooter;

        private Button btnSalvar;
        private Button btnLimpar;
        private Button btnCancelar;

        private TextBox txtTelefoneFornecedor;
        private TextBox txtEmailFornecedor;

        private TextBox txtPaisFornecedor;
        private TextBox txtEstadoFornecedor;
        private TextBox txtCidadeFornecedor;
        private TextBox txtRuaFornecedor;
        private TextBox txtBairroFornecedor;
        private TextBox txtNumeroFornecedor;
        private TextBox txtCepFornecedor;

        public F_Cad_Fornecedor()
        {
            InitializeComponent();
            BuildLayout();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        private void BuildLayout()
        {
            Text = "Cadastro de Fornecedor - Market 100 Stress";
            Size = new Size(1024, 740);
            MinimumSize = new Size(900, 600);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = UI_Cad_Fornecedor.CorFundo;


            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = UI_Cad_Fornecedor.HeaderHeight,
                Padding = new Padding(UI_Cad_Fornecedor.Padding, 0, UI_Cad_Fornecedor.Padding, 0),
                BackColor = UI_Cad_Fornecedor.CorPrimaria
            };

            var lblTitulo = new Label
            {
                Text = "MARKET 100 STRESS - Cadastro de Fornecedor",
                AutoSize = true,
                Font = UI_Cad_Fornecedor.FontTitulo,
                ForeColor = Color.White,
                Location = new Point(UI_Cad_Fornecedor.Padding, 8)
            };

            var lblSubtitulo = new Label
            {
                Text = "Preencha as informações do novo fornecedor:",
                AutoSize = true,
                Font = UI_Cad_Fornecedor.FontSubtitulo,
                ForeColor = UI_Cad_Fornecedor.CorPrimariaClara,
                Location = new Point(UI_Cad_Fornecedor.Padding + 3, 50)
            };

            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblSubtitulo);


            pnlToolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = UI_Cad_Fornecedor.ToolbarHeight,
                BackColor = UI_Cad_Fornecedor.CorPrimariaClara,
                Padding = new Padding(16, 10, 16, 10)
            };

            btnSalvar = CriarBotao("✓ Salvar", 16, 10, UI_Cad_Fornecedor.CorSucesso);
            btnLimpar = CriarBotao("↻ Limpar", 128, 10, UI_Cad_Fornecedor.CorAviso);
            btnCancelar = CriarBotao("✕ Cancelar", 240, 10, UI_Cad_Fornecedor.CorDanger);

            pnlToolbar.Controls.Add(btnSalvar);
            pnlToolbar.Controls.Add(btnLimpar);
            pnlToolbar.Controls.Add(btnCancelar);


            pnlFooter = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = UI_Cad_Fornecedor.FooterHeight,
                BackColor = UI_Cad_Fornecedor.CorPrimaria,
                Padding = new Padding(UI_Cad_Fornecedor.Padding, 8, UI_Cad_Fornecedor.Padding, 8)
            };


            pnlBody = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = UI_Cad_Fornecedor.CorFundo,
                Padding = new Padding(UI_Cad_Fornecedor.Padding),
                AutoScroll = false // removido
            };

            //logo do mercado
            logo = new PictureBox
            {
                Size = new Size(260, 260),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
            };
            pnlBody.Controls.Add(logo);

            logo.Location = new Point(pnlBody.ClientSize.Width - logo.Width - 20, 70);

            var logoPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "UI",
                "100stressmart.png"
                );

            if (System.IO.File.Exists(logoPath))
            {
                using (var img = Image.FromFile(logoPath))
                {
                    logo.Image = new Bitmap(img);
                }
            }
            //else { MessageBox.Show("Imagem não encontrada"); }


            // manter na ordem certa
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlHeader);


            MontarCamposTabela();

            // click de salvar no bd
            //  += (s, e) é a mesma coisa de (object sender, EventArgs e)
            btnSalvar.Click += (s, e) =>
            {
                MessageBox.Show(
                    "UI tá ok. agora falta conexão com bd.",
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


            posY = AdicionarSecao(pnlBody, "CONTATO", posY);

            txtTelefoneFornecedor = AdicionarCampoTexto(pnlBody, "Telefone", 20, posY, 250);
            txtEmailFornecedor = AdicionarCampoTexto(pnlBody, "Email", 300, posY, 370);
            posY += UI_Cad_Fornecedor.EspacoCampo;


            posY = AdicionarSecao(pnlBody, "ENDEREÇO", posY + 30);

            txtPaisFornecedor = AdicionarCampoTexto(pnlBody, "País", 20, posY, 250);
            txtEstadoFornecedor = AdicionarCampoTexto(pnlBody, "Estado", 300, posY, 120);
            txtCidadeFornecedor = AdicionarCampoTexto(pnlBody, "Cidade", 450, posY, 220);
            posY += UI_Cad_Fornecedor.EspacoCampo;

            txtRuaFornecedor = AdicionarCampoTexto(pnlBody, "Rua", 20, posY, 400);
            txtBairroFornecedor = AdicionarCampoTexto(pnlBody, "Bairro", 450, posY, 220);
            posY += UI_Cad_Fornecedor.EspacoCampo;

            txtNumeroFornecedor = AdicionarCampoTexto(pnlBody, "Número", 20, posY, 120);
            txtCepFornecedor = AdicionarCampoTexto(pnlBody, "CEP", 170, posY, 150);
            posY += UI_Cad_Fornecedor.EspacoCampo;
        }

        // ===== helpers UI =====

        private int AdicionarSecao(Panel container, string titulo, int posY)
        {
            var lblSecao = new Label
            {
                Text = titulo,
                AutoSize = true,
                Font = UI_Cad_Fornecedor.FontSecao,
                ForeColor = UI_Cad_Fornecedor.CorPrimaria,
                Location = new Point(UI_Cad_Fornecedor.Padding, posY + 10)
            };

            var separador = new Panel
            {
                Location = new Point(UI_Cad_Fornecedor.Padding, posY + 32),
                Size = new Size(680, 2),
                BackColor = UI_Cad_Fornecedor.CorPrimariaClara
            };

            // adicionar no container
            container.Controls.Add(lblSecao);
            container.Controls.Add(separador);

            return posY + 40; // espaço depois do título + linha
        }

        private TextBox AdicionarCampoTexto(Panel container, string label, int x, int y, int largura)
        {
            var lbl = new Label
            {
                Text = label,
                AutoSize = true,
                Font = UI_Cad_Fornecedor.FontLabel,
                ForeColor = UI_Cad_Fornecedor.CorTexto,
                Location = new Point(x, y)
            };

            var txt = new TextBox
            {
                Location = new Point(x, y + 22),
                Size = new Size(largura, UI_Cad_Fornecedor.AlturaCampo),
                Font = UI_Cad_Fornecedor.FontCampo,
                BackColor = Color.White,
                ForeColor = UI_Cad_Fornecedor.CorTexto,
                BorderStyle = BorderStyle.FixedSingle
            };

            // adc no container
            container.Controls.Add(lbl);
            container.Controls.Add(txt);

            return txt;
        }

        private Button CriarBotao(string texto, int x, int y, Color corFundo) // cria os botões 
        {
            var btn = new Button
            {
                Text = texto,
                Location = new Point(x, y),
                Size = new Size(100, 35),
                BackColor = corFundo,
                ForeColor = Color.White,
                Font = UI_Cad_Fornecedor.FontBotao,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Dark(corFundo, 0.15f);
            btn.MouseLeave += (s, e) => btn.BackColor = corFundo;

            return btn;
        }

        private void LimparCampos() //limpa tudo
        {
            txtTelefoneFornecedor?.Clear();
            txtEmailFornecedor?.Clear();

            txtPaisFornecedor?.Clear();
            txtEstadoFornecedor?.Clear();
            txtCidadeFornecedor?.Clear();
            txtRuaFornecedor?.Clear();
            txtBairroFornecedor?.Clear();
            txtNumeroFornecedor?.Clear();
            txtCepFornecedor?.Clear();
        }
    }
}