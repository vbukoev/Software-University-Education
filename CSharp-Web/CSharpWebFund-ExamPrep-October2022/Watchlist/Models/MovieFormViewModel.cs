using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Watchlist.Data.Models;
using static Watchlist.Data.Models.DataConstants.Genre;
using static Watchlist.Data.Models.DataConstants.ErrorMessages;
using static Watchlist.Data.Models.DataConstants.Movie;

namespace Watchlist.Models
{
    public class MovieFormViewModel
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(MovieTitleMaxLength, MinimumLength = MovieTitleMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Title{ get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(MovieDirectorMaxLength, MinimumLength = MovieDirectorMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Director { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Precision(18,2)]
        [Range(typeof(decimal), "0", "10")]
        public decimal Rating { get; set; }

        public int GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
    }
}
