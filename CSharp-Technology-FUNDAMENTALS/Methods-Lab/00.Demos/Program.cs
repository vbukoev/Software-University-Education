using System;

namespace _00.Demos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintNumbers(1, 5);
            PrintNumbers(2, 6);
            PrintNumbers(3, 7);
        }
        static void PrintNumbers(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                Console.WriteLine("{0}", i );
            }
            Console.WriteLine();
        }
    }
}
