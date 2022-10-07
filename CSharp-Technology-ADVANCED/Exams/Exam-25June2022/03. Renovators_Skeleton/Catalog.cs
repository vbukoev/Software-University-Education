using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renovators
{
    public class Catalog
    {
        private string name;
        private int needRenovators;
        private string project;
        private List<Renovator> renovators;
        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
            this.renovators = new List<Renovator>();
        }
        
        public IReadOnlyCollection<Renovator> Renovators => renovators;
        public string Name { get; private set; }
        public int NeededRenovators { get; private set; }
        public string Project { get; private set; }
        public int Count => this.Renovators.Count; 
        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            if (this.Count == this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            this.renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }
        public bool RemoveRenovator(string name)
        {
            Renovator toBeRemoved = this.renovators.FirstOrDefault(x => x.Name == name);
            if (toBeRemoved == null)
            {
                return false;
            }
            this.renovators.Remove(toBeRemoved);  
            return true;
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            List<Renovator> toBeRemoved = this.renovators.FindAll(x => x.Type == type).ToList();
            if (toBeRemoved.Count > 0)
            {
                foreach (var item in toBeRemoved)
                {
                    this.renovators.Remove(item);
                }
                return toBeRemoved.Count;
            }
            return 0;
        }
        public Renovator HireRenovator(string name)
        {
            Renovator sortByName = this.renovators.FirstOrDefault(x => x.Name == name);
            if (sortByName == null)
            {
                return null;
            }
            this.Renovators.FirstOrDefault(x => x.Name == name).Hired = true;
            return sortByName;
        }
        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> toBePaid = this.Renovators.Where(x => x.Days >= days).ToList();
            return toBePaid;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            var newCollection = this.Renovators.Where(x => x.Hired == false).Where(x=>x.Paid == false); //gets everybody who is not hired
            sb.AppendLine($"Renovators available for Project {this.Project}:");
            foreach (var item in newCollection) sb.AppendLine(item.ToString());
            return sb.ToString().TrimEnd();
        }
    }
}