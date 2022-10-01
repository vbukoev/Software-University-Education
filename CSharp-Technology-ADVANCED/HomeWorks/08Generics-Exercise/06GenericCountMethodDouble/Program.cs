using System;
using System.Linq;

namespace _01GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var box = new Box<double>();
            for (int i = 0; i < n; i++)
            {
                var input = double.Parse(Console.ReadLine());
                box.Add(input);
            }
            var value = double.Parse(Console.ReadLine());
            var greater = box.GreaterCount(value);
            Console.WriteLine(greater);
        }
    }
}
