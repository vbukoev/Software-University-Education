using System;

namespace _01._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            Console.WriteLine(SmallestNumber(num1, num2, num3));
            PrintTheSmallestNum(num1, num2, num3);  
        }

        static int SmallestNumber(int a, int b, int c)
        {
            return Math.Min(a,Math.Min(b,c));
        }
        static void PrintTheSmallestNum(int a, int b, int c) => Console.WriteLine(Math.Min(a, Math.Min(b,c)));



        //static void Main(string[] args)
        //{
        //    int firstNum = int.Parse(Console.ReadLine());
        //    int secondNum = int.Parse(Console.ReadLine());
        //    int thirdNum = int.Parse(Console.ReadLine());

        //    SmallestOfThreeNumbers(firstNum, secondNum, thirdNum);
        //}
        //static void SmallestOfThreeNumbers(int firstNum, int secondNum, int thirdNum)
        //{
        //    if (firstNum <= secondNum && firstNum <= thirdNum)
        //    {
        //        Console.WriteLine(firstNum); 
        //    }
        //    else if (secondNum <= firstNum && secondNum <= thirdNum)
        //    {
        //        Console.WriteLine(secondNum); 
        //    }
        //    else 
        //    {
        //        Console.WriteLine(thirdNum); 
        //    }
        //}

    }
}
