using System;

namespace _02._Sum_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int digit = int.Parse(Console.ReadLine());
            //int finalSum = 0;

            //while (digit!=0)
            //{
            //    int lastDigit = digit % 10;
            //    finalSum += lastDigit;
            //    digit /= 10;
            //}
            //Console.WriteLine(finalSum);

            string input = Console.ReadLine();
            char[] charArray = input.ToCharArray();
            int finalSum = 0;
            for (int value = 0; value < charArray.Length; value++)
            {
                finalSum += int.Parse(charArray[value].ToString());
            }
            Console.WriteLine(finalSum);
        }
    }
}
