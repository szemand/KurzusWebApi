using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerApp.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CarType { get; set; }
        public string LicensePlate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DateAdded { get; set; }
    }
}