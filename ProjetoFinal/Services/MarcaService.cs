using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Services
{
    public class MarcaService
    {
        private readonly ProjetoFinal0Context _context;

        public MarcaService(ProjetoFinal0Context context)
        {
            _context = context;
        }

        public List<Marca> FindAll()
        {
            // retorna todos os produtos ordenados por nome
            return _context.Marca.OrderBy(d => d.Nome).ToList();
        }
    }
}
