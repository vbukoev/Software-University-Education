using System;
using System.Linq;

namespace _11TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {



            int num = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Where(x=>x.ToCharArray().Sum(c=>c)>=num).ToList();
            if (names.Count!=0)
            {
            Console.WriteLine(names[0]);

            }
        }
    }
}
