using System;
using System.Data;

namespace _02Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = GetData(n);
            int[] positionInTheBeginning = GetCoords(matrix);
            Officer officer = new Officer(positionInTheBeginning[0], positionInTheBeginning[1]);
            while (true)
            {
                if (officer.SpentGold >= 65) break;
                officer.Move(n);
                if (officer.LeftTheMatrix) break;
                char currChar = matrix[officer.RowIndex, officer.ColIndex];
                if (currChar >= '0' && currChar <= '9')
                {
                    officer.SpentGold += int.Parse(currChar.ToString());
                    matrix[officer.RowIndex, officer.ColIndex] = '-';
                }
                else if (currChar=='M')
                {
                    Teleport(officer, matrix);
                }
            }
            if (officer.LeftTheMatrix)  Console.WriteLine("I do not need more swords!");
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
                matrix[officer.RowIndex, officer.ColIndex] = 'A';
            }
            Console.WriteLine($"The king paid {officer.SpentGold} gold coins.");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
            
        }

        private static void Teleport(Officer officer, char[,] matrix)
        {
            matrix[officer.RowIndex, officer.ColIndex] = '-';
            for (int i = 0; i < matrix.GetLength(0); i++) 
            for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] == 'M')
                    {
                        officer.RowIndex = i;
                        officer.ColIndex = j;
                        matrix[i,j] = '-';
                        return;
                    }
        }

        private static int[] GetCoords(char[,] matrix)
        {
            int[] coords = new int[2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == 'A')
                    {
                        coords[0] = i;
                        coords[1] = j;
                        matrix[i, j] = '-';
                        return coords;
                    }
                }
            }
            return coords;
        }

        private static char[,] GetData(int n)
        {
            char[,] matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                string currLine = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = currLine[j];
                }
            }
            return matrix;
        }
    }
    class Officer
    {
        public int RowIndex { get; set; }
        public int ColIndex { get; set; }
        public int SpentGold { get; set; }
        public bool LeftTheMatrix { get; set; }
        public Officer(int rowIndex, int colIndex)
        {
            RowIndex = rowIndex;
            ColIndex = colIndex;
            SpentGold = 0;
            LeftTheMatrix = false;
        }
        public void Move(int matrixSize)
        {
            string cmd = Console.ReadLine();
            switch (cmd)
            {
                case "up":
                    this.RowIndex--;
                    break;

                case "down":
                    this.RowIndex++;
                    break;

                case "left":
                    this.ColIndex--;
                    break;

                case "right":
                    this.ColIndex++;
                    break;
            }
            if (this.RowIndex < 0|| this.RowIndex == matrixSize || this.ColIndex <0 || this.ColIndex ==matrixSize)
            {
                this.LeftTheMatrix = true;
            }
        }
    }
}