using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int cnt = int.Parse(Console.ReadLine());
            var family = new Family();
            for (int i = 0; i < cnt; i++)
            {
                var tokens = Console.ReadLine().Split().ToArray();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var person = new Person(name, age);
                family.AddMember(person);
            }
            var old = family.GetOldestMember();
            Console.WriteLine($"{old.Name} {old.Age}");
        }
    }
}
