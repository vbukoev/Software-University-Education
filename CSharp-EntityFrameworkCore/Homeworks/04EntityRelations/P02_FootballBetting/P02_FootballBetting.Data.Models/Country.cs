namespace P02_FootballBetting.Data.Models
{
    public class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }
        public int CountryId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Town> Towns { get; set; }
    }
}