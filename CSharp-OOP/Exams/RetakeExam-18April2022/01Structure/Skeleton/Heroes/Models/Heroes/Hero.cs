using System;
using Heroes.Models.Contracts;

namespace Heroes.Models.Heroes
{
    public class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int Health
        {
            get => health;
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                health = value;
            }
        }

        public int Armour
        {
            get => armour;
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                armour = value;
            }
        }

        public IWeapon Weapon
        {
            get=> weapon;
            private set
            {
                if (value==null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
                weapon = value;
            }
        }

        public bool IsAlive => health > 0;
        public void TakeDamage(int points)
        {
            int armourDamage = Math.Min(Armour, points);
            Armour -= armourDamage;
            int healthDamage = Math.Min(Health, points - armourDamage);
            Health -= healthDamage;
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapon = weapon;
        }
    }
}
