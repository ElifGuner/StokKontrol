using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokKontrol
{
    public class Test2DBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=bss01;Database=BTestDB;User Id=sa;Password=q1w2e3r4t5*X;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder); 
            modelBuilder.Entity<Category>()
                .HasData(
                new Category() { Id = 1, CategoryName = "Bilgisayar" },
                new Category() { Id = 2, CategoryName = "Beyaz Eşya" }
                );

            modelBuilder.Entity<Warehouse>()
                .HasData(
                new Warehouse() { Id = 1, WarehouseName = "Ankara" },
                new Warehouse() { Id = 2, WarehouseName = "İstanbul" },
                new Warehouse() { Id = 3, WarehouseName = "İzmir" }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                new Product() { Id = 1, CategoryId = 1, WarehouseId = 1, ProductName = "Casper", Adet = 3, Fiyat = 10000 },
                new Product() { Id = 2, CategoryId = 1, WarehouseId = 2, ProductName = "Lenovo", Adet = 5, Fiyat = 12000 },
                new Product() { Id = 3, CategoryId = 2, WarehouseId = 2, ProductName = "Buzdolabı", Adet = 4, Fiyat = 30000 },
                new Product() { Id = 4, CategoryId = 2, WarehouseId = 3, ProductName = "Fırın", Adet = 6, Fiyat = 20000 }
                );


        }
    }

    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }

        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(Warehouse))]
        public int WarehouseId { get; set; }
        public string ProductName { get; set; }

        public int Adet { get; set; }

        public float Fiyat { get; set; }

        public Category Categories { get; set; }

        public Warehouse Warehouses { get; set; }
    }

    public class Warehouse
    {
        public int Id { get; set; }

        public string WarehouseName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
