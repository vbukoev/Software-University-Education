using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static SeminarHub.Data.DataConstants;

namespace SeminarHub.Data.Entities
{
    [Comment("Seminar Table")]
    public class Seminar
    {
        [Comment("Seminar Identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Seminar Topic")]
        [Required]
        [MaxLength(SeminarTopicMaxLength)]
        public string Topic { get; set; } = string.Empty;

        [Comment("Seminar Lecturer")]
        [Required]
        [MaxLength(SeminarLecturerMaxLength)]
        public string Lecturer { get; set; } = string.Empty;

        [Comment("Seminar Details")]
        [Required]
        [MaxLength(SeminarDetailsMaxLength)]
        public string Details { get; set; } = string.Empty;

        [Comment("Seminar Organizer Identifier")]
        [Required]
        public string OrganizerId { get; set; } = string.Empty;

        [Comment("Seminar Organizer")]
        [ForeignKey(nameof(OrganizerId))] 
        public IdentityUser Organizer { get; set; } = null!;

        [Comment("Seminar Date and Time")]
        [Required]
        public DateTime DateAndTime { get; set; }

        [Comment("Seminar Duration")]

        [MaxLength(SeminarDurationMaxValue)]
        public int Duration { get; set; }

        [Comment("Category Identifier")]
        [Required]
        public int CategoryId { get; set; }

        [Comment("Seminar Category")]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;


        [Comment("List of Seminar Participants")]
        public ICollection<SeminarParticipant> SeminarsParticipants { get; set; } = new List<SeminarParticipant>();
    }
}

