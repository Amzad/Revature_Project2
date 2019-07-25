using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revature_Project2API.Models
{
    public class Drink
    {
        [Key]
        public int DrinkID { get; set; }
        public string DrinkType { get; set; }

        public int OrderID { get; set; }
        public virtual Order Order { get; set; }

        public decimal Price { get; set; }

    }
}
