﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final.Models.ViewModels
{
    public class HomeViewModel
    {
        public ICollection<Produto> Produtos { get; set; }
        public ICollection<Banner> Banners { get; set; }
        public string Uploads { get; set; }
        //public ICollection<Categoria> Categorias { get; set; }
        //public ICollection<Marca> Marcas { get; set; }
    }
}
