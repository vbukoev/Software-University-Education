using System;
using System.Linq;
namespace _06.Jagged_ArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jagged = new int[rows][];
            for (int i = 0; i < jagged.Length; i++)
            {
                jagged[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }
            string cmd = Console.ReadLine().ToLower();
            while (cmd != "end")
            {
                string[] splitted = cmd.Split(' ');
                int row = int.Parse(splitted[1]);
                int col = int.Parse(splitted[2]);
                int value = int.Parse(splitted[3]);


                //-1
                if (row >= 0 && row < jagged.Length && col >= 0 && col < jagged[row].Length)
                {
                    if (splitted[0] == "add")
                    {
                        jagged[row][col] += value;
                    }
                    else
                    {
                        jagged[row][col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
                cmd = Console.ReadLine().ToLower();
            }
            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write($"{jagged[row][col] + " "}");
                }
                Console.WriteLine();
            }
        }
    }
}
