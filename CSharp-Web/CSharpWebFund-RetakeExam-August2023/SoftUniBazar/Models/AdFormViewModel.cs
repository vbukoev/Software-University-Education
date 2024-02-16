using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Data.DataConstants;
namespace SoftUniBazar.Models
{
    public class AdFormViewModel
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(AdNameMaxLength, MinimumLength = AdNameMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(AdDescriptionMaxLength, MinimumLength = AdDescriptionMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Description { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string ImageUrl { get; set; } = null!;
        [Required]
        public int CategoryId { get; set; }
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
