using ForumApp.Common.Validations;
using ForumApp.Data;
using ForumApp.Data.Models;

namespace ForumApp.Services
{
    using Forum.App.Data;
    using Interfaces;
    using ViewModels.Post;
    using Microsoft.EntityFrameworkCore;
    public class PostService : IPostService
    {
        private readonly ForumAppDbContext dbContext;

        public PostService(ForumAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<PostListViewModel>> ListAllAsync()
        {
            IEnumerable<PostListViewModel> allPosts = await dbContext
                .Posts
                .Select(p => new PostListViewModel()
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Content = p.Content,
                })
                .ToArrayAsync();
            return allPosts;
        }

        public async Task AddPostAsync(PostAddFormModel postViewModel)
        {
            Post newPost = new Post()
            {
                Title = postViewModel.Title,
                Content = postViewModel.Content,
            };
            await this.dbContext.Posts.AddAsync(new Post());
            await this.dbContext.SaveChangesAsync();
        }
    }
}
