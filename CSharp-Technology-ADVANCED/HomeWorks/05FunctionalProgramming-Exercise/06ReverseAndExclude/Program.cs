using System;
using System.Linq;

namespace _06ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse().ToArray();
            int divisor = int.Parse(Console.ReadLine());
            Action<int[], int[]> reverse = (arr, reversed) =>
            {
                for (int i = 0; i < reversed.Length; i++)
                {
                    reversed[i] = arr[arr.Length - 1 - i];
                }
            };
            var reversed = new int[nums.Length];
            reverse(nums, reversed);
            Func<int, int, bool> filter = (a, b) => a % b == 0;
            Console.WriteLine(String.Join(" ", nums.Where(x=>!filter(x, divisor))));
            //Another possible solution but without predicates/funcs

            //var nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse().ToList();
            //int divisor = int.Parse(Console.ReadLine());
            //Console.WriteLine(String.Join(" ", nums.Where(x=>x%divisor!=0)));
        }
    }
}
