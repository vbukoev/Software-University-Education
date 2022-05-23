using System;

namespace _03._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cntOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfTheWeek = Console.ReadLine();
            double totalPrice = 0;

            if (typeOfGroup == "Students")
            {
                if (dayOfTheWeek == "Friday")
                {
                    totalPrice = cntOfPeople * 8.45;
                }
                else if (dayOfTheWeek == "Saturday")
                {
                    totalPrice = cntOfPeople * 9.80;
                }
                else if (dayOfTheWeek == "Sunday")
                {
                    totalPrice = cntOfPeople * 10.46;
                }
                if(cntOfPeople >= 30)
                {
                    totalPrice -= totalPrice * 0.15;
                }
            }
            else if (typeOfGroup == "Regular")
            {
                if (dayOfTheWeek == "Friday")
                {
                    totalPrice = cntOfPeople * 15;
                }
                else if (dayOfTheWeek == "Saturday")
                {
                    totalPrice = cntOfPeople * 20;
                }
                else if (dayOfTheWeek == "Sunday")
                {
                    totalPrice = cntOfPeople * 22.50;
                }
                if(cntOfPeople >= 10 && cntOfPeople <=20)
                {
                    totalPrice -= totalPrice * 0.05;
                }
            }
            else if (typeOfGroup == "Business")
            {
                if (dayOfTheWeek == "Friday")
                {
                    totalPrice = cntOfPeople * 10.90;
                }
                else if (dayOfTheWeek == "Saturday")
                {
                    totalPrice = cntOfPeople * 15.60;
                }
                else if (dayOfTheWeek == "Sunday")
                {
                    totalPrice = cntOfPeople * 16;
                }
                if(cntOfPeople >= 100)
                {
                    totalPrice -= totalPrice /cntOfPeople * 10;
                }
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");
            
        }
    }
}
