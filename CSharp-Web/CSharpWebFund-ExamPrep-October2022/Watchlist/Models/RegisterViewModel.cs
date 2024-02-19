using System.ComponentModel.DataAnnotations;
using static Watchlist.Data.Models.DataConstants.ErrorMessages;
using static Watchlist.Data.Models.DataConstants.User;

namespace Watchlist.Models
{
    public class RegisterViewModel
    {
        /// <summary>
        /// Register Username
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string UserName { get; set; } = null!;
        /// <summary>
        /// Register Email
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [EmailAddress]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Email { get; set; } = null!; 
        /// <summary>
        /// Register Password
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = StringLengthErrorMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        /// <summary>
        /// Register Password Confirmation
        /// </summary>
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;


    }
}
