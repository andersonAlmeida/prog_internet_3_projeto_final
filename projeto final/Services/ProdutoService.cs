using Microsoft.EntityFrameworkCore;
using projeto_final.Data;
using projeto_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final.Services
{
    public class ProdutoService
    {
        private readonly ApplicationDbContext _context;

        public ProdutoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Produto> FindAll()
        {
            // retorna todos os produtos ordenados por nome
            return _context.Produto.Include(p => p.Categoria).OrderBy(d => d.Nome).ToList();
        }
    }
}
