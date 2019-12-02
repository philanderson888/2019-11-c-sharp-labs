using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17_Northwind_Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var testInstance = new NorthwindCustomers();
            var actual = testInstance.NumberOfNorthwindCustomers(null);
            Console.WriteLine(actual);
            var actualLondon = testInstance.NumberOfNorthwindCustomers("London");
            Console.WriteLine(actualLondon);
        }
    }

    public class NorthwindCustomers
    {
        static List<Customer> customers = new List<Customer>();
        public int NumberOfNorthwindCustomers(string city)
        {
            using (var db = new NorthwindEntities())
            {
                if(city==null || city == "")
                {
                    return db.Customers.Count();
                }
                else
                {
                    return db.Customers.Where(c => c.City == city).Count();
                }
            }
        }
    }


}
