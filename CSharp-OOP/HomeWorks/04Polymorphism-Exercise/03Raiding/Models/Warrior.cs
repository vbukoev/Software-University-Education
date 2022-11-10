namespace _03Raiding.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Warrior : BaseHero
    {
        public override string Name { get; set; }
        public override int Power { get; set; }
        public Warrior(string name)
        {
            Name = name;
            Power = 100;
        }

        public override string CastAbility()
        => $"{GetType().Name} - {Name} hit for {Power} damage";
    }
}
