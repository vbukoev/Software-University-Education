using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Models;

namespace SoftUniBazar.Controllers
{
    [Authorize]
    public class AdController : Controller
    {
        private readonly BazarDbContext data;

        public AdController(BazarDbContext context)
        {
            data = context;
        }
        public async Task<IActionResult> All()
        {
            var ads = await data.Ads
                .AsNoTracking()
                .Select(a=> new AdAndCartInfoViewModel(
                    a.Id,
                    a.Category.Name,
                    a.Description,
                    a.Name,
                    a.Price,
                    a.ImageUrl,
                    a.Owner.UserName,
                    a.CreatedOn))
                .ToListAsync();
            return View(ads);
        }

        public async Task<IActionResult> Cart()
        {
            var userId = GetUserId();
            var ads = await data.Ads
                .Where(a => a.AdBuyers.Any(ab => ab.BuyerId == userId))
                .AsNoTracking()
                .Select(a => new AdAndCartInfoViewModel(
                    a.Id,
                    a.Category.Name,
                    a.Description,
                    a.Name,
                    a.Price,
                    a.ImageUrl,
                    a.Owner.UserName,
                    a.CreatedOn))
                .ToListAsync();
            return View(ads);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var userId = GetUserId();
            if (data.AdBuyers.Any(ab => ab.AdId == id && ab.BuyerId == userId))
            {
                return RedirectToAction(nameof(All));
            }

            var adBuyer = new AdBuyer
            {
                AdId = id,
                BuyerId = userId
            };

            await data.AdBuyers.AddAsync(adBuyer);
            await data.SaveChangesAsync();
            return RedirectToAction(nameof(Cart));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var userId = GetUserId();
            var removeAdBuyer = data.AdBuyers.FirstOrDefault(ab => ab.AdId == id && ab.BuyerId == userId);
            if (removeAdBuyer == null)
            {
                return RedirectToAction(nameof(Cart));
            }
            data.AdBuyers.Remove(removeAdBuyer);
            await data.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Add()
        {
            return View(new AdFormViewModel()
            {
                Categories = await GetCategories()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();
                return View(model);
            }

            var ad = new Ad
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                CreatedOn = DateTime.UtcNow,
                OwnerId = GetUserId(),
                CategoryId = model.CategoryId
            };

            await data.Ads.AddAsync(ad);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ad = await data.Ads.FindAsync(id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(new AdFormViewModel
            {
                Name = ad.Name,
                Description = ad.Description,
                Price = ad.Price,
                ImageUrl = ad.ImageUrl,
                CategoryId = ad.CategoryId,
                Categories = await GetCategories()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdFormViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();
                return View(model);
            }

            var ad = await data.Ads.FindAsync(id);
            if (ad == null)
            {
                return NotFound();
            }

            ad.Name = model.Name;
            ad.Description = model.Description;
            ad.Price = model.Price;
            ad.ImageUrl = model.ImageUrl;
            ad.CategoryId = model.CategoryId;

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        private string GetUserId(){
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private async Task<List<CategoryViewModel>> GetCategories()
        {
            return await data.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }
    }
}
