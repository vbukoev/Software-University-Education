using System;
using System.Linq;

namespace _02SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Func<string, int> parser = n => int.Parse(n); // parser means to parse the string which is in the input, to integers in this example
            var nums = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(parser).ToArray();
            Console.WriteLine(nums.Length);
            Console.WriteLine(nums.Sum());
        }
    }
}
