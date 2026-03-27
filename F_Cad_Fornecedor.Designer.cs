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
            pnlHeader = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            pnlToolbar = new Panel();
            btnSalvar = new Button();
            btnLimpar = new Button();
            btnCancelar = new Button();
            pnlFooter = new Panel();
            pnlBody = new Panel();
            textBox1 = new TextBox();
            cmbEstado = new ComboBox();
            pictureBox1 = new PictureBox();
            lblContatoSecao = new Label();
            sepContato = new Panel();
            lblNome = new Label();
            txtNome = new TextBox();
            lblCnpj = new Label();
            txtCnpj = new TextBox();
            lblTelefone = new Label();
            txtTelefone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblEnderecoSecao = new Label();
            sepEndereco = new Panel();
            lblPais = new Label();
            lblEstado = new Label();
            lblCidade = new Label();
            txtCidade = new TextBox();
            lblRua = new Label();
            txtRua = new TextBox();
            lblBairro = new Label();
            txtBairro = new TextBox();
            lblNumero = new Label();
            txtNumero = new TextBox();
            lblCep = new Label();
            txtCep = new TextBox();
            lblComplemento = new Label();
            txtComplemento = new TextBox();
            pnlHeader.SuspendLayout();
            pnlToolbar.SuspendLayout();
            pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
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
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.FromArgb(215, 185, 145);
            pnlToolbar.Controls.Add(btnSalvar);
            pnlToolbar.Controls.Add(btnLimpar);
            pnlToolbar.Controls.Add(btnCancelar);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 90);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Padding = new Padding(16, 10, 16, 10);
            pnlToolbar.Size = new Size(1024, 55);
            pnlToolbar.TabIndex = 2;
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
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(244, 67, 54);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(240, 10);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 35);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "✕ Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
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
            pnlBody.Controls.Add(textBox1);
            pnlBody.Controls.Add(cmbEstado);
            pnlBody.Controls.Add(pictureBox1);
            pnlBody.Controls.Add(lblContatoSecao);
            pnlBody.Controls.Add(sepContato);
            pnlBody.Controls.Add(lblNome);
            pnlBody.Controls.Add(txtNome);
            pnlBody.Controls.Add(lblCnpj);
            pnlBody.Controls.Add(txtCnpj);
            pnlBody.Controls.Add(lblTelefone);
            pnlBody.Controls.Add(txtTelefone);
            pnlBody.Controls.Add(lblEmail);
            pnlBody.Controls.Add(txtEmail);
            pnlBody.Controls.Add(lblEnderecoSecao);
            pnlBody.Controls.Add(sepEndereco);
            pnlBody.Controls.Add(lblPais);
            pnlBody.Controls.Add(lblEstado);
            pnlBody.Controls.Add(lblCidade);
            pnlBody.Controls.Add(txtCidade);
            pnlBody.Controls.Add(lblRua);
            pnlBody.Controls.Add(txtRua);
            pnlBody.Controls.Add(lblBairro);
            pnlBody.Controls.Add(txtBairro);
            pnlBody.Controls.Add(lblNumero);
            pnlBody.Controls.Add(txtNumero);
            pnlBody.Controls.Add(lblCep);
            pnlBody.Controls.Add(txtCep);
            pnlBody.Controls.Add(lblComplemento);
            pnlBody.Controls.Add(txtComplemento);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 145);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(20);
            pnlBody.Size = new Size(1024, 466);
            pnlBody.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.ForeColor = Color.Black;
            textBox1.Location = new Point(20, 289);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(250, 23);
            textBox1.TabIndex = 31;
            textBox1.Text = "Brasil";
            // 
            // cmbEstado
            // 
            cmbEstado.ForeColor = Color.Black;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(299, 289);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(121, 23);
            cmbEstado.TabIndex = 29;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(743, 136);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(258, 204);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 28;
            pictureBox1.TabStop = false;
            // 
            // lblContatoSecao
            // 
            lblContatoSecao.AutoSize = true;
            lblContatoSecao.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblContatoSecao.ForeColor = Color.FromArgb(139, 101, 51);
            lblContatoSecao.Location = new Point(20, 25);
            lblContatoSecao.Name = "lblContatoSecao";
            lblContatoSecao.Size = new Size(83, 21);
            lblContatoSecao.TabIndex = 0;
            lblContatoSecao.Text = "CONTATO";
            // 
            // sepContato
            // 
            sepContato.BackColor = Color.FromArgb(215, 185, 145);
            sepContato.Location = new Point(20, 47);
            sepContato.Name = "sepContato";
            sepContato.Size = new Size(680, 2);
            sepContato.TabIndex = 1;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI", 9F);
            lblNome.ForeColor = Color.FromArgb(100, 80, 60);
            lblNome.Location = new Point(20, 75);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(72, 15);
            lblNome.TabIndex = 2;
            lblNome.Text = "Razão Social";
            // 
            // txtNome
            // 
            txtNome.BackColor = Color.White;
            txtNome.BorderStyle = BorderStyle.FixedSingle;
            txtNome.Font = new Font("Segoe UI", 10F);
            txtNome.ForeColor = Color.Black;
            txtNome.Location = new Point(20, 97);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(450, 25);
            txtNome.TabIndex = 3;
            // 
            // lblCnpj
            // 
            lblCnpj.AutoSize = true;
            lblCnpj.Font = new Font("Segoe UI", 9F);
            lblCnpj.ForeColor = Color.FromArgb(100, 80, 60);
            lblCnpj.Location = new Point(500, 75);
            lblCnpj.Name = "lblCnpj";
            lblCnpj.Size = new Size(34, 15);
            lblCnpj.TabIndex = 4;
            lblCnpj.Text = "CNPJ";
            // 
            // txtCnpj
            // 
            txtCnpj.BackColor = Color.White;
            txtCnpj.BorderStyle = BorderStyle.FixedSingle;
            txtCnpj.Font = new Font("Segoe UI", 10F);
            txtCnpj.ForeColor = Color.Black;
            txtCnpj.Location = new Point(500, 97);
            txtCnpj.Name = "txtCnpj";
            txtCnpj.Size = new Size(170, 25);
            txtCnpj.TabIndex = 5;
            // 
            // lblTelefone
            // 
            lblTelefone.AutoSize = true;
            lblTelefone.Font = new Font("Segoe UI", 9F);
            lblTelefone.ForeColor = Color.FromArgb(100, 80, 60);
            lblTelefone.Location = new Point(20, 135);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(51, 15);
            lblTelefone.TabIndex = 6;
            lblTelefone.Text = "Telefone";
            // 
            // txtTelefone
            // 
            txtTelefone.BackColor = Color.White;
            txtTelefone.BorderStyle = BorderStyle.FixedSingle;
            txtTelefone.Font = new Font("Segoe UI", 10F);
            txtTelefone.ForeColor = Color.Black;
            txtTelefone.Location = new Point(20, 157);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(250, 25);
            txtTelefone.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.ForeColor = Color.FromArgb(100, 80, 60);
            lblEmail.Location = new Point(300, 135);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(300, 157);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(370, 25);
            txtEmail.TabIndex = 9;
            // 
            // lblEnderecoSecao
            // 
            lblEnderecoSecao.AutoSize = true;
            lblEnderecoSecao.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEnderecoSecao.ForeColor = Color.FromArgb(139, 101, 51);
            lblEnderecoSecao.Location = new Point(20, 215);
            lblEnderecoSecao.Name = "lblEnderecoSecao";
            lblEnderecoSecao.Size = new Size(94, 21);
            lblEnderecoSecao.TabIndex = 10;
            lblEnderecoSecao.Text = "ENDEREÇO";
            // 
            // sepEndereco
            // 
            sepEndereco.BackColor = Color.FromArgb(215, 185, 145);
            sepEndereco.Location = new Point(20, 237);
            sepEndereco.Name = "sepEndereco";
            sepEndereco.Size = new Size(680, 2);
            sepEndereco.TabIndex = 11;
            // 
            // lblPais
            // 
            lblPais.AutoSize = true;
            lblPais.Font = new Font("Segoe UI", 9F);
            lblPais.ForeColor = Color.FromArgb(100, 80, 60);
            lblPais.Location = new Point(20, 265);
            lblPais.Name = "lblPais";
            lblPais.Size = new Size(28, 15);
            lblPais.TabIndex = 12;
            lblPais.Text = "País";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 9F);
            lblEstado.ForeColor = Color.FromArgb(100, 80, 60);
            lblEstado.Location = new Point(298, 265);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(42, 15);
            lblEstado.TabIndex = 14;
            lblEstado.Text = "Estado";
            // 
            // lblCidade
            // 
            lblCidade.AutoSize = true;
            lblCidade.Font = new Font("Segoe UI", 9F);
            lblCidade.ForeColor = Color.FromArgb(100, 80, 60);
            lblCidade.Location = new Point(450, 265);
            lblCidade.Name = "lblCidade";
            lblCidade.Size = new Size(44, 15);
            lblCidade.TabIndex = 16;
            lblCidade.Text = "Cidade";
            // 
            // txtCidade
            // 
            txtCidade.BackColor = Color.White;
            txtCidade.BorderStyle = BorderStyle.FixedSingle;
            txtCidade.Font = new Font("Segoe UI", 10F);
            txtCidade.ForeColor = Color.Black;
            txtCidade.Location = new Point(450, 287);
            txtCidade.Name = "txtCidade";
            txtCidade.Size = new Size(220, 25);
            txtCidade.TabIndex = 17;
            // 
            // lblRua
            // 
            lblRua.AutoSize = true;
            lblRua.Font = new Font("Segoe UI", 9F);
            lblRua.ForeColor = Color.FromArgb(100, 80, 60);
            lblRua.Location = new Point(20, 325);
            lblRua.Name = "lblRua";
            lblRua.Size = new Size(27, 15);
            lblRua.TabIndex = 18;
            lblRua.Text = "Rua";
            // 
            // txtRua
            // 
            txtRua.BackColor = Color.White;
            txtRua.BorderStyle = BorderStyle.FixedSingle;
            txtRua.Font = new Font("Segoe UI", 10F);
            txtRua.ForeColor = Color.Black;
            txtRua.Location = new Point(20, 347);
            txtRua.Name = "txtRua";
            txtRua.Size = new Size(400, 25);
            txtRua.TabIndex = 19;
            // 
            // lblBairro
            // 
            lblBairro.AutoSize = true;
            lblBairro.Font = new Font("Segoe UI", 9F);
            lblBairro.ForeColor = Color.FromArgb(100, 80, 60);
            lblBairro.Location = new Point(185, 385);
            lblBairro.Name = "lblBairro";
            lblBairro.Size = new Size(38, 15);
            lblBairro.TabIndex = 20;
            lblBairro.Text = "Bairro";
            // 
            // txtBairro
            // 
            txtBairro.BackColor = Color.White;
            txtBairro.BorderStyle = BorderStyle.FixedSingle;
            txtBairro.Font = new Font("Segoe UI", 10F);
            txtBairro.ForeColor = Color.Black;
            txtBairro.Location = new Point(185, 407);
            txtBairro.Name = "txtBairro";
            txtBairro.Size = new Size(235, 25);
            txtBairro.TabIndex = 21;
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Font = new Font("Segoe UI", 9F);
            lblNumero.ForeColor = Color.FromArgb(100, 80, 60);
            lblNumero.Location = new Point(20, 385);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(51, 15);
            lblNumero.TabIndex = 22;
            lblNumero.Text = "Número";
            // 
            // txtNumero
            // 
            txtNumero.BackColor = Color.White;
            txtNumero.BorderStyle = BorderStyle.FixedSingle;
            txtNumero.Font = new Font("Segoe UI", 10F);
            txtNumero.ForeColor = Color.Black;
            txtNumero.Location = new Point(20, 407);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(120, 25);
            txtNumero.TabIndex = 23;
            // 
            // lblCep
            // 
            lblCep.AutoSize = true;
            lblCep.Font = new Font("Segoe UI", 9F);
            lblCep.ForeColor = Color.FromArgb(100, 80, 60);
            lblCep.Location = new Point(450, 325);
            lblCep.Name = "lblCep";
            lblCep.Size = new Size(28, 15);
            lblCep.TabIndex = 24;
            lblCep.Text = "CEP";
            // 
            // txtCep
            // 
            txtCep.BackColor = Color.White;
            txtCep.BorderStyle = BorderStyle.FixedSingle;
            txtCep.Font = new Font("Segoe UI", 10F);
            txtCep.ForeColor = Color.Black;
            txtCep.Location = new Point(450, 347);
            txtCep.Name = "txtCep";
            txtCep.Size = new Size(220, 25);
            txtCep.TabIndex = 25;
            // 
            // lblComplemento
            // 
            lblComplemento.AutoSize = true;
            lblComplemento.Font = new Font("Segoe UI", 9F);
            lblComplemento.ForeColor = Color.FromArgb(100, 80, 60);
            lblComplemento.Location = new Point(450, 385);
            lblComplemento.Name = "lblComplemento";
            lblComplemento.Size = new Size(84, 15);
            lblComplemento.TabIndex = 26;
            lblComplemento.Text = "Complemento";
            // 
            // txtComplemento
            // 
            txtComplemento.BackColor = Color.White;
            txtComplemento.BorderStyle = BorderStyle.FixedSingle;
            txtComplemento.Font = new Font("Segoe UI", 10F);
            txtComplemento.ForeColor = Color.Black;
            txtComplemento.Location = new Point(450, 407);
            txtComplemento.Name = "txtComplemento";
            txtComplemento.Size = new Size(220, 25);
            txtComplemento.TabIndex = 27;
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
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlToolbar.ResumeLayout(false);
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Panel pnlToolbar;
        private Button btnSalvar;
        private Button btnLimpar;
        private Button btnCancelar;
        private Panel pnlFooter;
        private Panel pnlBody;
        private PictureBox pictureBox1;
        private Label lblContatoSecao;
        private Panel sepContato;
        private Label lblNome;
        private TextBox txtNome;
        private Label lblCnpj;
        private TextBox txtCnpj;
        private Label lblTelefone;
        private TextBox txtTelefone;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblEnderecoSecao;
        private Panel sepEndereco;
        private Label lblPais;
        private Label lblEstado;
        private Label lblCidade;
        private TextBox txtCidade;
        private Label lblRua;
        private TextBox txtRua;
        private Label lblBairro;
        private TextBox txtBairro;
        private Label lblNumero;
        private TextBox txtNumero;
        private Label lblCep;
        private TextBox txtCep;
        private Label lblComplemento;
        private TextBox txtComplemento;
        private ComboBox cmbEstado;
        private TextBox textBox1;
    }
}