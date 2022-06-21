
//using System;

//namespace WorldTour
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            string text = Console.ReadLine();

//            string line = string.Empty;

//            while (line != "Travel")
//            {
//                line = Console.ReadLine();

//                string[] parts = line.Split(":", StringSplitOptions.RemoveEmptyEntries);

//                string command = parts[0];

//                if (command == "Add Stop")
//                {
//                    int idx = int.Parse(parts[1]);

//                    if (idx >= 0 && idx < text.Length)
//                    {
//                        string substr = parts[2];
//                        text = text.Insert(idx, substr);
//                    }

//                    Console.WriteLine(text);
//                }
//                else if (command == "Remove Stop")
//                {
//                    int startIdx = int.Parse(parts[1]);
//                    int endIdx = int.Parse(parts[2]);

//                    if (startIdx >= 0 && endIdx < text.Length)
//                    {
//                        text = text.Remove(startIdx, endIdx - startIdx + 1);
//                    }

//                    Console.WriteLine(text);
//                }
//                else if (command == "Switch")
//                {
//                    string oldText = parts[1];
//                    string newText = parts[2];

//                    if (text.Contains(oldText))
//                    {
//                        text = text.Replace(oldText, newText);
//                    }

//                    Console.WriteLine(text);
//                }
//            }

//            Console.WriteLine($"Ready for world tour! Planned stops: {text}");
//        }
//    }
//}



using System;

namespace _07.WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Travel")
            {                
                string[] tokens = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                if (action == "Add Stop")
                {
                    int idx = int.Parse(tokens[1]);

                    if (idx >= 0 && idx < text.Length)
                    {
                        string substr = tokens[2];
                        text = text.Insert(idx, substr);
                    }

                    Console.WriteLine(text);
                }
                else if (action == "Remove Stop")
                {
                    int startIdx = int.Parse(tokens[1]);
                    int endIdx = int.Parse(tokens[2]);

                    if (startIdx >= 0 && endIdx < text.Length)
                    {
                        text = text.Remove(startIdx, endIdx - startIdx + 1);
                    }

                    Console.WriteLine(text);
                }
                else if (action == "Switch")
                {
                    string oldText = tokens[1];
                    string newText = tokens[2];

                    if (text.Contains(oldText))
                    {
                        text = text.Replace(oldText, newText);
                    }

                    Console.WriteLine(text);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {text}");
        }
    }
}