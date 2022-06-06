using System;

namespace P08._Tennis_Ranklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int turnirCnt = int.Parse(Console.ReadLine());
            int beginPointsCnt = int.Parse(Console.ReadLine());
            
            int W = 2000;
            int F = 1200;
            int SF = 720;
            int beginPointsCntW = 0;
            int beginPointsCntF = 0;
            int beginPointsCntSF = 0;
            int winCnt = 0;
            for (int i = 0; i < turnirCnt; i++)
            {
                string etapOtTurnir = Console.ReadLine();
                if (etapOtTurnir == "W")
                {
                    beginPointsCntW += W;
                    winCnt++;
                }
                else if (etapOtTurnir == "F")
                {
                    beginPointsCntF += F;
                }
                else if (etapOtTurnir == "SF")
                {
                    beginPointsCntSF += SF;
                }                
            }
            int totalPoints = beginPointsCnt+beginPointsCntW + beginPointsCntF + beginPointsCntSF;
            double averagePoints = (totalPoints-beginPointsCnt) / turnirCnt;
            int winMatches = winCnt;
            double percentWinMatches = winMatches * 100.00 / turnirCnt ;
            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
            Console.WriteLine($"{percentWinMatches:f2}%");
        }
    }
}
