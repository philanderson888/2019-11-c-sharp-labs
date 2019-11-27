using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Lab_07_Northwind_SQLITE
{
   
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {
            printCustomers();
        }
        #region printCustomers
        static void printCustomers()
        {
            using (var db = new NorthwindDbContext())
            {
                customers = db.Customers.Where(c=>c.City=="London").ToList();
            }
            customers.ForEach(c => Console.WriteLine(c.CustomerID));
        }
        #endregion
    }


    class Customer {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    class NorthwindDbContext : DbContext { 
        
        // Match TABLE Customers IN DB
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite(@"Data Source=C:\Engineering45\SQLite\Northwind.db");
        }
    }
}
