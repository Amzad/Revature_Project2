using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Revature_Project2.Areas.Identity;
using Revature_Project2.Areas.Identity.Pages.Account;

namespace Revature_Project2.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public virtual string CustomerID { get; set; }

        public virtual RegisterModel.InputModel Customer { get; set; }
            



    }
}
