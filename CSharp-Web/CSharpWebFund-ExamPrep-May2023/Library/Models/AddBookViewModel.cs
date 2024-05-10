using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class AddBookViewModel
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
        [Required(AllowEmptyStrings = false)]
        public string Url { get; set; } = null!;
        /// <summary>
        /// Book Rating
        /// </summary>
        [Required]
        public string Rating { get; set; } = null!;
        /// <summary>
        /// Book Description
        /// </summary>
        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string Description { get; set; } = null!;
        /// <summary>
        /// Category Identifier
        /// </summary>
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }
        /// <summary>
        /// Collection of Categories
        /// </summary>

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
