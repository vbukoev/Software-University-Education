using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
            var cnts = new SortedDictionary<double, int>();
            foreach (var number in numbers)
            {
                if (cnts.ContainsKey(number))
                {
                    int currOcc = cnts[number];
                    currOcc += 1;
                    cnts[number] = currOcc;
                }
                else cnts.Add(number, 1);
            }

            //{
            //    if (cnts.ContainsKey(number)) cnts[number]++;
            //    else cnts.Add(number, 1);
            //}
            foreach (var item in cnts) Console.WriteLine($"{item.Key} -> {item.Value}");
        }
    }
}
