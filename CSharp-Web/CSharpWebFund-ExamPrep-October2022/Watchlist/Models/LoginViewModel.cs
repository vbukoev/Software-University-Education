using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;

namespace Watchlist.Models
{
    public class LoginViewModel
    {
        /// <summary>
        /// Login Username
        /// </summary>
        [Required]
        public string UserName{ get; set; } = null!;
        /// <summary>
        /// Login Password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
