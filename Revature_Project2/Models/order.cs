using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Revature_Project2.Data;

namespace Revature_Project2.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public DateTime OrderDateTime { get; set; }

        public decimal OrderPrice { get; set; }
        public virtual string CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<PizzaDetail> PizzaDetails { get; set; }
       
        public virtual ICollection<Drink> Drinks { get; set; }

        // public virtual RegisterModel.InputModel Customer { get; set; }




    }
}
