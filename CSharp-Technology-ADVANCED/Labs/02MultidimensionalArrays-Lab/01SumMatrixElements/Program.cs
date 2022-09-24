using System;
using System.Linq;

namespace _01SumMatrixElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[sizes[0], sizes[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                    matrix[row, col] = colElements[col];
            }
            int sum = 0;
            foreach (var element in matrix)
            {
                sum += element;
            }
            int rows = sizes[0];
            int cols = sizes[1];
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);    
        }
    }
}
