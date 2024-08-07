﻿using System;
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
            Person[] people = new Person[peopleCnt];
            Func<Person, string, int, bool> ageFilter = (p, c, a) => c == "older" ? p.Age >= a : p.Age < a;
            Func<Person, string[], string> formatter = (p, f) =>
            {
                string fString = string.Empty;
                if (f.Length == 2)
                {
                    if (f[0] == "name")
                    {
                        fString = "{0} - {1}";
                    }
                    else
                    {
                        fString = "{1} - {0}";
                    }
                }
                else
                {
                    if (f[0] == "name")
                    {
                        fString = "{0}";
                    }
                    else
                    {
                        fString = "{1}";
                    }
                }
                return string.Format(fString, p.Name, p.Age);
            };

            for (int i = 0; i < peopleCnt; i++)
            {
                var tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people[i] = new Person()
                {
                    Name = tokens[0],
                    Age = int.Parse(tokens[1])
                };
            }
            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string[] pattern = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, people
                .Where(p => ageFilter(p, condition, age)).Select(p => formatter(p, pattern))));
        }
    }
}

