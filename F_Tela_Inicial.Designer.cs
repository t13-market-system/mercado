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
            panel2 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            painel_produtos.SuspendLayout();
            tabControl1.SuspendLayout();
            Cadastrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
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
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(114, 586);
            panel1.TabIndex = 0;
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
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(967, 558);
            tabPage1.TabIndex = 1;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
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
            pictureBox1.Location = new Point(3, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
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
    }
}