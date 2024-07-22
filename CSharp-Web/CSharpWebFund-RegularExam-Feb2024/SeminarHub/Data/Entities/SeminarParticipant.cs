using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace SeminarHub.Data.Entities
{
    [Comment("Seminar Participant's Table")]
    public class SeminarParticipant
    {
        [Comment("Seminar Identifier")]
        [Required]
        public int SeminarId { get; set; }

        [Comment("Seminar")]
        [ForeignKey(nameof(SeminarId))]
        public Seminar Seminar { get; set; }

        [Comment("Participant Identifier")]
        [Required]
        public string ParticipantId { get; set; }

        [Comment("Participant")]
        [ForeignKey(nameof(ParticipantId))]
        public IdentityUser Participant { get; set; }
    }
}

