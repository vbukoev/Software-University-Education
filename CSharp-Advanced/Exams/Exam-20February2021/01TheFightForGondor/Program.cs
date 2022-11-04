using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace _01TheFightForGondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> orcs = new Stack<int>();
            int plate = plates.Peek();
            for (int i = 1; i <= n; i++)
            {
                orcs = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
                if (i % 3 == 0) plates.Enqueue(int.Parse(Console.ReadLine()));
                int orc = orcs.Peek();
                while (true)
                {
                    if (!plates.Any() || !orcs.Any()) break;
                    int damage = Math.Min(plate, orc);
                    plate = plate - damage;
                    orc = orc - damage;
                    if (orc == 0)
                    {
                        orcs.Pop();
                        if (orcs.Any()) orc = orcs.Peek();
                    }
                    if (plate == 0)
                    {
                        plates.Dequeue();
                        if (plates.Any()) plate = plates.Peek();
                    }
                }
                if (!plates.Any())
                {
                    orcs.Pop();
                    orcs.Push(orc);
                    break;
                }
            }
            if (orcs.Any())//orcs
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
            else //plates
            {
                List<int> left = new List<int>(plates);
                left[0] = plate;
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", left)}");
            }
        }
    }
}
