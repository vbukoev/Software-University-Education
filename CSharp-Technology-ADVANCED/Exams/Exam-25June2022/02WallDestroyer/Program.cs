using System;
using System.Security.Cryptography;

namespace _02WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int[] position = new int[2];
            bool moveOne = true;
            bool electrocuted = false;
            int cntOfTheHoles = 0;
            int rodHits = 0;
            for (int row = 0; row < n; row++)
            {
                char[] r = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = r[col];
                    if (r[col] == 'V')
                    {
                        position[0] = row;
                        position[1] = col;
                    }
                }
            }
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "End" || electrocuted == true)
                {
                    Console.WriteLine($"Vanko managed to make {cntOfTheHoles} hole(s) and he hit only {rodHits} rod(s).");
                    break;
                }
                var currRow = position[0];
                var currCol = position[1];
                char nextStep = default;
                int[] nextStepCoords = new int[2];
                int firstNextStepCoordsValue = nextStepCoords[0];
                int secondNextStepCoordsValue = nextStepCoords[1];
                var valid = false;
                switch (cmd)
                {
                    case "up":
                        Up(matrix, currRow, currCol, ref nextStep, ref firstNextStepCoordsValue, ref secondNextStepCoordsValue, ref valid);
                        break;

                    case "down":
                        Down(n, matrix, currRow, currCol, ref nextStep, ref firstNextStepCoordsValue, ref secondNextStepCoordsValue, ref valid);
                        break;

                    case "left":
                        Left(matrix, currRow, currCol, ref nextStep, ref firstNextStepCoordsValue, ref secondNextStepCoordsValue, ref valid);
                        break;

                    case "right":
                        Right(n, matrix, currRow, currCol, ref nextStep, ref firstNextStepCoordsValue, ref secondNextStepCoordsValue, ref valid);
                        break;
                }
                switch (nextStep)
                {
                    case 'R':
                        rodHits = R(rodHits, valid);
                        break;

                    case 'C':
                        C(matrix, ref moveOne, ref electrocuted, ref cntOfTheHoles, currRow, currCol, firstNextStepCoordsValue, secondNextStepCoordsValue, valid);
                        break;

                    case '*':
                        Star(position, firstNextStepCoordsValue, secondNextStepCoordsValue, valid);
                        break;

                    case '-':
                        cntOfTheHoles = Dash(matrix, position, cntOfTheHoles, firstNextStepCoordsValue, secondNextStepCoordsValue, valid);
                        break;
                }
                if (moveOne)
                {
                    cntOfTheHoles += 1;
                    matrix[currRow, currCol] = '*';
                    moveOne = false;
                }
                if (!electrocuted)
                {
                    matrix[firstNextStepCoordsValue, secondNextStepCoordsValue] = 'V';
                }

            }
            PrintMatrix(n, matrix);
        }

        public static void PrintMatrix(int n, char[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static int Dash(char[,] matrix, int[] position, int cntOfTheHoles, int firstNextStepCoordsValue, int secondNextStepCoordsValue, bool valid)
        {
            if (valid == true)
            {
                position[0] = firstNextStepCoordsValue;
                position[1] = secondNextStepCoordsValue;
                matrix[position[0], position[1]] = '*';
                cntOfTheHoles += 1;
            }

            return cntOfTheHoles;
        }

        public static void Star(int[] position, int firstNextStepCoordsValue, int secondNextStepCoordsValue, bool valid)
        {
            if (valid == true)
            {
                Console.WriteLine($"The wall is already destroyed at position [{firstNextStepCoordsValue}, {secondNextStepCoordsValue}]!");
                position[0] = firstNextStepCoordsValue;
                position[1] = secondNextStepCoordsValue;
            }
        }

        public static void C(char[,] matrix, ref bool moveOne, ref bool electrocuted, ref int cntOfTheHoles, int currRow, int currCol, int firstNextStepCoordsValue, int secondNextStepCoordsValue, bool valid)
        {
            if (valid == true)
            {
                matrix[firstNextStepCoordsValue, secondNextStepCoordsValue] = 'E';
                if (moveOne)
                {
                    cntOfTheHoles += 1;
                    matrix[currRow, currCol] = '*';
                    moveOne = false;
                }
                cntOfTheHoles += 1;
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {cntOfTheHoles} hole(s).");
                electrocuted = true;
            }
        }

        public static int R(int rodHits, bool valid)
        {
            if (valid == true)
            {
                Console.WriteLine("Vanko hit a rod!");
                rodHits += 1;
            }

            return rodHits;
        }

        public static void Right(int n, char[,] matrix, int currRow, int currCol, ref char nextStep, ref int firstNextStepCoordsValue, ref int secondNextStepCoordsValue, ref bool valid)
        {
            if (currCol != n)
            {
                nextStep = matrix[currRow, currCol + 1];
                firstNextStepCoordsValue = currRow;
                secondNextStepCoordsValue = currCol + 1;
                valid = true;
            }
        }

        public static void Down(int n, char[,] matrix, int currRow, int currCol, ref char nextStep, ref int firstNextStepCoordsValue, ref int secondNextStepCoordsValue, ref bool valid)
        {
            if (currRow != n)
            {
                nextStep = matrix[currRow + 1, currCol];
                firstNextStepCoordsValue = currRow + 1;
                secondNextStepCoordsValue = currCol;
                valid = true;
            }
        }

        public static void Up(char[,] matrix, int currRow, int currCol, ref char nextStep, ref int firstNextStepCoordsValue, ref int secondNextStepCoordsValue, ref bool valid)
        {
            if (currRow != 0)
            {
                nextStep = matrix[currRow - 1, currCol];
                firstNextStepCoordsValue = currRow - 1;
                secondNextStepCoordsValue = currCol;
                valid = true;
            }
        }

        public static void Left(char[,] matrix, int currRow, int currCol, ref char nextStep, ref int firstNextStepCoordsValue, ref int secondNextStepCoordsValue, ref bool valid)
        {
            if (currCol != 0)
            {
                nextStep = matrix[currRow, currCol - 1];
                firstNextStepCoordsValue = currRow;
                secondNextStepCoordsValue = currCol - 1;
                valid = true;
            }
        }
    }
}