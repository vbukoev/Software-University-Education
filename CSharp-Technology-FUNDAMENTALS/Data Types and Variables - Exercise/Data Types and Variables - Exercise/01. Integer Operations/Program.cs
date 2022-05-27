using System;

namespace _01._Integer_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int divideNum = int.Parse(Console.ReadLine());
            int multiplyNum = int.Parse(Console.ReadLine());

            int sumNums = firstNum + secondNum;
            int devisionResult = sumNums / divideNum; 
            int multiplyResult = devisionResult * multiplyNum;

            int finalResult = (firstNum + secondNum) / divideNum * multiplyNum;
            Console.WriteLine(finalResult);           

        }
    }
}
