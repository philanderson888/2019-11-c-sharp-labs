using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Lab_23_Serialize_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1, "Billy", "NR2234B71");
            var customer2 = new Customer(2, "Mary", "CB345678G");
            var customer3 = new Customer(3, "John", "DZ345678G");
            var customers = new List<Customer>() { customer, customer2,customer3 };

            // serialise
            var JSONCustomerList = JsonConvert.SerializeObject(customers);

            // peek at this object
            Console.WriteLine(JSONCustomerList);

            // Save to file (JSON)
            File.WriteAllText("data.json", JSONCustomerList);

            // read
            var JSONstring = File.ReadAllText("data.json");
            // deserialize
            var customersFromJSON =
                JsonConvert.DeserializeObject<List<Customer>>(JSONstring);

            // print
            customersFromJSON.ForEach(c => Console.WriteLine($"{c.CustomerID,-10 },{c.CustomerName,-10}"));
        }
    }

    [Serializable]
    class Customer
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
