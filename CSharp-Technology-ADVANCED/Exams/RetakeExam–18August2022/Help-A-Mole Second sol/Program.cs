using System;
using System.Text;

namespace _02Help_A_Mole
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int points = 0;
            int moleStartRow = -1;
            int moleStartCol = -1;
            int specialOneRow = -1;
            int specialTwoRow = -1;
            int specialOneCol = -1;
            int specialTwoCol = -1;

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
                    if (matrix[row, col] == 'S') //special 
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
            string cmd = Console.ReadLine();
            int currRow = moleStartRow;
            int currCol = moleStartCol;

            while (points < 25 && cmd != "End")
            {
                if (cmd == "up")
                {
                    if (FieldCheck(currRow - 1, currCol, matrix))
                    {
                        currRow -= 1;
                        Position(currRow, currCol, matrix[currRow, currCol]);
                    }
                    else Console.WriteLine("Don't try to escape the playing field!");
                }

                if (cmd == "down")
                {
                    if (FieldCheck(currRow + 1, currCol, matrix))
                    {
                        currRow += 1;
                        Position(currRow, currCol, matrix[currRow, currCol]);
                    }
                    else Console.WriteLine("Don't try to escape the playing field!");
                }

                if (cmd == "right")
                {
                    if (FieldCheck(currRow, currCol + 1, matrix))
                    {
                        currCol += 1;
                        Position(currRow, currCol, matrix[currRow, currCol]);
                    }
                    else Console.WriteLine("Don't try to escape the playing field!");
                }
                else if (cmd == "left")
                {
                    if (FieldCheck(currRow, currCol - 1, matrix))
                    {
                        currCol -= 1;
                        Position(currRow, currCol, matrix[currRow, currCol]);
                    }
                    else Console.WriteLine("Don't try to escape the playing field!");
                }

                cmd = Console.ReadLine();
            }


            if (points >= 25)//won the game
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }
            matrix[currRow, currCol] = 'M';
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    sb.Append(matrix[row, col]);
                }
                sb.Append(Environment.NewLine);
            }
            Console.WriteLine(sb.ToString().TrimEnd());

            void Position(int col, int row, char v)
            {
                if (v == 'S')
                {
                    if (row == specialOneRow && col == specialOneCol)
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
        }


        public static bool FieldCheck(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}