using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PizzaDetail
    {
        [Key]
        public int PizzaDetailID { get; set; }

        public decimal PizzaDetailPrice { get; set; }
        public virtual Order Order { get; set; }

        public int PizzaID { get; set; }
        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
