using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }
        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.Models.Any(x => x.Name == name))
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            if (type != "Claymore" && type != "Mace")
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            IWeapon weapon;
            if (type == "Claymore")
            {
                weapon = new Claymore(name, durability);
            }
            else
            {
                weapon = new Mace(name, durability);
            }
            weapons.Add(weapon);
            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.Models.Any(x => x.Name == name))
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            if (type != "Knight" && type != "Barbarian")
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            IHero hero;
            string result;
            if (type == "Knight")
            {
                hero = new Knight(name, health, armour);
                result = $"Successfully added Sir {name} to the collection.";
            }
            else
            {
                hero = new Barbarian(name, health, armour);
                result = $"Successfully added Barbarian {name} to the collection.";
            }
            heroes.Add(hero);
            return result;
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IWeapon weapon = weapons.FindByName(weaponName);
            IHero hero = heroes.FindByName(heroName);

            if (hero == null)
            {
                throw new ArgumentException($"Hero {heroName} does not exist.");
            }

            if (weapon == null)
            {
                throw new ArgumentException($"Weapon {weaponName} does not exist.");
            }

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);
            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string StartBattle()
        {
            Map map = new Map();
            ICollection<IHero> heroesCollection = heroes.Models
                .Where(x => x.IsAlive && x.Weapon != null)
                .ToList();
            return map.Fight(heroesCollection);
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hero in heroes.Models
                         .OrderBy(x => x.GetType().Name)
                         .ThenByDescending(x => x.Health)
                         .ThenBy(x => x.Name))
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                sb.Append("--Weapon: ");
                sb.AppendLine(hero.Weapon == null ? "Unarmed" : hero.Weapon.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
