using System;
using System.Linq;

namespace _03MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = sizes[0];
            var cols = sizes[1];
            var matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++) // filling the matrix
            {
                var currRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            int currSum = 0;
            int maxSum = int.MinValue; // -2_147_483_648
            int rowIndex = int.MinValue;// -2_147_483_648 THIS IS THE INDEX OF THE ROW OF THE MAX SUM FROM 3X3 SQUARE 
            int colIndex = int.MinValue;// -2_147_483_648 THIS IS THE INDEX OF THE COL OF THE MAX SUM FROM 3X3 SQUARE 

            for (int row = 0; row < matrix.GetLength(0) - 2; row++) // by this we are getting a 3X3 square from the whole matrix
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + matrix[row + 2, col] + matrix[row + 2, col + 2] + matrix[row + 2, col + 1]; // summing the elements from the 3X3 square 
                    if (currSum > maxSum) // while the maxSum gets bigger than the currSum
                    {
                        maxSum = currSum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            
            Console.WriteLine($"{matrix[rowIndex, colIndex]} {matrix[rowIndex, colIndex + 1]} {matrix[rowIndex, colIndex + 2]}");
            Console.WriteLine($"{matrix[rowIndex + 1, colIndex]} {matrix[rowIndex + 1, colIndex + 1]} {matrix[rowIndex + 1, colIndex + 2]}");
            Console.WriteLine($"{matrix[rowIndex + 2, colIndex]} {matrix[rowIndex + 2, colIndex + 1]} {matrix[rowIndex + 2, colIndex + 2]}");
        }
    }
}
