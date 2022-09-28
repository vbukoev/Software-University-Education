﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Person()
        {
            this.Age = 1;
            this.Name = "No name";
        }
        public Person(int age) : this()
        {
            this.Age = age;
        }

        public Person(int age, string name)
        {
            Age = age;
            Name = name;
        }
    }
}
