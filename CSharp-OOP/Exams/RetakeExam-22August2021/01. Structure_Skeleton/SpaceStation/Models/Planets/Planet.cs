using System;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private List<string> items;
        private string name;

        public Planet(string name)
        {
            items = new List<string>();
            Name = name;
        }
        public ICollection<string> Items => items.AsReadOnly();

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }
    }
}
