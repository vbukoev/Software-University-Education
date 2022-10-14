using System;
using System.Collections.Generic;
using System.Linq;

namespace _01TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whites = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            Queue<int> greys = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            Dictionary<string, int> location = new Dictionary<string, int>();
            while (true)
            {
                if (!whites.Any() || !greys.Any()) break;
                int whiteArea = whites.Pop();
                int greyArea = greys.Dequeue();
                string partOfTheHouse = "";
                if (whiteArea == greyArea)
                {
                    int sumOfTheWhiteAndGreyArea = whiteArea + greyArea;
                    switch (sumOfTheWhiteAndGreyArea)
                    {
                        case 40:
                            partOfTheHouse = "Sink";
                            break;
                        case 50:
                            partOfTheHouse = "Oven";
                            break;
                        case 60:
                            partOfTheHouse = "Countertop";
                            break;
                        case 70:
                            partOfTheHouse = "Wall";
                            break;                            
                        default:
                            partOfTheHouse = "Floor";
                            break;
                    }
                    if (!location.ContainsKey(partOfTheHouse)) location.Add(partOfTheHouse, 0);
                    location[partOfTheHouse] += 1;
                }
                else
                {
                    whiteArea = whiteArea / 2;
                    whites.Push(whiteArea);
                    greys.Enqueue(greyArea);
                }
            }
            if (!whites.Any()) //if there are none white tiles left in the sequence
            {
                Console.WriteLine("White tiles left: none");
            }
            else //if there are white tiles left
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whites)}");
            }
            if (!greys.Any()) //if there are none grey tiles left in the sequence
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else //if there are grey tiles left
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greys)}");
            }
            foreach (var kvp in location.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key)) //locations ordered descending by number (count of new tiles per location) and then sorted ascending alphabetically
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}