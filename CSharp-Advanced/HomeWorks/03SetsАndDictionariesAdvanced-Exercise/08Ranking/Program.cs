using System;
using System.Collections.Generic;
using System.Linq;

namespace _08Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> candidates = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "end of contests") break;
                var credentials = cmd.Split(":", StringSplitOptions.RemoveEmptyEntries);
                contests.Add(credentials[0], credentials[1]);
            }

            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "end of submissions") break;
                var tokens = cmd.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string password = tokens[1];
                string candidate = tokens[2];
                int point = int.Parse(tokens[3]);
                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    UpsertCandidate(candidate, point, contest, candidates);
                }                
            }
            string bestCandidate = candidates.OrderByDescending(x => x.Value.Values.Sum()).First().Key;
            int bestCandidatePoints = candidates[bestCandidate].Values.Sum();
            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestCandidatePoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var candidate in candidates)
            {
                var orderByDesc = candidate.Value.OrderByDescending(x => x.Value); // similar as a dictionary but it is not
                Console.WriteLine(candidate.Key);
                foreach (var item in orderByDesc)
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }

        static void UpsertCandidate(string candidate, int point, string contest, SortedDictionary<string, Dictionary<string, int>> candidates)
        {
            if (!candidates.ContainsKey(candidate))
            {
                candidates[candidate] = new Dictionary<string, int>();
            }

            if (!candidates[candidate].ContainsKey(contest))
            {
                candidates[candidate][contest] = 0;
            }

            if (candidates[candidate][contest] < point)
            {
                candidates[candidate][contest] = point;
            }
        }
    }
}
