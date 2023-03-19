namespace VaporStore.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;
    using System.Collections.Generic;
    using System.Reflection.Emit;

    public class VaporStoreDbContext : DbContext
    {
        public VaporStoreDbContext()
        {

        }

        public VaporStoreDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Developer> Developers { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<GameTag> GameTags { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<GameTag>(entity =>
            {
                entity.HasKey(gt => new { gt.GameId, gt.TagId });
            });
        }
    }
}