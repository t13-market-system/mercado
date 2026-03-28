using MySqlConnector;
using SistemaLogin.DAO;
using SistemaLogin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SistemaLogin
{
    public partial class F_cad_produtos : Form
    {
        public F_cad_produtos()
        {
            InitializeComponent();
        }

        private void F_cad_produtos_Load(object sender, EventArgs e)
        {
            CategoriaDAO dao = new CategoriaDAO();
            DataTable dt = dao.ObterTodas();

            CB_categoria.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                CB_categoria.Items.Add(row["categoria"].ToString());
            }



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void BT_cadastro_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CB_fornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
    

