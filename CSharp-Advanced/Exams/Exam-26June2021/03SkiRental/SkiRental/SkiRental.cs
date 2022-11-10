using System;
using System.Collections.Generic;
using System.Linq;

namespace SkiRental
{
    public class SkiRental
    {
        private readonly List<Ski> skies; //Field data – collection that holds added Skis
        public string Name { get; set; } //properties
        public int Capacity { get; set; }
        public int Count { get { return this.skies.Count; } }
        public SkiRental(string name, int capacity)
        {
            this.skies = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }
        public void Add(Ski ski)
        {
            if (this.skies.Count < this.Capacity) this.skies.Add(ski);
        }
        public bool Remove(string manufacturer, string model)
        {
            return this.skies.Remove(this.skies.Find(x => x.Manufacturer == manufacturer && x.Model == model));
        }
        public Ski GetNewestSki()
        {
            return this.skies.OrderByDescending(x => x.Year).FirstOrDefault();
        }
        public Ski GetSki(string manufacturer, string model)
        {
            return this.skies.Find(x => x.Manufacturer == manufacturer && x.Model == model);
        }
        public string GetStatistics()
        {
            return $"The skis stored in {this.Name}:" + "\n" +
            String.Join("\n", this.skies);
        }
    }
}
