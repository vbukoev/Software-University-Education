using System;
using System.Collections.Generic;
using System.Linq;

namespace _05AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>();
            nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "end") break;
                    switch (cmd)
                    {
                        case "add":
                            nums = nums.Select(x => x + 1).ToList();
                            break;
                        case "multiply":
                            nums = nums.Select(x => x * 2).ToList();
                            break;
                        case "subtract":
                            nums = nums.Select(x => x - 1).ToList();
                            break;
                        case "print":
                            Console.WriteLine(String.Join(" ", nums));
                            break;
                        default:
                            break;
                    }
            }
        }
    }
}
