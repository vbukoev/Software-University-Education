using System;

namespace P02._Numbers_N1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number =int.Parse(Console.ReadLine()); // input from the user
            for (int i = number; i >= 1; i--) // i trqbva da zapochva ot number; i >=1; i namalqva sus 1 edinica nadolu pri izpulnenie na cikul
            {
                Console.WriteLine(i);
            }
        }
    }
}
