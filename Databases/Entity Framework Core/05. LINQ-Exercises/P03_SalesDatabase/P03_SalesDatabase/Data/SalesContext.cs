
namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;
    public class SalesContext : DbContext
    {
        public SalesContext() 
           : base ()
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
              .Property(t => t.Name)
              .IsRequired(true)
              .IsUnicode(true)
              .HasMaxLength(50);

            modelBuilder.Entity<Customer>()
              .Property(t => t.Name)
              .IsRequired(true)
              .IsUnicode(true)
              .HasMaxLength(100);

            modelBuilder.Entity<Customer>()
             .Property(t => t.Email)
             .IsRequired(true)
             .IsUnicode(false)
             .HasMaxLength(80);

            modelBuilder.Entity<Store>()
             .Property(t => t.Name)
             .IsRequired(true)
             .IsUnicode(true)
             .HasMaxLength(80);
        }
    }
}
