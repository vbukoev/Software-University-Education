using System;

namespace P05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int firstDigit = 1; firstDigit <= 9; firstDigit++)
            {
                for (int secondDigit = 1; secondDigit <=9 ; secondDigit++)
                {
                    for (int thirdDigit = 1; thirdDigit <= 9; thirdDigit++)
                    {
                        for (int forthDigit = 1; forthDigit <=9; forthDigit++)
                        {
                            bool isSpecialNumber = n % firstDigit == 0 && n % secondDigit == 0 && n % thirdDigit == 0 && n % forthDigit == 0;
                        if(isSpecialNumber)
                            {
                                Console.Write($"{firstDigit}{secondDigit}{thirdDigit}{forthDigit} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
