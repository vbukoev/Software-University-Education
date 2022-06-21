using System;

namespace _01.CounterStrike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int winsCnt = 0;
            while (command != "End of battle")
            {
                int distance = int.Parse(command);
                if (initialEnergy<distance)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {winsCnt} won battles and {initialEnergy} energy");
                    initialEnergy-=distance;
                    break;
                }
                winsCnt++;
                initialEnergy -= distance;
                if (winsCnt % 3 == 0) initialEnergy += winsCnt;
                command = Console.ReadLine();
            }            
            if (initialEnergy >= 0) Console.WriteLine($"Won battles: {winsCnt}. Energy left: {initialEnergy}");
            
        }
    }
}
