using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;



namespace Lab_20_Northwind_Products
{
    class Program
    {

        static void Main(string[] args)
        {
           using (var db = new Northwind())
            {

            }
        }
    }

    public class NorthwindProductTest
    {

        #region TestNumberOfProductsStartingWithAndContainingAParticularLetter
        public int TestNumberOfProductsStartingWithP()
        {
            using (var db = new Northwind())
            {
                string inputLetter = "p";
                var products1 =  db.Products.Where
                    (p => 
                        p.ProductName.StartsWith("p") || 
                        p.ProductName.StartsWith("P"))
                    .Count();

                var products = (
                    from product in db.Products
                    where product.ProductName.StartsWith("p")
                    select product
                    );
                var products2 =
                    db.Products
                        .Where(p => 
                        p.ProductName.StartsWith(inputLetter.ToUpper()) || 
                        p.ProductName.StartsWith(inputLetter.ToLower()))
                        .Count();
                var products3 =
                    db.Products.Where(p => p.ProductName.StartsWith(inputLetter))
                    .Count();
                return products3;
            }
        }

        public int TestNumberOfProductsStartingWithALetter(string letter)
        {
            using (var db = new Northwind())
            {
                var productCount = 
                    db.Products
                    .Where(p => p.ProductName.StartsWith(letter))
                    .Count();
                return productCount;
            }
        }

        public int TestNumberOfProductsContainingALetter(string letter)
        {
            using (var db = new Northwind())
            {
                var productCount =
                    db.Products
                    .Where(p => p.ProductName.Contains(letter))
                    .Count();
                return productCount;
            }
        }
        #endregion

    }


    #region NorthwindContextAndClasses
    public partial class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            this.Products = new List<Product>();
        }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public short? UnitsOnOrder { get; set; } = 0;
        public short? ReorderLevel { get; set; } = 0;
        public bool Discontinued { get; set; } = false;
    }

    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security = true;" + "MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            // define a one-to-many relationship
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);

            modelBuilder.Entity<Product>()
                .Property(c => c.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products);
        }
    }

    #endregion
}
