using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final.Models
{
    public class Imagem
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem_Thumb { get; set; }
        [Required]
        public string Imagem_Normal { get; set; }
        public int Id_Produto { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
