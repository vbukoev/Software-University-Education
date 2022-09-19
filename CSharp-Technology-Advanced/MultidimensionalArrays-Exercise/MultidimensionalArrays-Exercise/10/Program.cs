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
            string moves = Console.ReadLine();
            foreach (char move in moves)
            {
                bool playerWon = false;
                bool playerLost = false;
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;   
                switch (move)
                {
                    case 'U':
                        matrix[playerRow, playerCol] = '.';
                        newPlayerRow--;
                        MovePlayer(newPlayerRow, playerCol, matrix, ref playerWon, ref playerLost);
                        break;
                    case 'D':
                        matrix[playerRow, playerCol] = '.';
                        newPlayerRow++;
                        MovePlayer(newPlayerRow, playerCol, matrix, ref playerWon, ref playerLost);
                        break;
                    case 'L':
                        matrix[playerRow, playerCol] = '.';
                        newPlayerCol--;
                        MovePlayer(playerRow, newPlayerCol, matrix, ref playerWon, ref playerLost);
                        break;
                    case 'R':
                        matrix[playerRow, playerCol] = '.';
                        newPlayerCol++;
                        MovePlayer(playerRow, newPlayerCol, matrix, ref playerWon, ref playerLost);
                        break;

                    default:
                        break;
                }
                //Spread bunnies

                if (playerWon)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                }

                playerRow = newPlayerRow;
                playerCol = newPlayerCol;
            }
        }

        private static void PrintMatrix(char[,] matrix)
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

        static void MovePlayer(int playerRow, int playerCol, char[,] matrix, ref bool playerWon, ref bool playerLost)
        {
            if (IsCellValid(playerRow, playerCol, matrix))
            {
                if (matrix[playerRow, playerCol] == 'B')
                {
                    playerLost = true;
                }
                else
                {
                    matrix[playerRow, playerCol] = 'P';
                }
            }
            else
            {
                playerWon = true;
            }
        }
        static bool IsCellValid(int row, int col, char[,] matrix)
        {
            return row >= 0 
                && row < matrix.GetLength(0)
                && col >= 0 
                && col < matrix.GetLength(1);
        }
    }
}