using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class AllBookViewModel
    {
        /// <summary>
        /// Book Identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Book Title
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// Book Author
        /// </summary>
        public string Author { get; set; } = null!;
        /// <summary>
        /// Book Image URL
        /// </summary>
        public string ImageUrl { get; set; } = null!;
        /// <summary>
        /// Book Rating
        /// </summary>
        public decimal Rating { get; set; }
        /// <summary>
        /// Book Description
        /// </summary>
        public string? Description { get; set; } 
        /// <summary>
        /// Book Category
        /// </summary>
        public string Category { get; set; } = null!;
    }
}