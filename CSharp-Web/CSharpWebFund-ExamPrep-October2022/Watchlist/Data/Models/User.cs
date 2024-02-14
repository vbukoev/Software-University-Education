using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Watchlist.Data.Models
{
    public class User : IdentityUser
    {
        [Comment("User And Movies Collection (List)")]
        public List<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();
    }
}
