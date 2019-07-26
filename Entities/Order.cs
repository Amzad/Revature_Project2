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

        //[JsonIgnore]
        //[IgnoreDataMember]
        public virtual Customer Customer { get; set; }

        //[JsonIgnore]
        //[IgnoreDataMember]
        public virtual ICollection<PizzaDetail> PizzaDetails { get; set; }

        //[JsonIgnore]
        //[IgnoreDataMember]
        public virtual ICollection<Drink> Drinks { get; set; }

        // public virtual RegisterModel.InputModel Customer { get; set; }




    }
}
