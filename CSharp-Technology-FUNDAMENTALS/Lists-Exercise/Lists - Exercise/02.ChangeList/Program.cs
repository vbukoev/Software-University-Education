using System;
using System.Linq;

namespace _02.ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string line = Console.ReadLine();

            while (line!="end")
            {
                string[] tokens = line.Split();
                string cmd = tokens[0];
                if (cmd == "Delete")
                {
                    int element = int.Parse(tokens[1]);
                    numbers.RemoveAll(el => el == element);
                }
                else if (cmd =="Insert")
                {
                    int element = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);
                    numbers.Insert(index, element);
                }
                line = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
