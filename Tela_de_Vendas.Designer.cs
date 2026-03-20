namespace SistemaLogin
{
    partial class Tela_de_Vendas
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
            ListViewItem listViewItem1 = new ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tela_de_Vendas));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            label3 = new Label();
            btn_finalizar_venda = new Button();
            btn_cancelar = new Button();
            label4 = new Label();
            label5 = new Label();
            listView1 = new ListView();
            lb_produtos = new ListBox();
            pictureBox3 = new PictureBox();
            btn_remover = new Button();
            btn_remover_tudo = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.SaddleBrown;
            pictureBox1.Location = new Point(-1, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(802, 64);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.SaddleBrown;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(-3, 0);
            label1.Name = "label1";
            label1.Size = new Size(593, 37);
            label1.TabIndex = 1;
            label1.Text = "MARKET 100 STRESS - VENDA DE PRODUTOS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.SaddleBrown;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(5, 38);
            label2.Name = "label2";
            label2.Size = new Size(268, 15);
            label2.TabIndex = 2;
            label2.Text = "Faça suas compras no melhor mercado da cidade";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.SandyBrown;
            pictureBox2.Location = new Point(-3, 58);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(812, 35);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.SandyBrown;
            label3.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(4, 68);
            label3.Name = "label3";
            label3.Size = new Size(52, 16);
            label3.TabIndex = 4;
            label3.Text = "Ações     /";
            // 
            // btn_finalizar_venda
            // 
            btn_finalizar_venda.BackColor = Color.Lime;
            btn_finalizar_venda.FlatAppearance.BorderSize = 0;
            btn_finalizar_venda.FlatStyle = FlatStyle.Flat;
            btn_finalizar_venda.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_finalizar_venda.ForeColor = SystemColors.ControlText;
            btn_finalizar_venda.Location = new Point(62, 65);
            btn_finalizar_venda.Name = "btn_finalizar_venda";
            btn_finalizar_venda.Size = new Size(99, 23);
            btn_finalizar_venda.TabIndex = 5;
            btn_finalizar_venda.Text = "Finalizar Venda";
            btn_finalizar_venda.UseVisualStyleBackColor = false;
            // 
            // btn_cancelar
            // 
            btn_cancelar.BackColor = Color.Red;
            btn_cancelar.FlatAppearance.BorderSize = 0;
            btn_cancelar.FlatStyle = FlatStyle.Flat;
            btn_cancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_cancelar.ForeColor = SystemColors.ControlText;
            btn_cancelar.Location = new Point(167, 65);
            btn_cancelar.Name = "btn_cancelar";
            btn_cancelar.Size = new Size(99, 23);
            btn_cancelar.TabIndex = 6;
            btn_cancelar.Text = "Cancelar";
            btn_cancelar.UseVisualStyleBackColor = false;
            btn_cancelar.Click += btn_cancelar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.PeachPuff;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Chocolate;
            label4.Location = new Point(4, 110);
            label4.Name = "label4";
            label4.Size = new Size(186, 25);
            label4.TabIndex = 7;
            label4.Text = "Adicionar Produtos";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.PeachPuff;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(7, 139);
            label5.Name = "label5";
            label5.Size = new Size(62, 17);
            label5.TabIndex = 8;
            label5.Text = "Produto:";
            // 
            // listView1
            // 
            listView1.BorderStyle = BorderStyle.FixedSingle;
            listView1.FullRowSelect = true;
            listView1.Items.AddRange(new ListViewItem[] { listViewItem1 });
            listView1.Location = new Point(7, 159);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(537, 279);
            listView1.TabIndex = 10;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Tile;
            listView1.DoubleClick += listView1_DoubleClick;
            // 
            // lb_produtos
            // 
            lb_produtos.FormattingEnabled = true;
            lb_produtos.ItemHeight = 15;
            lb_produtos.Location = new Point(550, 159);
            lb_produtos.Name = "lb_produtos";
            lb_produtos.Size = new Size(238, 274);
            lb_produtos.TabIndex = 11;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.SaddleBrown;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(694, -20);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(105, 78);
            pictureBox3.TabIndex = 12;
            pictureBox3.TabStop = false;
            // 
            // btn_remover
            // 
            btn_remover.Location = new Point(602, 404);
            btn_remover.Name = "btn_remover";
            btn_remover.Size = new Size(130, 23);
            btn_remover.TabIndex = 13;
            btn_remover.Text = "Remover Selecionado";
            btn_remover.UseVisualStyleBackColor = true;
            btn_remover.Click += btn_remover_Click;
            // 
            // btn_remover_tudo
            // 
            btn_remover_tudo.BackColor = Color.Orange;
            btn_remover_tudo.FlatAppearance.BorderSize = 0;
            btn_remover_tudo.FlatStyle = FlatStyle.Flat;
            btn_remover_tudo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_remover_tudo.ForeColor = SystemColors.ControlText;
            btn_remover_tudo.Location = new Point(272, 65);
            btn_remover_tudo.Name = "btn_remover_tudo";
            btn_remover_tudo.Size = new Size(99, 23);
            btn_remover_tudo.TabIndex = 14;
            btn_remover_tudo.Text = "Remover Tudo";
            btn_remover_tudo.UseVisualStyleBackColor = false;
            btn_remover_tudo.Click += btn_remover_tudo_Click;
            // 
            // Tela_de_Vendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_remover_tudo);
            Controls.Add(btn_remover);
            Controls.Add(pictureBox3);
            Controls.Add(lb_produtos);
            Controls.Add(listView1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(btn_cancelar);
            Controls.Add(btn_finalizar_venda);
            Controls.Add(label3);
            Controls.Add(pictureBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Tela_de_Vendas";
            Text = "Tela_de_Vendas";
            Load += Tela_de_Vendas_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox2;
        private Label label3;
        private Button btn_finalizar_venda;
        private Button btn_cancelar;
        private Label label4;
        private Label label5;
        private ListView listView1;
        private ListBox lb_produtos;
        private PictureBox pictureBox3;
        private Button btn_remover;
        private Button btn_remover_tudo;
    }
}