using projeto_final.Data;
using projeto_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final.Services
{
    public class CategoriaService
    {
        private readonly ApplicationDbContext _context;

        public CategoriaService(ApplicationDbContext context)
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