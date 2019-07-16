using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revature_Project2.Models
{
    public class Topping
    { 
        [Key]
        public int ID { get; set; }
        public decimal Price { get;set; }
        //public ToppingType Type { get; set; }
    }
}
