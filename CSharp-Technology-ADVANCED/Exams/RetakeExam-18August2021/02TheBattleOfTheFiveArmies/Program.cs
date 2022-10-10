using System;
using System.Reflection;

namespace _02TheBattleOfTheFiveArmies
{
    public class Program
    {
        static void Main(string[] args)
        {
            int armour = int.Parse(Console.ReadLine());
            char[][] matrix = ReadMatrix();
            Army army = new Army(Coords(matrix, 'A'), Coords(matrix, 'M'), armour);
            matrix[army.Row][army.Col] = '-';
            while (true)
            {
                if (army.Armour<=0||army.Won)
                {
                    break;
                }
                var input = Console.ReadLine().Split();
                var cmd = input[0];
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                matrix[row][col] = '0';
                army.Move(cmd, matrix);
            }
            if (army.Won) Console.WriteLine($"The army managed to free the Middle World! Armor left: {army.Armour}");
            else Console.WriteLine($"The army was defeated at {army.Row};{army.Col}.");
            for (int i = 0; i < matrix.Length; i++) Console.WriteLine(string.Join("", matrix[i]));
            
        }

        public static (int, int) Coords(char[][] matrix, char v)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j]==v)
                    {
                        return (i, j);
                    }
                }
            }
            return (0,0);
        }

        public static char[][] ReadMatrix()
        {
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            for (int i = 0; i < n; i++)
            {
                string currLine = Console.ReadLine();
                matrix[i] = currLine.ToCharArray();
            }
            return matrix;
        }
    }
    public class Army
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Armour { get; set; }
        public bool Won { get; set; }
        public (int, int) Mordor { get; set; }
        public Army((int, int) coords,  (int, int) mordorCoords, int armour)
        {
            this.Row = coords.Item1;
            this.Col = coords.Item2;
            this.Mordor = mordorCoords;
            this.Armour = armour;
            this.Won = false;
        }

        public void Move(string cmd, char[][] matrix)
        {
            this.Armour--;
            switch (cmd)
            {
                case "up": if (this.Row - 1 >= 0) this.Row--; break;
                case "down": if (this.Row + 1 < matrix.Length) this.Row++; break;                   
                case "left": if(this.Col - 1 >=0) this.Col--; break; 
                case "right": if (this.Col + 1 < matrix[0].Length) this.Col++; break;  
            }
            char currChar = matrix[this.Row][this.Col];
            matrix[this.Row][this.Col] = '-';
            if (currChar == '0') this.Armour = this.Armour - 2;
            if (this.Row == this.Mordor.Item1 && this.Col == this.Mordor.Item2)
            {
                this.Won = true;
                return;
            }
            if (this.Armour <= 0) matrix[this.Row][this.Col] = 'X';
        }
    }
}