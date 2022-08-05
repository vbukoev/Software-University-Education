using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            List<int> warShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            int maxHelth = int.Parse(Console.ReadLine());
            string comand = null;
            bool yes = false;

            while ((comand = Console.ReadLine()) != "Retire")
            {
                string[] comnd = comand.Split(" ");
                if (comnd[0] == "Fire")
                {
                    int index = int.Parse(comnd[1]);
                    int damage = int.Parse(comnd[2]);
                    if (index >= 0 && index < pirateShip.Count)
                    {
                        int afterFire = warShip[index];
                        afterFire = afterFire - damage;
                        if (afterFire <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            yes = true;
                        }
                        else
                        {
                            warShip.RemoveAt(index);
                            warShip.Insert(index, afterFire);
                        }
                    }
                }
                else if (comnd[0] == "Defend")
                {
                    int startIndex = int.Parse(comnd[1]);
                    int endIndex = int.Parse(comnd[2]);
                    int damage = int.Parse(comnd[3]);
                    if (startIndex >= 0 && endIndex < pirateShip.Count)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            int indexNumber = i;
                            int result = pirateShip[indexNumber] - damage;
                            if (result <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                yes = true;
                                break;
                            }
                            else
                            {
                                pirateShip.Remove(pirateShip[indexNumber]);
                                pirateShip.Insert(startIndex, result);
                                startIndex++;
                            }
                        }
                    }
                }
                else if (comnd[0] == "Repair")
                {
                    int index = int.Parse(comnd[1]);
                    int helth = int.Parse(comnd[2]);
                    if (index >= 0 && index < pirateShip.Count)
                    {
                        if (helth > maxHelth)
                        {
                            helth = maxHelth;
                            pirateShip.RemoveAt(index);
                            pirateShip.Insert(index, helth);
                        }
                        else
                        {
                            int num = pirateShip[index];
                            pirateShip.RemoveAt(index);
                            pirateShip.Insert(index, helth + num);
                        }
                    }
                }
                else if (comnd[0] == "Status")
                {
                    int count = 0;
                    double percent = maxHelth * 0.2;
                    for (int i = 0; i < pirateShip.Count; i++)
                    {
                        int one = pirateShip[i];
                        if (percent > one)
                        {
                            count++;
                        }
                    }
                    Console.WriteLine($"{count} sections need repair.");
                }
                if (yes)
                {
                    break;
                }
            }
            if (yes == false)
            {
                int sum1 = 0;
                int sum2 = 0;
                for (int i = 0; i < pirateShip.Count; i++)
                {
                    sum1 += pirateShip[i];
                }
                Console.WriteLine($"Pirate ship status: {sum1}");
                for (int j = 0; j < warShip.Count; j++)
                {
                    sum2 += warShip[j];
                }
                Console.WriteLine($"Warship status: {sum2}");
            }
        }
    }
}




//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace _03.ManO_War
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            List<int> pirateShipStatus = Console.ReadLine().Split(">", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
//            List<int> warShipStatus = Console.ReadLine().Split(">", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
//            int maxHealth = int.Parse(Console.ReadLine());
//            bool stalementOccur = false;
//            int sumOfThePirateShip = 0;
//            int sumOfTheWarShip = 0;
//            int count = 0;
//            while (true)
//            {
//                string command = Console.ReadLine();
//                if (command == "Retire") break;
//                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
//                string action = tokens[0];

//                switch (action)
//                {
//                    case "Fire":
//                        int index = int.Parse(tokens[1]);
//                        int damage = int.Parse(tokens[2]);
//                        if (index >= 0 && index < pirateShipStatus.Count)
//                        {
//                            int afterFire = warShipStatus[index];
//                            afterFire -= damage;
//                            if (afterFire <= 0)
//                            {
//                                Console.WriteLine("You won! The enemy ship has sunken.");
//                                stalementOccur = true;
//                            }
//                            else
//                            {
//                                warShipStatus.RemoveAt(index);
//                                warShipStatus.Insert(index, afterFire);
//                            }
//                        }
//                        break;
//                    case "Defend":
//                        int startIndex = int.Parse(tokens[1]);
//                        int endIndex = int.Parse(tokens[2]);
//                        damage = int.Parse(tokens[3]);
//                        if (startIndex >= 0 && endIndex < pirateShipStatus.Count)
//                        {
//                            for (int currIndex = startIndex; currIndex <= endIndex; currIndex++)
//                            {
//                                int result = pirateShipStatus[currIndex] - damage;
//                                if (result <= 0)
//                                {
//                                    stalementOccur = true;

//                                    Console.WriteLine("You lost! The pirate ship has sunken.");

//                                    return;
//                                }
//                                else
//                                {
//                                    pirateShipStatus.Remove(pirateShipStatus[currIndex]);
//                                    pirateShipStatus.Insert(startIndex, result);
//                                    startIndex++;
//                                }
//                            }
//                        }
//                        break;
//                    case "Repair":
//                        int index1 = int.Parse(tokens[1]);
//                        int health = int.Parse(tokens[2]);
//                        if (index1 >= 0 && index1 < pirateShipStatus.Count)
//                        {
//                            if (health > maxHealth)
//                            {
//                                health = maxHealth;
//                                pirateShipStatus.RemoveAt(index1);
//                                pirateShipStatus.Insert(index1, health);
//                            }
//                            else
//                            {
//                                int number = pirateShipStatus[index1];
//                                pirateShipStatus.RemoveAt(index1);
//                                pirateShipStatus.Insert(index1, health + number);
//                            }
//                        }
//                        break;
//                    case "Status":
//                        double percents = maxHealth * 0.2;
//                        for (int currIndex = 0; currIndex < pirateShipStatus.Count; currIndex++)
//                        {
//                            if (percents > pirateShipStatus[currIndex]) count++;

//                        }
//                        Console.WriteLine($"{count} sections need repair.");
//                        break;

//                }
//                if (stalementOccur) break;
//            }
//            if (!stalementOccur)
//            {
//                for (int i = 0; i < pirateShipStatus.Count; i++) sumOfThePirateShip += pirateShipStatus[i];
//                Console.WriteLine($"Pirate ship status: {sumOfThePirateShip}");
//                for (int j = 0; j < warShipStatus.Count; j++) sumOfTheWarShip += warShipStatus[j];
//                Console.WriteLine($"Warship status: {sumOfTheWarShip}");
//            }
//        }
//    }
//}