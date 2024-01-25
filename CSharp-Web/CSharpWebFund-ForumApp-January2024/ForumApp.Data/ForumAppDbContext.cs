using ForumApp.Data;
using ForumApp.Data.Models;

namespace Forum.App.Data
{
    using Microsoft.EntityFrameworkCore;
    using Configuration;

    public class ForumAppDbContext : DbContext
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Post> Posts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
