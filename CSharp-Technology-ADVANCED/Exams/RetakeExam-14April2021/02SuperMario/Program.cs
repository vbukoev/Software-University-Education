using System;
using System.Data;

namespace _02SuperMario
{
    public class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            char[][] matrix = ReadMatrix();
            Mario mario = new Mario(Coords(matrix), lives);
            while (true)
            {
                if (mario.Lives <= 0 || mario.Won) break;
                mario.Move(matrix);
            }
                PrintMatrix(mario, matrix);
        }
        public static void PrintMatrix(Mario mario, char[][]matrix)
        {
            if (mario.Won)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {mario.Lives}");
            }
            else
            {
                Console.WriteLine($"Mario died at {mario.Row};{mario.Col}.");
                matrix[mario.Row][mario.Col] = 'X';
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }
        }

        public static (int, int) Coords(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'M')
                    {
                        return (i, j);
                    }
                }
            }
            return (0, 0);
        }

        public static char[][] ReadMatrix()
        {
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }
            return matrix;
        }
    }
    public class Mario
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Lives { get; set; }
        public bool Won { get; set; }
        public Mario((int, int) coords, int lives)
        {
            this.Row = coords.Item1;
            this.Col = coords.Item2;
            this.Lives = lives;
            this.Won = false;
        }
        public void Move(char[][] matrix)
        {
            string[] tokens = Console.ReadLine().Split();
            string cmd = tokens[0];
            int beginRow = int.Parse(tokens[1]);
            int beginCol = int.Parse(tokens[2]);
            matrix[beginRow][beginCol] = 'B';
            matrix[Row][Col] = '-';
            Lives--;
            int newRow = Row;
            int newCol = Col;
            switch (cmd)
            {
                case "W": newRow--; break;
                case "S": newRow++; break;
                case "A": newCol--; break;
                case "D": newCol++; break;
            }
            if (newRow < 0 || newRow == matrix.Length || newCol < 0 || newCol == matrix[0].Length) return;
            Row = newRow;
            Col = newCol;
            char symbol = matrix[Row][Col];
            switch (symbol)
            {
                case 'B': Lives -= 2; break;
                case 'P': Won = true; break;
            }
            matrix[newRow][newCol] = '-';
        }
    }
}
