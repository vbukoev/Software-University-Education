using System;
using System.Collections.Generic;
using System.Linq;

namespace _05SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            char[,] matrix = new char[rows, cols];
            string input = Console.ReadLine();
            Queue<char> snake = new Queue<char>(input);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        var currSymbol = snake.Peek();
                        snake.Enqueue(currSymbol);
                        matrix[row, col] = snake.Dequeue();
                    }
                }
                else if (row % 2 == 1)
                {
                    for (int col = matrix.GetLength(1) - 1; col >=0 ; col--)
                    {
                        var currSymbol = snake.Peek();
                        snake.Enqueue(currSymbol);
                        matrix[row, col] = snake.Dequeue();
                    }
                }
            }
            Print(matrix);
        }

        private static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
