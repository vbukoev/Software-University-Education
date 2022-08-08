using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace _01.MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            var results = Regex.Matches(input, pattern);
            foreach (Match result in results) Console.Write(result.Value + " ");
        }
    }
}
