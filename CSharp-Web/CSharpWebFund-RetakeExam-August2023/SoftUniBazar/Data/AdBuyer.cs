using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace SoftUniBazar.Data
{
    [Comment("AdBuyer table")]
    public class AdBuyer
    {
        [Comment("AdBuyer Identifier")]
        [Required] 
        public string BuyerId { get; set; } = string.Empty;

        [Comment("Ad Buyer")]
        [ForeignKey(nameof(BuyerId))] 
        public IdentityUser Buyer { get; set; } = null!;
        [Comment("Ad Identifier")]
        [Required]
        public int AdId { get; set; }
        [Comment("Ad")]

        [ForeignKey(nameof(AdId))] 
        public Ad Ad { get; set; } = null!;
    }
}