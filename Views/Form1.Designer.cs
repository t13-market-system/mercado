namespace SistemaLogin
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_entrar = new Button();
            tb_usuario = new TextBox();
            label3 = new Label();
            label4 = new Label();
            linkLabel1 = new LinkLabel();
            tb_senha = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btn_entrar
            // 
            btn_entrar.BackColor = Color.DarkOrange;
            btn_entrar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_entrar.Location = new Point(99, 310);
            btn_entrar.Name = "btn_entrar";
            btn_entrar.Size = new Size(354, 44);
            btn_entrar.TabIndex = 3;
            btn_entrar.Text = "Entrar";
            btn_entrar.UseVisualStyleBackColor = false;
            btn_entrar.Click += button1_Click;
            // 
            // tb_usuario
            // 
            tb_usuario.Location = new Point(99, 206);
            tb_usuario.Name = "tb_usuario";
            tb_usuario.PlaceholderText = "Usuário";
            tb_usuario.Size = new Size(354, 23);
            tb_usuario.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Britannic Bold", 24F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Sienna;
            label3.Location = new Point(131, 115);
            label3.Name = "label3";
            label3.Size = new Size(301, 36);
            label3.TabIndex = 6;
            label3.Text = "Mercado 100 stress";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Sienna;
            label4.Location = new Point(214, 154);
            label4.Name = "label4";
            label4.Size = new Size(136, 15);
            label4.TabIndex = 7;
            label4.Text = "Autenticação do usuário";
            label4.Click += label4_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.FromArgb(255, 128, 0);
            linkLabel1.Location = new Point(244, 380);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(65, 15);
            linkLabel1.TabIndex = 8;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Criar conta";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // tb_senha
            // 
            tb_senha.BackColor = Color.White;
            tb_senha.Location = new Point(99, 262);
            tb_senha.Name = "tb_senha";
            tb_senha.PasswordChar = '*';
            tb_senha.PlaceholderText = "Senha";
            tb_senha.Size = new Size(354, 23);
            tb_senha.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Yellow_Orange_Illustration_Mart_;
            pictureBox1.Location = new Point(231, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(119, 100);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Form1
            // 
            AcceptButton = btn_entrar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(567, 430);
            Controls.Add(pictureBox1);
            Controls.Add(tb_senha);
            Controls.Add(linkLabel1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(tb_usuario);
            Controls.Add(btn_entrar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_entrar;
        private TextBox tb_usuario;
        private Label label3;
        private Label label4;
        private LinkLabel linkLabel1;
        private TextBox tb_senha;
        private PictureBox pictureBox1;
    }
}
