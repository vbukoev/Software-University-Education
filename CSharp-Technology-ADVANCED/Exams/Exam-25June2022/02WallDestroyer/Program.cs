//using System;
//using System.Runtime.CompilerServices;
//using System.Security.Cryptography;

//namespace _02WallDestroyer
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {

using System;

namespace _02._Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int row = 0;
            int col = 0;
            int rods = 0;
            int holes = 1;
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                string currElement = Console.ReadLine();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = currElement[c];
                    if (matrix[r, c] == 'V')
                    {
                        row = r;
                        col = c;
                    }
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;

                int r = row;
                int c = col;
                switch (input)
                {
                    case "up": r--; break;

                    case "down": r++; break;

                    case "left": c--; break;

                    case "right": c++; break;
                }
                if (r < 0)
                {
                    r++;
                    continue;
                }
                else if (r > matrix.GetLength(0) - 1)
                {
                    r--;
                    continue;
                }
                if (c < 0)
                {
                    c++;
                    continue;
                }
                else if (c > matrix.GetLength(1) - 1)
                {
                    c--;
                    continue;
                }
                switch (matrix[r, c])
                {
                    case '-':
                        matrix[r, c] = 'V';
                        holes++;
                        switch (input)
                        {
                            case "up": matrix[r + 1, c] = '*'; break;

                            case "down": matrix[r - 1, c] = '*'; break;

                            case "left": matrix[r, c + 1] = '*'; break;

                            case "right": matrix[r, c - 1] = '*'; break;
                        }
                        break;

                    case 'R':
                        r = row;
                        c = col;
                        rods++;
                        Console.WriteLine("Vanko hit a rod!");
                        break;

                    case 'C':
                        holes++;
                        matrix[r, c] = 'E';
                        switch (input)
                        {
                            case "up": matrix[r + 1, c] = '*'; break;

                            case "down": matrix[r - 1, c] = '*'; break;

                            case "left": matrix[r, c + 1] = '*'; break;

                            case "right": matrix[r, c - 1] = '*'; break;
                        }
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s)");
                        PrintMatrix(matrix);
                        return;
                    case '*':
                        Console.WriteLine($"The wall is already destroyed at position [{r}, {c}]!");
                        matrix[r, c] = 'V';
                        switch (input)
                        {
                            case "up": matrix[r + 1, c] = '*'; break;

                            case "down": matrix[r - 1, c] = '*'; break;

                            case "left": matrix[r, c + 1] = '*'; break;

                            case "right": matrix[r, c - 1] = '*'; break;
                        }
                        break;
                }
                row = r;
                col = c;
            }
            if (matrix[row, col] == 'V')
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only{rods} rod(s).");
            }
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}

















//    int n = int.Parse(Console.ReadLine());
//    char[,] matrix = new char[n, n];
//    int[] position = new int[2];
//    bool moveOne = true;
//    bool electrocuted = false;
//    int cntOfTheHoles = 0;
//    int rodHits = 0;
//    for (int row = 0; row < n; row++)
//    {
//        char[] r = Console.ReadLine().ToCharArray();
//        for (int col = 0; col < n; col++)
//        {
//            matrix[row, col] = r[col];
//            if (r[col] == 'V')
//            {
//                position[0] = row;
//                position[1] = col;
//            }
//        }
//    }
//    string cmd = Console.ReadLine();
//    while (true)
//    {
//        if (cmd == "End" || electrocuted == true) break;
//        var currRow = position[0];
//        var currCol = position[1];
//        char nextStep = default;
//        int[] nextStepCoords = new int[2];
//        int firstNextStepCoordsValue = nextStepCoords[0];
//        int secondNextStepCoordsValue = nextStepCoords[1];
//        var valid = false;
//        switch (cmd)
//        {
//            case "up":
//                Up(matrix, currRow, currCol, ref nextStep, ref firstNextStepCoordsValue, ref secondNextStepCoordsValue, ref valid);
//                break;

//            case "down":
//                Down(n, matrix, currRow, currCol, ref nextStep, ref firstNextStepCoordsValue, ref secondNextStepCoordsValue, ref valid);
//                break;

//            case "left":
//                Left(matrix, currRow, currCol, ref nextStep, ref firstNextStepCoordsValue, ref secondNextStepCoordsValue, ref valid);
//                break;

//            case "right":
//                Right(n, matrix, currRow, currCol, ref nextStep, ref firstNextStepCoordsValue, ref secondNextStepCoordsValue, ref valid);
//                break;
//        }
//        switch (nextStep)
//        {
//            case 'R':
//                rodHits = R(rodHits, valid);
//                break;

//            case 'C':
//                C(matrix, ref moveOne, ref electrocuted, ref cntOfTheHoles, currRow, currCol, firstNextStepCoordsValue, secondNextStepCoordsValue, valid);
//                break;

//            case '*':
//                Star(position, firstNextStepCoordsValue, secondNextStepCoordsValue, valid);
//                break;

//            case '-':
//                cntOfTheHoles = Dash(matrix, position, cntOfTheHoles, firstNextStepCoordsValue, secondNextStepCoordsValue, valid);
//                break;
//        }
//        if (moveOne)
//        {
//            cntOfTheHoles += 1;
//            matrix[currRow, currCol] = '*';
//            moveOne = false;
//        }
//        if (!electrocuted) cmd = Console.ReadLine();
//        if (cmd == "End" || electrocuted)
//        {
//            if (!electrocuted)
//            {
//                matrix[firstNextStepCoordsValue, secondNextStepCoordsValue] = 'V';
//            }
//            if (cmd == "End" && !electrocuted)
//            {
//                Console.WriteLine($"Vanko managed to make {cntOfTheHoles} hole(s) and he hit only {rodHits} rod(s).");
//            }
//            for (int row = 0; row < n; row++)
//            {
//                for (int col = 0; col < n; col++)
//                {
//                    Console.Write(matrix[row, col]);
//                }
//                Console.WriteLine();
//            }
//        }
//    }
//}

//public static int Dash(char[,] matrix, int[] position, int cntOfTheHoles, int firstNextStepCoordsValue, int secondNextStepCoordsValue, bool valid)
//{
//    if (valid)
//    {
//        position[0] = firstNextStepCoordsValue;
//        position[1] = secondNextStepCoordsValue;
//        matrix[position[0], position[1]] = '*';
//        cntOfTheHoles += 1;
//    }

//    return cntOfTheHoles;
//}

//public static void Star(int[] position, int firstNextStepCoordsValue, int secondNextStepCoordsValue, bool valid)
//{
//    if (valid)
//    {
//        Console.WriteLine($"The wall is already destroyed at position [{firstNextStepCoordsValue}, {secondNextStepCoordsValue}]!");
//        position[0] = firstNextStepCoordsValue;
//        position[1] = secondNextStepCoordsValue;
//    }
//}

//public static void C(char[,] matrix, ref bool moveOne, ref bool electrocuted, ref int cntOfTheHoles, int currRow, int currCol, int firstNextStepCoordsValue, int secondNextStepCoordsValue, bool valid)
//{
//    if (valid)
//    {
//        matrix[firstNextStepCoordsValue, secondNextStepCoordsValue] = 'E';
//        if (moveOne)
//        {
//            cntOfTheHoles += 1;
//            matrix[currRow, currCol] = '*';
//            moveOne = false;
//        }
//        cntOfTheHoles += 1;
//        Console.WriteLine($"Vanko got electrocuted, but he managed to make {cntOfTheHoles} hole(s).");
//        electrocuted = true;
//    }
//}

//public static int R(int rodHits, bool valid)
//{
//    if (valid)
//    {
//        Console.WriteLine("Vanko hit a rod!");
//        rodHits += 1;
//    }

//    return rodHits;
//}

//public static void Right(int n, char[,] matrix, int currRow, int currCol, ref char nextStep, ref int firstNextStepCoordsValue, ref int secondNextStepCoordsValue, ref bool valid)
//{
//    if (currCol != n)
//    {
//        nextStep = matrix[currRow, currCol + 1];
//        firstNextStepCoordsValue = currRow;
//        secondNextStepCoordsValue = currCol + 1;
//        valid = true;
//    }
//}

//public static void Down(int n, char[,] matrix, int currRow, int currCol, ref char nextStep, ref int firstNextStepCoordsValue, ref int secondNextStepCoordsValue, ref bool valid)
//{
//    if (currRow != n)
//    {
//        nextStep = matrix[currRow + 1, currCol];
//        firstNextStepCoordsValue = currRow + 1;
//        secondNextStepCoordsValue = currCol;
//        valid = true;
//    }
//}

//public static void Up(char[,] matrix, int currRow, int currCol, ref char nextStep, ref int firstNextStepCoordsValue, ref int secondNextStepCoordsValue, ref bool valid)
//{
//    if (currRow != 0)
//    {
//        nextStep = matrix[currRow - 1, currCol];
//        firstNextStepCoordsValue = currRow - 1;
//        secondNextStepCoordsValue = currCol;
//        valid = true;
//    }
//}

//public static void Left(char[,] matrix, int currRow, int currCol, ref char nextStep, ref int firstNextStepCoordsValue, ref int secondNextStepCoordsValue, ref bool valid)
//{
//    if (currCol != 0)
//    {
//        nextStep = matrix[currRow, currCol - 1];
//        firstNextStepCoordsValue = currRow;
//        secondNextStepCoordsValue = currCol - 1;
//        valid = true;
//    }
//}
//        }
//    }
//}