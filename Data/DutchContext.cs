using System;
using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DutchTreat.Data {
    public class DutchContext : DbContext {
        public DutchContext(DbContextOptions<DutchContext> options) : base(options){}
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        /*
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql ("Host=localhost;Database=DutchTreadDb;Username=;" +
                                      "Password=Shaku786"); */

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
                .HasData(new Order()
                {
                    Id = 1,
                    OrderDate = DateTime.UtcNow,
                    OrderNumber = "12345"

                });
            
        }
    }
}
