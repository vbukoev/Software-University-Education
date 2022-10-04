using System;
using System.Data;
using System.Globalization;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;

namespace _02Help_A_Mole
{
    internal class Program
    {
        public static int points = 0;
        public static int moleStartRow = -1;
        public static int moleStartCol = -1;
        public static int specialOneRow = -1;
        public static int specialTwoRow = -1;
        public static int specialOneCol = -1;
        public static int specialTwoCol = -1;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string currElement = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {

                    matrix[row, col] = currElement[col];
                    if (matrix[row, col] == 'M')
                    {
                        moleStartRow = row;
                        moleStartCol = col;
                        matrix[row, col] = '-';
                    }
                    if (matrix[row, col] == 'S')//special 
                    {
                        if (specialOneRow != -1 && specialOneCol != -1)
                        {
                            specialTwoRow = row;
                            specialTwoCol = col;
                        }
                        else
                        {
                            specialOneRow = row;
                            specialOneCol = col;
                        }
                    }
                }
            }
            int currRow = moleStartRow;
            int currCol = moleStartCol;
            while (true)
            {
                string cmd = Console.ReadLine();
                if (points >= 25 || cmd == "End") break;
                switch (cmd)
                {
                    case "up":
                        if (FieldCheck(currRow - 1, currCol, matrix))
                        {
                            currRow-=1;
                            Position(currRow, currCol, matrix[currRow, currCol]);
                        }
                        else Console.WriteLine("Don't try to escape the playing field!");

                        break;
                    case "down":
                        if (FieldCheck(currRow + 1, currCol, matrix))
                        {
                            currRow+=1;
                            Position(currRow, currCol, matrix[currRow, currCol]);
                        }
                        else Console.WriteLine("Don't try to escape the playing field!");
                        break;
                    case "left":
                        if (FieldCheck(currRow, currCol - 1, matrix))
                        {
                            currCol-=1;
                            Position(currRow, currCol, matrix[currRow, currCol]);
                        }
                        else Console.WriteLine("Don't try to escape the playing field!");
                        break; 
                    case "right":
                        if (FieldCheck(currRow, currCol + 1, matrix))
                        {
                            currCol += 1;
                            Position(currRow, currCol, matrix[currRow, currCol]);
                        }
                        else Console.WriteLine("Don't try to escape the playing field!");
                        break; 
                }
            }
            if (points < 25)//lost the game
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points."); 
            }
            else
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");                
            }
            matrix[currRow, currCol] = 'M';
            MatrixPrint(n, matrix);
        }


        public static bool FieldCheck(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

       void Position(int currRow, int currCol, char v)
        {
            if (v == 'S')
            {
                if (currRow == specialOneRow && currCol == specialOneCol)
                {
                    currRow = specialTwoRow;
                    currCol = specialTwoCol;
                }
                else
                {
                    currRow = specialOneRow;
                    currCol = specialOneCol;
                }
                points -= 3;
                matrix[specialOneRow, specialOneCol] = '-';
                matrix[specialTwoRow, specialTwoCol] = '-';
            }
            else if (char.IsDigit(v))
            {
                int value = int.Parse(v.ToString());
                points = value + points;
                matrix[currRow, currCol] = '-';
            }
        }
        public static void MatrixPrint(int n, char[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
