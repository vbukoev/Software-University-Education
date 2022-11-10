using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        List<Drone> drones;

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count { get { return Drones.Count; } }
        public List<Drone> Drones { get { return this.drones; } set { this.drones = value; } }

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.Drones = new List<Drone>();
        }

        public string AddDrone(Drone drone)
        {
            if(drone.Name == string.Empty || drone.Brand == string.Empty ||
                drone.Name == null || drone.Brand == null ||
                drone.Range < 5 || drone.Range > 15)
                return "Invalid drone.";
            if (this.Count == this.Capacity)
            {
                return "Airfield is full.";
            }
            this.Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }
        public bool RemoveDrone(string name)
        {
            Drone drone = this.Drones.Find(x => x.Name == name);
            return this.Drones.Remove(drone);

        }
        public int RemoveDroneByBrand(string brand)
        {
            return this.Drones.RemoveAll(x => x.Brand == brand);
        }

        public Drone FlyDrone(string name)
        {
            Drone drone = this.Drones.Find(x => x.Name == name);
            if (drone!=null)
            {
                drone.Available = false;
            }
            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flyingDrones = this.Drones.Where(x => x.Range >= range).ToList();

            foreach (Drone drone in Drones) this.FlyDrone(drone.Name);
            
            return flyingDrones;
        }

        public string Report()
            => $"Drones available at {this.Name}:" +
               Environment.NewLine +
               String.Join(Environment.NewLine, this.Drones.Where(d => d.Available));
    }
}
