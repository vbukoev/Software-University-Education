using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _05AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> nums = new List<int>();
            //nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            //while (true)
            //{
            //    string cmd = Console.ReadLine();
            //    if (cmd == "end") break;
            //        switch (cmd)
            //        {
            //            case "add":
            //                nums = nums.Select(x => x + 1).ToList();
            //                break;
            //            case "multiply":
            //                nums = nums.Select(x => x * 2).ToList();
            //                break;
            //            case "subtract":
            //                nums = nums.Select(x => x - 1).ToList();
            //                break;
            //            case "print":
            //                Console.WriteLine(String.Join(" ", nums));
            //                break;
            //            default:
            //                break;
            //        }
            //}

            Action<List<int>> subtract = numbers =>
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i]--;
                }
            };
            Action<List<int>> multiply = numbers =>
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i]*=2;
                }
            };
            Action<List<int>> add = numbers =>
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i]++;
                }
            };

            Action<List<int>> print = numbers => Console.WriteLine(String.Join(" ", numbers));
            List<int> nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            while (true)
            {
                var cmd = Console.ReadLine();
                if (cmd == "end") break;
                switch (cmd)
                {
                    case "add":
                        add(nums);
                        break;

                    case "subtract":
                        subtract(nums);
                        break;
                        
                    case "multiply":
                        multiply(nums);
                        break;

                    case "print":
                        print(nums);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
