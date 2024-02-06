using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected string? GetUserId()
        {
            string id = String.Empty;

            if (User != null)
            {
                id = User?.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return id;
        }
    }
}
