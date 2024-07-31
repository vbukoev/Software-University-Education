using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static SoftUniBazar.Data.DataConstants;

namespace SoftUniBazar.Data
{
    [Comment("Ad table")]
    public class Ad
    {
        [Comment("Ad Identifier")]
        [Key]
        public int Id { get; set; }
        [Comment("Ad Name")]
        [Required]
        [MaxLength(AdNameMaxLength)]
        public string Name { get; set; } = string.Empty;
        [Comment("Ad Description")]
        [Required]
        [MaxLength(AdDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;
        [Comment("Ad Price")]
        [Required]
        public decimal Price { get; set; }
        [Comment("Ad Owner Identifier")]
        [Required]
        public string OwnerId { get; set; } = string.Empty;
        [Comment("Ad Owner")]
        [ForeignKey(nameof(OwnerId))]
        public IdentityUser Owner { get; set; } = null!;
        [Comment("Ad Image Path")]
        [Required] 
        public string ImageUrl { get; set; } = string.Empty;
        [Comment("Ad Creation Date")]
        [Required]
        public DateTime CreatedOn { get; set; }
        [Comment("Ad Category Identifier")]
        [Required]
        public int CategoryId { get; set; }
        [Comment("Ad Category")]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        [Comment("Ad Buyers Collection")]
        public IEnumerable<AdBuyer> AdBuyers { get; set; } = new List<AdBuyer>();
    }
}