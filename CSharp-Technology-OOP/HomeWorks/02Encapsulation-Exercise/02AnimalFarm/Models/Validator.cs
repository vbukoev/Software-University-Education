using System;
namespace AnimalFarm.Models
{
    public class Validator
    {
        public const int MinAge = 0;
        public const int MaxAge = 15;
        private const string NameCannotBeEmptyException = "Name cannot be empty.";
        public static void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(NameCannotBeEmptyException);
            }
        }
        public static void ValidateAge(int age)
        {
            if (age<MinAge || age> MaxAge)
            {
                throw new ArgumentException($"Age should be between {MinAge} and {MaxAge}.");
            }
        }
    }
}
