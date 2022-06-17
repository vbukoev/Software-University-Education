using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bombNum = tokens[0];
            int power = tokens[1];

            for (int index = 0; index < numbers.Count; index++)
            {
                int target = numbers[index];
                if (target == bombNum)
                {
                    BombNumber(numbers, power, index);
                }
            }
            Console.WriteLine(numbers.Sum());
        }

        private static void BombNumber(List<int> numbers, int power, int index)
        {
            int start = Math.Max(0, index-power);
            int end = Math.Min(numbers.Count - 1, index+power);
            for (int i = start; i <= end; i++)
            {
                numbers[i] = 0;
            }
        }
    }
}
