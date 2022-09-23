using System;
using System.IO;

namespace DEMO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader(".. / .. / .. / input.txt");
            using (reader)
            {
                int counter = 1;
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                        break;
                    Console.WriteLine(++counter + ". " + line);
                }
            }

        }
    }
}
