using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static SeminarHub.Data.DataConstants;

namespace SeminarHub.Data.Entities
{
    [Comment("Category Table")]
    public class Category
    {
        [Comment("Category Identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Category Name")]
        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Comment("List of Seminars")]
        public IEnumerable<Seminar> Seminars { get; set; } = new List<Seminar>();
    }
}
