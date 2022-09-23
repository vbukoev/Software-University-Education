using System;
using System.IO;

namespace ReadingATextFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../scoreboard.txt"))
            {
                int cnt = 1;
                while (reader.EndOfStream)
                {
                    Console.WriteLine($"{cnt++} {reader.ReadLine()}");
                    cnt++;
                }
            }
        }
    }
}
