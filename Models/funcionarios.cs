using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogin.Models
{
    internal class funcionarios
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string cpf_funcionario { get; set; }

        public string email_funcionario { get; set; }   
        public int id_cargo {  get; set; }


    }
}
