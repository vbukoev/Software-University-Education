using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenToPass = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string cmd = Console.ReadLine();
            int cnt = 0;
            while (cmd != "end")
            {
                if (cmd == "green")
                {
                    for (int i = 0; i < greenToPass; i++)
                    {
                        if (cars.Count>0)
                        {
                            string car = cars.Dequeue();
                            Console.WriteLine($"{car} passed!");
                            cnt++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(cmd);
                }
                cmd = Console.ReadLine();
            }
            Console.WriteLine($"{cnt} cars passed the crossroads.");
        }
    }
}
