using System;
using System.Linq;

namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleWaiting = int.Parse(Console.ReadLine());
            int[] currStateOfTheLift = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int peopleCurrentlyOnTheWagon = 0;
            int totalPeopleOnTheLift = 0;
            bool notEnoughSpace = false;
            for (int i = 0; i < currStateOfTheLift.Length; i++)
            {
                while(currStateOfTheLift[i]<4)
                {
                    currStateOfTheLift[i]++;
                    peopleCurrentlyOnTheWagon++;
                    if (peopleCurrentlyOnTheWagon + totalPeopleOnTheLift == peopleWaiting)
                    {
                        notEnoughSpace = true;
                        break;
                    }
                }
                totalPeopleOnTheLift += peopleCurrentlyOnTheWagon;
                if (notEnoughSpace)
                {
                    break;
                }
                peopleCurrentlyOnTheWagon = 0;
            }
            if (peopleWaiting > totalPeopleOnTheLift)
            {
                int peopleLeft = peopleWaiting - totalPeopleOnTheLift;
                Console.WriteLine($"There isn't enough space! {peopleLeft} people in a queue!");
                Console.WriteLine(string.Join(" ", currStateOfTheLift));
            }
            else if(peopleWaiting < currStateOfTheLift.Length * 4  && currStateOfTheLift.Any(w => w < 4))
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", currStateOfTheLift));
            }
            else if (currStateOfTheLift.All(w=>w==4)  && notEnoughSpace == true)
            {
                Console.WriteLine(string.Join(" ", currStateOfTheLift));
            }
        }
    }
}
