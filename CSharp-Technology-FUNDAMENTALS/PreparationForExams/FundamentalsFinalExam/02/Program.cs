using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var text = "";
            Regex pattern = new Regex(@"^!(?<validCommand>[A-Z][A-Za-z]{2,})!:\[(?<theStringWeLookFor>[A-Z)][A-Za-z]{8,})\]$");
            for (int i = 0; i < n; i++)
            {
                text = Console.ReadLine();
                var match = pattern.Match(text);
                if (match.Success)
                {
                    var cmd = match.Groups["validCommand"].Value;
                    var message = match.Groups["theStringWeLookFor"].Value; 
                    var arr = message.Select(x => "" + (int)x).ToArray();
                    Console.WriteLine($"{cmd}: {String.Join(" ", arr)}");
                }
                else Console.WriteLine("The message is invalid");
            }
        }
    }
}
//100/100
