namespace _03Raiding.Models
{
    public abstract class BaseHero
    {
        // string Name, int Power, string CastAbility()
        public abstract string Name { get; set; }
        public abstract int Power { get; set; }
        public abstract string CastAbility();

    }
}
