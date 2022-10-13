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
                string input = Console.ReadLine();
                if (input == "END") break;
                string[] tokens = input.Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];
                Person person = new Person(name, age, town);
                people.Add(person);
            }
            int index = int.Parse(Console.ReadLine());
            index -= 1;
            int equalCnt = 0;
            int notEqualCnt = 0;
            Person targetPerson = people[index];
            foreach (var person in people)
            {
                if (person.CompareTo(targetPerson)==0) equalCnt += 1; 
                else notEqualCnt += 1;
            }
            if (equalCnt > 1) // there were coincidence in the names
                Console.WriteLine($"{equalCnt} {notEqualCnt} {people.Count}");
            else Console.WriteLine("No matches");
        }
    }
}
