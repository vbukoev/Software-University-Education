using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private List<IDecoration> decorations;
        private List<IFish> fishes;

        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            decorations = new List<IDecoration>();
            fishes = new List<IFish>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAquariumName);
                }
                name = value;
            }
        }

        public int Capacity
        {
            get=> capacity;
            private set
            {
                capacity = value;
            }

        }

        public int Comfort => decorations.Select(x => x.Comfort).Sum();
        public ICollection<IDecoration> Decorations => decorations.AsReadOnly();
        public ICollection<IFish> Fish => fishes.AsReadOnly();
        public void AddFish(IFish fish)
        {
            if (fishes.Count() == capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            fishes.Add(fish);
        }

        public bool RemoveFish(IFish fish)
        => fishes.Remove(fish);

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void Feed()
        {
            fishes.ForEach(x=>x.Eat());
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} ({GetType().Name})");
            sb.AppendLine($"Fish: " + (fishes.Any() ? String.Join(", ", fishes) : "none"));
            sb.AppendLine($"Decorations: {decorations.Count}");
            sb.Append($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }
    }
}
