using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [MaxLength(30, ErrorMessage = "Limite máximo de 30 caracteres.")]
        public string Nome { get; set; }
                
        public ICollection<Produto> Produtos { get; set; }

        public Categoria()
        {
        }

        public Categoria(string nome)
        {
            Nome = nome;
        }

        public Categoria(int id, string nome)
        {
            CategoriaId = id;
            Nome = nome;
        }
    }
}
