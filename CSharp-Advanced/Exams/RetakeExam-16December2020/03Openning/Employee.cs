using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace BakeryOpenning
{
    public class Employee
    {
        //Name: string
        //Age: int
        //Country: string
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public Employee(string name, int age, string country)
        {
            Age = age;
            Country = country;
            Name = name;
        }
        public override string ToString()
        {
            return $"Employee: {Name}, {Age} ({Country})";
        }
    }
}
