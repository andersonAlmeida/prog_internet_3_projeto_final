using Microsoft.EntityFrameworkCore;
using projeto_final.Data;
using projeto_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final.Services
{
    public class HomeService
    {
        private readonly ApplicationDbContext _context;

        public HomeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Produto> FindAll()
        {
            // retorna todos os produtos ordenados por nome
            return _context.Produto.Include(p => p.Categoria).Include(p => p.Marca).OrderBy(d => d.Nome).ToList();
        }
    }
}
