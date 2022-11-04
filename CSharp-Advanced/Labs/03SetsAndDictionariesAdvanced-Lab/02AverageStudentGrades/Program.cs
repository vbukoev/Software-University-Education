using System;
using System.Collections.Generic;
using System.Linq;

namespace _02AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToArray();
                string name = input[0];
                decimal mark = decimal.Parse(input[1]);
                if (!students.ContainsKey(name)) students.Add(name, new List<decimal>());
                students[name].Add(mark);
            }
            foreach (var item in students)
            {
                Console.Write($"{item.Key} -> ");
                foreach (var grade in item.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {item.Value.Average():f2})");
            }
        }
    }
}

