using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Claims;

namespace _01Lootbox
{
    public class Program
    {
        static void Main(string[] args)
        {
            Queue<int> boxNumOne = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> boxNumTwo = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int sumOfClaimedItems = 0;
            while (true)
            {
                if (!boxNumOne.Any() || !boxNumTwo.Any()) break;
                int firstItem = boxNumOne.Peek();
                int secondItem = boxNumTwo.Pop();
                int sumOfFirstAndSecondItem = firstItem + secondItem;
                if (sumOfFirstAndSecondItem % 2 ==0)
                {
                    sumOfClaimedItems = sumOfFirstAndSecondItem + sumOfClaimedItems;
                    boxNumOne.Dequeue();
                }
                else  boxNumOne.Enqueue(secondItem); 
            }
            if (!boxNumOne.Any())Console.WriteLine("First lootbox is empty"); 
            else if (!boxNumTwo.Any()) Console.WriteLine("Second lootbox is empty"); 

            if (sumOfClaimedItems<100) Console.WriteLine($"Your loot was poor... Value: {sumOfClaimedItems}"); 
            else Console.WriteLine($"Your loot was epic! Value: {sumOfClaimedItems}");
        }
    }
}