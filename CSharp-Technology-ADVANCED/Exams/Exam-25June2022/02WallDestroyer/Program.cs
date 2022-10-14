using System;

namespace _02WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int row = 0;
            int col = 0;
            int rods = 0;
            int holes = 1;
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                string currElement = Console.ReadLine();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = currElement[c];
                    if (matrix[r, c] == 'V')
                    {
                        row = r;
                        col = c;
                    }
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;

                int r = row;
                int c = col;
                switch (input)
                {
                    case "up": r--; break;

                    case "down": r++; break;

                    case "left": c--; break;

                    case "right": c++; break;
                }
                if (r < 0)
                {
                    r++;
                    continue;
                }
                else if (r > matrix.GetLength(0) - 1)
                {
                    r--;
                    continue;
                }
                if (c < 0)
                {
                    c++;
                    continue;
                }
                else if (c > matrix.GetLength(1) - 1)
                {
                    c--;
                    continue;
                }
                switch (matrix[r, c])
                {
                    case '-':
                        matrix[r, c] = 'V';
                        holes++;
                        switch (input)
                        {
                            case "up": matrix[r + 1, c] = '*'; break;

                            case "down": matrix[r - 1, c] = '*'; break;

                            case "left": matrix[r, c + 1] = '*'; break;

                            case "right": matrix[r, c - 1] = '*'; break;
                        }
                        break;

                    case 'R':
                        r = row;
                        c = col;
                        rods++;
                        Console.WriteLine("Vanko hit a rod!");
                        break;

                    case 'C':
                        holes++;
                        matrix[r, c] = 'E';
                        switch (input)
                        {
                            case "up": matrix[r + 1, c] = '*'; break;

                            case "down": matrix[r - 1, c] = '*'; break;

                            case "left": matrix[r, c + 1] = '*'; break;

                            case "right": matrix[r, c - 1] = '*'; break;
                        }
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
                        PrintMatrix(matrix);
                        return;
                    case '*':
                        Console.WriteLine($"The wall is already destroyed at position [{r}, {c}]!");
                        matrix[r, c] = 'V';
                        switch (input)
                        {
                            case "up": matrix[r + 1, c] = '*'; break;

                            case "down": matrix[r - 1, c] = '*'; break;

                            case "left": matrix[r, c + 1] = '*'; break;

                            case "right": matrix[r, c - 1] = '*'; break;
                        }
                        break;
                }
                row = r;
                col = c;
            }
            if (matrix[row, col] == 'V')
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rods} rod(s).");
            }
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}