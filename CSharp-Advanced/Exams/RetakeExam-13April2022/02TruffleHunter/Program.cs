using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;

namespace _02TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            int blackTrufflesCnt = 0;
            int summerTrufflesCnt = 0;
            int whiteTrufflesCnt = 0;
            int BoarCnt = 0;
            for (int row = 0; row < n; row++)
            {
                var currElement = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currElement[col];
                }
            }
            var command = Console.ReadLine().Split().ToArray();

            while (command[0] != "Stop")
            {
                string cmd = command[0];
                int rowInput = int.Parse(command[1]);
                int colInput = int.Parse(command[2]);

                switch (cmd)
                {
                    case "Collect":
                        if (rowInput >= 0 && rowInput < matrix.GetLength(0) && colInput >= 0 && colInput < matrix.GetLength(1))
                        {
                            switch (matrix[rowInput, colInput])
                            {
                                case 'B':
                                    {
                                        blackTrufflesCnt++;
                                        matrix[rowInput, colInput] = '-';
                                    }
                                    break;
                                case 'S':
                                    {
                                        summerTrufflesCnt++;
                                        matrix[rowInput, colInput] = '-';
                                    }
                                    break;
                                case 'W':
                                    {
                                        whiteTrufflesCnt++;
                                        matrix[rowInput, colInput] = '-';
                                    }
                                    break;
                                case '-':
                                    {
                                        command = Console.ReadLine().Split().ToArray();
                                        continue;                                        
                                    }
                            }
                        }
                        break;
                    case "Wild_Boar":
                        var inputCommand = command[3];
                        if (IsTruffle(matrix, rowInput, colInput))
                        {
                            BoarCnt++;
                            matrix[rowInput, colInput] = '-';
                        }
                        switch (inputCommand)
                        {
                            case "up":
                                for (int row = rowInput; row >= 0; row -= 2)
                                {
                                    if (IsTruffle(matrix, row, colInput))
                                    {
                                        BoarCnt++;
                                    }
                                    matrix[row, colInput] = '-';
                                }
                                break;
                            case "down":
                                for (int row = rowInput; row < matrix.GetLength(0); row += 2)
                                {
                                    if (IsTruffle(matrix, row, colInput))
                                    {
                                        BoarCnt++;
                                    }
                                    matrix[row, colInput] = '-';
                                }
                                break;
                            case "left":
                                for (int col = colInput; col >= 0; col -= 2)
                                {
                                    if (IsTruffle(matrix, rowInput, col))
                                    {
                                        BoarCnt++;
                                    }
                                    matrix[rowInput, col] = '-';
                                }
                                break;
                            case "right":
                                for (int col = colInput; col < matrix.GetLength(1); col += 2)
                                {
                                    if (IsTruffle(matrix, rowInput, col))
                                    {
                                        BoarCnt++;
                                    }
                                    matrix[rowInput, col] = '-';
                                }
                                break;
                        }
                        break;
                }
                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine($"Peter manages to harvest {blackTrufflesCnt} black, {summerTrufflesCnt} summer, and {whiteTrufflesCnt} white truffles.");
            Console.WriteLine($"The wild boar has eaten {BoarCnt} truffles.");
            Printmatrix(matrix);
        }

        private static bool IsTruffle(char[,] matrix, int rowInput, int colInput)
        {
            return matrix[rowInput, colInput] == 'B' || matrix[rowInput, colInput] == 'S' || matrix[rowInput, colInput] == 'W';
        }               

        private static void Printmatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
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