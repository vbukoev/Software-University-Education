using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Homies.Data
{
    public class EventParticipant
    {
        [Microsoft.Build.Framework.Required]
        public string HelperId { get; set; } = string.Empty;

        [ForeignKey(nameof(HelperId))]
        public IdentityUser Helper { get; set; } = null!;

        [Microsoft.Build.Framework.Required]
        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; } = null!;
    }
}
