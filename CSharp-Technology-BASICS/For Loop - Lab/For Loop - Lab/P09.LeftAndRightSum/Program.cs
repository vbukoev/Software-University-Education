using System;

namespace P09.LeftAndRightSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfInputs = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;
            for (int i = 0; i<2*countOfInputs; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if(i<countOfInputs)
                {
                    leftSum += currentNumber;
                }
                else
                {
                    rightSum += currentNumber;
                }
            }
            if (leftSum==rightSum)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(leftSum-rightSum)}");
            }
        }
    }
}
