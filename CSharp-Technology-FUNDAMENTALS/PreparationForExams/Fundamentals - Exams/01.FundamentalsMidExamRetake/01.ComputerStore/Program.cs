using System;

namespace _01.ComputerStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double priceWithoutTax = 0;
            double tax = 0; 
            double sumTax = 0;
            double total = 0;
            while(command != "special" && command != "regular")
            {
                double price = double.Parse(command);
                if (price <0)
                {
                    Console.WriteLine("Invalid price!");
                    command = Console.ReadLine();
                }
                else
                {
                    priceWithoutTax += price;
                    tax = 0.2 * price;
                    sumTax += tax;
                    total += price * 1.2;
                    command = Console.ReadLine();
                }
            }
            if (total == 0)
            {
                Console.WriteLine("Invalid order!");
            }

            else if(command == "special")
            {
                total *= 0.9;
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {priceWithoutTax:F2}$");
                Console.WriteLine($"Taxes: {sumTax:F2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {total:F2}$");
            }
            else if(command == "regular")
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {priceWithoutTax:F2}$");
                Console.WriteLine($"Taxes: {sumTax:F2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {total:F2}$");
            }
        }
    }
}
