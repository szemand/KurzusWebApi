using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebApi_Server.Models;

namespace WebApi_Server.Repositories
{
    public static class CustomerRepository
    {
        private const string filename = "Customer.json";

        public static IEnumerable<Customer> GetCustomers()
        {
            if (File.Exists(filename))
            {
                var rawData = File.ReadAllText(filename);
                var people = JsonSerializer.Deserialize<IEnumerable<Customer>>(rawData);
                return people;
            }

            return new List<Customer>();
        }

        public static void StoreCustomers(IEnumerable<Customer> customers)
        {
            var rawData = JsonSerializer.Serialize(customers);
            File.WriteAllText(filename, rawData);
        }
    }
}
