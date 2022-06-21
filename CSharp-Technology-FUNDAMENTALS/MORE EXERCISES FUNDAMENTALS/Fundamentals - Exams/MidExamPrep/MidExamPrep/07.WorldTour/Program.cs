
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
            string newLine = Console.ReadLine();
            string command = string.Empty;

            while (command != "Travel")
            {
                command = Console.ReadLine();
                string[] tokens = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                switch (action)
                {
                    case "Add Stop":
                        int firstSymbol = int.Parse(tokens[1]);
                        string name = tokens[2];
                        if (firstSymbol >= 0 && firstSymbol < newLine.Length)
                        {
                            newLine.Insert(firstSymbol, name);
                        }
                        Console.WriteLine(newLine);
                        break;
                    case "Remove Stop":
                        int startIndex = int.Parse(tokens[1]);
                        int lastIndex = int.Parse(tokens[2]);
                        if (startIndex >= 0 && startIndex < lastIndex && lastIndex < newLine.Length)
                        {
                            newLine.Remove(startIndex, lastIndex - startIndex);
                        }
                        Console.WriteLine(newLine);
                        break;
                    case "Switch":
                        string old = tokens[1];
                        string news = tokens[2];
                        newLine.Replace(old, news);
                        Console.WriteLine(newLine);
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {newLine}");
        }
    }
}
