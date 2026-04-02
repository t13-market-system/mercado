namespace SistemaLogin
{
    partial class F_Cadastro_Funcionario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            txtNome = new TextBox();
            txtEmail = new TextBox();
            txtTelefone = new TextBox();
            txtCPF = new TextBox();
            label11 = new Label();
            txtPais = new TextBox();
            txtEstado = new TextBox();
            txtCidade = new TextBox();
            txtBairro = new TextBox();
            txtRua = new TextBox();
            txtNumero = new TextBox();
            btnCadastrar = new Button();
            label12 = new Label();
            txtComplemento = new TextBox();
            label13 = new Label();
            cbcCargos = new ComboBox();
            lbl_cep = new Label();
            txt_cep = new TextBox();
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            btn_deletar = new Button();
            btn_atualizar = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Humnst777 Blk BT", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Sienna;
            label1.Location = new Point(129, 9);
            label1.Name = "label1";
            label1.Size = new Size(280, 30);
            label1.TabIndex = 0;
            label1.Text = "Cadastro Funcionário";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Sienna;
            label2.Location = new Point(12, 67);
            label2.Name = "label2";
            label2.Size = new Size(69, 21);
            label2.TabIndex = 1;
            label2.Text = "Nome : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Sienna;
            label3.Location = new Point(8, 117);
            label3.Name = "label3";
            label3.Size = new Size(65, 21);
            label3.TabIndex = 2;
            label3.Text = "Email : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Sienna;
            label4.Location = new Point(8, 167);
            label4.Name = "label4";
            label4.Size = new Size(88, 21);
            label4.TabIndex = 3;
            label4.Text = "Telefone : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Sienna;
            label5.Location = new Point(8, 217);
            label5.Name = "label5";
            label5.Size = new Size(50, 21);
            label5.TabIndex = 4;
            label5.Text = "CPF : ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Sienna;
            label6.Location = new Point(12, 299);
            label6.Name = "label6";
            label6.Size = new Size(53, 21);
            label6.TabIndex = 5;
            label6.Text = "País : ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Sienna;
            label7.Location = new Point(5, 349);
            label7.Name = "label7";
            label7.Size = new Size(73, 21);
            label7.TabIndex = 6;
            label7.Text = "Estado : ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Sienna;
            label8.Location = new Point(6, 399);
            label8.Name = "label8";
            label8.Size = new Size(75, 21);
            label8.TabIndex = 7;
            label8.Text = "Cidade : ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Sienna;
            label9.Location = new Point(5, 449);
            label9.Name = "label9";
            label9.Size = new Size(68, 21);
            label9.TabIndex = 8;
            label9.Text = "Bairro : ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Sienna;
            label10.Location = new Point(279, 299);
            label10.Name = "label10";
            label10.Size = new Size(51, 21);
            label10.TabIndex = 9;
            label10.Text = "Rua : ";
            label10.Click += label10_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(8, 91);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Digite seu nome";
            txtNome.Size = new Size(269, 23);
            txtNome.TabIndex = 10;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(8, 141);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Digite seu email";
            txtEmail.Size = new Size(269, 23);
            txtEmail.TabIndex = 11;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(8, 191);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.PlaceholderText = "Digite seu telefone";
            txtTelefone.Size = new Size(185, 23);
            txtTelefone.TabIndex = 12;
            // 
            // txtCPF
            // 
            txtCPF.Location = new Point(8, 241);
            txtCPF.Name = "txtCPF";
            txtCPF.PlaceholderText = "Digite seu CPF";
            txtCPF.Size = new Size(185, 23);
            txtCPF.TabIndex = 13;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Sienna;
            label11.Location = new Point(278, 399);
            label11.Name = "label11";
            label11.Size = new Size(85, 21);
            label11.TabIndex = 14;
            label11.Text = "Número : ";
            // 
            // txtPais
            // 
            txtPais.Location = new Point(8, 323);
            txtPais.Name = "txtPais";
            txtPais.Size = new Size(225, 23);
            txtPais.TabIndex = 15;
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(8, 373);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(84, 23);
            txtEstado.TabIndex = 16;
            // 
            // txtCidade
            // 
            txtCidade.Location = new Point(5, 423);
            txtCidade.Name = "txtCidade";
            txtCidade.Size = new Size(211, 23);
            txtCidade.TabIndex = 17;
            txtCidade.TextChanged += txtCidade_TextChanged;
            // 
            // txtBairro
            // 
            txtBairro.Location = new Point(5, 473);
            txtBairro.Name = "txtBairro";
            txtBairro.Size = new Size(207, 23);
            txtBairro.TabIndex = 18;
            // 
            // txtRua
            // 
            txtRua.Location = new Point(277, 423);
            txtRua.Name = "txtRua";
            txtRua.Size = new Size(225, 23);
            txtRua.TabIndex = 19;
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(279, 323);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(223, 23);
            txtNumero.TabIndex = 20;
            // 
            // btnCadastrar
            // 
            btnCadastrar.BackColor = Color.Green;
            btnCadastrar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCadastrar.ForeColor = SystemColors.ActiveCaptionText;
            btnCadastrar.Location = new Point(994, 502);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(105, 39);
            btnCadastrar.TabIndex = 21;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = false;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Sienna;
            label12.Location = new Point(278, 449);
            label12.Name = "label12";
            label12.Size = new Size(131, 21);
            label12.TabIndex = 22;
            label12.Text = "Complemento : ";
            // 
            // txtComplemento
            // 
            txtComplemento.Location = new Point(278, 479);
            txtComplemento.Name = "txtComplemento";
            txtComplemento.Size = new Size(216, 23);
            txtComplemento.TabIndex = 23;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Sienna;
            label13.Location = new Point(325, 93);
            label13.Name = "label13";
            label13.Size = new Size(74, 21);
            label13.TabIndex = 25;
            label13.Text = "Cargos : ";
            // 
            // cbcCargos
            // 
            cbcCargos.FormattingEnabled = true;
            cbcCargos.Location = new Point(314, 119);
            cbcCargos.Name = "cbcCargos";
            cbcCargos.Size = new Size(157, 23);
            cbcCargos.TabIndex = 26;
            // 
            // lbl_cep
            // 
            lbl_cep.AutoSize = true;
            lbl_cep.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_cep.ForeColor = Color.Sienna;
            lbl_cep.Location = new Point(278, 349);
            lbl_cep.Name = "lbl_cep";
            lbl_cep.Size = new Size(55, 21);
            lbl_cep.TabIndex = 27;
            lbl_cep.Text = "CEP  : ";
            // 
            // txt_cep
            // 
            txt_cep.Location = new Point(279, 373);
            txt_cep.Name = "txt_cep";
            txt_cep.Size = new Size(156, 23);
            txt_cep.TabIndex = 28;
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(540, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(577, 493);
            panel1.TabIndex = 29;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(577, 493);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btn_deletar
            // 
            btn_deletar.BackColor = Color.Red;
            btn_deletar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_deletar.ForeColor = SystemColors.ActiveCaptionText;
            btn_deletar.Location = new Point(830, 502);
            btn_deletar.Name = "btn_deletar";
            btn_deletar.Size = new Size(105, 39);
            btn_deletar.TabIndex = 30;
            btn_deletar.Text = "Deletar";
            btn_deletar.UseVisualStyleBackColor = false;
            btn_deletar.Click += btn_deletar_Click;
            // 
            // btn_atualizar
            // 
            btn_atualizar.BackColor = Color.Yellow;
            btn_atualizar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_atualizar.ForeColor = SystemColors.ActiveCaptionText;
            btn_atualizar.Location = new Point(678, 502);
            btn_atualizar.Name = "btn_atualizar";
            btn_atualizar.Size = new Size(105, 39);
            btn_atualizar.TabIndex = 31;
            btn_atualizar.Text = "Atualizar";
            btn_atualizar.UseVisualStyleBackColor = false;
            btn_atualizar.Click += btn_atualizar_Click;
            // 
            // F_Cadastro_Funcionario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(1120, 541);
            Controls.Add(btn_atualizar);
            Controls.Add(btn_deletar);
            Controls.Add(panel1);
            Controls.Add(txt_cep);
            Controls.Add(lbl_cep);
            Controls.Add(cbcCargos);
            Controls.Add(label13);
            Controls.Add(txtComplemento);
            Controls.Add(label12);
            Controls.Add(btnCadastrar);
            Controls.Add(txtNumero);
            Controls.Add(txtRua);
            Controls.Add(txtBairro);
            Controls.Add(txtCidade);
            Controls.Add(txtEstado);
            Controls.Add(txtPais);
            Controls.Add(label11);
            Controls.Add(txtCPF);
            Controls.Add(txtTelefone);
            Controls.Add(txtEmail);
            Controls.Add(txtNome);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "F_Cadastro_Funcionario";
            Text = "F_Cadastro_Funcionario";
            Load += F_Cadastro_Funcionario_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox txtNome;
        private TextBox txtEmail;
        private TextBox txtTelefone;
        private TextBox txtCPF;
        private Label label11;
        private TextBox txtPais;
        private TextBox txtEstado;
        private TextBox txtCidade;
        private TextBox txtBairro;
        private TextBox txtRua;
        private TextBox txtNumero;
        private Button btnCadastrar;
        private Label label12;
        private TextBox txtComplemento;
        private Label label13;
        private ComboBox cbcCargos;
        private Label lbl_cep;
        private TextBox txt_cep;
        private Panel panel1;
        private DataGridView dataGridView1;
        private Button btn_deletar;
        private Button btn_atualizar;
    }
}