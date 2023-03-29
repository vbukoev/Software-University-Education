using Footballers.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Footballers.Data.Models
{
    public class Footballer
    {
        public Footballer()
        {
            TeamsFootballers = new HashSet<TeamFootballer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime ContractStartDate { get; set; }

        [Required]
        public DateTime ContractEndDate { get; set; }

        [Required]
        public PositionType PositionType { get; set; } // in the problem, downloaded from judge the prop name is only Position, but indeed it has to be PositionType :)

        [Required]
        public BestSkillType BestSkillType { get; set; } // in the problem, downloaded from judge the prop name is only BestSkill, but indeed it has to be BestSkillType :)

        [Required]
        [ForeignKey(nameof(Coach))]
        public int CoachId { get; set; }
        public Coach Coach { get; set; }

        public ICollection<TeamFootballer> TeamsFootballers { get; set; }
    }
}
