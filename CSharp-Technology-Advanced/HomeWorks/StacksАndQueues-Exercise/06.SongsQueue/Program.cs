using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var queue = new Queue<string>(songs);
            string cmd = Console.ReadLine();
            while (queue.Count > 0)           
            {                
                var tokens = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var actions = tokens[0];
                switch (actions)
                {
                    case "Play":
                        queue.Dequeue();
                        break;
                    case "Add":
                        string nameOfTheSong = string.Join(" ", tokens.Skip(1).ToArray());
                        if (queue.Contains(nameOfTheSong)) Console.WriteLine($"{nameOfTheSong} is already contained!");
                        else   
                            queue.Enqueue(nameOfTheSong);                        
                        break;
                    case "Show": Console.WriteLine(string.Join(", ", queue));
                        break;
                    default:
                        break;
                }
                cmd = Console.ReadLine();
            }
            Console.WriteLine("No more songs!");
        }
    }
}