using System;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine()); // rows Count which is equal to the nums of jagged arrays's length
            int[][] jagged = new int[rowsCount][];

            for (int row = 0; row < jagged.Length; row++)
            {
                string[] nums = Console.ReadLine().Split(' ');
                jagged[row] = new int[nums.Length];
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] = int.Parse(nums[col]);
                }
            }           
        }
    }
}
