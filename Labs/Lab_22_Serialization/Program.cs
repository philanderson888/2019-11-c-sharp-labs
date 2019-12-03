using System;
// SoapFormatter Nuget
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Collections.Generic;

namespace Lab_22_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1,"Billy","NR2234B71");
            var customer2 = new Customer(2, "Mary", "CB345678G");
            var customers = new List<Customer>() { customer, customer2 };


            // serialise customer to XML format
            // create object for serialisation
            // SOAP = Simple Object Access Protocol = 
                    // XML Transmission mechanism
            var formatter = new SoapFormatter();

            // stream customer to File WRITE
            // About to STREAM DATA TO XML FILE : Each time CREATE NEW FILE
            using (var stream = new FileStream
                    ("data.xml", FileMode.Create, FileAccess.Write, 
                                FileShare.None))
            {
                // Serialise data to XML as a STREAM OF DATA AND 
                //   SEND TO THE FILE STREAM
                formatter.Serialize(stream, customers);
            }

            // Print out file
            Console.WriteLine(File.ReadAllText("data.xml"));

            // Reverse

            var customersFromXMLFile = new List<Customer>();
            // stream READ
            using (var reader = File.OpenRead("data.xml"))
            {
                // deserialize XML=> Customer
                customersFromXMLFile = formatter.Deserialize(reader) as List<Customer>;
            }

            //and print
            customersFromXMLFile.ForEach(c => Console.WriteLine($"{c.CustomerID,-5} , {c.CustomerName}"));
        }
    }

    [Serializable]
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

       [NonSerialized]
        private string NINO;  // opt out

        public Customer(int ID, string Name, string Nino)
        {
            this.CustomerID = ID;
            this.CustomerName = Name;
            this.NINO = Nino;
        }
    }

}
