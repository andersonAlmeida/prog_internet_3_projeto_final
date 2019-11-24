using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Categoria()
        {
        }

        public Categoria(string nome)
        {
            Nome = nome;
        }

        public Categoria(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
