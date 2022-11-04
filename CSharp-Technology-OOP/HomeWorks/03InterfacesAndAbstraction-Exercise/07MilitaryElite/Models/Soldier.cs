namespace MilitaryElite.Models
{
    using Interfaces;
    public abstract class Soldier : ISoldier
    {
        protected Soldier(int id, string firstName, string lastName) // it should always be protected constructor!!!
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id}";
        }
    }
}
