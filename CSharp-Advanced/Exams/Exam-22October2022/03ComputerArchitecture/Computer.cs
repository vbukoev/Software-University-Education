using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        //•	Model - string
        //•	Capacity – int 
        //•	Multiprocessor – List<CPU>
        public List<CPU> Multiprocessor { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return Multiprocessor.Count; } }
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }
        public void Add(CPU cpu)
        {
            if (Capacity > Count)
            {
                Multiprocessor.Add(cpu);
            }
        }
        public bool Remove(string brand)
        {
            return Multiprocessor.Remove(Multiprocessor.Find(x => x.Brand == brand));
        }
        public CPU MostPowerful()
        {
            return Multiprocessor.OrderByDescending(x => x.Frequency).First();
        }
        public CPU GetCPU(string brand)
        {

            return Multiprocessor.FirstOrDefault(x => x.Brand == brand);
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {Model}:");
            foreach (var item in Multiprocessor)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
