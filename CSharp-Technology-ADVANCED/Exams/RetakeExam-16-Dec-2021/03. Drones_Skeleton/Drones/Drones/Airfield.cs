using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private string name;
        private int capacity;
        private double landingStrip;
        private List<Drone> drones;
        public Airfield(string name, int capacity, double landingStrip)
        {
            this.name = name;
            this.capacity = capacity;
            this.landingStrip = landingStrip;
            this.drones = new List<Drone>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public IReadOnlyCollection<Drone> Drones { get; set; }
        public int Count => this.Drones.Count;
        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            else if (capacity - this.Count <= 0)
            {
                return "Airfield is full.";
            }
            else
            {
                this.drones.Add(drone);
                return $"Successfully added {drone.Name} to the airfield.";
            }
        }
        public bool RemoveDrone(string name)
        {
            var newBool = false;
            var droneToBeRemoved = this.drones.FirstOrDefault(x => x.Name == name);
            if (droneToBeRemoved == null)
            {
                return false;
            }
            else
            {
                this.drones.Remove(droneToBeRemoved);
            }
            return newBool;
        }
        public int RemoveDroneByBrand(string brand)
        {
            var res = 0;
            if ((this.drones.Where(x => x.Brand == brand).ToList()).Count > 0)
            {
                res = this.drones.Where(x => x.Brand == brand).ToList().Count;
                foreach (var item in this.drones.Where(x => x.Brand == brand)) this.drones.Remove(item);
            }
            return res;
        }
        public Drone FlyDrone(string name)
        {
            var currDrone = this.drones.FirstOrDefault(x => x.Name == name);
            if (currDrone != null)
            {
                currDrone.Available = false;
                return currDrone;
            }
            return null;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            IEnumerable<Drone> fly = this.drones.Where(x => x.Range >= range);
            return fly.ToList();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");
            foreach (var item in drones.Where(x => x.Available == true)) sb.AppendLine(item.ToString()); 
            return sb.ToString().TrimEnd();
        }
    }
}
