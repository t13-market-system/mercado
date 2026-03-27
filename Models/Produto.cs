using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogin.Models
{
    internal class Produto
    {
        public int Id_produto { get; set; }
        public string Nome_produto { get; set; }
        public decimal Preco_produto { get; set; }
        public string Codigo_produto { get; set; }
        public int Id_categoria { get; set; }
        public int Id_fornecedor { get; set; }

    }

}

