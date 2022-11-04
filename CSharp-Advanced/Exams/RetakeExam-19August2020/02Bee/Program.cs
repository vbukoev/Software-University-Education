using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _02Bee
{
    public class Program
    {
        private const int a = 5;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                char[] currLine = Console.ReadLine().ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = currLine[j];
                }
            }

            Bee bee = new Bee(GetCoords(matrix));

            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "End") break;
                bee.Move(cmd, matrix);
                if(bee.Lost) break;
            }

            if (bee.Lost) Console.WriteLine($"The bee got lost!");
            else matrix[bee.Row, bee.Col] = 'B';

            if (bee.Flowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {a - bee.Flowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {bee.Flowers} flowers!");
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
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
                    if (matrix[i, j] == 'B') return (i, j);
                }
            }
            return (0, 0);
        }
    }
    class Bee
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Flowers { get; set; }
        public bool Lost { get; set; }
        public Bee((int, int) coords)
        {
            Row = coords.Item1;
            Col = coords.Item2;
            Flowers = 0;
            Lost = false;
        }
        public void Move(string cmd, char[,] matrix)
        {
            matrix[Row, Col] = '.';
            switch (cmd)
            {
                case "up": Row--; break;
                case "down": Row++; break;
                case "left": Col--; break;
                case "right": Col++; break;
            }
            if (GotLost(matrix))
            {
                Lost = true;
                return;
            }
            char symbol = matrix[Row, Col];
            switch (symbol)//flowers
            {
                case 'f':
                    Flowers++;
                    matrix[Row, Col] = '.';
                    break;

                case 'O':
                    Move(cmd, matrix);
                    break;
            }
        }

        public bool GotLost(char[,] matrix)
        {
            return Row < 0 || Row >= matrix.GetLength(0) || Col < 0 || Col >= matrix.GetLength(1);
        }
    }
}