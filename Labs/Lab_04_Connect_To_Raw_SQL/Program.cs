using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Lab_04_Connect_To_Raw_SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            // @ means take LITERALLY WHAT'S IN THE FOLLOWING STRING
            // IE NO 'escaping' of characters allowed
            //  Example @"C:\folder\file"  IS GOOD
            //           "C:\\folder\\file"   ESCAPING BACKSLASH 
            string connectionString = @"Data Source=(localdb)\mssqllocaldb;
                            Initial Catalog=Northwind";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine(connection.State);

                // READ FROM DATABASE
                using (var sqlCommand = new SqlCommand("SELECT * FROM CUSTOMERS", connection))
                {
                    // create a loop to read and iterate and parse data
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    // loop while data present
                    while (reader.Read())
                    {
                        string CustomerID = reader["CustomerID"].ToString();
                        string ContactName = reader["ContactName"].ToString();
                        Console.WriteLine($"{CustomerID,-15}{ContactName}");
                    }
                }
            }
        }
    }
}
