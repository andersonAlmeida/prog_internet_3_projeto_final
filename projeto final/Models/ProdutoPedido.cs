using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final.Models
{
    public class ProdutoPedido
    {
        [Key]
        public int Id { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }
}
