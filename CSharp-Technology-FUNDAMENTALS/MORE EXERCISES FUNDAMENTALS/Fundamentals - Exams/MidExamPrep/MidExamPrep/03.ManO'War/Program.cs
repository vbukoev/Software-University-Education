using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ManO_War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShipStatus = Console.ReadLine().Split(">", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> warShipStatus = Console.ReadLine().Split(">", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int maxHealth = int.Parse(Console.ReadLine());
            bool stalementOccur = false;
            int sumOfThePirateShip = 0;
            int sumOfTheWarShip = 0;
            int count = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Retire") break;
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
               
                switch (action)
                {
                    case "Fire":
                        int index = int.Parse(tokens[1]);
                        int damage = int.Parse(tokens[2]);
                        if (index >= 0 && index < pirateShipStatus.Count)
                        {                            
                            warShipStatus[index] -= damage;
                            if (warShipStatus[index] <= 0)
                            {
                                stalementOccur = true;
                                Console.WriteLine("You won! The enemy ship has sunken.");                                
                            }
                            else
                            {
                                warShipStatus.RemoveAt(index);
                                warShipStatus.Insert(index, warShipStatus[index]);
                            }
                        }
                        break;
                    case "Defend":
                        int startIndex = int.Parse(tokens[1]);
                        int endIndex = int.Parse(tokens[2]);
                        int damage = int.Parse(tokens[3]);
                        if (startIndex >= 0 && endIndex < pirateShipStatus.Count)
                        {
                            for (int currIndex = startIndex; currIndex <= endIndex; currIndex++)
                            {
                                int result = pirateShipStatus[currIndex] - damage;
                                if (result <= 0)
                                {
                                    stalementOccur = true;
                                    Console.WriteLine("You lost! The pirate ship has sunken.");
                                    break;
                                }
                                else
                                {
                                    pirateShipStatus.Remove(pirateShipStatus[currIndex]);
                                    pirateShipStatus.Insert(startIndex, result);
                                    startIndex++;
                                }
                            }
                        }
                        break;
                    case "Repair":
                        int index1 = int.Parse(tokens[1]);
                        int health = int.Parse(tokens[2]);
                        if (index1 >= 0 && index1 < pirateShipStatus.Count)
                        {
                            if (health > maxHealth)
                            {
                                health = maxHealth;
                                pirateShipStatus.RemoveAt(index1);
                                pirateShipStatus.Insert(index1, health);
                            }
                            else
                            {
                                pirateShipStatus.RemoveAt(index1);
                                pirateShipStatus.Insert(index1, health + pirateShipStatus[index1]);
                            }
                        }
                        break;
                    case "Status":
                        double percents = maxHealth * 0.2;
                        for (int currIndex = 0; currIndex < pirateShipStatus.Count; currIndex++)
                        if (percents > pirateShipStatus[currIndex]) count++;
                        Console.WriteLine($"{count} sections need repair.");
                        break;                      
                }
                if (stalementOccur) break;                
            }
            if (!stalementOccur)
            {
                for (int i = 0; i < pirateShipStatus.Count; i++) sumOfThePirateShip += pirateShipStatus[i];
                Console.WriteLine($"Pirate ship status: {sumOfThePirateShip}");
                for (int j = 0; j < warShipStatus.Count; j++) sumOfTheWarShip += warShipStatus[j];
                Console.WriteLine($"Warship status: {sumOfTheWarShip}");                
            }            
        }
    }
}