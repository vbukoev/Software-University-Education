using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;

namespace _02Re_Volt
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int numOfCmds = int.Parse(Console.ReadLine());
            char[,] matrix = DataForTheMatrix(n);
            Player player = new Player(PlayerCoords(matrix));
            for (int i = 0; i < numOfCmds; i++)
            {
                string cmd = Console.ReadLine();
                player.Move(matrix, cmd);
                if (player.Won) break; 
            }
            if (player.Won)  Console.WriteLine("Player won!");
            else Console.WriteLine("Player lost!");
            matrix[player.Row, player.Col] = 'f';
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        public static (int, int) PlayerCoords(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'f')
                    {
                        return (i, j); 
                    }
                }
            }
            return (0,0);
        }

        public static char[,] DataForTheMatrix(int n)
        {
            char[,] matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                char[] currLine = Console.ReadLine().ToCharArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = currLine[j];
                }
            }
            return matrix;
        }
    }
    public class Player
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public bool Won { get; set; }
        public Player((int,int) coords)
        {
            Row = coords.Item1;
            Col = coords.Item2;
        }

        public void Move(char[,] matrix, string cmd)
        {
            int n = matrix.GetLength(0);
            if (matrix[Row, Col] !='B') matrix[Row, Col] = '-';
            int row = Row;
            int col = Col;
            switch (cmd)
            {
                case "up":  row--; break; 
                case "down": row++; break; 
                case "left": col--;  break; 
                case "right": col++; break; 
            }
            if (row < 0) row = n - 1;
            if (col < 0) col = n - 1;
            if (row == n) row = 0;
            if (col == n) col = 0;
            char symbol = matrix[row, col];
            switch (symbol)
            {
                case 'T': return; //got trapped :(
                case 'B': // gets a bonus
                    Row = row;
                    Col = col;
                    Move(matrix, cmd);
                    return;
                case 'F': Won = true; break; //finished reached
            }
            Row= row;
            Col = col;
        }
    }
}
