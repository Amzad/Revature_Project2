using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Revature_Project2API.Data;

namespace Revature_Project2API.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public DateTime OrderDateTime { get; set; }

        public decimal OrderPrice { get; set; }
        public virtual string CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
 
       // public virtual RegisterModel.InputModel Customer { get; set; }
            



    }
}
