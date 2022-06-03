using System;
using System.Linq;

namespace _05._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                bool currIterationNumIsBigger = true;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] <= arr[j])
                    {
                        currIterationNumIsBigger = false;
                    }
                }
                if (currIterationNumIsBigger)
                {
                    Console.Write($"{arr[i]} ");
                }
            }
        }
    }
}
