using System;
using System.Collections.Generic;

namespace _08SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vip = new HashSet<string>();
            var guests = new HashSet<string>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "PARTY") break;
                foreach (var symbol in input)
                {
                    if (char.IsDigit(symbol))
                    {
                        vip.Add(input);
                    }
                    else
                    {
                        guests.Add(input);
                    }
                    break;
                }
            }

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "END") break;
                if (vip.Contains(command))
                {
                    vip.Remove(command);
                }
                if (guests.Contains(command))
                {
                    guests.Remove(command);
                }
            }
            int cnt = vip.Count + guests.Count;
            Console.WriteLine(cnt);
            foreach (var item in vip)
            {
                Console.WriteLine(item);
            }
            foreach (var item in guests)
            {
                Console.WriteLine(item);
            }
        }
    }
}
