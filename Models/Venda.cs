using MySqlConnector;
using System;


using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogin.Models
{
    internal class Venda
    {
        public int Id_venda { get; set; }
        public int Id_pedido { get; set; }
        public DateTime Data_venda { get; set; }
        public int Id_forma_pagamento { get; set; }
    }
}
