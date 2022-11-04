using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02Warships
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> tokens = new Queue<string>(Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray());
            char[,] matrix = ReadMatrix(n);
            int firstPlayerShips = ShipsCount(matrix, '<');
            int secondPlayerShips = ShipsCount(matrix, '>');
            while (true)
            {
                if (!tokens.Any() || firstPlayerShips <= 0 || secondPlayerShips <= 0) break;
                string command = tokens.Dequeue();
                int row = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).First();
                int col = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).Last();
                if (!ValidationOfIndex(n, row, col)) continue;
                char symbol = matrix[row, col];
                switch (symbol)
                {
                    case '<':
                        firstPlayerShips--;
                        matrix[row, col] = 'X';
                        break;
                    case '>':
                        secondPlayerShips--;
                        matrix[row, col] = 'X';
                        break;
                    case '#':
                        for (int i = row - 1; i <= row + 1; i++)
                        {
                            for (int j = col - 1; j <= col + 1; j++)
                            {
                                if (!ValidationOfIndex(n, i, j)) continue;
                                switch (matrix[i, j])
                                {
                                    case '<':
                                        firstPlayerShips--;
                                        matrix[i, j] = 'X';
                                        break;
                                    case '>':
                                        secondPlayerShips--;
                                        matrix[i, j] = 'X';
                                        break;
                                }
                            }
                        }
                        break;
                }
            }
            Print(firstPlayerShips, secondPlayerShips, ShipsCount(matrix, 'X'));
        }

        public static void Print(int firstPlayerShips, int secondPlayerShips, int destroyed)
        {
            if (secondPlayerShips <= 0) Console.WriteLine($"Player One has won the game! {destroyed} ships have been sunk in the battle.");
            else if (firstPlayerShips <= 0) Console.WriteLine($"Player Two has won the game! {destroyed} ships have been sunk in the battle.");
            else Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
        }

        public static bool ValidationOfIndex(int n, int row, int col)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }

        public static int ShipsCount(char[,] matrix, char v)
        {
            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == v) cnt++;
                }
            }
            return cnt;
        }

        public static char[,] ReadMatrix(int n)
        {
            char[,] matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                char[] currLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < n; j++) matrix[i, j] = currLine[j];
            }
            return matrix;
        }
    }
}