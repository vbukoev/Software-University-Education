using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cmds = Console.ReadLine().Split(" ");
            List<Person> personlist = new List<Person> ();
            while (cmds[0] != "End")
            {
                var person = new Person(cmds[0], cmds[1], int.Parse(cmds[2]));
                personlist.Add(person);
                cmds = Console.ReadLine().Split();
            }
            foreach (var person in personlist.OrderBy(person => person.Age))
            {
                Console.WriteLine(person);
            }
        }
    }
    class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        } 
        public  string Name { get; set; }
        public  string ID { get; set; }
        public  int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
}
