namespace PersonsInfo
{
    public class Person
    {
        //FirstName: string
        //LastName: string
        //Age: int
        //ToString(): string - override
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; set; }
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
        }
    }
}