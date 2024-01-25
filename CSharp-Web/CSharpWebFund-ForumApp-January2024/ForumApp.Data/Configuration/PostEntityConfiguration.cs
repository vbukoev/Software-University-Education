using ForumApp.Data;
using ForumApp.Data.Models;
using ForumApp.Data.Seeding;

namespace Forum.App.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        private readonly PostSeeder postSeeder;

        public PostEntityConfiguration()
        {
            this.postSeeder = new PostSeeder();
        }
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(this.postSeeder.GeneratePosts().ToArray());
        }
    }
}
