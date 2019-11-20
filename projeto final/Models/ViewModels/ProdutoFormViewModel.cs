using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final.Models.ViewModels
{
    public class ProdutoFormViewModel
    {
        public Produto Produto { get; set; }
        public ICollection<Categoria> Categorias { get; set; }
        public ICollection<Marca> Marcas { get; set; }
    }
}
