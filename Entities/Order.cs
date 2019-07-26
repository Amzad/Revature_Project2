using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public DateTime OrderDateTime { get; set; }

        public decimal OrderPrice { get; set; }

        //public string CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
        public virtual ICollection<Drink> Drinks { get; set; }



    }
}
