using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookViewModel
    {
        /// <summary>
        /// Book Identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Book Title
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = null!;
        /// <summary>
        /// Book Author
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Author { get; set; } = null!;

        /// <summary>
        /// Book Image URL
        /// </summary>
        [Required]
        [MinLength(5)]
        public string ImageUrl { get; set; } = null!;
        /// <summary>
        /// Book Rating
        /// </summary>
        [Required]
        public decimal Rating { get; set; }
        /// <summary>
        /// Book Description
        /// </summary>
        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string Description { get; set; } = null!;
        /// <summary>
        /// Book Category Identifier
        /// </summary>
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; } 
    }
}
