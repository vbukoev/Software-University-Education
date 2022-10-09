using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            var swords = new Dictionary<string, int>();
            while (true)
            {
                if (!steel.Any() || !carbon.Any()) break;
                int steelElement = steel.Dequeue();
                int carbonElement = carbon.Pop();
                int sum = steelElement + carbonElement;
                string sword = "";
                switch (sum)
                {
                    case 70:
                        sword = "Gladius";
                        break;
                    case 80:
                        sword = "Shamshir";
                        break;
                    case 90:
                        sword = "Katana";
                        break;
                    case 110:
                        sword = "Sabre";
                        break;
                    case 150:
                        sword = "Broadsword";
                        break;
                    default:
                        carbonElement += 5;
                        carbon.Push(carbonElement);
                        continue;
                }
                if (!swords.ContainsKey(sword))
                {
                    swords.Add(sword, 0);
                }
                swords[sword]++;
            }
            if (swords.Count > 0) Console.WriteLine($"You have forged {swords.Values.Sum()} swords.");
            else Console.WriteLine("You did not have enough resources to forge a sword.");
            if (steel.Count == 0) Console.WriteLine("Steel left: none");
            else Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            if (carbon.Count == 0) Console.WriteLine("Carbon left: none");
            else Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            if (swords.Count > 0)
            {
                foreach (var kvp in swords.OrderBy(x=>x.Key)) Console.WriteLine($"{kvp.Key}: {kvp.Value}");   
            }                
        }
    }
}
