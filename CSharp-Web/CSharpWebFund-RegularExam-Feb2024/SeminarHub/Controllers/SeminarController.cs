using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Data.Entities;
using SeminarHub.Models;
using System.Globalization;
using System.Security.Claims;

namespace SeminarHub.Controllers
{
    [Authorize]
    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext data;

        public SeminarController(SeminarHubDbContext context)
        {
            data = context;
        }
        public async Task<IActionResult> All()
        {
            var seminars = await data.Seminars
                .AsNoTracking()
                .Select(s => new SeminarInfoViewModel(
                    s.Id,
                    s.Topic,
                    s.Lecturer,
                    s.DateAndTime,
                    s.Organizer.UserName,
                    s.Category.Name))
                .ToListAsync();

            return View(seminars);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new SeminarFormViewModel();

            model.Categories = await GetCategories();

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Add(SeminarFormViewModel model)
        {
            DateTime dateAndTime = DateTime.Now;

            if (!DateTime.TryParseExact(model.DateAndTime, DataConstants.DateTimeFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out dateAndTime))
            {
                ModelState.AddModelError(nameof(model.DateAndTime), $"Invalid date and time. Format must be: {DataConstants.DateTimeFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();
                return View(model);
            }

            var entity = new Seminar
            {
                Topic = model.Topic,
                Lecturer = model.Lecturer,
                Details = model.Details,
                DateAndTime = dateAndTime,
                Duration = model.Duration,
                OrganizerId = GetUserId(),
                CategoryId = model.CategoryId
            };

            await data.Seminars.AddAsync(entity);
            await data.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Details(int id)
        {
            var seminar = await data.Seminars
                .AsNoTracking()
                .Where(s => s.Id == id)
                .Select(s => new SeminarDetailsViewModel
                {
                    Id = s.Id,
                    Topic = s.Topic,
                    Lecturer = s.Lecturer,
                    DateAndTime = s.DateAndTime.ToString(DataConstants.DateTimeFormat),
                    Organizer = s.Organizer.UserName,
                    Category = s.Category.Name,
                    Details = s.Details,
                    Duration = s.Duration
                })
                .FirstOrDefaultAsync();

            if (seminar == null)
            {
                return BadRequest();
            }

            return View(seminar);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var seminar = await data.Seminars.FindAsync(id);
            if (seminar == null)
            {
                return BadRequest();
            }

            if (seminar.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new SeminarFormViewModel
            {
                Topic = seminar.Topic,
                Lecturer = seminar.Lecturer,
                DateAndTime = seminar.DateAndTime.ToString(DataConstants.DateTimeFormat),
                Details = seminar.Details,
                Duration = seminar.Duration,
                CategoryId = seminar.CategoryId,
                Categories = await GetCategories()
            };

            model.Categories = await GetCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SeminarFormViewModel model, int id)
        {
            var seminar = await data.Seminars.FindAsync(id);
            if (seminar == null)
            {
                return BadRequest();
            }

            if (seminar.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            DateTime dateAndTime = DateTime.Now;

            if (!DateTime.TryParseExact(model.DateAndTime, DataConstants.DateTimeFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out dateAndTime))
            {
                ModelState.AddModelError(nameof(model.DateAndTime), $"Invalid date and time. Format must be: {DataConstants.DateTimeFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();
                return View(model);
            }
            seminar.Topic = model.Topic;
            seminar.Lecturer = model.Lecturer;
            seminar.Details = model.Details;
            seminar.DateAndTime = dateAndTime;
            seminar.Duration = model.Duration;
            seminar.CategoryId = model.CategoryId;

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Join(int id)
        {
            var seminar = await data.Seminars
                .Where(s => s.Id == id)
                .Include(s => s.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (seminar == null)
            {
                return BadRequest();
            }

            var alreadyJoined = seminar.SeminarsParticipants.Any(sp => sp.ParticipantId == GetUserId());

            string userId = GetUserId();

            if (alreadyJoined)
            {
                return RedirectToAction(nameof(All));
            }

            if (seminar.SeminarsParticipants.All(s => s.ParticipantId != userId))
            {
                seminar.SeminarsParticipants.Add(new SeminarParticipant
                {
                    SeminarId = id,
                    ParticipantId = userId
                });

                await data.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Joined));
        }

        public async Task<IActionResult> Joined()
        {
            string userId = GetUserId();
            var seminars = await data.SeminarsParticipants
                .AsNoTracking()
                .Where(sp => sp.ParticipantId == userId)
                .Select(sp => new SeminarInfoViewModel(
                                       sp.Seminar.Id,
                                       sp.Seminar.Topic,
                                       sp.Seminar.Lecturer,
                                       sp.Seminar.DateAndTime,
                                       sp.Seminar.Organizer.UserName,
                                       sp.Seminar.Category.Name))
                .ToListAsync();

            return View(seminars);
        }

        public async Task<IActionResult> Leave(int id)
        {
            var seminar = await data.Seminars
                .Where(s => s.Id == id)
                .Include(s => s.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (seminar == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            var participant = seminar.SeminarsParticipants
                .FirstOrDefault(sp => sp.ParticipantId == userId);

            if (participant != null)
            {
                seminar.SeminarsParticipants.Remove(participant);
                await data.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Joined));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var seminar = await data.Seminars.FindAsync(id);

            if (seminar == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (seminar.OrganizerId != userId)
            {
                return Unauthorized();
            }

            var model = new SeminarDeleteViewModel
            {
                Id = seminar.Id,
                Topic = seminar.Topic,
                DateAndTime = seminar.DateAndTime
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(SeminarDeleteViewModel model, int id)
        {
            var seminar = await data.Seminars.FindAsync(model.Id);

            if (seminar == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (seminar.OrganizerId != userId)
            {
                return Unauthorized();
            }

            var seminarParticipants = data.SeminarsParticipants
                .Where(sp => sp.SeminarId == id)
                .ToList();

            if (seminarParticipants.Any())
            {
                foreach (var participant in seminarParticipants)
                {
                    data.SeminarsParticipants.Remove(participant);
                }

                await data.SaveChangesAsync();
            }

            data.Seminars.Remove(seminar);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }

        private async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            return await data.Categories
                .AsNoTracking()
                .Select(t => new CategoryViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
        }


    }


}

