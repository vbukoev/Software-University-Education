using System;

namespace P03._Sum_Prime_Non_Prime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int primeNumberSum = 0;
            int nonPrimeNumberSum = 0;

            string command;
            while((command=Console.ReadLine()) !="stop")
            {
                int currNum = int.Parse(command);

                if(currNum<0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;   
                }
                else if(currNum==0)
                {
                    nonPrimeNumberSum+=currNum;
                    continue;
                }

                bool isPrimeNumber = true;
                for (int div = 2; div < currNum; div++)
                {
                    if(currNum%div == 0)
                    {
                        isPrimeNumber = false;
                        break;
                    }
                }
                if(isPrimeNumber)
                {
                    primeNumberSum += currNum;
                }
                else
                {
                    nonPrimeNumberSum += currNum;
                }

               
            }
            Console.WriteLine($"Sum of all prime numbers is: {primeNumberSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeNumberSum}");
        }
    }
}
