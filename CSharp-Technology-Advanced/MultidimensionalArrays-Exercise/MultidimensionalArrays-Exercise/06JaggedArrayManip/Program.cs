using System;
using System.Linq;

namespace _06JaggedArrayManip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jaggedMatrix = new double[n][];
            for (int row = 0; row < n; row++)
            {
                double[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                jaggedMatrix[row] = data;
            }
            for (int row = 0; row < n-1; row++)
            {
                double[] rowArray = jaggedMatrix[row];
                double[] secRowArray = jaggedMatrix[row + 1];
                if (rowArray.Length == secRowArray.Length) // if the two arrays have equal length  -> multiply
                {
                    jaggedMatrix[row] = rowArray.Select(x => x * 2).ToArray();
                    jaggedMatrix[row + 1] = secRowArray.Select(x => x * 2).ToArray();
                }
                else // or if they don't have  ->  divide
                {
                    jaggedMatrix[row] = rowArray.Select(x => x / 2).ToArray();
                    jaggedMatrix[row + 1] = secRowArray.Select(x => x / 2).ToArray();
                }
            }
            while (true)
            {
                var cmd = Console.ReadLine();
                if (cmd == "End") break;
                var tokens = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int rowIndex = int.Parse(tokens[1]);
                int colIndex = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                if (rowIndex >=0 && rowIndex < n && colIndex >= 0 && colIndex <jaggedMatrix[rowIndex].Length) continue;
                string action = tokens[0];
                switch (action)
                {
                    case "Add":
                        jaggedMatrix[rowIndex][colIndex] += value; // adding the value to the matrix
                        break;
                    case "Substract":
                        jaggedMatrix[rowIndex][colIndex] -= value; // substracting the value from the matrix
                        break;
                    default:
                        break;
                }
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedMatrix[i]));
            }
        }
    }
}
