using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Entities.Data;
using Entities.Models;

namespace Revature_Project2API.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        
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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Drink> Drinks { get; set; }
    }
}