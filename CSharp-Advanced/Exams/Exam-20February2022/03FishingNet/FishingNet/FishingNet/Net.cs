using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;
        public string Material { get; set; }
        public int Capacity { get; set; }
        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            fish = new List<Fish>();
        }
        public int Count => this.fish.Count;
        public IReadOnlyCollection<Fish> Fish => fish;

        public string AddFish(Fish fish)
        {
            if (fish.Length <= 0 || fish.Weight <= 0 || fish.FishType == null || string.IsNullOrEmpty(fish.FishType))
            {
                return "Invalid fish.";
            }
            else if (this.fish.Count + 1 > this.Capacity)
            {
                return "Fishing net is full.";
            }
            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }
        public bool ReleaseFish(double weight)
        {
            var fish = this.fish.FirstOrDefault(x => x.Weight == weight);
            if (fish == null)
            {
                return false;
            }
            else
            {
                return this.fish.Remove(fish);
            }
        }
        public Fish GetFish(string fishType)
        {
            return Fish.Where(x => x.FishType == fishType).First();
        }
        public Fish GetBiggestFish()
        {
            var biggestFish = this.Fish.Max(x => x.Length);
            return fish.FirstOrDefault(x => x.Length == biggestFish);
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");
            foreach (var item in fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(item.ToString().TrimEnd());
            }
            return sb.ToString().TrimEnd();
        }
    }
}