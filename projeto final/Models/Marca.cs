using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final.Models
{
    public class Marca
    {        
        public int MarcaId { get; set; }

        [MaxLength(30, ErrorMessage = "Limite máximo de 30 caracteres.")]
        public string Nome { get; set; }

        public ICollection<Produto> Produtos { get; set; }

        public Marca()
        {
        }

        public Marca(string nome)
        {
            Nome = nome;
        }

        public Marca(int id, string nome)
        {
            MarcaId = id;
            Nome = nome;
        }
    }
}
