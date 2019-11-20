using projeto_final.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public double Total { get; set; }
        [DataType(DataType.Date)]
        public DateTime Prazo { get; set; }
        public ICollection<Cliente> Cliente { get; set; } = new List<Cliente>();

        [Display(Name = "Código de Rastreamento")]
        public string Codigo_Rastreamento { get; set; }
                
        public PedidoStatus Status { get; set; }
        public List<ProdutoPedido> PP { get; set; }
    }
}
