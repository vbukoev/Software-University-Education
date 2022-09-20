using System;
using System.Linq;

namespace _09Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cmd = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[][] field = new string[n][];
            var minerIndex = new int[2];
            int totalCoalCnt = 0;   

            for (int row = 0; row < n; row++)
            {
                field[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < n; col++)

                {
                    string copy = field[row][col];
                    switch (copy)
                    {
                        case "s":
                            minerIndex[0] = row;
                            minerIndex[1] = col;
                            break;
                        case "c":
                            totalCoalCnt++;
                            break;
                        default:
                            break;
                    }
                }
 
            }

        }
    }
}
