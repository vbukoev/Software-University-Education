using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> sequence = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();
            int moves = 0;

            while (true)
            {
                if (command == "end")
                {
                    break;
                }

                moves++;
                string[] index = command.Split();
                int firstIndex = int.Parse(index[0]);
                int secIndex = int.Parse(index[1]);

                if (firstIndex>=0 && secIndex >=0 && firstIndex<sequence.Count && secIndex < sequence.Count && firstIndex != secIndex)
                {
                    if (sequence[firstIndex] == sequence[secIndex])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {sequence[firstIndex]}!");
                        if (firstIndex > secIndex)
                        {
                            sequence.RemoveAt(firstIndex);
                            sequence.RemoveAt(secIndex);
                        }
                        else
                        {
                            sequence.RemoveAt(secIndex);
                            sequence.RemoveAt(firstIndex);
                        }
                        if (sequence.Count == 0)
                        {
                            Console.WriteLine($"You have won in {moves} turns!");
                            return;
                        }
                    }
                    else if (sequence[firstIndex] != sequence[secIndex])
                    {
                        Console.WriteLine("Try again!");
                    }
                }                   
                else
                {
                    sequence.Insert(sequence.Count / 2, $"-{moves}a");
                    sequence.Insert(sequence.Count / 2, $"-{moves}a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
