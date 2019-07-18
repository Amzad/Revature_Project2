using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Revature_Project2API.Data;
using Revature_Project2API.Models;

namespace Revature_Project2API.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

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
        public DbSet<Revature_Project2API.Models.Order> Order { get; set; }
        public DbSet<Revature_Project2API.Models.OrderDetail> OrderDetail { get; set; }
        public DbSet<Revature_Project2API.Models.Pizza> Pizza { get; set; }
        public DbSet<Revature_Project2API.Models.Topping> Topping { get; set; }
    }
}