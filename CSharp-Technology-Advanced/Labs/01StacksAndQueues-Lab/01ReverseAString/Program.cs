using System;
using System.Collections.Generic;

namespace _01ReverseAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack <char> stack = new Stack<char>();
            foreach (var character in input)
            {
                stack.Push(character);
            }
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}