using System;

namespace _01.ImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            while (true)
            {
                string cmd= Console.ReadLine();
                if (cmd == "Decode") break;
                string[] tokens = cmd.Split("|");
                string action = tokens[0];
                switch (action)
                {
                    case "Move":
                        int length = int.Parse(tokens[1]);
                        string smthToMove = message.Substring(0, length);
                        message = message.Remove(0, length);
                        message += smthToMove;
                        break;
                    case "Insert":
                        int index = int.Parse(tokens[1]);
                        string value = tokens[2];
                        message = message.Insert(0, value);
                        break;
                    case "ChangeAll":
                        string substring = tokens[1];
                        string replacemnet = tokens[2];
                        message = message.Replace(substring, replacemnet);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
