namespace BirthdayCelebrations.Models
{
    using Contracts;
    public abstract class Mammal : IMammal
    {
        protected Mammal(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
        public string Name { get; }
        public string Birthdate { get; }
        public override string ToString() => $"{Birthdate}";
    }
}
