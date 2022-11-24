using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;
        
        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipment = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => name; 
            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException(ExceptionMessages.InvalidGymName);
                name = value;
            } 

        }

        public int Capacity
        {
            get=> capacity;

            private set=> capacity = value;
        }
        public double EquipmentWeight => equipment.Sum(x=>x.Weight);
        public ICollection<IEquipment> Equipment => equipment.AsReadOnly();
        public ICollection<IAthlete> Athletes => athletes.AsReadOnly();
        public void AddAthlete(IAthlete athlete)
        {
            if (athletes.Count == capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
        => athletes.Remove(athlete);

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            athletes.ForEach(x => x.Exercise());
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} is a {GetType().Name}:");
            sb.Append("Athletes: ");
            sb.AppendLine(athletes.Any() ? string.Join(", ", athletes.Select(x=>x.FullName)) : "No athletes");
            sb.AppendLine($"Equipment total count: {equipment.Count}"); 
            sb.Append($"Equipment total weight: {EquipmentWeight:f2} grams"); 
            return sb.ToString().TrimEnd();
        }
    }
}
