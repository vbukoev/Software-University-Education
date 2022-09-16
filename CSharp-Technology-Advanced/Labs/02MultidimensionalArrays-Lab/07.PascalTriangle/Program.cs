using System;

namespace _07.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] pascal = new long[n][];
            for (int row = 0; row < n; row++)
            {
                pascal[row] = new long[row + 1];
                for (int col = 0; col < pascal[row].Length; col++)
                {
                    if (row == 0)
                    {
                        pascal[row][col] = 1;
                        continue;
                    }
                    long currValue = 0;
                    //matrix[row-1, col]
                    //matrix[row-1, col-1]
                    if (col > 0 && row > 0)
                    {
                        currValue += pascal[row - 1][col - 1];
                    }
                    if (pascal[row].Length - 1 > col) // pascal[row].Length - 1 
                    {
                        currValue += pascal[row - 1][col];
                    }
                    pascal[row][col] = currValue;
                }
            }
            for (int row = 0; row < pascal.Length; row++)
            {
                for (int col = 0; col < pascal[row].Length; col++)
                {
                    Console.Write(pascal[row][col] + " " );
                }
                Console.WriteLine();
            }
        }
    }
}
