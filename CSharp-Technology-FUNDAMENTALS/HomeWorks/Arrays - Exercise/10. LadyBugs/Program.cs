using System;
using System.Linq;

namespace _10._LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            int[] ladyBugsField = new int[fieldSize];//[0 0 0]

            string[] occupiedIndexes = Console.ReadLine().Split();// 0 1 => [1 1 0]

            for (int i = 0; i < occupiedIndexes.Length; i++)
            {
                int currIndex = int.Parse(occupiedIndexes[i]);
                if (currIndex >= 0 && currIndex < fieldSize)
                {
                    ladyBugsField[currIndex] = 1;

                }
            }
            string[] commands = Console.ReadLine().Split();
            while (commands[0] != "end")
            {
                bool isFirst = true;
                int currentIndex = int.Parse(commands[0]);
                while (currentIndex >= 0 && currentIndex < fieldSize && ladyBugsField[currentIndex] != 0)
                {
                    if (isFirst)
                    {
                        ladyBugsField[currentIndex] = 0;
                        isFirst = false;
                    }

                    string direction = commands[1];
                    int flightLength = int.Parse(commands[2]);
                    if (direction == "left")
                    {
                        currentIndex -= flightLength;
                        if (currentIndex >= 0 && currentIndex < fieldSize)
                        {
                            if (ladyBugsField[currentIndex] == 0)
                            {
                                ladyBugsField[currentIndex] = 1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        currentIndex += flightLength;
                        if (currentIndex >= 0 && currentIndex < fieldSize)
                        {
                            if (ladyBugsField[currentIndex] == 0)
                            {
                                ladyBugsField[currentIndex] = 1;
                                break;
                            }
                        }
                    }
                }
                commands = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", ladyBugsField));
        }
    }
}