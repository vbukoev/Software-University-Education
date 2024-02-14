using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace SoftUniBazar.Data
{
    public class AdBuyer
    {
        [Required] 
        public string BuyerId { get; set; } = string.Empty;

        [ForeignKey(nameof(BuyerId))] 
        public IdentityUser Buyer { get; set; } = null!;
        [Required]
        public int AdId { get; set; }

        [ForeignKey(nameof(AdId))] 
        public Ad Ad { get; set; } = null!;
    }
}