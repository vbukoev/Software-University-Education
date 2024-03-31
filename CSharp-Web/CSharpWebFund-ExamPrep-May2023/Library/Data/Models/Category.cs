using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Models
{
    [Comment("Categories for the Library")]
    public class Category
    {
        [Comment("Category's unique identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Name of the category")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Comment("Collection of Books")]
        public List<Book> Books { get; set; } = new List<Book>();
    }
}

