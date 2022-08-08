using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, int>();
            var cmd = "";
            while (true)
            {
                cmd = Console.ReadLine();
                if (cmd == "Log out") break;
                var tokens = cmd.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                var action = tokens[0];
                var newUserName = tokens[1];
                switch (action)
                {
                    case "New follower":
                        NewFollower(dictionary, newUserName);
                        break;

                    case "Like":
                        Like(dictionary, tokens, newUserName);
                        break;

                    case "Comment":
                        Comment(dictionary, newUserName);
                        break;

                    case "Blocked":
                        Blocked(dictionary, newUserName);
                        break;

                    default:
                        break;
                }
            }
            var followersCnt = dictionary.Keys.Count;
            Console.WriteLine($"{followersCnt} followers");
            foreach (var kvp in dictionary) Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
        static void NewFollower(Dictionary<string, int> dictionary, string newUserName)
        {
            if (!dictionary.ContainsKey(newUserName)) dictionary.Add(newUserName, 0);
        }
        static void Like(Dictionary<string, int> dictionary, string[] tokens, string newUserName)
        {
            var cnt = int.Parse(tokens[2]);
            if (!dictionary.ContainsKey(newUserName)) dictionary.Add(newUserName, 0);
            dictionary[newUserName] += cnt;
        }
        static void Comment(Dictionary<string, int> dictionary, string newUserName)
        {
            if (!dictionary.ContainsKey(newUserName)) dictionary.Add(newUserName, 0);
            dictionary[newUserName] = dictionary[newUserName] + 1;
        }
        static void Blocked(Dictionary<string, int> dictionary, string newUserName)
        {
            if (!dictionary.ContainsKey(newUserName)) Console.WriteLine($"{newUserName} doesn't exist.");
            else dictionary.Remove(newUserName);
        }
    }
}
// task with methods