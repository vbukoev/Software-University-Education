using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!dictionary
                    .ContainsKey(name))
                    dictionary
                        .Add(name, new List<double>());
                dictionary[name]
                    .Add(grade);
            }
            foreach (var item in dictionary)
            {
                if (item.Value.Average() >= 4.50) Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
            }
        }
    }
}
