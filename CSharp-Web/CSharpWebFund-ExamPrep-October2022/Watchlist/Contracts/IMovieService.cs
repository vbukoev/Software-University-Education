using Watchlist.Data.Models;
using Watchlist.Models;

namespace Watchlist.Contracts
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieInfoViewModel>> GetAllAsync();

        Task<IEnumerable<Genre>> GetGenresAsync();

        Task AddMovie(MovieFormViewModel model);

        Task AddMovieToCollection(int movieId, string userId);

        Task RemoveMovieFromCollection(int movieId, string userId);

        Task<IEnumerable<MovieInfoViewModel>> GetWatchedAsync(string userId);

    }
}
