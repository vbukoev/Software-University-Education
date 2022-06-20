using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> sequenceOfElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            int turnNum = 1;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                int[] indexes = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int firstIndex = indexes[0];
                int secondIndex = indexes[1];
                if (firstIndex == secondIndex || firstIndex < 0 || firstIndex > sequenceOfElements.Count - 1|| secondIndex < 0 || secondIndex > sequenceOfElements.Count - 1 )
                {
                    sequenceOfElements.Insert(sequenceOfElements.Count / 2, $"-{turnNum}a");
                    sequenceOfElements.Insert(sequenceOfElements.Count / 2, $"-{turnNum}a");
                    Console.WriteLine("Invalid input! Adding aditional elements to the board");
                }
                else if(sequenceOfElements[firstIndex] == sequenceOfElements[secondIndex])
                {
                    string remove = sequenceOfElements[firstIndex];
                    sequenceOfElements.Remove(remove);
                    sequenceOfElements.Remove(remove);
                    Console.WriteLine($"Congrats! You have found matching elements - {remove}");
                }
                else
                {
                    Console.WriteLine("Try again!");
                }

                if (sequenceOfElements.Count == 0)
                {
                    Console.WriteLine($"You have won in {turnNum} turns!");
                    return;
                }
                else
                {
                    
                }
                turnNum++;
            }
            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(' ', sequenceOfElements));
        }
    }
}
