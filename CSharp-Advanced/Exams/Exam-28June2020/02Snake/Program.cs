using System;

namespace _02Snake
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                char[] currLine = Console.ReadLine().ToCharArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = currLine[j];
                }
            }
            Snake snake = new Snake(GetCoords(matrix));
            while (!snake.Left && snake.Food < 10) snake.Move(matrix);
            if (snake.Left) Console.WriteLine("Game over!");
            else 
            { 
                Console.WriteLine("You won! You fed the snake.");
                matrix[snake.Row, snake.Col] = 'S';
            }
            Console.WriteLine($"Food eaten: {snake.Food}");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        public static (int, int) GetCoords(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'S')
                    {
                        return (i, j);
                    }
                }
            }
            return (0, 0);
        }
    }
    class Snake
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Food { get; set; }
        public bool Left { get; set; }
        public Snake((int, int) coords)
        {
            Row = coords.Item1;
            Col = coords.Item2;
            Food = 0;
            Left = false;
        }
        public void Move(char[,] matrix)
        {
            matrix[Row, Col] = '.';
            string cmd = Console.ReadLine();
            switch (cmd)
            {
                case "up": Row--; break;
                case "down": Row++; break;
                case "left": Col--; break;
                case "right": Col++; break;
            }
            if (isValid(matrix))
            {
                Left = true;
                return;
            }
            char symbol = matrix[Row, Col];
            switch (symbol)
            {
                case '*':
                    Food++;
                    matrix[Row, Col] = '.';
                    break;
                case 'B':
                    matrix[Row, Col] = '.';
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (matrix[i, j] == 'B')
                            {
                                Row = i;
                                Col = j;
                            }
                        }
                    }
                    matrix[Row, Col] = '.';
                    break;
            }
        }

        public bool isValid(char[,] matrix)
        {
            return Row < 0 || Row == matrix.GetLength(0) || Col < 0 || Col == matrix.GetLength(1);
        }
    }
}
