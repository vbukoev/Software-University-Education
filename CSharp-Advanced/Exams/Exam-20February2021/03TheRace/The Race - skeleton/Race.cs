using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.data.Count; } }
        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Racer>();
        }
        public void Add(Racer Racer)
        {
            if (this.Count < this.Capacity) this.data.Add(Racer);
        }
        public bool Remove(string name)
        {
            return this.data.Remove(this.data.Find(x => x.Name == name));
        }
        public Racer GetOldestRacer()
        {
            return this.data.OrderByDescending(x => x.Age).First();
        }
        public Racer GetRacer(string name)
        {
            return this.data.Find(x => x.Name == name);
        }
        public Racer GetFastestRacer()
        {
            return this.data.OrderByDescending(x => x.Car.Speed).First();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {this.Name}:");
            sb.AppendLine(string.Join(Environment.NewLine, this.data));
            return sb.ToString().TrimEnd();
        }
    }
}
