using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            var cmd = Console.ReadLine().ToLower();
            while (cmd != "end")
            {
                var splitted = cmd.Split();
                if (splitted[0] == "add")
                {
                    int firstNum = int.Parse(splitted[1]);
                    int secondNum = int.Parse(splitted[2]);
                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                if (splitted[0] == "remove")
                {
                    int cnt = int.Parse(splitted[1]);
                    if (cnt <= stack.Count)
                    {
                        for (int i = 0; i < cnt; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                cmd = Console.ReadLine().ToLower();
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
