using System;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
	public abstract class Character
    {
        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = baseArmor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            this.bag = bag;
        }

        private string name;

		public string Name
		{
			get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            }
		}
		private double baseHealth;

		public double BaseHealth 
		{
			get { return baseHealth; }
            private set
            {
                baseHealth = value;
            }
		}

		private double  health;

		public double  Health 
		{
			get { return health; }
            set
            {
                if (value >  baseHealth) health = baseHealth;
                
				else if (value < 0) health = 0;
                
                else health = value;
            }
		}

		private double baseArmor;

		public double BaseArmor 
		{
			get { return baseArmor; }
			private set { baseArmor = value; }
		}

		private double armor;

		public double Armor 
		{
			get { return armor; }
            private set
            {
                if (value < 0) armor = 0;
                
                else armor = value;
            }
		}

		private double abilityPoints;

		public double AbilityPoints 
		{
			get { return abilityPoints; }
			private set { abilityPoints = value; }
		}

		private Bag bag ;

		public Bag Bag 
		{
			get { return bag ; }
			private set { bag  = value; }
		}

		public bool IsAlive { get; set; } = true;

        
		public void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

        public void TakeDamage(double hitPoints)
        {
			EnsureAlive();
            double armorDamage = Math.Min(Armor, hitPoints);
			double healthDamage = Math.Min(Health, hitPoints - armorDamage);
			Armor -= armorDamage;
			Health -= healthDamage;
        }

        public void UseItem(Item item)
        {
			EnsureAlive();
			item.AffectCharacter(this);
        }
    }
}