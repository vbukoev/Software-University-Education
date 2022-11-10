using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _01
{
    public class Program
    {
        static void Main(string[] args)
        {
            //STACK AND QUEUE
            Stack<int> coffeine = new Stack<int>(Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> energyDrinks = new Queue<int>(Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int limitPerDay = 300;
            int StamatCoffeine = 0;
            while (true)
            {
                if (!coffeine.Any() || !energyDrinks.Any()) break;
                int mgs = coffeine.Pop();
                int currEnergy = energyDrinks.Dequeue();
                int sum = mgs * currEnergy;
                if (sum + StamatCoffeine <= limitPerDay)
                {
                    StamatCoffeine = StamatCoffeine + sum;
                }
                else
                {
                    if (StamatCoffeine >=30)
                    {
                        StamatCoffeine = StamatCoffeine - 30;
                    }
                    energyDrinks.Enqueue(currEnergy);
                }
            }
            if (energyDrinks.Count>0)
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            Console.WriteLine($"Stamat is going to sleep with {StamatCoffeine} mg caffeine.");
        }
    }
}
