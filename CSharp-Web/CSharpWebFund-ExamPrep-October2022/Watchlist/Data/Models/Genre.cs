using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static Watchlist.Data.Models.DataConstants.Genre;

namespace Watchlist.Data.Models
{
    [Comment("Table Genre")]
    public class Genre
    {
        [Comment("Genre Identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Genre Name")]
        [Required]
        [StringLength(GenreNameMaxLength)]
        public string Name { get; set; } = null!;

        [Comment("Genre Collection")]
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}