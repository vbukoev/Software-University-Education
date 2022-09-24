using System;
using System.Collections.Generic;
using System.Linq;

namespace _02SetsOf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int first = numbers[0];
            int second = numbers[1];
            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();
            var newSet = new HashSet<int>();
            
            for (int i = 0; i < first; i++)
            {
                int num = int.Parse(Console.ReadLine());
                firstSet.Add(num);
            }

            for (int i = 0; i < second; i++)
            {
                int num = int.Parse(Console.ReadLine());
                secondSet.Add(num);
            }

            firstSet.IntersectWith(secondSet);

            //foreach (var firstNum in firstSet)
            //{
            //    foreach (var secondNum in secondSet)
            //    {
            //        if (firstNum == secondNum) newSet.Add(firstNum); 
            //    }
            //}

            Console.WriteLine(String.Join(" ", firstSet)); //another way of cw
            
            //foreach (var item in newSet) Console.Write(item + " ");
        }
    }
}
