using System;
using System.Collections.Generic;
using System.Linq;

namespace _01TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listWithTheWhite = new List<int>();
            List<int> listWithTheGrey = new List<int>();
            listWithTheWhite = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            listWithTheGrey = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Stack<int> whiteStack = new Stack<int>(listWithTheWhite);
            Queue<int> greyQueue = new Queue<int>(listWithTheGrey);
            Dictionary<string, int> location = new Dictionary<string, int>();
            while (whiteStack.Any() && greyQueue.Any())
            {
                int whiteArea = whiteStack.Pop();
                int greyArea = greyQueue.Dequeue();
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
                    whiteStack.Push(whiteArea);
                    greyQueue.Enqueue(greyArea);
                }
            }
            if (!whiteStack.Any()) //if there are none tiles left in the sequence
            {
                Console.WriteLine("White tiles left: none");
            }
            else //if there are tiles left
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteStack)}");
            }
            if (!whiteStack.Any()) //if there are none tiles left in the sequence
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else //if there are tiles left
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyQueue)}");
            }
            foreach (var kvp in location.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
