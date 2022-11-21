using System.Collections.Generic;
using System.Linq;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {

        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knightsHeroes = new List<IHero>();
            List<IHero> barbariansHeroes = new List<IHero>();
            foreach (var hero in players)
            {
                if (hero.GetType() == typeof(Knight)) knightsHeroes.Add(hero);
                else barbariansHeroes.Add(hero);
            }

            bool knigthsTurn = true;
            while (knightsHeroes.Any(x=>x.IsAlive) && barbariansHeroes.Any(x=>x.IsAlive))
            {
                if (knigthsTurn)
                {
                    MakeTheRoundFight(knightsHeroes, barbariansHeroes);
                }
                else
                {
                    MakeTheRoundFight(barbariansHeroes, knightsHeroes);
                }
            }

            int AliveKnigths = knightsHeroes.Where(x => !x.IsAlive).Count();
            int AliveBarbarians = knightsHeroes.Where(x => !x.IsAlive).Count();
            if (knightsHeroes.Any(x => x.IsAlive))
                return $"The knights took {AliveKnigths} casualties but won the battle.";
            else return $"The barbarians took {AliveBarbarians} casualties but won the battle.";
        }

        private void MakeTheRoundFight(List<IHero> attackers, List<IHero> defenders)
        {
            foreach (var attacker in attackers)
            {
                foreach (var defender in defenders)
                {
                    defender.TakeDamage(attacker.Weapon.DoDamage());
                }
            }
        }
    }
}