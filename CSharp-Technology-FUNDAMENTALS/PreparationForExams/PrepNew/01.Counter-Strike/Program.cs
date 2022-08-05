using System;

namespace _01.Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialEnergt = int.Parse(Console.ReadLine());
            int wins = 0;
            while (true)
            {
                string command = Console.ReadLine();
                
                if (command == "End of battle") break;
                int distance = int.Parse(command);
                if (initialEnergt < distance)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wins} won battles and {initialEnergt} energy");
                    return;
                }
                else
                {
                    wins++;
                    initialEnergt -= distance;
                    if (wins%3==0)
                    {
                        initialEnergt += wins;
                    }
                }
            }
            if (initialEnergt >=0)
            {
                Console.WriteLine($"Won battles: {wins}. Energy left: {initialEnergt}");
            }
        }
    }
}
