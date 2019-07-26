using Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace Entities.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //ree
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
        public DbSet<PizzaDetail> PizzaDetails { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Topping> Toppings { get; set; }
    
    
    }
}
