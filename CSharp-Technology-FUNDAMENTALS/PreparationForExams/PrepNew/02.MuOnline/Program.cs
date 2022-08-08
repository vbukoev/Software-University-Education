using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoins = 0;
            int num = 0;
            List<string> rooms = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
            int roomsCnt = 0;
            for (int i = 0; i < rooms.Count; i++)
            {
                string[] tokens = rooms[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                num = int.Parse(tokens[1]);
                switch (command)
                {
                    case "potion":
                        
                        if (health == 100) roomsCnt++;
                        else if (health < 100)
                        {
                            if (!(num + health > 100))
                            {
                                roomsCnt++;
                                health += num;
                                Console.WriteLine($"You healed for {num} hp.");
                                Console.WriteLine($"Current health: {health} hp.");
                            }
                            else
                            {
                                roomsCnt++;
                                int differenceBetween100AndHealth = 100 - health;
                                health += differenceBetween100AndHealth;
                                Console.WriteLine($"You healed for {differenceBetween100AndHealth} hp.");
                                Console.WriteLine($"Current health: {health} hp.");                               
                            }
                        }
                        break;
                    case "chest":
                        num = int.Parse(tokens[1]);
                        Console.WriteLine($"You found {num} bitcoins.");
                        bitcoins += num;
                        roomsCnt++;
                        break;
                    default:
                        if (((health - num) <= 0))
                        {
                            roomsCnt++;
                            Console.WriteLine($"You died! Killed by {command}.");
                            Console.WriteLine($"Best room: {roomsCnt}");                           
                            return;
                        }
                        Console.WriteLine($"You slayed {command}.");
                        roomsCnt++;
                        health -= num;
                        break;
                }
            }
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
