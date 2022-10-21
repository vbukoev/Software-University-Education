using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private readonly List<Car> data;
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            this.data = new List<Car>();
        }
        public void Add(Car car)
        {
            if (Count < Capacity) data.Add(car);
        }
        public bool Remove(string manufacturer, string model)
        {
            return data.Remove(data.Find(x => x.Manufacturer == manufacturer && x.Model == model));
        }
        public Car GetLatestCar()
        {
            return data.OrderByDescending(x => x.Year).FirstOrDefault();
        }
        public Car GetCar(string manufacturer, string model)
        {
            return data.Find(x => x.Manufacturer == manufacturer && x.Model == model);
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            sb.AppendLine(string.Join(Environment.NewLine, data));
            return sb.ToString().TrimEnd();
        }
    }
}
