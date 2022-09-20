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
            int coalCnt = 0;
            int r = minerIndex[0];
            int c = minerIndex[1];
            foreach (var command in cmd)
            {
                switch (command)
                {
                    case "up":
                        if (r - 1 >= 0)
                        {
                            field[r][c] = "*";
                            r--;
                            switch (field[r][c])
                            {
                                case "c":
                                    coalCnt++;
                                    totalCoalCnt--;
                                    break;
                                case "e":
                                    Console.WriteLine($"Game over! ({r}, {c})");
                                    return;
                                default:
                                    break;
                            }
                            field[r][c] = "s";
                        }
                        else continue;
                        break;
                    case "right":
                        if (c + 1 <n)
                        {
                            field[r][c] = "*";
                            c++;
                            switch (field[r][c])
                            {
                                case "c":
                                    coalCnt++;
                                    totalCoalCnt--;
                                    break;
                                case "e":
                                    Console.WriteLine($"Game over! ({r}, {c})");
                                    return;
                                default:
                                    break;
                            }
                            field[r][c] = "s";
                        }
                        else continue;
                        break;
                    case "down":
                        if (r + 1 < n)
                        {
                            field[r][c] = "*";
                            r++;
                            switch (field[r][c])
                            {
                                case "c":
                                    coalCnt++;
                                    totalCoalCnt--;
                                    break;
                                case "e":
                                    Console.WriteLine($"Game over! ({r}, {c})");
                                    return;
                                default:
                                    break;
                            }
                            field[r][c] = "s";
                        }
                        else continue;
                        break;
                    case "left":
                        if (c - 1 >= 0)
                        {
                            field[r][c] = "*";
                            c--;
                            switch (field[r][c])
                            {
                                case "c":
                                    coalCnt++;
                                    totalCoalCnt--;
                                    break;
                                case "e":
                                    Console.WriteLine($"Game over! ({r}, {c})");
                                    return;
                                default:
                                    break;
                            }
                            field[r][c] = "s";
                        }
                        else continue;
                        break;
                    default:
                        break;
                }
                if (totalCoalCnt == 0)
                {
                    Console.WriteLine($"You collected all coals! ({r}, {c})");
                    return;
                }
            }
            Console.WriteLine($"{totalCoalCnt} coals left. ({r}, {c})");
        }
    }
}
