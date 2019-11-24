using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final.Models
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

        //[ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }

        //[ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        //[ForeignKey("MarcaId")]
        //public int MarcaId { get; set; }

        //[ForeignKey("MarcaId")]
        public Marca Marca { get; set; }

        public List<ProdutoPedido> PP { get; set; }

        public Produto()
        {
        }

        public Produto(double preco, string nome, string descricao, double desconto, int estoque, Categoria categoria, Marca marca, List<ProdutoPedido> pP)
        {
            Preco = preco;
            Nome = nome;
            Descricao = descricao;
            Desconto = desconto;
            Estoque = estoque;
            Categoria = categoria;
            Marca = marca;
            PP = pP;
        }

        public Produto(int id, double preco, string nome, string descricao, double desconto, int estoque, Categoria categoria, Marca marca, List<ProdutoPedido> pP)
        {
            Id = id;
            Preco = preco;
            Nome = nome;
            Descricao = descricao;
            Desconto = desconto;
            Estoque = estoque;
            Categoria = categoria;
            Marca = marca;
            PP = pP;
        }
    }
}
