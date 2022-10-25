using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var stringStack = new StackOfStrings();
            Console.WriteLine(stringStack.IsEmpty());
            stringStack.AddRange("1", "20", "43");
            Console.WriteLine(stringStack.IsEmpty());
        }
    }
}
