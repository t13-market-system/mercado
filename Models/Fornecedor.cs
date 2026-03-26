using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogin.Models
{
    internal class Fornecedor
    {
        public int Id_Fornecedor { get; set; }
        public string Nome_Fornecedor { get; set; }
        public string CNPJ_Fornecedor { get; set; }
        public string Email_Fornecedor { get; set; }
    }
}
