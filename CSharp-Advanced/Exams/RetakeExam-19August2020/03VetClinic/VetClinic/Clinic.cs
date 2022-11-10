using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace VetClinic
{
    public class Clinic
    {
        private readonly List<Pet> data;
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }
        public Clinic(int capacity)
        {
            Capacity = capacity;
            this.data = new List<Pet>();
        }
        public void Add(Pet pet)
        {
            if (Count < Capacity) data.Add(pet);
        }
        public bool Remove(string name)
        {
            return data.Remove(data.Find(x => x.Name == name));
        }
        public Pet GetPet(string name, string owner)
        {
            return data.Find(x => x.Name == name && x.Owner == owner);
        }
        public Pet GetOldestPet()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }
        public string GetStatistics() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            sb.AppendLine(string.Join(Environment.NewLine, data.Select(x => $"Pet {x.Name} with owner: {x.Owner}")));
            return sb.ToString().TrimEnd();
        } 
    }
}
