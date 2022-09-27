using System;
using System.Linq;

namespace _04AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, string> VAT = x => (x * 1.2).ToString("F2");

            Console.WriteLine(String.Join(Environment.NewLine, Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).Select(VAT)));
                

            //var prices = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).Select(x => x * 1.2).ToArray();
            //foreach (var price in prices) Console.WriteLine($"{price:f2}");
        }
    }
}
