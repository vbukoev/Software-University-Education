using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShootfortheWin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string command = Console.ReadLine();
            int cnt = 0;
            while (command != "End")
            {
                int index = int.Parse(command);
                if (index >= sequence.Count || index < 0 || sequence[index] == -1)
                {
                    command = Console.ReadLine();
                    continue;
                }
                int old = sequence[index];
                sequence[index] = -1;
                cnt++;
                for (int i = 0; i <= sequence.Count - 1; i++)
                {
                    if (sequence[i] == -1) continue;
                    if (old < sequence[i])
                    {
                        int @new = sequence[i] - old;
                        sequence[i] = @new;
                    }
                    else if (old >= sequence[i] && sequence[i] != -1)
                    {
                        int @new = old + sequence[i];
                        sequence[i] = @new;
                    }

                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Shot targets: {cnt} -> {string.Join(' ', sequence)}");
        }
    }
}
