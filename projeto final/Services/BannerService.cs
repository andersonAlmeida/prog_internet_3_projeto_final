using Microsoft.EntityFrameworkCore;
using projeto_final.Data;
using projeto_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final.Services
{
    public class BannerService
    {
        private readonly ApplicationDbContext _context;

        public BannerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Banner> FindAll()
        {
            return _context.Banner.Where(b => b.Ativo == 1).ToList();
        }
    }
}
