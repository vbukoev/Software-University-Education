using System;
using System.Collections.Generic;

namespace DEMO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //push & pop & peek are important for the stack 
            //the elements could be added by stack.Push() 
            //the elements from the stack could be read by stack.Pop() 
            //depth-first-search - DFS - it is using stack (this is the use IRL)

            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
        }
    }
}
