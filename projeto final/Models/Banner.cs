using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final.Models
{
    public class Banner
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataType(DataType.Upload)]
        [Display(Name = "Selecione o banner")]
        public string Imagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(0, 1, ErrorMessage = "O valor deve ser  0 para inativo ou  1 para ativo.")]
        public int Ativo { get; set; } = 1;
    }
}
