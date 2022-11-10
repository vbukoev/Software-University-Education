using System;
using System.Linq;

namespace _11TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> check = (name, sum) => name.Sum(ch => ch) >= sum;
            Func<string[], int, Func<string, int, bool>, string> getFirstName = (names, sum, match) => names.FirstOrDefault(name => match(name, sum));
            
            int sum = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(getFirstName(names, sum, check));
            //ANOTHER SOLUTION TO THE PROBLEM
            //int num = int.Parse(Console.ReadLine());
            //var names = Console.ReadLine()
            //    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            //    .Where(x => x.ToCharArray().Sum(c => c) >= num)
            //    .ToList();
            //if (names.Count != 0) Console.WriteLine(names[0]); 
        }

       
    }
}