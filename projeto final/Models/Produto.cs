using Microsoft.AspNetCore.Http;
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
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Range(1, 999999)] // adiciona um valor minimo de 1 e maximo de 999999
        [DataType(DataType.Currency)] // diz que é uma moeda
        [Display(Name = "Preço")] // troca a label do campo
        public double Preco { get; set; }

        [MaxLength(50, ErrorMessage = "Limite máximo de 50 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [MaxLength(500, ErrorMessage = "Limite máximo de 500 caracteres")]
        public string Descricao { get; set; }

        [Range(0.0, double.MaxValue)] // seta um range entre 0 e maior valor de double
        public double Desconto { get; set; }

        [Range(0, 9999999)] // seta um limite
        public int Estoque { get; set; }

        [Display(Name = "Categoria")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoriaId { get; set; }        
        public virtual Categoria Categoria { get; set; }

        [Display(Name = "Marca")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MarcaId { get; set; }
        public virtual Marca Marca { get; set; }

        //[Required(ErrorMessage = "Selecione uma imagem.")]
        [DataType(DataType.Upload)]
        public string Thumb { get; set; }

        public List<ProdutoPedido> PP { get; set; }

        public Produto()
        {
        }

        public Produto(double preco, string nome, string descricao, double desconto, int estoque, Categoria categoria, Marca marca, string thumb)
        {
            Preco = preco;
            Nome = nome;
            Descricao = descricao;
            Desconto = desconto;
            Estoque = estoque;
            Categoria = categoria;
            Marca = marca;
            Thumb = thumb;
        }

        public Produto(double preco, string nome, string descricao, double desconto, int estoque, int categoriaId, Categoria categoria, int marcaId, Marca marca, /*string imagem,*/ List<ProdutoPedido> pP)
        {
            Preco = preco;
            Nome = nome;
            Descricao = descricao;
            Desconto = desconto;
            Estoque = estoque;
            CategoriaId = categoriaId;
            Categoria = categoria;
            MarcaId = marcaId;
            Marca = marca;
            //Thumb = imagem;
            PP = pP;
        }
    }
}
