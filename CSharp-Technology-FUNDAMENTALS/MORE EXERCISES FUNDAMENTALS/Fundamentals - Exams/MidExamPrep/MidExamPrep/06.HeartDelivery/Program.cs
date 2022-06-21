
//using System;
//using System.Collections.Generic;
//using System.Linq;


//internal class Program
//{
//    static void Main()
//    {
//        int[] houses = Console.ReadLine()
//            .Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries)
//            .Select(int.Parse)
//            .ToArray();
//        int index = 0;
//        string input;
//        while ((input = Console.ReadLine()) != "Love!")
//        {
//            string[] command = input.Split();
//            int jump = int.Parse(command[1]);
//            if (index + jump >= houses.Length) index = 0;
//            else index += jump;

//            if (houses[index] <= 0)
//            {
//                Console.WriteLine($"Place {index} already had Valentine's day.");
//                continue;
//            }
//            houses[index] -= 2;
//            if (houses[index] <= 0) Console.WriteLine($"Place {index} has Valentine's day.");
//        }
//        Console.WriteLine($"Cupid's last position was {index}.");
//        Console.WriteLine(houses.Any(x => x > 0) ?
//            $"Cupid has failed {houses.Where(x => x > 0).Count()} places." :
//            $"Mission was successful.");
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.HeartDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sequenceOfElements = Console.ReadLine().Split('@', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string input = Console.ReadLine();
            int index = 0;
            while (input != "Love!")
            {
                string[] command = input.Split();
                int numOfJump = int.Parse(command[1]);
                if (index + numOfJump >= sequenceOfElements.Count)
                {
                    index = 0;
                }
                else
                {
                    index += numOfJump;
                }
                if (sequenceOfElements[index] <= 0)
                {
                    Console.WriteLine($"Place {index} already had Valentine's day.");
                    input = Console.ReadLine();
                    continue;
                    
                }
                sequenceOfElements[index] -= 2;
                if (sequenceOfElements[index] <= 0)
                {
                    Console.WriteLine($"Place {index} has Valentine's day.");
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Cupid's last position was {index}.");
            Console.WriteLine(sequenceOfElements.Any(a => a > 0) ? $"Cupid has failed {sequenceOfElements.Where(a => a > 0).Count()} places." : $"Mission was successful.");
        }
    }
}
