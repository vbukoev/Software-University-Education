using System;

namespace _02Selling
{
    public class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = ReadMatrix();
            Cook cook = new Cook(Coords(matrix));
            while (true)
            {
                if (cook.Money >= 50 || cook.IsValid) break;
                cook.Move(matrix);
            }
            if (cook.IsValid) Console.WriteLine("Bad news, you are out of the bakery.");
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
                matrix[cook.Row, cook.Col] = 'S';
            }
            Console.WriteLine($"Money: {cook.Money}");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        public static (int, int) Coords(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == 'S')
                    {
                        return (i, j);
                    }
                }
            }
            return (0, 0);
        }

        public static char[,] ReadMatrix()
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                char[] currLine = Console.ReadLine().ToCharArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i,j]  = currLine[j];
                }
            }
            return matrix;
        }
    }
    class Cook
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Money { get; set; }
        public bool IsValid { get; set; }
        public Cook((int, int) coords)
        {
            Row = coords.Item1;
            Col = coords.Item2;
            Money = 0;
            this.IsValid = false;
        }
        public void Move(char[,] matrix)
        {
            matrix[Row, Col] = '-';
            string cmd = Console.ReadLine();
            switch (cmd)
            {
                case "up": Row--; break;
                case "down": Row++; break;
                case "left": Col--; break;
                case "right": Col++; break;
            }
            if (Checks(matrix))
            {
                IsValid = true;
                return;
            }
            char symbol = matrix[Row, Col];
            if (char.IsDigit(symbol))
            {
                Money = int.Parse(symbol.ToString()) + Money;
                matrix[Row, Col] = '-';
            }
            else if (symbol == 'O')
            {
                matrix[Row, Col] = '-';
                (int, int) location = (0, 0);
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == 'O')
                        {
                            location = (i, j);
                        }
                    }
                }
                Row = location.Item1;
                Col = location.Item2;
                matrix[Row, Col] = '-';
            }
        }

        public bool Checks(char[,] matrix)
        {
            return Row < 0 || Row == matrix.GetLength(0) || Col < 0 || Col == matrix.GetLength(1);
        }
    }
}
