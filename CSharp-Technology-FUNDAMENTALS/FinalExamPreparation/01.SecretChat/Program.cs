using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string cmd = Console.ReadLine();
            while (true)
            {
                if (cmd == "Reveal") break;
                var command = cmd.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                var action = command[0];
                switch (action)
                {
                    case "InsertSpace":
                        {
                            int index = int.Parse(command[1]);
                            if (index >= 0 && index < input.Length) input = input.Insert(index, " ");
                            break;
                        }
                    case "Reverse":
                        {
                            var index1 = command[1];
                            var charArray = index1.ToCharArray();
                            Array.Reverse(charArray);
                            if (input.Contains(index1))
                            {
                                string newString = new string(charArray);
                                Regex regPlace = new Regex(index1);
                                input = regPlace.Replace(input, "", 1);
                                input = input + newString;

                            }
                            else Console.WriteLine("error");
                            break;
                        }
                    case "ChangeAll":
                        {
                            string subString = command[1];
                            string replace = command[2];
                            input = input.Replace(subString, replace);
                            break;
                        }                        
                }
                Console.WriteLine(input);
                cmd = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {input}");
        }
    }
}
