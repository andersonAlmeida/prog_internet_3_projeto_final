using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required( ErrorMessage = "O campo {0} é obrigatório." )]
        public string Nome { get; set; }

        [Required( ErrorMessage = "O campo {0} é obrigatório." )]
        public string Sobrenome { get; set; }

        [Required( ErrorMessage = "O campo {0} é obrigatório." )]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required( ErrorMessage = "O campo {0} é obrigatório." )]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime Nascimento { get; set; }

        [Required( ErrorMessage = "O campo {0} é obrigatório." )]
        public string Cpf { get; set; }

        [Required( ErrorMessage = "O campo {0} é obrigatório." )]
        public string Rg { get; set; }
    }
}
