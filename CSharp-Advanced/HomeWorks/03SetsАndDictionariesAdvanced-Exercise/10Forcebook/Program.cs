using System;
using System.Collections.Generic;
using System.Linq;

namespace _10Forceb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedSet<string>> sidesUsers = new Dictionary<string, SortedSet<string>>();
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "Lumpawaroo") break;
                if (cmd.Contains('|'))
                {
                    var tokens = cmd.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string side = tokens[0];
                    string user = tokens[1];
                    if (!sidesUsers.Values.Any(u => u.Contains(user)))
                    {
                        if (!sidesUsers.ContainsKey(side))
                        {
                            sidesUsers.Add(side, new SortedSet<string>());
                        }
                        sidesUsers[side].Add(user);
                    }
                }
                else
                {
                    var tokens = cmd.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string side = tokens[1];
                    string user = tokens[0];
                    foreach (var sideUser in sidesUsers)
                    {
                        if (sideUser.Value.Contains(user))
                        {
                            sideUser.Value.Remove(user);
                            break;
                        }
                    }
                    if (!sidesUsers.ContainsKey(side))
                    {
                        sidesUsers.Add(side, new SortedSet<string>());   
                    }
                    sidesUsers[side].Add(user);
                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            var orderedSidesUsers = sidesUsers.OrderByDescending(u => u.Value.Count).ThenBy(n=>n.Key);

            foreach (var sideUsers in orderedSidesUsers)
            {
                if (sideUsers.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {sideUsers.Key}, Members: {sideUsers.Value.Count}");
                    foreach (var user in sideUsers.Value)
                    {
                        Console.WriteLine($"! {user}");
                    }
                }                
            }
        }
    }
}
