using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static Watchlist.Data.Models.DataConstants.Movie;

namespace Watchlist.Data.Models
{
    [Comment("Table Movie")]
    public class Movie
    {
        [Comment("Movie Identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Movie Title")]
        [Required]
        [StringLength(MovieTitleMaxLength)]
        public string Title { get; set; }

        [Comment("Movie Director")]
        [Required]
        [StringLength(MovieDirectorMaxLength)]
        public string Director { get; set; }

        [Comment("Movie Image")]
        [Required]
        public string ImageUrl { get; set; }

        [Comment("Movie Rating")]
        [Required]
        public decimal Rating { get; set; }

        [Comment("Movie Genre Identifier")]
        [Required]
        public int? GenreId { get; set; }

        [Comment("Genre Entity")]
        [ForeignKey(nameof(GenreId))]
        public Genre? Genre { get; set; }

        [Comment("UserMovies Collection")]
        public List<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();
    }
}