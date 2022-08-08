using System;

namespace _01.WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "Travel") break;
                string[] tokens = cmd.Split(":");
                string action = tokens[0];
                switch (action)
                {
                    case "Add Stop":
                        int index = int.Parse(tokens[1]);
                        string newStop = tokens[2];
                        if (index >= 0 && index < stops.Length) stops = stops.Insert(index, newStop);

                        break;
                    case "Remove Stop":
                        int start = int.Parse(tokens[1]);
                        int end = int.Parse(tokens[2]);
                        if (start >= 0 && start < stops.Length && end >= 0 && end < stops.Length) stops = stops.Remove(start, end - start + 1);
                        break;
                    case "Switch":
                        string oldString = tokens[1];
                        string newString = tokens[2];
                        if (stops.Contains(oldString)) stops = stops.Replace(oldString, newString);
                        break;
                }
                Console.WriteLine(stops);
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}

