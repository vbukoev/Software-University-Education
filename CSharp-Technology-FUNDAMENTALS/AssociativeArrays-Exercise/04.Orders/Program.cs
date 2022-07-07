using System;
using System.Collections.Generic;
using System.Linq;
namespace _04.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, double[]>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "buy") break;
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string prodcut = tokens[0];
                double price = double.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);
                if (!products.ContainsKey(prodcut))
                {
                    products[prodcut] = new double[2];
                    products[prodcut][0] = price;
                    products[prodcut][1] = quantity;
                }
                else
                {
                    products[prodcut][0] = price;
                    products[prodcut][1] += quantity;
                }
            }
            foreach (var item in products) Console.WriteLine($"{item.Key} -> {(item.Value[0] * item.Value[1]):f2}");
        }
    }
}