using System;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private IBag bag;

        public Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
        }

        public string Name
        {
            get=> name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidAstronautName);
                name = value;
            }
        }
        public double Oxygen
        {
            get=> oxygen;
            protected set
            {
                if (value < 0) throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                oxygen = value;
            }
        }

        public bool CanBreath => oxygen > 0;
        public IBag Bag => bag;

        public virtual void Breath()
        {
            Oxygen = Math.Max(Oxygen - 10, 0);
        }
    }
}