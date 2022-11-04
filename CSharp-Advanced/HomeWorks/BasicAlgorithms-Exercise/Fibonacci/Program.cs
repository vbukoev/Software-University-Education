using System;

namespace Fibonacci
{
    public class Program
    {
        static void Main(string[] args) //THIS WAY IS NOT THE BEST FIBONACCI FUNC, BECAUSE OF THE RECURSION :) 
        {
            int position = int.Parse(Console.ReadLine());
            int fibonacci = Fibonacci(position);
            Console.WriteLine(fibonacci);
        }

        private static int Fibonacci(int position)
        {
            if (position == 0) return 0; 
            if (position == 1) return 1; 

            int previous = Fibonacci(position - 1);
            Console.WriteLine($"Fib({position-1})");

            int secPrevious = Fibonacci(position - 2);
            Console.WriteLine($"Fib({position - 2})");
            return previous + secPrevious;
        }
    }
}
