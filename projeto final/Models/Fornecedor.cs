using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Razao_Social { get; set; }
    }
}
