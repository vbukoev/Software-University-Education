using System;
using System.Linq;

namespace _08Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowCols = int.Parse(Console.ReadLine());
            var matrix = new int[rowCols, rowCols];
            int alive = 0;
            int sumAlive = 0;
            for (int row = 0; row < rowCols; row++)
            {
                var currRow = Console.ReadLine().Split().Select(n => int.Parse(n)).ToArray();
                for (int col = 0; col < rowCols; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }
            var cmds = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var item in cmds)
            {
                var coordinates = item.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
        }
    }
}
