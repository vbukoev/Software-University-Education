using System;

namespace P07.AreaOfFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //read the figure name from the console
            string formOfFigure = Console.ReadLine();
            //Create condition for every formOfFigure and print the result
            if (formOfFigure == "square")
            {
                double a = double.Parse(Console.ReadLine());
                double S = a * a;
                Console.WriteLine($"{S:f3}");
            }
            else if (formOfFigure == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                double S = a * b;
                Console.WriteLine($"{S:f3}");
            }
            else if (formOfFigure == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                double S = Math.PI * r * r;
                Console.WriteLine($"{S:f3}");
            }
            else if (formOfFigure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double ha = double.Parse(Console.ReadLine());
                double S = (a * ha) / 2;
                Console.WriteLine($"{S:f3}");
            }
        }
    }
}
