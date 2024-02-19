using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Homies.Data
{
    [Comment("Type table")]
    public class Type
    {
        [Key]
        [Comment("Type Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.TypeNameMaxLength)]
        [Comment("Type Name")]
        public string Name { get; set; } = string.Empty;
        [Comment("Collection of Events")]
        public IEnumerable<Event> Events { get; set; } = new List<Event>();
    }
}
