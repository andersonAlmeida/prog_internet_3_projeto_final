using Microsoft.EntityFrameworkCore;
using projeto_final.Data;
using projeto_final.Models;
using projeto_final.Services.Exceptions;
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

        public void Insert(Produto produto)
        {
            _context.Add(produto);
            _context.SaveChanges();
        }

        public List<Produto> FindAll()
        {
            // retorna todos os produtos ordenados por nome
            return _context.Produto.Include(p => p.Categoria).Include(p => p.Marca).OrderBy(d => d.Nome).ToList();
        }

        public Produto FindById(int id)
        {
            // Retorna o produto com o ID passado por parâmetro
            return _context.Produto.Include(p => p.Categoria).Include(p => p.Marca).FirstOrDefault(s => s.Id == id);
        }

        public void Update(Produto obj)
        {
            //Se não houver nenhum vendedor com esse ID no banco de dados
            if (!_context.Produto.Any(s => s.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            //Se houver um vendedor no banco de dados com esse ID, vou atualizar seus dados
            //com base no objeto Seller que recebi como parâmetro do método
            _context.Update(obj);
            /*Porém, sempre que executarmos uma operação de update no banco de dados, pode ocorrer um erro de concorrência*/
            _context.SaveChanges();

        }
    }
}
