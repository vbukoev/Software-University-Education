using System.Security.Cryptography;

namespace P02_FootballBetting.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Bet
    {
        public Bet()
        {
            this.Games = new HashSet<Game>();
        }
        [Key]
        public int BetId { get; set; }

        public decimal Amount { get; set; }

        [Required]
        public string? Prediction { get; set; }

        public DateTime DateTime { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public int GameId { get; set; }
        public virtual Game Game { get; set; } = null!;
        public ICollection<Game> Games { get; set; }
    }
}