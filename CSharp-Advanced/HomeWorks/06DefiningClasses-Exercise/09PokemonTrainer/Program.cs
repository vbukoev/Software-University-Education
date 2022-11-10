namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var trainers = new Dictionary<string, Trainer>();            
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Tournament")
                {
                    break;
                }
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var trainerName = tokens[0];
                var pokemonName = tokens[1];
                var pokemonElement = tokens[2];
                int health = int.Parse(tokens[3]);
                var pokemon = new Pokemon(pokemonName, pokemonElement, health);
                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }
                trainers[trainerName].AddPokemon(pokemon);

            }
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                if (input == "Fire")
                {
                    foreach (var item in trainers.Values)
                    {
                        item.Check(input);
                    }
                }
                else if (input == "Water")
                {
                    foreach (var item in trainers.Values)
                    {
                        item.Check(input);
                    }
                }
                else if (input == "Electricity")
                {
                    foreach (var item in trainers.Values)
                    {
                        item.Check(input);
                    }
                }
            }
            var res = trainers.Values.OrderByDescending(x => x.Badges).ToList();
            foreach (var item in res) Console.WriteLine(item);
        }

    }
}
