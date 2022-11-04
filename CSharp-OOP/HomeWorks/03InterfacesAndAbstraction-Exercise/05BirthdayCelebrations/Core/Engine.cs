namespace BorderControl.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BirthdayCelebrations.Commands;
    using BirthdayCelebrations.Contracts;
    using BirthdayCelebrations.Models;
    using BorderControl.Contracts;
    using BorderControl.Models;


    public class Engine
    {
        private readonly List<IIdentifiable> identifiables;
        private readonly List<IMammal> mammals;
        private CommandParser commandParser;
        public Engine(CommandParser commandParser)
        {
            this.commandParser = commandParser;
            mammals = new List<IMammal>();
            identifiables = new List<IIdentifiable>();
        }
        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;
                var command = commandParser.Parser(input);
                if (command.Name == "Robot") // robot
                {
                    string model = command.Args[0];
                    string id = command.Args[1];
                    IIdentifiable robot = new Robot(model, id);
                    identifiables.Add(robot);
                }
                else if (command.Name == "Citizen") // citizen
                {
                    string name = command.Args[0];
                    int age = int.Parse(command.Args[1]);
                    string id = command.Args[2];
                    string birthdate = command.Args[3];
                    IMammal citizen = new Citizen(name, age, id, birthdate);
                    mammals.Add(citizen);
                }
                else if (command.Name == "Pet") // pet
                {
                    string petName = command.Args[0];
                    string birthdate = command.Args[1];
                    IMammal pet = new Pet(petName, birthdate);
                    mammals.Add(pet);
                }
            }
            string specificYear = Console.ReadLine();
            PrintMammals(specificYear);
        }

        private void PrintMammals(string specificYear)
        {
            if (mammals.Any(x => x.Birthdate.EndsWith(specificYear)))
            {
                foreach (var mammal in mammals.Where(x => x.Birthdate.EndsWith(specificYear)))
                {
                    Console.WriteLine(mammal);
                }
            }
        }
    }
}
