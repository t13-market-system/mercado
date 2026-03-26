using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogin.Models
{
    internal class Estoque
    {
        public int Id_estoque {  get; set; }

        public int Id_produto { get; set; }

        public int Qtd_estoque { get; set; }    
        
        public int Id_fornecedor { get; set; }

        public string N_lote {  get; set; } 

        public DateTime Data_validade { get; set; } 

        public string Local_estoque  { get; set; }  

        public string Status {  get; set; } 

        public DateTime Data_entrada { get; set; }  


    }
}
