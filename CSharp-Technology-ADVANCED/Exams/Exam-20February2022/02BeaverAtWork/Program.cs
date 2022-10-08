using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.InteropServices;

namespace _02BeaverAtWork
{
    public class Program
    {
        private static char[,] matrix;
        private static List<char> branchesCollected = new List<char>();
        private static int cntTotalBranches = 0;
        private static string lastDirection;
        private static int beaverRow;
        private static int beaverCol;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            matrix = new char[n, n];
            for (int i = 0; i < n; i++) //filling up the input matrix
            {
                char[] input = Console.ReadLine().Replace(" ", "").ToCharArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];
                    if (matrix[i, j] == 'B')
                    {
                        beaverRow = i;
                        beaverCol = j;
                    }
                    else if (char.IsLower(matrix[i, j]))
                    {
                        cntTotalBranches++;
                    }
                }
            }
            while (true)
            {
            string cmd = Console.ReadLine();
                if (cmd == "end") break;
                lastDirection = cmd;
                switch (cmd)
                {
                    case "up": Move(-1, 0); break;
                    case "down": Move(1, 0); break;
                    case "left": Move(0, -1); break;
                    case "right": Move(0, 1); break;
                }
                if (cntTotalBranches == 0)
                {
                    break;
                }
            }
            if (cntTotalBranches > 0)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {cntTotalBranches} branches left.");
            }
            else
            {
                Console.WriteLine($"The Beaver successfully collect {branchesCollected.Count} wood branches: {string.Join(", ", branchesCollected)}.");
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void Move(int row, int col)
        {
            if (!RangeFilter(beaverRow + row, beaverCol + col))
            {
                if (branchesCollected.Any())
                {
                    branchesCollected.Remove(branchesCollected[branchesCollected.Count - 1]);
                }
                return;
            }
            matrix[beaverRow, beaverCol] = '-';
            beaverRow += row;
            beaverCol += col;
            if (char.IsLower(matrix[beaverRow, beaverCol]))
            {
                branchesCollected.Add(matrix[beaverRow, beaverCol]);
                matrix[beaverRow, beaverCol] = 'B';
                cntTotalBranches--;
            }
            else if (matrix[beaverRow, beaverCol] == 'F')
            {
                matrix[beaverRow, beaverCol] = '-';
                if (lastDirection == "up")
                {
                    if (beaverRow == 0)
                    {
                        if (char.IsLower(matrix[matrix.GetLength(0) - 1, beaverCol]))
                        {
                            branchesCollected.Add(matrix[matrix.GetLength(0) - 1, beaverCol]);
                            cntTotalBranches--;
                        }
                        beaverRow = matrix.GetLength(0) - 1;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else
                    {
                        if (char.IsLower(matrix[0, beaverCol]))
                        {
                            branchesCollected.Add(matrix[0, beaverCol]);
                            cntTotalBranches--;
                        }
                        beaverRow = 0;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                }
                else if (lastDirection == "down")
                {
                    if (beaverRow == matrix.GetLength(0) - 1)
                    {
                        if (char.IsLower(matrix[0, beaverCol]))
                        {
                            branchesCollected.Add(matrix[0, beaverCol]);
                            cntTotalBranches--;
                        }
                        beaverRow = 0;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else
                    {
                        if (char.IsLower(matrix[matrix.GetLength(0) - 1, beaverCol]))
                        {
                            branchesCollected.Add(matrix[matrix.GetLength(0) - 1, beaverCol]);
                            cntTotalBranches--;
                        }
                        beaverRow = matrix.GetLength(0) - 1;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                }
                else if (lastDirection == "left")
                {
                    if (beaverCol == 0)
                    {
                        if (char.IsLower(matrix[beaverRow, matrix.GetLength(1) - 1]))
                        {
                            branchesCollected.Add(matrix[beaverRow, matrix.GetLength(1) - 1]);
                            cntTotalBranches--;
                        }
                        beaverCol = matrix.GetLength(1) - 1;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else
                    {
                        if (char.IsLower(matrix[beaverRow, 0]))
                        {
                            branchesCollected.Add(matrix[beaverRow, 0]);
                            cntTotalBranches--;
                        }
                        beaverCol = 0;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                }
                else if (lastDirection == "right")
                {
                    if (beaverCol == matrix.GetLength(1) - 1)
                    {
                        if (char.IsLower(matrix[beaverRow, 0]))
                        {
                            branchesCollected.Add(matrix[beaverRow, 0]);
                            cntTotalBranches--;
                        }
                        beaverCol = 0;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else
                    {
                        if (char.IsLower(matrix[beaverRow, matrix.GetLength(1) - 1]))
                        {
                            branchesCollected.Add(matrix[beaverRow, matrix.GetLength(1) - 1]);
                            cntTotalBranches--;
                        }
                        beaverCol = matrix.GetLength(1) - 1;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                }
            }
        }

        private static bool RangeFilter(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
