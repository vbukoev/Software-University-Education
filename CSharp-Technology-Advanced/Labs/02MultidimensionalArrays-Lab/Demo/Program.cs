using System;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] intMatrix = 
                { 
                { 5, 2, 3, 1 },
                { 1, 9, 2, 4 },
                { 9, 8, 6, 9 }
            };
            for (int row = 0; row < intMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < intMatrix.GetLength(1); col++)
                {
                    Console.Write("{0} ", intMatrix[row, col]);
                }
                Console.WriteLine();
            }



        }
    }
}
