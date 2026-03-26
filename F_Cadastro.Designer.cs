namespace SistemaLogin
{
    partial class F_Cadastro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Cadastro));
            tb_senha = new TextBox();
            tb_usuario = new TextBox();
            button1 = new Button();
            tb_email = new TextBox();
            label4 = new Label();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tb_senha
            // 
            tb_senha.Location = new Point(87, 315);
            tb_senha.Name = "tb_senha";
            tb_senha.PasswordChar = '*';
            tb_senha.PlaceholderText = "Senha";
            tb_senha.Size = new Size(382, 23);
            tb_senha.TabIndex = 3;
            // 
            // tb_usuario
            // 
            tb_usuario.Location = new Point(87, 206);
            tb_usuario.Name = "tb_usuario";
            tb_usuario.PlaceholderText = "Usuário";
            tb_usuario.Size = new Size(382, 23);
            tb_usuario.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkOrange;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(82, 362);
            button1.Name = "button1";
            button1.Size = new Size(387, 42);
            button1.TabIndex = 8;
            button1.Text = "Cadastrar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // tb_email
            // 
            tb_email.Location = new Point(87, 261);
            tb_email.Name = "tb_email";
            tb_email.PlaceholderText = "Email";
            tb_email.Size = new Size(382, 23);
            tb_email.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Sienna;
            label4.Location = new Point(212, 151);
            label4.Name = "label4";
            label4.Size = new Size(113, 15);
            label4.TabIndex = 15;
            label4.Text = "Cadastro do usuário";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Britannic Bold", 24F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Sienna;
            label3.Location = new Point(116, 115);
            label3.Name = "label3";
            label3.Size = new Size(301, 36);
            label3.TabIndex = 16;
            label3.Text = "Mercado 100 stress";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(212, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(100, 100);
            pictureBox2.TabIndex = 17;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
          //  pictureBox1.Image = Properties.Resources.Yellow_Orange_Illustration_Mart_;
            pictureBox1.Location = new Point(-1, -26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(102, 83);
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // F_Cadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(554, 429);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(tb_email);
            Controls.Add(tb_senha);
            Controls.Add(tb_usuario);
            Controls.Add(button1);
            Name = "F_Cadastro";
            Text = "F_Cadastro";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox tb_senha;
        private TextBox tb_usuario;
        private Button button1;
        private TextBox tb_email;
        private Label label4;
        private Label label3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
    }
}