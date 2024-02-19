using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Watchlist.Contracts;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Models;

namespace Watchlist.Services
{
    [Authorize]
    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext data;

        public MovieService(WatchlistDbContext context)
        {
            data = context;
        }

        public async Task AddMovie(MovieFormViewModel model)
        {
            var movie = new Movie
            {
                Director = model.Director,
                GenreId = model.GenreId,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                Title = model.Title,
            };

            await data.Movies.AddAsync(movie);
            await data.SaveChangesAsync();
        }

        public async Task AddMovieToCollection(int movieId, string userId)
        {
            var user = await data
                .Users
                .Where(x => x.Id == userId)
                .Include(x => x.UsersMovies)
                .FirstOrDefaultAsync();

            var movie = await data.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            if (movie == null)
            {
                throw new ArgumentException("Movie not found");
            }

            if (user.UsersMovies.All(x => x.MovieId != movieId))
            {
                user.UsersMovies.Add(new UserMovie()
                {
                    UserId = userId,
                    MovieId = movieId,
                });
            }
            await data.SaveChangesAsync();
        }

        public async Task<IEnumerable<MovieInfoViewModel>> GetAllAsync()
        {
            var movies = await data.Movies
                .Include(m => m.Genre)
                .ToListAsync();

            return movies.Select(m => new MovieInfoViewModel(
                m.Id,
                m.Title,
                m.Director,
                m.ImageUrl,
                m.Rating,
                m.Genre.Name));
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await data.Genres.ToListAsync();
        }

        public async Task<IEnumerable<MovieInfoViewModel>> GetWatchedAsync(string userId)
        {
            var user = await data.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .ThenInclude(um => um.Movie)
                .ThenInclude(m => m.Genre)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new InvalidOperationException("Invalid userId");
            }

            return user.UsersMovies
                .Select(um => new MovieInfoViewModel(um.MovieId, um.Movie.Title, um.Movie.Director, um.Movie.ImageUrl, um.Movie.Rating, um.Movie.Genre.Name)
                );
        }
        public async Task RemoveMovieFromCollection(int movieId, string userId)
        {
            var user = await data.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync();

            var movie = user?.UsersMovies
                .FirstOrDefault(m => m.MovieId == movieId);

            if (user == null)
            {
                throw new ArgumentException("Invalid userId");
            }

            if (movie == null)
            {
                throw new ArgumentException("Invalid movieId");
            }
            user.UsersMovies.Remove(movie);

            await data.SaveChangesAsync();
        }
    }

}

