using System;

namespace P01._Number_Pyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int curr = 1;
            bool isBigger = false;
            for (int rows = 1; rows <= n; rows++)
            {
                for (int cols = 1; cols <= rows; cols++)
                {
                    if (curr > n)
                    {
                        isBigger = true;
                        break;
                    }
                    Console.Write(curr + " ");
                    curr++;
                }
                if (isBigger)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
