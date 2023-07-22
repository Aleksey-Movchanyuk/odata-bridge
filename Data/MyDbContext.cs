using Microsoft.EntityFrameworkCore;

using ODataBridge.Models;

namespace ODataBridge.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sales>().HasKey(s => new { s.PeriodKey, s.ProductKey, s.RegionKey });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Period> Periods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Sales> Sales { get; set; }
    }
}
