
//using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using static StokKontrol.Program;

namespace StokKontrol
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            Test2DBContext context = new Test2DBContext();


            //var data = context.Categories.Include(c => c.Products.Where(p => p.ProductName == "Buzdolabý")).
            //    ThenInclude(p => p.Warehouses).
            //    Select(p => new
            //    {
            //        //Adet = p.Adet,
            //        //ProductName = p.ProductName,
            //        CategoryName = p.CategoryName,
            //        ProductName = p.Products.Select(p => p.ProductName),
            //        WarehouseName = p.Products.Select(p => p.Warehouses.WarehouseName),
            //        Adet = p.Products.Select(p => p.Adet),
            //        Fiyat = p.Products.Select(p => p.Fiyat)
            //    }
            //    ).ToList();

            //var data = context.Categories
            //          .Include(c => c.Products)
            //          .ThenInclude(p => p.Warehouses).

            //RETRIEVE
            var data = context.Products
                      .Include(p => p.Categories)
                      .Include(p => p.Warehouses)
                      .Where(p => p.ProductName.Equals("Buzdolabý")).
                Select(p => new
                {
                    Adet = p.Adet,
                    ProductName = p.ProductName,
                    Fiyat = p.Fiyat,
                    CategoryName = p.Categories.CategoryName,
                    WarehouseName = p.Warehouses.WarehouseName                   
                }
                ).ToList();

            foreach (var d in data)
            { 
                Console.WriteLine(d.CategoryName);
                Console.WriteLine(d.ProductName);
                Console.WriteLine(d.WarehouseName);
                Console.WriteLine(d.Adet);
                Console.WriteLine(d.Fiyat);
            }
        }


        //public class Test2DBContext : DbContext
        //{
        //    public DbSet<Category> Categories { get; set; }
        //    public DbSet<Product> Products { get; set; }
        //    public DbSet<Warehouse> Warehouses { get; set; }
        //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    {
        //        //base.OnConfiguring(optionsBuilder);
        //        optionsBuilder.UseSqlServer("Server=bss01;Database=BTestDB;User Id=sa;Password=q1w2e3r4t5*X;TrustServerCertificate=True");
        //    }
        //    protected override void OnModelCreating(ModelBuilder modelBuilder)
        //    {
        //        //base.OnModelCreating(modelBuilder); 
        //        modelBuilder.Entity<Category>()
        //            .HasData(
        //            new Category() { Id = 1, CategoryName = "Bilgisayar" },
        //            new Category() { Id = 2, CategoryName = "Beyaz Eþya" }
        //            );

        //        modelBuilder.Entity<Warehouse>()
        //            .HasData(
        //            new Warehouse() { Id = 1, WarehouseName  = "Ankara" },
        //            new Warehouse() { Id = 2, WarehouseName  = "Ýstanbul" },
        //            new Warehouse() { Id = 3, WarehouseName  = "Ýzmir" }
        //            );

        //        modelBuilder.Entity<Product>()
        //            .HasData(
        //            new Product() { Id = 1, CategoryId = 1, WarehouseId = 1, ProductName = "Casper", Adet = 3, Fiyat = 10000 },
        //            new Product() { Id = 2, CategoryId = 1, WarehouseId = 2, ProductName = "Lenovo", Adet = 5, Fiyat = 12000 },
        //            new Product() { Id = 3, CategoryId = 2, WarehouseId = 2, ProductName = "Buzdolabý", Adet = 4, Fiyat = 30000 },
        //            new Product() { Id = 4, CategoryId = 2, WarehouseId = 3, ProductName = "Fýrýn", Adet = 6, Fiyat = 20000 }
        //            );


        //    }
        //}
        //public class Category
        //{
        //    public Category()
        //    {
        //        Products = new List<Product>();
        //    }
        //    public int Id { get; set; }

        //    public string CategoryName { get; set; }
        //    public ICollection<Product> Products { get; set; }
        //}

        //public class Product
        //{
        //    public int Id { get; set; }
        //    [ForeignKey(nameof(Category))]
        //    public int CategoryId { get; set; }

        //    [ForeignKey(nameof(Warehouse))]
        //    public int WarehouseId { get; set; }
        //    public string ProductName { get; set; }

        //    public int Adet { get; set; }

        //    public float Fiyat { get; set; }

        //    public Category Categories { get; set; }

        //    public Warehouse Warehouses { get; set; }
        //}

        //public class Warehouse
        //{
        //    public int Id { get; set; }

        //    public string WarehouseName { get; set; }

        //    public ICollection<Product> Products { get; set; }
        //}
    }


}