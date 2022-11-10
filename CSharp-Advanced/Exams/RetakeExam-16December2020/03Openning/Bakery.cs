using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private readonly List<Employee> data;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }
        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }
        public void Add(Employee employee)
        {
            if (Count<Capacity)  data.Add(employee);            
        }
        public bool Remove(string name)
        {
            return data.Remove(data.Find(x => x.Name == name));
        }
        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(x => x.Age).First();
        }
        public Employee GetEmployee(string name)
        {
            return data.Find(x => x.Name == name);
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");
            sb.AppendLine(string.Join(Environment.NewLine, data));
            return sb.ToString().TrimEnd();
        }
    }
}
