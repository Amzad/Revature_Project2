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


        //public virtual int OrderID { get; set; }
        public decimal PizzaDetailPrice { get; set; }

        //[JsonIgnore]
        //[IgnoreDataMember]
        public virtual Order Order { get; set; }


        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
