namespace BorderControl.Core
{
    using BorderControl.Contracts;
    using BorderControl.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Text;


    public class Engine
    {
        private readonly List<IIdentifiable> identifiables;
        public Engine()
        {
            identifiables = new List<IIdentifiable>();
        }
        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;
                string[] inputParts = input.Split().ToArray();
                if (inputParts.Length == 2) // robot
                {
                    string model = inputParts[0];
                    string id = inputParts[1];
                    IIdentifiable robot = new Robot(model, id);
                    identifiables.Add(robot);
                }
                else if(inputParts.Length == 3) // citizen
                {
                    string name = inputParts[0];
                    int age = int.Parse(inputParts[1]);
                    string id = inputParts[2];
                    IIdentifiable citizen = new Citizen(name, age, id);
                    identifiables.Add(citizen);
                }
            }
            string fakeIdLastDigits = Console.ReadLine();
            foreach (IIdentifiable fakeId in identifiables.Where(x=>x.Id.EndsWith(fakeIdLastDigits)))
            {
                Console.WriteLine(fakeId);
            }
        }
    }
}
