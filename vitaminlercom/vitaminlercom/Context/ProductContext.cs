using Microsoft.EntityFrameworkCore;
using vitaminlercom.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace  vitaminlercom.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<KategoriAddresses> KategoriAddresses { get; set; }
        public DbSet<ProductAddresses> ProductAddresses { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Unit> Unit { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-V0M4I1T\SQLEXPRESS02;Initial Catalog=ProductPoolDcomvitaminler;Integrated Security=True");

        }
    }
}
