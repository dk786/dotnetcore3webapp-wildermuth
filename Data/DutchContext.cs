using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DutchTreat.Data {
    public class DutchContext : DbContext {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql ("Host=localhost;Database=DutchTreadDb;Username=Shaku;Password=Shaku786");

    }
}