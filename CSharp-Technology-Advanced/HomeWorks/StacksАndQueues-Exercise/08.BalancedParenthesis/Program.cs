using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var stack = new Stack<char>();
            bool isBalanced = true;
            foreach (var symbol in input)
            {
                if (symbol == '(' || symbol == '[' || symbol == '{')
                {
                    stack.Push(symbol);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        isBalanced = false;
                        break; 
                    }
                    char lastSymbol = stack.Pop();
                    if (lastSymbol == ')' && lastSymbol != '(')
                    {
                        isBalanced = false;
                        break;
                    }
                    else if (lastSymbol == )
                    {

                    }
                    
                }
            }
        }
    }
}
