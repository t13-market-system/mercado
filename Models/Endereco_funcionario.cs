using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogin.Models
{
    internal class Endereco_funcionario
    {
        public int Id_funcionaro {  get; set; } 

        public int Id_endereco_funcionario { get; set; }

        public string Pais_funcionario { get; set; }  

        public string Estado_funcionario { get; set; }  

        public string Cidade_funcionario { get; set; }  

        public string Bairro_funcionario { get; set; }  

        public string Rua_funcionario { get; set; } 

        public string Cep_funcionario { get; set; } 

        public string Complemento_funcionario { get; set; } 

        public string Numero_rua {  get; set; }

        

    }
}
