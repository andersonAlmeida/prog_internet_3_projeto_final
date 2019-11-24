using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Marca()
        {
        }

        public Marca(string nome)
        {
            Nome = nome;
        }

        public Marca(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
