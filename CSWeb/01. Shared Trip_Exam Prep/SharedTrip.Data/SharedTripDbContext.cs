using System;
using Microsoft.EntityFrameworkCore;
using SharedTrip.Data.Models;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Data
{
    public class SharedTripDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<UserTrip> UserTrips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSettings.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(x => x.UserTrips)
                .WithOne(x => x.User).HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trip>().HasMany(x => x.UserTrips)
                .WithOne(x => x.Trip).HasForeignKey(x => x.TripId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserTrip>().HasKey(c => new { c.UserId, c.TripId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
