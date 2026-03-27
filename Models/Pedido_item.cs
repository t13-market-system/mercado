using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogin.Models
{
    internal class Pedido_item
    {
        public int Id_item { get; set; }
        public int Id_pedido { get; set; }
        public int Id_produto { get; set; }
        public int Qtd_item { get; set; }
        public decimal Preco_uni {  get; set; }

    }
}
