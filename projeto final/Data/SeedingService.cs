using projeto_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final.Data
{
    public class SeedingService
    {
        private readonly ApplicationDbContext _context;

        public SeedingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            //testar se já existe algum dado na minha base de dados
            //Operação ANY do LINQ neste caso vai verificar se há algum registro nesta tabela.
            if (_context.Categoria.Any() || _context.Marca.Any() || _context.Produto.Any())
            {
                return; //Banco de dados já foi criado. Então cancela essa operação!
            }

            //Categorias
            Categoria c1 = new Categoria("Tecnologia");
            Categoria c2 = new Categoria("Casa e cozinha");
            Categoria c3 = new Categoria("Esportes");
            Categoria c4 = new Categoria("Saúde");
            Categoria c5 = new Categoria("Brinquedos");

            //Marcas
            Marca m1 = new Marca("Apple");
            Marca m2 = new Marca("Arno");
            Marca m3 = new Marca("Adidas");
            Marca m4 = new Marca("X pharma");
            Marca m5 = new Marca("Lego");

            // Produtos
            Produto p1 = new Produto(5000.50, "Iphone", "Bem caro", 0, 1020, c1, m1, null);
            Produto p2 = new Produto(350.80, "Adidas Superstar", "Bom tênis", 0, 3000, c3, m3, null);
            Produto p3 = new Produto(1500.50, "Star Wars", "Maneiro", 0, 350, c5, m5, null);

            // Adiciona no banco
            _context.Categoria.AddRange(c1, c2, c3, c4, c5);
            _context.Marca.AddRange(m1, m2, m3, m4, m5);
            _context.Produto.AddRange(p1, p2, p3);

            //Método que efetiva o registro/gravação no banco de dados
            _context.SaveChanges();

        }
    }
}
