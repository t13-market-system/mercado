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
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tb_senha = new TextBox();
            tb_usuario = new TextBox();
            button1 = new Button();
            label5 = new Label();
            tb_email = new TextBox();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(211, 9);
            label3.Name = "label3";
            label3.Size = new Size(99, 30);
            label3.TabIndex = 14;
            label3.Text = "Cadastro";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(17, 210);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 12;
            label2.Text = "Senha";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(17, 66);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 11;
            label1.Text = "Usuário";
            // 
            // tb_senha
            // 
            tb_senha.Location = new Point(17, 228);
            tb_senha.Name = "tb_senha";
            tb_senha.PasswordChar = '*';
            tb_senha.Size = new Size(530, 23);
            tb_senha.TabIndex = 3;
            // 
            // tb_usuario
            // 
            tb_usuario.Location = new Point(17, 84);
            tb_usuario.Name = "tb_usuario";
            tb_usuario.Size = new Size(530, 23);
            tb_usuario.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Highlight;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(12, 298);
            button1.Name = "button1";
            button1.Size = new Size(530, 39);
            button1.TabIndex = 8;
            button1.Text = "Cadastrar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(17, 132);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 17;
            label5.Text = "e-mail";
            // 
            // tb_email
            // 
            tb_email.Location = new Point(17, 150);
            tb_email.Name = "tb_email";
            tb_email.Size = new Size(530, 23);
            tb_email.TabIndex = 2;
            // 
            // F_Cadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(554, 350);
            Controls.Add(label5);
            Controls.Add(tb_email);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tb_senha);
            Controls.Add(tb_usuario);
            Controls.Add(button1);
            Name = "F_Cadastro";
            Text = "F_Cadastro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox tb_senha;
        private TextBox tb_usuario;
        private Button button1;
        private Label label5;
        private TextBox tb_email;
    }
}