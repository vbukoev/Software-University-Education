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
            var people = new List<Person>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END") break;
                var tokens = input.Split();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var town = tokens[2];
                var person = new Person(name, age, town);
                people.Add(person);
            }
            var index = int.Parse(Console.ReadLine());
            index -= 1;
            var equalCnt = 0;
            var notEqualCnt = 0;
            var targetPerson = people[index];
            foreach (var person in people)
            {
                if (person.CompareTo(targetPerson)==0) equalCnt += 1; 
                else notEqualCnt += 1;
            }
            if (equalCnt > 1) Console.WriteLine($"{equalCnt} {notEqualCnt} {people.Count}");
            else Console.WriteLine("No matches");
        }
    }
}
