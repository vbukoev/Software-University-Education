using System;
using System.Collections.Generic;

namespace _01._Sum_Adjacent_Equal_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();

            names.Add("Maria");
            names.Add("Ivan");
            names.Add("Asen");
            names.Add("Petar");
            names.Add("Georgi");

            Console.WriteLine(String.Join(", ", names));

            //foreach (string name in names)
            //{
            //    Console.WriteLine(name);
            //}

        }
    }
}
