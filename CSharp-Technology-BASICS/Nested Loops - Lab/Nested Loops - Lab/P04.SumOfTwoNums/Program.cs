using System;

namespace P04.SumOfTwoNums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int combination = 0;
            bool isMagicCombinationFound = false;
            for (int firstNumber = startNumber; firstNumber <= endNumber; firstNumber++)
            {
                for (int secondNumber = startNumber; secondNumber <= endNumber; secondNumber++)
                {
                    combination++;
                    if (firstNumber + secondNumber == magicNumber)
                    {
                        isMagicCombinationFound = true;
                        Console.WriteLine($"Combination N:{combination} ({firstNumber} + {secondNumber} = {firstNumber+secondNumber})");
                    }
                    if (isMagicCombinationFound)
                    {
                        break;
                    }
                   
                }
                if (isMagicCombinationFound)
                {
                    break;
                }               
            }
            if (!isMagicCombinationFound)
            {
                Console.WriteLine($"{combination} combinations - neither equals {magicNumber}");
            }
        }
            
    }
}
