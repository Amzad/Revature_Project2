using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Revature_Project2.Areas.Identity.Pages.Account;
using Revature_Project2.Data;
using Revature_Project2.Models;

namespace Revature_Project2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //ree
        }


        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /*builder.Entity<Order>()
                           .HasOne(u => u.Customer)
                           .WithMany(a => a.Orders)
                           .HasForeignKey(k => k.CustomerID)
                           .HasConstraintName("CustomerID")
                           .OnDelete(DeleteBehavior.Cascade)
                           .IsRequired();*/
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<PizzaDetail> PizzaDetails { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Topping> Toppings { get; set; }
    
    
    }
}
