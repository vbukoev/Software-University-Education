using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            var matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currRow = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++) matrix[row, col] = currRow[col];
            }
            int sum = int.MinValue;
            int rowIndex = int.MinValue;
            int colIndex = int.MinValue;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row+1, col] + matrix[row+1, col+1];
                    if (currSum > sum)
                    {
                        sum = currSum;
                        rowIndex = row;
                        colIndex = col;
                    }
                    
                }
            }
            Console.WriteLine($"{matrix[rowIndex, colIndex]} {matrix[rowIndex, colIndex+1]}");
            Console.WriteLine($"{matrix[rowIndex+1, colIndex]} {matrix[rowIndex+1, colIndex+1]}");
            Console.WriteLine(sum);
                                                                                                       
        }
    }
}
