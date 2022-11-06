namespace _03Raiding.Models
{
    using System;
    public class Druid : BaseHero
    {
        public override string Name { get; set; }
        public override int Power { get; set; }
        public Druid(string name)
        {
            Name = name;
            Power = 80;
        }

        public override string CastAbility()
        => $"{GetType().Name} - {Name} healed for {Power}";
    }
}
