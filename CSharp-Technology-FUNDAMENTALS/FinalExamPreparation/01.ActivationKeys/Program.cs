using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var actKey  = Console.ReadLine();
            var cmd = "";
            while (true)
            {
                cmd = Console.ReadLine();
                if (cmd == "Generate") break;
                var splitted = cmd.Split(">>>").ToArray();
                var action = splitted[0];
                switch (action)
                {
                   case "Contains":
                        {
                            var substring = splitted[1];
                            if (actKey.Contains(substring)) Console.WriteLine($"{actKey} contains {substring}");
                            else Console.WriteLine("Substring not found!");
                            break;
                        }
                    case "Flip":
                        {
                            var cases = splitted[1];
                            var cnt = int.Parse(splitted[3]) - int.Parse(splitted[2]);
                            var substring = actKey.Substring(int.Parse(splitted[2]), int.Parse(splitted[3]));
                            var toChar = actKey.ToArray();
                            switch (cases)
                            {
                                case "Upper":
                                    {
                                        substring = substring.ToUpper();
                                        var index = 0;
                                        for (int i = int.Parse(splitted[2]); i < int.Parse(splitted[3]); i++)
                                        {
                                            toChar[i] = substring[index];
                                            index++;
                                        }
                                        actKey = String.Join("", toChar);
                                        break;
                                    }
                                case "Lower":
                                    {
                                        substring = substring.ToLower();
                                        var index = 0;
                                        for (int i = int.Parse(splitted[2]); i < int.Parse(splitted[3]); i++)
                                        {
                                            toChar[i] = substring[index];
                                            index++;
                                        }
                                        actKey = String.Join("", toChar);
                                        break;
                                    }
                                default:
                                    break;
                            }
                            Console.WriteLine(actKey);
                            break;
                        }
                    case "Slice":
                        {
                            var cnt = int.Parse(splitted[2]) - int.Parse(splitted[1]);
                            actKey = actKey.Remove(int.Parse(splitted[1]), cnt);
                            Console.WriteLine(actKey);
                            break;
                        }
                    default:
                        break;
                }
            }
            Console.WriteLine($"Your activation key is: {actKey}");
        }
    }
}