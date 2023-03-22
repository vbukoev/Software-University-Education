namespace Artillery.Data
{
    using Artillery.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Reflection.Emit;

    public class ArtilleryContext : DbContext
    {
        public ArtilleryContext() { }

        public ArtilleryContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryGun> CountriesGuns { get; set; }
        public DbSet<Gun> Guns { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Shell> Shells { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CountryGun>(entity =>
            {
                entity.HasKey(ab => new { ab.CountryId, ab.GunId });
                entity.HasOne(c => c.Country).WithMany(x => x.CountriesGuns).HasForeignKey(x => x.CountryId);
                entity.HasOne(g => g.Gun).WithMany(x => x.CountriesGuns).HasForeignKey(x => x.GunId);
            });
        }
    }
}
