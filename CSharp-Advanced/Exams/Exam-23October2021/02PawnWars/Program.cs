using System;

namespace _02PawnWars
{
    public class Program
    {
        public static void Main(string[] args)
        {
            char[,] matrix = ReadMatrix();
            Pawn w = new Pawn(Location(matrix, 'w'), "White");
            Pawn b = new Pawn(Location(matrix, 'b'), "Black");
            while (true)
            {
                if (ChecksWhite(w, b))
                {
                    WhiteTurn(w, b);
                    break;
                }
                else if (--w.Row == 0)
                {
                    Print(w, true);
                    break;
                }
                if (ChecksBlack(w, b))
                {
                    BlackTurn(w, b);
                    break;
                }
                else if (++b.Row == 7)
                {
                    Print(b, true);
                    break;
                }
            }
        }

        public static void BlackTurn(Pawn w, Pawn b)
        {
            b.Row = w.Row;
            b.Col = w.Col;
            Print (b, false);
        }

        public static void WhiteTurn(Pawn w, Pawn b)
        {
            w.Row = b.Row;
            w.Col = b.Col;
            Print(w, false);
        }

        public static bool ChecksBlack(Pawn w, Pawn b)
        {
            return w.Row == b.Row + 1 && (w.Col == b.Col - 1 || w.Col == b.Col + 1);
        }

        public static void Print(Pawn w, bool isValid)
        {
            string coords = (char)('a' + w.Col) + (8 - w.Row).ToString();

            if (isValid) Console.WriteLine($"Game over! {w.Colour} pawn is promoted to a queen at {coords}.");   
            else Console.WriteLine($"Game over! {w.Colour} capture on {coords}.");
        }

        public static bool ChecksWhite(Pawn w, Pawn b)
        {
            return b.Row == w.Row - 1 && (b.Col == w.Col - 1 || b.Col == w.Col + 1);
        }

        public static (int,int) Location(char[,] matrix, char v)
        {
            for (int i = 0; i < 8; i++) 
            {
                for (int j = 0; j < 8; j++)
                {
                    if (matrix[i,j]==v)
                    {
                        return (i, j);
                    }
                }
            }
            return (0, 0);
        }

        public static char[,] ReadMatrix()
        {
            char[,] matrix = new char[8, 8];
            for (int i = 0; i < 8; i++)
            {
                char[] currLine = Console.ReadLine().ToCharArray();
                for (int j = 0; j < 8; j++)
                {
                    matrix[i, j] = currLine[j];
                }
            }
            return matrix;
        }
    }
    public class Pawn
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public string Colour { get; set; }
        public Pawn((int, int) rowCol, string colour)
        {
            Row = rowCol.Item1;
            Col = rowCol.Item2;
            Colour = colour;
        }
    }
}