using System;

namespace P07._Trekking_Mania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groupCnt = int.Parse(Console.ReadLine());
            int musala = 0;
            int montblan = 0;
            int kilimandjaro = 0;
            int k2 = 0;
            int everest = 0;
            for (int i = 0; i < groupCnt; i++)
            {
                int pplCnt = int.Parse(Console.ReadLine());                
                if (pplCnt <= 5)
                {
                    musala+=pplCnt;
                }
                else if (pplCnt >= 6 && pplCnt <= 12)
                {

                    montblan+=pplCnt;
                }
                else if (pplCnt >= 13 && pplCnt <= 25)
                {
                    kilimandjaro+=pplCnt;
                }
                else if (pplCnt >= 26 && pplCnt <= 40)
                {
                    k2+=pplCnt;
                }
                else if (pplCnt >= 41)
                {
                    everest+=pplCnt;
                }

            }
            double allAlpinists = musala + montblan + kilimandjaro + k2 + everest;
            double percentMusala = musala / allAlpinists * 100;
            double percentMontblanc = montblan / allAlpinists * 100;
            double percentKilimanjaro = kilimandjaro / allAlpinists * 100;
            double percentK2 = k2 / allAlpinists * 100;
            double percentEverest = everest / allAlpinists * 100;

            Console.WriteLine($"{percentMusala:f2}%");
            Console.WriteLine($"{percentMontblanc:f2}%");
            Console.WriteLine($"{percentKilimanjaro:f2}%");
            Console.WriteLine($"{percentK2:f2}%");
            Console.WriteLine($"{percentEverest:f2}%");
        }
    }
}
