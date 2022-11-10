namespace IteratorsAndComparators
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }
        public int CompareTo(Person other)
        {
            if (Name.CompareTo(other.Name) != 0) return Name.CompareTo(other.Name);
            if (Age - other.Age != 0) return Age - other.Age;
            if (Town.CompareTo(other.Town) != 0) return Town.CompareTo(other.Town);
            return 0;
        }
    }
}
