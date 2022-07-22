using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^[^|$%.]*%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<qtity>\d+)\|[^|$%.]*?(?<price>\d+\.?\d*)[^|$%.]*\$";

            Regex regex = new Regex(pattern);
            double income = 0;

            while (true)
            {
                string line = Console.ReadLine();          //customer, product, count and a price:

                if (line == "end of shift") break;              

                Match match = regex.Match(line);

                if (match.Success == false) continue; 

                string customer = match.Groups["customer"].Value;
                string product = match.Groups["product"].Value;
                int quantity = int.Parse(match.Groups["qtity"].Value);
                double price = (double.Parse)(match.Groups["price"].Value);

                double totalCustomerIncome = price * quantity;
                income += totalCustomerIncome;

                Console.WriteLine($"{customer}: {product} - {totalCustomerIncome:f2}");
            }
            Console.WriteLine($"Total income: {income:f2}");
        }
    }
}
