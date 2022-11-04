using System;

namespace P06._Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameOfActor = Console.ReadLine();
            double pointsFromAcademy = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string nameOfGrader = Console.ReadLine();
                double pointsFromGrader = double.Parse(Console.ReadLine());
                pointsFromAcademy = pointsFromAcademy + ((nameOfGrader.Length * pointsFromGrader) / 2);
                if (pointsFromAcademy > 1250.5)
                {
                    Console.WriteLine($"Congratulations, {nameOfActor} got a nominee for leading role with {pointsFromAcademy:f1}!");
                    return;
                }
                
            }
            if(pointsFromAcademy<=1250.5)
            {
                double pointsNeeded = 1250.5 - pointsFromAcademy;
                Console.WriteLine($"Sorry, {nameOfActor} you need {pointsNeeded:f1} more!");
            }
        }
    }
}