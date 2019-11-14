using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public double Preco { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Desconto { get; set; }
        public int Estoque { get; set; }

        //public int? CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        //public int? MarcaId { get; set; }

        [ForeignKey("MarcaId")]
        public Marca Marca { get; set; }

        public List<ProdutoPedido> PP { get; set; }
    }
}
