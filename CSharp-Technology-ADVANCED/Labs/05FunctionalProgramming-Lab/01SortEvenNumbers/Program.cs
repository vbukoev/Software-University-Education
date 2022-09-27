using System;
using System.Linq;

namespace _01SortEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine().Split(new String[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Where(n => n % 2 == 0).OrderBy(n => n).ToArray()));
        }
    }
}
