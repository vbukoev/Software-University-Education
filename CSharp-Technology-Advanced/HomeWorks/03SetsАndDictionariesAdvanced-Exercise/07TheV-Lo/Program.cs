using System;
using System.Collections.Generic;
using System.Linq;

namespace _07TheV_Lo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vlogger> vloggers = new List<Vlogger>();
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "Statistics") break;
                var tokens = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string vloggerName = tokens[0];
                string vloggerToFollow = tokens[2];

                switch (tokens[1])
                {
                    case "joined":
                        if (!vloggers.Any(v => v.Name == vloggerName))
                        {

                        }
                        vloggers.Add(new Vlogger(vloggerName));
                        break;


                    case "followed":
                        if (vloggerName == vloggerToFollow || !vloggers.Any(v => v.Name == vloggerName || !vloggers.Any(v => v.Name == vloggerToFollow))) continue;
                        Vlogger vlogger = vloggers.Single(vlogger => vlogger.Name == vloggerName);
                        vlogger.Following.Add(vloggerToFollow);

                        Vlogger vloggerToFolow = vloggers.Single(vlogger => vlogger.Name == vloggerToFollow);
                        vloggerName.Followers.Add(vloggerName);
                        break;
                    default:
                        break;
                }
            }
            vloggers = vloggers.OrderByDescending(x => x.Followers.Count).ThenBy(x=>x.Following.Count).ToList();

            int cnt = 1;
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            foreach (var vlogger in vloggers)
            {
                Console.WriteLine($"{cnt}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Following.Count} following");
                if (cnt == 1)
                {
                    foreach (var follower in vlogger.Followers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                cnt++;
            }
        }
    }
    public class Vlogger
    {
        public Vlogger(string name)
        {
            Name = name;
            Followers = new SortedSet<string>();
            Following = new HashSet<string>();
        }

        public string Name { get; set; }
        public SortedSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }
    }
}