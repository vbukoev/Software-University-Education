using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"@#+[A-Z][a-zA-Z\d]{4,}[A-Z]@#+";
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string currBarcodes = Console.ReadLine();
                if (Regex.IsMatch(currBarcodes, pattern))
                {
                    var digits = currBarcodes.Where(char.IsDigit).ToArray();
                    var barcodeGroup = digits.Length == 0 ? "00" : String.Join("", digits);
                    Console.WriteLine($"Product group: {barcodeGroup}");
                }
                else Console.WriteLine("Invalid barcode");
            }
        }
    }
}
