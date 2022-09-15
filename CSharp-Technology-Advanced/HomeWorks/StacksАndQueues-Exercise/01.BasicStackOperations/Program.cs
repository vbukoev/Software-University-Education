using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cmdNums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int elementToPush = cmdNums[0];
            int elementToPop = cmdNums[1];
            int elementToPeek = cmdNums[2];
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < elementToPush; i++) //push of the stack
            {
                stack.Push(input[i]);
            }
            //Stack<int> stack = new Stack<int>(input);

            for (int i = 1; i <= elementToPop; i++) //pop of the stack
            {
                stack.Pop();
            }
            if (stack.Contains(elementToPeek)) Console.WriteLine("true");
            else
            {
                if (stack.Any()) Console.WriteLine(stack.Min());
                else Console.WriteLine(0);
            }
        }
    }
}
