using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> dungeonsRoom = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
            int initialHealth = 100;
            int initialBitcoins = 0;
            string command = "";
            int number = 0;
            int rooms = 0;
            List<string> currRoom = new List<string>();
            for (int i = 0; i < dungeonsRoom.Count; i++)
            {
                currRoom = dungeonsRoom[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                command = currRoom[0];
                number = int.Parse(currRoom[1]);
                switch (command)
                {
                    case "potion":
                        if (initialHealth == 100) rooms++;
                        else if (initialHealth < 100)
                        {
                            int healthPoint = number;
                            bool isEnoughHealth = number + initialHealth > 100;
                            if (!isEnoughHealth)
                            {
                                initialHealth += number;
                                Console.WriteLine($"You healed for {healthPoint} hp.");
                                Console.WriteLine($"Current health: {initialHealth} hp.");
                                rooms++;
                            }
                            else
                            {
                                int diff = 100 - initialHealth;
                                initialHealth += diff;
                                Console.WriteLine($"You healed for {diff} hp.");
                                Console.WriteLine($"Current health: {initialHealth} hp.");
                                rooms++;
                            }
                        }
                        break;
                    case "chest":
                        int currBitCoin = number;
                        Console.WriteLine($"You found {number} bitcoins.");
                        initialBitcoins += currBitCoin;
                        rooms++;
                        break;
                    default:
                        bool isHealthZero = initialHealth - number <= 0;
                        if (isHealthZero)
                        {
                            rooms++;
                            Console.WriteLine($"You died! Killed by {command}.");
                            Console.WriteLine($"Best room: {rooms}");
                            return;
                        }
                        Console.WriteLine($"You slayed {command}.");
                        initialHealth -= number;
                        rooms++;
                        break;
                }
            }
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {initialBitcoins}");
            Console.WriteLine($"Health: {initialHealth}");
        }    
    }
}
