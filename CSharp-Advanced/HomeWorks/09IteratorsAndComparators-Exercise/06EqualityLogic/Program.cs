namespace IteratorsAndComparators

{
using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var hashSet = new HashSet<Person>();
            var sortedSet = new SortedSet<Person>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var tokens = Console.ReadLine().Split();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var person = new Person(name, age);
                hashSet.Add(person);
                sortedSet.Add(person);
            }
            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
