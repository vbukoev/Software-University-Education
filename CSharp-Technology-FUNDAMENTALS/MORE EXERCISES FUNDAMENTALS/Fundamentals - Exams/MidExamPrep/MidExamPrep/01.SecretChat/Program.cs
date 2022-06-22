using System;

namespace _01.SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //input
            int numOfStuds = int.Parse(Console.ReadLine());
            int numOfLecs = int.Parse(Console.ReadLine());
            int addBonus = int.Parse(Console.ReadLine());
            double attends = 0;
            double bonus = 0;
            int maxAtts = 0;

            for (int i = 0; i < numOfStuds; i++)
            {
                attends = double.Parse(Console.ReadLine());
                double bonusTotal = ((1.0 * attends / numOfLecs) * (5 + addBonus));
                if (bonus < bonusTotal)
                {
                    bonus = bonusTotal;
                    maxAtts = (int)attends;
                }
            }

            //output
            Console.WriteLine($"Max Bonus: {Math.Ceiling(bonus)}.");
            Console.WriteLine($"The student has attended {maxAtts} lectures.");
        }
    }
}
