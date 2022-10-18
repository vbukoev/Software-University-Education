using System;
using System.Linq;

namespace _02Garden
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = data[0];
            int cols = data[1];
            int[,] matrix = new int[rows, cols];
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Bloom Bloom Plow") break;
                int row = input.Split().Select(int.Parse).First();
                int col = input.Split().Select(int.Parse).Last();
                if (Invalid(rows, cols, row, col))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    matrix[row, i]++;
                }
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, col]++;
                }
                matrix[row, col]--;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine(); ;
            }
        }

        public static bool Invalid(int rows, int cols, int row, int col)
        {
            return row < 0 || row >= rows || col < 0 || col >= cols;
        }
    }
}