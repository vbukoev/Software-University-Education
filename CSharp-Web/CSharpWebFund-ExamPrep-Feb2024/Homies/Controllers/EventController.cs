using System.Globalization;
using Homies.Data;
using Homies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Homies.Controllers
{
    public class EventController : Controller
    {
        private readonly HomiesDbContext data;

        public EventController(HomiesDbContext context)
        {
            data = context;
        }
        public async Task<IActionResult> All()
        {
            var events = await data.Events
                .AsNoTracking()
                .Select(e => new EventInfoViewModel(
                    e.Id,
                    e.Name,
                    e.Start,
                    e.Type.Name,
                    e.Organiser.UserName))
                .ToListAsync();
            return View(events);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var e = await data.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventsParticipants)
                .FirstOrDefaultAsync();

            if (e == null)
            {
                return BadRequest();
            }
            string userId = GetUserId();

            if (!e.EventsParticipants.Any(p => p.HelperId == userId))
            {
                e.EventsParticipants.Add(new EventParticipant
                {
                    EventId = e.Id,
                    HelperId = userId
                });

                await data.SaveChangesAsync();

            }

            return RedirectToAction("Joined");
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string userId = GetUserId();
            var events = await data.EventsParticipants
                .Where(ep =>  ep.HelperId == userId)
                .AsNoTracking()
                .Select(ep => new EventInfoViewModel(
                                       ep.EventId,
                                       ep.Event.Name,
                                       ep.Event.Start,
                                       ep.Event.Type.Name,
                                       ep.Event.Organiser.UserName))
                .ToListAsync();

            return View(events);
        }

        public async Task<IActionResult> Leave(int id)
        {
            var e = await data.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventsParticipants)
                .FirstOrDefaultAsync();

            if (e == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            var participant = e.EventsParticipants
                .FirstOrDefault(p => p.HelperId == userId);

            if (participant != null)
            {
                e.EventsParticipants.Remove(participant);
                await data.SaveChangesAsync();
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new EventFormViewModel();
            model.Types = await GetTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormViewModel model)
        {
           DateTime start = DateTime.Now;
           DateTime end = DateTime.Now;
           if (!DateTime.TryParseExact(model.Start, DataConstants.DateTimeFormat, CultureInfo.InvariantCulture,
                   DateTimeStyles.None, out start))
           {
                ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be: {DataConstants.DateTimeFormat}.");
           }

           if (!DateTime.TryParseExact(model.End, DataConstants.DateTimeFormat, CultureInfo.InvariantCulture,
                   DateTimeStyles.None, out end))
           {
               ModelState.AddModelError(nameof(model.End), $"Invalid date! Format must be: {DataConstants.DateTimeFormat}.");
           }

           if (!ModelState.IsValid)
           {
               model.Types = await GetTypes();
               return View(model);
           }

           var entity = new Event
           {
               Name = model.Name,
               Description = model.Description,
               Start = start,
               End = end,
               TypeId = model.TypeId,
               OrganiserId = GetUserId(),
               CreatedOn = DateTime.Now
           };

           await data.Events.AddAsync(entity);
           await data.SaveChangesAsync();

           return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var e = await data.Events.FindAsync(id);
            if (e == null)
            {
                return BadRequest();
            }

            if (e.OrganiserId != GetUserId())
            {
                return Unauthorized();
            }
            var model = new EventFormViewModel()
            {
                Name = e.Name,
                Description = e.Description,
                Start = e.Start.ToString(DataConstants.DateTimeFormat),
                End = e.End.ToString(DataConstants.DateTimeFormat),
                TypeId = e.TypeId,
            };

            model.Types = await GetTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventFormViewModel model, int id)
        {
            var e = await data.Events.FindAsync(id);
            if (e == null)
            {
                return BadRequest();
            }

            if (e.OrganiserId != GetUserId())
            {
                return Unauthorized();
            }

            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;
            if (!DateTime.TryParseExact(model.Start, DataConstants.DateTimeFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out start))
            {
                ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be: {DataConstants.DateTimeFormat}.");
            }

            if (!DateTime.TryParseExact(model.End, DataConstants.DateTimeFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out end))
            {
                ModelState.AddModelError(nameof(model.End), $"Invalid date! Format must be: {DataConstants.DateTimeFormat}.");
            }

            if (!ModelState.IsValid)
            {
                model.Types = await GetTypes();
                return View(model);
            }
            e.Start = start;
            e.End = end;
            e.Name = model.Name;
            e.Description = model.Description;
            e.TypeId = model.TypeId;

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }

        private async Task<IEnumerable<TypeViewModel>> GetTypes()
        {
            return await data.Types
                .AsNoTracking()
                .Select(t => new TypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
        }

        public async Task<IActionResult> Details(int id)
        {

            var model = await data.Events
                .Where(e => e.Id == id)
                .AsNoTracking()
                .Select(e => new EventDetailsViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start.ToString(DataConstants.DateTimeFormat),
                    End = e.End.ToString(DataConstants.DateTimeFormat),
                    Organiser = e.Organiser.UserName,
                    Type = e.Type.Name,
                    CreatedOn = e.CreatedOn.ToString(DataConstants.DateTimeFormat)
                })
                .FirstOrDefaultAsync();
            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }
    }
}
