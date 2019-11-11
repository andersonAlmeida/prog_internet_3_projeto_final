using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;

namespace ProjetoFinal.Models
{
    public class ProjetoFinal0Context : DbContext
    {
        public ProjetoFinal0Context (DbContextOptions<ProjetoFinal0Context> options)
            : base(options)
        {
        }

        public DbSet<Administrador> Administrador { get; set; }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Marca> Marca { get; set; }

        public DbSet<Pedido> Pedido { get; set; }

        public DbSet<Produto> Produto { get; set; }

        //public DbSet<ProjetoFinal.Models.ProdutoPedido> ProdutoPedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoPedido>()
                .HasKey(pp => new { pp.ProdutoId, pp.PedidoId});

            modelBuilder.Entity<ProdutoPedido>()
                .HasOne(pp => pp.Produto)
                .WithMany(p => p.PP)
                .HasForeignKey(pp => pp.ProdutoId);

            modelBuilder.Entity<ProdutoPedido>()
                .HasOne(pp => pp.Pedido)
                .WithMany(p => p.PP)
                .HasForeignKey(pp => pp.PedidoId);
        }
    }
}
