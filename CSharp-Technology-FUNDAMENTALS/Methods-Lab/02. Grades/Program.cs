using System;

namespace _02._Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double grade = double.Parse(input);
            PrintGrade(grade);
        }
        static void PrintGrade(double grade)
        {
            if (grade >=2 && grade <=2.99)
            {
                Console.WriteLine("Fail");
            }
            else if(grade <= 3.49)
            {
                Console.WriteLine("Poor");
            }
            else if(grade<=4.49)
            {
                Console.WriteLine("Good");
            } 
            else if(grade <= 5.49)
            {
                Console.WriteLine("Very good");
            }
            else if(grade <=6)
            {
                Console.WriteLine("Excellent");
            }
                //2.00 – 2.99 - "Fail"

//· 3.00 – 3.49 - "Poor"

//· 3.50 – 4.49 - "Good"

//· 4.50 – 5.49 - "Very good"

//· 5.50 – 6.00 - "Excellent"
        }
    }
}
