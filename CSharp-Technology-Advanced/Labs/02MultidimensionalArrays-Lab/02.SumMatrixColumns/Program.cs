using System;
using System.Linq;

namespace _02.SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(new[] { ' ', ',' },   StringSplitOptions.RemoveEmptyEntries ).Select(int.Parse).ToArray();
            var rows = sizes[0];
            var cols = sizes[1];
            var matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum = sum + matrix[row, col];
                }
            Console.WriteLine(sum);
            }
        }
    }
}
