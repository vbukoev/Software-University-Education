using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbs = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> list = new List<int>();
            var average = numbs.Average();            
            int cnt = 0;
            for (int i = 0; i < numbs.Count; i++)
            {

                if (numbs[i] > average)
                {
                    list.Add(numbs[i]);
                    cnt++;
                }
            }
            //foreach (var element in numbs) //THIS IS NOT WORKING WITH ForEach Loop 
            //{
            //    if (element > average)
            //    {
            //        list.Add(element);
            //        cnt++;
            //    }                
            //}
            if (cnt == 0)
            {
                Console.WriteLine("No");
                return;
            }
            list = list.OrderByDescending(x => x).ToList(); // C# list.Orderby descending
            if (list.Count < 5)
            {
                Console.WriteLine(string.Join(" ", list));
                return;
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(list[i]+" ");
                }
                
            }
        }
    }
}
