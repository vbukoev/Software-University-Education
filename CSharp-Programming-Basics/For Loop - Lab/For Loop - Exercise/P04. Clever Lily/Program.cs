using System;

namespace P04._Clever_Lily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            int nAgeOfLily = int.Parse(Console.ReadLine());
            double priceOfWashingMachine = double.Parse(Console.ReadLine());
            int singleToyPrice = int.Parse(Console.ReadLine());

            //Act
            //let the for loop be Lily aging 
            int toysCollected = 0;
            int savings = 0;

            for (int currAge = 1; currAge <= nAgeOfLily; currAge++)
            {
                if (currAge % 2 != 0)
                {//odd age
                    toysCollected++;
                }
                else//even age
                {
                    int moneyPresent = (currAge * 5) - 1;
                    savings += moneyPresent;
                }
            }

            //Lily has saved money from even years
            //Now we need to add money from the sold toys
            int toysSellPrice = toysCollected * singleToyPrice;
            savings += toysSellPrice;

            //Output
            if (savings >= priceOfWashingMachine)
            {
                double left = savings - priceOfWashingMachine;
                Console.WriteLine($"Yes! {left:f2}");
            }
            else
            {
                double needed = priceOfWashingMachine - savings;
                Console.WriteLine($"No! {needed:f2}");
            }
        }
    }
}
