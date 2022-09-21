using System;
using System.Collections.Generic;
using System.Linq;

namespace _04EvenTim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(num)) numbers.Add(num, 1);
                else numbers[num]++;
            }
            foreach (var item in numbers.Where(x => x.Value % 2 == 0))
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
