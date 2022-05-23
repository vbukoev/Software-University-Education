    using System;

    namespace T10._Multiplication_Table
    {
        internal class Program
        {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int times = 1; times <= 10; times++)
            {
                Console.WriteLine($"{number} X {times} = {number * times}");
            }
        }
        }
    }
