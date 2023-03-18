namespace P02_FootballBetting.Data.Models
{
    public class Bet
    {
        public Bet()
        {
            this.Games = new HashSet<Game>();
        }
        public int BetId { get; set; }
        public decimal Amount { get; set; }
        public string? Prediction { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; } = null!;
        public ICollection<Game> Games { get; set; }
    }
}