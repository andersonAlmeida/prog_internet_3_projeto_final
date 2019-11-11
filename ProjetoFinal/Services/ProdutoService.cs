using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Services
{
    public class ProdutoService
    {
        private readonly ProjetoFinal0Context _context;

        public ProdutoService(ProjetoFinal0Context context)
        {
            _context = context;
        }

        public List<Produto> FindAll()
        {
            // retorna todos os produtos ordenados por nome
            return _context.Produto.OrderBy(d => d.Nome).ToList();
        }
    }
}
