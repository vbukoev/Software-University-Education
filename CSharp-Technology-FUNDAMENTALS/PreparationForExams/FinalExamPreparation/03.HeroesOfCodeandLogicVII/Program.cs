using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesOfCodeandLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var command = "";
            var heroes = new Dictionary<string, Hero>();
            for (int i = 0; i < n; i++)
            {
                var heroInfo = Console.ReadLine();
                var splitted = heroInfo.Split();
                var name = splitted[0];
                var Hp = int.Parse(splitted[1]);
                var Mp = int.Parse(splitted[2]);
                Hero hero = new Hero() 
                { 
                    hp = Hp, 
                    mp = Mp 
                };
                heroes.Add(name, hero);
            }

            while (true)
            {
                command = Console.ReadLine();
                if (command == "End") break;
                var splitted = command.Split(" - ");
                var action = splitted[0];
                var currName = splitted[1];
                switch (action)
                {
                    case "CastSpell":
                        var needMp = int.Parse(splitted[2]);
                        var spell = splitted[3];
                        if (heroes[currName].mp - needMp >= 0)
                        {
                            heroes[currName].mp = heroes[currName].mp - needMp;
                            Console.WriteLine($"{currName} has successfully cast {spell} and now has {heroes[currName].mp} MP!");
                        }
                        else Console.WriteLine($"{currName} does not have enough MP to cast {spell}!");
                        break;
                    case "TakeDamage":
                        var damage = int.Parse(splitted[2]);
                        var attacker = splitted[3];
                        heroes[currName].hp -= damage;
                        if (heroes[currName].hp > 0) Console.WriteLine($"{currName} was hit for {damage} HP by {attacker} and now has {heroes[currName].hp} HP left!");
                        else
                        {
                            Console.WriteLine($"{currName} has been killed by {attacker}!");
                            heroes.Remove(currName);
                        }
                        break;
                    case "Recharge":
                        var amount = int.Parse(splitted[2]);
                        if (heroes[currName].mp + amount > 200) amount = 200 - heroes[currName].mp;
                        heroes[currName].mp = heroes[currName].mp + amount;
                        Console.WriteLine($"{currName} recharged for {amount} MP!");
                        break;
                    case "Heal":
                        amount = int.Parse(splitted[2]);
                        if (heroes[currName].hp + amount > 100) amount = 100 - heroes[currName].hp;
                        heroes[currName].hp = heroes[currName].hp + amount;
                        Console.WriteLine($"{currName} healed for {amount} HP!");
                        break;
                    default:
                        break;
                }                
            }            
            foreach (var item in heroes)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine($" HP: {item.Value.hp}");
                Console.WriteLine($" MP: {item.Value.mp}");
            }
        }
    }
    class Hero
    {
        public int hp { get; set; }
        public int mp { get; set; }
    }
}
