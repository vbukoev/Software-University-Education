using System;
using System.Collections.Generic;

namespace _04.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> indices = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    indices.Push(i);
                    
                }

                if (expression[i] == ')')
                {
                    var startIndex = indices.Pop();

                    Console.WriteLine(expression.Substring(startIndex, i - startIndex + 1));
                }
            }
        }
    }
}
