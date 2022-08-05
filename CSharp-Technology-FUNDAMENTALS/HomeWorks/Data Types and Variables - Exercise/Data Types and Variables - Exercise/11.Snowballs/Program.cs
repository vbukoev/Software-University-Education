using System;
using System.Numerics;

namespace _11.Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int snowBalls = int.Parse(Console.ReadLine());
            BigInteger snowBallValue = 0;
            BigInteger snowBallSnow = 0;
            BigInteger snowBallTime = 0;
            int snowBallQuality = 0;
            BigInteger bestSnowBall = int.MinValue;

            string bestSnowBallFormula = "";
            for (int i = 0; i < snowBalls; i++)
            {
                snowBallSnow = BigInteger.Parse(Console.ReadLine());
                snowBallTime = BigInteger.Parse(Console.ReadLine());
                snowBallQuality = int.Parse(Console.ReadLine());

                BigInteger currentSnowBallValue = snowBallSnow / snowBallTime;
                snowBallValue = BigInteger.Pow(currentSnowBallValue, snowBallQuality);
                if (snowBallValue>bestSnowBall)
                {
                    bestSnowBall = snowBallValue;
                    bestSnowBallFormula = $"{snowBallSnow} : {snowBallTime} = {snowBallValue} ({snowBallQuality})";
                }
            }
            Console.WriteLine(bestSnowBallFormula);
        }
    }
}
