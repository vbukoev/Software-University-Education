using System;

namespace P05.Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            //Inspection begins
            for (int i = 1; i <= n ; i++)
            {
                //Single iteration represents inspection of a single tab
                //Read every tab website opened
                string currentTabWebsite = Console.ReadLine();

                if (currentTabWebsite == "Facebook")
                {
                    salary -= 150;
                }
                else if (currentTabWebsite == "Instagram")
                {
                    salary -= 100;
                }
                else if (currentTabWebsite == "Reddit")
                {
                    salary -= 50;
                }

                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    //Program ends immediately
                    return;
                }
                
                
            }
            Console.WriteLine(salary);
        }
    }
}
