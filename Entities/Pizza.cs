using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaID { get; set; }
        public string PizzaType { get; set; }
        public string PizzaSize { get; set; }
        public string PizzaSauce { get; set; }
        public string PizzaBread { get; set; }
        public bool PizzaCheese { get; set; }

        public decimal PizzaPrice { get; set; }
        public int PizzaDetailID { get; set; }
        public virtual Order Order { get; set; }

        public virtual ICollection<Topping> Toppings { get; set; }
        
        
    }
}
