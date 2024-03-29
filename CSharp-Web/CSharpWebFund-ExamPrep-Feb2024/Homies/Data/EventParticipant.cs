using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Homies.Data
{
    [Comment("EventParticipant table")]
    public class EventParticipant
    {
        [Required]
        [Comment("EventParticipant Helper Identifier")]
        public string HelperId { get; set; } = string.Empty;

        [ForeignKey(nameof(HelperId))]
        [Comment("EventParticipant Helper")]
        public IdentityUser Helper { get; set; } = null!;

        [Required]
        [Comment("EventParticipant Event Identifier")]
        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        [Comment("EventParticipant Event")]
        public Event Event { get; set; } = null!;
    }
}
