using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Watchlist.Data.Models
{
    [Comment("Table UserMovies")]
    public class UserMovie
    {
        [Comment("User Identifier")]
        [Required]
        public string UserId { get; set; }

        [Comment("User Entity")]
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Comment("Movie Identifier")]
        [Required]
        public int MovieId { get; set; }

        [Comment("Movie Entity")]
        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; }
    }
}