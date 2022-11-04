using ExplicitInterfaces.Contracts;
using ExplicitInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Core
{
    public class Engine
    {
        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;
                string[] inputParts = input.Split();
                string name = inputParts[0];
                string country =inputParts[1];
                int age = int.Parse(inputParts[2]);
                IPerson person = new Citizen(name, age, country);
                IResident resident = new Citizen(name, age, country);
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
