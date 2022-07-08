//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Legendary_Farming
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {

//            var legendaryFarming = new Dictionary<string, int>()
//            {
//                {"shards", 0 },
//                {"fragments", 0},
//                {"motes", 0 }
//            };

//            bool finish = false;
//            while (!finish)
//            {

//                string[] input = Console.ReadLine().Split();
//                for (int i = 0; i < input.Length; i += 2)
//                {
//                    int valueItem = int.Parse(input[i]);
//                    string nameItem = input[i + 1].ToLower(); ;

//                    if (legendaryFarming.ContainsKey(nameItem))
//                    {
//                        legendaryFarming[nameItem] += valueItem;
//                    }
//                    else
//                    {
//                        legendaryFarming.Add(nameItem, valueItem);
//                    }

//                    bool validName = nameItem == "shards" || nameItem == "fragments" || nameItem == "motes";
//                    if (legendaryFarming[nameItem] >= 250 && validName)
//                    {
//                        finish = true;
//                        switch (nameItem)
//                        {
//                            case "shards": Console.WriteLine("Shadowmourne obtained!"); break;
//                            case "fragments": Console.WriteLine("Valanyr obtained!"); break;
//                            case "motes": Console.WriteLine("Dragonwrath obtained!"); break;
//                        }
//                        legendaryFarming[nameItem] -= 250;
//                        break;
//                    }
//                }
//            }


//            var material = legendaryFarming.Where(x => x.Key == "shards" || x.Key == "fragments" || x.Key == "motes").ToDictionary(x => x.Key, x => x.Value);
//            var junk = legendaryFarming.Where(x => x.Key != "shards" && x.Key != "fragments" && x.Key != "motes").OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

//            material = material.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

//            foreach (var item in material)
//            {
//                Console.WriteLine(item.Key + ": " + item.Value);
//            }
//            foreach (var item in junk)
//            {
//                Console.WriteLine(item.Key + ": " + item.Value);
//            }
//        }
//    }
//}

/////////////////////////////--------------------------------------------------------/////////////////////////////

//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace _03.LegendaryFarming
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            var junks = new Dictionary<string, int>();
//            var dictionary = new Dictionary<string, int>();
//            dictionary["fragments"] = 0;
//            dictionary["motes"] = 0;
//            dictionary["shards"] = 0;
//            bool isThereAWinner = false;

//            while (!isThereAWinner)
//            {
//                var tokens = Console.ReadLine().Split();
//                for (int i = 0; i < tokens.Length; i += 2)
//                {
//                    string type = tokens[i + 1].ToLower();
//                    int quantity = int.Parse(tokens[i]);
//                    if (dictionary.ContainsKey(type)) dictionary[type] += quantity;
//                    else dictionary.Add(type, quantity);
//                    bool validName = type == "shards" || type == "fragments" || type == "motes";
//                    if (dictionary[type] >=250 && validName)
//                    {
//                        isThereAWinner = true;
//                        switch (type)
//                        {
//                            case "shards":
//                                Console.WriteLine("Shadowmourne obtained!");
//                                break;
//                            case "motes":
//                                Console.WriteLine("Dragonwrath obtained!");
//                                break;
//                            case "fragments":
//                                Console.WriteLine("Valanyr obtained!");
//                                break;
//                            default:
//                                break;
//                        }
//                        dictionary[type] -= 250;
//                        break;
//                    }
//                }
//            }

//            var material = dictionary.Where(x => x.Key == "shards" || x.Key == "fragments" || x.Key == "motes").ToDictionary(x => x.Key, x => x.Value);
//            var junk = dictionary.Where(x => x.Key != "shards" && x.Key != "fragments" && x.Key != "motes").OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

//            material = material.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

//            foreach (var item in material)
//            {
//                Console.WriteLine(item.Key + ": " + item.Value);
//            }
//            foreach (var item in junk)
//            {
//                Console.WriteLine(item.Key + ": " + item.Value);
//            }
//        }
//    }
//}
using System;
using System.Linq;
using System.Collections.Generic;

namespace _03LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyElements = new Dictionary<string, int>();

            keyElements["fragments"] = 0;
            keyElements["motes"] = 0;
            keyElements["shards"] = 0;

            var junkElements = new Dictionary<string, int>();

            bool haveWinner = false;

            while (haveWinner != true)
            {
                var tokens = Console.ReadLine()
                    .ToLower()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int i = 0; i < tokens.Length; i += 2)
                {
                    string type = tokens[i + 1];
                    int quantity = int.Parse(tokens[i]);

                    if (keyElements.ContainsKey(type))
                    {
                        keyElements[type] += quantity;

                        if (keyElements["motes"] >= 250)
                        {
                            Console.WriteLine("Dragonwrath obtained!");
                            keyElements["motes"] -= 250;
                            haveWinner = true;
                            break;
                        }
                        else if (keyElements["fragments"] >= 250)
                        {
                            Console.WriteLine("Valanyr obtained!");
                            keyElements["fragments"] -= 250;
                            haveWinner = true;
                            break;
                        }
                        else if (keyElements["shards"] >= 250)
                        {
                            Console.WriteLine("Shadowmourne obtained!");
                            keyElements["shards"] -= 250;
                            haveWinner = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkElements.ContainsKey(type))
                        {
                            junkElements[type] = quantity;
                        }
                        else
                        {
                            junkElements[type] += quantity;
                        }
                    }
                }

            }

            foreach (var kvp in keyElements.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junkElements)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}