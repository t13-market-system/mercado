namespace SistemaLogin
{
    partial class F_Tela_Inicial
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel1 = new Panel();
            button7 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            painel_produtos = new Panel();
            tabControl1 = new TabControl();
            Cadastrar = new TabPage();
            button6 = new Button();
            button5 = new Button();
            tb_categoria = new TextBox();
            button4 = new Button();
            dgvCategorias = new DataGridView();
            tabPage1 = new TabPage();
            button8 = new Button();
            CB_delete = new ComboBox();
            BT_Add = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            TB_codigo = new TextBox();
            TB_precoProduto = new TextBox();
            tb_nomeProduto = new TextBox();
            DGV_produto = new DataGridView();
            CB_fornecedor = new ComboBox();
            CB_categoria = new ComboBox();
            panel2 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            painel_produtos.SuspendLayout();
            tabControl1.SuspendLayout();
            Cadastrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_produto).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1107, 658);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Controls.Add(painel_produtos, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 63);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1101, 592);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(114, 586);
            panel1.TabIndex = 0;
            // 
            // button7
            // 
            button7.Location = new Point(0, 123);
            button7.Name = "button7";
            button7.Size = new Size(111, 23);
            button7.TabIndex = 3;
            button7.Text = "Vendas";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(0, 84);
            button3.Name = "button3";
            button3.Size = new Size(111, 23);
            button3.TabIndex = 2;
            button3.Text = "Fornecedor";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(0, 43);
            button2.Name = "button2";
            button2.Size = new Size(112, 23);
            button2.TabIndex = 1;
            button2.Text = "Funcionário";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(108, 23);
            button1.TabIndex = 0;
            button1.Text = "Produtos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // painel_produtos
            // 
            painel_produtos.BackColor = SystemColors.AppWorkspace;
            painel_produtos.Controls.Add(tabControl1);
            painel_produtos.Dock = DockStyle.Fill;
            painel_produtos.Location = new Point(123, 3);
            painel_produtos.Name = "painel_produtos";
            painel_produtos.Size = new Size(975, 586);
            painel_produtos.TabIndex = 1;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Cadastrar);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(975, 586);
            tabControl1.TabIndex = 0;
            // 
            // Cadastrar
            // 
            Cadastrar.Controls.Add(button6);
            Cadastrar.Controls.Add(button5);
            Cadastrar.Controls.Add(tb_categoria);
            Cadastrar.Controls.Add(button4);
            Cadastrar.Controls.Add(dgvCategorias);
            Cadastrar.Location = new Point(4, 24);
            Cadastrar.Name = "Cadastrar";
            Cadastrar.Padding = new Padding(3);
            Cadastrar.Size = new Size(967, 558);
            Cadastrar.TabIndex = 0;
            Cadastrar.Text = "Categorias";
            Cadastrar.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(254, 99);
            button6.Name = "button6";
            button6.Size = new Size(118, 23);
            button6.TabIndex = 4;
            button6.Text = "Excluir";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Location = new Point(130, 99);
            button5.Name = "button5";
            button5.Size = new Size(118, 23);
            button5.TabIndex = 3;
            button5.Text = "Atualizar";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // tb_categoria
            // 
            tb_categoria.Location = new Point(6, 60);
            tb_categoria.Name = "tb_categoria";
            tb_categoria.Size = new Size(362, 23);
            tb_categoria.TabIndex = 2;
            // 
            // button4
            // 
            button4.Location = new Point(6, 99);
            button4.Name = "button4";
            button4.Size = new Size(118, 23);
            button4.TabIndex = 1;
            button4.Text = "Adicionar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // dgvCategorias
            // 
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorias.Dock = DockStyle.Right;
            dgvCategorias.Location = new Point(389, 3);
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.ReadOnly = true;
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.Size = new Size(575, 552);
            dgvCategorias.TabIndex = 0;
            dgvCategorias.CellClick += dgvCategorias_CellClick;
            dgvCategorias.CellContentClick += dgvCategorias_CellContentClick;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(button8);
            tabPage1.Controls.Add(CB_delete);
            tabPage1.Controls.Add(BT_Add);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(TB_codigo);
            tabPage1.Controls.Add(TB_precoProduto);
            tabPage1.Controls.Add(tb_nomeProduto);
            tabPage1.Controls.Add(DGV_produto);
            tabPage1.Controls.Add(CB_fornecedor);
            tabPage1.Controls.Add(CB_categoria);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(967, 558);
            tabPage1.TabIndex = 1;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.Red;
            button8.Location = new Point(96, 484);
            button8.Name = "button8";
            button8.Size = new Size(236, 23);
            button8.TabIndex = 15;
            button8.Text = "Deletar";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // CB_delete
            // 
            CB_delete.FormattingEnabled = true;
            CB_delete.Location = new Point(96, 438);
            CB_delete.Name = "CB_delete";
            CB_delete.Size = new Size(236, 23);
            CB_delete.TabIndex = 14;
            // 
            // BT_Add
            // 
            BT_Add.BackColor = Color.Green;
            BT_Add.Location = new Point(96, 321);
            BT_Add.Name = "BT_Add";
            BT_Add.Size = new Size(236, 23);
            BT_Add.TabIndex = 13;
            BT_Add.Text = "Adicionar";
            BT_Add.UseVisualStyleBackColor = false;
            BT_Add.Click += BT_Add_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1, 283);
            label6.Name = "label6";
            label6.Size = new Size(49, 15);
            label6.TabIndex = 12;
            label6.Text = "Codigo:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1, 208);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 11;
            label5.Text = "Preço:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1, 145);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 10;
            label4.Text = "Fornecedor:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1, 88);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 9;
            label3.Text = "Categoria:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1, 23);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 8;
            label2.Text = "Nome Produto:";
            label2.Click += label2_Click;
            // 
            // TB_codigo
            // 
            TB_codigo.Location = new Point(96, 280);
            TB_codigo.Name = "TB_codigo";
            TB_codigo.Size = new Size(236, 23);
            TB_codigo.TabIndex = 7;
            TB_codigo.TextChanged += textBox3_TextChanged;
            // 
            // TB_precoProduto
            // 
            TB_precoProduto.Location = new Point(96, 208);
            TB_precoProduto.Name = "TB_precoProduto";
            TB_precoProduto.Size = new Size(236, 23);
            TB_precoProduto.TabIndex = 6;
            TB_precoProduto.TextChanged += TB_precoProduto_TextChanged;
            // 
            // tb_nomeProduto
            // 
            tb_nomeProduto.Location = new Point(96, 20);
            tb_nomeProduto.Name = "tb_nomeProduto";
            tb_nomeProduto.Size = new Size(236, 23);
            tb_nomeProduto.TabIndex = 3;
            // 
            // DGV_produto
            // 
            DGV_produto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_produto.Location = new Point(368, 3);
            DGV_produto.Name = "DGV_produto";
            DGV_produto.Size = new Size(596, 555);
            DGV_produto.TabIndex = 2;
            // 
            // CB_fornecedor
            // 
            CB_fornecedor.FormattingEnabled = true;
            CB_fornecedor.Location = new Point(96, 145);
            CB_fornecedor.Name = "CB_fornecedor";
            CB_fornecedor.Size = new Size(236, 23);
            CB_fornecedor.TabIndex = 1;
            // 
            // CB_categoria
            // 
            CB_categoria.FormattingEnabled = true;
            CB_categoria.Location = new Point(96, 85);
            CB_categoria.Name = "CB_categoria";
            CB_categoria.Size = new Size(236, 23);
            CB_categoria.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1101, 54);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(438, 6);
            label1.Name = "label1";
            label1.Size = new Size(202, 30);
            label1.TabIndex = 1;
            label1.Text = "Mercado 100 stress";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Yellow_Orange_Illustration_Mart_;
            pictureBox1.Location = new Point(3, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(136, 410);
            label7.Name = "label7";
            label7.Size = new Size(157, 25);
            label7.TabIndex = 16;
            label7.Text = "Apagar Produto";
            // 
            // F_Tela_Inicial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1107, 658);
            Controls.Add(tableLayoutPanel1);
            Name = "F_Tela_Inicial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "F_Tela_Inicial";
            Load += F_Tela_Inicial_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            painel_produtos.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            Cadastrar.ResumeLayout(false);
            Cadastrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_produto).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private Button button3;
        private Button button2;
        private Button button1;
        private Panel painel_produtos;
        private Panel panel2;
        private Label label1;
        private PictureBox pictureBox1;
        private TabControl tabControl1;
        private TabPage Cadastrar;
        private TabPage tabPage1;
        private TextBox tb_categoria;
        private Button button4;
        private DataGridView dgvCategorias;
        private Button button6;
        private Button button5;
        private Button button7;
        private ComboBox CB_fornecedor;
        private ComboBox CB_categoria;
        private DataGridView DGV_produto;
        private TextBox tb_nomeProduto;
        private TextBox TB_precoProduto;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox TB_codigo;
        private Button BT_Add;
        private Button button8;
        private ComboBox CB_delete;
        private Label label7;
    }
}