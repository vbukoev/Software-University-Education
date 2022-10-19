using System;
using System.Collections;
using System.Collections.Generic;

namespace _03SumOfCoins
{
    public class Program
    {
        static void Main(string[] args)
        {
            int finalSum = 18;
            int currSum = 0;
            int[] coins = { 10, 10, 5, 5, 2, 2, 1, 1 };
            Queue<int> result = new Queue<int>();
            for (int i = 0; i < coins.Length; i++)
            {
                if (currSum + coins[i] > finalSum) continue;
                currSum += coins[i];
                result.Enqueue(coins[i]);
                if (currSum == finalSum)
                {

                }
            }
            Console.WriteLine("Sum not found");
        }
    }
}
