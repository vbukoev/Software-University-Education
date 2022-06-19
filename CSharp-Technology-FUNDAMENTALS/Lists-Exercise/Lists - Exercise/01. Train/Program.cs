using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command.Split();
                if (tokens.Length == 2)
                {
                    int wagon = int.Parse(tokens[1]);
                    wagons.Add(wagon);
                }
                else
                {
                    int passangers = int.Parse(tokens[0]);
                    FindWagon(wagons, maxCapacity, passangers);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", wagons));
        }

        private static void FindWagon(List<int> wagons, int maxCapacity, int passangers)
        {
            for (int i = 0; i < wagons.Count; i++)
            {
                int currWagon = wagons[i];
                if (currWagon + passangers <= maxCapacity)
                {
                    wagons[i] += passangers;
                    break;
                }
            }
        }
    }
}
