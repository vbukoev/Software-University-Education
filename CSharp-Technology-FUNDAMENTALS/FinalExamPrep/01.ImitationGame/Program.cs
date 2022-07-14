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
                string[] tokens = cmd.Split('|');
                string action = tokens[0];
                switch (action)
                {
                    case "Move":
                        message = Move(message, tokens);
                        break;
                    case "Insert":
                        message = Insert(message, tokens);
                        break;
                    case "ChangeAll":
                        message = ChangeAll(message, tokens);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }
        static string Move(string message, string[] tokens)
        {
            int length = int.Parse(tokens[1]);
            string smthToMove = message.Substring(0, length);
            message = message.Remove(0, length);
            message += smthToMove;
            return message;
        }
        static string Insert(string message, string[] tokens)
        {
            int index = int.Parse(tokens[1]);
            string value = tokens[2];
            message = message.Insert(index, value);
            return message;
        }
        static string ChangeAll(string message, string[] tokens)
        {
            string substring = tokens[1];
            string replacemnet = tokens[2];
            message = message.Replace(substring, replacemnet);
            return message;
        }
    }
}
