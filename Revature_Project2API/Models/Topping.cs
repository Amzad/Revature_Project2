using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revature_Project2API.Models
{
    public class Topping
    {
        [Key]
        public int ToppingID { get; set; }
        public string ToppingName { get; set; }
        public decimal ToppingPrice { get; set; }
        public string ToppingType { get; set; }

        public int PizzaID { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
