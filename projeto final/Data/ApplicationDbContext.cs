using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projeto_final.Models;

namespace projeto_final.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<projeto_final.Models.Administrador> Administrador { get; set; }
        public DbSet<projeto_final.Models.Categoria> Categoria { get; set; }
        public DbSet<projeto_final.Models.Cliente> Cliente { get; set; }
        public DbSet<projeto_final.Models.Endereco> Endereco { get; set; }
        public DbSet<projeto_final.Models.Fornecedor> Fornecedor { get; set; }
        public DbSet<projeto_final.Models.Imagem> Imagem { get; set; }
        public DbSet<projeto_final.Models.Marca> Marca { get; set; }
        public DbSet<projeto_final.Models.Pedido> Pedido { get; set; }
        public DbSet<projeto_final.Models.Produto> Produto { get; set; }
        public DbSet<projeto_final.Models.Telefone> Telefone { get; set; }
        public DbSet<projeto_final.Models.Banner> Banner { get; set; }
    }
}
