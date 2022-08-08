using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int waitingPeople = int.Parse(Console.ReadLine());
            List<int> liftWithWagons = Console.ReadLine().Split().Select(int.Parse).ToList();

            int maxPeople = 4;
            for (int i = 0; i < liftWithWagons.Count; i++)
            {
                for (int j = liftWithWagons[i]; j < maxPeople; j++)
                {
                    liftWithWagons[i]++;
                    waitingPeople--;

                    if (waitingPeople == 0)
                    {
                        if (liftWithWagons.Sum() < maxPeople* liftWithWagons.Count)
                        {
                            Console.WriteLine("The lift has empty spots!");
                        }
                        Console.WriteLine(string.Join(' ', liftWithWagons));
                        return;
                    }                   
                }
            }
            Console.WriteLine($"There isn't enough space! {waitingPeople} people in a queue!");
            Console.WriteLine(string.Join(' ', liftWithWagons));
        }
    }
}
