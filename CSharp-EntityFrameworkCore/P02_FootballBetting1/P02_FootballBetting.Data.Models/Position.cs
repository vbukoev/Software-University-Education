namespace P02_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Position
    {
        public Position()
        {
            this.Players = new HashSet<Player>();
        }
        [Key]
        public int PositionId { get; set; }

        [Required] public string Name { get; set; } = null!;

        public virtual ICollection<Player> Players { get; set; }
    }
}