using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Revature_Project2.Data;
using Revature_Project2.Models;

namespace Revature_Project2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


        //public DbSet<Topping> Toppings { get; set; }
        //public DbSet<Ham> Ham { get; set; }
       // public DbSet<Chicken> Chicken { get; set; }
       public DbSet<Customer> Customers { get; set; }


    }
}
