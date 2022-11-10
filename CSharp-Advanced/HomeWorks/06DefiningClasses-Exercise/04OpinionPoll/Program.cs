using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var person = new Person(name, age);
                people.Add(person);
            }
            var res = people.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
            foreach (var item in res)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
    }
}
