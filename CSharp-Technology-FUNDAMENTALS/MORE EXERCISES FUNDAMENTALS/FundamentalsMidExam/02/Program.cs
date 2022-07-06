using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <int> sequence = Console.ReadLine().Split().Select(int.Parse).ToList();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Finish") break;
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = tokens[0];

                switch (action)
                {
                    case "Add":
                        int item = int.Parse(tokens[1]);
                        sequence.Add(item);
                        break;
                    case "Remove":
                        item = int.Parse(tokens[1]);
                        if (sequence.Contains(item)) sequence.Remove(item);
                        break;
                    case "Replace":
                        item = int.Parse(tokens[1]);
                        int replacement = int.Parse(tokens[2]);
                        int index = sequence.IndexOf(item);
                        if (sequence.Contains(item)) sequence[index] = replacement;
                        break;
                    case "Collapse":
                        item = int.Parse(tokens[1]);
                        sequence.RemoveAll(currNum => currNum < item); 
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(String.Join(" ", sequence));
        }
    }
}