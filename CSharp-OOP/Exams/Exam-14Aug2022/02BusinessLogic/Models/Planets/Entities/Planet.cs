using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.MilitaryUnits.Entities;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Models.Weapons.Entities;
using PlanetWars.Repositories.Entities;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.Planets.Entities
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private UnitRepository units;
        private WeaponRepository weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPlanetName));
                }
                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidBudgetAmount));
                }
                budget = value;
            }
        }

        public double MilitaryPower => Math.Round(CalculateMilitaryPower(), 3);



        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;
        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;
        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public void TrainArmy()
        {
            foreach (var VARIABLE in Army)
            {
                VARIABLE.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {
            if (amount>budget)
            {
                throw new ArgumentException(ExceptionMessages.UnsufficientBudget);
            }
            Budget -= amount;
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.Append($"--Forces: ");
            if (Army.Count == 0)
            {
                sb.AppendLine("No units");
            }
            else
            {
                sb.AppendLine(string.Join(", ", units.Models.Select(x => x.GetType().Name)));
            }

            sb.Append("--Combat equipment: ");
            if (Weapons.Count ==0)
            {
                sb.AppendLine("No weapons");
            }
            else
            {
                sb.AppendLine(string.Join(", ", weapons.Models.Select(x => x.GetType().Name)));
            }
            sb.Append($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        private double CalculateMilitaryPower()
        {
            double res = units.Models.Sum(x => x.EnduranceLevel) + weapons.Models.Sum(x => x.DestructionLevel);

            if (units.Models.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                res *= 1.3;
            }

            if (weapons.Models.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
            {
                res *= 1.45;
            }
            return res;
        }
    }
}