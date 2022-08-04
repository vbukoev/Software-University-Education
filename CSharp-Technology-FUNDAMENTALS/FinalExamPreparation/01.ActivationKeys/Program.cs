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
                   var substring = splitted[1];
                        if (actKey.Contains(substring)) Console.WriteLine($"{actKey} contains {substring}");
                        else Console.WriteLine("Substring not found!");
                        break;
                    case "Flip":
                    var cases = splitted[1];
                        var start = int.Parse(splitted[2]);
                        var end = int.Parse(splitted[3]);
                        var cnt = end - start;
                        substring = actKey.Substring(start, cnt);
                        var toChar= actKey.ToArray();
                        switch (cases)
                        {
                            case "Upper":
                                substring = substring.ToUpper();
                                var index = 0;
                                for (int i = start; i < end; i++)
                                {                                    
                                    toChar[i] = substring[index];
                                    index++;
                                }
                                actKey = String.Join("", toChar);
                                break;
                            case "Lower":
                                substring = substring.ToLower();
                                index = 0;
                                for (int i = start; i < end; i++)
                                {                                    
                                    toChar[i] = substring[index];
                                    index++;
                                }
                                actKey = String.Join("", toChar);
                                break;
                            default:
                                break;
                        }
                        Console.WriteLine(actKey);
                        break;
                    case "Slice":
                        start = int.Parse(splitted[1]);
                        end = int.Parse(splitted[2]);
                        cnt = end - start;
                        actKey = actKey.Remove(start, cnt);
                        Console.WriteLine(actKey);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"Your activation key is: {actKey}");
        }
    }
}