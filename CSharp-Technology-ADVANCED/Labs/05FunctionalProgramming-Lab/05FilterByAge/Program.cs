using System;
using System.Collections.Generic;
using System.Linq;

namespace _05FilterByAge
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleCnt = int.Parse(Console.ReadLine());
            var people = new List<Person>();
            for (int i = 0; i < peopleCnt; i++)
            {
                var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = tokens[0];
                int personAge = int.Parse(tokens[1]);
                var person = new Person()
                {
                    Age = personAge,
                    Name = name
                };
                people.Add(person);
            }
            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            Func<Person, bool> filter = CreateFilter(condition, age);
            string format = Console.ReadLine();
            Func<Person, string> select = GetSelector(format);
            var res = people.Where(filterF)
        }

        static Func<Person, string> GetSelector(string format)
        {
            switch (format)
            {
                case "name age": return p => $"{p.Name} - {p.Age}";
                case "age": return p => $"{p.Age}";
                case "name": return p => $"{p.Name}";                
            }
           
        }

        public static Func<Person, bool> CreateFilter(string condition, int age)
    {
        switch (condition)
        {
            case "younger" return x => x < age; 
                    case "older" return x => x >= age;
            default: throw new ArgumentOutOfRangeException(condition);
                break;
        }
    } 
    }
}
