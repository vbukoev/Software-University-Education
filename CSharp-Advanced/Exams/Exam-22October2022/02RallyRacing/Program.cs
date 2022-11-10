using System;
using System.Linq;

namespace _02
{
    public class Program
    {
        static void Main(string[] args)
        {
            //MATRIX
            int n = int.Parse(Console.ReadLine());
            string racingNumber =Console.ReadLine();
            char[,] matrix = new char[n, n];
            int currRow = 0;
            int currCol = 0;

            int firstTunnelRow = 0;
            int firstTunnelCol = 0;

            int secTunnelRow = 0;
            int secTunnelCol = 0;
            int indicator = 1;
            int km = 0;
            bool finished = false;
            for (int i = 0;  i < matrix.GetLength(0);  i++)
            {
                char[] currLine = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currLine[j];
                    if (matrix[i,j] == 'T')
                    {
                        if (indicator == 1)
                        {
                            firstTunnelRow = i;
                            firstTunnelCol = j;
                            indicator++;
                        }
                        else
                        {
                            secTunnelRow = i;
                            secTunnelCol = j;
                        }
                    }
                }
            }
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "End" || finished) break;
                if (cmd == "up")
                {
                    if (matrix[currRow-1, currCol]=='F')
                    {
                        km += 10;
                        currRow--;
                        matrix[currRow, currCol] = 'C';
                        finished = true;
                    }
                    else if (matrix[currRow - 1, currCol] == 'T')
                    {
                        currRow--;
                        matrix[currRow, currCol] = '.';
                        km += 30;
                        if (currRow == firstTunnelRow && currCol == firstTunnelCol)
                        {
                            currRow = secTunnelRow;
                            currCol = secTunnelCol;
                            matrix[currRow, currCol] = '.';

                        }
                        else
                        {
                            currRow = firstTunnelRow;
                            currCol = firstTunnelCol;
                            matrix[currRow, currCol] = '.';
                        }
                    }
                    else if (matrix[currRow - 1, currCol] == '.')
                    {
                        currRow--;
                        km += 10;
                    }
                }
                if (cmd == "down")
                {
                    if (matrix[currRow + 1, currCol] == 'F')
                    {
                        km += 10;
                        currRow++;
                        matrix[currRow, currCol] = 'C';
                        finished = true;
                    }
                    else if (matrix[currRow + 1, currCol] == 'T')
                    {
                        currRow++;
                        matrix[currRow, currCol] = '.';
                        km += 30;
                        if (currRow == firstTunnelRow && currCol == firstTunnelCol)
                        {
                            currRow = secTunnelRow;
                            currCol = secTunnelCol;
                            matrix[currRow, currCol] = '.';

                        }
                        else
                        {
                            currRow = firstTunnelRow;
                            currCol = firstTunnelCol;
                            matrix[currRow, currCol] = '.';
                        }
                    }
                    else if (matrix[currRow + 1, currCol] == '.')
                    {
                        currRow++;
                        km += 10;
                    }
                }
                if (cmd == "left")
                {
                    if (matrix[currRow, currCol - 1] == 'F')
                    {
                        km += 10;
                        currCol--;
                        matrix[currRow, currCol] = 'C';
                        finished = true;
                    }
                    else if (matrix[currRow, currCol - 1] == 'T')
                    {
                        currCol--;
                        matrix[currRow, currCol] = '.';
                        km += 30;
                        if (currRow == firstTunnelRow && currCol == firstTunnelCol)
                        {
                            currRow = secTunnelRow;
                            currCol = secTunnelCol;
                            matrix[currRow, currCol] = '.';

                        }
                        else
                        {
                            currRow = firstTunnelRow;
                            currCol = firstTunnelCol;
                            matrix[currRow, currCol] = '.';
                        }
                    }
                    else if (matrix[currRow, currCol-1] == '.')
                    {
                        currCol--;
                        km += 10;
                    }
                }
                if (cmd == "right")
                {
                    if (matrix[currRow, currCol + 1] == 'F')
                    {
                        km += 10;
                        currCol++;
                        matrix[currRow, currCol] = 'C';
                        finished = true;
                    }
                    else if (matrix[currRow, currCol + 1] == 'T')
                    {
                        currCol++;
                        matrix[currRow, currCol] = '.';
                        km += 30;
                        if (currRow == firstTunnelRow && currCol == firstTunnelCol)
                        {
                            currRow = secTunnelRow;
                            currCol = secTunnelCol;
                            matrix[currRow, currCol] = '.';

                        }
                        else
                        {
                            currRow = firstTunnelRow;
                            currCol = firstTunnelCol;
                            matrix[currRow, currCol] = '.';
                        }
                    }
                    else if (matrix[currRow, currCol+1] == '.')
                    {
                        currCol++;
                        km += 10;
                    }
                }

            }
            if (finished)
            {
                Console.WriteLine($"Racing car {racingNumber} finished the stage!"); 
            }
            else 
            {
                matrix[currRow, currCol] = 'C';
                Console.WriteLine($"Racing car {racingNumber} DNF.");               
            }
            Console.WriteLine($"Distance covered {km} km.");
            Print(matrix,n);
        }

        public static void Print(char[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
    
}
