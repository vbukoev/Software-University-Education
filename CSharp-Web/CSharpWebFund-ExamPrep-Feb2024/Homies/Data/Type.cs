using System.ComponentModel.DataAnnotations;


namespace Homies.Data
{
    public class Type
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.TypeNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Event> Events { get; set; } = new List<Event>();
    }
}
