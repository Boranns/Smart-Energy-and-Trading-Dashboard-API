using Microsoft.EntityFrameworkCore;
using SmartEnergyAPI.Entities;

namespace SmartEnergyAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<EnergyProduct> EnergyProduct { get; set; }
        public DbSet<Trade> Trade { get; set; }
        public DbSet<Portfolio> Portfolio { get; set; }
        public DbSet<Alert> Alert { get; set; }
    }
}
