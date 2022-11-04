namespace BirthdayCelebrations.Commands
{
    using System.Linq;
    public class CommandParser
    {
        public Command Parser(string input)
        {
            string[] parts = input.Split();
            string name = parts[0];
            string[] args = parts
                .Skip(1)
                .ToArray();
            return new Command(name, args);
        }
    }
}
