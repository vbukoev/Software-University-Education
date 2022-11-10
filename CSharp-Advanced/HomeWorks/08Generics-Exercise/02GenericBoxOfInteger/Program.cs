using System;

namespace _01GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var box = new Box<int>();
            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                box.Add(input);
            }
            Console.WriteLine(box);
        }
    }
}
