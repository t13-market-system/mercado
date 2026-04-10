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

        // telefone/endereço no mesmo objeto: foi necessário para conseguir editar o fornecedor de forma mais simples
        public string Telefone_Fornecedor { get; set; }
        public string Pais_Fornecedor { get; set; }
        public string Estado_Fornecedor { get; set; }
        public string Cidade_Fornecedor { get; set; }
        public string Rua_Fornecedor { get; set; }
        public string Numero_Fornecedor { get; set; }
        public string Bairro_Fornecedor { get; set; }
        public string Complemento_Fornecedor { get; set; }
        public string Cep_Fornecedor { get; set; }
    }
}
