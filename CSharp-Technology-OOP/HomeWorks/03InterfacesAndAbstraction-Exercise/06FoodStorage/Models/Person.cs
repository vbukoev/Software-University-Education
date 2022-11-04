namespace FoodStorage.Models
{
    using _06FoodStorage.Contracts;
    public abstract class Person : IBuyer
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        protected Person(string name, int age, string birthdate) : this(name, age)
        {
            Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }
        public string Birthdate { get; private set; }
        public int Food { get; protected set; }

        public abstract void BuyFood();
    }
}
