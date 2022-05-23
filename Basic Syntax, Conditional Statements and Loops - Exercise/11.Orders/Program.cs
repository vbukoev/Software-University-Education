using System;

namespace _11.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double cntOfOrdersShopReceivesN = int.Parse(Console.ReadLine()); // !!!May be a need of Math.Ceiling !!!
            double totalPrice = 0;
            for (int i = 1; i <= cntOfOrdersShopReceivesN; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCnt = int.Parse(Console.ReadLine());
                double priceOfOrders = ((days * capsulesCnt) * pricePerCapsule);
                Console.WriteLine($"The price for the coffee is: {priceOfOrders:F2}");
                totalPrice += priceOfOrders;
            }
            
            Console.WriteLine($"Total: {totalPrice:F2}");
        }
    }
}
