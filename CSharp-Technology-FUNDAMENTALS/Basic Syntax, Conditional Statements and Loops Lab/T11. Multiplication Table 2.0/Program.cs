using System;

namespace T11._Multiplication_Table_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int theInteger = int.Parse(Console.ReadLine());
            int times = int.Parse(Console.ReadLine());
            do
            {
                Console.WriteLine($"{theInteger} X {times} = {theInteger * times}");
                times++;
            } while (times <= 10);
            
        }
    }
}
