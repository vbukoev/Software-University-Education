using System;

namespace _01.SoftUniReception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            int firstEfficiency = int.Parse(Console.ReadLine());
            int secondEfficiency = int.Parse(Console.ReadLine());
            int thirdEfficiency = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            int neededTime = 0;
            int totalEff = firstEfficiency + secondEfficiency + thirdEfficiency;

            //logicOfTheOperation
            while (studentsCount > 0)
            {
                studentsCount -= totalEff;
                neededTime++;
                if (neededTime % 4 == 0)
                {
                    neededTime++;
                }
            }
           
            //output 
            Console.WriteLine($"Time needed: {neededTime}h.");
        }
    }
}
