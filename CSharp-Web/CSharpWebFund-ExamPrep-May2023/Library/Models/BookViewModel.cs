using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Author { get; set; } = null!;
        [Required]
        [MinLength(5)]
        public string ImageUrl { get; set; } = null!;
        [Required]
        public decimal Rating { get; set; }
        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string Description { get; set; } = null!;
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; } 
    }
}
