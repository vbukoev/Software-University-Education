using System;
using System.Linq;

namespace _04MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            var matrix = new string[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
                
            }
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END") break;
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var action = tokens[0];
                if (action == "swap")
                {
                    if (tokens.Length - 1 == 4)
                    {
                        int firstRow = int.Parse(tokens[1]);
                        int firstCol = int.Parse(tokens[2]);
                        int secRow = int.Parse(tokens[3]);
                        int secCol = int.Parse(tokens[4]);
                        if (firstRow >= 0 && firstRow < matrix.GetLength(0) && secRow >= 0 && secRow < matrix.GetLength(0) && firstCol >= 0 && firstCol < matrix.GetLength(1) && secCol >= 0 & secCol < matrix.GetLength(1))
                        {
                            string tempMatrix = matrix[firstRow, firstCol];
                            matrix[firstRow, firstCol] = matrix[secRow, secCol];
                            matrix[secRow, secCol] = tempMatrix;

                            Print(matrix);
                        }
                        else Console.WriteLine("Invalid input!");
                    }
                    else Console.WriteLine("Invalid input!");
                }
                else Console.WriteLine("Invalid input!");
            }
        }

        private static void Print(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++) // printing the matrix
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

