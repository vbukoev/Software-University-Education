using System;

namespace _02RecursiveFactorial
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(n));
        }
        static long Factorial(int num) 
        {
            if (num==0)  return 1;
            
            return num * Factorial(num-1);
        }
    }
}
