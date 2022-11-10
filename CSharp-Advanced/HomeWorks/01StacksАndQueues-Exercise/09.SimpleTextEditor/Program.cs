using System;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cntOfCommand = int.Parse(Console.ReadLine()); // n
            var textVersion = new Stack<string>();
            var sb = new StringBuilder();
            for (int i = 0; i < cntOfCommand; i++)
            {
                var tokens = Console.ReadLine().Split();
                int cmd = int.Parse(tokens[0]);
                switch (cmd)
                {
                    case 1:
                        textVersion.Push(sb.ToString());
                        string toAppend = tokens[1];
                        sb.Append(toAppend);
                        break;
                    case 2:
                        int cnt = int.Parse(tokens[1]);
                        textVersion.Push(sb.ToString());
                        sb.Remove(sb.Length - cnt, cnt);
                        break;
                    case 3:
                        int index = int.Parse(tokens[1]);
                        index--;
                        if (index >= 0 && index < sb.Length)
                        {
                            Console.WriteLine(sb[index]);
                        }
                        break;
                    case 4:
                        sb.Clear();
                        sb.Append(textVersion.Pop());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
