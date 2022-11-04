using System;

namespace P04._Even_Powers_of_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // input from the user
            int num = 1; //create the number
            for (int i = 0; i <=n; i+=2) // for-loop
            {
                Console.WriteLine(num); // print the number on the console
                num = num * 2 * 2; 
            }
        }
    }
}
