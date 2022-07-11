using System;
using System.Collections.Generic;
using System.Linq;
namespace _04.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var orders = new Dictionary<string, double>();
            var newOrders = new Dictionary<string, int>();
            var input = Console.ReadLine();
            while (input != "buy")
            {
                var cmd = input.Split(" ");
                var productName = cmd[0];
                double productPrice = double.Parse(cmd[1]);
                int quantity = int.Parse(cmd[2]);
                if (!orders.ContainsKey(productName))
                {
                    orders.Add(productName, productPrice);
                    newOrders.Add(productName, quantity);
                }
                else if (orders.ContainsKey(productName))
                {
                    orders.Remove(productName);
                    orders.Add(productName, productPrice);
                    newOrders[productName] += quantity;
                }
                input = Console.ReadLine();
            }

            foreach (var order in orders)
            {
                foreach (var newOrder in newOrders)
                {
                    if (order.Key == newOrder.Key)
                    {
                        Console.WriteLine($"{order.Key} -> {order.Value * newOrder.Value:f2}");
                    }
                }
            }


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //var products = new Dictionary<string, double[]>();
            //while (true)
            //{
            //    string command = Console.ReadLine();
            //    if (command == "buy") break;
            //    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            //    string prodcut = tokens[0];
            //    double price = double.Parse(tokens[1]);
            //    int quantity = int.Parse(tokens[2]);
            //    if (!products.ContainsKey(prodcut))
            //    {
            //        products[prodcut] = new double[2];
            //        products[prodcut][0] = price;
            //        products[prodcut][1] = quantity;
            //    }
            //    else
            //    {
            //        products[prodcut][0] = price;
            //        products[prodcut][1] += quantity;
            //    }
            //}
            //foreach (var item in products) Console.WriteLine($"{item.Key} -> {(item.Value[0] * item.Value[1]):f2}");
        }
    }
}