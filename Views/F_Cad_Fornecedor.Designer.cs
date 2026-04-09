namespace SistemaLogin
{
    partial class F_Cad_Fornecedor
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Cad_Fornecedor));
            pnlFooter = new Panel();
            pnlBody = new Panel();
            tabGuias = new TabControl();
            tabInfo = new TabPage();
            txtTelefone = new MaskedTextBox();
            txtCnpj = new MaskedTextBox();
            txtPais = new TextBox();
            cmbEstado = new ComboBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            panel2 = new Panel();
            label2 = new Label();
            txtNome = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtEmail = new TextBox();
            label6 = new Label();
            panel3 = new Panel();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            txtCidade = new TextBox();
            label10 = new Label();
            textBox7 = new TextBox();
            label11 = new Label();
            txtBairro = new TextBox();
            label12 = new Label();
            txtNumero = new TextBox();
            label13 = new Label();
            txtCep = new TextBox();
            label14 = new Label();
            txtComplemento = new TextBox();
            tabGerenciar = new TabPage();
            dgvFornecedor = new DataGridView();
            btnDeletar = new Button();
            btnLimpar = new Button();
            btnSalvar = new Button();
            pnlToolbar = new Panel();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            pnlHeader = new Panel();
            pnlBody.SuspendLayout();
            tabGuias.SuspendLayout();
            tabInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            tabGerenciar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFornecedor).BeginInit();
            pnlToolbar.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(139, 101, 51);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 611);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Padding = new Padding(20, 8, 20, 8);
            pnlFooter.Size = new Size(1024, 40);
            pnlFooter.TabIndex = 1;
            // 
            // pnlBody
            // 
            pnlBody.AutoScroll = true;
            pnlBody.BackColor = Color.FromArgb(245, 235, 220);
            pnlBody.Controls.Add(tabGuias);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 145);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(20);
            pnlBody.Size = new Size(1024, 466);
            pnlBody.TabIndex = 0;
            // 
            // tabGuias
            // 
            tabGuias.Controls.Add(tabInfo);
            tabGuias.Controls.Add(tabGerenciar);
            tabGuias.Dock = DockStyle.Fill;
            tabGuias.Location = new Point(20, 20);
            tabGuias.Name = "tabGuias";
            tabGuias.SelectedIndex = 0;
            tabGuias.Size = new Size(984, 426);
            tabGuias.TabIndex = 32;
            // 
            // tabInfo
            // 
            tabInfo.BackColor = Color.FromArgb(245, 235, 220);
            tabInfo.Controls.Add(txtTelefone);
            tabInfo.Controls.Add(txtCnpj);
            tabInfo.Controls.Add(txtPais);
            tabInfo.Controls.Add(cmbEstado);
            tabInfo.Controls.Add(pictureBox2);
            tabInfo.Controls.Add(label1);
            tabInfo.Controls.Add(panel2);
            tabInfo.Controls.Add(label2);
            tabInfo.Controls.Add(txtNome);
            tabInfo.Controls.Add(label3);
            tabInfo.Controls.Add(label4);
            tabInfo.Controls.Add(label5);
            tabInfo.Controls.Add(txtEmail);
            tabInfo.Controls.Add(label6);
            tabInfo.Controls.Add(panel3);
            tabInfo.Controls.Add(label7);
            tabInfo.Controls.Add(label8);
            tabInfo.Controls.Add(label9);
            tabInfo.Controls.Add(txtCidade);
            tabInfo.Controls.Add(label10);
            tabInfo.Controls.Add(textBox7);
            tabInfo.Controls.Add(label11);
            tabInfo.Controls.Add(txtBairro);
            tabInfo.Controls.Add(label12);
            tabInfo.Controls.Add(txtNumero);
            tabInfo.Controls.Add(label13);
            tabInfo.Controls.Add(txtCep);
            tabInfo.Controls.Add(label14);
            tabInfo.Controls.Add(txtComplemento);
            tabInfo.Location = new Point(4, 24);
            tabInfo.Name = "tabInfo";
            tabInfo.Padding = new Padding(3);
            tabInfo.Size = new Size(976, 398);
            tabInfo.TabIndex = 0;
            tabInfo.Text = "Informações";
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(23, 123);
            txtTelefone.Mask = "(99) 00000-0000";
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(250, 23);
            txtTelefone.TabIndex = 62;
            // 
            // txtCnpj
            // 
            txtCnpj.Culture = new System.Globalization.CultureInfo("en-001");
            txtCnpj.Location = new Point(502, 64);
            txtCnpj.Mask = "00.000.000/0000-00";
            txtCnpj.Name = "txtCnpj";
            txtCnpj.Size = new Size(171, 23);
            txtCnpj.TabIndex = 61;
            // 
            // txtPais
            // 
            txtPais.ForeColor = Color.Black;
            txtPais.Location = new Point(23, 238);
            txtPais.Name = "txtPais";
            txtPais.ReadOnly = true;
            txtPais.Size = new Size(250, 23);
            txtPais.TabIndex = 60;
            txtPais.Text = "Brasil";
            // 
            // cmbEstado
            // 
            cmbEstado.ForeColor = Color.Black;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(302, 238);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(121, 23);
            cmbEstado.TabIndex = 59;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(709, 85);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(258, 204);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 58;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(139, 101, 51);
            label1.Location = new Point(23, 3);
            label1.Name = "label1";
            label1.Size = new Size(83, 21);
            label1.TabIndex = 32;
            label1.Text = "CONTATO";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(215, 185, 145);
            panel2.Location = new Point(23, 25);
            panel2.Name = "panel2";
            panel2.Size = new Size(680, 2);
            panel2.TabIndex = 33;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.ForeColor = Color.FromArgb(100, 80, 60);
            label2.Location = new Point(23, 40);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 34;
            label2.Text = "Razão Social";
            // 
            // txtNome
            // 
            txtNome.BackColor = Color.White;
            txtNome.BorderStyle = BorderStyle.FixedSingle;
            txtNome.Font = new Font("Segoe UI", 10F);
            txtNome.ForeColor = Color.Black;
            txtNome.Location = new Point(23, 62);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(450, 25);
            txtNome.TabIndex = 35;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.ForeColor = Color.FromArgb(100, 80, 60);
            label3.Location = new Point(503, 40);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 36;
            label3.Text = "CNPJ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.ForeColor = Color.FromArgb(100, 80, 60);
            label4.Location = new Point(23, 100);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 38;
            label4.Text = "Telefone";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F);
            label5.ForeColor = Color.FromArgb(100, 80, 60);
            label5.Location = new Point(303, 100);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 40;
            label5.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(303, 122);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(370, 25);
            txtEmail.TabIndex = 41;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(139, 101, 51);
            label6.Location = new Point(23, 164);
            label6.Name = "label6";
            label6.Size = new Size(94, 21);
            label6.TabIndex = 42;
            label6.Text = "ENDEREÇO";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(215, 185, 145);
            panel3.Location = new Point(23, 186);
            panel3.Name = "panel3";
            panel3.Size = new Size(680, 2);
            panel3.TabIndex = 43;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F);
            label7.ForeColor = Color.FromArgb(100, 80, 60);
            label7.Location = new Point(23, 214);
            label7.Name = "label7";
            label7.Size = new Size(28, 15);
            label7.TabIndex = 44;
            label7.Text = "País";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F);
            label8.ForeColor = Color.FromArgb(100, 80, 60);
            label8.Location = new Point(301, 214);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 45;
            label8.Text = "Estado";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F);
            label9.ForeColor = Color.FromArgb(100, 80, 60);
            label9.Location = new Point(453, 214);
            label9.Name = "label9";
            label9.Size = new Size(44, 15);
            label9.TabIndex = 46;
            label9.Text = "Cidade";
            // 
            // txtCidade
            // 
            txtCidade.BackColor = Color.White;
            txtCidade.BorderStyle = BorderStyle.FixedSingle;
            txtCidade.Font = new Font("Segoe UI", 10F);
            txtCidade.ForeColor = Color.Black;
            txtCidade.Location = new Point(453, 236);
            txtCidade.Name = "txtCidade";
            txtCidade.Size = new Size(220, 25);
            txtCidade.TabIndex = 47;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F);
            label10.ForeColor = Color.FromArgb(100, 80, 60);
            label10.Location = new Point(23, 274);
            label10.Name = "label10";
            label10.Size = new Size(27, 15);
            label10.TabIndex = 48;
            label10.Text = "Rua";
            // 
            // textBox7
            // 
            textBox7.BackColor = Color.White;
            textBox7.BorderStyle = BorderStyle.FixedSingle;
            textBox7.Font = new Font("Segoe UI", 10F);
            textBox7.ForeColor = Color.Black;
            textBox7.Location = new Point(23, 296);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(400, 25);
            textBox7.TabIndex = 49;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F);
            label11.ForeColor = Color.FromArgb(100, 80, 60);
            label11.Location = new Point(188, 334);
            label11.Name = "label11";
            label11.Size = new Size(38, 15);
            label11.TabIndex = 50;
            label11.Text = "Bairro";
            // 
            // txtBairro
            // 
            txtBairro.BackColor = Color.White;
            txtBairro.BorderStyle = BorderStyle.FixedSingle;
            txtBairro.Font = new Font("Segoe UI", 10F);
            txtBairro.ForeColor = Color.Black;
            txtBairro.Location = new Point(188, 356);
            txtBairro.Name = "txtBairro";
            txtBairro.Size = new Size(235, 25);
            txtBairro.TabIndex = 51;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F);
            label12.ForeColor = Color.FromArgb(100, 80, 60);
            label12.Location = new Point(23, 334);
            label12.Name = "label12";
            label12.Size = new Size(51, 15);
            label12.TabIndex = 52;
            label12.Text = "Número";
            // 
            // txtNumero
            // 
            txtNumero.BackColor = Color.White;
            txtNumero.BorderStyle = BorderStyle.FixedSingle;
            txtNumero.Font = new Font("Segoe UI", 10F);
            txtNumero.ForeColor = Color.Black;
            txtNumero.Location = new Point(23, 356);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(120, 25);
            txtNumero.TabIndex = 53;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F);
            label13.ForeColor = Color.FromArgb(100, 80, 60);
            label13.Location = new Point(453, 274);
            label13.Name = "label13";
            label13.Size = new Size(28, 15);
            label13.TabIndex = 54;
            label13.Text = "CEP";
            // 
            // txtCep
            // 
            txtCep.BackColor = Color.White;
            txtCep.BorderStyle = BorderStyle.FixedSingle;
            txtCep.Font = new Font("Segoe UI", 10F);
            txtCep.ForeColor = Color.Black;
            txtCep.Location = new Point(453, 296);
            txtCep.Name = "txtCep";
            txtCep.Size = new Size(220, 25);
            txtCep.TabIndex = 55;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F);
            label14.ForeColor = Color.FromArgb(100, 80, 60);
            label14.Location = new Point(453, 334);
            label14.Name = "label14";
            label14.Size = new Size(84, 15);
            label14.TabIndex = 56;
            label14.Text = "Complemento";
            // 
            // txtComplemento
            // 
            txtComplemento.BackColor = Color.White;
            txtComplemento.BorderStyle = BorderStyle.FixedSingle;
            txtComplemento.Font = new Font("Segoe UI", 10F);
            txtComplemento.ForeColor = Color.Black;
            txtComplemento.Location = new Point(453, 356);
            txtComplemento.Name = "txtComplemento";
            txtComplemento.Size = new Size(220, 25);
            txtComplemento.TabIndex = 57;
            // 
            // tabGerenciar
            // 
            tabGerenciar.Controls.Add(dgvFornecedor);
            tabGerenciar.Location = new Point(4, 24);
            tabGerenciar.Name = "tabGerenciar";
            tabGerenciar.Padding = new Padding(3);
            tabGerenciar.Size = new Size(976, 398);
            tabGerenciar.TabIndex = 1;
            tabGerenciar.Text = "Gerenciar";
            tabGerenciar.UseVisualStyleBackColor = true;
            // 
            // dgvFornecedor
            // 
            dgvFornecedor.BackgroundColor = Color.FromArgb(245, 235, 220);
            dgvFornecedor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFornecedor.Dock = DockStyle.Fill;
            dgvFornecedor.Location = new Point(3, 3);
            dgvFornecedor.Name = "dgvFornecedor";
            dgvFornecedor.Size = new Size(970, 392);
            dgvFornecedor.TabIndex = 0;
            // 
            // btnDeletar
            // 
            btnDeletar.BackColor = Color.FromArgb(244, 67, 54);
            btnDeletar.Cursor = Cursors.Hand;
            btnDeletar.FlatStyle = FlatStyle.Flat;
            btnDeletar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeletar.ForeColor = Color.White;
            btnDeletar.Location = new Point(240, 10);
            btnDeletar.Name = "btnDeletar";
            btnDeletar.Size = new Size(100, 35);
            btnDeletar.TabIndex = 2;
            btnDeletar.Text = "✕ Deletar";
            btnDeletar.UseVisualStyleBackColor = false;
            // 
            // btnLimpar
            // 
            btnLimpar.BackColor = Color.FromArgb(255, 152, 0);
            btnLimpar.Cursor = Cursors.Hand;
            btnLimpar.FlatStyle = FlatStyle.Flat;
            btnLimpar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLimpar.ForeColor = Color.White;
            btnLimpar.Location = new Point(128, 10);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(100, 35);
            btnLimpar.TabIndex = 1;
            btnLimpar.Text = "↻ Limpar";
            btnLimpar.UseVisualStyleBackColor = false;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = Color.FromArgb(76, 175, 80);
            btnSalvar.Cursor = Cursors.Hand;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.Location = new Point(16, 10);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(100, 35);
            btnSalvar.TabIndex = 0;
            btnSalvar.Text = "✓ Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.FromArgb(215, 185, 145);
            pnlToolbar.Controls.Add(btnSalvar);
            pnlToolbar.Controls.Add(btnLimpar);
            pnlToolbar.Controls.Add(btnDeletar);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 90);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Padding = new Padding(16, 10, 16, 10);
            pnlToolbar.Size = new Size(1024, 55);
            pnlToolbar.TabIndex = 2;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 10F);
            lblSubtitulo.ForeColor = Color.FromArgb(215, 185, 145);
            lblSubtitulo.Location = new Point(23, 50);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(288, 19);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Preencha as informações do novo fornecedor:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(497, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "MARKET 100 STRESS - Cadastro de Fornecedor";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(139, 101, 51);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(20, 0, 20, 0);
            pnlHeader.Size = new Size(1024, 90);
            pnlHeader.TabIndex = 3;
            // 
            // F_Cad_Fornecedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 235, 220);
            ClientSize = new Size(1024, 651);
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlHeader);
            ForeColor = Color.Black;
            MinimumSize = new Size(900, 600);
            Name = "F_Cad_Fornecedor";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Fornecedor - Market 100 Stress";
            pnlBody.ResumeLayout(false);
            tabGuias.ResumeLayout(false);
            tabInfo.ResumeLayout(false);
            tabInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            tabGerenciar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFornecedor).EndInit();
            pnlToolbar.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlFooter;
        private Panel pnlBody;
        private Button btnDeletar;
        private Button btnLimpar;
        private Button btnSalvar;
        private Panel pnlToolbar;
        private Label lblSubtitulo;
        private Label lblTitulo;
        private Panel pnlHeader;
        private TabControl tabGuias;
        private TabPage tabInfo;
        private TextBox txtPais;
        private ComboBox cmbEstado;
        private PictureBox pictureBox2;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private TextBox txtNome;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtEmail;
        private Label label6;
        private Panel panel3;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox txtCidade;
        private Label label10;
        private TextBox textBox7;
        private Label label11;
        private TextBox txtBairro;
        private Label label12;
        private TextBox txtNumero;
        private Label label13;
        private TextBox txtCep;
        private Label label14;
        private TextBox txtComplemento;
        private TabPage tabGerenciar;
        private DataGridView dgvFornecedor;
        private MaskedTextBox txtTelefone;
        private MaskedTextBox txtCnpj;
    }
}