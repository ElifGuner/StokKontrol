using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using static StokKontrol.Program;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StokKontrol
{




    public partial class Form1 : Form
    {
        Test2DBContext context = new Test2DBContext();
        DataTable dt = new DataTable();
        public Form1()
        {

            InitializeComponent();

            cmbWarehouse.Items.Add("");
            cmbWarehouse.Items.Add("Ankara");
            cmbWarehouse.Items.Add("Ýstanbul");
            cmbWarehouse.Items.Add("Ýzmir");

           
            dt.Columns.Add("Kategori");
            dt.Columns.Add("Ürün");
            dt.Columns.Add("Depo");
            dt.Columns.Add("Adet");
            dt.Columns.Add("Fiyat");
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            //RETRIEVE
            #region Eager Loading

            //var datax = context.Products
            //          .Include(p => p.Categories)
            //          .Include(p => p.Warehouses)
            //          .Where(p => p.ProductName.Equals(txtProduct.Text)).
            //    Select(p => new
            //    {
            //        Adet = p.Adet,
            //        ProductName = p.ProductName,
            //        Fiyat = p.Fiyat,
            //        CategoryName = p.Categories.CategoryName,
            //        WarehouseName = p.Warehouses.WarehouseName
            //        //txtAdet = p.Adet,
            //        //txtProduct = p.ProductName,
            //        //txtFiyat = p.Fiyat,
            //        //txtCategory = p.Categories.CategoryName,
            //        //cmbWarehouse.SelectedValue= "sdaad"
            //    }
            //    );

            //var data = datax.FirstOrDefault();

            #endregion

            #region Query Syntax

            var query = from product in context.Products
                        join category in context.Categories
                             on product.CategoryId equals category.Id
                        join warehouse in context.Warehouses
                            on product.WarehouseId equals warehouse.Id
                        where product.ProductName == txtProduct.Text
                        select new
                        {
                            Adet = product.Adet,
                            ProductName = product.ProductName,
                            Fiyat = product.Fiyat,
                            CategoryName = category.CategoryName,
                            WarehouseName = warehouse.WarehouseName
                        };

            var data = query.Where(p => p.ProductName.Equals(txtProduct.Text)).FirstOrDefault();

            #endregion

            #region Method Syntax

            //var query = context.Products
            //    .Join(context.Categories,
            //    product => product.CategoryId,
            //    category => category.Id,
            //    (product, category) => new
            //    {
            //        product.Adet,
            //        product.ProductName,
            //        product.Fiyat,
            //        product.WarehouseId,
            //        category.CategoryName
            //    })
            //    .Join(context.Warehouses,
            //    productCategory => productCategory.WarehouseId,
            //    warehouse => warehouse.Id,
            //    (productCategory, warehouse) => new
            //    {
            //        productCategory.Adet,
            //        productCategory.ProductName,
            //        productCategory.Fiyat,
            //        productCategory.WarehouseId,
            //        productCategory.CategoryName,
            //        warehouse.WarehouseName
            //    });

            //var data = query.FirstOrDefault(p => p.ProductName.Equals(txtProduct.Text));

            #endregion

            txtAdet.Text = data.Adet.ToString();
            txtProduct.Text = data.ProductName;
            txtFiyat.Text = data.Fiyat.ToString();
            txtCategory.Text = data.CategoryName;

            cmbWarehouse.SelectedValue = data.WarehouseName;
            int index = cmbWarehouse.Items.IndexOf(data.WarehouseName);
            if (index >= 0)
            {
                cmbWarehouse.SelectedIndex = index;
            }


            DataRow drow = dt.NewRow();
            drow["Kategori"] = txtCategory.Text;
            drow["Ürün"] = txtProduct.Text;
            drow["Depo"] = data.WarehouseName;
            drow["Adet"] = txtAdet.Text;
            drow["Fiyat"] = txtFiyat.Text;

            dt.Rows.Add(drow);

            dataGridView1.DataSource = dt;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            // List <Category> categories = context.Categories.
            Category? category = context.Categories.Where(c => c.CategoryName.Equals(txtCategory.Text)).FirstOrDefault();
            //int WarehouseIndex = cmbWarehouse.Items.IndexOf(cmbWarehouse.SelectedItem.ToString());
            Warehouse? warehouse = context.Warehouses.FirstOrDefault(w => w.WarehouseName.Equals(cmbWarehouse.SelectedItem.ToString()));

            if (category == null)
            {
                Product product = new()
                {
                    ProductName = txtProduct.Text,
                    Adet = int.Parse(txtAdet.Text),
                    Fiyat = float.Parse(txtFiyat.Text),
                    Categories = new Category() { CategoryName = txtCategory.Text },
                    // Warehouses = new Warehouse() { WarehouseName = cmbWarehouse.SelectedItem.ToString() }
                    //WarehouseId = WarehouseIndex + 1
                    WarehouseId = warehouse.Id
                };
                context.Products.Add(product);
                context.SaveChanges();
            }
            else
            {
                Product product = new()
                {
                    ProductName = txtProduct.Text,
                    Adet = int.Parse(txtAdet.Text),
                    Fiyat = float.Parse(txtFiyat.Text),
                    CategoryId = category.Id,
                    // WarehouseId = WarehouseIndex + 1
                    WarehouseId = warehouse.Id
                };
                context.Products.Add(product);
                context.SaveChanges();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product? product = context.Products.FirstOrDefault(p => p.ProductName.Equals(txtProduct.Text));
            Warehouse? warehouse = context.Warehouses.FirstOrDefault(w => w.WarehouseName.Equals(cmbWarehouse.SelectedItem.ToString()));
            Category? category = context.Categories.Where(c => c.CategoryName.Equals(txtCategory.Text)).FirstOrDefault();
            if (product != null)
            {
                if (txtAdet.Text != "")
                    product.Adet = int.Parse(txtAdet.Text);
                if (txtFiyat.Text != "")
                    product.Fiyat = float.Parse(txtFiyat.Text);
                if (txtCategory.Text != "")
                    product.CategoryId = category.Id;
                if (cmbWarehouse.SelectedItem.ToString() != "")
                    product.WarehouseId = warehouse.Id;
                context.SaveChanges();

            }
            else
                MessageBox.Show("Bu ürün bulunmamaktadýr");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Product? product = context.Products.FirstOrDefault(p => p.ProductName.Equals(txtProduct.Text));
            if (product != null)
            {
                context.Remove(product);
                context.SaveChanges();

            }
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
    //            new Warehouse() { Id = 1, WarehouseName = "Ankara" },
    //            new Warehouse() { Id = 2, WarehouseName = "Ýstanbul" },
    //            new Warehouse() { Id = 3, WarehouseName = "Ýzmir" }
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