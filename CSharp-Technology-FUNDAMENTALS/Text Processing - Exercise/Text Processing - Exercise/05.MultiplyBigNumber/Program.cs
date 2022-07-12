using System;
using System.Numerics;

namespace _05.MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigInteger firstNum = BigInteger.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            BigInteger res = firstNum * secondNum;
            Console.WriteLine(res);
        }
    }
}
