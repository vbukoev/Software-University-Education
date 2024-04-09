using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SoftUniBazar.Data
{
    [Comment("Category table")]
    public class Category
    {
        [Comment("Category Identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Category Name")]
        [Required]
        [MaxLength(DataConstants.CategoryNameMaxLength)]
        public string Name { get; set; } = string.Empty;
        [Comment("Collection of Ads")]
        public IList<Ad> Ads { get; set; } = new List<Ad>();
    }
}