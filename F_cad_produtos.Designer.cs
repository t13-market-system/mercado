namespace SistemaLogin
{
    partial class F_cad_produtos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_cad_produtos));
            tb_nomeProduto = new TextBox();
            BT_cadastro = new Button();
            label1 = new Label();
            label3 = new Label();
            CB_categoria = new ComboBox();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            CB_fornecedor = new ComboBox();
            label5 = new Label();
            TB_precoProduto = new TextBox();
            label6 = new Label();
            TB_codigo = new TextBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tb_nomeProduto
            // 
            tb_nomeProduto.Location = new Point(46, 114);
            tb_nomeProduto.Multiline = true;
            tb_nomeProduto.Name = "tb_nomeProduto";
            tb_nomeProduto.PlaceholderText = "Digite....";
            tb_nomeProduto.Size = new Size(372, 23);
            tb_nomeProduto.TabIndex = 0;
            // 
            // BT_cadastro
            // 
            BT_cadastro.BackColor = Color.Sienna;
            BT_cadastro.Location = new Point(278, 280);
            BT_cadastro.Name = "BT_cadastro";
            BT_cadastro.Size = new Size(302, 65);
            BT_cadastro.TabIndex = 1;
            BT_cadastro.Text = "Cadastrar";
            BT_cadastro.UseVisualStyleBackColor = false;
            BT_cadastro.Click += BT_cadastro_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Playbill", 60F);
            label1.ForeColor = Color.Peru;
            label1.Location = new Point(34, 9);
            label1.Name = "label1";
            label1.Size = new Size(367, 81);
            label1.TabIndex = 2;
            label1.Text = "Cadastro Produtos";
            label1.Click += label1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Swis721 Hv BT", 15F);
            label3.ForeColor = Color.Peru;
            label3.Location = new Point(46, 87);
            label3.Name = "label3";
            label3.Size = new Size(190, 24);
            label3.TabIndex = 4;
            label3.Text = "Nome Do Produto";
            // 
            // CB_categoria
            // 
            CB_categoria.FormattingEnabled = true;
            CB_categoria.Location = new Point(46, 220);
            CB_categoria.Name = "CB_categoria";
            CB_categoria.Size = new Size(372, 23);
            CB_categoria.TabIndex = 5;
            CB_categoria.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Swis721 Hv BT", 15F);
            label2.ForeColor = Color.Peru;
            label2.Location = new Point(46, 193);
            label2.Name = "label2";
            label2.Size = new Size(120, 24);
            label2.TabIndex = 6;
            label2.Text = "Categorias";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(385, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(277, 77);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Swis721 Hv BT", 15F);
            label4.ForeColor = Color.Peru;
            label4.Location = new Point(46, 140);
            label4.Name = "label4";
            label4.Size = new Size(126, 24);
            label4.TabIndex = 9;
            label4.Text = "Fornecedor";
            // 
            // CB_fornecedor
            // 
            CB_fornecedor.FormattingEnabled = true;
            CB_fornecedor.Location = new Point(46, 167);
            CB_fornecedor.Name = "CB_fornecedor";
            CB_fornecedor.Size = new Size(372, 23);
            CB_fornecedor.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Swis721 Hv BT", 15F);
            label5.ForeColor = Color.Peru;
            label5.Location = new Point(441, 164);
            label5.Name = "label5";
            label5.Size = new Size(188, 24);
            label5.TabIndex = 11;
            label5.Text = "Preço do Produto";
            label5.Click += label5_Click;
            // 
            // TB_precoProduto
            // 
            TB_precoProduto.Location = new Point(441, 191);
            TB_precoProduto.Multiline = true;
            TB_precoProduto.Name = "TB_precoProduto";
            TB_precoProduto.PlaceholderText = "Digite....";
            TB_precoProduto.Size = new Size(188, 23);
            TB_precoProduto.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Swis721 Hv BT", 15F);
            label6.ForeColor = Color.Peru;
            label6.Location = new Point(650, 164);
            label6.Name = "label6";
            label6.Size = new Size(83, 24);
            label6.TabIndex = 13;
            label6.Text = "Codigo";
            // 
            // TB_codigo
            // 
            TB_codigo.Location = new Point(650, 191);
            TB_codigo.Multiline = true;
            TB_codigo.Name = "TB_codigo";
            TB_codigo.PlaceholderText = "Digite....";
            TB_codigo.Size = new Size(163, 23);
            TB_codigo.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Swis721 Hv BT", 15F);
            label7.ForeColor = Color.DarkOrange;
            label7.Location = new Point(46, 218);
            label7.Name = "label7";
            label7.Size = new Size(0, 24);
            label7.TabIndex = 14;
            // 
            // F_cad_produtos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(928, 435);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(TB_codigo);
            Controls.Add(label5);
            Controls.Add(TB_precoProduto);
            Controls.Add(label4);
            Controls.Add(CB_fornecedor);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(CB_categoria);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(BT_cadastro);
            Controls.Add(tb_nomeProduto);
            Name = "F_cad_produtos";
            Text = "F_cad_produtos";
            Load += F_cad_produtos_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_nomeProduto;
        private Button BT_cadastro;
        private Label label1;
        private Label label3;
        private ComboBox CB_categoria;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label4;
        private ComboBox CB_fornecedor;
        private Label label5;
        private TextBox TB_precoProduto;
        private Label label6;
        private TextBox TB_codigo;
        private Label label7;
    }
}