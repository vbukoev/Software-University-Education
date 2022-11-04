using System;
using System.Linq;

namespace _01GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var box = new Box<int>();
            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                box.Add(input);
            }
            var swap = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int first = swap[0];
            int second = swap[1];
            box.Swap(first, second);
            Console.WriteLine(box);
        }
    }
}
