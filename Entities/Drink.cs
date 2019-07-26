using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Drink
    {
        [Key]
        public int DrinkID { get; set; }
        public string DrinkType { get; set; }

        //public int OrderID { get; set; }
        //[JsonIgnore]
        //[IgnoreDataMember]
        public virtual Order Order { get; set; }

        public decimal Price { get; set; }

    }
}
