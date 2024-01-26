using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApp.ViewModels.Post;

namespace ForumApp.Services.Interfaces
{
    public interface IPostService 
    {
        Task<IEnumerable<PostListViewModel>> ListAllAsync();

        Task AddPostAsync(PostAddFormModel postViewModel);

        Task<PostAddFormModel> GetForEditOrDeleteByIdAsync(string id);
        
        Task EditByIdAsync(string id, PostAddFormModel postEditedModel);

        Task DeleteByIdAsync(string id);
    }
}
