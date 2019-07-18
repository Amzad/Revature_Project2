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


        //public DbSet<Topping> Toppings { get; set; }
        //public DbSet<Ham> Ham { get; set; }
        // public DbSet<Chicken> Chicken { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Order>()
                           .HasOne(u => u.Customer)
                           .WithMany(a => a.Orders)
                           .HasForeignKey(k => k.CustomerID)
                           .HasConstraintName("CustomerID")
                           .OnDelete(DeleteBehavior.Cascade)
                           .IsRequired();
        }
    }
}
