using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        //Visto que essa classe extende/herda de ApplicationException, 
        //devemos criar o método construtor compatível
        //Método construtor que recebe como parâmetro uma mensagem
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
