using System;
using System.Reflection.Metadata.Ecma335;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var a = Console.ReadLine();
            var b = Console.ReadLine();
            var scale = new EqualityScale<string>(a, b);
            Console.WriteLine(scale.AreEqual());
        }
    }
}
