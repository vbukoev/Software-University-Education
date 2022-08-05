using System;

namespace _08._Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nLines = int.Parse(Console.ReadLine());
            double biggesKegg = double.MinValue;
            string biggestKegName = "";

            for (int i = 0; i < nLines; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volumeOfTheCurrKegg = Math.PI * Math.Pow(radius, 2) * height;
                if (volumeOfTheCurrKegg > biggesKegg)
                {
                    biggesKegg = volumeOfTheCurrKegg;
                    biggestKegName = model;
                }                
            }
            Console.WriteLine(biggestKegName);
        }
    }
}
