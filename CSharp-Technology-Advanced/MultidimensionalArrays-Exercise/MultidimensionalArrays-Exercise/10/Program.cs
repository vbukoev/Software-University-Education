using System;
using System.Linq;

namespace _10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int playerRow = 0;
            int playerCol = 0;
            var matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var chars = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = chars[col];
                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
    }
}
