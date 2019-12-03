using System;
using Lab_22_Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Lab_24_Serialize_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1, "Billy", "NR2234B71");
            var customer2 = new Customer(2, "Mary", "CB345678G");
            var customers = new List<Customer>() { customer, customer2 };


            // formatter : allow us to serialise to Binary
            var formatter = new BinaryFormatter();

            // stream to FILE
            using (var stream = new FileStream("data.bin", FileMode.Create, 
                FileAccess.Write, FileShare.None))
            {
                // write to file
                formatter.Serialize(stream, customers);
            }

            // read back
            //var BinaryString = File.ReadAllText("data.bin");
            var customersBinary = new List<Customer>();
            using (var reader = File.OpenRead("data.bin"))
            {
                // deserialise
                customersBinary = formatter.Deserialize(reader) as List<Customer>;
            }

            customersBinary.ForEach(c => Console.WriteLine($"{c.CustomerID} {c.CustomerName}"));
            


        }
    }



}
