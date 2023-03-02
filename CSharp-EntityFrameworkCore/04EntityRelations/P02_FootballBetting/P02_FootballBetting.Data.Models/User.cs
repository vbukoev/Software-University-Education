namespace P02_FootballBetting.Data.Models
{
    public class User
    {
        public User()
        {
            this.Bets = new HashSet<Bet>();
        }
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Email { get; set; }
        public string Name { get; set; } = null!;
        public decimal Balance { get; set; }
        public ICollection<Bet> Bets { get; set; }
    }
}