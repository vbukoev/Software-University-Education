namespace IteratorsAndComparators

{
using System;
    using System.Linq;
    using System.Reflection;

    public class StartUp
    {
        static void Main(string[] args)
        {
            
            var stack = new Stack<int>();
            while (true)
            {
            var input = Console.ReadLine();
                if (input == "END") break;
                if (input.Contains("Push"))
                {
                    var nums = input.Split(new string[] { "Push", ", ", " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    stack.Push(nums);
                }
                else if (input.Contains("Pop"))
                {
                    try { stack.Pop(); }
                    catch (InvalidOperationException message) { Console.WriteLine(message.Message); }
                }
            }
            foreach (var item in stack) Console.WriteLine(item); 
            foreach (var item in stack) Console.WriteLine(item); 
        }
    }
}
