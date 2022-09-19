using System;
using System.Linq;

namespace _02.SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = sizes[0];
            var cols = sizes[1];
            var matrix = new string[rows, cols]; // making the matrix
            for (int row = 0; row < matrix.GetLength(0); row++) //filling the matrix 
            {
                var currRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }
            int cntOfSquares = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++) //going through the matrixandlookinfor squares
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] && matrix[row + 1, col] == matrix[row+ 1,col + 1] && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        cntOfSquares++;
                    }
                }
            }            
            Console.WriteLine(cntOfSquares);
        }
    }
}

