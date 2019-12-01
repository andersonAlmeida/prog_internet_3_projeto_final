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
        [Key]
        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "Limite máximo de 30 caracteres.")]
        public string Nome { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Produto Produto { get; set; }

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
