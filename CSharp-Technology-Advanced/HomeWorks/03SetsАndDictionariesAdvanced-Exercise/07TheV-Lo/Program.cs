using System;
using System.Collections.Generic;
using System.Linq;

namespace _07TheV_Lo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Statistics") break;
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string cmd = tokens[1];
                if (cmd == "joined")
                {
                    string vloggerName = tokens[0];
                    if (!dict.ContainsKey(vloggerName))
                    {
                        dict.Add(vloggerName, new Dictionary<string, HashSet<string>>());
                        dict[vloggerName].Add("followers", new HashSet<string>());
                        dict[vloggerName].Add("following", new HashSet<string>());

                    }
                }
                else
                {
                    string first = tokens[0];
                    string second = tokens[2];
                    if (dict.ContainsKey(first) 
                        && dict.ContainsKey(second) 
                        && first != second)
                    {
                        dict[second]["followers"].Add(first);
                        dict[first]["following"].Add(second);
                    }
                }
            }
            int cnt = 1;
            Console.WriteLine($"The V-Logger has a total of {dict.Keys.Count} vloggers in its logs.");

            foreach (var vlogger in dict.OrderByDescending(x=>x.Value["followers"].Count).ThenBy(x=> x.Value["following"].Count))
            {
                Console.WriteLine($"{cnt}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
                if (cnt == 1)
                {
                    foreach (var follower in vlogger.Value["followers"].OrderBy(x=>x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                cnt++;
            }
        }
    }
}



//        List<Vlogger> vloggers = new List<Vlogger>();
//        while (true)
//        {
//            string cmd = Console.ReadLine();
//            if (cmd == "Statistics") break;
//            var tokens = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
//            string vloggerName = tokens[0];
//            string vloggerToFollowName = tokens[2];

//            switch (tokens[1])
//            {
//                case "joined":
//                    if (!vloggers.Any(v => v.Name == vloggerName))
//                    {
//                    vloggers.Add(new Vlogger(vloggerName));
//                    }
//                    break;


//                case "followed":
//                    if (vloggerName == vloggerToFollowName
//                        || !vloggers.Any(v => v.Name == vloggerName
//                        || !vloggers.Any(v => v.Name == vloggerToFollowName)))
//                        continue;

//                    Vlogger vlogger = vloggers.Single(v => v.Name == vloggerName);
//                    vlogger.Following.Add(vloggerToFollowName);

//                    Vlogger vloggerToFollow = vloggers.Single(v => v.Name == vloggerToFollowName);
//                    vloggerToFollow.Followers.Add(vloggerName);

//                    break;
//            }
//        }
//        vloggers = vloggers.OrderByDescending(x => x.Followers.Count).ThenBy(x=>x.Following.Count).ToList();

//        int cnt = 1;
//        Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

//        foreach (var vlogger in vloggers)
//        {
//            Console.WriteLine($"{cnt}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Following.Count} following");
//            if (cnt == 1)
//            {
//                foreach (var follower in vlogger.Followers)
//                {
//                    Console.WriteLine($"*  {follower}");
//                }
//            }
//            cnt++;
//        }
//    }
//}
//public class Vlogger
//{
//    public Vlogger(string name)
//    {
//        Name = name;
//        Followers = new SortedSet<string>();
//        Following = new HashSet<string>();
//    }

//    public string Name { get; set; }
//    public SortedSet<string> Followers { get; set; }
//    public HashSet<string> Following { get; set; }

