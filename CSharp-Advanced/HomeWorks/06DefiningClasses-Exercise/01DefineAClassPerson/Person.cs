using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Person(int age, string name)
        {
            Age = age;
            Name = name;
        }
    }
}
