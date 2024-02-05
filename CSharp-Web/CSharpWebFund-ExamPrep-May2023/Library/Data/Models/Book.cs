using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Models
{
    [Comment("Books for the Library")]
    public class Book
    {
        [Comment("Book's unique identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Title of the book")]
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [Comment("Author of the book")]
        [Required]
        [MaxLength(50)]
        public string Author { get; set; }


        [Comment("Description of the book")]
        [Required]
        [MaxLength(5000)]
        public string Description { get; set; }

        [Comment("URL of the book's cover image")]
        [Required(AllowEmptyStrings = false)]
        public string ImageUrl { get; set; } = null!;

        [Comment("Rating of the book")]
        [Required]
        public decimal Rating { get; set; }

        [Comment("CategoryId of the book")]
        [Required]
        public int CategoryId { get; set; }

        [Comment("Category of the book")]
        [Required]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        [Comment("Users who have the book")]
        public List<IdentityUserBook> UsersBooks { get; init; } = new List<IdentityUserBook>();
    }
}


