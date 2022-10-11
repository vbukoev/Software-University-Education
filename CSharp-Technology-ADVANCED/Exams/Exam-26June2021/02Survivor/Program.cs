using System;
using System.Linq;

namespace _02Survivor
{
    public class Program
    {
        static void Main(string[] args)
        {
            int playerScoreCnt = 0;
            int opponentScoreCnt = 0;
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = string.Join("", Console.ReadLine().Split()).ToCharArray();
            }
            while (true)
            {
                var inputCmd = Console.ReadLine();
                if (inputCmd == "Gong") break;
                if (inputCmd.Split().First() == "Find")
                {
                    int row = int.Parse(inputCmd.Split().Skip(1).First());
                    int col = int.Parse(inputCmd.Split().Last());
                    if (!ValidIndex(matrix, row, col))
                        return;
                    if (matrix[row][col] == 'T')
                    {
                        matrix[row][col] = '-';
                        playerScoreCnt += 1;
                    }

                }
                else
                {
                    int row = int.Parse(inputCmd.Split().Skip(1).First());
                    int col = int.Parse(inputCmd.Split().Skip(2).First());
                    string move = inputCmd.Split().Last();
                    if (!ValidIndex(matrix, row, col)) return;
                    if (matrix[row][col] == 'T')
                    {
                        matrix[row][col] = '-';
                        opponentScoreCnt += 1;
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        switch (move)
                        {
                            case "up": row--; break;
                            case "down": row++; break;
                            case "left": col--; break;
                            case "right": col++; break;
                        }
                        if (!ValidIndex(matrix, row, col)) continue;
                        if (matrix[row][col] == 'T')
                        {
                            matrix[row][col] = '-';
                            opponentScoreCnt += 1;
                        }
                    }
                }                  
                
            }
            for (int i = 0; i < matrix.Length; i++)  Console.WriteLine(string.Join(" ", matrix[i]));
            Console.WriteLine($"Collected tokens: {playerScoreCnt}");
            Console.WriteLine($"Opponent's tokens: {opponentScoreCnt}");
        }

        private static bool ValidIndex(char[][] matrix, int row, int col)
        {
            return (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length);
        }
    }
}
