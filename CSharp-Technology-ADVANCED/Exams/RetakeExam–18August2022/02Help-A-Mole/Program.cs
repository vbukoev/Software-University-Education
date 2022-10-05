using System;
using System.Linq;

namespace _02Help_A_Mole
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int points = 0;
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[0][col]; //input[0] gets the first input from the string array which is the row 
                }
            }
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "End")
                {
                    Console.WriteLine("Too bad! The Mole lost this battle!");
                    Console.WriteLine($"The Mole lost the game with a total of {points} points.");
                    break;
                }
                (int row, int col) = Position(matrix);
                if ((row, col) == (69, 69)) break;

                if (cmd == "up") points = points + Move(row, col, row - 1, col, matrix);

                else if (cmd == "down") points = points + Move(row, col, row + 1, col, matrix);

                if (cmd == "right") points = points + Move(row, col, row, col + 1, matrix);    

                else if (cmd == "left") points = points + Move(row, col, row, col - 1, matrix);

                if (points >= 25)
                {
                    Console.WriteLine("Yay! The Mole survived another game!");
                    Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
                    break;
                }
            }
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(String.Join("", matrix[row, col]));

                }
                Console.WriteLine();
            }
        }

        public static int Move(int row, int col, int rowOne, int colOne, char[,] matrix)
        {
            if (rowOne < 0 || colOne < 0 || rowOne >= matrix.GetLength(0) || colOne >= matrix.GetLength(1))
            {
                Console.WriteLine("Don't try to escape the playing field!");
                return 0;
            }
            matrix[row, col] = '-';
            var add = matrix[rowOne, colOne];
            matrix[rowOne, colOne] = 'M';
            if (Char.IsDigit(add))
            {
                return add - 48;

            }
            else if (add == 'S')
            {
                matrix[rowOne, colOne] = '-';
                (int SpecialRow, int TeleportedRow) = Teleport(matrix);
                matrix[SpecialRow, TeleportedRow] = 'M';
                return -3;
            }
            return 0;
        }

        public static (int SpecialRow, int TeleportedRow) Teleport(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLongLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        return (row, col);
                    }
                }
            }
            return (69, 69);
        }

        public static (int, int) Position(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLongLength(1); col++)
                {
                    if (matrix[row, col] == 'M')
                    {
                        return (row, col);
                    }
                }
            }
            return (69, 69);
        }
    }
}
