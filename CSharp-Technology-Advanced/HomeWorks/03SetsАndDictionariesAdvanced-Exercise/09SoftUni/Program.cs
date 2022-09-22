using System;
using System.Collections.Generic;
using System.Linq;

namespace _09SoftUni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<User> users = new List<User>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exam finished") break;
                string[] currUser = input.Split('-');
                string userName = currUser[0];
                User user = users.Find(x => x.Name == userName);
                if (currUser.Length == 3)
                {
                    string language = currUser[1];
                    int points = int.Parse(currUser[2]);
                    if (!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, 1);
                    }
                    else
                    {
                        submissions[language]++;
                    }
                    if (user == null)
                    {
                        user = new User(userName);
                        user.points.Add(language, points);
                        users.Add(user);
                    }
                    else
                    {
                        if (!user.points.ContainsKey(language))
                        {
                            user.points.Add(language, points);
                        }
                        else
                        {
                            if (points > user.points[language])
                            {
                                user.points[language] = points;
                            }
                        }
                    }
                }
                else // if he is cheating
                {
                    users.Remove(user);
                }
            }
            Console.WriteLine("Results:");
            foreach (var user in users.OrderByDescending(x=>x.MaxPoints()).ThenBy(x=>x.Name))
            {
                Console.WriteLine($"{user.Name} | {user.points.Values.Max()}");
            }
            Console.WriteLine("Submissions:");
            foreach (var item in submissions.OrderByDescending(x=>x.Value).ThenBy(y=>y.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
    class User
    {
        public string Name { get; set; }
        public Dictionary<string, int> points { get; set; }
        public User(string name)
        {
            Name = name;
            points = new Dictionary<string, int>();
        }
        public int MaxPoints()
        {
            int max = points.Values.Max();
            return max;
        }
    }
}
