using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            var sb = new StringBuilder();
            var lines = int.Parse(Console.ReadLine());
            for (int i = 1; i <= lines; i++)
            {
                var tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int cmd = tokens[0];

                switch (cmd)
                {
                    case 1:
                        int elementPush = tokens[1];
                        stack.Push(elementPush);
                        break; 
                    case 2:
                        if (stack.Count > 0) stack.Pop();
                        break;
                    case 3:
                        if (stack.Count > 0) sb.AppendLine(stack.Max().ToString());
                        break;
                    case 4:
                        if (stack.Count > 0) sb.AppendLine(stack.Min().ToString());     
                        break;
                    default:
                        break;
                }
            }        
            sb.AppendLine(String.Join(", ", stack));
            Console.WriteLine(sb);
        }
    }
}
