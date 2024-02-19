using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Watchlist.Contracts;
using Watchlist.Data;
using Watchlist.Models;

namespace Watchlist.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMovieService data;

        public MoviesController(IMovieService movieService)
        {
            data = movieService;
        }

        public async Task<IActionResult> All()
        {
            return View(await data.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new MovieFormViewModel
            {
                Genres = await data.GetGenresAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await data.AddMovie(model);
                return RedirectToAction(nameof(All), "Movies");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int movieId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await data.AddMovieToCollection(movieId, userId);
            }
            catch (Exception)
            {
                throw;
            }
            
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Watched()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(await data.GetWatchedAsync(userId));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await data.RemoveMovieFromCollection(movieId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(Watched));
        }
    }
}
