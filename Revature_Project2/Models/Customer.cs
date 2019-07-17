using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revature_Project2.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerAddress { get; set; }
        [Phone]
        public string CustomerPhoneNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}
