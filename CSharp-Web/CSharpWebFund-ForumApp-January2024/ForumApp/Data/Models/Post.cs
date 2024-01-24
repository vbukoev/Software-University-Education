using System.ComponentModel.DataAnnotations;
using static Forum.App.Data.DataConstants.Post;
namespace Forum.App.Data.Models
{
    public class Post
    {
        public int Id { get; init; }
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;
        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;
    }
}
