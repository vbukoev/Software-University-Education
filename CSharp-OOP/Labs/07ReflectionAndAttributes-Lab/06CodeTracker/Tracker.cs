namespace AuthorProblem
{
    using System;
    using System.Reflection;
    using System.Linq;

    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type authorAttributeType = typeof(AuthorAttribute);

            MethodInfo[] methodsByAuthor = Assembly.GetExecutingAssembly().GetTypes()
                .SelectMany(x => x
                    .GetMethods(
                                  BindingFlags.Instance
                                | BindingFlags.Public
                                | BindingFlags.Static))
                .Where(x=>x.GetCustomAttributes(authorAttributeType)
                    .Any())
                .ToArray();

            foreach (var methodByAuthor in methodsByAuthor)
            {
                var attributes = methodByAuthor.GetCustomAttributes<AuthorAttribute>();
                foreach (AuthorAttribute attribute in attributes)
                {
                    Console.WriteLine($"{methodByAuthor.Name} is written by {attribute.Name}");
                }
            }
        }
    }
}
