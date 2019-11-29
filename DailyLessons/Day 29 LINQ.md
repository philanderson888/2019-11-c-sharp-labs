# Day 29 - LINQ

# LINQ

Microsoft created a language called LINQ

LANGUAGE INTEGRATED QUERY

Queries are fairly simple get powerful

Two types of LINQ

    1) Query Comprehension : simple version
    
    2) Lambda 'Extension Methods' version

Use both in same query : full flexibility

    <ItemGroup>
    <PackageReference Include="microsoft.entityframeworkcore" Version="2.1.1" />
    <PackageReference Include="microsoft.entityframeworkcore.design" Version="2.1.1" />
    <PackageReference Include="microsoft.entityframeworkcore.sqlserver" Version="2.1.1" />
    </ItemGroup>

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.SqlServer;
    
    namespace Lab_14_LINQ
    {
        class Program
        {
    
            static List<Customer> customers = new List<Customer>();
            static List<ModifiedCustomer> modifiedcustomers = new List<ModifiedCustomer>();
            static List<Product> products = new List<Product>();
            static List<Category> categories = new List<Category>();
    
            static void Main(string[] args)
            {
                #region Explanation
                /*
                 * 1) Read NORTHWIND using ENTITY CORE 2.1.1
                 * 2) Basic LINQ
                 * 3) More advanced LINQ with LAMBDA
                 *     
                 *                 
                 // Nuget : microsoft.entityframeworkcore / .sqlserver / .design   v 2.1.1
                 // install-package microsoft.entityframeworkcore -v 2.1.1
                 */
                #endregion
    
                using(var db = new Northwind())
                {
                    customers = db.Customers.ToList();
    
                    // SIMPLE LINQ FROM LOCAL COLLCTION 
                    // WHOLE DATASET IS RETURNED (MORE DATA)
                    // IENUMERABLE ARRAY
                    var selectedCustomers =
                        from customer in customers
                        select customer;
    
                    // SAME QUERY OVER DATABASE DIRECTLY
                    // ONLY RETURN ACTUAL DATA WE NEED
                    // LAZY LOADING : QUERY IS NOT ACTUALLY EXECUTED!!!
                    // DATA HAS NOT ACTUALLY ARRIVED YET!
                    var selectedCustomers2 =
                        (from customer in db.Customers
                         where customer.City=="London" || customer.City=="Berlin"
                         where customer.ContactName != "Phil"
                         where customer.ContactName != "New Name"
                         orderby customer.ContactName
                        select customer).ToList();
                     // FORCE DATA BY PUSHING TO A LIST IE .ToList() or by taking aggregate eg Sum,Count
    
                    printCustomers(selectedCustomers2);
    
                    Console.WriteLine($"There are {selectedCustomers2.Count} records returned");
    
                    // CREATE CUSTOM OBJECT OUTPUT
                    var selectedCustomers3 =
                        (from customer in db.Customers
                        select new { 
                            Name = customer.ContactName,
                            Location = customer.City + " " + customer.Country
                        }).Take(10).Skip(10).ToList();
                    foreach (var c in selectedCustomers3)
                    {
                        Console.WriteLine($"{c.Name,-20}{c.Location}");
                    }
    
                    //or
    
                    var selectedCustomers4 =
                            (from c in db.Customers
                             select new 
                             ModifiedCustomer(c.ContactName,c.City+" "+c.Country))
                             .ToList();
    
    
                    // Grouping
                    // Group and list all customers by CITY
                    // CITY ... COUNT(CUSTOMER)
                    var selectedCustomers5 =
                        from cust in db.Customers
                        group cust by cust.City into Cities
                        where Cities.Count()>1
                        orderby Cities.Count() descending
                        select new { 
                          City = Cities.Key,
                          Count = Cities.Count()
                        };
                    foreach(var c in selectedCustomers5.ToList())
                    {
                        Console.WriteLine($"{c.City,-15}{c.Count}");
                    }
    
                    Console.WriteLine("\\n\\nList of Products Inner Join Category Showing Name\\n" +
                        "======================================================\\n");
                    var listofproducts =
                        (from p in db.Products
                         join c in db.Categories
                         on p.CategoryID equals c.CategoryID
                         select new
                         {
                             ID = p.ProductID,
                             Name = p.ProductName,
                             Category = c.CategoryName
                         }).ToList();
                    listofproducts.ForEach(p => 
                        Console.WriteLine($"{p.ID,-15}{p.Name,-30}{p.Category}"));
    
    
                    Console.WriteLine("\\n\\nNow Print Off The Same List But Using Much Smarter\\n" +
                        "'dot' Notation To Join Tables\\n");
                    // read in products and categories
                    products = db.Products.ToList();
                    categories = db.Categories.ToList();
                    products.ForEach(p => 
                        Console.WriteLine($"{p.ProductID,-15}{p.ProductName,-30}{p.Category.CategoryName}"));
    
                    Console.WriteLine("\\n\\nList Categories With Count of Products And Sub-List Of Product Names\\n");
                    categories.ForEach(c =>
                        {
                            Console.WriteLine($"{c.CategoryID,-5}{c.CategoryName,-15} has {c.Products.Count} products");
                            // loop within loop
                            foreach(var p in c.Products)
                            {
                                Console.WriteLine($"\\t\\t\\t\\t{p.ProductID,-5}{p.ProductName}");
                            }
                        }
                     );
    
    
                    Console.WriteLine($"\\n\\nLINQ Lambda Notation\\n");
                    customers = db.Customers.ToList();
                    Console.WriteLine($"Count is {customers.Count}");
                    Console.WriteLine($"Count is {db.Customers.Count()}");
    
    
                    // Select ... Distinct
                    Console.WriteLine("\\n\\nList Of Cities : Select ... Distinct...OrderBy\\n");
                    Console.WriteLine("Using SELECT to SELECT ONE COLUMN\\n");
                    var cityList = db.Customers.Select(c => c.City).Distinct().OrderBy(c=>c).ToList();
                    cityList.ForEach(city => Console.WriteLine(city));
    
    
                    Console.WriteLine("\\n\\nContains (same as SQL LIKE)\\n");
                    var cityListFiltered =
                        db.Customers
                            .Select(c => c.City)
                            .Where(city => city.Contains("o"))
                            .Distinct()
                            .OrderBy(c => c)
                            .ToList();
                    cityListFiltered.ForEach(city => Console.WriteLine(city));
    
                }
            }
    
            static void printCustomers(List<Customer> customers)
            {
                customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-10}" +
                    $"{c.ContactName,-30}{c.CompanyName,-40}{c.City}"));
            }
        }
    
        #region DatabaseContextAndClasses
        // connect to database
    
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
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security = true;" + "MultipleActiveResultSets=true;");
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
    
        public class ModifiedCustomer { 
            public string Name { get; set; }
            public string Location { get; set; }
    
            public ModifiedCustomer(string Name,string Location)
            {
                this.Name = Name;
                this.Location = Location;
            }
        }
        #endregion
    }