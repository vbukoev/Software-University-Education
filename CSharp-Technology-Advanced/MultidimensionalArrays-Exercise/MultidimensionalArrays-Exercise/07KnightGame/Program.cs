using System;
using System.Linq;

namespace _07KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            if (size < 3)
            {
                Console.WriteLine(0);
                return;
            }
               
            var matrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                var chars = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = chars[col];
                }
            }
            
            var knightsRemoveCnt = 0;
            int cntMostAttacked = 0;
            int rowMostAttacked = 0;
            int colMostAttacked = 0;
            while (true)
            {
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int attackedKnights = CountAttackedKnigths(row, col, size, matrix);
                            if (cntMostAttacked < attackedKnights)
                            {
                                cntMostAttacked = attackedKnights;
                                rowMostAttacked = row;
                                colMostAttacked = col;
                            }
                        }
                    }
                }
                if (cntMostAttacked == 0) break;
                else
                {
                    matrix[rowMostAttacked, colMostAttacked] = '0';
                    knightsRemoveCnt++;
                }
            }
            Console.WriteLine(knightsRemoveCnt);
        }
        
        static int CountAttackedKnigths(int row, int col, int size, char[,] matrix)
        {
            int attackedKnigths = 0;

            ////HORIZONTAL
            
            //horizontal left-up
            if (IsCellValid(row - 1, col - 2, size))
            {
                if (matrix[row - 1, col - 2] == 'K') attackedKnigths++;
            }
            //horizontal left-down
            if (IsCellValid(row + 1, col - 2, size))
            {
                if (matrix[row + 1, col - 2] == 'K') attackedKnigths++;
            }
            //horizontal rigth-up
            if (IsCellValid(row - 1, col + 2, size))
            {
                if (matrix[row - 1, col + 2] == 'K') attackedKnigths++;
            }
            // horizontal rigth-down
            if (IsCellValid(row +1, col + 2, size))
            {
                if (matrix[row + 1, col + 2] == 'K') attackedKnigths++;
            }

            ///////////VERTICAL
            
            // vertical up-left
            if (IsCellValid(row -2 , col -1 , size))
            {
                if (matrix[row -2, col - 1] == 'K') attackedKnigths++;
            }
            //vertical up-rigth
            if (IsCellValid(row - 2, col + 1, size))
            {
                if (matrix[row - 2, col + 1] == 'K') attackedKnigths++;
            }
            //vertical down-left
            if (IsCellValid(row + 2, col - 1, size))
            {
                if (matrix[row + 2, col - 1] == 'K') attackedKnigths++;
            }
            //vertical down-rigth
            if (IsCellValid(row + 2, col + 1, size))
            {
                if (matrix[row + 2, col + 1] == 'K') attackedKnigths++;
            }
            return attackedKnigths;
        }
        static bool IsCellValid(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }
    }
}
