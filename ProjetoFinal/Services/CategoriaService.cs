using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Services
{
    public class CategoriaService
    {
        private readonly ProjetoFinal0Context _context;

        public CategoriaService(ProjetoFinal0Context context)
        {
            _context = context;
        }

        public List<Categoria> FindAll()
        {
            // retorna todos os produtos ordenados por nome
            return _context.Categoria.OrderBy(d => d.Nome).ToList();
        }
    }
}
