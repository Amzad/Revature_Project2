using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revature_Project2.Models
{
    public class Drink
    {
        [Key]
        public int DrinkID { get; set; }
        public string Drinks { get; set; }
        public virtual int OrderDetailsId { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }
    }
}
