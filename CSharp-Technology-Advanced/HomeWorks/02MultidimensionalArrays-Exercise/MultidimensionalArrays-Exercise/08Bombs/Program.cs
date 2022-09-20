using System;
using System.Linq;

namespace _08Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int alive = 0;
            int sumAlive = 0;
            var matrix = new int[size, size];
            
            ReadMatrix(size, matrix);
            
            var cmds = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Explode(size, matrix, cmds);
            
            //getting the sum of the aliveCells and their count
            AliveCellsAndTheirSum(size, matrix, ref alive, ref sumAlive);

            //printing the matrix
            PrintMatrix(size, matrix);
        }

        static void Explode(int size, int[,] matrix, string[] cmds)
        {
            foreach (var item in cmds)
            {
                var coordinates = item.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var bombRow = coordinates[0];
                var bombCol = coordinates[1];
                int bombPower = matrix[bombRow, bombCol];
                if (bombPower < 1)
                {
                    continue;
                }
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        var distance = Math.Pow(Math.Abs(row - bombRow), 2) + Math.Pow(Math.Abs(col - bombCol), 2);
                        if (matrix[bombRow, bombCol] > 0)
                        {
                            if (distance <= 2 && distance != 0 && matrix[row, col] > 0)
                            {
                                matrix[row, col] -= matrix[bombRow, bombCol];
                            }
                        }
                    }
                }
                matrix[bombRow, bombCol] = 0;
            }
        }

        static void ReadMatrix(int size, int[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                var currRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }
        }

        static void AliveCellsAndTheirSum(int rowCols, int[,] matrix, ref int alive, ref int sumAlive)
        {
            for (int row = 0; row < rowCols; row++)
            {
                for (int col = 0; col < rowCols; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        alive++;
                        sumAlive += matrix[row, col];
                    }
                }
            }

            //printing the alive cells and the sum of them
            Console.WriteLine($"Alive cells: {alive}");
            Console.WriteLine($"Sum: {sumAlive}");
        }

        static void PrintMatrix(int rowCols, int[,] matrix)
        {
            for (int row = 0; row < rowCols; row++)
            {
                for (int col = 0; col < rowCols; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
