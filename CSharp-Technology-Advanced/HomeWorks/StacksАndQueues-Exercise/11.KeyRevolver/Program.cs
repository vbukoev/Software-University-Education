using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barelSize = int.Parse(Console.ReadLine());
            int[] bulletsInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locksInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int reward = int.Parse(Console.ReadLine());
            Queue<int> locks = new Queue<int>(locksInfo);
            Stack<int> bullets = new Stack<int>(bulletsInfo);

            int bulletsShot = 0; //counter of bullets

            while (bullets.Any() && locks.Any()) //while there are bullets and locks left!
            {
                int bulletSize = bullets.Pop(); // Remove it both cases 
                int lockSize = locks.Peek(); // we only peek the value
                bulletsShot++;
                if (bulletSize>=lockSize) // we shot that lock 
                {
                    locks.Dequeue(); // remove the lock
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
            }
        }
    }
}
