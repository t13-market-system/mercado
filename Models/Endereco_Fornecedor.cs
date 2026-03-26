using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogin.Models
{
    internal class Endereco_Fornecedor
    {
        public int Id_Endereco_Fornecedor { get; set; }
        public int Id_Fornecedor { get; set; }
        public string Pais_Fornecedor { get; set; }
        public string Estado_Fornecedor { get; set; }
        public string Cidade_Fornecedor { get; set; }
        public string Rua_Fornecedor { get; set; }
        public string Bairro_Fornecedor { get; set; }
        public string Numero_Fornecedor { get; set; }
        public string CEP_Fornecedor { get; set; }
        public string Complemento_Fornecedor { get; set; }
    }
}
