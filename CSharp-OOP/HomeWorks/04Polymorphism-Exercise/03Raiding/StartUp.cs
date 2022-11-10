namespace _03Raiding
{
    using _03Raiding.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int numOfHeroes = int.Parse(Console.ReadLine());
            while (true)
            {
                if (heroes.Count >= numOfHeroes) break; 
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                try
                {
                    BaseHero baseHero = Factory.GetHero(name, type);
                    heroes.Add(baseHero);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            int powerOfBoss = int.Parse(Console.ReadLine());
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }
            int totalPower = heroes.Select(x => x.Power).Sum();
            if (totalPower >= powerOfBoss) Console.WriteLine("Victory!");
            else Console.WriteLine("Defeat...");
        }
    }
}
