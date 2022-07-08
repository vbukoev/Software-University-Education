using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, List<string>>();
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "end") break;
                var tokens = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var courseName = tokens[0];
                var studentName = tokens[1];
                if (!dictionary.ContainsKey(courseName)) dictionary.Add(courseName, new List<string>());
                    dictionary[courseName].Add(studentName);
            }
            foreach (var course in dictionary)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var student in course.Value.OrderBy(x => x)) 
                    Console.WriteLine($"-- {student}");
            }
        }
    }
}
