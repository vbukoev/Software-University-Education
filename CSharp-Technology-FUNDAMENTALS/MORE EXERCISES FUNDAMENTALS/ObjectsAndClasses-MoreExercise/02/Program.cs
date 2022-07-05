using System;
using System.Collections.Generic;
using System.Linq;
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int numOfMember = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfMember; i++)
            {
                family.AddMember(Console.ReadLine().Split());

            }
            Person theOldest = family.Oldest();
            Console.WriteLine($"{theOldest.Name} {theOldest.Age}");
        }
    }
    class Person
    { 
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    class Family
    {
        public List<Person> FamilyPeople { get; set; } = new List<Person>();
        public void AddMember(string[] info)
        {
            Person newMember = new Person(info[0], int.Parse(info[1]));
            FamilyPeople.Add(newMember);
        }
        public Person Oldest() => FamilyPeople.OrderByDescending(member=>member.Age).First();        
    }
    class Family
    {

    }
    class Person
    {
        
    }
}
