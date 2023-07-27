using Disaster_Alleviation_Web.Models.Donation;
using Disaster_Alleviation_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Alleviation_Web.Data
{
    public class DisasterReliefContext : DbContext
    {
        // DB connection properties injected automatically
        public DisasterReliefContext()
        {

        }

        // DB connection properties given explicitly (for Unit Tests)
        public DisasterReliefContext(DbContextOptions<DisasterReliefContext> options) : base(options)
        {
        }

        public DbSet<Monetary> Monetaries { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Disaster> Disasters { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AidType> AidTypes { get; set; }
        public DbSet<GoodsPurchase> GoodsPurchases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Monetary>().ToTable("Monetary");
            modelBuilder.Entity<Good>().ToTable("Good");
            modelBuilder.Entity<Disaster>().ToTable("Disaster");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<AidType>().ToTable("AidType");
            modelBuilder.Entity<GoodsPurchase>().ToTable("GoodsPurchase");
        }
    }
}
