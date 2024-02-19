using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static Homies.Data.DataConstants;

namespace Homies.Data
{
    [Comment("Events table")]
    public class Event
    {
        [Key]
        [Comment("Event Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(EventNameMaxLength)]
        [Comment("Event Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(EventDescriptionMaxLength)]
        [Comment("Event Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Event Organiser Identifier")]
        public string OrganiserId { get; set; } = string.Empty;

        [ForeignKey(nameof(OrganiserId))]
        [Comment("Event Organiser")]
        public IdentityUser Organiser { get; set; } = null!;

        [Required]
        [Comment("Event Creation")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Comment("Event Start Date and Time")]
        public DateTime Start { get; set; }

        [Required]
        [Comment("Event End Date and Time")]
        public DateTime End { get; set; }

        [Required]
        [Comment("Event Type Identifier")]
        public int TypeId { get; set; }

        [ForeignKey(nameof(TypeId))]
        [Comment("Event Type")]
        public Type Type { get; set; } = null!;
        [Comment("Event Participants collection")]
        public IList<EventParticipant> EventsParticipants { get; set; } = new List<EventParticipant>();
    }
}

