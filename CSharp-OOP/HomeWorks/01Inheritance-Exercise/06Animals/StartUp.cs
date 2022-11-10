using System;
using System.Linq;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        public static void Main()
        {
            StringBuilder result = new StringBuilder();
            string cmd = Console.ReadLine();
            while (cmd != "Beast!")
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string gender = string.Empty;
                if (tokens.Length > 2) gender = tokens[2];
                if (cmd == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);
                    result.AppendLine(cat.ToString());
                }
                else if (cmd == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    result.AppendLine(dog.ToString());
                }
                else if (cmd== "Frog")
                {
                    Frog frog = new Frog(name, age, gender);
                    result.AppendLine(frog.ToString());
                }
                else if (cmd == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(name, age);
                    result.AppendLine(tomcat.ToString());
                }
                else if (cmd == "Kitten")
                {
                    Kitten kitten = new Kitten(name, age);
                    result.AppendLine(kitten.ToString());
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }
                cmd = Console.ReadLine();
            }
            Console.WriteLine(result.ToString());
        }
    }
}
