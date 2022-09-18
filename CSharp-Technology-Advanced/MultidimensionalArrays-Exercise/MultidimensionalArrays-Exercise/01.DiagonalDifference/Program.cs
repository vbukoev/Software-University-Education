using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizes = int.Parse(Console.ReadLine()); // N
            var matrix = new int[sizes, sizes];
            for (int row = 0; row < sizes; row++)
            {
                var currRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < currRow.Length; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }
            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;
            int currCol = 0;
             // gets the difference between the primary and the secondary diagonal
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int col = row;
                primaryDiagonal += matrix[row, col];
            }
            for (int row = matrix.GetLength(0)-1; row>=0; row--)
            {
                secondaryDiagonal += matrix[row, currCol];

                currCol++;
            }
            int diff = primaryDiagonal - secondaryDiagonal;
            Console.WriteLine(Math.Abs(diff));
        }
    }
}
