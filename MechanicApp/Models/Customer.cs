using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerApp.Models
{
    public class Customer
    {
        public long Id { get; set; }

        [Required]
        [RegularExpression(@"[\w ]*[^\W_][\w ]*")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"[\w ]*[^\W_][\w ]*")]
        public string CarType { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{3}-\d{3}$")]
        public string LicensePlate { get; set; }

        [Required]
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DateAdded { get; set; }
    }
}