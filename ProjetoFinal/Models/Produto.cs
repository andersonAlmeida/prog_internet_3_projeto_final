using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public double Preco { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Desconto { get; set; }
        public int Estoque { get; set; }

        public int CategoriaId { get; set; }
        public ICollection<Categoria> Categoria { get; set; } = new List<Categoria>();

        public int MarcaId { get; set; }
        public ICollection<Marca> Marca { get; set; } = new List<Marca>();

        public List<ProdutoPedido> PP { get; set; }
    }
}
