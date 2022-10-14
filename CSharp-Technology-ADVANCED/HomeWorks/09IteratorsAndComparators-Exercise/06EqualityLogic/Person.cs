namespace IteratorsAndComparators
{
    using System;
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public int CompareTo(Person other)
        {
            var result = Name.CompareTo(other.Name);
            if (result == 0) return Age - other.Age;
            return result;
        }
        public override bool Equals(object obj)
        {
            return Name == ((Person)obj).Name && Age == ((Person)obj).Age;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Age.GetHashCode() + (257 * 53);
        }
    }
}