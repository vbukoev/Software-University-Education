using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            while (true)
            {
                var cmd = Console.ReadLine();
                if (cmd == "Done") break;
                var tokens = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var action = tokens[0];
                switch (action)
                {
                    case "Change":
                        {
                            var nChar = char.Parse(tokens[1]);
                            var replacement = char.Parse(tokens[2]);
                            input = input.Replace(nChar, replacement);
                            Console.WriteLine(input);
                            break;
                        }
                    case "Includes":
                        {
                            var substring = tokens[1];
                            if (!input.Contains(substring)) Console.WriteLine("False");
                            else Console.WriteLine("True");
                            break;
                        }                        
                    case "End":
                        {
                            var substring = tokens[1];
                            var finalLength = input.Substring(input.Length - substring.Length);
                            if (finalLength != substring) Console.WriteLine("False");
                            else Console.WriteLine("True");                                       
                            break;
                        }
                    case "Uppercase":
                        {
                            input = input.ToUpper();
                            Console.WriteLine(input);
                            break; 
                        }                        
                    case "FindIndex":
                        {
                            var newChar = char.Parse(tokens[1]);
                            var indexOfChar = input.IndexOf(newChar);
                            Console.WriteLine(indexOfChar);
                            break;
                        }
                    case "Cut":
                        {
                            var start = int.Parse(tokens[1]);
                            var cnt = int.Parse(tokens[2]);
                            input = input.Substring(start, cnt);
                            Console.WriteLine(input);
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
}
